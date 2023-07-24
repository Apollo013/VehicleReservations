using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using VehicleTestDrive_CustomersApi.Entities;
using VehicleTestDrive_CustomersApi.Services.Contracts;

namespace VehicleTestDrive_CustomersApi.Services
{
    public class CustomerBusService : ICustomerBusService
    {
        private readonly string connectionString;
        private readonly string queueName;

        public CustomerBusService(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("AzureBusService:ConnectionString");
            queueName = configuration.GetValue<string>("AzureBusService:CustomerQueueName");
        }

        public async Task SendAsync(string text)
        {
            // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
            await using var client = new ServiceBusClient(connectionString);

            // create the sender
            ServiceBusSender sender = client.CreateSender(queueName);

            // create a message that we can send. UTF-8 encoding is used when providing a string.
            ServiceBusMessage message = new(text);

            // send the message
            await sender.SendMessageAsync(message);
        }
    }
}
