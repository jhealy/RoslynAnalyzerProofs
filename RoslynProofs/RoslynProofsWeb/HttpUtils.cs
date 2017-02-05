using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace RoslynProofsWeb
{
    public class HttpUtils
    {
        // TODO Write ROSLYN analyzer for http using issue
        public async Task<string> GetWebPageContent ( Uri uri )
        {
            string retVal;
            // httpclient has idisposable. we want it to clean up when done
            using (HttpClient cli = new HttpClient())
            {
                // force a timeout exception
                // cli.Timeout = new TimeSpan(1);
                try
                {
                    retVal = await cli.GetStringAsync(uri);
                }
                catch (Exception _ex)
                {
                    System.Diagnostics.Debug.WriteLine(@"dangit", @"Exception thrown, look in results for more info.", @"Understood");
                    System.Diagnostics.Debug.WriteLine(_ex.ToString());
                    if (_ex.InnerException != null)
                    {
                        System.Diagnostics.Debug.WriteLine(_ex.InnerException.ToString());
                    }
                    retVal = string.Empty;
                }
            }
            return retVal;
        }
    }
}
