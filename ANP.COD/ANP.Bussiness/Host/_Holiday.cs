using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ANP.Bussiness.Models;
using ANP.Common;
using ANP.Data;
using ANP.Data.BaseData;
using ANP.Bussiness.Objects;

namespace ANP.Bussiness.Host
{
    public class _Holiday
    {
        IHoliday _host;
        LoginDetails UserInfo;
        Base BI = new Base();


        public void InitializeIHoliday(IHoliday hostform, LoginDetails LD)
        {
            this._host = hostform;
            UserInfo = LD;
        }

        public void LoadMyGrid()
        {
            _host.MyGrid.DataSource = BI.ReturnHolidayList();
            _host.MyGrid.DataBind();
        }

        public void SaveData()
        {
            string Date=_host.MyDate;
            string Detail=_host.txtDetail.Text;

            BI.SaveNewHoliday (Date, Detail, UserInfo.UserId);
        }
    }
}
