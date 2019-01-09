using Supplier_1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;

namespace Supplier_1
{
    
    [ServiceContract]
    public interface IWsServiceCatalog
    {

        [OperationContract]
        string getAllServices();

        [OperationContract]
        string getServiceNames();

        [OperationContract]
        string getServiceID(string name);

        [OperationContract]
        DataSet SelectInvoiceDate();
    }
}
