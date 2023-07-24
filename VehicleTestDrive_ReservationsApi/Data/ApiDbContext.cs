using Microsoft.EntityFrameworkCore;
using VehicleTestDrive_ReservationsApi.Entities;

namespace VehicleTestDrive_ReservationsApi.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
            
        }

    }
}
