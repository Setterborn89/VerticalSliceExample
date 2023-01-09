using VerticalSliceExample.Features.ExampleFeature.Infrastructure.ApiModels;
using VerticalSliceExample.Features.ExampleFeature.Models;
using VerticalSliceExample.Shared.Tools;

namespace VerticalSliceExample.Features.ExampleFeature.Infrastructure
{
    public interface IExampleHttpClient
    {
        Task<ResultContainer<ExampleResponse>> GetExampleAsync(ExampleRequest example);
        Task<ResultContainer<bool>> PostExampleAsync(ExampleRequest example);
    }
}