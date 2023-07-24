using Microsoft.AspNetCore.Mvc;
using VehicleTestDrive_ReservationsApi.Entities;
using VehicleTestDrive_ReservationsApi.Services.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehicleTestDrive_ReservationsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // GET: api/<ReservationsController>
        [HttpGet]
        public async Task<IEnumerable<Reservation>> Get()
        {
            return await _reservationService.GetReservationsAsync();
        }

        // PUT api/<ReservationsController>
        [HttpPut("{id}")]
        public async Task Put(int id)
        {
            await _reservationService.UpdateMailService(id);
        }
    }
}
