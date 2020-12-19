import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Tooltip from "@material-ui/core/Tooltip";
import IconButton from "@material-ui/core/IconButton";

const useStylesBootstrap = makeStyles(theme => ({
  arrow: {
    color: theme.palette.common.black
  },
  tooltip: {
    backgroundColor: theme.palette.common.black,
    fontSize: "12px"
  }
}));


export default props => {
  const classes = useStylesBootstrap();
  const color = props.color ?? 'primary';

  const iconStyle = makeStyles((theme) => ({
    color: {
      color: theme.palette[color].main
    }
  }));
  const iconClasses = iconStyle();

  return (
    <Tooltip title={props.title} classes={classes}>
      <IconButton className={iconClasses.color} component="span" onClick={props.onClick}>
        <i className="material-icons md-36">{props.icon}</i>
      </IconButton>
    </Tooltip>
  );
};
