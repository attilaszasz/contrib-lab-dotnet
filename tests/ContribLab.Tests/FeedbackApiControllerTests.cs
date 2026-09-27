using ContribLab.Web.Controllers;
using ContribLab.Web.Models.Api;
using Microsoft.AspNetCore.Mvc;

namespace ContribLab.Tests;

public class FeedbackApiControllerTests
{
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Submit_InvalidMessage_ReturnsBadRequest(string message)
    {
        var controller = new FeedbackApiController();

        var result = controller.Submit(new FeedbackRequest { Message = message });

        var badRequest = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("The message is required.", badRequest.Value);
    }
}
