import axios from "axios";
import { getSession } from "../LoginService";

const api = axios.create({ baseURL: "https://localhost:5001/api/fornecedores" });

api.interceptors.request.use(async config => {
  const token = getSession().token;
  if (token) {
    config.headers.Authorization = token;
  }

  return config;
});

const getProviders = async () => await api.get();

const getProviderById = async id => await api.get(id);

const insertProvider = async provider => await api.post("/", provider);

const updateProvider = async (id, provider) => await api.put(`/${id}`, provider);

const delProvider = async id => await api.delete(`/${id}`);

const editProvider = async (id, provider) => await api.put(`/${id}`, provider);

export default {
  getProviders,
  getProviderById,
  delProvider,
  editProvider,
  insertProvider,
  updateProvider
};
