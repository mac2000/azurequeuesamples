using Worker.Code;

namespace Worker.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			var worker = new AzureQueueMessageProcessor("UseDevelopmentStorage=true", "sandbox", new ConsoleLogger());

			worker.Loop();
		}
	}
}
