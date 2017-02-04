using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynProofsConsole
{
    public abstract class LoggerBase : EventSource, ILogger, IDisposable
    {
        public string Name
        {
            get;
            private set;
        }
    }

    public interface ILogger 
    {
    }
}