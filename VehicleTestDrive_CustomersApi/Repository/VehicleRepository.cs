using Microsoft.EntityFrameworkCore;
using VehicleTestDrive_CustomersApi.Data;
using VehicleTestDrive_CustomersApi.Entities;
using VehicleTestDrive_CustomersApi.Repository.Contracts;

namespace VehicleTestDrive_CustomersApi.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApiDbContext _context;

        public VehicleRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task<Vehicle> GetAsync(int id)
        {
            return await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
        }
    }
}
