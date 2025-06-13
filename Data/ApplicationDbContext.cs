using Microsoft.EntityFrameworkCore;
using BlazorApp1.Models;

namespace BlazorApp1.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // entities main
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Blog> Blogs => Set<Blog>();
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Employee> Employees => Set<Employee>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureComplexTypes(modelBuilder);
        
        ConfigureJsonColumns(modelBuilder);
        
        ConfigurePrimitiveCollections(modelBuilder);
        
        ConfigureHierarchyId(modelBuilder);
        
        ConfigureDateTimeTypes(modelBuilder);
        
        ConfigureRowVersions(modelBuilder);
    }

    private static void ConfigureComplexTypes(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ComplexProperty(e => e.Contact, contactBuilder =>
            {
                contactBuilder.ComplexProperty(c => c.Address);
                contactBuilder.ComplexProperty(c => c.HomePhone);
                contactBuilder.ComplexProperty(c => c.WorkPhone);
                contactBuilder.ComplexProperty(c => c.MobilePhone);
            });
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ComplexProperty(e => e.ShippingAddress);
            entity.ComplexProperty(e => e.BillingAddress);
            entity.ComplexProperty(e => e.ContactPhone);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ComplexProperty(e => e.Contact, contactBuilder =>
            {
                contactBuilder.ComplexProperty(c => c.Address);
                contactBuilder.ComplexProperty(c => c.HomePhone);
                contactBuilder.ComplexProperty(c => c.WorkPhone);
                contactBuilder.ComplexProperty(c => c.MobilePhone);
            });
        });
    }

    private static void ConfigureJsonColumns(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>()
            .OwnsOne(b => b.Metadata, metadataBuilder =>
            {
                metadataBuilder.ToJson();
            });

        modelBuilder.Entity<Post>()
            .OwnsOne(p => p.Metadata, metadataBuilder =>
            {
                metadataBuilder.ToJson();
                metadataBuilder.OwnsMany(m => m.Updates);
                metadataBuilder.OwnsMany(m => m.TopSearches);
            });
    }

    private static void ConfigurePrimitiveCollections(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .Property(e => e.Tags)
            .HasMaxLength(2048);

        modelBuilder.Entity<Customer>()
            .Property(e => e.PreferredCategories)
            .HasMaxLength(1024);

        modelBuilder.Entity<Blog>()
            .Property(e => e.Tags)
            .HasMaxLength(1024);

        modelBuilder.Entity<Post>()
            .Property(e => e.Tags)
            .HasMaxLength(512);

        modelBuilder.Entity<Employee>()
            .Property(e => e.Skills)
            .HasMaxLength(2048);
    }

    private static void ConfigureHierarchyId(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .Property(e => e.PathFromCEO)
            .HasColumnType("hierarchyid");
    }

    private static void ConfigureDateTimeTypes(ModelBuilder modelBuilder)
    {   
        modelBuilder.Entity<Order>()
            .Property(e => e.OrderDate)
            .HasColumnType("date");

        modelBuilder.Entity<Order>()
            .Property(e => e.PreferredDeliveryTime)
            .HasColumnType("time");
    }

    private static void ConfigureRowVersions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .Property(e => e.RowVersion)
            .IsRowVersion();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<List<string>>()
            .AreUnicode(true)
            .HaveMaxLength(4000);

        configurationBuilder
            .Properties<string[]>()
            .AreUnicode(true)
            .HaveMaxLength(2000);
    }
} 