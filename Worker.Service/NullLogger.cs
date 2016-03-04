using Worker.Code;

namespace Worker.Service
{
	public class NullLogger : ILog
	{
		public void Error(string message)
		{

		}

		public void Info(string message)
		{

		}
	}
}
