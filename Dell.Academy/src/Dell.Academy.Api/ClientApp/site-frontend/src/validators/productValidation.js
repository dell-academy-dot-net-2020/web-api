import * as yup from "yup";

export default yup.object().shape({
  name: yup.string().required("nome obrigatório"),
  sku: yup.string().required("sku obrigatório"),
  value: yup.number().moreThan(0, "valor precisa ser maior do que 0").required("valor obrigatório"),
  categoryId: yup.string().required("selecione uma categoria"),
  providerId: yup.string().required("selecione um fornecedor"),
  description: yup.string().required("descrição obrigatória"),
});
