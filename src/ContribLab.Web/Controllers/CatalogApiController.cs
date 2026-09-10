using ContribLab.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContribLab.Web.Controllers;

[ApiController]
[Route("api/catalog")]
public class CatalogApiController : ControllerBase
{
    private readonly CatalogApiClient _catalogApiClient;

    public CatalogApiController(CatalogApiClient catalogApiClient)
    {
        _catalogApiClient = catalogApiClient;
    }

    [HttpGet("sample")]
    public async Task<IActionResult> GetSample(CancellationToken cancellationToken)
    {
        var data = await _catalogApiClient.GetSampleDataAsync(cancellationToken);
        return Content(data, "application/json");
    }
}
