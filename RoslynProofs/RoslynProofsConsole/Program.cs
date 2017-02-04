using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynProofsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            LocalizedData d = new LocalizedData();
            d.BatteryChargerFailure = "57";
            d.HighSpeedAlarmMessage = "Failure at 37mbs";
            Console.WriteLine(d.ToString());

            Console.WriteLine(@"Hit enter to continue");
            Console.ReadLine();
        }
    }
}
