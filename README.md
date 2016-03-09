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
