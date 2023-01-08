using VerticalSliceExample.Features.ExampleFeature.Infrastructure;
using VerticalSliceExample.Features.ExampleFeature.Infrastructure.ApiModels;
using VerticalSliceExample.Features.ExampleFeature.Models;
using VerticalSliceExample.Shared.Tools;

namespace VerticalSliceExample.Features.ExampleFeature.Queries;

public sealed class ExampleQuery
{
    public record Query(ExampleRequest Request) : IRequest<Response>;

    public record Response(ResultContainer<ExampleResponse> Result);

    public class Handler : IRequestHandler<Query, Response>
    {
        private readonly IExampleHttpClient _exampleHttpClient;
        public Handler(IExampleHttpClient exampleHttpClient)
        {
            _exampleHttpClient = exampleHttpClient;
        }

        public async Task<Response> Handle(Query query, CancellationToken cancellationToken) =>
            new Response(await _exampleHttpClient.GetExampleAsync(query.Request));
    }
}