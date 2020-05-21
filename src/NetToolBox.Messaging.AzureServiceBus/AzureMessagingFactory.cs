using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Primitives;
using NetToolBox.Messaging.Abstractions;
using System.Collections.Concurrent;

namespace NetToolBox.Messaging.AzureServiceBus
{
    public sealed class AzureMessagingFactory : IMessagingFactory
    {
        private readonly ConcurrentDictionary<(string connectionString, string entityPath), IMessageSender> _senderDictionary = new ConcurrentDictionary<(string connectionString, string entityPath), IMessageSender>();
        public IMessageSender GetSender(string connectionString, string entityPath)
        {
            IMessageSender retval;

            if (!_senderDictionary.ContainsKey((connectionString, entityPath)))
            {
                var tokenProvider = TokenProvider.CreateManagedIdentityTokenProvider();
                var queueClient = new QueueClient(connectionString, entityPath, tokenProvider);
                var messageSender = new AzureMessageSender(queueClient);
                _senderDictionary.TryAdd((connectionString, entityPath), messageSender);
            }
            retval = _senderDictionary[(connectionString, entityPath)];
            return retval;

        }
    }
}
