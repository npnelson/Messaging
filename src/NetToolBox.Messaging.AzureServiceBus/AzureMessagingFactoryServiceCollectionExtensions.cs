using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NetToolBox.Messaging.Abstractions;

namespace NetToolBox.Messaging.AzureServiceBus
{
    namespace Microsoft.Extensions.DependencyInjection
    {
        public static class AzureMessagingFactoryServiceCollectionExtensions
        {
            public static IServiceCollection AddAzureMessaging(this IServiceCollection serviceCollection)
            {
                serviceCollection.TryAddSingleton<IMessagingFactory, AzureMessagingFactory>();
                return serviceCollection;
            }
        }
    }
}
