using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynProofsConsole
{
    public class ItemWithProfile
    {
        public string Name { get; set; }
        public  CanProfile Profilable {get;set;}
    }

    public enum CanProfile
    {
        None=0,
        Yes=1,
        Caution=2,
        DoNotProfile=3
    }

    public class ProfileHelpers
    {
        public bool CanContact( CanProfile profile )
        {
            bool retval = false;
            switch ( profile )
            {
                case CanProfile.DoNotProfile:
                    retval = false;
                    break;
                case CanProfile.Caution:
                    retval = true;
                    break;
                case CanProfile.None:
                    retval = false;
                    break;
                case CanProfile.Yes:
                    retval = true;
                    break;
                default :
                    retval = false;
                    break;
            }
            return retval;
        }

        public bool CheckProfile(ItemWithProfile obj )
        {
            bool retval = false; 
            CanProfile tempProfileID;
            Enum.TryParse<CanProfile>(obj.Profilable.ToString(), out tempProfileID);
            if (tempProfileID != null)
            {
                switch (tempProfileID)
                {
                    case CanProfile.Yes:
                    case CanProfile.Caution:
                        retval = true;
                        break;
                    case CanProfile.None:
                    case CanProfile.DoNotProfile:
                    default:
                        retval = false;
                        break;
                }
            }
            return retval;
        }
        public static bool CheckProfileBetter(ItemWithProfile obj)
        {
            bool retval = false;
            CanProfile tempProfileID;
            bool parseGood = Enum.TryParse<CanProfile>(obj.Profilable.ToString(), out tempProfileID);
            if ( parseGood && (tempProfileID != CanProfile.None))
            {
                switch (tempProfileID)
                {
                    case CanProfile.Yes:
                    case CanProfile.Caution:
                        retval = true;
                        break;
                    case CanProfile.None:
                    case CanProfile.DoNotProfile:
                    default:
                        retval = false;
                        break;
                }
            }
            return retval;
        }

    }
}
