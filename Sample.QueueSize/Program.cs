using Microsoft.WindowsAzure.Storage;
using System;
using System.Threading;

namespace Sample.QueueSize
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
				queue.FetchAttributes();
				int? cachedMessageCount = queue.ApproximateMessageCount;

				Console.WriteLine($"{cachedMessageCount} messages left");

				Thread.Sleep(500);
			}
		}
	}
}
