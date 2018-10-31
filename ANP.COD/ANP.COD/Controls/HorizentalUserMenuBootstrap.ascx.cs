using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ANP.Bussiness;
using ANP.Common;
using ANP.Bussiness.Models;
using ANP.Bussiness.Objects;

namespace ANP.COD.Controls
{
    public partial class HorizentalUserMenuBootstrap : System.Web.UI.UserControl
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
            //menuBar.Items.Clear();
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
            view.Sort = "Ordering ";
            strCreateMenu = "";
            strCreateMenu = string.Format(
                 @"<div class=""navbar-inner-sm "">
                                <div class=""container-fluid fa"">
                                    <nav class=""collapse navbar-collapse"" role=""navigation"">
                                        <ul class=""nav navbar-nav"">");
            foreach (DataRowView row in view)
            {
                if (Convert.ToInt32(row["ChildCount"].ToString()) > 0)
                {
                    strCreateMenu += string.Format(@"
                        <li class=""dropdown"" style=""width:115px; text-align:center;"">
                            <a href=""#"" class=""dropdown-toggle"" data-toggle=""dropdown"" role=""button"" aria-haspopup=""true"" aria-expanded=""false""> {0} <b class=""caret""></b></a>
                                <ul class=""dropdown-menu"">", row["menuTitle"].ToString());
                    AddChildItems(table, row);
                }
                else
                {
                    strCreateMenu += string.Format(@"
                        <li style="" direction:rtl; text-align:center; width:110px;"">
                            <a  href=""" + AddressDefult + @"{0}"">{1}</a></li>", row["uID"].ToString(), row["menuTitle"].ToString());
                }
            }
            strCreateMenu += " </ul> </nav> </div> </div>";
            lblMenu.Text = strCreateMenu;
        }

        private void AddChildItems(DataTable table, DataRowView row)
        {
            DataView viewItem = new DataView(table);

            viewItem.RowFilter = "ParentID=" + row["id"].ToString();
            viewItem.Sort = "Ordering";
            foreach (DataRowView childView in viewItem)
            {
                strCreateMenu += string.Format(@"
                    <li class=""LiMenu"" ><a  href=""" + AddressDefult + @"{0}"">{1}</a></li>"
                    , childView["uID"].ToString()
                    , childView["menuTitle"].ToString());
            }
            strCreateMenu += "</ul> </li>";
        }
    }
}