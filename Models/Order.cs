namespace BlazorApp1.Models;

public class Order
{
    public int Id { get; set; }
    public required string Contents { get; set; }
    
    public required Address ShippingAddress { get; set; }
    public required Address BillingAddress { get; set; }
    public required PhoneNumber ContactPhone { get; set; }
    
    public DateOnly OrderDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public TimeOnly PreferredDeliveryTime { get; set; }
    
    public Customer Customer { get; set; } = null!;
    public int CustomerId { get; set; }
} 