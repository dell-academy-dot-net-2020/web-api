import React from "react";
import { makeStyles } from "@material-ui/styles";
import { Button } from "@material-ui/core";

export default props => {
  const useStyles = makeStyles(theme => ({
    btnColor: {
      backgroundColor: theme.palette[props.btnColor].main,
      color: theme.palette[props.btnColor].contrastText,
      "&:hover": {
        backgroundColor: theme.palette[props.btnColor].dark
      }
    }
  }));

  const classes = useStyles(props);

  return (
    <Button className={classes.btnColor} variant="contained" type={props.type}>
      {props.text}
    </Button>
  );
};
