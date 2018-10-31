using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANP.Bussiness.Host;
using ANP.Bussiness.Models;
using ANP.Bussiness.Objects;

namespace ANP.COD.Forms.Accounts
{
    public partial class ChangePassword : System.Web.UI.UserControl , IChangePassword
    {
        LoginDetails UserDetail = new LoginDetails();
        _ChangePassword changePass = new _ChangePassword();
        string Message = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserValidate();
            ucAlertControl.Hide();
            changePass.Init(this, UserDetail);
            if (!IsPostBack)
            {
                hf_msg.Value = "";
            }
        }
        private void UserValidate()
        {
            if (null != Session["UserInfo"])
                UserDetail = Session["UserInfo"] as LoginDetails;
            else
                Response.Redirect("~/Login.aspx", true);
        }
        protected void btn_approve_Click(object sender, EventArgs e)
        {
            bool Result = false;
            if (changePass.IsExist())
            {
                Result = changePass.ChgPassword();
            }
            if (!string.IsNullOrEmpty(hf_msg.Value))
            {
                ////DivMessage.Visible = true;
                ////lblMessage.Text = hf_msg.Value;
                if (Result == true)
                    ucAlertControl.Show("عملیات موفق", hf_msg.Value, COD.Controls.AlertControl.AlertTypes.success);
                else
                    ucAlertControl.Show("عملیات ناموفق", hf_msg.Value, COD.Controls.AlertControl.AlertTypes.danger);
            }
            else
            {
                ////DivMessage.Visible = false;
                ////lblMessage.Text = hf_msg.Value;
                ucAlertControl.Hide();
            }
        }
        #region IChangePassword
        HiddenField IChangePassword.hf_msg
        {
            get { return hf_msg; }
        }
        TextBox IChangePassword.txt_curentpass
        {
            get { return txt_curentpass; }
        }
        TextBox IChangePassword.txt_newpass
        {
            get { return txt_newpass; }
        }
        TextBox IChangePassword.txt_new_repass
        {
            get { return txt_new_repass; }
        }
        Button IChangePassword.btn_approve
        {
            get { return btn_approve; }
        }
        #endregion IChangePassword
    }
}