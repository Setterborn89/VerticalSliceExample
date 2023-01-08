using ExampleApi.Features.ExampleFeature.Models;

namespace ExampleApi.Features.ExampleFeature.FakedDatabase;

public class FakedDatabase
{
    public FakedDatabase()
    {
        Example = new()
        {
            new (1, "Example1"),
            new (2, "Example2"),
            new (3, "Example3")
        };
    }

    private static List<FakedData> Example = new();

    public async Task AddExample(FakedData example)
    {
        Example.Add(example);
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<FakedData>?> GetAllExamples() => await Task.FromResult(Example);

    public async Task<FakedData?> GetExampleById(int id) => await Task.FromResult(Example.FirstOrDefault(x => x.Id == id));
}
