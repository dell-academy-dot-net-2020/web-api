import React from "react";
import { Link } from "react-router-dom";
import { Formik } from "formik";
import { FormikTextField, FormikCheckbox, MenuItem } from "@dccs/react-formik-mui";
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
    : ["Cadastrar produto", "Cadastrar"];

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
              <Grid item md={9} xs={12}>
                <FormikTextField
                  fullWidth
                  label="Nome"
                  name="name"
                  id="name"
                  required
                  variant="outlined"
                />
              </Grid>
              <Grid item md={3} xs={12}>
                <FormikTextField
                  fullWidth
                  label="Valor"
                  name="value"
                  id="value"
                  required
                  variant="outlined"
                />
              </Grid>
              <Grid item md={12} xs={12}>
                <FormikTextField
                  fullWidth
                  label="Descrição"
                  name="description"
                  required
                  variant="outlined"
                />
              </Grid>
              <Grid item md={4} xs={12}>
                <FormikTextField
                  select
                  fullWidth
                  label="Ativo?"
                  name="active"
                  id="active"
                  defaultValue={true}
                  variant="outlined"
                >
                  {props.categories.map(category => (
                    <MenuItem value={0}>{category.name}</MenuItem>
                  ))}
                  </FormikTextField>
              </Grid>
              <Grid item md={4} xs={12}>
                <FormikTextField
                  fullWidth
                  label="Ativo?"
                  name="active"
                  id="active"
                  defaultValue={true}
                  variant="outlined"
                >
                  {props.categories.map(provider => (
                    <MenuItem value={0}>{provider.name}</MenuItem>
                  ))}
                </FormikTextField>
              </Grid>
              <Grid item md={4} xs={12}>
                <FormikCheckbox
                  fullWidth
                  label="Ativo?"
                  name="active"
                  id="active"
                  defaultValue={true}
                  variant="outlined"
                />
              </Grid>
            </Grid>
          </CardContent>
          <Divider />
          <CardActions>
            <MyButton btnColor="success" text={button} type="submit" />
            <Link to="/pessoas/listar">
              <MyButton btnColor="primary" text="Voltar" />
            </Link>
          </CardActions>
        </form>
      )}
    </Formik>
  );
};
