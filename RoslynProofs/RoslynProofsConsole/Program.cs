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
            // to use the eightball service the eightball service project must be set as a second startup type
            Console.WriteLine(@"[in rod stewart voice] do you think Im sexxy - ");        
            string response = EightBallHelper.AskAQuestion(@"do  you think I'm sexxy");
            if ( String.IsNullOrEmpty(response))
            {
                Console.WriteLine("eightball is having issues");
            }
            else
            {
                Console.WriteLine($"Eightball says {response}");
            }

            //LocalizedData d = new LocalizedData();
            //d.BatteryChargerFailure = "57";
            //d.HighSpeedAlarmMessage = "Failure at 37mbs";
            //Console.WriteLine(d.ToString());

            Console.WriteLine(@"Hit enter to continue");
            Console.ReadLine();
        }
    }
}
