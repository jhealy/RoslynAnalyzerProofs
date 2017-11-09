using System.Collections.Generic;

namespace RoslynProofsConsole.animals
{
    public static class AnimalFactory
    {
        // spot the error CC0017
        private static string m_WhereSpotted;
        public static string WhereSpotted
        {
            get { return m_WhereSpotted; }
            set { m_WhereSpotted = value; }
        }

        // spot the error CA1002
        // https://msdn.microsoft.com/library/ms182142.aspx
        public static List<Bird> BirdList { get; set; }

        // spot the error CA1008
        public enum CanProfile
        {
            Yes = 11,
            Caution = 27,
            DoNotProfile = 301
        }

        // trips a cc for initializers
        // also trips VS2017 IDE0017
        public static Bird CreateBird( string name, double wingSpan, Classification type )
        {
            Bird turkey = new Bird();
            turkey.Name = "Turkey";
            turkey.WingSpan = 4.7;
            turkey.Type = Classification.Wild;
            return turkey;
        }

        // VS2017 IDE0018 for moving out vars inline
        public static bool DoStuff(string s)
        {
            bool retval;
            int i;
            if ( int.TryParse( s, out i))
            {
                retval = true; 
            }
            else
            {
                retval = false;
            }
            return retval;
        }
    }
}
