using System.Threading.Tasks;

namespace NetToolBox.Messaging.Abstractions
{
    public interface IMessageSender
    {
        Task SendAsync(string message);
        Task SendAsync<T>(T message);
    }
}
