using System.Net;
using System.Net.Mail;
using VehicleTestDrive_ReservationsApi.Entities;
using VehicleTestDrive_ReservationsApi.Repository.Contracts;
using VehicleTestDrive_ReservationsApi.Services.Contracts;

namespace VehicleTestDrive_ReservationsApi.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IReservationBusService _reservationBusService;
        private readonly IEmailService _emailService;

        public ReservationService(IReservationRepository reservationRepository, IReservationBusService reservationBusService, IEmailService emailService)
        {
            _reservationRepository = reservationRepository;
            _reservationBusService = reservationBusService;
            _emailService = emailService;
        }

        public async Task<List<Reservation>> GetReservationsAsync()
        {
            var reservations = await _reservationBusService.ReceiveAsync();
            await _reservationRepository.AddReservationsAsync(reservations);
            return await _reservationRepository.GetReservationsAsync();
        }

        public async Task UpdateMailService(int id)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(id);

            if (reservation != null && reservation.IsEmailSent == false)
            {
                _emailService.SendTestDriveConfirmationEmail(reservation.Email);
                reservation.IsEmailSent = true;
                await _reservationRepository.SaveAsync();
            }
        }

    }
}
