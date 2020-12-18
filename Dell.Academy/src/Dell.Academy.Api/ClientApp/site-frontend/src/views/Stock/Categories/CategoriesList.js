import React, { useEffect } from "react";
import { makeStyles } from "@material-ui/styles";
import { bindActionCreators } from "redux";
import { connect } from "react-redux";
import { getCategories, delCategory, delCategoryConfirmed, setCategoriesFound } from "../../../store/stock/categoriesReducer";
import { closeNotification } from "../../../store/notificationsReducer";
import { closeModal } from "../../../store/modalReducer";

import { CategoriesToolbar, CategoriesTable } from "./components";
import { Notification, ConfirmModal } from "../../../common";

const useStyles = makeStyles((theme) => ({
  root: {
    padding: theme.spacing(3),
  },
  content: {
    marginTop: theme.spacing(2),
  },
}));

const CategoriesList = (props) => {
  const classes = useStyles();

  useEffect(() => {
    props.getCategories();
  }, []);

  const searchCategory = (name) => {
    if (name.trim()) {
      const categoriesFound = props.categories.filter((e) =>
        e.name.toUpperCase().includes(name.toUpperCase())
      );
      props.setCategoriesFound(categoriesFound, true);
    } else {
      props.setCategoriesFound([], false);
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
          delConfirmed={props.delCategoryConfirmed}
        ></ConfirmModal>
      )}
      <CategoriesToolbar searchCategory={searchCategory} />
      <div className={classes.content}>
        <CategoriesTable
          categories={props.search ? props.categoriesFound : props.categories}
          delcategory={(id) => props.delCategory(id)}
        />
      </div>
    </div>
  );
};

const mapStateToProps = (state) => ({
  categories: state.categories.list,
  notification: state.notification,
  categoriesFound: state.categories.foundList,
  search: state.categories.search,
  modal: state.modal,
});

const mapDispatchToProps = (dispatch) =>
  bindActionCreators(
    {
      getCategories,
      closeNotification,
      closeModal,
      setCategoriesFound,
      delCategory,
      delCategoryConfirmed,
    },
    dispatch
  );

export default connect(mapStateToProps, mapDispatchToProps)(CategoriesList);
