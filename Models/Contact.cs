using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Models;

[ComplexType]
public record Contact
{
    public required Address Address { get; init; }
    public required PhoneNumber HomePhone { get; init; }
    public required PhoneNumber WorkPhone { get; init; }
    public required PhoneNumber MobilePhone { get; init; }
} 