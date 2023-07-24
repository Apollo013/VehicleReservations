using System.Net.Mail;
using System.Net;
using VehicleTestDrive_ReservationsApi.Services.Contracts;

namespace VehicleTestDrive_ReservationsApi.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendTestDriveConfirmationEmail(string emailTo)
        {
            var host = _configuration.GetValue<string>("EmailService:Host");
            var account = _configuration.GetValue<string>("EmailService:Account");
            var password = _configuration.GetValue<string>("EmailService:Password");

            var smtpClient = new SmtpClient(host)
            {
                Port = 587,
                Credentials = new NetworkCredential(account, password),
                EnableSsl = true
            };

            smtpClient.Send(account, emailTo, "Vehicle Test Drive", "Your test drive has been reserved");
        }
    }
}
