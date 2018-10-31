using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ANP.Bussiness.Models;
using ANP.Data;
using ANP.Bussiness.Objects;

namespace ANP.Bussiness.Host
{
    public class _FinancialMood
    {
        IFinancialMood _host;
        LoginDetails UserInfo;
        ANP.Data.BaseData.Base BI = new ANP.Data.BaseData.Base();
        

        public void InitializeIFinancialMood(IFinancialMood hostform, LoginDetails LD)
        {
            this._host = hostform;
            UserInfo = LD;
        }

        public void LoadMyGrid()
        {
            _host.MyGrid.DataSource = BI.ReturnFinancialMoodList();
            _host.MyGrid.DataBind();
        }

        public void SaveData()
        {
            string Detail = _host.txtDetail.Text;
            BI.SaveNewFinancialMood(Detail);
            _host.txtDetail.Text = string.Empty;
        }
    }
}
