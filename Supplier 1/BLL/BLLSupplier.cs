using Supplier_1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Supplier_1.BLL
{
    public class BLLSupplier
    {
        public string getAllServices()
        {
            return Supplier_DA.getAllServices();
        }

        public string getServiceNames()
        {
            return Supplier_DA.getServiceNames();
        }

        public string getServiceID(string name)
        {
            return Supplier_DA.getServiceID(name);
        }

        public DataSet SelectInvoiceDate()
        {
            DALinvoice iv = new DALinvoice();
            return iv.SelectInvoiceDate();
        }


    }
}