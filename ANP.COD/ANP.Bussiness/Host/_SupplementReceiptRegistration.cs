using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ANP.Data;
using ANP.Bussiness;
using ANP.Common;
using ANP.Bussiness.Models;
using ANP.Bussiness.Objects;
using ANP.Data.Object;
using ANP.Bussiness.Basic;

namespace ANP.Bussiness.Host
{
    public class _SupplementReceiptRegistration
    {
        ISupplementReceiptRegistration _host;
        LoginDetails UserInfo;
        BankReceipt BI = new BankReceipt();
        ReceiptClass RC = new ReceiptClass();
        string ParentSerialNo = string.Empty;
        string ParentNumberSeri = string.Empty;
        string ParentSeriAlphabet = string.Empty;

        public void Init(ISupplementReceiptRegistration hostform, LoginDetails LD, string ID,string Mode, bool IsSup,bool IsPostBack)
        {
            IsSup = false;
            this._host = hostform;
            UserInfo = LD;


            if (!IsPostBack)
            {
                Utility.FillCombo(BI.ReturnBankName(), _host.ddl_bank, "ID", "title", false);
                Utility.FillCombo(BI.ReturnReceiptType(), _host.ddlReceiptType, "Value", "Title", false);
                Utility.FillCombo(BI.ReturnAllAlephabetSeri(), _host.ddlSeri, "ID", "Title", false);

                if (ID != "0" && Mode == "S"){
                    BI.ReturnReceiptNoByReceiptID(Convert.ToInt32(ID), out ParentSerialNo, out ParentNumberSeri, out ParentSeriAlphabet);
                    _host.txtParentReceiptID.Text =ParentSerialNo;
                    _host.txtParentSeri.Text=ParentNumberSeri;
                    _host.txtParentSeriAlphabet.Text=ParentSeriAlphabet;
                }
                else if (ID != "0" && Mode == "E")
                    IsSup = LoadDataForEdit(ID);

                _host.ddlReceiptType.SelectedValue = BI.ReturnReceiptTypeValueByID(ID);
                
                //_host.lblSlash.Visible =
                //_host.txtParentSeri.Visible =
                //_host.txtParentSeriAlphabet.Visible=
                //_host.lblParentReceipt.Visible =
                //_host.txtParentReceiptID.Visible = IsSup;
            }
        }

        private bool LoadDataForEdit(string ID)
        {
            try
            {
                ReceiptClass rc = new ReceiptClass();
                rc = BI.ReturnReceiptInfoByID(Convert.ToInt32(ID));
                //if (rc.ParentID == 0)
                //    _host.txtParentSeri.Text=
                //        _host.txtParentSeriAlphabet.Text=
                //        _host.txtParentReceiptID.Text = "0";
                //else
                //{
                if(rc.IsSupplementReceipt=="Y")
                    BI.ReturnParentReceiptNoByReceiptID(rc.IsSupplementReceipt,rc.ParentID, out ParentSerialNo, out ParentNumberSeri, out ParentSeriAlphabet);
                else
                    BI.ReturnParentReceiptNoByReceiptID(rc.IsSupplementReceipt,Convert.ToUInt64(rc.RefID), out ParentSerialNo, out ParentNumberSeri, out ParentSeriAlphabet);


                    _host.txtParentReceiptID.Text = ParentSerialNo;
                    _host.txtParentSeri.Text = ParentNumberSeri;
                    _host.txtParentSeriAlphabet.Text = ParentSeriAlphabet;
                //}
                _host.txtReceiptNo.Text = rc.ReceiptSerialNo;
                _host.txtPayerName.Text = rc.PayerName;
                _host.txtPrice.Text = rc.Price.ToString();
                _host.PayDate = rc.PayDate;
                _host.ddl_bank.SelectedValue = rc.BankID.ToString();
                _host.ddlReceiptType.SelectedValue = rc.ReceiptTypeValue.ToString();
                _host.ddlSeri.SelectedValue = rc.ReceiptAlphabetSeri;
                _host.txtSeri.Text = rc.ReceiptNumberSeri;
                //_host.ddlTypePrice.SelectedValue = (rc.IsPhish == "Y" ? "1" :"0");
                _host.ddlTypePrice.SelectedValue = rc.IsPhish;
                _host.txtSaderKonandehCheque.Text=rc.ChequeSaderKonandeh;
                _host.txtVajehCheque.Text=rc.ChequeVajh;
                _host.txtComment.Text=rc.ChequeComment;
                _host.txtAccountNoCheque.Text = rc.ChequeAccountNo;
                FormItemesVisible(rc.IsPhish);

                if (rc.IsSupplementReceipt == "Y")
                    return true;
                else return false;
            }
            catch { return false; }
        }

        private ReceiptClass FillReceiptObject(int ParentReceiptID)
        {
            ReceiptClass rc = new ReceiptClass();
            rc.ApproveFlag = "A";
            rc.UserID = UserInfo.UserId;
            rc.ParentID =Convert.ToUInt64( ParentReceiptID);
            rc.ReceiptSerialNo = _host.txtReceiptNo.Text;
            rc.ReceiptNumberSeri = _host.txtSeri.Text;
            rc.ReceiptAlphabetSeri = _host.ddlSeri.SelectedValue;
            rc.Price = Convert.ToUInt64(_host.txtPrice.Text);
            rc.PayerName = _host.txtPayerName.Text;
            rc.PayDate = _host.PayDate;
            rc.IsSupplementReceipt = "Y";
            rc.InsertTime = DateAndTime.GetTime8Digit();
            rc.Description = "";
            rc.Deleted = "N";
            rc.IsPhish = _host.ddlTypePrice.SelectedValue;
            if (rc.IsPhish == "0")
            {
                rc.ChequeVajh = _host.txtVajehCheque.Text.Trim();
                rc.ChequeAccountNo = _host.txtAccountNoCheque.Text.Trim();
                rc.ChequeComment = _host.txtComment.Text.Trim();
                rc.ChequeSaderKonandeh = _host.txtSaderKonandehCheque.Text.Trim();
            }
            rc.BankID = Convert.ToInt32(_host.ddl_bank.SelectedValue);
            rc.ApproveDate = DateAndTime.GetDate10Digit();
            rc.RefID=BI.ReturnRefIDByID(Convert.ToUInt64( ParentReceiptID));
            rc.ReceiptTypeValue = Convert.ToUInt64(BI.ReturnReceiptTypeValueByID(ParentReceiptID.ToString()));
            return rc;
        }

        private ReceiptClass FillOtherReceiptObject(UInt64 ReceiptID)
        {
            ReceiptClass rc = new ReceiptClass();
            rc.ApproveFlag = "A";
            rc.UserID = UserInfo.UserId;
            rc.PostNodeCode = UserInfo.PostNodeCode;
            rc.ParentID =ReceiptID;
            rc.ReceiptSerialNo = _host.txtReceiptNo.Text;
            rc.ReceiptNumberSeri = _host.txtSeri.Text;
            rc.ReceiptAlphabetSeri = _host.ddlSeri.SelectedValue;
            rc.Price = Convert.ToUInt64(_host.txtPrice.Text);
            rc.PayerName = _host.txtPayerName.Text;
            rc.IsPhish = _host.ddlTypePrice.SelectedValue;
            if (rc.IsPhish == "0")
            {
                rc.ChequeVajh = _host.txtVajehCheque.Text.Trim();
                rc.ChequeAccountNo = _host.txtAccountNoCheque.Text.Trim();
                rc.ChequeComment = _host.txtComment.Text.Trim();
                rc.ChequeSaderKonandeh = _host.txtSaderKonandehCheque.Text.Trim();
            }
            rc.PayDate = _host.PayDate;
            rc.IsSupplementReceipt = "Y";
            rc.InsertTime = DateAndTime.GetTime8Digit();
            rc.Description = "";
            rc.Deleted = "N";
            rc.BankID = Convert.ToInt32(_host.ddl_bank.SelectedValue);
            rc.ApproveDate = DateAndTime.GetDate10Digit();
            rc.RefID = BI.ReturnRefIDByID(ReceiptID);
            rc.ReceiptTypeValue = Convert.ToUInt64(BI.ReturnReceiptTypeValueByID(ReceiptID.ToString()));
            return rc;
        }

        public void SaveSupplementForOtherReceipt(UInt64 ReceiptID)
        {
            RC = FillOtherReceiptObject(ReceiptID);
            BI.InsertSupplementReceipt(RC);
        }

        public void SaveSupplementReceipt(int ParentReceiptID)
        {
            RC = FillReceiptObject(ParentReceiptID);
            BI.InsertSupplementReceipt(RC);
        }

        public void UpdateSupplementReceipt(int ID)
        {
            RC = FillSupplementReceipt(ID);
            BI.UpdateSupplementReceipt(RC, DateAndTime.GetDate10Digit_latin(), DateAndTime.GetTime8Digit(), DateAndTime.GetDate10Digit());
        }

        private ReceiptClass FillSupplementReceipt(int ID)
        {
            ReceiptClass rc = new ReceiptClass();
            rc.ID = ID;
            rc.BankID = Convert.ToInt32(_host.ddl_bank.SelectedValue);
            rc.ParentID = Convert.ToUInt64(_host.txtParentReceiptID.Text);
            rc.PayDate = _host.PayDate;
            rc.PayerName = _host.txtPayerName.Text;
            rc.ReceiptSerialNo = _host.txtReceiptNo.Text;
            rc.ReceiptNumberSeri = _host.txtSeri.Text;
            rc.ReceiptAlphabetSeri = _host.ddlSeri.SelectedValue;
            rc.Price = Convert.ToUInt64(_host.txtPrice.Text);
            rc.UserID = UserInfo.UserId;
            rc.IsPhish = _host.ddlTypePrice.SelectedValue;
            if (rc.IsPhish == "0")
            {
                rc.ChequeVajh = _host.txtVajehCheque.Text.Trim();
                rc.ChequeAccountNo = _host.txtAccountNoCheque.Text.Trim();
                rc.ChequeComment=_host.txtComment.Text.Trim();
                rc.ChequeSaderKonandeh = _host.txtSaderKonandehCheque.Text.Trim();
            }
            return rc;
        }


        public int DisparityPriceForUpdateSupp(string ReceiptID, string ReceiptType)
        {
            return BI.DisparityPriceForUpdate(ReceiptID, _host.txtParentReceiptID.Text, ReceiptType, _host.txtPrice.Text);
        }

        public int DisparityPriceForSaveSupp(string ParentID, string ReceiptType)
        {
            return BI.DisparityPriceForSaveSupp(ParentID, ReceiptType, _host.txtPrice.Text);
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

        public bool IsExistEqualOtherReceipt(string txtReceiptNo, string txtSeri, string ddlSeri, string ReceiptID)
        {
            return BI.IsExistEqualOtherReceipt(txtReceiptNo, txtSeri, ddlSeri, ReceiptID);
        }

        public bool ReceiptCheckForUnique(string txtReceiptNo, string txtSeri, string ddlSeri)
        {
            return BI.ReceiptCheckForUnique(txtReceiptNo, txtSeri, ddlSeri);
        }
    }
}
