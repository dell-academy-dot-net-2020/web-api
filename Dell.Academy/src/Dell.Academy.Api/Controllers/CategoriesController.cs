using Dell.Academy.Application.Extensions.Exceptions;
using Dell.Academy.Application.Interfaces;
using Dell.Academy.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
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
            _logger.LogInformation($"Temos {categories.Count} categorias cadastradas");
            return categories;
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<ActionResult<CategoryViewModel>> Get(long id)
        {
            try
            {
                var category = await _service.GetCategoryByIdAsync(id);
                _logger.LogInformation($"A categoria {category?.Name} foi encontrada");
                return category;
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, $"A categoria não foi encontrada");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Falha na comunicação com o banco");
                return BadRequest(ex.Message);
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
                _logger.LogCritical(ex, "Não foi possível cadastrar a categoria!");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id:long}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                await _service.DeleteCategoryAsync(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, $"A categoria não foi encontrada");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Não foi possível deletar o categoria!");
                return BadRequest(ex.Message);
            }
        }
    }
}