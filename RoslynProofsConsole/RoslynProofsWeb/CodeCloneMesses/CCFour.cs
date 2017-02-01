using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoslynProofsWeb.CodeCloneMesses
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Web;

    namespace RoslynProofsWeb.CodeCloneMesses
    {
        // jhealy: we know there are big issues with the code below below.  its intentional.
        public class CCFour
        {
            string m_Msg;
            public CCFour()
            {
                m_Msg = "I am ccfour hear me roar."
            }
            public static void SpecialMethodForCCFour()
            {
                System.Diagnostics.Debug.WriteLine("i am in cc four");
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
}