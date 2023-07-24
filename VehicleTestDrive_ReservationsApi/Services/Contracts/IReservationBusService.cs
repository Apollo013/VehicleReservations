using VehicleTestDrive_ReservationsApi.Entities;

namespace VehicleTestDrive_ReservationsApi.Services.Contracts
{
    public interface IReservationBusService
    {
        Task<List<Reservation>> ReceiveAsync();
    }
}
