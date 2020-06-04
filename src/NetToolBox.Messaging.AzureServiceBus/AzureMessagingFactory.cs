using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Primitives;
using NetToolBox.Messaging.Abstractions;
using System.Collections.Concurrent;

namespace NetToolBox.Messaging.AzureServiceBus
{
    public sealed class AzureMessagingFactory : IMessagingFactory
    {
        private readonly ConcurrentDictionary<(string connectionString, string? entityPath), IMessageSender> _senderDictionary = new ConcurrentDictionary<(string connectionString, string? entityPath), IMessageSender>();
        public IMessageSender GetSender(string connectionString, string? entityPath)
        {
            IMessageSender retval;
            QueueClient queueClient;
            var connStringBuilder = new ServiceBusConnectionStringBuilder(connectionString);
            if (!_senderDictionary.ContainsKey((connectionString, entityPath)))
            {
                if (entityPath == null)
                {

                    queueClient = new QueueClient(connStringBuilder);

                }
                else
                {
                    var tokenProvider = TokenProvider.CreateManagedIdentityTokenProvider();
                    queueClient = new QueueClient(connStringBuilder.Endpoint, entityPath, tokenProvider);
                }
                var messageSender = new AzureMessageSender(queueClient);
                _senderDictionary.TryAdd((connectionString, entityPath), messageSender);
            }
            retval = _senderDictionary[(connectionString, entityPath)];
            return retval;

        }
    }
}
