using System.ComponentModel.DataAnnotations.Schema;

namespace Sklad.Components.Models;

public class Tool
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool Borrowed { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime? DateModified { get; set; }
    public string? Borrower { get; set; }
    public DateTime? ReturnDate { get; set; }
    public string? Tags { get; set; }
    public string? ImagePath { get; set; }
    public int Quantity { get; set; }
    
    //[Column("location_id")]
    public int? LocationId { get; set; }

    //[Column("condition_id")]
    public int? ConditionId { get; set; }

    //[Column("exactlocation_id")]
    public int? ExactLocationId { get; set; }
    public Location? Location { get; set; }
    public Condition? Condition { get; set; }
    public ExactLocation? ExactLocation { get; set; }

}