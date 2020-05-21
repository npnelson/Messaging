namespace NetToolBox.Messaging.Abstractions
{
    public interface IMessagingFactory
    {
        IMessageSender GetSender(string connectionString, string entityPath);
    }
}
