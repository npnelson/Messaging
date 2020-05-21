using Microsoft.Azure.ServiceBus;
using NetToolBox.Messaging.Abstractions;
using System;
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
        public Task SendAsync(string message, Guid messageGuid = default)
        {
            var azureMessage = new Message(Encoding.UTF8.GetBytes(message));
            if (messageGuid == default)
            {
                messageGuid = Guid.NewGuid();
            }
            azureMessage.MessageId = messageGuid.ToString();
            return SendAsync(azureMessage);
        }

        public Task SendAsync<T>(T message, Guid messageGuid = default)
        {
            var messageString = JsonSerializer.Serialize(message);
            return SendAsync(messageString, messageGuid);

        }

        private Task SendAsync(Message message)
        {
            return _queueClient.SendAsync(message);
        }
    }
}
