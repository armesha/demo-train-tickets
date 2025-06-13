using Microsoft.EntityFrameworkCore;
using BlazorApp1.Data;
using BlazorApp1.Models;

namespace BlazorApp1.Services;

public class DataService
{
    private readonly ApplicationDbContext _context;

    public DataService(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<List<Customer>> FindCustomersByCityAsync(string city)
    {
        return await _context.Customers
            .Where(c => c.Contact.Address.City == city)
            .ToListAsync();
    }

    public async Task<List<Customer>> FindCustomersByPhoneAsync(PhoneNumber phoneNumber)
    {
        return await _context.Customers
            .Where(c => c.Contact.MobilePhone == phoneNumber ||
                       c.Contact.WorkPhone == phoneNumber ||
                       c.Contact.HomePhone == phoneNumber)
            .ToListAsync();
    }



    public async Task<List<Customer>> FindCustomersWithTagsAsync(string[] tags)
    {
        return await _context.Customers
            .Where(c => tags.Any(tag => c.Tags.Contains(tag)))
            .ToListAsync();
    }

    public async Task<List<Customer>> FindCustomersVisitedInYearAsync(int year)
    {
        return await _context.Customers
            .Where(c => c.VisitDates.Any(date => date.Year == year))
            .ToListAsync();
    }

    public async Task<object> GetCustomerStatisticsAsync()
    {
        return await _context.Customers
            .Select(c => new
            {
                c.Name,
                TagCount = c.Tags.Count,
                LastVisit = c.VisitDates.OrderByDescending(d => d).FirstOrDefault(),
                AverageRating = c.RatingHistory.Count > 0 ? c.RatingHistory.Average() : 0
            })
            .ToListAsync();
    }


    public async Task<List<Post>> FindPostsUpdatedBeforeAsync(DateOnly cutoffDate)
    {
        return await _context.Posts
            .Where(p => p.Metadata!.Updates[0].UpdatedOn < cutoffDate &&
                       p.Metadata!.Updates[1].UpdatedOn < cutoffDate)
            .ToListAsync();
    }

    public async Task<List<Post>> FindPostsWithSearchTermsAsync(string[] searchTerms)
    {
        return await _context.Posts
            .Where(p => p.Metadata!.TopSearches.Any(s => searchTerms.Contains(s.Term)))
            .ToListAsync();
    }

    public async Task<object> GetPostsWithLatestUpdatesAsync()
    {
        return await _context.Posts
            .Select(p => new
            {
                p.Title,
                LatestUpdate = (DateOnly?)p.Metadata!.Updates[0].UpdatedOn,
                SecondLatestUpdate = (DateOnly?)p.Metadata.Updates[1].UpdatedOn
            })
            .ToListAsync();
    }




    public async Task<List<Employee>> GetEmployeesAtLevelAsync(int level)
    {
        return await _context.Employees
            .Where(e => e.PathFromCEO.GetLevel() == level)
            .ToListAsync();
    }
    
    public async Task<List<Employee>> FindDirectReportsAsync(string managerName)
    {
        return await _context.Employees
            .Where(e => e.PathFromCEO.GetAncestor(1) == _context.Employees
                .Single(manager => manager.Name == managerName).PathFromCEO)
            .ToListAsync();
    }

    public async Task<List<Employee>> FindAllDescendantsAsync(string managerName)
    {
        var manager = await _context.Employees
            .FirstAsync(e => e.Name == managerName);

        return await _context.Employees
            .Where(e => e.PathFromCEO.IsDescendantOf(manager.PathFromCEO) && e.Id != manager.Id)
            .OrderBy(e => e.PathFromCEO.GetLevel())
            .ToListAsync();
    }



    public async Task<List<Employee>> FindEmployeesWorkingAtTimeAsync(TimeOnly currentTime)
    {
        return await _context.Employees
            .Where(e => e.WorkStartTime <= currentTime && e.WorkEndTime >= currentTime)
            .ToListAsync();
    }

    public async Task<List<Order>> GetTodaysOrdersAsync()
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        return await _context.Orders
            .Where(o => o.OrderDate == today)
            .ToListAsync();
    }




    public async Task<List<CustomerSummary>> GetCustomerSummariesAsync()
    {
        return await _context.Database
            .SqlQuery<CustomerSummary>($"""
                SELECT 
                    c.Name as CustomerName,
                    c.Contact_Address_City as City,
                    COUNT(o.Id) as OrderCount
                FROM Customers c
                LEFT JOIN Orders o ON c.Id = o.CustomerId
                GROUP BY c.Name, c.Contact_Address_City
                """)
            .ToListAsync();
    }




    public async Task<int> UpdateCustomerTagsAsync(string oldTag, string newTag)
    {
        return await _context.Customers
            .Where(c => c.Tags.Contains(oldTag))
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(c => c.Tags, c => c.Tags.Select(tag => tag == oldTag ? newTag : tag).ToList()));
    }

    public async Task<int> DeleteOldOrdersAsync(DateOnly cutoffDate)
    {
        return await _context.Orders
            .Where(o => o.OrderDate < cutoffDate)
            .ExecuteDeleteAsync();
    }


}

public class CustomerSummary
{
    public string CustomerName { get; set; } = null!;
    public string City { get; set; } = null!;
    public int OrderCount { get; set; }
} 