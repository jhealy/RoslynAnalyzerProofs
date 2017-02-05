using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynProofsConsole
{
    // CS0108
    public abstract class LoggerBase : EventSource, ILogger, IDisposable
    {
        public string Name
        {
            get;
            private set;
        }

        // CA1062
        public string ToValue( Dictionary<string, string> querystring, string key)
        {
            if (querystring.Any(m => m.Key.Equals(key)))
            {
                return querystring[key];
            }
            else
            {
                return string.Empty;
            }
        }

        // CA1806
        public Guid ToGuid(string val)
        {
            Guid value;
            Guid.TryParse(val, out value);
            return value;
        }
    }

    public interface ILogger
    {
    }
}