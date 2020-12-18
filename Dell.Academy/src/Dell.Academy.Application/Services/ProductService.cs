using AutoMapper;
using Dell.Academy.Application.Extensions;
using Dell.Academy.Application.Interfaces;
using Dell.Academy.Application.ViewModels;
using Dell.Academy.Domain.Extensions;
using Dell.Academy.Domain.Interfaces;
using Dell.Academy.Domain.Models;
using Dell.Academy.Domain.Models.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dell.Academy.Application.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProviderRepository _providerRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IProviderRepository provierRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _providerRepository = provierRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult> GetProductByIdAsync(long id)
        {
            var product = await _productRepository.GetProductByIdWithCategoryAndProviderAsync(id);
            return Success(_mapper.Map<ProductViewModel>(product));
        }

        public async Task<OperationResult> GetProductsAsync()
        {
            var products = await _productRepository.GetProductsWithCategoryAndProviderAsync();
            return Success(_mapper.Map<List<ProductViewModel>>(products));
        }

        public async Task<OperationResult> InsertProductAsync(ProductViewModel viewModel)
        {
            var product = _mapper.Map<Product>(viewModel);
            product.SetProductRegister(DateTime.UtcNow);
            if (!EntityIsValid(new ProductValidator(), product))
                return ValidationErrors();

            if (await _categoryRepository.GetByIdAsync(product.CategoryId) is null)
                return Error(ErrorMessages.NotFoundError("Categoria", product.CategoryId));

            if (await _providerRepository.GetByIdAsync(product.ProviderId) is null)
                return Error(ErrorMessages.NotFoundError("Fornecedor", product.ProviderId));

            if (await _productRepository.ProductSkuExists(product))
                return Error(ErrorMessages.ProductSkuExistsError);

            return Commit(await _productRepository.InsertAsync(product));
        }

        public async Task<OperationResult> UpdateProductAsync(ProductViewModel viewModel)
        {
            var product = _mapper.Map<Product>(viewModel);
            if (!EntityIsValid(new ProductValidator(), product))
                return ValidationErrors();

            if (await _categoryRepository.GetByIdAsync(product.CategoryId) == null)
                return Error(ErrorMessages.NotFoundError("Categoria", product.CategoryId));

            if (await _providerRepository.GetByIdAsync(product.ProviderId) == null)
                return Error(ErrorMessages.NotFoundError("Fornecedor", product.ProviderId));

            var productFromDb = await _productRepository.GetByIdAsync(product.Id);
            if (productFromDb is null)
                return Error(ErrorMessages.NotFoundError("Produto", product.Id));

            if (await _productRepository.ProductSkuExists(product))
                return Error(ErrorMessages.ProductSkuExistsError);

            product.SetProductRegister(productFromDb.Register);
            return Commit(await _productRepository.UpdateAsync(product));
        }

        public async Task<OperationResult> DeleteProductAsync(long id)
        {
            var productFromDb = await _productRepository.GetByIdAsync(id);
            if (productFromDb is null)
                return Error(ErrorMessages.NotFoundError("Produto", id));

            return Commit(await _productRepository.DeleteAsync(id));
        }
    }
}