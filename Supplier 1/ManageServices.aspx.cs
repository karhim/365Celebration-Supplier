using Supplier_1.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Supplier_1
{
    public partial class ManageServices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_add_Click(object sender, EventArgs e)
        {


            int servicetype = 0, vendorID = 0, result = 0;

            if (ddl_ServiceType.SelectedIndex > 0)
            {
                servicetype = int.Parse(ddl_ServiceType.SelectedItem.Value);
            }
            if (Page.IsValid)
            {
                Service serv = new Service(servicetype, vendorID, tb_servName.Text, tb_shortDesc.Text, tb_servDesc.Text, int.Parse(tb_quantity.Text), decimal.Parse(tb_price.Text), "0");
                result = serv.ServiceInsert(vendorID);

                lbl_msg.Visible = true;
                if (result > 0)
                {
                    foreach (HttpPostedFile postedFile in fileupload_photo.PostedFiles)
                    {
                        string fileName = Path.GetFileName(postedFile.FileName);
                        postedFile.SaveAs(Server.MapPath("~/img/") + fileName);
                        serv = new Service(fileName);
                        serv.ServiceImageInsert();
                    }

                    lbl_msg.Text = "Product Insert Successful";
                    InputValidation.ClearInputs(this.Controls);
                    ddl_ServiceType.SelectedIndex = 0;
                }
                else
                {
                    lbl_msg.Text = "Product Insert NOT Successful";

                }
            }
        }
    }
}