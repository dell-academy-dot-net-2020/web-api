using AutoMapper;
using Dell.Academy.Application.Extensions;
using Dell.Academy.Application.Interfaces;
using Dell.Academy.Application.ViewModels;
using Dell.Academy.Domain.Extensions;
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
        private readonly IProviderRepository _providerRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public ProviderService(IProviderRepository repository, IAddressRepository addressRepository, IMapper mapper)
        {
            _providerRepository = repository;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult> GetProvidersAsync()
        {
            var providers = await _providerRepository.GetProvidersWithAddressAsync();
            return Success(_mapper.Map<List<ProviderViewModel>>(providers));
        }

        public async Task<OperationResult> GetProviderByIdAsync(long id)
        {
            var provider = await _providerRepository.GetProviderWithAddressAndProductsByIdAsync(id);
            if (provider is null)
                return Error(ErrorMessages.NotFoundError("Fornecedor", id), HttpStatusCode.NotFound);

            return Success(_mapper.Map<ProviderViewModel>(provider));
        }

        public async Task<OperationResult> InsertProviderAsync(ProviderViewModel viewModel)
        {
            var provider = _mapper.Map<Provider>(viewModel);
            if (!EntityIsValid(new ProviderValidator(), provider) || !EntityIsValid(new AddressValidator(), provider.Address))
                return ValidationErrors();

            if (await ProviderWithDocumentNumberExistsAsync(provider.DocumentNumber))
                return Error(ErrorMessages.ProviderExistsError(provider.DocumentNumber));

            return Commit(await _providerRepository.InsertAsync(provider));
        }

        public async Task<OperationResult> UpdateProviderAsync(ProviderViewModel viewModel)
        {
            var provider = _mapper.Map<Provider>(viewModel);
            if (!EntityIsValid(new ProviderValidator(), provider))
                return ValidationErrors();

            var provideryFomDb = await _providerRepository.GetByIdAsync(provider.Id);
            if (provideryFomDb is null)
                return Error(ErrorMessages.NotFoundError("Fornecedor", provider.Id), HttpStatusCode.NotFound);

            if (await ProviderWithDocumentNumberExistsAsync(provider.DocumentNumber))
                return Error(ErrorMessages.ProviderExistsError(provider.DocumentNumber));

            return Commit(await _providerRepository.UpdateAsync(provider));
        }

        public async Task<OperationResult> UpdateAddressAsync(AddressViewModel viewModel)
        {
            var address = _mapper.Map<Address>(viewModel);
            if (!EntityIsValid(new AddressValidator(), address))
                return ValidationErrors();

            var provideryFomDb = await _providerRepository.GetByIdAsync(address.ProviderId);
            if (provideryFomDb is null)
                return Error(ErrorMessages.NotFoundError("Fornecedor", address.ProviderId), HttpStatusCode.NotFound);

            return Commit(await _addressRepository.UpdateAsync(address));
        }

        public async Task<OperationResult> DeleteProviderAsync(long id)
        {
            var provider = await _providerRepository.GetByIdAsync(id);
            if (provider is null)
                return Error(ErrorMessages.NotFoundError("Fornecedor", id), HttpStatusCode.NotFound);

            return Commit(await _providerRepository.DeleteAsync(id));
        }

        private async Task<bool> ProviderWithDocumentNumberExistsAsync(string documentNumber)
            => await _providerRepository.ProviderWithDocumentNumberExistsAsync(documentNumber);
    }
}