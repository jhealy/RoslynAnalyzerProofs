using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynProofsConsole
{
    // SPOT THE PROBLEM CA1814, CA1819
    public class DataPoints
    {
        public Int32[,] Properties { get; set; }
        public String[] AlternateDay { get; set; }

        // SPOT THE PROBLEM CA1819, CA1822, IDE0017
        public Day AddDayDetails(DateTime day)
        {
            Day monthDay = new Day();
            monthDay.Date = day;
            monthDay.DateString = day.ToString("MM-dd-yyyy");
            monthDay.DayOfMonth = day.Day;
            return monthDay;
        }
    }

    public class Day
    {
        public DateTime Date { get; internal set; }
        public string DateString { get; internal set; }
        public int DayOfMonth { get; internal set; }
    }
}
