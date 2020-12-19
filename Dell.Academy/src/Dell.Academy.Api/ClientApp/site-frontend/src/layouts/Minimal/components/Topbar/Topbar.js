import React from 'react';
import { Link as RouterLink } from 'react-router-dom';
import clsx from 'clsx';
import PropTypes from 'prop-types';
import { makeStyles } from '@material-ui/styles';
import { AppBar, Toolbar, IconButton } from '@material-ui/core';
import Folder from "@material-ui/icons/Folder";

const useStyles = makeStyles(theme => ({
  root: {
    boxShadow: "none"
  },
  flexGrow: {
    flexGrow: 1
  },
  signOutButton: {
    marginLeft: theme.spacing(1)
  },
  logo: {
    color: "white",
  },
  icon: {
    marginRight: "10px"
  },
  topbar: {
    backgroundColor: theme.palette.primary.dark
  }
}));

const Topbar = props => {
  const { className, ...rest } = props;

  const classes = useStyles();

  return (
    <AppBar
      {...rest}
      className={clsx(classes.root, className, classes.topbar)}
      color="primary"
      position="fixed"
    >
      <Toolbar>
      <RouterLink to="/">
          <IconButton className={classes.logo}>
            <Folder fontSize="large" className={classes.icon}/>
              Projetos
          </IconButton>
        </RouterLink>
      </Toolbar>
    </AppBar>
  );
};

Topbar.propTypes = {
  className: PropTypes.string
};

export default Topbar;
