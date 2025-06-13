using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Models;

public class Employee
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Position { get; set; }
    public required string Department { get; set; }
    
    public required HierarchyId PathFromCEO { get; set; }
    
    public required Contact Contact { get; set; }
    
    public DateOnly HireDate { get; set; }
    public TimeOnly WorkStartTime { get; set; }
    public TimeOnly WorkEndTime { get; set; }
    
    public List<string> Skills { get; set; } = new();
    public List<DateOnly> PerformanceReviewDates { get; set; } = new();
    
    public decimal Salary { get; set; }
} 