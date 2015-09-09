using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace GeoLib.WebHost
{
    public class CustomHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost ( Type serviceType, Uri[] baseAddresses )
        {
            ServiceHost host = new ServiceHost(serviceType, baseAddresses);

            return host;
        }

    }

}