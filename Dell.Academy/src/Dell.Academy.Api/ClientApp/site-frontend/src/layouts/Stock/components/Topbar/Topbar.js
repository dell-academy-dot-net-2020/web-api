import React, { useEffect, useState } from "react";
import { Link as RouterLink, useHistory } from "react-router-dom";
import clsx from "clsx";
import PropTypes from "prop-types";
import { makeStyles } from "@material-ui/styles";
import {
  clearSession,
  isAuthenticated
} from "../../../../services/LoginService";
import {
  AppBar,
  Toolbar,
  Hidden,
  IconButton,
  Typography
} from "@material-ui/core";

// ICONS
import MenuIcon from "@material-ui/icons/Menu";
import Folder from "@material-ui/icons/Folder";
import InputIcon from "@material-ui/icons/Input";
import AccessTimeIcon from "@material-ui/icons/AccessTime";

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
    color: "white"
  },
  icon: {
    marginRight: "10px"
  },
  topbar: {
    backgroundColor: theme.palette.primary.dark
  }
}));

const Topbar = props => {
  const { className, onSidebarOpen, ...rest } = props;
  const classes = useStyles();
  const history = useHistory();
  const [datetimeNow, setDatetimeNow] = useState(new Date());

  useEffect(() => {
    setInterval(() => {
      setDatetimeNow(new Date());
    }, 60000);
  }, [datetimeNow]);

  const loggout = () => {
    clearSession();
    history.push("/");
  };

  return (
    <AppBar {...rest} className={clsx(classes.root, className, classes.topbar)}>
      <Toolbar>
        <RouterLink to="/">
          <IconButton className={classes.logo}>
            <Folder fontSize="large" className={classes.icon} />
            Dell Academy C# - 2020
          </IconButton>
        </RouterLink>
        <div className={classes.flexGrow} />
        <Hidden mdDown>
          <AccessTimeIcon className={classes.icon} />
          <Typography variant="body1" color="inherit" className={classes.icon}>
            {datetimeNow.toLocaleTimeString([], {
              hour: "2-digit",
              minute: "2-digit"
            })}{" "}
            {datetimeNow.toLocaleDateString()}
          </Typography>
          {isAuthenticated() && (
            <IconButton
              className={classes.icon}
              color="inherit"
              onClick={loggout}
            >
              <InputIcon />
            </IconButton>
          )}
        </Hidden>
        <Hidden lgUp>
          <IconButton color="inherit" onClick={onSidebarOpen}>
            <MenuIcon />
          </IconButton>
        </Hidden>
      </Toolbar>
    </AppBar>
  );
};

Topbar.propTypes = {
  className: PropTypes.string,
  onSidebarOpen: PropTypes.func
};

export default Topbar;
