using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ANP.Bussiness.Basic;
using ANP.Data.BaseData.Report;
using ANP.Bussiness.Models.Reports;
using ANP.Bussiness.Objects;
using ANP.Data.BaseData;

namespace ANP.Bussiness.Host.Reports
{
    public class _ControlForm
    {
        ReportData dal = new ReportData();
        LoginDetails UserInfo;
        IControlForm _host;
        string Query = string.Empty;

        public void InitializeIControlForm(IControlForm hostform, LoginDetails LD)
        {
            this._host = hostform;
            UserInfo = LD;
        }

        public void FillState(int RoleID,int StateCode,string Address)
        {
            try
            {

                if ((RoleID <= 1002) || (Address == "4a1b4e3f-46cd-42da-b0ce-88577fa18085") )
                    Utility.FillCombo2(dal.ReturnState(), _host.ddlState, "CODE", "PNAME", "کل کشور");
                 else if (RoleID > 1002)
                    Utility.FillCombo2(dal.ReturnOneState(StateCode), _host.ddlState, "CODE", "PNAME", false);    
                //Utility.FillCombo2(dal.ReturnState(), _host.ddlState, "CODE", "PNAME", "کل کشور");
                //if (RoleID > 1001)
                //{
                //    _host.ddlState.SelectedValue = StateCode.ToString();
                //    _host.trState = false;
                //}
            }
            catch { }
        }

        public void FillCity(int RoleID, int CityCode)
        {
            try
            {
            if (RoleID > 1004)
                Utility.FillCombo2(dal.ReturnOneCity(_host.ddlState.SelectedValue, CityCode), _host.ddlCity, "Code", "Pname",false);
            else if (RoleID <= 1004)
                Utility.FillCombo2(dal.ReturnCity(_host.ddlState.SelectedValue), _host.ddlCity, "Code", "Pname", "کل استان");
            }
            catch { }
            //Utility.FillCombo2(dal.ReturnCity(_host.ddlState.SelectedValue), _host.ddlCity, "Code", "Pname", "کل استان");
            //if (RoleID == 1006)
            //{
            //    _host.ddlCity.SelectedValue = CityCode.ToString();
            //    _host.trCity = false;
            //}
        }

        public void FillPostNode(int RoleID, int PostNode)
        {
            try
            {
                if (RoleID <= 1004)
                    Utility.FillCombo2(dal.ReturnPostNode(_host.ddlCity.SelectedValue), _host.ddlPostNode, "Code", "Pname", "کل شهر");
                else if (RoleID > 1004)
                    Utility.FillCombo2(dal.ReturnOnePostNode(_host.ddlCity.SelectedValue, PostNode), _host.ddlPostNode, "Code", "Pname", false);
            }
            catch { }
        }

        public void FillPostNode_Ghabool(int RoleID, int PostNode)
        {
            try
            {
                Utility.FillCombo2(dal.ReturnPostNodeGhabool(_host.ddlCity.SelectedValue), _host.ddlPostNode, "Code", "Pname", "کل شهر");
            }
            catch { }
        }

        public void FillUser(int RoleID, int UserID)
        {
            try{
            Utility.FillCombo(dal.ReturnUser(UserInfo.RoleID,UserInfo.UserId,UserInfo.StateCode,UserInfo.PostNodeCode
                ,Convert.ToInt32( _host.ddlState.SelectedValue),Convert.ToInt32(_host.ddlCity.SelectedValue)
                , Convert.ToInt32(_host.ddlPostNode.SelectedValue)), _host.ddlUser, "UserID", "Name", "تمام کاربران");
            }
            catch { }
            //Utility.FillCombo(dal.ReturnUser( _host.ddlState.SelectedValue,_host.ddlCity.SelectedValue, _host.ddlPostNode.SelectedValue), _host.ddlUser, "UserID", "Name", "تمام کاربران");
            //if (RoleID == 1006)
            //{
            //    _host.ddlUser.SelectedValue = UserID.ToString();
            //    _host.ddlUser.Enabled = false;
            //}
        }

        public void FillReceiptSeriAlepha()
        {
            Utility.FillCombo(dal.ReturnReceiptSeriAlepha(), _host.ddlReceiptSeriAlepha, "ID", "Title", false);
        }

        public void FillReceiptType()
        {
            Utility.FillCombo(dal.ReturnReceiptType(), _host.ddlReceiptType, "Value", "Title","همه");
        }

        public void FillReceiptState()
        {
            Utility.FillCombo(dal.ReturnReceiptState(), _host.ddlReceiptState, "Flag", "Title","همه");
        }

        public void FillBarcodeStatus()
        {
            Utility.FillCombo(dal.ReturnBarcodeStatus(), _host.ddlBarcodeStatus, "Code", "Title", "همه");
        }

        public void FillReceiptSaveState()
        {
            Utility.FillCombo(dal.ReturnReceiptSaveState(), _host.ddlReceiptSaveState, "Value", "Title", "همه");
        }

        public string Encrypt(string param)
        {
            return Library.Encryption.Encrypt(param);
        }

        public void FillLastState( )
        {
            try
            {
                Utility.FillCombo2(dal.ReturnStateBedonehManategh(), _host.ddlLastState, "CODE", "PNAME", "کل کشور");
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

        public string ReturnRahgiriPate(string Barcode)
        {
            string Query = string.Format("exec PostExchangeCenter..SetPateh @Parcel = N'{0}'", Barcode);
            return dal.SqlDataTable172(Query).Rows[0][0].ToString();
        }
    }
}