using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynProofsConsole
{
    public class StringHelpers
    {
        public string MakeBuffer( Int32 x1 )
        {
            String toAppend = String.Empty;
            for (Int32 index = 0; index < x1; index++)
            {
                toAppend += @".0";
            }
            return toAppend;
        }
        public string MakeBufferBetter(Int32 x1)
        {
            StringBuilder toAppend = new StringBuilder(1024);
            for (Int32 index = 0; index < x1; index++)
            {
                toAppend.Append( @".0" );
            }
            return toAppend.ToString();
        }

        public string LoopAppend( string a, string b, string c, string d )
        {
            // S1643
            String s = String.Empty;
            for ( Int32 ii = 0; ii < 1000; ii++ )
            {
                s += a + b + c + d;
            }
            return s;
        }

        public string LoopAppend2(string a, string b, string c, string d, string e, string f, string g)
        {
            StringBuilder sb = new StringBuilder(1024);
            for (Int32 ii = 0; ii < 1000; ii++)
            {
                sb.Append(a + b + c + d + e + f + g);
            }
            return sb.ToString();
        }

        // spot the problems CA1309
        // hint: this code was supposed to be internationalized
        public int GetDateInfo(DateTime now)
        {
            int dayNumber = 0;
            DateTime dt = now.Date;
            string dayStr = Convert.ToString(dt.DayOfWeek);

            if (dayStr.ToLower() == "sunday")
            {
                dayNumber = 0;
            }
            else if (dayStr.ToLower() == "monday")
            {
                dayNumber = 1;
            }
            else if (dayStr.ToLower() == "tuesday")
            {
                dayNumber = 2;
            }
            else if (dayStr.ToLower() == "wednesday")
            {
                dayNumber = 3;
            }
            else if (dayStr.ToLower() == "thursday")
            {
                dayNumber = 4;
            }
            else if (dayStr.ToLower() == "friday")
            {
                dayNumber = 5;
            }
            else if (dayStr.ToLower() == "saturday")
            {
                dayNumber = 6;
            }
            return dayNumber;
        }

    } // CLASS

} // NAMESPACE
