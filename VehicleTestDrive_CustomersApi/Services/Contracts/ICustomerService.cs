using VehicleTestDrive_CustomersApi.Entities;

namespace VehicleTestDrive_CustomersApi.Services.Contracts
{
    public interface ICustomerService
    {
        Task AddCustomerAsync(Customer customer);
    }
}
