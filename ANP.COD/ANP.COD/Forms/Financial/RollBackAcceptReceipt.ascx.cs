using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANP.Bussiness.Models;
using ANP.Bussiness.Host;
using ANP.Bussiness.Objects;
using ANP.Common;
using ANP.COD.Controls;

namespace ANP.COD.Forms.Financial
{
    public partial class RollBackAcceptReceipt : System.Web.UI.UserControl, IRollBackAcceptReceipt
    {
        _RollBackAcceptReceipt BU = new _RollBackAcceptReceipt();
        LoginDetails UserInfo = new LoginDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            UserValidate();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "anything", "test();", true);
            BU.InitializeIRollBackAcceptReceipt(this, UserInfo);
            if (!IsPostBack)
            {
                LoadPage();
            }
        }

        private void LoadPage()
        {
            Date.Text = DateAndTime.GetDate10Digit();
            BU.Load_ddlState();
        }

        private void UserValidate()
        {
            if (Session["UserInfo"] != null)
            {
                UserInfo = Session["UserInfo"] as LoginDetails;
                //if(UserInfo.RoleID!=1005)
                //    Response.Redirect("~/Default.aspx", true);
            }
            else
            {
                Response.Redirect("~/Login.aspx", true);
            }

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            string MSG=string.Empty;
            MSG=CheckValidation();
            if (MSG==string.Empty)
                BU.Load_dgReceiptList(ddlState.SelectedValue, Date.Text);
            else
                ucAlertControl.Show("خطا", MSG, COD.Controls.AlertControl.AlertTypes.warning);

        }

        private string CheckValidation()
        {
            if (Date.Text.ToString().Length != 10)
                return "تاریخ وارد شده معتبر نیست . طول تاریخ باید ده کاراکتر باشد";
            else if (ddlState.SelectedValue == null)
                return "شهر مقصد به درستی انتخاب نشده است.";
            else
                return string.Empty;
        }

#region IRollBackAcceptReceipt Members

        string IRollBackAcceptReceipt.Date
        {
            get
            {
                return Date.Text;
            }
            set { Date.Text = value; }

        }

        Button IRollBackAcceptReceipt.btnShow
        {
            get { return btnShow; }
        }

        DropDownList IRollBackAcceptReceipt.ddlState
        {
            get { return ddlState; }
        }

        DataGrid IRollBackAcceptReceipt.dgReceiptList
        {
            get { return dgReceiptList; }
        }

        #endregion

        protected void dgReceiptList_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "ChangeState")
            {
                string MSG= BU.ReturnReceiptToState(e);
                ucAlertControl.Show("توجه", MSG, (MSG == string.Empty ? AlertControl.AlertTypes.success : AlertControl.AlertTypes.danger));
                BU.Load_dgReceiptList(ddlState.SelectedValue, Date.Text);
            }
        }
    }
}