const ACTIONS = {
  SHOW: "SHOW_MODAL",
  CLOSE: "CLOSE_MODAL"
};

const INITIAL_STATE = {
  open: false
};

const modalReducer = (state = INITIAL_STATE, action) => {
  switch (action.type) {
    case ACTIONS.SHOW:
      return { ...state, open: true };
    case ACTIONS.CLOSE:
      return INITIAL_STATE;
    default:
      return state;
  }
};

const showModal = () => {
  return {
    type: ACTIONS.SHOW
  };
};

const closeModal = () => {
  return {
    type: ACTIONS.CLOSE
  };
};

export { modalReducer, showModal, closeModal };
