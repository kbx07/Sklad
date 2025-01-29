namespace Sklad.Components.Models;

public class Tool
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Location { get; set; }
    public string? Description { get; set; }
    public bool Borrowed { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime? DateModified { get; set; }
    public string? Category { get; set; }
    public string? Condition { get; set; }
    public string? Borrower { get; set; }
    public DateTime? ReturnDate { get; set; }
    public string? Tags { get; set; }
    public string? ImagePath { get; set; }
    public int Quantity { get; set; }
}