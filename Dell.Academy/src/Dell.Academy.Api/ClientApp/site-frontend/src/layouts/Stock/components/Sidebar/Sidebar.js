import React from "react";
import clsx from "clsx";
import PropTypes from "prop-types";
import { makeStyles } from "@material-ui/styles";
import { Drawer, Typography } from "@material-ui/core";
import BusinessIcon from '@material-ui/icons/Business';
import ListAltIcon from '@material-ui/icons/ListAlt';
import CategoryIcon from '@material-ui/icons/Category';
import {  SidebarNav } from "./components";

const useStyles = makeStyles(theme => ({
  drawer: {
    width: 240,
    [theme.breakpoints.up("lg")]: {
      marginTop: 64,
      height: "calc(100% - 64px)"
    }
  },
  root: {
    backgroundColor: theme.palette.primary.dark,
    display: "flex",
    flexDirection: "column",
    height: "100%",
    padding: theme.spacing(2)
  },
  divider: {
    margin: theme.spacing(2, 0)
  },
  nav: {
    marginBottom: theme.spacing(2)
  },
  text: {
    color: "#9e9e9e",
    textAlign: "center",
  },
  textDiv: {
    marginTop: "auto"
  }
}));

const Sidebar = props => {
  const { open, variant, onClose, className, ...rest } = props;
  const classes = useStyles();

  const pages = [
    {
      title: "Produtos",
      href: "/produtos/listar",
      icon: <ListAltIcon />
    },
    {
      title: "Fornecedores",
      href: "/fornecedores/listar",
      icon: <BusinessIcon />
    },
    {
      title: "Categorias",
      href: "/categorias/listar",
      icon: <CategoryIcon />
    }
  ];

  return (
    <Drawer
      anchor="left"
      classes={{ paper: classes.drawer }}
      onClose={onClose}
      open={open}
      variant={variant}
    >
      <div {...rest} className={clsx(classes.root, className)}>
        <SidebarNav className={classes.nav} pages={pages} />
        <div className={classes.textDiv}>
        <Typography variant="body1" className={classes.text}>
          &copy; Regis Lima - 2020
        </Typography>
        <Typography variant="body2" className={classes.text}>
          Made with <i className={`fab fa-react ${classes.icon}`}></i>
        </Typography>
        </div>
      </div>
    </Drawer>
  );
};

Sidebar.propTypes = {
  className: PropTypes.string,
  onClose: PropTypes.func,
  open: PropTypes.bool.isRequired,
  variant: PropTypes.string.isRequired
};

export default Sidebar;
