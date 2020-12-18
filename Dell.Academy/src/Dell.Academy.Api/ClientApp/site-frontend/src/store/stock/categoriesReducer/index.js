import categoriesService from "../../../services/stock/categoriesService";
import { showNotification } from "../../notificationsReducer";
import { showModal, closeModal } from "../../modalReducer";
import { redirectTo } from "../../redirectReducer";

const ACTIONS = {
  LIST: "LIST_CATEGORIES",
  FOUND_LIST: "FOUND_CATEGORIES",
  SAVE: "SAVE_CATEGORY",
  DELETE: "DELETE_CATEGORY",
  DETAIL: "CATEGORY_DETAIL",
  ERROR: "CATEGORY_FORM_ERROR",
  REDIRECT: "REDIRECT",
};

const INITIAL_STATE = {
  list: [],
  foundList: [],
  detail: {
    name: "",
    products: [],
  },
  search: false,
  errors: [],
  redirectTo: null,
};

let categoryId = "";

const categoriesReducer = (state = INITIAL_STATE, action) => {
  switch (action.type) {
    case ACTIONS.LIST:
      return { ...state, list: action.categories };
    case ACTIONS.FOUND_LIST:
      return {
        ...state,
        foundList: action.foundList,
        search: action.search,
      };
    case ACTIONS.DETAIL:
      return {
        ...state,
        detail: action.category,
      };
    case ACTIONS.DELETE:
      const list = state.list.filter((p) => p.id !== categoryId);
      return { ...state, list: list };
    case ACTIONS.ERROR:
      return { ...state, errors: action.errors };
    default:
      return state;
  }
};

const getCategories = () => {
  return async (dispatch) => {
    try {
      const response = await categoriesService.getCategories();
      dispatch([
        {
          type: ACTIONS.LIST,
          categories: response.data,
        },
        redirectTo(null),
      ]);
    } catch (error) {
      dispatch(
        showNotification("Não foi possível carregar as informações", "error")
      );
    }
  };
};

const setCategoriesFound = (categoriesFound, search) => {
  return (dispatch) => {
    dispatch({
      type: ACTIONS.FOUND_LIST,
      foundList: categoriesFound,
      search: search,
    });
  };
};

const getCategory = (id) => {
  return async (dispatch) => {
    try {
      if (id !== undefined) {
        const response = await categoriesService.getCategoryById(id);
        if (response.data) {
          dispatch([
            {
              type: ACTIONS.DETAIL,
              category: response.data,
            },
            redirectTo(null),
          ]);
        }
      } else {
        dispatch({
          type: ACTIONS.DETAIL,
          category: INITIAL_STATE.detail,
        });
      }
    } catch (error) {
      error.response.status === 401
        ? dispatch(redirectTo("/entrar"))
        : dispatch(redirectTo("/not-found"));
    }
  };
};

const registerCategory = (category) => {
  return async (dispatch) => {
    let message = "atualizado";
    try {
      if (category.id) {
        category.products = [];
        await categoriesService.updateCategory(category.id, category);
      } else {
        await categoriesService.insertCategory(category);
        message = "efetuado";
      }
      dispatch([
        showNotification(`Cadastro ${message} com sucesso`, "success"),
        redirectTo("/categorias/listar"),
      ]);
    } catch (error) {
      dispatch({
        type: ACTIONS.ERROR,
        errors: error.response.data.errors,
      });
    }
  };
};

const delCategory = (id) => {
  categoryId = id;
  return (dispatch) => {
    dispatch(showModal());
  };
};

const delCategoryConfirmed = () => {
  return async (dispatch) => {
    try {
      await categoriesService.delCategory(categoryId);
      dispatch([
        {
          type: ACTIONS.DELETE,
          id: categoryId,
        },
        closeModal(),
        showNotification("Categoria excluída com sucesso!", "success"),
      ]);
    } catch (error) {
      var errorMessage = error.response.data.Errors[0];
      dispatch(showNotification(errorMessage, "error"));
    }
  };
};

const clearErrors = () => {
  return {
    type: ACTIONS.ERROR,
    errors: [],
  };
};

export {
  categoriesReducer,
  getCategories,
  getCategory,
  registerCategory,
  setCategoriesFound,
  delCategory,
  delCategoryConfirmed,
  clearErrors,
};
