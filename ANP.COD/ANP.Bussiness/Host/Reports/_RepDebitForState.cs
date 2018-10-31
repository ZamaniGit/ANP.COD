using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ANP.Common;
using System.Data;
using ANP.Bussiness.Basic;
using ANP.Data;
using ANP.Data.BaseData.Report;
using ANP.Bussiness.Objects;
using ANP.Bussiness.Models.Reports;

namespace ANP.Bussiness.Host.Reports
{
    public class _RepDebitForState
    {
    
        DBConnector exe = new DBConnector();
        ReportData dal = new ReportData();
        LoginDetails UserInfo;
        IRepDebitForState _host;
        string Query = string.Empty;

        public void InitializeIControlForm(IRepDebitForState hostform, LoginDetails LD)
        {
            this._host = hostform;
            UserInfo = LD;
            
        }

    public void LoadForm()
        {
            try
            {
                FillState();
                FillLastState(UserInfo.RoleID, UserInfo.StateCode);
                FillCity(UserInfo.RoleID, UserInfo.StateCode,0);
                FillPostNode(UserInfo.RoleID, UserInfo.PostNodeCode,0);
                FillBarcodeStatus();
            }
            catch { }
        }

        public void FillBarcodeStatus()
        {
            Utility.FillCombo(dal.ReturnBarcodeStatus(), _host.ddlBarcodeStatus, "Code", "Title", "همه");
        }

        public void FillLastState(int RoleID, int StateCode)
        {
            try
            {
                if (RoleID > 1002)
                    Utility.FillCombo2(dal.ReturnOneState(StateCode), _host.ddlLastState, "CODE", "PNAME", false);
                else if (RoleID <= 1002)
                    Utility.FillCombo2(dal.ReturnState(), _host.ddlLastState, "CODE", "PNAME", false);
            }
            catch { }


        }

        public void FillState()
        {
            try
            {
                Utility.FillCombo2(dal.ReturnState(), _host.ddlState, "CODE", "PNAME", "کل کشور");
            }
            catch { }
        }

        public void FillCity(int RoleID, int CityCode, int Types)
        {
            try
            {
                switch (Types)
                {
                    case 1:
                        Utility.FillCombo2(dal.ReturnCity(_host.ddlState.SelectedValue), _host.ddlCity, "Code", "Pname", "کل شهرها");
                        break;
                    case 2:
                        Utility.FillCombo2(dal.ReturnCity(_host.ddlLastState.SelectedValue), _host.ddlLastCity, "Code", "Pname", "کل شهرها");
                        break;
                    case 0:
                        Utility.FillCombo2(dal.ReturnCity(_host.ddlState.SelectedValue), _host.ddlCity, "Code", "Pname", "کل شهرها");
                        Utility.FillCombo2(dal.ReturnCity(_host.ddlLastState.SelectedValue), _host.ddlLastCity, "Code", "Pname", "کل شهرها");
                        break;
                }
            }
            catch { }
        }

        public void FillPostNode(int RoleID, int PostNode, int Types)
        {
            try
            {
                switch (Types)
                {
                    case 1:
                        Utility.FillCombo2(dal.ReturnPostNodeGhabool(_host.ddlCity.SelectedValue), _host.ddlPostNode, "Code", "Pname", "کل شهر");
                        break;
                    case 2:
                        Utility.FillCombo2(dal.ReturnPostNode(_host.ddlLastCity.SelectedValue), _host.ddlLastPostNode, "Code", "Pname", "کل نقاط مبادله");
                        break;
                    case 0:
                        Utility.FillCombo2(dal.ReturnPostNodeGhabool(_host.ddlCity.SelectedValue), _host.ddlPostNode, "Code", "Pname", "کل شهر");
                        Utility.FillCombo2(dal.ReturnPostNode(_host.ddlLastCity.SelectedValue), _host.ddlLastPostNode, "Code", "Pname", "کل نقاط مبادله");
                        break;
                }
            }
            catch { }
        }

        public DataSet LoadReport()
        {
            try
            {
                string Query =
                    string.Format(@"EXECUTE sp_rptCountDebitForState
                           @FirstState={0},@FirstCity={1},@FirstPostNode={2}
                          ,@LastState={3},@Date1='{4}',@Date2='{5}',@StatusID='{6}',@IsReceipt={7}
                          ,@LastCity={8},@LastPostNode={9}",
                 _host.ddlState.SelectedValue
                 ,_host.ddlCity.SelectedValue
                 ,_host.ddlPostNode.SelectedValue
                 , _host.ddlLastState.SelectedValue
                 ,_host.Fdate
                 ,_host.Ldate
                 ,_host.hfStateList.Value
                 ,_host.ddlIsReceipt.SelectedValue
                 , _host.ddlLastCity.SelectedValue
                 , _host.ddlLastPostNode.SelectedValue);
                return exe.SqlDataSet(Query);
            }
            catch (Exception ex)
            {
                string Query = string.Format(@"EXECUTE sp_FilltblErrorProgrammer
                                       @Message=N'{0}'
                                      ,@DateError='{1}'
                                      ,@PhysicalPath=N'{2}'
                                      ,@UserHostAddress='{3}'
                                      ,@Browser='{4}'"
                    , "Error For Load Report :  rptCountDebitForState ; Detail :  " + ex.Message.Replace("'", "''")
                    , DateAndTime.GetDateTime16Digit_Latin(), "", "", "");
                return exe.SqlDataSet(Query);
            }
        }

        public void ddlState_SelectedIndexChanged()
        {
            FillCity(UserInfo.RoleID, UserInfo.CityCode,1);
            FillPostNode(UserInfo.RoleID, UserInfo.PostNodeCode,1);
        }

        public void ddlCity_SelectedIndexChanged()
        {
            FillPostNode(UserInfo.RoleID, UserInfo.PostNodeCode,1);
        }

        public void ddlLastState_SelectedIndexChanged()
        {
            FillCity(UserInfo.RoleID, UserInfo.CityCode, 2);
            FillPostNode(UserInfo.RoleID, UserInfo.PostNodeCode, 2);
        }        
        
        public void ddlLastCity_SelectedIndexChanged()
        {
            FillPostNode(UserInfo.RoleID, UserInfo.PostNodeCode, 2);

        }
    }
}