using VehicleTestDrive_ReservationsApi.Entities;

namespace VehicleTestDrive_ReservationsApi.Services.Contracts
{
    public interface IReservationService
    {
        Task<List<Reservation>> GetReservationsAsync();
        Task UpdateMailService(int id);
    }
}
