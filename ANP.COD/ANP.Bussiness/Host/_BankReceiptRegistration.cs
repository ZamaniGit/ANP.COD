using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;
using ANP.Data;
using ANP.Bussiness;
using ANP.Common;
using ANP.Bussiness.Models;
using ANP.Bussiness.Objects;
using ANP.Data.Object;
using ANP.Bussiness.Basic;
using ANP.Data.BaseData;
namespace ANP.Bussiness.Host
{
    public class _BankReceiptRegistration
    {
      
        IBankReceiptRegistration _host;
        LoginDetails UserInfo;
        BankReceipt BI = new BankReceipt();

        public void InitializeIBankReceiptRegistration(IBankReceiptRegistration hostform, LoginDetails LD)
        {
            this._host = hostform;
            UserInfo = LD;

            Utility.FillCombo(BI.ReturnBankName(), _host.ddl_bank, "ID", "title", false);
            Utility.FillCombo(BI.ReturnAllAlephabetSeri(), _host.ddlSeri, "ID", "title", false);
            Utility.FillCombo(BI.ReturnAllAlephabetSeri(), _host.ddlSearechPostReceiptSeri, "ID", "title", false);
        }

        public void Load_dgBarcodeList(string IdOfMovazeh,string Fdate,string Ldate )
        {
            _host.dgBarcodeListWithPostalCost.DataSource = BI.ReturnAllBarcodeDeliveryWithPostalCost(UserInfo.PostNodeCode, IdOfMovazeh, Fdate, Ldate);
            _host.dgBarcodeListWithPostalCost.DataBind();
            _host.dgBarcodeListWithOutPostalCost.DataSource = BI.ReturnAllBarcodeDeliveryWithOutPostalCost(UserInfo.PostNodeCode, IdOfMovazeh, Fdate, Ldate);
            _host.dgBarcodeListWithOutPostalCost.DataBind();
        }

        public void GetSelectedRowIndgBarcodeList(out string SelectedID)
        {
            SelectedID = string.Empty;
            SelectedID = GetidOfSelectedRow();
        }

        public void SaveReceiptInfo(string SelectedID)
        {
            try
            {
               
                ReceiptClass _Receipt = FillReceiptObject();
                BI.SaveReceipt(_Receipt, SelectedID, Convert.ToInt16(_host.ddlReceiptType.SelectedValue));
                ClearForm();
                Load_dgBarcodeList(_host.hfMovazeh.Value, _host.Fdate, _host.Ldate);
                Load_dgReceiptList();
            }
            catch { }
        }

        private ReceiptClass FillReceiptObject()
        {
            ReceiptClass _Receipt = new ReceiptClass();
            _Receipt.IsPhish= _host.ddlTypePrice.SelectedValue;
            _Receipt.BankID = Convert.ToInt32(_host.ddl_bank.SelectedValue);
            _Receipt.InsertDate_SH = DateAndTime.GetDate10Digit();
            _Receipt.InsertTime = DateAndTime.GetTime8Digit();
            _Receipt.PayerName = _host.txtPayerName.Text.Trim();
            _Receipt.Price = Convert.ToUInt64(_host.txtPrice.Text.Trim());
            _Receipt.ReceiptSerialNo = _host.txtReceiptSerialNo.Text.Trim();
            _Receipt.ReceiptNumberSeri = _host.txtSeri.Text.Trim();
            _Receipt.ReceiptAlphabetSeri = _host.ddlSeri.SelectedValue.ToString();
            _Receipt.PayDate = _host.ReceiptDate;
            _Receipt.UserID = UserInfo.UserId;
            _Receipt.PostNodeCode = UserInfo.PostNodeCode;
            if (_host.ddlTypePrice.SelectedValue == "0")
            {
                _Receipt.ChequeAccountNo=_host.txtAccountNoCheque.Text.Trim();
                _Receipt.ChequeComment = _host.txtComment.Text.Trim();
                _Receipt.ChequeSaderKonandeh = _host.txtSaderKonandehCheque.Text.Trim();
                _Receipt.ChequeVajh = _host.txtVajehCheque.Text.Trim();
            }
            return _Receipt;
        }

        public void Load_dgReceiptList()
        {
            DataTable dt = new DataTable();
            dt = BI.ReturnAllReceiptList(UserInfo.PostNodeCode);
            _host.dgReceiptList.DataSource = dt;
            _host.dgReceiptList.DataBind();
       
        }

        private string GetidOfSelectedRow()
        {
            string Result = string.Empty;

            if (_host.dgBarcodeListWithPostalCost.Visible == true)
            {
                foreach (DataGridItem item in _host.dgBarcodeListWithPostalCost.Items)
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                        if (((CheckBox)item.Cells[2].FindControl("chkSelect")).Checked)
                            if (item.Cells[7].Text == "--")
                                Result += item.Cells[0].Text + ",";
            }
            if (_host.dgBarcodeListWithOutPostalCost.Visible == true)
            {
                foreach (DataGridItem item in _host.dgBarcodeListWithOutPostalCost.Items)
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                        if (((CheckBox)item.Cells[2].FindControl("chkSelect")).Checked)
                            if (item.Cells[7].Text == "--")
                                Result += item.Cells[0].Text + ",";
            }
            Result = Result.TrimEnd(',');
            return Result;
        }

        public void upHoldReceiptInfo()
        {
            BI.UpdateReceiptForupHold(DateAndTime.GetDate10Digit(), UserInfo.UserId, UserInfo.PostNodeCode);
        }

        public void ItemCommand(DataGridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Delete":
                    if (BI.AllowForDelete(Convert.ToInt32(e.CommandArgument)))
                    {
                        BI.DeleteReceiptInfoByID(Convert.ToInt32(e.CommandArgument));
                        ShowMessage("");
                    }
                    else
                        ShowMessage(" در حال حاضر قادر به حذف این فیش نمی باشید . ابتدا تمام فیش های زیر گروه مربوطه را حذف نمایید. ");
                    break;
            }
            Load_dgBarcodeList("","0","0");
            Load_dgReceiptList();
        }

        public void ShowMessage(string Message)
        {
            if (Message.Trim() == string.Empty)
            {
                _host.lblMessage.Text = "";
                _host.lblMessage.Visible = false;
            }
            else
            {
                _host.lblMessage.Text = @"<div id=""DivMessage"" runat=""server"" class=""alert alert-info"">
                    <!-- success alert -->
                    <strong> توجه ! </strong> " + Message + "</div>";
            }
        }

        public void FreezeRowOfDataGrid(DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.Cells[7].Text != "--")
                //if (Convert.ToInt32(e.Item.Cells[7].Text) > 0)
                {
                    e.Item.Style.Add("background-color", "#DDDDDD");
                    ((CheckBox)e.Item.Cells[1].FindControl("chkSelect")).Checked = true;
                    ((CheckBox)e.Item.Cells[1].FindControl("chkSelect")).Enabled = false;
                }

            }
        }

        public void ClearForm()
        {
            _host.ReceiptDate = DateAndTime.GetDate10Digit();
            _host.txtSearechPostReceiptSerial.Text =
            _host.txtSearechPostReceiptSeri.Text =
            _host.txtSaderKonandehCheque.Text =
            _host.txtReceiptSerialNo.Text =
            _host.txtAccountNoCheque.Text =
            _host.txtPayerName.Text =
            _host.txtComment.Text =
            _host.txtPrice.Text =
            _host.txtSeri.Text =
            string.Empty;
        }

        public void FillddlReceiptType()
        {
            Utility.FillCombo(BI.ReturnReceiptType(), _host.ddlReceiptType, "Value", "Title", false);
        }

        public int MasterReceiptNoIsPerfect()
        {
            if (_host.txtSearechPostReceiptSerial.Text.Trim() == string.Empty || _host.txtSearechPostReceiptSeri.Text.Trim() == string.Empty) return -2;
            string Query = string.Format(@" select isnull( (Select id from ReceiptInfo Where ReceiptSerialNo='{0}'
                                AND UserID={1} AND IsSupplementReceipt='N' AND ReceiptTypeValue=1
                                AND ReceiptAlephabetSeri={2} AND ReceiptNumberSeri={3}  AND LogFlag='N' and Deleted='N' ),0)",
                                _host.txtSearechPostReceiptSerial.Text.Trim(), UserInfo.UserId,
                                _host.ddlSearechPostReceiptSeri.SelectedValue.ToString(), _host.txtSearechPostReceiptSeri.Text.Trim());
            DataTable dt = new DataTable();
            dt = BI.SqlDataTable(Query);
            if (dt.Rows.Count == 1)
                return Convert.ToInt32(dt.Rows[0][0].ToString());
            else
                return -1;
        }

        public bool DataIsValid()
        {
            if (_host.ReceiptDate.Trim() != string.Empty &&
                _host.txtSearechPostReceiptSerial.Text.Trim() != string.Empty &&
                _host.txtSearechPostReceiptSeri.Text.Trim() != string.Empty &&
                _host.txtPayerName.Text.Trim() != string.Empty &&
                _host.txtPrice.Text.Trim() != string.Empty &&
                _host.txtSeri.Text.Trim() != string.Empty &&
                _host.txtReceiptSerialNo.Text.Trim() != string.Empty)
                return true;
            else
                return false;
        }

        public void SaveOtherReceiptInfo(int RefID)
        {
            ReceiptClass rc = new ReceiptClass();
            rc.ReceiptSerialNo = _host.txtReceiptSerialNo.Text;
            rc.ReceiptAlphabetSeri = _host.ddlSeri.SelectedValue;
            rc.ReceiptNumberSeri = _host.txtSeri.Text.Trim();
            rc.BankID = Convert.ToInt32(_host.ddl_bank.SelectedValue);
            rc.Price = Convert.ToUInt64(_host.txtPrice.Text);
            rc.PayDate = _host.ReceiptDate;
            rc.InsertTime = DateAndTime.GetTime8Digit();
            rc.PayerName = _host.txtPayerName.Text;
            rc.UserID = UserInfo.UserId;
            rc.ReceiptTypeValue = Convert.ToUInt64(_host.ddlReceiptType.SelectedValue);
            rc.RefID = RefID;
            rc.PostNodeCode = UserInfo.PostNodeCode;
            rc.IsPhish = _host.ddlTypePrice.SelectedValue;
            if (_host.ddlTypePrice.SelectedValue == "0")
            {
                rc.ChequeAccountNo = _host.txtAccountNoCheque.Text.Trim();
                rc.ChequeComment = _host.txtComment.Text.Trim();
                rc.ChequeSaderKonandeh = _host.txtSaderKonandehCheque.Text.Trim();
                rc.ChequeVajh = _host.txtVajehCheque.Text.Trim();
            }
            BI.SaveOtherReceipt(rc);
        }

        public bool DontExistOtherReceipt()
        {
            int MasterReceiptID = MasterReceiptNoIsPerfect();
            if (MasterReceiptID > 0)
                return BI.DontExistOtherReceipt(MasterReceiptID, _host.ddlReceiptType.SelectedValue, UserInfo.UserId, UserInfo.PostNodeCode);
            else
                return false;
        }

        public bool DontSendMasterReceipt()
        {
            int MasterReceiptID = MasterReceiptNoIsPerfect();
            if (MasterReceiptID > 0)
                return !(BI.IsSendToFinancialById(MasterReceiptID.ToString(), UserInfo.UserId));
            else
                return false;
        }

        public string CheckArsenalOfBarcode(out string SelectedID)
        {
            int Disparity = 0;
            string Result = string.Empty;
            SelectedID = "";
            string ReceiptType = _host.ddlReceiptType.SelectedValue;

            switch (ReceiptType)
            {
                case "1":
                case "4":
                    GetSelectedRowIndgBarcodeList(out SelectedID);
                    if (SelectedID.Trim() == string.Empty)
                    {
                        Result = "حداقل یکی از بارکدها باید انتخاب شود.";
                        break;
                    }
                    if (BarcodePriceNotZero(SelectedID) == false)
                    {
                        Result = "حداقل یکی از بارکدهای انتخابی بدون مبلغ می باشد.";
                        break;
                    }
                    Disparity = DisparityPriceByArsenalForPostalComm(SelectedID);
                    if (Disparity < 0)
                        Result = string.Format(" مبلغ فیش ثبت شده {0} ریال کمتر از جمع مبالغ بارکدها میباشد .", Disparity);
                    break;
                case "2":
                    Disparity = DisparityPriceByArsenalForCustomerComm();
                    if (Disparity == -987654)
                        Result = string.Format("فیش ح.س.پست با مشخصات ذکر شده یافت نشد");
                    if (Disparity < 0)
                        Result = string.Format(" مبلغ فیش ثبت شده {0} ریال کمتر از جمع مبالغ ح.س طرف قرارداد میباشد .", Disparity);

                    break;
                case "3":
                    Disparity = DisparityPriceByArsenalForVattax();
                    if (Disparity==-987654)
                        Result = string.Format("فیش ح.س.پست با مشخصات ذکر شده یافت نشد");
                    else if (Disparity < 0)
                        Result = string.Format(" مبلغ فیش ثبت شده {0} ریال کمتر از جمع مبالغ مالیات میباشد .", Disparity);

                    break;

                default:
                    break;
            }

            return Result;
        }

        private bool BarcodePriceNotZero(string SelectedID)
        {
            int Result=0;
            Result = BI.ParcelCodeZeroPrice(SelectedID);
            if (Result == 0)
                return true;
            else
                return false;
        }

        private int DisparityPriceByArsenalForVattax()
        {
            int Vattax = 0;
            int ReceiptPrice = 0;
            int MasterReceiptID = 0;
            try
            {
                MasterReceiptID = MasterReceiptNoIsPerfect();
                if (MasterReceiptID == 0)
                    return -987654;
                Vattax = BI.ReturnVattaxForArsenal(MasterReceiptID);
                ReceiptPrice = Convert.ToInt32(_host.txtPrice.Text);
                return ReceiptPrice - Vattax;
            }
            catch { return -1; }
        }

        private int DisparityPriceByArsenalForPostalComm(string SelectedID)
        {
            int BarcodePrice = 0;
            int ReceiptPrice = 0;
            try
            {
                if (Convert.ToInt32(_host.ddlReceiptType.SelectedValue) == 1)
                    BarcodePrice = BI.ReturnPostalCommForArsenal(SelectedID);
                if (Convert.ToInt32(_host.ddlReceiptType.SelectedValue) == 4)
                    BarcodePrice = BI.ReturnCustomerCommForArsenal(SelectedID);

                ReceiptPrice = Convert.ToInt32(_host.txtPrice.Text);
                return ReceiptPrice - BarcodePrice;
            }
            catch { return -1; }
        }

        private int DisparityPriceByArsenalForCustomerComm()
        {
            int CustomerComm = 0;
            int ReceiptPrice = 0;
            int MasterReceiptID = 0;
            try
            {
                MasterReceiptID = MasterReceiptNoIsPerfect();
                if (MasterReceiptID == 0)
                    return -987654;
                CustomerComm = BI.ReturnCustomerCommForArsenal(MasterReceiptID);
                ReceiptPrice = Convert.ToInt32(_host.txtPrice.Text);
                return ReceiptPrice - CustomerComm;
            }
            catch { return -1; }
        }

        public bool ReceiptIsUnique()
        {
            bool Result = false;
            string NumberSeri = _host.txtSeri.Text.Trim();
            string AlephabetSeri = _host.ddlSeri.SelectedValue;
            string Serial = _host.txtReceiptSerialNo.Text.Trim();
            Result = BI.ReceiptCheckForUnique(Serial, NumberSeri, AlephabetSeri);
            return Result;
        }

        private void IsCheque(bool Result)
        {
            _host.DivtxtAccountNoCheque=
            _host.DivtxtSaderKonandehCheque=
            _host.DivtxtVajehCheque=
            _host.txtComment.Visible =
            _host.DivtxtComment = 
          //  _host.DivtxtSearechPostReceiptSerial=
            _host.lblVajehCheque.Visible =
            _host.txtVajehCheque.Visible =
            _host.lblAccountNoCheque.Visible =
            _host.txtAccountNoCheque.Visible =
            _host.lblSaderKonandehCheque.Visible =
            _host.txtSaderKonandehCheque.Visible =
            _host.lblComment.Visible = Result;
        }

        public void FormItemesVisible(string TypePrice)
        {
            switch (TypePrice)
            {
                case "0":
                    {
                        IsCheque(true);
                        break;
                    }
                case "1":
                    {
                        IsCheque(false);
                        break;
                    }
            }
        }

        public Int64 GetPrice(string ReceiptType, string Serial, string SeriNumber, string SeriHarf)
        {
            Int64 Result = 0;
            try
            {
                Result = BI.GetPriceByReceiptInfo(ReceiptType,Serial,SeriNumber,SeriHarf,UserInfo.PostNodeCode);
                return Result;
            }
            catch { return Result; }
        }

        public void FillddlMovazehSearch()
        {
            Utility.FillCombo(BI.ReturnMovazehSearch( UserInfo.PostNodeCode ), _host.ddlMovazehSearch, "Value", "Title", false);
        }
    }

}
