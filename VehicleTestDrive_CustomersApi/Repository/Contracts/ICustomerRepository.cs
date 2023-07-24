using VehicleTestDrive_CustomersApi.Entities;

namespace VehicleTestDrive_CustomersApi.Repository.Contracts
{
    public interface ICustomerRepository
    {
        Task AddCustomerAsync(Customer customer);
    }
}
