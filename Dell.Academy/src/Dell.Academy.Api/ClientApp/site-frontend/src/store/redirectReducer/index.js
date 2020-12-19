const ACTIONS = {
    REDIRECT: "REDIRECT_TO",
  };
  
  const INITIAL_STATE = {
    redirect: null
  };
  
  const redirectReducer = (state = INITIAL_STATE, action) => {
    switch (action.type) {
      case ACTIONS.REDIRECT:
        return { ...state, redirect: action.redirect };
      default:
        return state;
    }
  };
  
  const redirectTo = path => {
    return {
      type: ACTIONS.REDIRECT,
      redirect: path
    };
  };
  
  export { redirectReducer, redirectTo };
  