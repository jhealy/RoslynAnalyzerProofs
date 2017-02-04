using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;

namespace RoslynProofsWeb.CodeCloneMesses
{
    // jhealy: we know there are big issues with the code below below.  its intentional.
    public class CCTwo
    {
        public Int32 AddNumbers( Int32 a, Int32 b)
        {
            return a + b;
        }
        public CultureInfo GetCultureInfo(HttpRequest request)
        {
            CultureInfo cultureInfo;
            string[] languages = request.UserLanguages;
            if (languages.Count() > 0)
            {
                try
                {
                    cultureInfo = new CultureInfo(languages[0]);
                }
                catch (CultureNotFoundException)
                {
                    cultureInfo = CultureInfo.InvariantCulture;
                }
            }
            else
                cultureInfo = CultureInfo.InvariantCulture;

            return cultureInfo;
        }
    }
}