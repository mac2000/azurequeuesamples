using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Threading;

namespace Worker.Code
{
	public class AzureQueueMessageProcessor : IMessageProcessor
	{
		private int backoff = 0;
		private CloudQueue queue;
		private ILog log;

		public void Process(string message)
		{
			// Emulating heavy weight work here
			Thread.Sleep(new Random(DateTime.Now.Millisecond).Next(100, 1000));
		}

		public void Loop()
		{
			while (true)
			{
				CloudQueueMessage message = queue.GetMessage();
				if (message != null)
				{
					backoff = 0;
					log.Info($" > [retrieved] [{message.Id}] \"{message.AsString}\"");

					try
					{
						Process(message);
						log.Info($" + [processed] [{message.Id}] \"{message.AsString}\"");

						queue.DeleteMessage(message);
						log.Info($" < [aknowledg] [{message.Id}] \"{message.AsString}\"");
					}
					catch (Exception ex)
					{
						log.Error($" ! [error] {ex.Message}");
						throw ex;
					}
				}
				else
				{
					backoff = Math.Min(backoff + 5, 60);
					log.Info($" ~ [sleep] no messages, going to sleep for {backoff} seconds");
					Thread.Sleep(backoff * 1000);
				}
			}
		}

		public AzureQueueMessageProcessor(string connectionString, string queueName, ILog log)
		{
			this.log = log;
			var storageAccount = CloudStorageAccount.Parse(connectionString);
			var queueClient = storageAccount.CreateCloudQueueClient();
			queue = queueClient.GetQueueReference(queueName);
			if (queue.CreateIfNotExists())
			{
				this.log.Info($"{queueName} queue created");
			}

		}

		public void Process(CloudQueueMessage message)
		{
			Process(message.AsString);
		}
	}
}
