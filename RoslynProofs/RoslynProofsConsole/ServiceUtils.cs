using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynProofsConsole
{
    class ServiceUtils
    {
        // spot the error - CA1024 in vs2015, doesn't show up in vs2017
        // TODO ask the experts fodder
        protected virtual IDictionary<string, object> GetExtraValidationParameters()
        {
            return new Dictionary<string, object>();
        }
    }

    public class JSONPSupportBehaviorAttribute2
    {

        void AddBindingParameters()
        { }
        void Validate()
        { }

    }

    [AttributeUsage(AttributeTargets.Class)]
    public class JSONPSupportBehaviorAttribute : Attribute, IServiceBehavior
    {
        void IServiceBehavior.AddBindingParameters(
             ServiceDescription serviceDescription, ServiceHostBase serviceHostBase,
             System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints,
             BindingParameterCollection bindingParameters)
        { }
        void IServiceBehavior.ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { }
        void IServiceBehavior.Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { }
    }

    #region "MOCKSTUBS"

    internal class BindingParameterCollection
    {
    }

    internal class ServiceEndpoint
    {
    }

    internal class ServiceHostBase
    {
    }

    internal class ServiceDescription
    {
    }

    internal interface IServiceBehavior
    {
        void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters);
        void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase);
        void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase);
    }
    #endregion
}