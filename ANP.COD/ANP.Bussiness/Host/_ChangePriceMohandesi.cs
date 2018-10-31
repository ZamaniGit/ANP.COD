using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ANP.Bussiness.Models;
using ANP.Data.BaseData;
using ANP.Bussiness.Objects;
using ANP.Common;

namespace ANP.Bussiness.Host
{
    public class _ChangePriceMohandesi
    {

        IChangePriceMohandesi _host;
        LoginDetails UserInfo;
        ExchangeDB Data = new ExchangeDB();

        public void Init(IChangePriceMohandesi hostform, LoginDetails LD)
        {
            this._host = hostform;
            UserInfo = LD;
        }
        public void LoadForm()
        {
            
        }

        public void Search()
        {
            if (UserInfo.RoleID==1001)
                LoadGrid();
            else
                LoadGrid_Pate();

            LoadTextBox();
            //ClearText();
        }

        private void LoadTextBox()
        {
            if (_host.MyGrid.Items.Count == 1)
            {
                _host.txtPostPrice.Text = _host.MyGrid.Items[0].Cells[6].Text;
                _host.txtCustomerPrice.Text = _host.MyGrid.Items[0].Cells[7].Text;
                _host.txtVattax.Text = _host.MyGrid.Items[0].Cells[8].Text;
            }
            else
            {
                _host.txtPostPrice.Text = "0";
                _host.txtCustomerPrice.Text = "0";
                _host.txtVattax.Text = "0";
            }
        }

        private void ClearText()
        {
            _host.txtCustomerPrice.Text =
                _host.txtPostPrice.Text =
                _host.txtVattax.Text ="0";
        }

        public void SavePrice()
        {
            Data.EditPrice(_host.txtCustomerPrice.Text.Trim(), _host.txtPostPrice.Text.Trim(), _host.txtVattax.Text.Trim(),UserInfo.UserId, _host.txtBarcode.Text.Trim());
        }

        public void LoadGrid()
        {
            _host.MyGrid.DataSource = Data.LoadParcelsByBarcode(_host.txtBarcode.Text.Trim());
            _host.MyGrid.DataBind();
        }

        public void LoadGrid_Pate()
        {
            _host.MyGrid.DataSource = Data.LoadPateByBarcode(_host.txtBarcode.Text.Trim());
            _host.MyGrid.DataBind();
        }

        //public string DeleteBarcode(string ParcelID)
        //{
        //    string Result = string.Empty;
        //    if (Data.AllowForDelete(ParcelID))
        //    {
        //        Data.DeleteParcel(ParcelID, UserInfo.StateCode, UserInfo.PostNodeCode, UserInfo.RoleID, UserInfo.UserId, DateAndTime.GetDate10Digit());
        //        LoadGrid();
        //    }
        //    else
        //    { Result = "برای مرسوله مورد نظر فیش ثبت شده یا امکان حذف وجود ندارد"; }
        //    return Result;
        //}

        public string AllowUpdatePrice()
        {
            string Message = string.Empty;
            if (Data.IsDeleted(_host.txtBarcode.Text.Trim()))
            {
                Message = "مرسوله مورد نظر حذف شده و امکان تغییر قیمت وجود ندارد";
            }
            else if (Data.IsReceipt(_host.txtBarcode.Text.Trim()))
            {
                Message = "برای مرسوله مورد نظر فیش ثبت شده و امکان تغییر قیمت وجود ندارد";
            }
           return Message;
        }
    }
}