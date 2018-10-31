using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANP.Bussiness.Models;
using ANP.Bussiness.Objects;
using ANP.Bussiness.Host;

namespace ANP.COD.Forms.Exchange
{
    public partial class ShowAllParcels_Old : System.Web.UI.UserControl, IShowAllParcels
    {

        _ShowAllParcels BU = new _ShowAllParcels();
        LoginDetails UserInfo = new LoginDetails();


        protected void Page_Load(object sender, EventArgs e)
        {
            UserValidate();
            BU.Init(this, UserInfo);
            if (!IsPostBack)
            {
                BU.LoadForm();
            }
        }

        private void UserValidate()
        {
            if (null != Session["UserInfo"])
                UserInfo = Session["UserInfo"] as LoginDetails;
            else
                Response.Redirect("~/Login.aspx", true);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
           BU.ShowExchangeStore();
        }

        protected void MyGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            //BU.ItemCommand(e);
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            BU.DisableDetail();
        }

        #region Implementation

        Button IShowAllParcels.btnReturn
        {
            get { return btnReturn; }
        }

        DataGrid IShowAllParcels.MyDetailGrid
        {
            get { return MyDetailGrid; }
        }

        public bool DivDetailVisibale
        {
            get
            {
                return divDetail.Visible;
            }
            set
            {
                divDetail.Visible = value;
            }
        }

        public bool DivDetail2Visibale
        {
            get
            {
                return divDetail2.Visible;
            }
            set
            {
                divDetail2.Visible = value;
            }
        }

        DropDownList IShowAllParcels.ddlStatus
        {
            get { return ddlStatus; }
        }

        Button IShowAllParcels.btnSearch
        {
            get { return btnSearch; }
        }

        DataGrid IShowAllParcels.MyGrid
        {
            get { return MyGrid; }
        }

        public string FDate
        {
            get
            {
                return Fdate.SelectedPersianDate;
            }
            set
            {
                Fdate.SelectedPersianDate = value;
            }
        }

        public string LDate
        {
            get
            {
                return Ldate.SelectedPersianDate;
            }
            set
            {
                Ldate.SelectedPersianDate = value;
            }
        }

        #endregion
    }
}