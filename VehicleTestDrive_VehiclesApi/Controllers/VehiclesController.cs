using Microsoft.AspNetCore.Mvc;
using VehicleTestDrive_VehiclesApi.Entities;
using VehicleTestDrive_VehiclesApi.Services.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehicleTestDrive_VehiclesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // GET: api/<VehiclesController>
        [HttpGet]
        public async Task<IEnumerable<Vehicle>> Get()
        {
            return await _vehicleService.GetAllVehiclesAsync();
        }

        // GET api/<VehiclesController>/5
        [HttpGet("{id}")]
        public async Task<Vehicle> Get(int id)
        {
            return await _vehicleService.GetVehicleByIdAsync(id);
        }

        // POST api/<VehiclesController>
        [HttpPost]
        public async Task Post([FromBody] Vehicle vehicle)
        {
            await _vehicleService.AddVehicleAsync(vehicle);
        }

        // PUT api/<VehiclesController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Vehicle vehicle)
        {
            await _vehicleService.UpdateVehicleAsync(vehicle, id);
        }

        // DELETE api/<VehiclesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _vehicleService.RemoveVehicleAsync(id);
        }
    }
}
