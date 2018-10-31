using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ANP.Bussiness.Models;
using ANP.Bussiness.Objects;
using ANP.Bussiness.Basic;
using ANP.Bussiness.Models.Reports;
using ANP.Bussiness.Host.Reports;
using ANP.Common;

namespace ANP.COD.Forms.Reports
{
    public partial class ControlForm : System.Web.UI.UserControl, IControlForm
    {
        string PageID = string.Empty;
        _ControlForm Buss = new _ControlForm();
        LoginDetails UserInfo = new LoginDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            UserValidate();
            Buss.InitializeIControlForm(this, UserInfo);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "anything", "Test();", true);
            if (false == Page.IsPostBack)
            {
                Fdate.Text = DateAndTime.GetDate10Digit();
                Ldate.Text = DateAndTime.GetDate10Digit();
                LoadFrom();
            }

        }

        private void UserValidate()
        {
            if (null != Session["UserInfo"])
                UserInfo = Session["UserInfo"] as LoginDetails;
            else
                Response.Redirect("~/Login.aspx", true);
        }

        private void LoadFrom()
        {
            if (!IsPostBack)
            {
                if (null != Request.QueryString["action"])
                {
                    PageID = Request.QueryString["action"].ToString();
                    Initi();
                    DisableRow();
                    switch (PageID)
                    {
                        case "24c7cb43-7e87-4f09-9d54-cf5e9495648f":

                            trState.Visible = true;
                            trUser.Visible = true;
                            trCity.Visible = true;
                            trPostNodeName.Visible = true;
                            trBarcodeStatus.Visible = true;
                            trFDate.Visible = true;
                            trTDate.Visible = true;
                            break;
                        case "9af522f6-c1b6-4406-a1e6-0054237fe2cb":

                            trState.Visible = true;
                            trUser.Visible = true;
                            trCity.Visible = true;
                            trPostNodeName.Visible = true;
                            trFDate.Visible = true;
                            trTDate.Visible = true;
                            trReceiptType.Visible = true;
                            trPayType.Visible = true;
                            trReceiptState.Visible = true;
                            trReceiptSaveState.Visible = true;
                            break;
                        case "5a0dac0a-cbc0-4b82-9da4-9e1785b70580":

                            trBarCode.Visible = true;
                            lblBarCode.Text = "بارکد مرسولات کرایه در مقصد";
                            break;

                        case "d4553f7a-1013-4f5f-8c5a-b47f8c80e4e4":

                            trLastState.Visible = true;
                            trLastCity.Visible = true;
                            trFDate.Visible = true;
                            trTDate.Visible = true;
                            trCredit.Visible = true;
                            break;

                        case "26b9c197-195f-4558-b2cc-0c9f19179fdb":
                            lblPateTracking_.Visible = true;
                            trBarCode.Visible = true;
                            lblBarCode.Text = "بارکد مرسولات پته";
                            break;

                            //گزارش سی ستونی
                        case "4a1b4e3f-46cd-42da-b0ce-88577fa18085":
                            trState.Visible = true;
                            trCity.Visible = true;
                            trPostNodeName.Visible = true;
                            trLastState.Visible = true;
                            trFDate.Visible = true;
                            trTDate.Visible = true;

                            break;
                    }
                }
            }
        }

        private void DisableRow()
        {
            trBarcodeStatus.Visible = false;
            trCity.Visible = false;
            trFDate.Visible = false;
            trPostNodeName.Visible = false;
            trReceiptNo.Visible = false;
            trReceiptState.Visible = false;
            trReceiptType.Visible = false;
            trState.Visible = false;
            trTDate.Visible = false;
            trUser.Visible = false;
            trReceiptSaveState.Visible = false;
            trPayType.Visible = false;
            trBarCode.Visible = false;
            trCredit.Visible = false;
            trLastState.Visible = false;
            trLastCity.Visible = false;
            trLastPostNode.Visible = false;
            lblPateTracking_.Visible = false;

        }

        private void Initi()
        {
            try
            {

                Buss.FillState(UserInfo.RoleID, UserInfo.StateCode, Request.QueryString["action"].ToString());
                Buss.FillCity(UserInfo.RoleID, UserInfo.CityCode);
                FillPostNode();
                Buss.FillLastState();
                Buss.FillLastCity();
                Buss.FillLastPostNode();
                Buss.FillUser(UserInfo.RoleID, UserInfo.UserId);
                Buss.FillBarcodeStatus();
                Buss.FillReceiptSeriAlepha();
                Buss.FillReceiptType();
                Buss.FillReceiptState();
                Buss.FillReceiptSaveState();
            }
            catch { }
        }

        private void FillPostNode()
        {
            if (Request.QueryString["action"].ToString() == "4a1b4e3f-46cd-42da-b0ce-88577fa18085")
                Buss.FillPostNode_Ghabool(UserInfo.RoleID, UserInfo.PostNodeCode);
            else
                Buss.FillPostNode(UserInfo.RoleID, UserInfo.PostNodeCode);
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buss.FillCity(UserInfo.RoleID, UserInfo.CityCode);
            FillPostNode();
            Buss.FillUser(UserInfo.RoleID, UserInfo.UserId);
        }

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillPostNode();
            Buss.FillUser(UserInfo.RoleID, UserInfo.UserId);
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            if (null != Request.QueryString["action"])
            {
                //Init();
                string param = "";

                if (ChackDate(62) == false)
                {
                    //Error
                    ucAlertControl.Show("خطا", "حداکثر بازه انتخابی از دو ماه نباید بیشتر شود", COD.Controls.AlertControl.AlertTypes.danger);
                    return;
                }

                PageID = Request.QueryString["action"].ToString();

                param = "StateCode|" + ddlState.SelectedValue + "#";
                param += "CityCode|" + ddlCity.SelectedValue + "#";
                param += "PostNodeCode|" + ddlPostNode.SelectedValue + "#";
                param += "LastStateCode|" + ddlLastState.SelectedValue + "#";
                param += "LastCityCode|" + ddlLastCity.SelectedValue + "#";
                param += "LastPostNode|" + ddlLastPostNode.SelectedValue + "#";
                param += "UserID|" + ddlUser.SelectedValue + "#";
                param += "FirstDate|" + Fdate.Text + "#";
                param += "LastDate|" + Ldate.Text + "#";
                param += "BarcodeStatusID|" + ddlBarcodeStatus.SelectedValue + "#";
                param += "ReceiptSeriAlepha|" + ddlReceiptSeriAlepha.SelectedValue + "#";
                param += "ReceiptNo|" + txtReceiptNo.Text.Trim() + "#";
                param += "ReceiptSeriNo|" + txtReceiptSeriNo.Text.Trim() + "#";
                param += "ReceiptType|" + ddlReceiptType.SelectedValue + "#";
                param += "FinancialMoodValue|" + ddlReceiptSaveState.SelectedValue + "#";
                param += "ApproveFlag|" + ddlReceiptState.SelectedValue + "#";
                param += "PayType|" + ddlPayType.SelectedValue + "#";
                param += "BarCode|" + txtBarCode.Text.Trim() + "#";
                param += "Credit|" + ddlCredit.SelectedValue.ToString() + "#";

                //switch (Convert.ToInt32(ddlReceiptType.SelectedValue))
                //{
                //    case 0:
                //        ReceiptType = "0";
                //        break;
                //    case 1:
                //        ReceiptType = "Y";
                //        break;
                //    case 2:
                //        ReceiptType = "N";
                //        break;
                //}

                switch (PageID)
                {
                    case "24c7cb43-7e87-4f09-9d54-cf5e9495648f":
                        {
                            if (Convert.ToInt32(ddlState.SelectedValue) == -1 && ChackDate(2) == false)
                                ucAlertControl.Show("خطا", "حداکثر بازه انتخابی از دو روز نباید بیشتر شود", COD.Controls.AlertControl.AlertTypes.danger);
                           
                            else if (UserInfo.RoleID < 1005 && Convert.ToInt32(ddlState.SelectedValue) > -1 && ChackDate(14) == false)
                                ucAlertControl.Show("خطا", "حداکثر بازه انتخابی از چهار روز نباید بیشتر شود", COD.Controls.AlertControl.AlertTypes.danger);
                            else if (UserInfo.RoleID >= 1005 && Convert.ToInt32(ddlState.SelectedValue) > -1 && ChackDate(14) == false)
                                ucAlertControl.Show("خطا", "حداکثر بازه انتخابی از هفت روز نباید بیشتر شود", COD.Controls.AlertControl.AlertTypes.danger);
                            else
                                Response.Redirect("Default.aspx?action=303f5b17-fa3e-49ce-bcf4-f6a05c1d3c63&pra=" + Buss.Encrypt(param));
                            break;
                        }
                    case "9af522f6-c1b6-4406-a1e6-0054237fe2cb": Response.Redirect("Default.aspx?action=6aaf1aa9-591e-4d46-92ae-ccdd3d919fc4&pra=" + Buss.Encrypt(param)); break;
                    case "5a0dac0a-cbc0-4b82-9da4-9e1785b70580": Response.Redirect("Default.aspx?action=3d5fe897-2a5e-4581-9aba-6e1a33e3a51a&pra=" + Buss.Encrypt(param)); break;
                    case "d4553f7a-1013-4f5f-8c5a-b47f8c80e4e4": Response.Redirect("Default.aspx?action=a8209dc1-301f-4275-a88c-a7fcfa4a3c15&pra=" + Buss.Encrypt(param)); break;
                    case "26b9c197-195f-4558-b2cc-0c9f19179fdb": { lblPateTracking.Text = ""; PateTracking(lblPateTracking.Text.Trim()); break; }//Response.Redirect("Default.aspx?action=38a96ecb-5bfd-4d28-9abe-4bcaa9f3b411&pra=" + Buss.Encrypt(param)); break;
                    case "4a1b4e3f-46cd-42da-b0ce-88577fa18085": Response.Redirect("Default.aspx?action=8e7f6fa5-d33a-43a7-951f-4e0f85012e5e&pra=" + Buss.Encrypt(param)); break;


                }
            }
        }

        private void PateTracking(string p)
        {
            lblPateTracking.Text = "نتیجه ایی یافت نشد . ";
            try
            {
                lblPateTracking.Text = Buss.ReturnRahgiriPate(txtBarCode.Text.Trim()); ;
            }
            catch { }

        }

        private bool ChackDate(int MaxDay)
        {
            if (Fdate.Visible && Ldate.Visible)
            {
                double Diff = DateAndTime.DiffDateShamsi(Fdate.Text, Ldate.Text);
                if (Diff > MaxDay)
                    return false;
                else
                    return true;
            }
            else
                return true;
        }

        protected void ddlPostNode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buss.FillUser(UserInfo.RoleID, UserInfo.UserId);
        }

        #region IControlForm Members

        bool IControlForm.trState
        {
            get { return trState.Visible; }
            set { trState.Visible = value; }
        }

        bool IControlForm.trCity
        {
            get
            {
                return trCity.Visible;
            }
            set { trCity.Visible = value; }

        }

        bool IControlForm.trPostNodeName
        {
            get
            {
                return trPostNodeName.Visible;
            }
            set { trPostNodeName.Visible = value; }

        }

        bool IControlForm.trLastState
        {
            get { return trLastState.Visible; }
            set { trLastState.Visible = value; }
        }

        bool IControlForm.trLastCity
        {
            get
            {
                return trLastCity.Visible;
            }
            set { trLastCity.Visible = value; }

        }

        bool IControlForm.trLastPostNode
        {
            get
            {
                return trLastPostNode.Visible;
            }
            set { trLastPostNode.Visible = value; }
        }

        bool IControlForm.trUser
        {
            get
            {
                return trUser.Visible;
            }
            set { trUser.Visible = value; }

        }

        bool IControlForm.trBarcodeStatus
        {
            get
            {
                return trBarcodeStatus.Visible;
            }
            set { trBarcodeStatus.Visible = value; }

        }

        bool IControlForm.trFDate
        {
            get
            {
                return trFDate.Visible;
            }
            set { trFDate.Visible = value; }

        }

        bool IControlForm.trTDate
        {
            get
            {
                return trTDate.Visible;
            }
            set { trTDate.Visible = value; }

        }

        bool IControlForm.trReceiptNo
        {
            get
            {
                return trReceiptNo.Visible;
            }
            set { trReceiptNo.Visible = value; }

        }

        bool IControlForm.trReceiptType
        {
            get
            {
                return trReceiptType.Visible;
            }
            set { trReceiptType.Visible = value; }

        }

        bool IControlForm.trReceiptState
        {
            get
            {
                return trReceiptState.Visible;
            }
            set { trReceiptState.Visible = value; }

        }

        bool IControlForm.trShowButton
        {
            get
            {
                return trShowButton.Visible;
            }
            set { trShowButton.Visible = value; }

        }

        bool IControlForm.trReceiptSaveState
        {
            get
            {
                return trReceiptSaveState.Visible;
            }
            set
            {
                trReceiptSaveState.Visible = value;
            }
        }

        bool IControlForm.trPayType
        {
            get
            {
                return trPayType.Visible;
            }
            set
            {
                trPayType.Visible = value;
            }
        }

        bool IControlForm.trBarCode
        {
            get
            {
                return trBarCode.Visible;
            }
            set
            {
                trBarCode.Visible = value;
            }
        }

        bool IControlForm.trCredit
        {
            get
            {
                return trCredit.Visible;
            }
            set
            {
                trCredit.Visible = value;
            }
        }

        string IControlForm.Fdate
        {
            get
            {
                return Fdate.Text;
            }
            set { Fdate.Text = value; }

        }

        string IControlForm.Ldate
        {
            get
            {
                return Ldate.Text;
            }
            set { Ldate.Text = value; }

        }

        DropDownList IControlForm.ddlCredit
        {
            get
            {
                return ddlCredit;
            }
            set { ddlCredit = value; }

        }

        DropDownList IControlForm.ddlReceiptSeriAlepha
        {
            get
            {
                return ddlReceiptSeriAlepha;
            }
            set { ddlReceiptSeriAlepha = value; }

        }

        TextBox IControlForm.txtReceiptSeriNo
        {
            get
            {
                return txtReceiptSeriNo;
            }
            set { txtReceiptSeriNo = value; }

        }

        TextBox IControlForm.txtReceiptNo
        {
            get
            {
                return txtReceiptNo;
            }
            set { txtReceiptNo = value; }

        }

        TextBox IControlForm.txtBarCode
        {
            get
            {
                return txtBarCode;
            }
            set
            {
                txtBarCode = value;
            }
        }

        DropDownList IControlForm.ddlState
        {
            get
            {
                return ddlState;
            }
            set { ddlState = value; }
        }

        DropDownList IControlForm.ddlCity
        {
            get
            {
                return ddlCity;
            }
            set { ddlCity = value; }

        }

        DropDownList IControlForm.ddlPostNode
        {
            get
            {
                return ddlPostNode;
            }
            set { ddlPostNode = value; }

        }

        DropDownList IControlForm.ddlLastState
        {
            get
            {
                return ddlLastState;
            }
            set { ddlLastState = value; }
        }

        DropDownList IControlForm.ddlLastCity
        {
            get
            {
                return ddlLastCity;
            }
            set { ddlLastCity = value; }

        }

        DropDownList IControlForm.ddlLastPostNode
        {
            get
            {
                return ddlLastPostNode;
            }
            set { ddlLastPostNode = value; }

        }
        DropDownList IControlForm.ddlUser
        {
            get
            {
                return ddlUser;
            }
            set { ddlUser = value; }

        }

        DropDownList IControlForm.ddlBarcodeStatus
        {
            get
            {
                return ddlBarcodeStatus;
            }
            set { ddlBarcodeStatus = value; }

        }

        DropDownList IControlForm.ddlReceiptType
        {
            get
            {
                return ddlReceiptType;
            }
            set { ddlReceiptType = value; }

        }

        DropDownList IControlForm.ddlReceiptState
        {
            get
            {
                return ddlReceiptState;
            }
            set { ddlReceiptState = value; }

        }

        DropDownList IControlForm.ddlPayType
        {
            get
            {
                return ddlPayType;
            }
            set { ddlPayType = value; }

        }

        DropDownList IControlForm.ddlReceiptSaveState
        {
            get
            {
                return ddlReceiptSaveState;
            }
            set
            {
                ddlReceiptSaveState = value;
            }
        }

        Button IControlForm.btnShow
        {
            get
            {
                return btnShow;
            }
            set { btnShow = value; }

        }

        Label IControlForm.lblReceiptState
        {
            get
            {
                return lblReceiptState;
            }
            set { lblReceiptState = value; }

        }

        Label IControlForm.lblReceiptType
        {
            get
            {
                return lblReceiptType;
            }
            set { lblReceiptType = value; }

        }

        Label IControlForm.lblReceiptNo
        {
            get
            {
                return lblReceiptNo;
            }
            set { lblReceiptNo = value; }

        }

        Label IControlForm.lblTdate
        {
            get
            {
                return lblTdate;
            }
            set { lblTdate = value; }

        }

        Label IControlForm.lblFdate
        {
            get
            {
                return lblFdate;
            }
            set { lblFdate = value; }
        }

        Label IControlForm.lblUser
        {
            get
            {
                return lblUser;
            }
            set { lblUser = value; }
        }

        Label IControlForm.lblBarcodeStatus
        {
            get
            {
                return lblBarcodeStatus;
            }
            set { lblBarcodeStatus = value; }
        }

        Label IControlForm.lblPostNode
        {
            get
            {
                return lblPostNode;
            }
            set { lblPostNode = value; }
        }

        Label IControlForm.lblCity
        {
            get
            {
                return lblCity;
            }
            set { lblCity = value; }

        }

        Label IControlForm.lblState
        {
            get
            {
                return lblState;
            }
            set { lblState = value; }
        }

        Label IControlForm.lblLastPostNode
        {
            get
            {
                return lblLastPostNode;
            }
            set { lblLastPostNode = value; }
        }

        Label IControlForm.lblLastCity
        {
            get
            {
                return lblLastCity;
            }
            set { lblLastCity = value; }

        }

        Label IControlForm.lblLastState
        {
            get
            {
                return lblLastState;
            }
            set { lblLastState = value; }
        }
        Label IControlForm.lblReceiptSaveState
        {
            get
            {
                return lblReceiptSaveState;
            }
            set
            {
                lblReceiptSaveState = value;
            }
        }

        Label IControlForm.lblPayType
        {
            get
            {
                return lblPayType;
            }
            set
            {
                lblPayType = value;
            }
        }

        Label IControlForm.lblBarCode
        {
            get
            {
                return lblBarCode;
            }
            set
            {
                lblBarCode = value;
            }
        }

        Label IControlForm.lblCredit
        {
            get
            {
                return lblCredit;
            }
            set
            {
                lblCredit = value;
            }
        }



        #endregion

        protected void ddlLastState_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buss.FillLastCity();
            Buss.FillLastPostNode();
        }

        protected void ddlLastCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buss.FillLastPostNode();
        }
    }

}