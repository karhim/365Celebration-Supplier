using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using Supplier_1.DAL;

namespace Supplier_1
{
    public class WsServiceCatalog : IWsServiceCatalog
    {
        public string getAllServices()
        {
            Supplier_1.BLL.BLLSupplier a;

            a = new Supplier_1.BLL.BLLSupplier();
            return a.getAllServices();
        }

        public string getServiceNames()
        {
            Supplier_1.BLL.BLLSupplier a;

            a = new Supplier_1.BLL.BLLSupplier();
            return a.getServiceNames();

        }

        public string getServiceID(string name)
        {
            Supplier_1.BLL.BLLSupplier a;
            a = new Supplier_1.BLL.BLLSupplier();

            return a.getServiceID(name);
        }
    }
}