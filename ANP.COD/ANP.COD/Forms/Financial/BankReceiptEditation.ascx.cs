using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANP.Bussiness.Models;
using ANP.Bussiness.Host;
using ANP.Bussiness.Objects;

namespace ANP.COD.Forms.Financial
{
    public partial class BankReceiptEditation : System.Web.UI.UserControl, IBankReceiptEditation
    {
        _BankReceiptEditation BU = new _BankReceiptEditation();
        LoginDetails UserInfo = new LoginDetails();
        int EditID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            UserValidate();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "anything", "test();", true);
            BU.Init(this, UserInfo);
            if (!IsPostBack)
            {
                BU.Load_MyGrid(Session["ParentID"].ToString());
            }
        }

        private void UserValidate()
        {
            if (null != Session["UserInfo"])
                UserInfo = Session["UserInfo"] as LoginDetails;
            else
                Response.Redirect("~/Login.aspx", true);
        }

        protected void MyGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            lblMessage.Hide();
            EditID = Convert.ToInt32(e.CommandArgument.ToString());
            switch (e.CommandName)
            {
                case "Edit":
                    EditReceipt(EditID);
                    break;
                case "Del":
                    DelReceipt(EditID);
                    break;
            }
            BU.Load_MyGrid(Session["ParentID"].ToString());
        }

        private void EditReceipt(int EditID)
        {
            if (ReceiptIsSupplement(EditID))
            {
                Session["ReceiptID"] = EditID;
                Session["ReceiptIsSupplement_Param"] = "E";
                Response.Redirect("~/Default.aspx?action=a503df13-a237-4278-9614-a22a09e61579", true);
            }
            else
            {
                Session["ReceiptID"] = EditID;
                Response.Redirect("~/Default.aspx?action=eb76fbc1-5cc3-43c4-ae9c-354c78055a70", true);
            }

        }

        private bool ReceiptIsSupplement(int EditID)
        {
            return BU.IsSupplement(EditID);
        }

        private void DelReceipt(int EditID)
        {
            if (BU.Del(EditID))
            {
                lblMessage.Hide();
                lblMessage.Show("عملیات موفق", "فیش مورد نظر حذف شد .", COD.Controls.AlertControl.AlertTypes.success);
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Show("عملیات ناموفق", "برای حذف فیش اصلی باید ابتدا تمام فیش های متمم حذف شوند."
                    ,COD.Controls.AlertControl.AlertTypes.warning);
            }
        }

        #region Implemante
        DataGrid IBankReceiptEditation.MyGrid
        {
            get { return MyGrid; }
        }
        #endregion

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            BU.SendeToFinance();
            Response.Redirect("~/Default.aspx?action=df5acbb6-b2da-4c87-b737-988dbfb5054b", true);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx?action=DF5ACBB6-B2DA-4C87-B737-988DBFB5054B", true);
        }
    }
}