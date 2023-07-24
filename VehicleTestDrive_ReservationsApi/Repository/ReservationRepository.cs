using Microsoft.EntityFrameworkCore;
using VehicleTestDrive_ReservationsApi.Data;
using VehicleTestDrive_ReservationsApi.Entities;
using VehicleTestDrive_ReservationsApi.Repository.Contracts;

namespace VehicleTestDrive_ReservationsApi.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApiDbContext _context;
        public ReservationRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task AddReservationsAsync(List<Reservation> reservations)
        {
            await _context.Reservations.AddRangeAsync(reservations);
            await _context.SaveChangesAsync();
        }

        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            return await _context.Reservations.FindAsync(id);
        }

        public async Task<List<Reservation>> GetReservationsAsync()
        {
            return await _context.Reservations.ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();

        }
    }
}
