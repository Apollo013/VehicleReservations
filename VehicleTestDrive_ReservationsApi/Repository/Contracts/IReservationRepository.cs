using VehicleTestDrive_ReservationsApi.Entities;

namespace VehicleTestDrive_ReservationsApi.Repository.Contracts
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetReservationsAsync();
        Task<Reservation> GetReservationByIdAsync(int id);
        Task AddReservationsAsync(List<Reservation> reservations);
        Task SaveAsync();
    }
}
