using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stimulsoft.Report;
using ANP.Bussiness.Objects;
using ANP.Data;
using ANP.Data.BaseData.Report;
using ANP.Bussiness.Models.Reports;
using ANP.Bussiness.Host.Reports;
using ANP.Common;
using System.Data;
using ANP.COD.Properties;
using ANP.Data.BaseData;

namespace ANP.COD.Forms.Reports
{
    public partial class RepFinancialParcelOfFirstState : System.Web.UI.UserControl, IRepFinancialParcelOfFirstState
    {
        LoginDetails _LoginDetails = new LoginDetails();
        DBConnector _host = new DBConnector();
        _RepFinancialParcelOfFirstState Buss = new _RepFinancialParcelOfFirstState();
        public DataTable _dtReport = new DataTable();

        public string UserName { get; set; }
        public string PostNodeName { get; set; }
        public string ReportDate { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            UserValidate();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "anything", "Test();", true);
            Buss.InitializeIControlForm(this, _LoginDetails);

            if (false == Page.IsPostBack)
            {
                Fdate.Text = DateAndTime.GetDate10Digit();
                Ldate.Text = DateAndTime.GetDate10Digit();
                Buss.LoadForm();
            }
        }

        private void UserValidate()
        {
            if (null != Session["UserInfo"])
                _LoginDetails = Session["UserInfo"] as LoginDetails;
            else
                Response.Redirect("~/Login.aspx", true);
        }



        private string LoadReport()
        {

            try
            {
                string param = string.Empty;
                param = "ddlState|" + ddlState.SelectedValue + "#";
                param += "ddlBarcodeStatus|" + ddlBarcodeStatus.SelectedValue + "#";
                param += "ddlBarcodeSubStatus|" + ddlBarcodeSubStatus.SelectedValue + "#";
                param += "ddlCredit|" + ddlCredit.SelectedValue + "#";
                param += "Ldate|" + Ldate.Text + "#";
                param += "Fdate|" + Fdate.Text + "#";
                param += "ddlLastPostNode|" + ddlLastPostNode.SelectedValue + "#";
                param += "ddlLastCity|" + ddlLastCity.SelectedValue + "#";
                param += "ddlLastState|" + ddlLastState.SelectedValue + "#";
                param += "ddlPostNode|" + ddlPostNode.SelectedValue + "#";
                param += "ddlCity|" + ddlCity.SelectedValue + "#";
                param += "ddlState|" + ddlState.SelectedValue + "#";
                return Library.Encryption.Encrypt(param);

            }
            catch 
            {
                return "";
            }

        }

        #region IRepFinancialParcelOfFirstState Members

        DropDownList IRepFinancialParcelOfFirstState.ddlState
        {
            get { return ddlState; }
        }

        DropDownList IRepFinancialParcelOfFirstState.ddlCity
        {
            get { return ddlCity; }
        }

        DropDownList IRepFinancialParcelOfFirstState.ddlPostNode
        {
            get { return ddlPostNode; }
        }

        DropDownList IRepFinancialParcelOfFirstState.ddlLastState
        {
            get { return ddlLastState; }
        }

        DropDownList IRepFinancialParcelOfFirstState.ddlLastCity
        {
            get { return ddlLastCity; }
        }

        DropDownList IRepFinancialParcelOfFirstState.ddlLastPostNode
        {
            get { return ddlLastPostNode; }
        }

        DropDownList IRepFinancialParcelOfFirstState.ddlBarcodeStatus
        {
            get { return ddlBarcodeStatus; }
        }

        DropDownList IRepFinancialParcelOfFirstState.ddlBarcodeSubStatus
        {
            get { return ddlBarcodeSubStatus; }
        }

        string IRepFinancialParcelOfFirstState.Fdate
        {
            get { return Fdate.Text; }
        }

        string IRepFinancialParcelOfFirstState.Ldate
        {
            get { return Ldate.Text; }
        }

        DropDownList IRepFinancialParcelOfFirstState.ddlCredit
        {
            get { return ddlCredit; }
        }

        Button IRepFinancialParcelOfFirstState.btnShow
        {
            get { return btnShow; }
        }

        #endregion

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buss.ddlState_SelectedIndexChanged();
        }

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buss.ddlCity_SelectedIndexChanged();
        }

        protected void ddlLastState_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buss.ddlLastState_SelectedIndexChanged();

        }

        protected void ddlLastCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buss.ddlLastCity_SelectedIndexChanged();

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            ucAlertControl.Hide();
            if (ComplateFilter())
            {
                if (DiffDate() == true)
                {
                    Response.Redirect("Default.aspx?action=581a3424-3a37-4544-8cd0-89ad4dbc2a66&pra="+LoadReport());
                }
                else
                    ucAlertControl.Show("خطا", "حداکثر بازه انتخابی دو ماه میباشد .", COD.Controls.AlertControl.AlertTypes.danger);
            }
            else
                ucAlertControl.Show("خطا", "لطفا فیلتر های انتخابی را با دقت بیشتری انتخاب کنید", COD.Controls.AlertControl.AlertTypes.danger);
            //up.Update();
        }

        private bool DiffDate()
        {
            if (DateAndTime.DiffDateShamsi(Fdate.Text, Ldate.Text) > 60)
                return false;
            else
                return true;
        }

        private bool ComplateFilter()
        {
            if (
                (ddlState.Items.Count > 0) &&
                (Convert.ToInt32(ddlState.SelectedValue) > -2) &&
                (ddlCity.Items.Count > 0) &&
                (Convert.ToInt32(ddlCity.SelectedValue) > -2) &&
                (ddlPostNode.Items.Count > 0) &&
                (Convert.ToInt32(ddlPostNode.SelectedValue) > -2) &&
                (ddlLastState.Items.Count > 0) &&
                (Convert.ToInt32(ddlLastState.SelectedValue) > -2) &&
                (ddlLastCity.Items.Count > 0) &&
                (Convert.ToInt32(ddlLastCity.SelectedValue) > -2) &&
                (ddlLastPostNode.Items.Count > 0) &&
                (Convert.ToInt32(ddlLastPostNode.SelectedValue) > -2) &&
                (ddlCredit.Items.Count > 0) &&
                (Convert.ToInt32(ddlCredit.SelectedValue) > -2) &&
                (ddlBarcodeStatus.Items.Count > 0) &&
                (Convert.ToInt32(ddlBarcodeStatus.SelectedValue) > -2))
                return true;
            else
                return false;
        }

        protected void ddlBarcodeStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buss.FillBarcodeSubStatus();
        }
    }
}