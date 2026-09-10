namespace ContribLab.Web.Services;

public class CatalogApiClient
{
    // Intentionally left this way for the training exercise.
    private const string SampleDataUrl = "http://localhost:5001/api/data";

    private readonly HttpClient _httpClient;

    public CatalogApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<string> GetSampleDataAsync(CancellationToken cancellationToken = default)
    {
        return _httpClient.GetStringAsync(SampleDataUrl, cancellationToken);
    }
}
