using Dell.Academy.Application.Interfaces;
using Dell.Academy.Application.ViewModels;
using Dell.Academy.Domain.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dell.Academy.Api.Controllers
{
    [ApiController]
    [Route("/api/categorias")]
    public class CategoriesController : ApiController
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service) => _service = service;

        [HttpGet]
        [ProducesResponseType(typeof(List<CategoryViewModel>), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 500)]
        public async Task<ActionResult<List<CategoryViewModel>>> Get() => CustomResponse(await _service.GetCategoriesAsync());

        [HttpGet]
        [Route("{id:long}")]
        [ProducesResponseType(typeof(CategoryViewModel), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(typeof(ErrorViewModel), 500)]
        public async Task<ActionResult<CategoryViewModel>> Get(long id) => CustomResponse(await _service.GetCategoryByIdAsync(id));

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorViewModel), 400)]
        [ProducesResponseType(typeof(ErrorViewModel), 500)]
        public async Task<ActionResult> Post(CategoryViewModel viewModel) => CustomResponse(await _service.InsertCategoryAsync(viewModel));

        [HttpPut]
        [Route("{id:long}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorViewModel), 400)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(typeof(ErrorViewModel), 500)]
        public async Task<ActionResult> Put(CategoryViewModel viewModel, long id)
        {
            if (id != viewModel.Id)
                return BadRequest(ErrorMessages.IdDoNotMatch);

            return CustomResponse(await _service.UpdateCategoryAsync(viewModel));
        }

        [HttpDelete]
        [Route("{id:long}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorViewModel), 400)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(typeof(ErrorViewModel), 500)]
        public async Task<ActionResult> Delete(long id) => CustomResponse(await _service.DeleteCategoryAsync(id));
    }
}