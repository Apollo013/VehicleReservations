using Newtonsoft.Json;
using VehicleTestDrive_CustomersApi.Entities;
using VehicleTestDrive_CustomersApi.Repository.Contracts;
using VehicleTestDrive_CustomersApi.Services.Contracts;

namespace VehicleTestDrive_CustomersApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ICustomerBusService _customerBusService;

        public CustomerService(ICustomerRepository customerRepository, IVehicleRepository vehicleRepository, ICustomerBusService customerBusService)
        {
            _customerRepository = customerRepository;
            _vehicleRepository = vehicleRepository;
            _customerBusService = customerBusService;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            var vehicleInDb = await _vehicleRepository.GetAsync(customer.VehicleId);

            if (vehicleInDb == null)
            {
                await _vehicleRepository.AddAsync(customer.Vehicle);
            }

            customer.Vehicle = null;
            await _customerRepository.AddCustomerAsync(customer);

            var customerJson = JsonConvert.SerializeObject(customer);
            await _customerBusService.SendAsync(customerJson);

        }
    }
}
