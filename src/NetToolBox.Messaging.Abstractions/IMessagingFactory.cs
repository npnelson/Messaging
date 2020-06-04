namespace NetToolBox.Messaging.Abstractions
{
    public interface IMessagingFactory
    {
        /// <summary>
        /// Will use managedIdentity if entitypath is specified, otherwise, authentication must be included in connectionstring
        /// Note: This convention is not awesome, but managed identity should be used unless running in an environment that doesnt allow for it
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="entityPath">If Null, EntityPath must be specified in the connectionstring</param>
        /// <returns></returns>
        IMessageSender GetSender(string connectionString, string? entityPath);
    }
}
