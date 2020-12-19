const ACTIONS = {
  SHOW: "SHOW_NOTIFICATION",
  CLOSE: "CLOSE_NOTIFICATION"
};

const INITIAL_STATE = {
  open: false,
  message: "",
  color: ""
};

const notificationsReducer = (state = INITIAL_STATE, action) => {
  switch (action.type) {
    case ACTIONS.SHOW:
      return {
        ...state,
        open: true,
        message: action.notification.message,
        color: action.notification.color
      };
    case ACTIONS.CLOSE:
      return INITIAL_STATE;
    default:
      return state;
  }
};

const showNotification = (message, color) => {
  return {
    type: ACTIONS.SHOW,
    notification: {
      open: true,
      message: message,
      color: color
    }
  };
};

const closeNotification = () => ({
  type: ACTIONS.CLOSE,
  notification: null
});

export { notificationsReducer, showNotification, closeNotification };
