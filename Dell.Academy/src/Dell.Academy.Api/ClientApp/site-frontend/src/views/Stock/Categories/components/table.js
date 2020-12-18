import React, { useState } from "react";
import { useHistory } from "react-router-dom";
import clsx from "clsx";
import PropTypes from "prop-types";
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

const CategoriesTable = (props) => {
  const categories = props.categories;
  const history = useHistory();
  const classes = useStyles();

  const [rowsPerPage, setRowsPerPage] = useState(10);
  const [page, setPage] = useState(0);

  const handlePageChange = (event, page) => {
    setPage(page);
  };

  const handleRowsPerPageChange = (event) => {
    setRowsPerPage(event.target.value);
  };

  const delCategory = (id) => {
    isAuthenticated() ? props.delcategory(id) : console.log();
  };

  const tooltipEdit = isAuthenticated()
    ? "editar"
    : "faça login para ter acesso";
  const tooltipExcluir = isAuthenticated()
    ? "excluir"
    : "faça login para ter acesso";

  const editCategory = (id) => {
    const link = isAuthenticated() ? `/categorias/cadastrar/${id}` : "#";
    return history.push(link);
  };

  const getCategory = id => history.push(`/categorias/detalhar/${id}`)

  return (
    <Card className={clsx(classes.root)}>
      <CardContent className={classes.content}>
        <PerfectScrollbar>
          <div className={classes.inner}>
            <Table>
              <TableHead>
                <TableRow>
                  <TableCell align="center">Nome</TableCell>
                  <TableCell align="center">Opções</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {categories.length === 0 ? (
                  <TableRow>
                    <TableCell colSpan={6} align="center">
                      <Typography variant="h3">
                        Nenhum registro encontrado
                      </Typography>
                    </TableCell>
                  </TableRow>
                ) : (
                  <>
                    {categories.slice(0, rowsPerPage).map((category) => (
                      <TableRow
                        className={classes.tableRow}
                        hover
                        key={category.id}
                      >
                        <TableCell align="center">
                              {category.name}
                        </TableCell>
                        <TableCell align="center">
                        <IconButtonTooltip
                            title="ver detalhes"
                            color="info"
                            icon="pageview"
                            onClick={() => getCategory(category.id)}
                          />
                          <IconButtonTooltip
                            title={tooltipEdit}
                            color="primary"
                            icon="edit"
                            onClick={() => editCategory(category.id)}
                          />
                          <IconButtonTooltip
                            title={tooltipExcluir}
                            color="error"
                            icon="delete"
                            onClick={() => delCategory(category.id)}
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
          count={categories.length}
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

CategoriesTable.propTypes = {
  className: PropTypes.string,
  categories: PropTypes.array.isRequired,
};

export default CategoriesTable;
