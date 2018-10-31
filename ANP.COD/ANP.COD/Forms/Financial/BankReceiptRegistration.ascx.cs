using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANP.Bussiness.Host;
using ANP.Bussiness.Models;
using ANP.COD.Controls;
using ANP.Bussiness.Objects;
using ANP.Common;


namespace ANP.COD.Forms.Financial
{
    public partial class BankReceiptRegistration : System.Web.UI.UserControl, IBankReceiptRegistration
    {
        _BankReceiptRegistration BU = new _BankReceiptRegistration();
        ANP.Bussiness.Objects.LoginDetails UserInfo = new ANP.Bussiness.Objects.LoginDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            //txtBarcodeSearch.Focus();
            UserValidate();
            txtBarcodeSearch.Attributes.Add("onKeyDown", "ModifyEnterKeyPress;");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "anything", "test();", true);
            BU.InitializeIBankReceiptRegistration(this, UserInfo);
            if (!IsPostBack)
            {
                Fdate.Text = DateAndTime.GetDate10Digit();
                Ldate.Text = DateAndTime.GetDate10Digit();
                BU.FormItemesVisible(ddlTypePrice.SelectedValue);
                BU.FillddlReceiptType();
                BU.FillddlMovazehSearch();
           //     ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "anything", "UpDateGrid();", true);
                if (txtBarcodeSearch.Text.Trim() == string.Empty)
                {
                    BU.Load_dgBarcodeList(string.Empty, DateAndTime.GetDate10Digit(), DateAndTime.GetDate10Digit());
                    BU.Load_dgReceiptList();
                    
                }
                else
                {
                    txtBarcodeSearch.Text = string.Empty;
                }
                ChangeControlState();
                txtBarcodeSearch.Focus();
                DateSelector1.Text = DateAndTime.GetDate10Digit();
            }
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

        protected void btn_addToList_Click(object sender, EventArgs e)
        {
            string Result = string.Empty;
            string SelectedID = string.Empty;
            string ReceiptType = ddlReceiptType.SelectedValue;
            if (BU.ReceiptIsUnique() == false)
            {
                ShowMessage(string.Format("اطلاعات فیش وارد شده قبلا در سیستم ثبت شده"));
                return;
            }

            if (DateSelector1.Text.Length!=10)
            {
                ShowMessage(string.Format("لطفا تاریخ فیش را بصورت دستی وارد نکنید"));
                return;
            }
            switch (ReceiptType)
            {
                //حق السهم پست
                case "1":
                    Result = BU.CheckArsenalOfBarcode(out SelectedID);
                    if (Result == string.Empty)
                    {
                        BU.SaveReceiptInfo(SelectedID);
                        ShowMessage("");
                    }
                    else
                        ShowMessage(Result);
                    break;
                case "2":
                case "3":
                    if (BU.DontExistOtherReceipt())
                    {
                        if (BU.DontSendMasterReceipt())
                        {
                            Result = BU.CheckArsenalOfBarcode(out SelectedID);
                            if (Result == string.Empty)
                            {
                                SaveOtherReceipt();
                                ShowMessage("");
                            }
                            else
                                ShowMessage(Result);
                        }
                        else
                        {
                            ShowMessage(string.Format(@"  حق السهم پست با شماره {0} به امور مالی
                                                        ارسال شده و شما قادر به ثبت این درخواست نیستید. ",
                                                        txtSearechPostReceiptSerial.Text));
                        }
                    }
                    else
                    {
                        ShowMessage(string.Format(@"سیستم برای ثبت  {1} برای شماره  
                                                    {0} با مشکل مواجه شد لطفا اطلاعات ورودی را چک کنید.",
                                    txtSearechPostReceiptSerial.Text, ddlReceiptType.SelectedItem.Text));
                    }
                    break;
                case "4":
                    Result = BU.CheckArsenalOfBarcode(out SelectedID);
                    if (Result == string.Empty)
                    {
                        BU.SaveReceiptInfo(SelectedID);
                        ShowMessage("");
                    }
                    else
                        ShowMessage(Result);
                    break;
            }

        }

        private void ClearForm( bool ClickButton)
        {
            BU.ClearForm();
            if (ClickButton)
            {
                BU.Load_dgBarcodeList("", Fdate.Text, Ldate.Text);
                BU.Load_dgReceiptList();
            }
        }

        private void SaveOtherReceipt()
        {
            int MasterReceiptNoID = -1;
            try
            {
                MasterReceiptNoID = BU.MasterReceiptNoIsPerfect();
                if (MasterReceiptNoID == -1)
                {
                    string Message = (((txtSearechPostReceiptSerial.Text.Trim() == string.Empty) || (txtSearechPostReceiptSeri.Text.Trim() == string.Empty)) ?
                        "لطفا شماره فیش حق السهم پست را وارد کنید." :
                        "فیش حق السهم پست با شماره " + txtSearechPostReceiptSerial.Text.Trim() + " یافت نشد . لطفا شماره درست را وارد نمایید.");
                    ShowMessage(Message);
                    return;
                }
                if (BU.DataIsValid() == false)
                {
                    ShowMessage("اطلاعات مربوط به فیش بصورت کامل وارد نمایید.");
                    return;
                }
                BU.SaveOtherReceiptInfo(MasterReceiptNoID);
                ClearForm(true);
            }
            catch
            {
                ShowMessage("خطا در ثبت اطلاعات فیش.");
            }
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
                lblAlert.Text = @"<div id=""DivMessage"" runat=""server"" class=""alert alert-info"">
                    <!-- success alert -->
                    <strong> توجه ! </strong> " + Message + "</div>";
            }
        }

        protected void btnReceiptSend_Click(object sender, EventArgs e)
        {
            BU.upHoldReceiptInfo();
            BU.Load_dgReceiptList();
            BU.Load_dgBarcodeList("",Fdate.Text,Ldate.Text);
        }

        protected void dgReceiptList_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            BU.ItemCommand(e);
        }

        protected void dgBarcodeList_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            BU.FreezeRowOfDataGrid(e);
        }

        protected void ddlReceiptType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeControlState();
        }

        private void ChangeControlState()
        {
            if (Convert.ToInt32(ddlReceiptType.SelectedValue) > 1 && Convert.ToInt32(ddlReceiptType.SelectedValue) < 4)
            {
                Label12.Visible = 
                //Label8.Visible = true;
                lblMasterReceiptNo.Visible = 
                DivtxtSearechPostReceiptSerial.Visible =
                txtSearechPostReceiptSerial.Visible = 
                txtSearechPostReceiptSeri.Visible =
                ddlSearechPostReceiptSeri.Visible = 
                tr_SearchReceiptInfo.Visible = true;
                //txtSearechPostReceiptSerial.Enabled = true;
                //ddlSearechPostReceiptSeri.Enabled = true;
                //txtSearechPostReceiptSeri.Enabled = true;
                //lblMasterReceiptNo.ForeColor =
                //    Label12.ForeColor =
                //    Label8.ForeColor =
                //    System.Drawing.Color.Red;

                dgBarcodeListWithOutPostalCost.Visible =
                     DivBarcodeSearch.Visible = 
                dgBarcodeListWithPostalCost.Visible = 
                div_BarcodeListTitle.Visible =
                div_dgBarcodeList.Visible = 
                DivSelectedPrice.Visible = 
                DivSearch.Visible = false;
                LoadPrice();
            }
            else
            {
                Label12.Visible = 
                //Label8.Visible = false;
                lblMasterReceiptNo.Visible = 
                DivtxtSearechPostReceiptSerial.Visible = 
                txtSearechPostReceiptSerial.Visible =
                txtSearechPostReceiptSeri.Visible = 
                ddlSearechPostReceiptSeri.Visible =
                
                tr_SearchReceiptInfo.Visible = false;
                //txtSearechPostReceiptSerial.Enabled = false;
                //ddlSearechPostReceiptSeri.Enabled = false;
                //txtSearechPostReceiptSeri.Enabled = false;
                //lblMasterReceiptNo.ForeColor =
                //    Label12.ForeColor =
                //    Label8.ForeColor =
                //    System.Drawing.Color.Khaki;
DivBarcodeSearch.Visible = 
                div_BarcodeListTitle.Visible =
                div_dgBarcodeList.Visible =
                DivSelectedPrice.Visible = 
                DivSearch.Visible = true;
                if (Convert.ToInt32(ddlReceiptType.SelectedValue) == 1)
                {
                    dgBarcodeListWithOutPostalCost.Visible = false;
                    dgBarcodeListWithPostalCost.Visible = true;
                }
                if (Convert.ToInt32(ddlReceiptType.SelectedValue) == 4)
                {
                    dgBarcodeListWithOutPostalCost.Visible = true;
                    dgBarcodeListWithPostalCost.Visible =false ;
                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(),"anything2", "calculateTotal();", true);
            }
        }

        protected void ddlTypePrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            BU.FormItemesVisible(ddlTypePrice.SelectedValue);
        }


        #region IBankReceiptRegistration Members


        HiddenField IBankReceiptRegistration.hfMovazeh
        {
            get { return hfMovazeh; }
        }

        Label IBankReceiptRegistration.lblComment
        {
            get { return lblComment; }
        }

        Label IBankReceiptRegistration.lblAccountNoCheque
        {
            get { return lblAccountNoCheque; }
        }

        Label IBankReceiptRegistration.lblSaderKonandehCheque
        {
            get { return lblSaderKonandehCheque; }
        }

        Label IBankReceiptRegistration.lblVajehCheque
        {
            get { return lblVajehCheque; }
        }

        TextBox IBankReceiptRegistration.txtVajehCheque
        {
            get { return txtVajehCheque; }
        }

        TextBox IBankReceiptRegistration.txtSaderKonandehCheque
        {
            get { return txtSaderKonandehCheque; }
        }

        TextBox IBankReceiptRegistration.txtAccountNoCheque
        {
            get { return txtAccountNoCheque; }
        }

        DropDownList IBankReceiptRegistration.ddlTypePrice
        {
            get { return ddlTypePrice; }
        }

        DropDownList IBankReceiptRegistration.ddlMovazehSearch
        {
            get { return ddlMovazehSearch; }
        }

        TextBox IBankReceiptRegistration.txtPayerName
        {
            get { return txtPayerName; }
        }

        string IBankReceiptRegistration.ReceiptDate
        {
            set { DateSelector1.Text = value; }
            get { return DateSelector1.Text; }
        }

        TextBox IBankReceiptRegistration.txtPrice
        {
            get { return txtPrice; }
        }

        TextBox IBankReceiptRegistration.txtReceiptSerialNo
        {
            get { return txtReceiptSerialNo; }
        }

        TextBox IBankReceiptRegistration.txtComment
        {
            get { return txtComment; }
        }

        DropDownList IBankReceiptRegistration.ddl_bank
        {
            get { return ddl_bank; }
        }

        DataGrid IBankReceiptRegistration.dgBarcodeListWithOutPostalCost
        {
            get { return dgBarcodeListWithOutPostalCost; }
        }

        DataGrid IBankReceiptRegistration.dgBarcodeListWithPostalCost
        {
            get { return dgBarcodeListWithPostalCost; }
        }

        Button IBankReceiptRegistration.btn_addToList
        {
            get { return btn_addToList; }
        }

        bool IBankReceiptRegistration.DivtxtSaderKonandehCheque
        {
            get
            {
                return DivtxtSaderKonandehCheque.Visible;
            }
            set
            {
                DivtxtSaderKonandehCheque.Visible = value;
            }
        }

        bool IBankReceiptRegistration.DivtxtVajehCheque
        {
            get
            {
                return DivtxtVajehCheque.Visible;
            }
            set
            {
                DivtxtVajehCheque.Visible = value;
            }
        }

        bool IBankReceiptRegistration.DivtxtSearechPostReceiptSerial
        {
            get
            {
                return DivtxtSearechPostReceiptSerial.Visible;
            }
            set
            {
                DivtxtSearechPostReceiptSerial.Visible = value;
            }
        }

        bool IBankReceiptRegistration.DivtxtComment
        {
            get
            {
                return DivtxtComment.Visible;
            }
            set
            {
                DivtxtComment.Visible = value;
            }
        }

        bool IBankReceiptRegistration.DivtxtAccountNoCheque
        {
            get
            {
                return DivtxtAccountNoCheque.Visible;
            }
            set
            {
                DivtxtAccountNoCheque.Visible = value;
            }
        }

        Label IBankReceiptRegistration.lblMessage
        {
            get
            {
                return lblAlert;
            }
            set
            {
                lblAlert = value;
            }
        }

        DataGrid IBankReceiptRegistration.dgReceiptList
        {
            get { return dgReceiptList; }
        }

        TextBox IBankReceiptRegistration.txtSearechPostReceiptSerial
        {
            get { return txtSearechPostReceiptSerial; }
        }

        DropDownList IBankReceiptRegistration.ddlReceiptType
        {
            get { return ddlReceiptType; }
        }

        DropDownList IBankReceiptRegistration.ddlSearechPostReceiptSeri
        {
            get { return ddlSearechPostReceiptSeri; }
        }

        TextBox IBankReceiptRegistration.txtSearechPostReceiptSeri
        {
            get { return txtSearechPostReceiptSeri; }
        }

        TextBox IBankReceiptRegistration.txtSeri
        {
            get { return txtSeri; }
        }

        DropDownList IBankReceiptRegistration.ddlSeri
        {
            get { return ddlSeri; }
        }

        string IBankReceiptRegistration.Fdate
        {
            get
            {
                return Fdate.Text;
            }
            set { Fdate.Text = value; }

        }

        string IBankReceiptRegistration.Ldate
        {
            get
            {
                return Ldate.Text;
            }
            set { Ldate.Text = value; }

        }

        #endregion IUserModel Members

        protected void Button1_Click(object sender, EventArgs e)
        {
            LoadPrice();
        }

        private void LoadPrice()
        {
            Int64 Price = 0;
            Price = BU.GetPrice(
                ddlReceiptType.SelectedValue,
                txtSearechPostReceiptSerial.Text.Trim(),
                txtSearechPostReceiptSeri.Text.Trim(),
                ddlSearechPostReceiptSeri.SelectedValue);
            if (Price >= 0)
                txtPrice.Text = Price.ToString();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtBarcodeSearch.Text.Trim() == string.Empty)
            {
                BU.Load_dgBarcodeList(hfMovazeh.Value, Fdate.Text, Ldate.Text);
                txtBarcodeSearch.Focus();
            }
            else { txtBarcodeSearch.Text = string.Empty; txtBarcodeSearch.Focus(); }
        }
    }
    }
