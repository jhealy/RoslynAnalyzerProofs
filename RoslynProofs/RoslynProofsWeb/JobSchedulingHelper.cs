using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynProofsWeb
{
    public class JobSchedulingHelper
    {
        public Int32 JobDayHelper()
        {
            Int32 rc;
            DateTime schedTime = DateTime.Now;
            rc = schedTime.Day;
            return rc;
        }
    }
}