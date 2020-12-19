import React from "react";
import { Link } from "react-router-dom";
import { Formik } from "formik";
import { FormikTextField, FormikCheckbox } from "@dccs/react-formik-mui";
import {
  CardHeader,
  CardContent,
  CardActions,
  Divider,
  Grid,
  MenuItem,
} from "@material-ui/core";

import MyButton from "../../../../common/MyButton";

export default (props) => {
  const [title, button] = props.update
    ? ["Atualizar cadastro", "Aualizar"]
    : ["Cadastrar produto", "Cadastrar"];
  const categories = props.categories;

  return (
    <Formik
      initialValues={props.initialValues}
      enableReinitialize
      validationSchema={props.validationSchema}
      onSubmit={props.onSubmit}
    >
      {(formikProps) => (
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
                  id="name"
                  required
                  variant="outlined"
                />
              </Grid>
              <Grid item md={3} xs={12}>
                <FormikTextField
                  fullWidth
                  label="SKU"
                  name="sku"
                  id="sku"
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
                  type="number"
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
                  fullWidth
                  select
                  label="Categoria"
                  name="categoryId"
                  id="categoryId"
                  variant="outlined"
                  required
                >
                  {categories.map((category) => (
                    <MenuItem key={category.id} value={category.id}>
                      {category.name}
                    </MenuItem>
                  ))}
                </FormikTextField>
              </Grid>
              <Grid item md={4} xs={12}>
                <FormikTextField
                  fullWidth
                  select
                  label="Fornecedor"
                  name="providerId"
                  id="providerId"
                  variant="outlined"
                  required
                >
                  {props.providers.map((provider) => (
                    <MenuItem key={provider.id} value={provider.id}>
                      {provider.name}
                    </MenuItem>
                  ))}
                </FormikTextField>
              </Grid>
              <Grid item md={4} xs={12}>
                <FormikCheckbox
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
            <Link to="/produtos/listar">
              <MyButton btnColor="primary" text="Voltar" />
            </Link>
          </CardActions>
        </form>
      )}
    </Formik>
  );
};
