using Dell.Academy.Application.Extensions;
using Dell.Academy.Application.Interfaces;
using Dell.Academy.Application.ViewModels;
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

        public CategoriesController(ICategoryService service)
            => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<CategoryViewModel>>> Get() => CustomResponse(await _service.GetCategoriesAsync());

        [HttpGet]
        [Route("{id:long}")]
        public async Task<ActionResult<CategoryViewModel>> Get(long id) => CustomResponse(await _service.GetCategoryByIdAsync(id));

        [HttpPost]
        public async Task<ActionResult> Post(CategoryViewModel viewModel) => CustomResponse(await _service.InsertCategoryAsync(viewModel));

        [HttpPut]
        [Route("{id:long}")]
        public async Task<ActionResult> Put(CategoryViewModel viewModel, long id)
        {
            if (id != viewModel.Id)
                return BadRequest(ErrorMessages.IdDoNotMatch);

            return CustomResponse(await _service.UpdateCategoryAsync(viewModel));
        }

        [HttpDelete]
        [Route("{id:long}")]
        public async Task<ActionResult> Delete(long id) => CustomResponse(await _service.DeleteCategoryAsync(id));
    }
}