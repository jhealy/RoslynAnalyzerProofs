using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RoslynProofsConsole
{
    public class ResourceHelpers
    {

        // spot the problem
        // ca1010 - https://msdn.microsoft.com/library/ms182132.aspx
        public class DBResourceSet : ResourceSet
        {
            public DBResourceSet(CultureInfo culture) :
                base(new CustomResourceReader(culture))
            {
                // intentionally left blank
            }
            //Return custom reader as default one for reading language resources 
            public override Type GetDefaultReader()
            {
                return typeof(CustomResourceReader);
            }
        }



        public sealed class CustomResourceReader : IResourceReader
        {
            private IDictionary _resources;
            private static IContainer serviceContainer = null;
            IDBResourceManager manager;

            public CustomResourceReader(CultureInfo Culture)
            {
                // intentionally blank
            }

            public static void SetContainer(IContainer container)
            {
                serviceContainer = container;
            }

            IDictionaryEnumerator IResourceReader.GetEnumerator()
            {
                return _resources.GetEnumerator();
            }

            void IResourceReader.Close() { }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return _resources.GetEnumerator();
            }

            // SPOT THE ERROR CA1063
            void IDisposable.Dispose() { return; }
        }
        [ServiceContract(Namespace = "http://www.nextgen.com/PatientPortal")]
        public interface IDBResourceManager : IService
        {
            [OperationContract]
            DBResourceString[] GetAllResourcesForView(string culture, string viewName);
        }

        public class DBResourceString
        {
            string ID { get; set; }
        }

        [ServiceContract(Namespace = "http://www.devfish.net")]
        public interface IService
        {
            [OperationContract(IsOneWay = true)]
            void Dispose();
        }
    }
}
