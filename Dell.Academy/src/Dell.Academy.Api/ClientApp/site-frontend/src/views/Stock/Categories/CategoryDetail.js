import React, { useEffect } from "react";
import { useHistory } from "react-router-dom";
import { makeStyles } from "@material-ui/styles";
import { bindActionCreators } from "redux";
import { connect } from "react-redux";
import { getCategory } from "../../../store/stock/categoriesReducer";
import { ProductsTable } from "../Products/components/";
import { Card, CardHeader, Divider, Typography } from "@material-ui/core";
const useStyles = makeStyles((theme) => ({
  root: {
    padding: theme.spacing(3),
  },
  content: {
    marginTop: theme.spacing(2),
  },
  header: {
    margin: theme.spacing(2),
  },
  subHeader: {
    margin: theme.spacing(4),
  },
}));

const CategoryDetail = (props) => {
  const classes = useStyles();
  const history = useHistory();
  const id = props.match.params.id;

  useEffect(() => {
    props.getCategory(id);
    if (props.redirect !== null) return history.push(props.redirect);
  }, [props.redirect]);

  return (
    <div className={classes.root}>
      <Card>
        <CardHeader
          className={classes.header}
          subheader=""
          title={
            <Typography variant="h3">
              {`Categoria ${props.category.name}`}
            </Typography>
          }
        />
        <Divider />
        <Typography variant="h4" className={classes.subHeader}>
              Produtos desta categoria:
            </Typography>
      <div className={classes.content}>
        <ProductsTable
          products={props.category.products}
          options={false}
        />
      </div>
      </Card>
    </div>
  );
};

const mapStateToProps = (state) => ({
  category: state.categories.detail,
  redirect: state.history.redirect,
});

const mapDispatchToProps = (dispatch) =>
  bindActionCreators(
    {
      getCategory,
    },
    dispatch
  );

export default connect(mapStateToProps, mapDispatchToProps)(CategoryDetail);
