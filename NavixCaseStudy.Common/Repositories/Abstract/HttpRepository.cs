namespace NavixCaseStudy.Common.Repositories.Abstract;

/// <summary>
/// Base repository class for HTTP requests with helpers functions
/// </summary>
public class HttpRepository
{
    protected readonly HttpClient _httpClient;

    public HttpRepository(string clientName, IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient(clientName);
    }

    public void AddQueryParam(Dictionary<string, string?> queryParams, string key, string? value)
    {
        if (value is not null)
        {
            queryParams.Add(key, value);
        }
    }

    public void AddQueryParam(Dictionary<string, string?> queryParams, string key, List<string>? values)
    {
        if (values is not null)
        {
            foreach (var value in values)
            {
                queryParams.Add(key, value);
            }
        }
    }
}
