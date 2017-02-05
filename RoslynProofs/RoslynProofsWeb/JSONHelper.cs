using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace RoslynProofsWeb
{
    public class JSONHelper
    {
        public static void WriteStringToOutput( string value )
        {
            using (StreamWriter streamWriter = new System.IO.StreamWriter(@"out.txt"))
            {
                string json = new JavaScriptSerializer().Serialize(value);
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }
    }
}