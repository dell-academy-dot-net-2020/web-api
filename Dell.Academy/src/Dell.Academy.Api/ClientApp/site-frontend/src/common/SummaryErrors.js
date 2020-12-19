import React from "react";
import { Alert, AlertTitle } from "@material-ui/lab";
import { makeStyles } from "@material-ui/core/styles";
import { Typography } from "@material-ui/core";
import CloseIcon from "@material-ui/icons/Close";
import IconButton from "@material-ui/core/IconButton";

const useStyles = makeStyles(theme => ({
  root: {
    width: "100%",
    "& > * + *": {
      marginTop: theme.spacing(2)
    }
  }
}));

export default props => {
  const errors = props.errors;
  const classes = useStyles();

  return (
    <>
      <div className={classes.root}>
        <Alert
          severity="error"
          action={
            <IconButton
              aria-label="close"
              color="inherit"
              size="small"
              onClick={props.closeNotification}
            >
              <CloseIcon fontSize="inherit" />
            </IconButton>
          }
        >
          <AlertTitle variant="h4">Opa! Algo deu errado :(</AlertTitle>
          {errors.map((error, index) => (
            <Typography variant="body1" key={index}>
              <li>{error}</li>
            </Typography>
          ))}
        </Alert>
      </div>
    </>
  );
};
