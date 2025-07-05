using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

// Class what we are deriving from
public class StoreContext(DbContextOptions options) : DbContext(options)
{
    public required DbSet<Product> Products { get; set; }
}
