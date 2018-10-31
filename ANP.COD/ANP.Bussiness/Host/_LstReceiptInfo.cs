using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ANP.Data;
using ANP.Bussiness.Models;
using ANP.Bussiness.Objects;

namespace ANP.Bussiness.Host
{
    public class _LstReceiptInfo
    {
        ILstReceiptInfo _host;
        LoginDetails UserInfo;
        ReceiptInfo BI = new ReceiptInfo();
        public void Init(ILstReceiptInfo hostform, LoginDetails LD)
        {
            this._host = hostform;
            UserInfo = LD;
        }
        public void Load_MyGrid()
        {           
            _host.MyGrid.DataSource = BI.SearchResult(_host.txt_ReceiptInfo.Text.Trim(),UserInfo.StateCode);
            _host.MyGrid.DataBind();
        }
    }
}
