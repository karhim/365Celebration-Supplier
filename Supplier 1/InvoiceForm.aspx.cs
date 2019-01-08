using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Supplier_1
{
    public partial class InvoiceForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_invoicedate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lbl_billing.Text = "365Celebration";
            lbl_invMonth.Text = Request.QueryString["data"]; 
        }
    }
}