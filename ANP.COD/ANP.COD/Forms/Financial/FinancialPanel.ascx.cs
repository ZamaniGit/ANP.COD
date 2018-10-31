using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Prs.Bussiness;
using ANP.Bussiness.Models;
using ANP.Bussiness.Host;
using ANP.Bussiness.Objects;
using ANP.Common;

namespace ANP.COD.Forms.Financial
{
    public partial class FinancialPanel : System.Web.UI.UserControl, IFinancialPanel
    {
        _FinancialPanel _fin = new _FinancialPanel();
        LoginDetails UserInfo = new LoginDetails();
        int SumVattax, SumCustomerCost, SumPostalCost, SumAllPrice = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            UserValidate();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "anything", "test();", true);
            _fin.InitializeFinancialPanel(this, UserInfo);
            if (!IsPostBack)
            {
                Fdate.Text = DateAndTime.GetDate10DigitManyAgoDays(-60);
                Ldate.Text = DateAndTime.GetDate10Digit();
                _fin.Load_ddlCountry();
                _fin.Load_MyGrid();

            }
        }

        private void UserValidate()
        {
            if (null != Session["UserInfo"])
                UserInfo = Session["UserInfo"] as LoginDetails;
            else
                Response.Redirect("~/Login.aspx", true);
        }

        protected void dgReceiptList_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (_fin.ItemCommand(e))
                _fin.Load_MyGrid();
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            _fin.Load_ddlCity();
            //_fin.Load_MyGrid();
        }

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            _fin.Load_ddlDispense();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            _fin.Load_MyGrid();
        }

        protected void dgFinancialReceipt_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            _fin.Load_ddlCause(e);
        }

        #region InterFace

        string IFinancialPanel.Fdate
        {
            get
            {
                return Fdate.Text;
            }
            set
            {
                Fdate.Text = value;
            }
        }

        string IFinancialPanel.Ldate
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

        DropDownList IFinancialPanel.ddlCountry
        {
            get { return ddlCountry; }
        }

        DropDownList IFinancialPanel.ddlCity
        {
            get { return ddlCity; }
        }

        DropDownList IFinancialPanel.ddlDispense
        {
            get { return ddlDispense; }
        }

        DataGrid IFinancialPanel.dgFinancialReceipt
        {
            get { return dgFinancialReceipt; }
        }

        Label IFinancialPanel.lblMessage
        {
            get { return lblAlert; }
        }

        bool IFinancialPanel.Div_Visible
        {
            get { return DivMessage.Visible; }
            set { DivMessage.Visible = value; }
        }

        public bool DivDetail {
            get {
                return divDetail.Visible;
            }
            set {
                divDetail.Visible = value;
            }
        }

        public bool DivDetail1
        {
            get
            {
                return divDetail1.Visible;
            }
            set
            {
                divDetail1.Visible = value;
            }
        }

        public bool DivDetail2 {
            get {
                return divDetail2.Visible;
            }
            set {
                divDetail2.Visible = value;
            }
        }

        Button IFinancialPanel.btnDetail
        {
            get { return btnDetail; }
        }

        DataGrid IFinancialPanel.dgParcelsDetail
        {
            get { return dgParcelsDetail; }
        }

        DataGrid IFinancialPanel.dgDetail
        {
            get { return dgDetail; }
        }

        #endregion 

        protected void btnDetail_Click(object sender, EventArgs e)
        {
            _fin.DisableDetail();
        }

        protected void dgParcelsDetail_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SumPostalCost += Convert.ToInt32(e.Item.Cells[7].Text);
                SumVattax += Convert.ToInt32(e.Item.Cells[8].Text);
                SumCustomerCost += Convert.ToInt32(e.Item.Cells[9].Text);
                SumAllPrice += Convert.ToInt32(e.Item.Cells[10].Text);
            }
            lblPostalCost.Text = SumPostalCost.ToString();
            lblVattax.Text = SumVattax.ToString();
            lblCostumerCost.Text = SumCustomerCost.ToString();
            lblAllPrice.Text = SumAllPrice.ToString();
        }
    }
}