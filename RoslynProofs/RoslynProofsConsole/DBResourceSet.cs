using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using static RoslynProofsConsole.ResourceHelpers;

namespace RoslynProofsConsole
{
    // CA2000 - WHICH ISN'T TRIPPING HERE, WTH
    public class DBResourceSet : ResourceSet
    {
        public DBResourceSet(CultureInfo Culture) :
            base(new CustomResourceReader(Culture))
        { }
        //Return custom reader as default one for reading language resources 
        public override Type GetDefaultReader()
        {
            return typeof(CustomResourceReader);
        }
    }
}
