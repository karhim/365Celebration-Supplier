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
            myCommand.Parameters.AddWithValue("@paymentStatus", "waiting");
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
            sql.AppendLine("SELECT  invoiceDate, InvoiceMonth, paymentStatus, invoiceID FROM Invoice");

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

        public int updatePaymentStatus(int invoiceid, string paymentstatus)
        {
            int result = 0;
            SqlConnection con = new SqlConnection(connectionString);
            string queryStr = "UPDATE Invoice SET paymentStatus = @paymentstatus WHERE invoiceID = @invoiceid";
            SqlCommand cmd = new SqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue("@paymentstatus", paymentstatus);
            cmd.Parameters.AddWithValue("@invoiceid", invoiceid);
            con.Open();
            result += cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public DataSet SelectInvoiceDetails()
        {
            StringBuilder sql;
            SqlDataAdapter da;
            DataSet invoice = new DataSet();

            SqlConnection myConnect = new SqlConnection(connectionString);
            sql = new StringBuilder();
            sql.AppendLine("SELECT startDate, aID, finalPrice FROM Appointment");

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