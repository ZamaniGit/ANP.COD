using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ANP.COD.Controls
{
    public partial class AlertControl : System.Web.UI.UserControl
    {
        public string Header { get; set; }
        public string Message { get; set; }
        public enum AlertTypes
        {

            success
            , info
            , warning
            , danger
        }

        //public AlertControl(string Header, string Message, AlertTypes Type)
        //{
        //    Show(Header, Message, Type);
        //}

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Show(string Header, string Message, AlertTypes Type)
        {
            AlertTypes AlertType = Type;
            //if (Header.Trim() != string.Empty)
            //    Header += " : ";
            string tmp = string.Format(
                 @"<div id=""DivMessage"" runat=""server"" class=""alert alert-{0}"">
                    <!-- success alert -->
                    <strong>{1} ! </strong> {2}
                </div>", AlertType, Header,Message);
            lblAlert.Visible = true;
            lblAlert.Text = tmp;
        }

        public void Hide()
        {
            lblAlert.Text = "";
            lblAlert.Visible = false;
        }
    }
}