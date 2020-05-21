﻿using NetToolBox.Messaging.AzureServiceBus;
using System;
using System.Threading.Tasks;

namespace NetToolBox.Messaging.TestHarness
{
    class Program
    {
        static async Task Main(string[] args)
        {


            var factory = new AzureMessagingFactory();
            var sender = factory.GetSender("Endpoint=sb://medonehp.servicebus.windows.net;Authentication=ManagedIdentity", "hl7messages-test");
            await sender.SendAsync("test message");
            Console.WriteLine("Message Sent");
            Console.ReadLine();

        }
    }
}
