using Supplier_1.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Supplier_1
{
    public partial class InvoiceForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGridView();
            }

            lbl_invoicedate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lbl_billing.Text = "365Celebration";
            lbl_invMonth.Text = Request.QueryString["data"];
        }
        private void bindGridView()
        {
            DAL.DALinvoice a = new DAL.DALinvoice();
            gv_invoice.DataSource = a.SelectInvoiceDetails();
            gv_invoice.DataBind();
        }
        protected void btn_close_Click(object sender, EventArgs e)
        {

            DALinvoice invoice = new DALinvoice();
            int result = 0;
            result = invoice.InsertInvoiceDate(lbl_invoicedate.Text, lbl_invMonth.Text);

            Response.Redirect("WebForm2.aspx");
        }

       
        }
}