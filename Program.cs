using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using System;
using System.Diagnostics.Tracing;
using System.Text;

namespace EventHubPublisher // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var client = new EventHubProducerClient("Endpoint=sb://maineventhubnamespace.servicebus.windows.net/;SharedAccessKeyName=actualeventhubpolicyconnection;SharedAccessKey=HZuP78eCBqjacbSra1lTEaQj0YkBs3YY7+AEhIEVRCM=;EntityPath=actualeventhub");//give eventhubnamespace or evemt hub Shared key
            EventDataBatch batch = await client.CreateBatchAsync();
            batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Message 1 from console app")));
            batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Message 2 from console app")));
            batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Message 3 from console app")));
            batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Message 4 from console app")));

            await client.SendAsync(batch);
            Console.WriteLine("Event messgs published successfully.");
            Console.ReadKey();
        }
    }
}