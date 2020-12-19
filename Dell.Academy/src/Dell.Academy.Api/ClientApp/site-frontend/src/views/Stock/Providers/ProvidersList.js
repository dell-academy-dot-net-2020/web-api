import React, { useEffect } from "react";
import { makeStyles } from "@material-ui/styles";
import { bindActionCreators } from "redux";
import { connect } from "react-redux";
import { getProviders, setProvidersFound } from "../../../store/stock/providersReducer"
import { closeNotification } from "../../../store/notificationsReducer";
import { closeModal } from "../../../store/modalReducer";

import { ProductsToolbar, ProductsTable } from "./components";
import { Notification, ConfirmModal } from "../../../common";

const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(3)
  },
  content: {
    marginTop: theme.spacing(2)
  }
}));

const ProvidersList = props => {
  const classes = useStyles();

  useEffect(() => {
    props.getProviders();
  }, []);

  const searchPerson = name => {
    if (name.trim()) {
      const personsFound = props.persons.filter(e =>
        e.name.toUpperCase().includes(name.toUpperCase())
      );
      props.setPersonsFound(personsFound, true);
    } else {
      props.setPersonsFound([], false);
    }
  };

  return (
    <div className={classes.root}>
      {props.notification.open && (
        <Notification
          color={props.notification.color}
          message={props.notification.message}
          onClose={props.closeNotification}
        ></Notification>
      )}
      {props.modal.open && (
        <ConfirmModal
          open={props.modal.open}
          close={props.closeModal}
          delPersonConfirmed={props.delPersonConfirmed}
        ></ConfirmModal>
      )}
      <ProductsToolbar searchPerson={searchPerson} />
      <div className={classes.content}>
        <ProductsTable
          providers={props.search ? props.personsFound : props.providers}
          delperson={id => props.delPerson(id)}
        />
      </div>
    </div>
  );
};

const mapStateToProps = state => ({
  providers: state.providers.list,
  notification: state.notification,
  providersFound: state.providers.foundList,
  search: state.providers.search,
  modal: state.modal
});

const mapDispatchToProps = dispatch =>
  bindActionCreators(
    { getProviders, setProvidersFound
      //  setPersonsFound, delPerson, delPersonConfirmed, closeNotification, closeModal 
      },
    dispatch
  );

export default connect(mapStateToProps, mapDispatchToProps)(ProvidersList);
