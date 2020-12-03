using Dell.Academy.Application.Extensions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Dell.Academy.Api.Controllers
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        public ActionResult CustomResponse(OperationResult result)
        {
            if (!result.IsValid)
                return ErrorResponse(result);

            return Ok(result.Content);
        }

        private ActionResult ErrorResponse(OperationResult result)
        {
            if (result.StatusCode == HttpStatusCode.NotFound)
                return NotFound(MapErrorsToResponse(result.Result));

            return BadRequest(MapErrorsToResponse(result.Result));
        }

        private static List<string> MapErrorsToResponse(ValidationResult validationResult)
            => validationResult.Errors.Select(e => e.ErrorMessage).ToList();
    }
}