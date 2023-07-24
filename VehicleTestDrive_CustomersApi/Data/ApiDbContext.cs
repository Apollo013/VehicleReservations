using Microsoft.EntityFrameworkCore;
using VehicleTestDrive_CustomersApi.Entities;

namespace VehicleTestDrive_CustomersApi.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
            
        }
    }
}
