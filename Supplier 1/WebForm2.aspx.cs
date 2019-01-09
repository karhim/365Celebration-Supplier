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
            if (Page.IsPostBack == false)
            {
                bindGridView();
            }
        }

        private void bindGridView()
        {
            //get connection string from web.config
            string strConnectionString =
                ConfigurationManager.ConnectionStrings["Supplier"].ConnectionString;
            SqlConnection myConnect = new SqlConnection(strConnectionString);

            string strCommandText = "SELECT invoiceDate, InvoiceMonth, paymentStatus, invoiceID FROM Invoice";

            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            myConnect.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);  //** ONLY DATA TABLE CAN USE PAGING

            reader.Close();
            myConnect.Close();

            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
    }
}