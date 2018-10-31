using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using ANP.Data;
using ANP.Bussiness;
using ANP.Common;
using ANP.Bussiness.Objects;
using Prs.Bussiness;
using ANP.Data.Object;
using ANP.Bussiness.Basic;
namespace ANP.Bussiness.Host
{
    public class _BarcodeReceiptEditation
    {
        IBarcodeReceiptEditation _host;
        LoginDetails UserInfo;
        BankReceipt BI = new BankReceipt();


        public void InitializeIBankReceiptRegistration(IBarcodeReceiptEditation hostform, LoginDetails LD)
        {
            this._host = hostform;
            UserInfo = LD;

            Utility.FillCombo(BI.ReturnBankName(), _host.ddl_bank, "ID", "title", false);
            Utility.FillCombo(BI.ReturnAllAlephabetSeri(), _host.ddlSeri, "ID", "title", false);
        }

        public void Load_dgBarcodeList(string ReceiptID)
        {
            _host.dgBarcodeList.DataSource = BI.ReturnAllBarcodeDelivery_BarcodeForMyReceiptID(UserInfo.UserId,ReceiptID,UserInfo.PostNodeCode );
            _host.dgBarcodeList.DataBind();
        }

        public void LoadReceiptInfo(string ReceiptID)
        {
            ReceiptClass rc = new ReceiptClass();
            rc = BI.ReturnReceiptInfoByID(Convert.ToInt32( ReceiptID));
            _host.txtPayerName.Text=rc.PayerName;
            _host.txtPrice.Text=rc.Price.ToString();
            _host.txtReceiptNo.Text = rc.ReceiptSerialNo;
            _host.txtSeri.Text = rc.ReceiptNumberSeri;
            _host.ddlSeri.SelectedValue= rc.ReceiptAlphabetSeri;
            _host.ddl_bank.SelectedValue=rc.BankID.ToString();
            _host.ReceiptDate=rc.PayDate;
            _host.txtSaderKonandehCheque.Text = rc.ChequeSaderKonandeh;
            _host.txtAccountNoCheque.Text = rc.ChequeAccountNo;
            _host.txtVajehCheque.Text = rc.ChequeVajh;
            _host.txtComment.Text = rc.ChequeComment;
            _host.ddlTypePrice.SelectedValue=(rc.IsPhish=="0"?"0":"1");

            FormItemesVisible(_host.ddlTypePrice.SelectedValue);
        }

        public void GetSelectedRowIndgBarcodeList(out string SelectedID)
        {
            SelectedID = string.Empty;
            SelectedID = GetidOfSelectedRow();
        }

        public void GetDontSelectedRowIndgBarcodeList(out string DontSelectedID)
        {
            DontSelectedID = string.Empty;
            DontSelectedID = GetidOfDontSelectedRow();
        }

        private string GetidOfSelectedRow()
        {
            string Result = string.Empty;

            foreach (DataGridItem item in _host.dgBarcodeList.Items)
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    if (((CheckBox)item.Cells[2].FindControl("chkHeaderSelect")).Checked)
                            Result += item.Cells[0].Text + ",";

            Result = Result.TrimEnd(',');
            return Result;
        }

        private string GetidOfDontSelectedRow()
        {
            string Result = string.Empty;

            foreach (DataGridItem item in _host.dgBarcodeList.Items)
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    if (((CheckBox)item.Cells[2].FindControl("chkHeaderSelect")).Checked==false)
                            Result += item.Cells[0].Text + ",";

            Result = Result.TrimEnd(',');
            return Result;
        }

        private ReceiptClass FillReceiptObject()
        {
            ReceiptClass _Receipt = new ReceiptClass();
            _Receipt.BankID = Convert.ToInt32(_host.ddl_bank.SelectedValue);
            _Receipt.PayerName = _host.txtPayerName.Text.Trim();
            _Receipt.Price = Convert.ToUInt64(_host.txtPrice.Text.Trim());
            _Receipt.ReceiptSerialNo = _host.txtReceiptNo.Text.Trim();
            _Receipt.ReceiptNumberSeri = _host.txtSeri.Text.Trim();
            _Receipt.ReceiptAlphabetSeri = _host.ddlSeri.SelectedValue;
            _Receipt.PayDate = _host.ReceiptDate;
            _Receipt.UserID = UserInfo.UserId;
            return _Receipt;
        }

        public string UpdateInfo(string SelectedID, string DontSelectedID,string RceiptID)
        {
            string Result = "";
            try
            {
                ReceiptClass _Receipt = FillReceiptObject();
                if (DontDisparityPriceWithArsenal(SelectedID, RceiptID) > -1)
                {
                    if (BI.IsExistEqualOtherReceipt(_Receipt.ReceiptSerialNo, _Receipt.ReceiptNumberSeri, _Receipt.ReceiptAlphabetSeri, RceiptID))
                    {
                        Result = "این فیش قبلا ثبت شده لطفا اطلاعات فیش را بررسی نمایید .";
                        return Result;
                    }
                    BI.UpdateReceipt(_Receipt, RceiptID, DateAndTime.GetDate10Digit_latin(), DateAndTime.GetTime8Digit(), DateAndTime.GetDate10Digit());
                    BI.UpdateReceiptidInParcelList(SelectedID, DontSelectedID, RceiptID, DateAndTime.GetSQLDateTimeDigitMiladi(), DateAndTime.GetSQLDate10DigitShamsi());
                    Result = "";
                }
                else { Result = "مبلغ فیش از مبالغ مرسولات کمتر است ."; }
            }
            catch { Result = "مشکل در بروز رسانی اطلاعات."; }
            return Result;
        }

        private int DontDisparityPriceWithArsenal(string SelectedID, string RceiptID)
        {
            int Result = -1;
            int PostalComm = 0;
            int PostalReceipt = 0;
            try
            {
                PostalComm = BI.ReturnPostalCommForArsenal(SelectedID);
                PostalReceipt = BI.ReturnPostalCommPriceForReceipt(RceiptID,_host.txtPrice.Text);
                Result = PostalReceipt - PostalComm;
            }
            catch { Result = -1; }
            return Result;
        }

        private void IsCheque(bool Result)
        {
            _host.txtComment.Visible =
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
    }
}
