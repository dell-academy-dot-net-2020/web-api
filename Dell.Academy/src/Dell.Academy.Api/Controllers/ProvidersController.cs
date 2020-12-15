using Dell.Academy.Application.Interfaces;
using Dell.Academy.Application.ViewModels;
using Dell.Academy.Domain.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dell.Academy.Api.Controllers
{
    [ApiController]
    [Route("/api/fornecedores")]
    public class ProvidersController : ApiController
    {
        private readonly IProviderService _service;

        public ProvidersController(IProviderService service) => _service = service;

        [HttpGet]
        [ProducesResponseType(typeof(List<ProviderViewModel>), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 500)]
        public async Task<ActionResult<List<CategoryViewModel>>> Get() => CustomResponse(await _service.GetProvidersAsync());

        [HttpGet]
        [Route("{id:long}")]
        [ProducesResponseType(typeof(ProviderViewModel), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(typeof(ErrorViewModel), 500)]
        public async Task<ActionResult<ProviderViewModel>> Get(long id) => CustomResponse(await _service.GetProviderByIdAsync(id));

        [HttpPost]
        [ProducesResponseType(typeof(ProviderViewModel), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 400)]
        [ProducesResponseType(typeof(ErrorViewModel), 500)]
        public async Task<ActionResult> Post(ProviderViewModel viewModel) => CustomResponse(await _service.InsertProviderAsync(viewModel));

        [HttpPut]
        [Route("{id:long}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorViewModel), 400)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(typeof(ErrorViewModel), 500)]
        public async Task<ActionResult> Put(ProviderViewModel viewModel, long id)
        {
            if (id != viewModel.Id)
                return BadRequest(ErrorMessages.IdDoNotMatch);

            return CustomResponse(await _service.UpdateProviderAsync(viewModel));
        }

        [HttpPut]
        [Route("atualizar-endereco/{id:long}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorViewModel), 400)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(typeof(ErrorViewModel), 500)]
        public async Task<ActionResult> Put(AddressViewModel viewModel, long id)
        {
            if (id != viewModel.ProviderId)
                return BadRequest(ErrorMessages.IdDoNotMatch);

            return CustomResponse(await _service.UpdateAddressAsync(viewModel));
        }

        [HttpDelete]
        [Route("{id:long}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(typeof(ErrorViewModel), 500)]
        public async Task<ActionResult> Delete(long id) => CustomResponse(await _service.DeleteProviderAsync(id));
    }
}