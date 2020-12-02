using Dell.Academy.Application.Extensions;
using Microsoft.AspNetCore.Mvc;
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
                return NotFound(result.Result.Errors);

            return BadRequest(result.Result.Errors);
        }
    }
}