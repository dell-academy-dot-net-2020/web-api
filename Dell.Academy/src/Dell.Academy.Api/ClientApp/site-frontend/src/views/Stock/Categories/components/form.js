import React from "react";
import { Link } from "react-router-dom";
import { Formik } from "formik";
import { FormikTextField } from "@dccs/react-formik-mui";
import {
  CardHeader,
  CardContent,
  CardActions,
  Divider,
  Grid
} from "@material-ui/core";

import MyButton from "../../../../common/MyButton";

export default props => {
  const [title, button] = props.update
    ? ["Atualizar cadastro", "Aualizar"]
    : ["Cadastrar categoria", "Cadastrar"];

  return (
    <Formik
      initialValues={props.initialValues}
      enableReinitialize
      validationSchema={props.validationSchema}
      onSubmit={props.onSubmit}
    >
      {formikProps => (
        <form onSubmit={formikProps.handleSubmit}>
          <CardHeader subheader="" title={title} />
          <Divider />
          <CardContent>
            <Grid container spacing={2}>
              <Grid item md={6} xs={12}>
                <FormikTextField
                  fullWidth
                  label="Nome"
                  name="name"
                  required
                  variant="outlined"
                />
            </Grid>
            </Grid>
          </CardContent>
          <Divider />
          <CardActions>
            <MyButton btnColor="success" text={button} type="submit" />
            <Link to="/categorias/listar">
              <MyButton btnColor="primary" text="Voltar" />
            </Link>
          </CardActions>
        </form>
      )}
    </Formik>
  );
};
