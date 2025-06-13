namespace BlazorApp1.Models;

public class Post
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public DateOnly PublishedOn { get; set; }
    
    public PostMetadata? Metadata { get; set; }
    
    public List<string> Tags { get; set; } = new();
    public List<string> SearchTerms { get; set; } = new();
    
    public Blog Blog { get; set; } = null!;
    public int BlogId { get; set; }
}

public class PostMetadata
{
    public List<PostUpdate> Updates { get; set; } = new();
    public List<SearchInfo> TopSearches { get; set; } = new();
    
    public string? CustomField1 { get; set; }
    public string? CustomField2 { get; set; }
    public int CustomNumber { get; set; }
}

public class PostUpdate
{
    public DateOnly UpdatedOn { get; set; }
    public required string UpdatedBy { get; set; }
    public required string Description { get; set; }
}

public class SearchInfo
{
    public required string Term { get; set; }
    public int Count { get; set; }
} 