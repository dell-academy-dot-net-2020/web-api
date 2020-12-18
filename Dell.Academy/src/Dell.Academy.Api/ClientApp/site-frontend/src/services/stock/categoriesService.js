import axios from "axios";
import { getSession } from "../LoginService";

const api = axios.create({ baseURL: "https://localhost:5001/api/categorias" });

api.interceptors.request.use(async config => {
  const token = getSession().token;
  if (token) {
    config.headers.Authorization = token;
  }

  return config;
});

const getCategories = async () => await api.get();

const getCategoryById = async id => await api.get(id);

const insertCategory = async category => await api.post("/", category);

const updateCategory = async (id, category) => await api.put(`/${id}`, category);

const delCategory = async id => await api.delete(`/${id}`);

const editCategory = async (id, category) => await api.put(`/${id}`, category);

export default {
  getCategories,
  getCategoryById,
  delCategory,
  editCategory,
  insertCategory,
  updateCategory
};
