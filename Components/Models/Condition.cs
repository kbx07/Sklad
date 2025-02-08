namespace Sklad.Components.Models;

public class Condition
{
    public int Id { get; set; }
    public string? Name { get; set; }

    // Możesz dodać listę Tools:
    public List<Tool>? Tools { get; set; }
}