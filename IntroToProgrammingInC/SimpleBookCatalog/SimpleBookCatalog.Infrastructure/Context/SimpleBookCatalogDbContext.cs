using Microsoft.EntityFrameworkCore;
using SimpleBookCatalog.Domain.Entities;

namespace SimpleBookCatalog.Infrastructure.Context;

public class SimpleBookCatalogDbContext : DbContext
{
 public SimpleBookCatalogDbContext(DbContextOptions<SimpleBookCatalogDbContext> options) : base(options)
 {
    
 }
 
 public DbSet<Book> Books { get; set; }

 
 // this is fluent api
 // protected override void OnModelCreating(ModelBuilder modelBuilder)
 // {
 //  modelBuilder.Entity<Book>().Property(e => e.Title).IsRequired().HasMaxLength(100);
 //  modelBuilder.Entity<Book>().Property(e => e.Author).IsRequired().HasMaxLength(100);
 // }
 
}