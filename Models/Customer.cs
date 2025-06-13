namespace BlazorApp1.Models;

public class Customer
{
    public int Id { get; set; }
    public required string Name { get; set; }
    
    public required Contact Contact { get; set; }
    
    public List<string> Tags { get; set; } = new();
    public List<DateOnly> VisitDates { get; set; } = new();
    public string[] PreferredCategories { get; set; } = Array.Empty<string>();
    public List<int> RatingHistory { get; set; } = new();
    
    public List<Order> Orders { get; } = new();
    
    public ulong RowVersion { get; set; }
} 