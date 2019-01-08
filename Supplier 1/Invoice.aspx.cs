using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Supplier_1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Invoice_btn_Click(object sender, EventArgs e)
        {
            if(DropDownList1.SelectedValue == "-1")
            {
                Response.Write("Please Select a date");
            }
            else
            {
            Response.Redirect("InvoiceForm.aspx?data=" + DropDownList1.SelectedValue);
        }

        }
    }
}