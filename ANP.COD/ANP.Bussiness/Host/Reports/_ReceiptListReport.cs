using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ANP.Bussiness.Models.Reports;
using ANP.Bussiness.Objects;
using ANP.Data.BaseData.Report;
using ANP.Common;

namespace ANP.Bussiness.Host.Reports
{
    public class _ReceiptListReport 
    {
        string Query = string.Empty;
        IReceiptListReport _host;
        LoginDetails UserInfo;
        ReportData dal = new ReportData();

        public void Init(IReceiptListReport hostform, LoginDetails LD)
        {
            this._host = hostform;
            UserInfo = LD;
        }
    }
}
