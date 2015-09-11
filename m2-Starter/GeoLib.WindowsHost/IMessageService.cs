using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.WindowsHost.Contracts
{
    ////namespace moved into the assemblyInfo
    //  [ServiceContract(Namespace = "https://www.pluralsight.com/MiguelCastro/WcfEndToEnd")]
    [ServiceContract]
    public interface IMessageService
    {
        [OperationContract]
        void ShowMessage ( string message );
    }
}
