using VehicleTestDrive_VehiclesApi.Entities;
using VehicleTestDrive_VehiclesApi.Repository.Contracts;
using VehicleTestDrive_VehiclesApi.Services.Contracts;

namespace VehicleTestDrive_VehiclesApi.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository repository)
        {
            _vehicleRepository = repository;
        }

        public async Task AddVehicleAsync(Vehicle vehicle)
        {
            await _vehicleRepository.AddVehicleAsync(vehicle);
        }

        public async Task<List<Vehicle>> GetAllVehiclesAsync()
        {
            return await _vehicleRepository.GetAllVehiclesAsync();
        }

        public async Task<Vehicle> GetVehicleByIdAsync(int id)
        {
            return await _vehicleRepository.GetVehicleByIdAsync(id);
        }

        public async Task RemoveVehicleAsync(int id)
        {
            await _vehicleRepository.RemoveVehicleAsync(id);
        }

        public async Task UpdateVehicleAsync(Vehicle vehicle, int id)
        {
            await _vehicleRepository.UpdateVehicleAsync(vehicle, id);
        }
    }
}
