import React, { useEffect } from "react";
import { makeStyles } from "@material-ui/styles";
import { bindActionCreators } from "redux";
import { connect } from "react-redux";
import {
  getProducts,
  delProduct,
  delProductConfirmed,
  setProductsFound,
} from "../../../store/stock/productsReducer";
import { closeNotification } from "../../../store/notificationsReducer";
import { closeModal } from "../../../store/modalReducer";

import { ProductsToolbar, ProductsTable } from "./components";
import { Notification, ConfirmModal } from "../../../common";

const useStyles = makeStyles((theme) => ({
  root: {
    padding: theme.spacing(3),
  },
  content: {
    marginTop: theme.spacing(2),
  },
}));

const ProductsList = (props) => {
  const classes = useStyles();

  useEffect(() => {
    props.getProducts();
  }, []);

  const searchProduct = (name) => {
    if (name.trim()) {
      const productsFound = props.products.filter((e) =>
        e.name.toUpperCase().includes(name.toUpperCase())
      );
      props.setProductsFound(productsFound, true);
    } else {
      props.setProductsFound([], false);
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
          delConfirmed={props.delProductConfirmed}
        ></ConfirmModal>
      )}
      <ProductsToolbar searchProduct={searchProduct} />
      <div className={classes.content}>
        <ProductsTable
          products={props.search ? props.productsFound : props.products}
          delproduct={(id) => props.delProduct(id)}
        />
      </div>
    </div>
  );
};

const mapStateToProps = (state) => ({
  products: state.products.list,
  notification: state.notification,
  productsFound: state.products.foundList,
  search: state.products.search,
  modal: state.modal,
});

const mapDispatchToProps = (dispatch) =>
  bindActionCreators(
    {
      getProducts,
      setProductsFound,
      delProduct,
      delProductConfirmed,
      closeNotification,
      closeModal,
    },
    dispatch
  );

export default connect(mapStateToProps, mapDispatchToProps)(ProductsList);
