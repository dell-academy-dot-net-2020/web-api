import React, { useState } from "react";
import { useHistory } from "react-router-dom";
import clsx from "clsx";
import PropTypes from "prop-types";
import DoneIcon from "@material-ui/icons/Done";
import ClearIcon from "@material-ui/icons/Clear";
import PerfectScrollbar from "react-perfect-scrollbar";
import IconButtonTooltip from "../../../../common/IconButtonTooltip";
import { isAuthenticated } from "../../../../services/LoginService";

import { makeStyles } from "@material-ui/styles";
import
{
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
import { getProviders } from "store/stock/providersReducer";

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

const ProductsTable = (props) =>
{
  const providers = props.providers;
  const history = useHistory();
  const classes = useStyles();

  const [rowsPerPage, setRowsPerPage] = useState(10);
  const [page, setPage] = useState(0);

  const handlePageChange = (event, page) =>
  {
    setPage(page);
  };

  const handleRowsPerPageChange = (event) =>
  {
    setRowsPerPage(event.target.value);
  };

  const delProduct = (id) =>
  {
    isAuthenticated() ? props.delproduct(id) : console.log();
  };

  const tooltipEdit = isAuthenticated()
    ? "editar"
    : "faça login para ter acesso";
  const tooltipExcluir = isAuthenticated()
    ? "excluir"
    : "faça login para ter acesso";

  const editProduct = (id) =>
  {
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
                  <TableCell>Documento</TableCell>
                  <TableCell>Ativo?</TableCell>
                  <TableCell>Tipo do Fornecedor</TableCell>
                  <TableCell>Opções</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {providers.length === 0 ? (
                  <TableRow>
                    <TableCell colSpan={6} style={{ textAlign: "center" }}>
                      <Typography variant="h3" data-testid="no-products">
                        Nenhum registro encontrado
                      </Typography>
                    </TableCell>
                  </TableRow>
                ) : (
                    <>
                      {providers.slice(0, rowsPerPage).map((provider) => (
                        <TableRow
                          className={classes.tableRow}
                          hover
                          key={provider.id}
                        >
                          <TableCell>
                            <div className={classes.nameContainer}>
                              <Typography variant="body1">
                                {provider.name}
                              </Typography>
                            </div>
                          </TableCell>
                          <TableCell>{provider.documentNumber}</TableCell>
                          <TableCell>
                            {provider.active ? <DoneIcon /> : <ClearIcon />}
                          </TableCell>
                          {provider.providerType === 1 ? 
                            <TableCell>Pessoa física</TableCell> : 
                            <TableCell>Pessoa jurídica</TableCell>
                          }
                          <TableCell>
                            <IconButtonTooltip
                              title="ver detalhes"
                              color="info"
                              icon="pageview"
                              onClick={() => getProduct(provider.id)}
                            />
                            <IconButtonTooltip
                              title={tooltipEdit}
                              color="primary"
                              icon="edit"
                              onClick={() => editProduct(provider.id)}
                            />
                            <IconButtonTooltip
                              title={tooltipExcluir}
                              color="error"
                              icon="delete"
                              onClick={() => delProduct(provider.id)}
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
          count={providers.length}
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
