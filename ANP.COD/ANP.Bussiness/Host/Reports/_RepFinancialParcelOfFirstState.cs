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
using ANP.Data;
using System.Data;

namespace ANP.Bussiness.Host.Reports
{
    public class _RepFinancialParcelOfFirstState 
    {
        DBConnector exe = new DBConnector();
        ReportData dal = new ReportData();
        LoginDetails UserInfo;
        IRepFinancialParcelOfFirstState _host;
        string Query = string.Empty;

        public void InitializeIControlForm(IRepFinancialParcelOfFirstState hostform, LoginDetails LD)
        {
            this._host = hostform;
            UserInfo = LD;
            
        }

        public void LoadForm()
        {
            try
            {
                FillState(UserInfo.RoleID, UserInfo.StateCode);
                FillCity(UserInfo.RoleID, UserInfo.CityCode);
                FillPostNode(UserInfo.RoleID, UserInfo.PostNodeCode);
                FillLastState();
                FillLastCity();
                FillLastPostNode();
                FillBarcodeStatus();
                FillBarcodeSubStatus();
            }
            catch { }
        }

        public void FillBarcodeStatus()
        {
            Utility.FillCombo(dal.ReturnBarcodeStatus(), _host.ddlBarcodeStatus, "Code", "Title", "همه");
        }

        public void FillBarcodeSubStatus()
        {
            Utility.FillCombo(dal.ReturnBarcodeSubStatus(_host.ddlBarcodeStatus.SelectedValue), _host.ddlBarcodeSubStatus, "Code", "Title", "همه");
        }

        public void FillLastState()
        {
            try
            {
                Utility.FillCombo2(dal.ReturnState(), _host.ddlLastState, "CODE", "PNAME", "کل کشور");
            }
            catch { }
        }

        public void FillLastCity()
        {
            try
            {
                Utility.FillCombo2(dal.ReturnCity(_host.ddlLastState.SelectedValue), _host.ddlLastCity, "Code", "Pname", "کل استان");
            }
            catch { }
        }

        public void FillLastPostNode()
        {
            try
            {
                Utility.FillCombo2(dal.ReturnPostNode(_host.ddlLastCity.SelectedValue), _host.ddlLastPostNode, "Code", "Pname", "کل شهر");
            }
            catch { }
        }

        public void FillState(int RoleID, int StateCode)
        {
            try
            {
                if (RoleID > 1002)
                    Utility.FillCombo2(dal.ReturnOneState(StateCode), _host.ddlState, "CODE", "PNAME", false);
                else if (RoleID <= 1002)
                    Utility.FillCombo2(dal.ReturnState(), _host.ddlState, "CODE", "PNAME",false);
            }
            catch { }
        }

        public void FillCity(int RoleID, int CityCode)
        {
            try
            {
                //if (RoleID > 1004)
                //    Utility.FillCombo2(dal.ReturnOneCity(_host.ddlState.SelectedValue, CityCode), _host.ddlCity, "Code", "Pname", false);
                //else if (RoleID <= 1004)
                    Utility.FillCombo2(dal.ReturnCity(_host.ddlState.SelectedValue), _host.ddlCity, "Code", "Pname", "کل استان");
            }
            catch { }
        }

        public void FillPostNode(int RoleID, int PostNode)
        {
            try
            {
                Utility.FillCombo2(dal.ReturnPostNodeGhabool(_host.ddlCity.SelectedValue), _host.ddlPostNode, "Code", "Pname", "کل شهر");

                //if (RoleID <= 1004)
                //    Utility.FillCombo2(dal.ReturnPostNodeGhabool(_host.ddlCity.SelectedValue), _host.ddlPostNode, "Code", "Pname", "کل شهر");
                //else if (RoleID > 1004)
                //    Utility.FillCombo2(dal.ReturnPostNodeGhabool(_host.ddlCity.SelectedValue, PostNode), _host.ddlPostNode, "Code", "Pname", false);

            }
            catch { }
        }


        public DataTable LoadReport()
        {
            try
            {
                string Query =
                    string.Format(@"EXECUTE sp_rptFinancialParcelOfFirstState
                           @FirstState={0},@FirstCity={1},@FirstPostNode={2}
                          ,@LastState={3},@LastCity={4},@LastPostNode={5}
                          ,@FirstDate='{6}',@LastDate='{7}',@PayType={8},@BarcodeStatus={9}",
                 _host.ddlState.SelectedValue
                 ,_host.ddlCity.SelectedValue
                 ,_host.ddlPostNode.SelectedValue
                 ,_host.ddlLastState.SelectedValue
                 ,_host.ddlLastCity.SelectedValue
                 ,_host.ddlLastPostNode.SelectedValue
                 ,_host.Fdate
                 ,_host.Ldate
                 ,_host.ddlCredit.SelectedValue
                 ,_host.ddlBarcodeStatus.SelectedValue);
                return exe.SqlDataTable(Query);
            }
            catch (Exception ex)
            {
                string Query = string.Format(@"EXECUTE sp_FilltblErrorProgrammer
                                       @Message=N'{0}'
                                      ,@DateError='{1}'
                                      ,@PhysicalPath=N'{2}'
                                      ,@UserHostAddress='{3}'
                                      ,@Browser='{4}'"
                    , "Error For Load Report :  rptBarcodeDetail ; Detail :  " + ex.Message.Replace("'", "''")
                    , DateAndTime.GetDateTime16Digit_Latin(), "", "", "");
                return exe.SqlDataTable(Query);
            }
        }

        public void ddlState_SelectedIndexChanged()
        {
            FillCity(UserInfo.RoleID, UserInfo.CityCode);
            FillPostNode(UserInfo.RoleID, UserInfo.PostNodeCode);
        }

        public void ddlCity_SelectedIndexChanged()
        {
            FillPostNode(UserInfo.RoleID, UserInfo.PostNodeCode);
        }

        public void ddlLastState_SelectedIndexChanged()
        {
            FillLastCity();
            FillLastPostNode();
        }

        public void ddlLastCity_SelectedIndexChanged()
        {
            FillLastPostNode();
        }
    }
}