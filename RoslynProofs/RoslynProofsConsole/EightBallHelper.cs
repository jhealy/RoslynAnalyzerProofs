using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoslynProofsConsole.DevfishServices;
using System.ServiceModel;

namespace RoslynProofsConsole
{
    public static class EightBallHelper
    {
        // spot the problem
        // note final solution  does not get picked up by roslyn analyzers
        // http://msdn.microsoft.com/en-us/library/aa355056.aspx
        // TODO write a roslyn analyzer for this

        // CA2000
        public static string AskAQuestionBad( string question )
        {
            string result;
            EightBallServiceClient client = new EightBallServiceClient();
            result = client.AskQuestion(question);
            client.Close();
            return result;
        }

        // PFE Code Review Tool pickup
        public static string AskAQuestion( string question )
        {
            using ( EightBallServiceClient client = new EightBallServiceClient() )
            {
                return client.AskQuestion(question);
            }
        }

        // gtg
        public static string AskAQuestionProperly(string question)
        {
            string result = string.Empty;
            try
            {
                EightBallServiceClient client = new EightBallServiceClient();
                result = client.AskQuestion(question);
                client.Close();
            }
            catch ( CommunicationException )
            {
                string msg = $"CommunicationException in {System.Reflection.MethodBase.GetCurrentMethod()}";
                System.Diagnostics.Debug.WriteLine(msg);
            }
            catch ( TimeoutException )
            {
                string msg = $"TimeoutException in {System.Reflection.MethodBase.GetCurrentMethod()}";
                System.Diagnostics.Debug.WriteLine(msg);
            }
            catch ( Exception e )
            {
                string msg = $"Exception in {System.Reflection.MethodBase.GetCurrentMethod()} Exception details: {e.ToString()}";
                System.Diagnostics.Debug.WriteLine(msg);
                throw;
            }
            return result;
        }
    }
}
