import React, { useEffect } from "react";
import { bindActionCreators } from "redux";
import { connect } from "react-redux";
import { useHistory } from "react-router-dom";
import clsx from "clsx";
import { makeStyles } from "@material-ui/styles";
import { Card } from "@material-ui/core";
import { Notification, SummaryErrors } from "../../../common";
import CategoriesForm from "./components/form.js";
import categoryValitation from "../../../validators/categoryValidation";
import {
  getCategory,
  registerCategory,
  clearErrors,
} from "../../../store/stock/categoriesReducer";
import { closeNotification } from "../../../store/notificationsReducer";

const useStyles = makeStyles((theme) => ({
  root: {
    padding: theme.spacing(3),
  },
  content: {
    padding: theme.spacing(3),
  },
}));

const CategoriesRegister = (props) => {
  const { className } = props;
  const classes = useStyles();
  const history = useHistory();

  const id = props.match.params.id;
  const update = id !== undefined ? true : false;

  useEffect(() => {
    props.getCategory(id);
    if (props.redirect !== null) return history.push(props.redirect);
  }, [props.redirect]);

  return (
    <div className={classes.root}>
      {props.notification.open && (
        <Notification
          color={props.notification.color}
          message={props.notification.message}
          onClose={props.closeNotification}
        ></Notification>
      )}
      {props.errors.length > 0 && (
        <SummaryErrors
          errors={props.errors}
          closeNotification={props.clearErrors}
        ></SummaryErrors>
      )}
      <Card className={clsx(classes.root, className)}>
        <div className={classes.content}>
          <CategoriesForm
            initialValues={props.category}
            update={update}
            validationSchema={categoryValitation}
            onSubmit={props.registerCategory}
          ></CategoriesForm>
        </div>
      </Card>
    </div>
  );
};

const mapStateToProps = (state) => ({
  categories: state.categories.list,
  category: state.categories.detail,
  errors: state.categories.errors,
  notification: state.notification,
  redirect: state.history.redirect,
});

const mapDispatchToProps = (dispatch) =>
  bindActionCreators(
    { getCategory, registerCategory, closeNotification, clearErrors },
    dispatch
  );

export default connect(mapStateToProps, mapDispatchToProps)(CategoriesRegister);
