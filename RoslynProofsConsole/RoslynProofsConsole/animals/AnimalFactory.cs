namespace RoslynProofsConsole.animals
{
    public static class AnimalFactory
    {
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
