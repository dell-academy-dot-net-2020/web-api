import React, { useEffect } from "react";
import Moment from "react-moment";
import { useHistory } from "react-router-dom";
import { bindActionCreators } from "redux";
import { connect } from "react-redux";
import { makeStyles } from "@material-ui/styles";
import BusinessCenterIcon from "@material-ui/icons/BusinessCenter";
import DescriptionIcon from '@material-ui/icons/Description';
import CategoryIcon from '@material-ui/icons/Category';
import LocalAtmIcon from '@material-ui/icons/LocalAtm';
import EventIcon from '@material-ui/icons/Event';
import LibraryAddCheckIcon from '@material-ui/icons/LibraryAddCheck';
import {
  Card,
  CardContent,
  Grid,
  CardHeader,
  Divider,
  CardMedia,
  Typography,
  Checkbox,
  Table,
  TableHead,
  TableRow,
  TableCell,
} from "@material-ui/core";
import { getProduct } from "../../../store/stock/productsReducer";

const useStyles = makeStyles((theme) => ({
  root: {
    padding: theme.spacing(4),
  },
  icon: {
    color: theme.palette.primary.primary,
    height: 30,
    display: "flex",
    fontSize: "18px"
  },
  text: {
    marginLeft: theme.spacing(1),
    marginRight: theme.spacing(1),
  },
  row: {
    height: "auto",
    display: "flex",
  },
  list: {
    padding: theme.spacing(4),
    maxWidth: "100%",
  },
  content: {
    padding: 0,
  },
  inner: {
    minWidth: 1050,
  },
  nameContainer: {
    display: "flex",
    alignItems: "center",
  },
  actions: {
    justifyContent: "flex-end",
  },
  image: {
    width: "100%",
  },
  imageGrid: {
    padding: theme.spacing(8),
    paddingTop: theme.spacing(4),
  },
  header: {
    margin: theme.spacing(2),
  },
}));

const ProductDetail = (props) => {
  const classes = useStyles();
  const history = useHistory();
  const id = props.match.params.id;

  useEffect(() => {
    props.getProduct(id);
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
              {`Detalhes do produto: ${props.product.name}`}
            </Typography>
          }
        />
        <Divider />
        <CardContent className={classes.content}>
          <div className={classes.row}>
            <Grid container spacing={0}>
              <Grid
                item
                lg={6}
                md={6}
                xl={4}
                xs={12}
                className={classes.imageGrid}
              >
                <CardMedia
                  className={classes.image}
                  component="img"
                  image={props.imagePreview}
                  title={props.product.name}
                />
              </Grid>
              <Grid item lg={6} md={6} xl={8} xs={12}>
                <div className={classes.list}>
                  <Table>
                    <TableHead>
                      <TableRow>
                        <TableCell>
                          <div className={classes.icon}>
                            <BusinessCenterIcon />
                            <strong className={classes.text}>
                              Fornecedor:
                            </strong>
                            {props.product.providerName}
                          </div>
                        </TableCell>
                      </TableRow>
                      <TableRow>
                        <TableCell>
                        <div className={classes.icon}>
                            <CategoryIcon />
                          <strong className={classes.text}>Categoria:</strong>{" "}
                          {props.product.categoryName}
                          </div>
                        </TableCell>
                      </TableRow>
                      <TableRow>
                        <TableCell>
                        <div className={classes.icon}>
                            <LocalAtmIcon />
                          <strong className={classes.text}>Valor:</strong> R${props.product.value}
                          </div>
                        </TableCell>
                      </TableRow>
                      <TableRow>
                        <TableCell>
                        <div className={classes.icon}>
                            <DescriptionIcon />
                          <strong className={classes.text}>Descrição:</strong>{" "}
                          {props.product.description}
                          </div>
                        </TableCell>
                      </TableRow>
                      <TableRow>
                        <TableCell>
                        <div className={classes.icon}>
                            <EventIcon />
                          <strong className={classes.text}>Data de cadastro:</strong>{" "}
                          <Moment format="DD/MM/YYYY">
                            {props.product.register}
                          </Moment>
                          </div>
                        </TableCell>
                      </TableRow>
                      <TableRow>
                        <TableCell>
                        <div className={classes.icon}>
                            <LibraryAddCheckIcon />
                          <strong className={classes.text}>Ativo?</strong>
                          <Checkbox
                            checked={props.product.active}
                            name="checkedB"
                            disabled
                          />
                          </div>
                        </TableCell>
                      </TableRow>
                    </TableHead>
                  </Table>
                </div>
              </Grid>
            </Grid>
          </div>
        </CardContent>
      </Card>
    </div>
  );
};

const mapStateToProps = (state) => ({
  product: state.products.detail,
  redirect: state.history.redirect,
  imagePreview: state.products.imagePreview,
});

const mapDispatchToProps = (dispatch) =>
  bindActionCreators(
    {
      getProduct,
    },
    dispatch
  );
export default connect(mapStateToProps, mapDispatchToProps)(ProductDetail);
