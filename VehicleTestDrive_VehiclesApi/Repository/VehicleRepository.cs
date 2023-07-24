using Microsoft.EntityFrameworkCore;
using VehicleTestDrive_VehiclesApi.Data;
using VehicleTestDrive_VehiclesApi.Entities;
using VehicleTestDrive_VehiclesApi.Repository.Contracts;

namespace VehicleTestDrive_VehiclesApi.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApiDbContext _ctx;

        public VehicleRepository(ApiDbContext context)
        {
            _ctx = context;   
        }

        public async Task AddVehicleAsync(Vehicle vehicle)
        {
            await _ctx.Vehicles.AddAsync(vehicle);
            await _ctx.SaveChangesAsync();
        }

        public async Task<List<Vehicle>> GetAllVehiclesAsync()
        {
            return await _ctx.Vehicles.ToListAsync();
        }

        public async Task<Vehicle> GetVehicleByIdAsync(int id)
        {
            return await _ctx.Vehicles.Where(v => v.Id == id).FirstOrDefaultAsync();    
        }

        public async Task RemoveVehicleAsync(int id)
        {
            var vehicleObj = await GetVehicleByIdAsync(id) ?? throw new InvalidOperationException();

            _ctx.Vehicles.Remove(vehicleObj);
            await _ctx.SaveChangesAsync();
        }

        public async  Task UpdateVehicleAsync(Vehicle vehicle, int id)
        {
            var vehicleObj = await GetVehicleByIdAsync(id) ?? throw new InvalidOperationException();

            vehicleObj.Name = vehicle.Name;
            vehicleObj.Price = vehicle.Price;
            vehicleObj.Displacement = vehicle.Displacement;
            vehicleObj.Width = vehicle.Width;
            vehicleObj.Height = vehicle.Height; 
            vehicleObj.Length = vehicle.Length; 
            vehicleObj.ImageUrl = vehicle.ImageUrl;

            await _ctx.SaveChangesAsync();
        }
    }
}
