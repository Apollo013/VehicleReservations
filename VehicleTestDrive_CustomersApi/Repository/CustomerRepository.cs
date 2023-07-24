using VehicleTestDrive_CustomersApi.Data;
using VehicleTestDrive_CustomersApi.Entities;
using VehicleTestDrive_CustomersApi.Repository.Contracts;

namespace VehicleTestDrive_CustomersApi.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApiDbContext _customerContext;

        public CustomerRepository(ApiDbContext context)
        {
            _customerContext = context;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await _customerContext.Customers.AddAsync(customer);
            await _customerContext.SaveChangesAsync();
        }
    }
}
