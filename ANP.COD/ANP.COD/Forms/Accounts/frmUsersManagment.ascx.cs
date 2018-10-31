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
    public partial class frmUsersManagment : System.Web.UI.UserControl, IUsersManagment
    {
        LoginDetails UserDetail = new LoginDetails();
        UsersManagment UserManag = new UsersManagment();
        string Message = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            UserValidate();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "anything", "test();", true);
            UserManag.Init(this, UserDetail);
            if (!Page.IsPostBack)
            {
                ucAlertControl.Hide();
                UserManag.Fill_ddlRole();
                FillPlaceControls();
                UserManag.Fill_MyGrid();
                ddl_Role.SelectedValue = "1005";
            }
        }

        private void FillPlaceControls()
        {
            UserManag.Fill_ddlState();
            UserManag.Fill_ddlCity();
            UserManag.Fill_ddlPostNode();
            UserManag.Fill_ddlStatus();
         
            // UserManag.Role_Action();
        }

        private void Role_Action()
        {
            UserManag.Role_Action();
        }

        protected void csvEname_ServerValidate(object sender, System.Web.UI.WebControls.ServerValidateEventArgs e)
        {
            if (!UserManag.IsUniqueUserName() && hf_update.Value == "0")
            {
                e.IsValid = false;
            }
        }

        private void UserValidate()
        {
            if (null != Session["UserInfo"])
                UserDetail = Session["UserInfo"] as LoginDetails;
            else
                Response.Redirect("~/Login.aspx", true);
        }

        protected void ddl_Role_SelectedIndexChanged(object sender, EventArgs e)
        {
            Role_Action();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            ucAlertControl.Hide();
            if (Page.IsValid)
            {
                Message = UserManag.Validate(hf_update.Value);

                if (Message != string.Empty)
                    ucAlertControl.Show("عملیات نا موفق", Message, COD.Controls.AlertControl.AlertTypes.warning);
                else
                {
                    if (UserManag.SaveNewUser())
                    {
                        ucAlertControl.Show("عملیات موفق", "اطلاعات با موفقیت ثبت شد.", COD.Controls.AlertControl.AlertTypes.success);
                        UserManag.Fill_MyGrid();
                        UserManag.ClearForm();

                        hf_update.Value = "0";
                        divState.Visible = true;
                        divCity.Visible = true;
                        divPostNode.Visible = true;
                        divRole.Visible = true;
                        divEname.Visible = true;
                    }
                    else
                        ucAlertControl.Show("عملیات نا موفق", "ثبت اطلاعات کاربر با مشکل مواجه شد.", COD.Controls.AlertControl.AlertTypes.warning);
                }
            }


        }

        protected void MyGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                hf_update.Value = e.CommandArgument.ToString();
                UserManag.LoadUserInfoForEdit(e.CommandArgument.ToString());
            }
        }

        protected void ddl_State_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserManag.Fill_ddlCity();
            UserManag.Fill_ddlPostNode();
        }

        protected void ddl_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserManag.Fill_ddlPostNode();
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            UserManag.ClearForm();
            hf_update.Value = "0";

            divState.Visible = true;
            divCity.Visible = true;
            divPostNode.Visible = true;
            divRole.Visible = true;
            divEname.Visible = true;
            ddl_Role.SelectedValue = "1005";
            ddl_State_SelectedIndexChanged(null, null);
        }

        #region IuserManagment

        System.Web.UI.HtmlControls.HtmlGenericControl IUsersManagment.divRole
        {
            get { return divRole; }
        }
        System.Web.UI.HtmlControls.HtmlGenericControl IUsersManagment.divEname
        {
            get { return divEname; }
        }
        System.Web.UI.HtmlControls.HtmlGenericControl IUsersManagment.divState
        {
            get { return divState; }
        }

        System.Web.UI.HtmlControls.HtmlGenericControl IUsersManagment.divCity
        {
            get { return divCity; }
        }

        System.Web.UI.HtmlControls.HtmlGenericControl IUsersManagment.divPostNode
        {
            get { return divPostNode; }
        }

        HiddenField IUsersManagment.hf_update
        {
            get { return hf_update; }
        }

        TextBox IUsersManagment.txt_Pname
        {
            get { return txt_Pname; }
        }

        TextBox IUsersManagment.txt_Fmily
        {
            get { return txt_Family; }
        }

        TextBox IUsersManagment.txt_Ename
        {
            get { return txt_Ename; }
        }

        TextBox IUsersManagment.txt_Pass
        {
            get { return txt_Pass; }
        }

        TextBox IUsersManagment.txt_RePass
        {
            get { return txt_RePass; }
        }

        DropDownList IUsersManagment.ddl_Role
        {
            get { return ddl_Role; }
        }

        DropDownList IUsersManagment.ddl_State
        {
            get { return ddl_State; }
        }

        DropDownList IUsersManagment.ddl_City
        {
            get { return ddl_City; }
        }

        DropDownList IUsersManagment.ddl_PostNode
        {
            get { return ddl_PostNode; }
        }

        DropDownList IUsersManagment.ddl_Status
        {
            get { return ddl_Status; }
        }

        Button IUsersManagment.btn_cancel
        {
            get { return btn_cancel; }
        }

        Button IUsersManagment.btn_save
        {
            get { return btn_save; }
        }

        public DataGrid Mygrd
        {
            get { return MyGrid; }
        }
        #endregion
    }
}