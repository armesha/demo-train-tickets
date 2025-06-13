using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Models;

public class Blog
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    
    public BlogMetadata Metadata { get; set; } = new();
    
    public List<string> Tags { get; set; } = new();
    public List<DateOnly> PublishDates { get; set; } = new();
     
    public List<Post> Posts { get; } = new();
}

public class BlogMetadata
{
    public string? Author { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public List<string> Categories { get; set; } = new();
    
    public string? Theme { get; set; }
    public string? Language { get; set; }
    public bool IsPublic { get; set; } = true;
} 