using VerticalSliceExample.Features.ExampleFeature.Infrastructure.ApiModels;
using VerticalSliceExample.Features.ExampleFeature.Infrastructure;
using VerticalSliceExample.Features.ExampleFeature.Models;
using VerticalSliceExample.Shared.Tools;

namespace VerticalSliceExample.Features.ExampleFeature.Commands;

public sealed class ExampleCommand
{
    public record Command(ExampleRequest Request) : IRequest<Response>;

    public record Response(ResultContainer<bool> Result);

    public class Handler : IRequestHandler<Command, Response>
    {
        private readonly IExampleHttpClient _exampleHttpClient;
        public Handler(IExampleHttpClient exampleHttpClient)
        {
            _exampleHttpClient = exampleHttpClient;
        }

        public async Task<Response> Handle(Command command, CancellationToken cancellationToken) =>
            new Response(await _exampleHttpClient.PostExampleAsync(command.Request));
    }
}
