using VerticalSliceExample.Features.ExampleFeature.Infrastructure.ApiModels;
using VerticalSliceExample.Features.ExampleFeature.Models;
using VerticalSliceExample.Shared.Tools;

namespace VerticalSliceExample.Features.ExampleFeature.Infrastructure;

public class ExampleHttpClient : IExampleHttpClient
{
    private readonly HttpClient _httpClient;

    public ExampleHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<ResultContainer<ExampleResponse>> GetExampleAsync(ExampleRequest example)
    {
        var response = await _httpClient.GetAsync($"api/Example/{example.Id}");
        var content = await response.Content.ReadFromJsonAsync<ExampleResponse>();

        return new ResultContainer<ExampleResponse>(content, response);
    }
}
