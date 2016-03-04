using Worker.Code;

namespace Worker.Console
{
	class ConsoleLogger : ILog
	{
		public void Error(string message)
		{
			System.Console.WriteLine(message);
		}

		public void Info(string message)
		{
			System.Console.WriteLine(message);
		}
	}
}
