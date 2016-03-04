using System.ServiceProcess;
using System.Threading;
using Worker.Code;

namespace Worker.Service
{
	public partial class WorkerService : ServiceBase
	{
		public WorkerService()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			var worker = new Thread(DoWork);
			worker.Name = ServiceName;
			worker.IsBackground = false;
			worker.Start();
		}

		protected void DoWork()
		{
			//var log = new NullLogger();
			var log = new EventLogAdapter(eventLog);

			var worker = new AzureQueueMessageProcessor("UseDevelopmentStorage=true", "sandbox", log);
			worker.Loop();
		}

		protected override void OnStop()
		{
		}
	}

}
