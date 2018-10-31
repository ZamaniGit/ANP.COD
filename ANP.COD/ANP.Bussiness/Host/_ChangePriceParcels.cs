using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ANP.Bussiness.Models;
using ANP.Bussiness.Objects;
using ANP.Data.BaseData;
using System.Web.UI.WebControls;
using ANP.Bussiness.Basic;

namespace ANP.Bussiness.Host
{
    public class _ChangePriceParcels
    {
        IChangePriceParcels _host;
        LoginDetails UserInfo;
        ExchangeDB Data = new ExchangeDB();
        Base BI = new Base();

        int SumPrice = 0;
        int SumCustomer = 0;
        int SumVatTax = 0;
        int SumPostal = 0;

        public void LoadForm()
        {
            Load_ddlMovazeh();
            //Load_ddlFinancial();
            Load_ddlParentState();
            Load_ddlParcelType();
            Load_ddlLC();
            Load_ddlGC();
        }
        
        //private void Load_ddlFinancial()
        //{
        //    Utility.FillCombo(BI..GetAllStatusParcels(), _host.ddlFinancial, "ID", "Name", "همه");
        //}
        public void Load_ddlParentState()
        {
            Utility.FillCombo(BI.GetAllParentStatus(), _host.ddlParentState, "ID", "Name", "همه");
           _host.ddlParentState.SelectedIndex=0;
           Load_ddlStatus();
        }
        public void Load_ddlGC()
        {
            Utility.FillCombo2Header(BI.GetAllGlobalContracts(UserInfo.PostNodeCode), _host.ddlGC, "ID", "Name", "همه");
        }
        public void Load_ddlLC()
        {
            Utility.FillCombo2Header(BI.GetAllLocalContracts(UserInfo.PostNodeCode), _host.ddlLC, "ID", "Name", "همه");
        }
        public void Load_ddlParcelType()
        {
            Utility.FillCombo(BI.GetAllServiceType(), _host.ddlParcelType, "ID", "Name", "همه");
        }

        public void Load_ddlStatus()
        {
            Utility.FillCombo(BI.GetAllStatusOfOneParcels(_host.ddlParentState.SelectedValue), _host.ddlStatus, "ID", "Name", "همه");
        }

        public void Load_ddlMovazeh()
        {
            int UserID=(UserInfo.RoleID==1006?UserInfo.UserId : 0);
            if (UserInfo.RoleID == 1006)
            {
                Utility.FillCombo(BI.ReturnAllMovozeh(UserInfo.PostNodeCode, UserID), _host.ddlMovazeh, "ID", "Name",false);
            }
            else
            {
                Utility.FillCombo(BI.ReturnAllMovozeh(UserInfo.PostNodeCode, UserID), _host.ddlMovazeh, "ID", "Name", "همه");
            }

            _host.ddlMovazeh.SelectedValue = "0";
            //if (UserInfo.RoleID == 1006)
            //{
            //    _host.ddlMovazeh.SelectedValue = UserInfo.UserId.ToString();
            //    _host.ddlMovazeh.Enabled = false;
            //}
            //else
            //{
            //    _host.ddlMovazeh.SelectedValue = "0";
            //    _host.ddlMovazeh.Enabled = true;
            //}
        }
        public void FillMyGrid()
        {
            int LC, GC, ParentState, Financial, ParcelType, Status, Movazeh,IsBaje = 0;
            
            if (_host.ddlGC.SelectedValue=="") GC=-1;  else GC=Convert.ToInt32(_host.ddlGC.SelectedValue);
            if (_host.ddlLC.SelectedValue == "") LC = -1; else LC = Convert.ToInt32(_host.ddlLC.SelectedValue);
            if (_host.ddlParentState.SelectedValue == "") ParentState = 0; else ParentState = Convert.ToInt32(_host.ddlParentState.SelectedValue);
            if (_host.ddlFinancial.SelectedValue == "") Financial = 0; else Financial = Convert.ToInt32(_host.ddlFinancial.SelectedValue);
            if (_host.ddlParcelType.SelectedValue == "") ParcelType = 0; else ParcelType = Convert.ToInt32(_host.ddlParcelType.SelectedValue);
            if (_host.ddlStatus.SelectedValue == "") Status = 0; else Status = Convert.ToInt32(_host.ddlStatus.SelectedValue);
            if (_host.ddlMovazeh.SelectedValue == "") Movazeh = -1; else Movazeh = Convert.ToInt32(_host.ddlMovazeh.SelectedValue);
            if (_host.ChkNonContract.Checked) IsBaje =1; else IsBaje = 0;

            _host.MyGrid.DataSource = Data.LoadDeliveryParcels(UserInfo.PostNodeCode, _host.Fdate, _host.Ldate,IsBaje
                , Movazeh, _host.txtBracodeSearch.Text.Trim() ,Status, _host.chkDontPayPrice.Checked, ParentState, Financial, ParcelType , LC, GC);
            _host.MyGrid.DataBind();
        }

        public void ShowDeliveryParcels()
        {
            FillMyGrid();
        }

        public void MyGrid_DataBinding()
        {
            SumPrice = 0;
        }

        public void Init(IChangePriceParcels hostform, LoginDetails LD)
        {
            this._host = hostform;
            UserInfo = LD;
        }

        public void MyGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SumPrice += Convert.ToInt32(e.Item.Cells[16].Text);
                SumPostal += Convert.ToInt32(e.Item.Cells[13].Text);
                SumVatTax += Convert.ToInt32(e.Item.Cells[15].Text);
                SumCustomer += Convert.ToInt32(e.Item.Cells[14].Text);
            }
            _host.txtSumPrice.Text = String.Format("{0:#,###;#,###;0}", SumPrice);
            _host.lblSumCustomer.Text = String.Format("{0:#,###;#,###;0}", SumCustomer);
            _host.lblSumPostal.Text = String.Format("{0:#,###;#,###;0}", SumPostal);
            _host.lblSumVatTax.Text = String.Format("{0:#,###;#,###;0}", SumVatTax);
        }


        public void LoadDetailGrid(string ParcelID)
        {
            _host.MyDetailGrid.DataSource = Data.LoadDetailDeliveryParcels(ParcelID);
            _host.MyDetailGrid.DataBind();
        }
    }
}