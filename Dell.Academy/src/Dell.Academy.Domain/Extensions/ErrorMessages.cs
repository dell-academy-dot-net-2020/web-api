﻿namespace Dell.Academy.Domain.Extensions
{
    public static class ErrorMessages
    {
        public static string DatabaseCommitError => "Não foi possível salvar o registro no banco de dados.";
        public static string CategoryNameExistsError => "Categoria já cadastrada";
        public static string ProviderExistsError => "Fornecedor já cadastrado";
        public static string IdDoNotMatch => "Os Id's não correspondem";
        public static string CpfSizeError => "O campo Cpf precisa ter 11 caracteres";
        public static string CpfInvalidError => "O Cpf fornecido não é válido";
        public static string CnpjSizeError => "O campo Cnpj precisa ter 14 caracteres";
        public static string CnpjInvalidError => "O Cnpj fornecido não é válido";

        public static string NotFoundError(string entityType, long id) => $"{entityType} com o id {id} não foi encontrado(a)";
    }
}