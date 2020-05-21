using Microsoft.Azure.ServiceBus;
using NetToolBox.Messaging.Abstractions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetToolBox.Messaging.AzureServiceBus
{
    public sealed class AzureMessageSender : IMessageSender
    {
        private readonly IQueueClient _queueClient;

        internal AzureMessageSender(IQueueClient queueClient)
        {
            _queueClient = queueClient;
        }
        public Task SendAsync(string message)
        {
            var azureMessage = new Message(Encoding.UTF8.GetBytes(message));
            return SendAsync(azureMessage);
        }

        public Task SendAsync<T>(T message)
        {
            var messageString = JsonSerializer.Serialize(message);
            return SendAsync(messageString);

        }

        private Task SendAsync(Message message)
        {
            return _queueClient.SendAsync(message);
        }
    }
}
