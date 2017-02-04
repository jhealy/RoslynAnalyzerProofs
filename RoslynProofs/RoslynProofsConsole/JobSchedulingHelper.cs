using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynProofsConsole
{
    public class JobSchedulingHelper
    {
        public static string ApplicationVersion;
        public static Dictionary<int, string> CommModels;

        public Int32 JobDayHelper()
        {
            Int32 rc;
            DateTime schedTime = DateTime.Now;
            rc = schedTime.Day;
            return rc;
        }
    }
}