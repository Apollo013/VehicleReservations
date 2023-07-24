using VehicleTestDrive_CustomersApi.Entities;

namespace VehicleTestDrive_CustomersApi.Repository.Contracts
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetAsync(int id);
        Task AddAsync(Vehicle vehicle); 
    }
}
