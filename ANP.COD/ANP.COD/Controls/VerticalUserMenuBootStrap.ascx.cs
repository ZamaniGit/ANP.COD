using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANP.Bussiness.Objects;
using ANP.Bussiness.Models;
using System.Data;

namespace ANP.COD.Controls
{
    public partial class VerticalUserMenuBootStrap : System.Web.UI.UserControl
    {
        LoginDetails UserInfo = new LoginDetails();
        public string strCreateMenu { get; set; }
        string AddressDefult = HttpContext.Current.Request.Url.AbsolutePath + "?action=";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UserValidate();
                if (IsPostBack == false)
                {
                    strCreateMenu = string.Empty;
                    GetMenuData();
                }
            }
            catch { }
        }
        private void UserValidate()
        {
            if (null != Session["UserInfo"])
                UserInfo = Session["UserInfo"] as LoginDetails;
            else
                Response.Redirect("~/Login.aspx", true);
        }

        private void GetMenuData()
        {
            string permission = "";
            switch (UserInfo.RoleID)
            {
                case 1000: permission = "Z"; break;
                case 1001: permission = "A"; break;
                case 1002: permission = "B"; break;
                case 1003: permission = "C"; break;
                case 1004: permission = "D"; break;
                case 1005: permission = "E"; break;
                case 1006: permission = "F"; break;
                case 1007: permission = "G"; break;
                case 1008: permission = "H"; break;
            }
            DefultInfo baseClass = new DefultInfo();
            DataTable table = baseClass.ReturnUserMenu(permission, UserInfo.ID);

            DataView view = new DataView(table);
            view.RowFilter = "ParentID=0";
            view.Sort = "Ordering";
            strCreateMenu = "";
            strCreateMenu = string.Format(
                 @"<div class=""panel-group"" id=""accordion fa"">
                        <div class=""panel panel-default "">");
            foreach (DataRowView row in view)
            {
                if (Convert.ToInt32(row["ChildCount"].ToString()) > 0)
                {
                    strCreateMenu += string.Format(@"
                        <div class=""panel-heading ""  style=""margin : 5px;"">
                            <a class=""accordion-toggle collapsed "" data-toggle=""collapse"" data-parent=""#accordion"" href=""#{0}""><h1 class=""panel-title "">{1} </h1></a>
                        </div>
                        <div id=""{0}"" class=""collapse panel-collapse fade"">
                            <div class=""panel-body"">
                                <table class=""table""> ", row["id"].ToString(), row["menuTitle"].ToString());
                    AddChildItems(table, row);
                    strCreateMenu += string.Format(@" </table> </div> </div>");
                }
                else
                {
                    strCreateMenu +=string.Format(@"  
                            <div class=""panel-heading "" style=""margin : 5px;"">
                                <a href=""" + AddressDefult + @"{0}""><h1 class=""panel-title"">{1} </h1></a>
                            </div>", row["uID"].ToString(), row["menuTitle"].ToString());
                }
            }
            strCreateMenu += " </div> </div>";
        //    strCreateMenu += " </div> ";
            lblV_Menu.Text = strCreateMenu;
        }

        private void AddChildItems(DataTable table, DataRowView row)
        {
            DataView viewItem = new DataView(table);

            viewItem.RowFilter = "ParentID=" + row["id"].ToString();
            viewItem.Sort = "Ordering";
            foreach (DataRowView childView in viewItem)
            {
                strCreateMenu += string.Format(@"
                    <tr>
                        <td style=""border-bottom-width:1px; border-top-width:0px; border-bottom-style:solid"">
                            <a href=""" + AddressDefult + @"{0}""><h6 class=""panel-title "">{1} </h6></a>
                        </td>
                    </tr> ", childView["uID"].ToString(), childView["menuTitle"].ToString());
            }
        }
    }
}