using CustomerApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace CustomerApp.Infrastructure
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer>? Customers { get; set; }
    }
}