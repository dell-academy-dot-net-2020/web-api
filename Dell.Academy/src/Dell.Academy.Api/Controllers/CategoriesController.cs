using Dell.Academy.Application.Interfaces;
using Dell.Academy.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dell.Academy.Api.Controllers
{
    [ApiController]
    [Route("/api/categorias")]
    public class CategoriesController : ApiController
    {
        private readonly ICategoryService _service;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ICategoryService service, ILogger<CategoriesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryViewModel>>> Get()
        {
            var categories = await _service.GetCategoriesAsync();
            _logger.LogInformation($"Temos {categories.Count} categories");
            return categories;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<CategoryViewModel>> Get(long id)
        {
            try
            {
                var category = await _service.GetCategoryByIdAsync(id);
                _logger.LogInformation($"Categoria {category?.Name} encontrada");
                return category;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(CategoryViewModel viewModel)
        {
            try
            {
                await _service.InsertCategoryAsync(viewModel);
                _logger.LogInformation("Categoria foi cadastrada com sucesso!");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possível cadastrar!");
                return BadRequest(ex.Message);
            }
        }
    }
}