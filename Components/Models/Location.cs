namespace Sklad.Components.Models;

public class Location
{
    public int Id { get; set; }
    public string? Name { get; set; }

    // Jeśli chcesz odwzorować relację 1:N od strony "jedynki" (Location -> wiele Tools),
    // możesz dodać listę narzędzi, które mają przypisane to Location:
    public List<Tool>? Tools { get; set; }
}