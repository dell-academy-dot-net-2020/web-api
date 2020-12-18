import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Modal from "@material-ui/core/Modal";
import Backdrop from "@material-ui/core/Backdrop";
import Fade from "@material-ui/core/Fade";
import { Grid, Typography } from "@material-ui/core";
import IconButton from "@material-ui/core/IconButton";

const useStyles = makeStyles(theme => ({
  modal: {
    display: "flex",
    alignItems: "center",
    justifyContent: "center"
  },
  paper: {
    backgroundColor: theme.palette.background.paper,
    border: "2px solid #000",
    boxShadow: theme.shadows[5],
    padding: theme.spacing(2, 4, 3)
  },
  confirm: {
    color: theme.palette.success.main
  },
  cancel: {
    color: theme.palette.error.main
  }
}));

export default props => {
  const classes = useStyles();

  return (
    <div>
      <Modal
        aria-labelledby="transition-modal-title"
        aria-describedby="transition-modal-description"
        className={classes.modal}
        open={props.open}
        onClose={props.close}
        closeAfterTransition
        BackdropComponent={Backdrop}
        BackdropProps={{
          timeout: 500
        }}
      >
        <Fade in={props.open}>
          <div className={classes.paper}>
            <Typography variant="h2" id="transition-modal-title">Confirmar a exclusão?</Typography>
            <Grid>
              <IconButton
                className={classes.confirm}
                component="span"
                onClick={props.delConfirmed}
              >
                <i className="material-icons md-36">check</i>
              </IconButton>
              <IconButton
                className={classes.cancel}
                component="span"
                onClick={props.close}
              >
                <i className="material-icons md-36">close</i>
              </IconButton>
            </Grid>
          </div>
        </Fade>
      </Modal>
    </div>
  );
};
