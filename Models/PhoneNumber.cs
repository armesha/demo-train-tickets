using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Models;

[ComplexType]
public record PhoneNumber(int CountryCode, long Number); 