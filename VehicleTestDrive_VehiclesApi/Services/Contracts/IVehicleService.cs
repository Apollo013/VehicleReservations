using VehicleTestDrive_VehiclesApi.Entities;

namespace VehicleTestDrive_VehiclesApi.Services.Contracts
{
    public interface IVehicleService
    {
        Task<List<Vehicle>> GetAllVehiclesAsync();
        Task<Vehicle> GetVehicleByIdAsync(int id);
        Task AddVehicleAsync(Vehicle vehicle);
        Task UpdateVehicleAsync(Vehicle vehicle, int id);
        Task RemoveVehicleAsync(int id);
    }
}
