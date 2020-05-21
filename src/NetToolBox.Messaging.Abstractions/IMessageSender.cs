using System;
using System.Threading.Tasks;

namespace NetToolBox.Messaging.Abstractions
{
    public interface IMessageSender
    {
        Task SendAsync(string message, Guid messageGuid = default);
        Task SendAsync<T>(T message, Guid messageGuid = default);
    }
}
