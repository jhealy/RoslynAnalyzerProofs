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
    }
}
