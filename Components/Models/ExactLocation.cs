namespace Sklad.Components.Models;

public class ExactLocation
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public List<Tool>? Tools { get; set; }
}