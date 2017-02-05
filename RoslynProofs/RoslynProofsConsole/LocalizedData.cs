using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynProofsConsole
{
    public class LocalizedData
    {
        public string Test;
        public string NoparsingMethodAvailable;
        public string NoOrInvalidDataPassed;
        public string NotificationMessage;
        public string HighSpeedNotificationMessage;
        public string BatteryChargerFailure;
        public string SecondaryCommunicationPathFailure;
        public string NetworkAlertMessageReferEMail;
        public string HighSpeedAlarmMessage;
        public string Data;
        public string DeviceType { get; protected set; }
        public string ZoneDescriptor1 { get; protected set; }
        public string Name { get; protected set; }

        public string ConvertNewLine( string inputString)
        {
            string value = inputString;
            //Fix for CustomerIssue-1117
            //CA1309
            if (string.Equals(this.Name, @"Notes", StringComparison.InvariantCultureIgnoreCase))
            {
                value = value.Replace( "&#10;" , System.Environment.NewLine);
            }
            return value;
        }
        public string ConvertNewLineBetter(string inputString)
        {
            string value = inputString;
            //Fix for CustomerIssue-1117
            if (string.Equals(this.Name, @"Notes", StringComparison.OrdinalIgnoreCase))
            {
                value = value.Replace("&#10;", System.Environment.NewLine);
            }
            return value;
        }

        public void AdjustZoneDescriptor()
        {
            // example #1
            if (this.ZoneDescriptor1 != null && this.ZoneDescriptor1 != "0" && this.ZoneDescriptor1 != "")
            {
                this.ZoneDescriptor1 = this.ZoneDescriptor1.Trim(new char[]
                   { '~' });
            }
        }
        public void AdjustZoneDescriptorBetter()
        {
            // example #1
            if ( String.IsNullOrEmpty(this.ZoneDescriptor1) && this.ZoneDescriptor1 != "0" )
            {
                this.ZoneDescriptor1 = this.ZoneDescriptor1.Trim(new char [] { '~' });
            }
        }

        public void AdjustSuperVisionLevel()
        {
            try
            {
                if (DeviceType == "876" || DeviceType == "864")
                {
                    Data = "PT" + Data.Substring(0, Data.IndexOf("m") - 1) + "M";
                }
                else
                {
                    Data = "PT" + Data.Substring(0, Data.IndexOf("h") - 1) + "H";
                }
            }
            catch
            {}
        }

        // spot the problem 
        // ca1031 but bigger
        public DateTime DateParsePlay(string msg)
        {
            DateTime retval;
            try
            {
                retval = DateTime.Parse(msg);
            }
            catch
            {
                retval = DateTime.Now;
            }
            return retval;
        }
        public DateTime DateParsePlayBetter(string msg)
        {
            DateTime result;
            if (DateTime.TryParse(msg, out result ) == false )
            {
                result = DateTime.UtcNow;
            }
            return result;
        }

        // SPOT THE PROBLEM - CA1721
        public class PlanOfCareModel
        {
            public string Date { get; set; }

            public string Type { get; set; }

            public string Action { get; set; }

            public string Status { get; set; }
        }
    }
}
