using ExampleApi.Features.ExampleFeature.FakedDatabase;
using ExampleApi.Features.ExampleFeature.Queries;
using MediatR;

namespace ExampleApi.Features;

public static class FeatureConfiguration
{
    public static WebApplicationBuilder AddExampleFeatureFeature(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<FakedDatabase>();

        builder.Services.AddScoped(typeof(IRequestHandler<ExampleQuery.Query, ExampleQuery.Response>), typeof(ExampleQuery.Handler));

        return builder;
    }
}
