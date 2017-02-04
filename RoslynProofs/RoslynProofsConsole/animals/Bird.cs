using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynProofsConsole.animals
{
    public class Bird
    {
        private const string NAME_UNKNOWN = @"<UNKNOWN/>";
        public string Name { get; set; }
        public double WingSpan { get; set; }
        public Classification Type { get; set; }
        public Bird()
        {
            this.Name = NAME_UNKNOWN;
            this.WingSpan = 0.0;
            this.Type = Classification.None;
        }

        // VS2017 IDE0016 simplify null checks
        public Bird( string name )
        {
            if ( name==null )
            {
                throw new ArgumentNullException(nameof(name));
            }
            this.Name = name;
            this.WingSpan = 0.0;
            this.Type = Classification.None;
        }
    }
}
