using ContribLab.Web.Models.Api;
using Microsoft.AspNetCore.Mvc;

namespace ContribLab.Web.Controllers;

[ApiController]
[Route("api/feedback")]
public class FeedbackApiController : ControllerBase
{
    [HttpPost]
    public IActionResult Submit([FromBody] FeedbackRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Message))
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "The message is required.");
        }

        return Ok(new
        {
            request.Email,
            request.Rating,
            Received = true
        });
    }
}
