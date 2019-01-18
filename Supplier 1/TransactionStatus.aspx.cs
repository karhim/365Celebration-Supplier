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
    public partial class TransactionStatus : System.Web.UI.Page
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



        //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GridViewRow row = GridView1.SelectedRow;
        //    int invoiceid = int.Parse(row.Cells[0].Text);

        //    TextBox tb = (TextBox)row.FindControl("Textbox2");
        //    string paymentStatus = tb.Text;
        //    DALinvoice invoice = new DALinvoice();
        //    invoice.updatePaymentStatus(invoiceid, paymentStatus);

        //}

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bindGridView();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bindGridView();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {


            GridViewRow row = GridView1.Rows[e.RowIndex];
            int invoiceid = int.Parse(row.Cells[0].Text);

            DropDownList dd = (DropDownList)row.FindControl("DropDownList1");
            string paymentStatus = dd.SelectedValue;
            DALinvoice invoice = new DALinvoice();
            invoice.updatePaymentStatus(invoiceid, paymentStatus);
            GridView1.EditIndex = -1;
            bindGridView();
        }

        //private void updateGridviewRecord(int invoiceid, string paymentStatus)
        //{
        //    string strConnectionString = ConfigurationManager.ConnectionStrings["Supplier"].ConnectionString;
        //    SqlConnection myConnect = new SqlConnection(strConnectionString);

        //    string strCommandText = "UPDATE Invoice SET paymentStatus=@paymentStatus WHERE invoiceID=@invoiceid";

        //    SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
        //    cmd.Parameters.AddWithValue("@invoiceid", invoiceid);
        //    cmd.Parameters.AddWithValue("@paymentStatus", paymentStatus);

        //    myConnect.Open();
        //    int result = cmd.ExecuteNonQuery();

        //    myConnect.Close();

        //    //Cancel Edit mode
        //    GridView1.EditIndex = -1;
        //    bindGridView();

        //}

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int i = 0;
            GridViewRow therow = e.Row;
            DropDownList thedd = (DropDownList)therow.Cells[3].FindControl("DropDownList1");

//            if (e.Row.RowState == DataControlRowState.Edit)
                if (thedd != null)
                {
                TextBox thetb = (TextBox)therow.Cells[3].FindControl("TextBox1");
                string currentstatus = thetb.Text;
                thedd = (DropDownList)therow.Cells[3].FindControl("DropDownList1");
                thedd.SelectedValue = currentstatus;

            }

        }
    }
}