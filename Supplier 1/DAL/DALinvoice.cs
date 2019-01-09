using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace Supplier_1.DAL
{
    public class DALinvoice
    {
        private String connectionString = WebConfigurationManager.ConnectionStrings["Supplier"].ConnectionString;
        private string errMsg;

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
        public DataSet SelectInvoiceDate()
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet invoice = new DataSet();

            SqlConnection myConnect = new SqlConnection(connectionString);
            sql = new StringBuilder();
            sql.AppendLine("SELECT invoiceDate, InvoiceMonth, paymentStatus, invoiceID FROM Invoice");

            try
            {
                da = new SqlDataAdapter(sql.ToString(), myConnect);
                da.Fill(invoice);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                myConnect.Close();
            }

            return invoice;
        }
    }
}