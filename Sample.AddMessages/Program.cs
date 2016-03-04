using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Threading;

namespace Sample.AddMessages
{
	class Program
	{
		static void Main(string[] args)
		{
			var storageAccount = CloudStorageAccount.Parse("UseDevelopmentStorage=true");
			var queueClient = storageAccount.CreateCloudQueueClient();
			var queue = queueClient.GetQueueReference("sandbox");
			queue.CreateIfNotExists();

			while (true)
			{
				var time = DateTime.Now.ToString("hh:mm:ss.fff");
				var messageContent = $"Hello World at {time}";

				var message = new CloudQueueMessage(messageContent);
				queue.AddMessage(message);

				queue.FetchAttributes();
				int? cachedMessageCount = queue.ApproximateMessageCount;

				Console.WriteLine($"Added: {messageContent}, number of messages in queue: {cachedMessageCount}");

				Thread.Sleep(100);
			}
		}
	}
}
