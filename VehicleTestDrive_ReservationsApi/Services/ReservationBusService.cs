using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using VehicleTestDrive_ReservationsApi.Entities;
using VehicleTestDrive_ReservationsApi.Services.Contracts;

namespace VehicleTestDrive_ReservationsApi.Services
{
    public class ReservationBusService : IReservationBusService
    {
        private readonly string connectionString;
        private readonly string queueName;

        public ReservationBusService(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("AzureBusService:ConnectionString");
            queueName = configuration.GetValue<string>("AzureBusService:CustomerQueueName");
        }

        public async Task<List<Reservation>> ReceiveAsync()
        {
            // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
            await using var client = new ServiceBusClient(connectionString);

            // create a receiver that we can use to receive the message
            ServiceBusReceiver receiver = client.CreateReceiver(queueName);

            // the received message is a different type as it contains some service set properties
            IReadOnlyList<ServiceBusReceivedMessage> receivedMessages = await receiver.ReceiveMessagesAsync(10);
            if (receivedMessages == null || receivedMessages.Count == 0)
            {
                return null;
            }

            List<Reservation> reservations = new();   

            foreach (ServiceBusReceivedMessage receivedMessage in receivedMessages)
            {
                string body = receivedMessage.Body.ToString();
                var messageCreated = JsonConvert.DeserializeObject<Reservation>(body);
                reservations.Add(messageCreated);
                await receiver.CompleteMessageAsync(receivedMessage);
            }

            
            return reservations;
        }
    }
}
