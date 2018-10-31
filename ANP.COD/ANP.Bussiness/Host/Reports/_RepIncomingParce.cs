using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ANP.Data;
using ANP.Data.BaseData.Report;
using ANP.Bussiness.Objects;
using ANP.Bussiness.Basic;
using ANP.Bussiness.Models;
using System.Data;
using ANP.Common;

namespace ANP.Bussiness.Host.Reports
{
    public class _RepIncomingParce
    {

        DBConnector exe = new DBConnector();
        ReportData dal = new ReportData();
        LoginDetails UserInfo;
        IRepIncomingParcel _host;
        string Query = string.Empty;

        public void InitializeIControlForm(IRepIncomingParcel hostform, LoginDetails LD)
        {
            this._host = hostform;
            UserInfo = LD;
        }

        public void LoadForm()
        {
            try
            {
                FillFirstState(UserInfo.RoleID); //رول برای کل کشور باشد یا نباشد بکار میرود
                FillLastState(UserInfo.RoleID);
                FillLastCity(UserInfo.RoleID);
                FillLastPostNode(UserInfo.RoleID);
                FillExchangeState();
               // FillReceiptState();
                FillGlobalContract(UserInfo.StateCode);
            }
            catch { }
        }

        public void FillGlobalContract(int GC)
        {
            Utility.FillCombo(dal.ReturnGlobalContract(), _host.ddlGC, "CODE", "Title", false);    
        }

        //public void FillReceiptState()
        //{
        //    Utility.FillCombo(dal.ReturnReceiptState(), _host.ddlReceiptState, "Flag", "Title", "همه");    
        //}

        public void FillExchangeState()
        {
            Utility.FillCombo(dal.ReturnBarcodeStatus(), _host.ddlExchangeState, "CODE", "Title", "همه");    

        }

        public void FillLastPostNode(int RoleID)
        {
            if (RoleID > 1004)
            Utility.FillCombo(dal.ReturnPostNode(_host.ddlLastCity.SelectedValue), _host.ddlLastPostNode, "CODE", "PNAME", false);    
            else
                Utility.FillCombo(dal.ReturnPostNode(_host.ddlLastCity.SelectedValue), _host.ddlLastPostNode, "CODE", "PNAME", "کل نقاط شهر");    
        }

        public void FillLastCity(int RoleID)
        {
            try
            {
                if (RoleID > 1004)
                    Utility.FillCombo(dal.ReturnCity(_host.ddlLastState.SelectedValue), _host.ddlLastCity, "CODE", "PNAME", false);
                else
                    Utility.FillCombo(dal.ReturnCity(_host.ddlLastState.SelectedValue), _host.ddlLastCity, "CODE", "PNAME", "کل استان");
            }
            catch { }
        }

        public void FillLastState(int RoleID)
        {
            try
            {
                if (RoleID > 1001)
                    Utility.FillCombo(dal.ReturnOneState(UserInfo.StateCode), _host.ddlLastState, "CODE", "PNAME", false);
                else
                    Utility.FillCombo(dal.ReturnState(), _host.ddlLastState, "CODE", "PNAME", "کل کشور");
            }
            catch { }
        }

        public void FillFirstState(int RoleID)
        {
            try
            {
                    Utility.FillCombo(dal.ReturnState(), _host.ddlFirstState, "CODE", "PNAME", "کل کشور");
            }
            catch { }
        }

        public DataTable LoadReport()
        {
            DataTable dt = new DataTable();
            try
            {
                string Query =
                    string.Format(@"EXECUTE sp_rptStateIncomingParcels
                                               @fDate='{0}'  ,@lDate='{1}'  ,@LastStateCode={2}  ,@LastCityCode={3}  
                                               ,@LastPostNode={4},@FirstStateCode={5}  ,@ReceiptState='{6}'  ,@ExchangeState={7}
                                               ,@ServiceType={8} ,@IsContract='{9}'  ,@GContractID={10}  ,@RoleID={11}",
                 _host.Fdate, _host.Ldate, _host.ddlLastState.SelectedValue, _host.ddlLastCity.SelectedValue
                 , _host.ddlLastPostNode.SelectedValue, _host.ddlFirstState.SelectedValue, _host.ddlReceiptState.SelectedValue
                 , _host.ddlExchangeState.SelectedValue
                 , _host.ddlServiceType.SelectedValue, _host.ddlContractType.SelectedValue, _host.ddlGC.SelectedValue,UserInfo.RoleID);
                dt= exe.SqlDataTable(Query);
                return dt;
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
                exe.SqlDataSet(Query);
                return dt;
            }
        }
    }
}

//ddlFirstState
//lblExchangeState
//ddlReceiptState
//ddlLastState
//ddlLastCity
//ddlLastPostNode
//ddlGC