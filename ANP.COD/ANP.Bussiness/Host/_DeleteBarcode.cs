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
    public class _DeleteBarcode
    {
        IDeleteBarcode _host;
        LoginDetails UserInfo;
        ExchangeDB Data = new ExchangeDB();

        public void Init(IDeleteBarcode hostform, LoginDetails LD)
        {
            this._host = hostform;
            UserInfo = LD;
        }

        public void LoadForm()
        {

        }
        public string InsertRequestForDeleteBarcode()
        {
            string Result = string.Empty;
            Result = Data.ValidationForRequestDelete(_host.txtBarcode.Text.Trim(), UserInfo.StateCode);
           // Result = Data.ErrorForDelete(Barcode, UserInfo.StateCode);
            if (Result == string.Empty)
            {
                Result=Data.Request_DelParcel(UserInfo.RoleID, _host.txtBarcode.Text.Trim(), UserInfo.UserId, UserInfo.StateCode, _host.txtComment.Text.Trim(), 10);
            }
            return Result;
        }

        private void ClearText()
        {
            _host.txtBarcode.Text =
                _host.txtComment.Text = string.Empty;
        }
    }
}