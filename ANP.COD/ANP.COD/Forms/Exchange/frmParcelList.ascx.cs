using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANP.Bussiness.Host;
using ANP.Bussiness.Objects;
using ANP.Bussiness.Models;
using System.Web.UI.HtmlControls;
using ANP.Common;

namespace ANP.COD.Forms.Exchange
{
    public partial class ChangePriceParcels : System.Web.UI.UserControl, IChangePriceParcels
    {
        _ChangePriceParcels Buss = new _ChangePriceParcels();
        LoginDetails UserInfo = new LoginDetails();

        private void UserValidate()
        {
            if (null != Session["UserInfo"])
            {
                UserInfo = Session["UserInfo"] as LoginDetails;
                if((UserInfo.RoleID ==1005 || UserInfo.RoleID ==1006 )==false)
                    Response.Redirect("~/Permission.aspx", true);
            }
            else
                Response.Redirect("~/Login.aspx", true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UserValidate();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "anything", "test();", true);
            ChkNonContract_CheckedChanged(null, null);
            Buss.Init(this, UserInfo);
            if (!IsPostBack)
            {
                Buss.LoadForm();
                ViewState["RowID"] = 0;
                Fdate.Text = DateAndTime.GetDate10Digit();
                Ldate.Text = DateAndTime.GetDate10Digit();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Buss.ShowDeliveryParcels();
        }

        protected void MyGrid_DataBinding(object sender, EventArgs e)
        {
            Buss.MyGrid_DataBinding();
        }

        protected void MyGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            Buss.MyGrid_ItemDataBound(sender, e);
        }

        protected void MyGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Detail")
            {
                ShowDetail(e.Item.Cells[1].Text);
            }
        }

        private void ShowDetail(string ParcelID)
        {
            DivAllPage.Visible = true;
            DivDetail.Visible = true;
            Buss.LoadDetailGrid(ParcelID);
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            DivAllPage.Visible = false;
            DivDetail.Visible = false;
        }

        protected void ddlParentState_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buss.Load_ddlStatus();
        }

        #region IChangePriceParcels Members

        HtmlGenericControl IChangePriceParcels.DivDetail
        {
            get { return DivDetail; }
        }

        HtmlGenericControl IChangePriceParcels.DivAllPage
        {
            get { return DivAllPage; }
        }

        DropDownList IChangePriceParcels.ddlLC
        {
            get { return ddlLC; }
        }
        DropDownList IChangePriceParcels.ddlGC
        {
            get { return ddlGC; }
        }
        DropDownList IChangePriceParcels.ddlMovazeh
        {
            get { return ddlMovazeh; }
        }
        DropDownList IChangePriceParcels.ddlStatus
        {
            get { return ddlStatus; }
        }
        DropDownList IChangePriceParcels.ddlFinancial
        {
            get { return ddlFinancial; }
        }
        DropDownList IChangePriceParcels.ddlParcelType
        {
            get { return ddlParcelType; }
        }
        DropDownList IChangePriceParcels.ddlParentState
        {
            get { return ddlParentState; }
        }

        TextBox IChangePriceParcels.txtBracodeSearch
        {
            get { return txtBracodeSearch; }
        }
        //LinkButton IChangePriceParcels.lblDetail
        //{
        //    get { return lblDetail; }
        //}
        public LinkButton lblDetail
        {
            get { return lblDetail; }
        }
        Button IChangePriceParcels.btnSearch
        {
            get { return btnSearch; }
        }
        Button IChangePriceParcels.btnReturn
        {
            get { return btnReturn; }
        }
        string IChangePriceParcels.Fdate
        {
            get
            {
                return Fdate.Text;
            }
        }
        string IChangePriceParcels.Ldate
        {
            get
            {
                return Ldate.Text;
            }
            set
            {
                Ldate.Text = value;
            }
        }
        Label IChangePriceParcels.lblSumCustomer
        {
            get { return lblSumCustomer; }
        }
        Label IChangePriceParcels.lblSumPostal
        {
            get { return lblSumPostal; }
        }
        Label IChangePriceParcels.lblSumVatTax
        {
            get { return lblSumVatTax; }
        }
        Label IChangePriceParcels.txtSumPrice
        {
            get { return txtSumPrice; }
        }
        DataGrid IChangePriceParcels.MyGrid
        {
            get { return MyGrid; }
        }
        DataGrid IChangePriceParcels.MyDetailGrid
        {
            get { return DetailGrid; }
        }

        CheckBox IChangePriceParcels.chkDontPayPrice
        {
            get { return chkDontPayPrice; }
        }

        CheckBox IChangePriceParcels.ChkNonContract
        {
            get { return ChkNonContract; }
        }
        
        #endregion

        protected void ChkNonContract_CheckedChanged(object sender, EventArgs e)
        {
            ddlLC.SelectedIndex = ddlGC.SelectedIndex = -1;
            if (ChkNonContract.Checked)
            {
                ddlLC.Enabled = ddlGC.Enabled = false;
            }
            else
            {
                ddlLC.Enabled = ddlGC.Enabled = true;
            }
        }
    }
}