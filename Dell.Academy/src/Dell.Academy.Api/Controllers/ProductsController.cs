using Dell.Academy.Application.Interfaces;
using Dell.Academy.Application.ViewModels;
using Dell.Academy.Domain.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dell.Academy.Api.Controllers
{
    [ApiController]
    [Route("/api/produtos")]
    public class ProductsController : ApiController
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service) => _service = service;

        [HttpGet]
        [ProducesResponseType(typeof(List<ProductViewModel>), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 500)]
        public async Task<ActionResult<List<ProductViewModel>>> Get() => CustomResponse(await _service.GetProductsAsync());

        [HttpGet]
        [Route("{id:long}")]
        [ProducesResponseType(typeof(ProductViewModel), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(typeof(ErrorViewModel), 500)]
        public async Task<ActionResult<ProductViewModel>> Get(long id) => CustomResponse(await _service.GetProductByIdAsync(id));

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorViewModel), 400)]
        [ProducesResponseType(typeof(ErrorViewModel), 500)]
        public async Task<ActionResult> Post(ProductViewModel viewModel) => CustomResponse(await _service.InsertProductAsync(viewModel));

        [HttpPut]
        [Route("{id:long}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorViewModel), 400)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(typeof(ErrorViewModel), 500)]
        public async Task<ActionResult> Put(ProductViewModel viewModel, long id)
        {
            if (id != viewModel.Id)
                return BadRequest(ErrorMessages.IdDoNotMatch);

            return CustomResponse(await _service.UpdateProductAsync(viewModel));
        }

        [HttpDelete]
        [Route("{id:long}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(typeof(ErrorViewModel), 500)]
        public async Task<ActionResult> Delete(long id) => CustomResponse(await _service.DeleteProductAsync(id));
    }
}