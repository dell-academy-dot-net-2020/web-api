import axios from "axios";
import { getSession } from "../LoginService";

const api = axios.create({ baseURL: "https://localhost:5001/api/produtos" });

api.interceptors.request.use(async config => {
  const token = getSession().token;
  if (token) {
    config.headers.Authorization = token;
  }

  return config;
});

const getProducts = async () => await api.get();

const getProductById = async id => await api.get(id);

const insertProduct = async product => await api.post("/", product);

const updateProduct = async (id, product) => await api.put(`/${id}`, product);

const delProduct = async id => await api.delete(`/${id}`);

const editProduct = async (id, product) => await api.put(`/${id}`, product);

export default {
  getProducts,
  getProductById,
  delProduct,
  editProduct,
  insertProduct,
  updateProduct
};
