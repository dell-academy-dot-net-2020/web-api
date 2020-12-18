import React from "react";
import PropTypes from "prop-types";
import clsx from "clsx";
import { makeStyles } from "@material-ui/styles";
import { Fab, Grid, Tooltip } from "@material-ui/core";
import AddIcon from "@material-ui/icons/Add";
import { SearchInput } from "components";
import { Link } from "react-router-dom";
import { isAuthenticated } from "../../../../services/LoginService";

const useStyles = makeStyles(theme => ({
  root: {},
  row: {
    height: "42px",
    display: "flex",
    alignItems: "center",
    marginTop: theme.spacing(1)
  },
  spacer: {
    flexGrow: 1
  },
  importButton: {
    marginRight: theme.spacing(1)
  },
  exportButton: {
    marginRight: theme.spacing(1)
  },
  searchInput: {
    marginRight: theme.spacing(1)
  }
}));

const useStylesBootstrap = makeStyles(theme => ({
  arrow: {
    color: theme.palette.common.black
  },
  tooltip: {
    backgroundColor: theme.palette.common.black,
    fontSize: "12px"
  }
}));

const CategoriesToolbar = props => {
  const searchCategory = e => props.searchCategory(e.target.value);
  const classes = useStyles();
  const tooltipClasses = useStylesBootstrap();

  const link = isAuthenticated() ? "/categorias/cadastrar" : "#";
  const tooltip = isAuthenticated()
    ? "cadastrar"
    : "faça login para ter acesso";

  return (
    <div className={clsx(classes.root)}>
      <div className={classes.row}>
        <Grid item md={3} xs={3}>
          <span className={classes.spacer} />
          <Link to={link}>
            <Tooltip title={tooltip} classes={tooltipClasses} placement="right">
              <Fab color="secondary" aria-label="add" size="medium">
                <AddIcon />
              </Fab>
            </Tooltip>
          </Link>
        </Grid>
        <Grid item md={9} xs={9} container justify="flex-end">
          <Grid item md={4} xs={9}>
            <SearchInput
              className={classes.searchInput}
              onChange={e => searchCategory(e)}
              placeholder="Procurar"
            />
          </Grid>
        </Grid>
      </div>
    </div>
  );
};

CategoriesToolbar.propTypes = {
  className: PropTypes.string
};

export default CategoriesToolbar;
