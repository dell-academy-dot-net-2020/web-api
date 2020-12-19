import React, { useState } from "react";
import { useHistory } from "react-router-dom";
import clsx from "clsx";
import PropTypes from "prop-types";
import DoneIcon from "@material-ui/icons/Done";
import ClearIcon from "@material-ui/icons/Clear";
import VisibilityIcon from "@material-ui/icons/Visibility";
import VisibilityOffIcon from "@material-ui/icons/VisibilityOff";
import PerfectScrollbar from "react-perfect-scrollbar";
import IconButtonTooltip from "../../../../common/IconButtonTooltip";
import { isAuthenticated } from "../../../../services/LoginService";

import { makeStyles } from "@material-ui/styles";
import {
  Card,
  CardActions,
  CardContent,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
  Typography,
  TablePagination,
} from "@material-ui/core";
import { getProduct } from "store/stock/productsReducer";

const useStyles = makeStyles((theme) => ({
  root: {},
  content: {
    padding: 0,
  },
  inner: {
    minWidth: 1050,
  },
  nameContainer: {
    display: "flex",
    alignItems: "center",
  },
  actions: {
    justifyContent: "flex-end",
  },
  error: {
    color: theme.palette.primary.main,
  },
}));

const ProductsTable = (props) => {
  const products = props.products;
  const history = useHistory();
  const classes = useStyles();

  const [rowsPerPage, setRowsPerPage] = useState(10);
  const [page, setPage] = useState(0);
  const [showImages, setShowImages] = useState(true);

  const handlePageChange = (event, page) => {
    setPage(page);
  };

  const handleRowsPerPageChange = (event) => {
    setRowsPerPage(event.target.value);
  };

  const delProduct = (id) => {
    isAuthenticated() ? props.delproduct(id) : console.log();
  };

  const tooltipEdit = isAuthenticated()
    ? "editar"
    : "faça login para ter acesso";
  const tooltipExcluir = isAuthenticated()
    ? "excluir"
    : "faça login para ter acesso";

  const editProduct = (id) => {
    const link = isAuthenticated() ? `/produtos/cadastrar/${id}` : "#";
    return history.push(link);
  };

  const getProduct = (id) => history.push(`/produtos/detalhar/${id}`);

  return (
    <Card className={clsx(classes.root)}>
      <CardContent className={classes.content}>
        <PerfectScrollbar>
          <div className={classes.inner}>
            <Table>
              <TableHead>
                <TableRow>
                  <TableCell>Nome</TableCell>
                  <TableCell>Valor</TableCell>
                  <TableCell>Ativo?</TableCell>
                  <TableCell>Fornecedor</TableCell>
                  <TableCell>Opções</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {products.length === 0 ? (
                  <TableRow>
                    <TableCell colSpan={6} style={{ textAlign: "center" }}>
                      <Typography variant="h3" data-testid="no-products">
                        Nenhum registro encontrado
                      </Typography>
                    </TableCell>
                  </TableRow>
                ) : (
                  <>
                    {products.slice(0, rowsPerPage).map((product) => (
                      <TableRow
                        className={classes.tableRow}
                        hover
                        key={product.id}
                      >
                        <TableCell>
                          <div className={classes.nameContainer}>
                            <Typography variant="body1">
                              {product.name}
                            </Typography>
                          </div>
                        </TableCell>
                        <TableCell>{product.value}</TableCell>
                        <TableCell>
                          {product.active ? <DoneIcon /> : <ClearIcon />}
                        </TableCell>
                            <TableCell>{product.providerName}</TableCell>
                            <TableCell>
                              <IconButtonTooltip
                                title="ver detalhes"
                                color="info"
                                icon="pageview"
                                onClick={() => getProduct(product.id)}
                              />
                              <IconButtonTooltip
                                title={tooltipEdit}
                                color="primary"
                                icon="edit"
                                onClick={() => editProduct(product.id)}
                              />
                              <IconButtonTooltip
                                title={tooltipExcluir}
                                color="error"
                                icon="delete"
                                onClick={() => delProduct(product.id)}
                              />
                            </TableCell>
                      </TableRow>
                    ))}
                  </>
                )}
              </TableBody>
            </Table>
          </div>
        </PerfectScrollbar>
      </CardContent>
      <CardActions className={classes.actions}>
        <TablePagination
          component="div"
          count={products.length}
          onChangePage={handlePageChange}
          onChangeRowsPerPage={handleRowsPerPageChange}
          page={page}
          rowsPerPage={rowsPerPage}
          rowsPerPageOptions={[5, 10, 25]}
        />
      </CardActions>
    </Card>
  );
};

ProductsTable.propTypes = {
  className: PropTypes.string,
  products: PropTypes.array.isRequired,
};

export default ProductsTable;
