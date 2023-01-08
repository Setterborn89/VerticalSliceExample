using ExampleApi.Features.ExampleFeature.Models;
using MediatR;

namespace ExampleApi.Features.ExampleFeature.Queries;

public sealed class ExampleQuery
{
    public record Query(int Id) : IRequest<Response>;

    public record Response(FakedData? Result);

    public class Handler : IRequestHandler<Query, Response>
    {
        private readonly FakedDatabase.FakedDatabase _fakeDatabase;

        public Handler(FakedDatabase.FakedDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public async Task<Response> Handle(Query query, CancellationToken cancellationToken) =>
            new Response(await _fakeDatabase.GetExampleById(query.Id));
    }
}
