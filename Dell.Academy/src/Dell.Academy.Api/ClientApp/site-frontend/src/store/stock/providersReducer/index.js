import providersService from "../../../services/stock/providersService";
import { showNotification } from "../../notificationsReducer";

const ACTIONS = {
  LIST: "LIST_PROVIDERS",
  FOUND_LIST: "FOUND_PROVIDERS",
};

const INITIAL_STATE = {
  list: [],
  foundList: []
};

const providersReducer = (state = INITIAL_STATE, action) => {
  switch (action.type) {
    case ACTIONS.LIST:
      return { ...state, list: action.providers};
    case ACTIONS.FOUND_LIST:
      return {
        ...state,
        foundList: action.foundList,
        search: action.search,
      };
    default:
      return state;
  }
};

const getProviders = () => {
  return async (dispatch) => {
    try {
      const response = await providersService.getProviders();
      dispatch({
        type: ACTIONS.LIST,
        providers: response.data,
      });
    } catch (error) {
      dispatch(
        showNotification("Não foi possível carregar as informações", "error")
      );
    }
  };
};

const setProvidersFound = (providersFound, search) => {
  return (dispatch) => {
    dispatch({
      type: ACTIONS.FOUND_LIST,
      foundList: providersFound,
      search: search,
    });
  };
};

export { providersReducer, getProviders, setProvidersFound };
