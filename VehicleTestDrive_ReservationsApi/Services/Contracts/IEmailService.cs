using VehicleTestDrive_ReservationsApi.Entities;

namespace VehicleTestDrive_ReservationsApi.Services.Contracts
{
    public interface IEmailService
    {
        void SendTestDriveConfirmationEmail(string emailTo);
    }
}
