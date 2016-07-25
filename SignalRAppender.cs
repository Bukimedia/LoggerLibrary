using log4net.Appender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Core;
using Microsoft.AspNet.SignalR.Client;

namespace Bukimedia.LoggerLibrary
{
    class SignalRAppender : BufferingAppenderSkeleton
    {
        public IHubProxy Hub { get; set; }

        private DateTime lastFlushTime = DateTime.Now;

        protected override void Append(LoggingEvent loggingEvent)
        {
            base.Append(loggingEvent);
            if (lastFlushTime.AddSeconds(5) < DateTime.Now)
            {
                lastFlushTime = DateTime.Now;
                Flush();
            }
        }

        protected override void SendBuffer(LoggingEvent[] events)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (var ev in events )
            {
                sb.AppendLine(ev.MessageObject.ToString());
            }
            this.Hub.Invoke("ClientMessage", sb.ToString());
        }
    }
}
