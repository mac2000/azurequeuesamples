using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker.Code;

namespace Worker.Service
{
	class EventLogAdapter : ILog
	{
		EventLog eventLog;

		public EventLogAdapter(EventLog eventLog)
		{
			this.eventLog = eventLog;
		}

		public void Error(string message)
		{
			eventLog.WriteEntry(message, EventLogEntryType.Error);
		}

		public void Info(string message)
		{
			eventLog.WriteEntry(message, EventLogEntryType.Information);
		}
	}
}
