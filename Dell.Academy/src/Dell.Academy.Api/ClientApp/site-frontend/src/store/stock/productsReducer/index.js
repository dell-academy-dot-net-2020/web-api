import productsService from "../../../services/stock/productsService";
// import categoriesService from "../../../services/stock/categoriesService";
// import providersService from "../../../services/stock/providersService";
import { showNotification } from "../../notificationsReducer";
import { showModal, closeModal } from "../../modalReducer";
import { redirectTo } from "../../redirectReducer";
import { getCategories } from "../../stock/categoriesReducer";
import { getProviders } from "../../stock/providersReducer";

const ACTIONS = {
  LIST: "LIST_PRODUCTS",
  FOUND_LIST: "FOUND_PRODUCTS",
  IMAGE_PREVIEW: "CHANGE_IMAGE_PREVIEW",
  SAVE: "SAVE_PRODUCT",
  DELETE: "DELETE_PRODUCT",
  DETAIL: "PRODUCT_DETAIL",
  ERROR: "PRODUCT_FORM_ERROR",
  REDIRECT: "REDIRECT",
};

const INITIAL_STATE = {
  list: [],
  foundList: [],
  detail: {
    image: "",
    imageUpload: "",
    name: "",
    description: "",
    value: "",
    active: true,
    categoryId: "",
    providerId: "",
  },
  imagePreview: "/images/product.jpg",
  search: false,
  errors: [],
  redirectTo: null,
};

let productId = "";
let productName = "";
let productImgUpload = "";

const productsReducer = (state = INITIAL_STATE, action) => {
  switch (action.type) {
    case ACTIONS.LIST:
      return {
        ...state,
        list: action.products,
      };
    case ACTIONS.FOUND_LIST:
      return {
        ...state,
        foundList: action.foundList,
        search: action.search,
      };
    case ACTIONS.DETAIL:
      return {
        ...state,
        detail: action.product,
      };
    case ACTIONS.DELETE:
      const list = state.list.filter((p) => p.id !== productId);
      return { ...state, list: list };
    case ACTIONS.ERROR:
      return { ...state, errors: action.errors };
    case ACTIONS.IMAGE_PREVIEW:
      return { ...state, imagePreview: action.imagePreview };
    default:
      return state;
  }
};

const getProducts = () => {
  return async (dispatch) => {
    try {
      const response = await productsService.getProducts();
      dispatch([
        {
          type: ACTIONS.LIST,
          products: response.data,
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

const getProduct = (id) => {
  return async (dispatch) => {
    try {
      if (id !== undefined) {
        const response = await productsService.getProductById(id);
        if (response.data) {
          dispatch([
            getCategories(),
            getProviders(),
            {
              type: ACTIONS.DETAIL,
              product: response.data,
            },
            redirectTo(null),
          ]);
        }
      } else {
        dispatch([
          getCategories(),
          getProviders(),
          {
            type: ACTIONS.DETAIL,
            product: INITIAL_STATE.detail,
          },
        ]);
      }
    } catch (error) {
      error.response.status === 401
        ? dispatch(redirectTo("/entrar"))
        : dispatch(redirectTo("/not-found"));
    }
  };
};

const registerProduct = (product) => {
  if (productImgUpload !== "") {
    product.image = productName;
    product.imageUpload = productImgUpload;
  }
  return async (dispatch) => {
    let message = "atualizado";
    try {
      if (product.id) {
        await productsService.updateProduct(product.id, product);
      } else {
        await productsService.insertProduct(product);
        message = "efetuado";
      }
      dispatch([
        showNotification(`Cadastro ${message} com sucesso`, "success"),
        redirectTo("/produtos/listar"),
      ]);
    } catch (error) {
      dispatch({
        type: ACTIONS.ERROR,
        errors: error.response.data.errors,
      });
    }
  };
};

const delProduct = (id) => {
  productId = id;
  return (dispatch) => {
    dispatch(showModal());
  };
};

const delProductConfirmed = () => {
  return async (dispatch) => {
    try {
      await productsService.delProduct(productId);
      dispatch([
        {
          type: ACTIONS.DELETE,
          id: productId,
        },
        closeModal(),
        showNotification("Registro excluído com sucesso!", "success"),
      ]);
    } catch (error) {
      dispatch(showNotification("Erro: não foi possível excluir.", "error"));
    }
  };
};

const setProductsFound = (productsFound, search) => {
  return (dispatch) => {
    dispatch({
      type: ACTIONS.FOUND_LIST,
      foundList: productsFound,
      search: search,
    });
  };
};

const changeImagePreview = (imgName, imgUrl) => {  
  productName = imgName;
  productImgUpload = (imgUrl.split(","))[1];
  return {
    type: ACTIONS.IMAGE_PREVIEW,
    imagePreview: imgUrl,
  };
};

const clearErrors = () => {
  return {
    type: ACTIONS.ERROR,
    errors: [],
  };
};

export {
  productsReducer,
  getProducts,
  getProduct,
  registerProduct,
  delProduct,
  setProductsFound,
  delProductConfirmed,
  clearErrors,
  changeImagePreview,
};
