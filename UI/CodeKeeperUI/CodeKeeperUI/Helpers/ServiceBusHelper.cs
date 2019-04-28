using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CodeKeeperUI.Helpers
{
    public class ServiceBusHelper
    {
        const string ServiceBusConnectionString = "Endpoint=sb://hackathonsrvbus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Aq0ZO/GcZ6lj7TjF9FmiAy0gWkcYHqni4xNvzQyECxo=";
        const string QueueName = "queue1";
        static IQueueClient queueClient;
        
        public static async Task MainAsync(string messageBody)
        {
            queueClient = new QueueClient(ServiceBusConnectionString, QueueName);
            await SendMessagesAsync(messageBody);
            await queueClient.CloseAsync();
        }

        static async Task SendMessagesAsync(string messageBody)
        {
            var message = new Message(Encoding.UTF8.GetBytes(messageBody));

            // Write the body of the message to the console.
            Console.WriteLine($"Sending message: {messageBody}");

            // Send the message to the queue.
            await queueClient.SendAsync(message);
        }
    }
}
