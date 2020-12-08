﻿namespace Dell.Academy.Application.Extensions
{
    public static class ErrorMessages
    {
        public static string DatabaseCommitError => "Não foi possível salvar o registro no banco de dados.";
        public static string CategoryNameExistsError => "Categoria já cadastrada";
        public static string ProviderExistsError => "Fornecedor já cadastrado";
        public static string IdDoNotMatch => "Os Id's não correspondem";

        public static string NotFoundError(string entityType, long id) => $"{entityType} com o id {id} não foi encontrado(a)";
    }
}