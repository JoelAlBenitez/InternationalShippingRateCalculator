namespace Infraestructure.Data;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class ShippingDbContext : DbContext
{
    public ShippingDbContext(DbContextOptions<ShippingDbContext> options) 
        : base(options)
    {
    }

    public DbSet<Country> Countrys { get; set; } = null!;

  
}
