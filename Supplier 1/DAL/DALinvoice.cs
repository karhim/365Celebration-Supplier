using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Supplier_1.DAL
{
    public class DALinvoice
    {
        private String connectionString = WebConfigurationManager.ConnectionStrings["Supplier"].ConnectionString;

        public int InsertInvoiceDate(string invoice, string Month)
        {
            int result = 0;

            SqlConnection myConnection = new SqlConnection(connectionString);
            string query = "INSERT INTO Invoice(invoiceDate, InvoiceMonth, paymentStatus) VALUES(@InvoiceDate, @invoiceMonth, @paymentStatus)";
            SqlCommand myCommand = new SqlCommand(query, myConnection);
            myCommand.Parameters.AddWithValue("@InvoiceDate", invoice);
            myCommand.Parameters.AddWithValue("@invoiceMonth", Month);
            myCommand.Parameters.AddWithValue("@paymentStatus", 0);
            myConnection.Open();

            // ... other parameters

            result = myCommand.ExecuteNonQuery();
            myConnection.Close();

            return result;
        }
    }
}