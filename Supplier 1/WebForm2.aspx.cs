using Supplier_1.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Supplier_1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGridView();
            }
        }

        private void bindGridView()
        {
            DAL.DALinvoice a = new DAL.DALinvoice();
            GridView1.DataSource = a.SelectInvoiceDate();
            GridView1.DataBind();


            //DALinvoice invoice = new DALinvoice();

            //string invoiceid = invoice.invoiceID;
            //string invoicedate = invoice.invoiceDate;
            //string invoicemonth = invoice.InvoiceMonth;
            //string paymentstatus = invoice.paymentStatus;
            //GridView1.DataSource = invoice.SelectInvoiceDate(invoiceid, invoicedate, invoicemonth, paymentstatus);
            //GridView1.DataBind();
            ////get connection string from web.config
            //string strConnectionString =
            //    ConfigurationManager.ConnectionStrings["Supplier"].ConnectionString;
            //SqlConnection myConnect = new SqlConnection(strConnectionString);

            //string strCommandText = "SELECT invoiceDate, InvoiceMonth, paymentStatus, invoiceID FROM Invoice";

            //SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            //myConnect.Open();
            //SqlDataReader reader = cmd.ExecuteReader();

            //DataTable dt = new DataTable();
            //dt.Load(reader);  //** ONLY DATA TABLE CAN USE PAGING

            //reader.Close();
            //myConnect.Close();

            //GridView1.DataSource = dt;
            //GridView1.DataBind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            int invoiceid = int.Parse(row.Cells[0].Text);

            DropDownList ddl = (DropDownList)row.FindControl("DropDownList1");
            string paymentStatus = ddl.SelectedValue;
            DALinvoice invoice = new DALinvoice();
            invoice.updatePaymentStatus(invoiceid, paymentStatus);

        }
    }
}