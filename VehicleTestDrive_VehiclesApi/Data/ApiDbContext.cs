using Microsoft.EntityFrameworkCore;
using VehicleTestDrive_VehiclesApi.Entities;

namespace VehicleTestDrive_VehiclesApi.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
            
        }

    }
}
