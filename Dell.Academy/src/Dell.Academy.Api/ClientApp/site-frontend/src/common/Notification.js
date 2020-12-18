import React from "react";
import Snackbar from "@material-ui/core/Snackbar";
import MuiAlert from "@material-ui/lab/Alert";
import { makeStyles } from "@material-ui/styles";
import { Typography } from "@material-ui/core";

function Alert(props) {
  return <MuiAlert elevation={6} variant="filled" {...props} />;
}

export default props => {
  const useStyles = makeStyles(theme => ({
    color: {
      backgroundColor: theme.palette[props.color].main,
      color: theme.palette[props.color].contrastText,
    },
    textColor: {
      color: theme.palette[props.color].contrastText,
    }
  }));

  const classes = useStyles(props);

  const open = true;

  return (  
    <Snackbar
      open={open}
      autoHideDuration={5000}
      onClose={props.onClose}
      anchorOrigin={{vertical: "top", horizontal: "center"}}
    >
      <Alert onClose={props.onClose} severity={props.color}>
        <Typography variant="h5" className={classes.textColor}>{props.message}</Typography>
      </Alert>
    </Snackbar>
  );
};
