Azure Queue Samples
===================

[Windows Azure Storage](https://www.nuget.org/packages/WindowsAzure.Storage/) - required package

[Local Storage Emulator](https://azure.microsoft.com/en-us/documentation/articles/storage-use-emulator/) - may be installed via [Web Platform Installer](https://www.microsoft.com/web/downloads/platform.aspx) by installing **Microsoft Azure SDK for .NET** (latest available at this moment)


Connecting to Queue
-------------------

```csharp
var storageAccount = CloudStorageAccount.Parse("UseDevelopmentStorage=true"); // connection string
var queueClient = storageAccount.CreateCloudQueueClient();
var queue = queueClient.GetQueueReference("sandbox"); // queue name
queue.CreateIfNotExists();
```


Sending messages
----------------

```csharp
queue.AddMessage(new CloudQueueMessage("Hello World!"));
```


Processing messages
-------------------

```csharp
while (true)
{
	var message = queue.GetMessage();
	if (message != null)
	{
		//TODO: process message
		queue.DeleteMessage(message);
	}
	else
	{
		Thread.Sleep(1000);
	}
}
```


Sample projects
---------------

1. **Sample.AddMessages** - will start adding messages to queue
2. **Sample.QueueSize** - to monitor how much messages left in queue
3. **Worker.Code** - common code to process messages
4. **Worker.Console** - console worker
5. **Worker.Service** - example of Windows Service
