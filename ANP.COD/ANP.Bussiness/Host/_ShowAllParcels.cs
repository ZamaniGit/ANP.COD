using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ANP.Bussiness.Models;
using ANP.Bussiness.Objects;
using ANP.Data.BaseData;
using ANP.Bussiness.Basic;

namespace ANP.Bussiness.Host
{
    public class _ShowAllParcels
    {
        IShowAllParcels _host;
        LoginDetails UserInfo;
        Base BI = new Base();

        public void Init(IShowAllParcels hostform, LoginDetails LD)
        {
            this._host = hostform;
            UserInfo = LD;
        }

        public void LoadForm()
        {
            Utility.FillCombo(BI.GetAllStatusParcels(), _host.ddlStatus, "Code", "Name", "همه");
            _host.ddlStatus.SelectedValue = "0";
            ShowExchangeStore();
        }

        public void ShowExchangeStore(){
            _host.MyGrid.DataSource = BI.GetAllExchangeStoreByStatus(_host.ddlStatus.SelectedValue, UserInfo.PostNodeCode, UserInfo.UserId,_host.FDate,_host.LDate);
            _host.MyGrid.DataBind();
        }

        public void ItemCommand(System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Detail")
                EnableDetail(e.CommandArgument.ToString());
        }

        private void Load_MyDetailGrid()
        {
            throw new NotImplementedException();
        }

        public void DisableDetail()
        {
            _host.DivDetail2Visibale = false;
            _host.DivDetailVisibale = false;
        }

        public void EnableDetail(string ID)
        {
            _host.DivDetail2Visibale = true;
            _host.DivDetailVisibale = true;

            _host.MyDetailGrid.DataSource = BI.GetAllExchangeStoreByStatusDetail(ID);
            _host.MyDetailGrid.DataBind();
        }
        
    }
}