using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Models;

[ComplexType]
public record Address(string Line1, string? Line2, string City, string Country, string PostCode); 