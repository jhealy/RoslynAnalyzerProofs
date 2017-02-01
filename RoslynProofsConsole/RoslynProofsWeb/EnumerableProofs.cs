using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RoslynProofsConsole
{
    public class EnumerableProofs
    {
        public EnumerableProofs() { }
        public CultureInfo GetCultureInfo( HttpRequest request )
        {
            string[] languages = request.UserLanguages;
            CultureInfo cultureInfo;

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

        public static CultureInfo GetCultureInfoBetter(HttpRequest request)
        {
#pragma warning disable CC0001 // You should use 'var' whenever possible.
            string[] languages = request.UserLanguages;
#pragma warning restore CC0001 // You should use 'var' whenever possible.

            CultureInfo cultureInfo = CultureInfo.InstalledUICulture;

            if (languages.Any())
            {
                try
                {
                    cultureInfo = new CultureInfo(languages[0]);
                }
                catch ( Exception ex )
                {
                    System.Diagnostics.Debug.WriteLine( $"CultureInfo not found for {languages[0]}");
                }
            }

            return cultureInfo;
        }

        // singleton
        private static CultureInfo m_CultureInfo = null;       
        public  static CultureInfo GetCultureInfoBest(HttpRequest request)
        {
            if ( m_CultureInfo != null )
            {
                return m_CultureInfo;
            }

#pragma warning disable CC0001 // You should use 'var' whenever possible.
            string[] languages = request.UserLanguages;
#pragma warning restore CC0001 // You should use 'var' whenever possible.

            CultureInfo cultureInfo = CultureInfo.InstalledUICulture;

            if (languages.Any())
            {
                try
                {
                    cultureInfo = new CultureInfo(languages[0]);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"CultureInfo not found for {languages[0]}");
                }
            }

            m_CultureInfo = cultureInfo;

            return m_CultureInfo;
        }
    }
}
