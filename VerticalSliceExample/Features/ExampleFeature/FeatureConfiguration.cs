using VerticalSliceExample.Features.ExampleFeature.Infrastructure;
using VerticalSliceExample.Features.ExampleFeature.Queries;

namespace VerticalSliceExample.Features.ExampleFeature;

public static class FeatureConfiguration
{
    public static WebApplicationBuilder AddExampleFeatureFeature(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped(typeof(IRequestHandler<ExampleQuery.Query, ExampleQuery.Response>), typeof(ExampleQuery.Handler));

        builder.AddExampleHttpClient();

        return builder;
    }

    private static IHttpClientBuilder AddExampleHttpClient(this WebApplicationBuilder builder)
    {
        var baseAdress = builder.Configuration.GetValue<string>("BaseUrl");

        return builder.Services.AddHttpClient<IExampleHttpClient, ExampleHttpClient>(client =>
        {
            client.BaseAddress = new Uri(baseAdress);
        });
    }
}
