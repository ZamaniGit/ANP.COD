using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ANP.Bussiness.Models.Reports;
using ANP.Bussiness.Objects;
using ANP.Data.BaseData.Report;
using ANP.Data.BaseData;
using ANP.Bussiness.Basic;
using ANP.Common;

namespace ANP.Bussiness.Host.Reports
{
    public class _RegistrationReceiptListReport
    {
        string Query = string.Empty;
        IRegistrationReceiptListReport _host;
        LoginDetails UserInfo;
        ReportData dal = new ReportData();
        Base baseDAL = new Base();

        public void Init(IRegistrationReceiptListReport hostform, LoginDetails LD)
        {
            this._host = hostform;
            UserInfo = LD;
            if (UserInfo.RoleID == 1006)
                FillDataForUser();
        }

        private void FillDataForUser()
        {
            //_host.ddlCounty.SelectedValue = UserInfo.CountyCode.ToString();
            _host.ddlCity.SelectedValue = UserInfo.CityCode.ToString();
            _host.ddlPostNode.SelectedValue = UserInfo.PostNodeCode.ToString();

            _host.ddlCounty.Enabled =
                _host.ddlCity.Enabled =
                 _host.ddlPostNode.Enabled = false;
        }

        public void FillControls()
        {
            FillCounty();
            FillCity();
            FillPostNode();
        }
        public void FillCounty()
        {
            Utility.FillCombo(baseDAL.ReturnCounty(UserInfo.StateCode.ToString()), _host.ddlCounty, "code", "pname", true);        
        }

        public void FillCity()
        {
            Utility.FillCombo(baseDAL.ReturnCity(_host.ddlCounty.SelectedValue ,UserInfo.StateCode.ToString()), _host.ddlCity, "code", "pname", true);
        }

        public void FillPostNode()
        {
            Utility.FillCombo(baseDAL.ReturnPostnode(_host.ddlCity.SelectedValue), _host.ddlPostNode, "code", "pname", true);
        }
    }
}
