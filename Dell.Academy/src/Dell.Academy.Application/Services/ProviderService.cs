using AutoMapper;
using Dell.Academy.Application.Extensions;
using Dell.Academy.Application.Interfaces;
using Dell.Academy.Application.ViewModels;
using Dell.Academy.Domain.Interfaces;
using Dell.Academy.Domain.Models;
using Dell.Academy.Domain.Models.Validations;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Dell.Academy.Application.Services
{
    public class ProviderService : BaseService, IProviderService
    {
        private readonly IProviderRepository _repository;
        private readonly IMapper _mapper;

        public ProviderService(IProviderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult> GetProvidersAsync()
        {
            var providers = await _repository.GetProvidersWithAddressAsync();
            return Success(_mapper.Map<List<ProviderViewModel>>(providers));
        }

        public async Task<OperationResult> GetProviderByIdAsync(long id)
        {
            var provider = await _repository.GetProviderWithAddressAndProductsByIdAsync(id);
            if (provider is null)
                return Error(ErrorMessages.NotFoundError("Fornecedor", id), HttpStatusCode.NotFound);

            return Success(_mapper.Map<ProviderViewModel>(provider));
        }

        public async Task<OperationResult> InsertProviderAsync(ProviderViewModel viewModel)
        {
            var provider = _mapper.Map<Provider>(viewModel);
            var validator = new ProviderValidator();
            var validationResult = validator.Validate(provider);
            if (!validationResult.IsValid)
                return Error(validationResult);

            var providerExists = await _repository.ProviderWithDocumentNumberExistsAsync(viewModel.DocumentNumber);
            if (providerExists)
                return Error(ErrorMessages.ProviderExistsError);

            return Commit(await _repository.InsertAsync(provider));
        }
    }
}