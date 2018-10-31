using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANP.Bussiness.Host;
using ANP.Bussiness.Objects;

using ANP.Bussiness.Models;


namespace ANP.COD.Forms.Financial
{
    public partial class SupplementReceiptRegistration : System.Web.UI.UserControl, ISupplementReceiptRegistration
    {
        _SupplementReceiptRegistration BU = new _SupplementReceiptRegistration();
        LoginDetails UserInfo = new LoginDetails();
        //BankReceipt BI = new BankReceipt();
        bool IsSup = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["Param"] = Session["ReceiptIsSupplement_Param"];
                ViewState["ReceiptID"] = Session["ReceiptID"];
                ViewState["ParentID"] = Session["ParentID"];

                Session["ReceiptIsSupplement_Param"] = null;
                Session["ReceiptID"] = null;
                Session["ParentID"] = null;
            }

            UserValidate();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "anything", "test();", true);

            if (ViewState["Param"] != null && ViewState["Param"].ToString() == "E")
                BU.Init(this, UserInfo, ViewState["ReceiptID"].ToString(), "E", true, IsPostBack);

            else if (ViewState["Param"] == null)
                BU.Init(this, UserInfo, ViewState["ParentID"].ToString(), "S", false, IsPostBack);

            else if (ViewState["Param"] != null && ViewState["Param"].ToString() == "S")
                BU.Init(this, UserInfo, ViewState["ParentID"].ToString(), "S", true, IsPostBack);
        }

        private void UserValidate()
        {
            if (null != Session["UserInfo"])
            {
                UserInfo = Session["UserInfo"] as LoginDetails;
                if (UserInfo.RoleID != 1005 && UserInfo.RoleID != 1006)
                    Response.Redirect("~/Permission.aspx", true);
            }
            else
                Response.Redirect("~/Login.aspx", true);

            if (ViewState["ReceiptID"] == null && ViewState["ParentID"] == null)
                Response.Redirect("~/Permission.aspx", true);

        }

        #region Interface

        TextBox ISupplementReceiptRegistration.txtParentSeri
        {
            get { return txtParentSeri; }
        }

        TextBox ISupplementReceiptRegistration.txtParentSeriAlphabet
        {
            get { return txtParentSeriAlphabet; }
        }

        DropDownList ISupplementReceiptRegistration.ddlSeri
        {
            get { return ddlSeri; }
        }

        TextBox ISupplementReceiptRegistration.txtSeri
        {
            get { return txtSeri; }
        }

        DropDownList ISupplementReceiptRegistration.ddlReceiptType
        {
            get { return ddlReceiptType; }
        }

        DropDownList ISupplementReceiptRegistration.ddl_bank
        {
            get { return ddl_bank; }
        }

        DropDownList ISupplementReceiptRegistration.ddlTypePrice
        {
            get { return ddlTypePrice; }
        }

        TextBox ISupplementReceiptRegistration.txtReceiptNo
        {
            get { return txtReceiptNo; }
        }

        TextBox ISupplementReceiptRegistration.txtPrice
        {
            get { return txtPrice; }
        }

        TextBox ISupplementReceiptRegistration.txtPayerName
        {
            get { return txtPayerName; }
        }

        Button ISupplementReceiptRegistration.btn_addToList
        {
            get { return btn_addToList; }
        }
        public string PayDate
        {
            get { return DateSelector1.Text; }
            set { DateSelector1.Text = value; }
        }

        TextBox ISupplementReceiptRegistration.txtParentReceiptID
        {
            get { return txtParentReceiptID; }
        }

        Label ISupplementReceiptRegistration.lblParentReceipt
        {
            get { return lblParentReceipt; }
        }

        TextBox ISupplementReceiptRegistration.txtSaderKonandehCheque
        {
            get { return txtSaderKonandehCheque; }
        }

        TextBox ISupplementReceiptRegistration.txtAccountNoCheque
        {
            get { return txtAccountNoCheque; }
        }

        TextBox ISupplementReceiptRegistration.txtComment
        {
            get { return txtComment; }
        }

        TextBox ISupplementReceiptRegistration.txtVajehCheque
        {
            get { return txtVajehCheque; }
        }

        Label ISupplementReceiptRegistration.lblAccountNoCheque
        {
            get { return lblAccountNoCheque; }
        }

        Label ISupplementReceiptRegistration.lblSaderKonandehCheque
        {
            get { return lblSaderKonandehCheque; }
        }

        Label ISupplementReceiptRegistration.lblVajehCheque
        {
            get { return lblVajehCheque; }
        }

        Label ISupplementReceiptRegistration.lblComment
        {
            get { return lblComment; }
        }
        #endregion

        protected void btn_addToList_Click(object sender, EventArgs e)
        {
            if (ViewState["Param"] != null && ViewState["Param"].ToString() == "E")
                if (DisparityPriceWithArsenal("Supp_E") > -1)
                {
                    //
                    if (BU.IsExistEqualOtherReceipt(txtReceiptNo.Text, txtSeri.Text, ddlSeri.SelectedValue, ViewState["ReceiptID"].ToString()))
                    {
                        ShowMessage("این فیش قبلا در سیستم ثبت شده و امکان ثبت مجدد نیست .  ");
                        return;
                    }
                    else
                    {
                        BU.UpdateSupplementReceipt(Convert.ToInt32(ViewState["ReceiptID"].ToString()));
                    }
                }
                else
                {
                    ShowMessage(" مبلغ وارد شده برای این فیش  بعلت اختلاف با مبلغ واقعی مرسولات قابل ثبت نمی باشد.  ");
                    return;
                }
            //This Never Use "Param"="s"
            else if (ViewState["Param"] != null && ViewState["Param"].ToString() == "S")
            {
                if (DisparityPriceWithArsenal("Supp_S") > -1)
                {
                    if (BU.ReceiptCheckForUnique(txtReceiptNo.Text.Trim(), txtSeri.Text.Trim(), ddlSeri.SelectedValue))
                        BU.SaveSupplementReceipt(Convert.ToInt32(ViewState["ParentID"].ToString()));
                    else
                    {
                        ShowMessage(" شماره فیش وارد شده تکراری می باشد.  ");
                        return;
                    }
                }
                else
                {
                    ShowMessage(" مبلغ وارد شده برای این فیش متمم بعلت اختلاف با مبلغ واقعی مرسولات قابل ثبت نمی باشد.  ");
                    return;
                }
            }
            else if (ViewState["Param"] == null)
            {
                if (DisparityPriceWithArsenal("Supp_S") > -1)
                {
                    if (BU.ReceiptCheckForUnique(txtReceiptNo.Text.Trim(), txtSeri.Text.Trim(), ddlSeri.SelectedValue))
                        BU.SaveSupplementForOtherReceipt(Convert.ToUInt64(ViewState["ParentID"].ToString()));
                    else
                    {
                        ShowMessage(" شماره فیش وارد شده تکراری می باشد.  ");
                        return;
                    }
                }
                else
                {
                    ShowMessage(" مبلغ وارد شده برای این فیش متمم بعلت اختلاف با مبلغ واقعی مرسولات قابل ثبت نمی باشد.  ");
                    return;
                }
            }
            Finish();
            Response.Redirect("~/Default.aspx?action=DF5ACBB6-B2DA-4C87-B737-988DBFB5054B", true);
        }

        private int DisparityPriceWithArsenal(string Flag)
        {
            int Result = 0;
            switch (Flag)
            {
                case "Supp_E":
                    Result = BU.DisparityPriceForUpdateSupp(ViewState["ReceiptID"].ToString(), ddlReceiptType.SelectedValue);
                    break;
                case "Supp_S":
                    Result = BU.DisparityPriceForSaveSupp(ViewState["ParentID"].ToString(), ddlReceiptType.SelectedValue);
                    break;
                case "Master_E":
                    Result = BU.DisparityPriceForSaveSupp(ViewState["ParentID"].ToString(), ddlReceiptType.SelectedValue);
                    break;
            }
            return Result;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Finish();
            Response.Redirect("~/Default.aspx?action=DF5ACBB6-B2DA-4C87-B737-988DBFB5054B", true);
        }

        private void Finish()
        {
            Session["ReceiptID"] = null;
            Session["ParentID"] = null;
            Session["ReceiptIsSupplement_Param"] = null;
            ViewState["Param"] = null;
            ViewState["ReceiptID"] = null;
            ViewState["ParentID"] = null;
        }

        public void ShowMessage(string Message)
        {
            if (Message.Trim() == string.Empty)
            {
                lblAlert.Text = "";
                lblAlert.Visible = false;
            }
            else
            {
                lblAlert.Visible = true;
                lblAlert.Text = @"<div id=""DivMessage"" runat=""server"" class=""alert alert-info"">
                    <!-- success alert -->
                    <strong> توجه ! </strong> " + Message + "</div>";
            }
        }

        protected void ddlTypePrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            BU.FormItemesVisible(ddlTypePrice.SelectedValue);
        }
    }
}