namespace ExampleApi.Features.ExampleFeature.Models;

public class FakedData
{
    public FakedData(int id, string example)
    {
        Id = id;
        Example = example;
    }

    public int Id { get; set; }
    public string? Example { get; set; }
}
