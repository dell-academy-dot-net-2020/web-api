import { combineReducers } from "redux";
import { notificationsReducer } from "./notificationsReducer";
import { modalReducer } from "./modalReducer";
import { redirectReducer } from "./redirectReducer";
import { productsReducer } from "./stock/productsReducer";
import { categoriesReducer } from "./stock/categoriesReducer";
import { providersReducer } from "./stock/providersReducer";

const mainReducer = combineReducers({
  products: productsReducer,
  providers: providersReducer,
  categories: categoriesReducer,
  notification: notificationsReducer,
  history: redirectReducer,
  modal: modalReducer
});

export default mainReducer;
