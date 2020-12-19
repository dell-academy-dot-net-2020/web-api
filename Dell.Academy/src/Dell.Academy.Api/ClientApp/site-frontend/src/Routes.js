import React from "react";
import { Switch, Redirect } from "react-router-dom";
import { RouteWithLayout } from "./components";
import {
  Minimal as MinimalLayout,
  MainStock,
} from "./layouts";

import {
  ProductsList as ProductsView,
  ProductsRegister as ProductsFormView,
  ProductDetail as ProductDetailView,
  ProvidersList as ProvidersView,
  CategoriesList as CategoriesView,
  CategoryDetail as CategoryDetailView,
  CategoriesRegister as CategoriesFormView,
  NotFound as NotFoundView,
} from "./views";

const Routes = () => {
  return (
    <Switch>
      <Redirect exact from="/" to="/produtos/listar" />
      <RouteWithLayout
        component={ProductsView}
        exact
        layout={MainStock}
        path="/produtos/listar"
      />
      <RouteWithLayout
        component={ProductsFormView}
        exact
        layout={MainStock}
        path="/produtos/cadastrar/:id?"
      />
      <RouteWithLayout
        component={ProductDetailView}
        exact
        layout={MainStock}
        path="/produtos/detalhar/:id"
      />
      <RouteWithLayout
        component={ProvidersView}
        exact
        layout={MainStock}
        path="/fornecedores/listar"
      />
      <RouteWithLayout
        component={CategoriesFormView}
        exact
        layout={MainStock}
        path="/categorias/cadastrar/:id?"
      />
      <RouteWithLayout
        component={CategoriesView}
        exact
        layout={MainStock}
        path="/categorias/listar"
      />
      <RouteWithLayout
        component={CategoryDetailView}
        exact
        layout={MainStock}
        path="/categorias/detalhar/:id"
      />
      <RouteWithLayout
        component={NotFoundView}
        exact
        layout={MinimalLayout}
        path="/not-found"
      />
      <Redirect to="/not-found" />
    </Switch>
  );
};

export default Routes;
