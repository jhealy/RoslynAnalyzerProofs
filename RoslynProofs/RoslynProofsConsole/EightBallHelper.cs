using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoslynProofsConsole.DevfishServices;

namespace RoslynProofsConsole
{
    public static class EightBallHelper
    {
        public static string AskAQuestion( string question )
        {
            using ( EightBallServiceClient client = new EightBallServiceClient() )
            {
                return client.AskQuestion(question);
            }
        }
    }
}
