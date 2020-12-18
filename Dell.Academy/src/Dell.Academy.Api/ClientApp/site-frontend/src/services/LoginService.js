import axios from "axios";

const api = axios.create({ baseURL: "https://localhost:5001/api/v1" });

const login = async user => await api.post("/login", user);

const register = async user => await api.post("/register", user);

const TOKEN_KEY = "@myapi-token";

const USER_KEY = "@myapi-user";

const getSession = () => {
  return {
    username: localStorage.getItem(USER_KEY),
    token: localStorage.getItem(TOKEN_KEY)
  };
};

const saveSession = (username, token) => {
  localStorage.setItem(USER_KEY, username);
  localStorage.setItem(TOKEN_KEY, `Bearer ${token}`);
};

const clearSession = () => {
  localStorage.removeItem(USER_KEY);
  localStorage.removeItem(TOKEN_KEY);
};

const isAuthenticated = () => true;

export {
  login,
  register,
  getSession,
  saveSession,
  clearSession,
  isAuthenticated
};
