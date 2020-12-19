using Dell.Academy.Application.Extensions;
using Dell.Academy.Application.ViewModels;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace Dell.Academy.Api.Controllers
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        protected ActionResult CustomResponse(OperationResult result)
        {
            if (!result.IsValid)
                return ErrorResponse(result);

            return Ok(result.Content ?? string.Empty);
        }

        private ActionResult ErrorResponse(OperationResult result)
        {
            if (result.StatusCode == HttpStatusCode.NotFound)
                return NotFound(MapErrorsToResponse(result.Result));

            return BadRequest(MapErrorsToResponse(result.Result));
        }

        private static ErrorViewModel MapErrorsToResponse(ValidationResult validationResult)
            => new ErrorViewModel(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
    }
}