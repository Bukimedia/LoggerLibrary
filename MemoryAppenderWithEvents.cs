using log4net.Appender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukimedia.LoggerLibrary
{

    public class MemoryAppenderWithEvents : MemoryAppender
    {
        public event EventHandler Updated;

        protected override void Append(log4net.Core.LoggingEvent loggingEvent)
        {
            // Append the event as usual
            base.Append(loggingEvent);

            // Then alert the Updated event that an event has occurred
            var handler = Updated;
            if (handler != null)
            {
                handler(this, new MessageEventArgs(loggingEvent.MessageObject.ToString()));
            }
        }
    }
    
    public class MessageEventArgs : EventArgs
    {
        public string Message { get; set; }

        public MessageEventArgs(string message)
        {
            this.Message = message;
        }
    }
}
