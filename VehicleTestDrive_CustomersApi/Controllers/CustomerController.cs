using Microsoft.AspNetCore.Mvc;
using VehicleTestDrive_CustomersApi.Entities;
using VehicleTestDrive_CustomersApi.Repository;
using VehicleTestDrive_CustomersApi.Repository.Contracts;
using VehicleTestDrive_CustomersApi.Services.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehicleTestDrive_CustomersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task Post([FromBody] Customer customer)
        {
            await _customerService.AddCustomerAsync(customer);
        }
    }
}
