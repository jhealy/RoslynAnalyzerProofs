using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynProofsConsole
{
    public class DBUtils
    {
        public bool CheckStuff()
        {
            string cmd = "cmd nothing here";
            int objDataReader = -1;

            try
            {
                
                int.TryParse(this.GetParameterValue(cmd, "@Presult").ToString(), out objDataReader);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (objDataReader > 0)
                return true;
            else
                return false;

        }

        // CA2200
        public bool CheckStuffJustABitOff()
        {
            try
            {
                string cmd = @"cmd nothing here";
                Int32 objDataReader = -1;
                bool okParsed = int.TryParse(this.GetParameterValue(cmd, "@Presult").ToString(), out objDataReader);
                return (okParsed && (objDataReader != -1));
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }


        public bool CheckStuffBetter()
        {
            string cmd = "cmd nothing here";
            Int32 objDataReader = -1;
            bool okParsed = int.TryParse(this.GetParameterValue(cmd, "@Presult").ToString(), out objDataReader);
            return (okParsed && (objDataReader != -1));
        }

        private object GetParameterValue(string cmd, string v)
        {
            throw new NotImplementedException();
        }

        public static string FormatEffectiveDates(string date)
        {
            if (!string.IsNullOrWhiteSpace(date))
            {
                try
                {
                    int index = date.LastIndexOf('-');
                    if ((date.Length - index) < 4)
                    {
                        date = string.Format("{0}", ControllerUtility.ParseDate(date.Substring(0, index).Trim()));
                    }
                    else
                    {
                        int index2 = date.IndexOf(" - ");
                        date = string.Format("{0} - {1}", ControllerUtility.ParseDate(date.Substring(0, index2)), ControllerUtility.ParseDate(date.Substring(index2 + 3)));
                    }
                }
                catch (Exception)
                {
                }
            }
            return date;
        }
    }

    internal class ControllerUtility
    {
        internal static object ParseDate(string v)
        {
            throw new NotImplementedException();
        }
    }
}
