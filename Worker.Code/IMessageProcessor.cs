namespace Worker.Code
{
	public interface IMessageProcessor
	{
		void Process(string message);
		void Loop();
	}
}
