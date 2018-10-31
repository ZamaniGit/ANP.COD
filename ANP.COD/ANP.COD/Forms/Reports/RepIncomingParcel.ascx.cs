using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANP.Bussiness.Models;
using ANP.Bussiness.Objects;
using ANP.Data;
using ANP.Bussiness.Host.Reports;
using System.Data;
using ANP.Common;
using System.Web.UI.HtmlControls;

namespace ANP.COD.Forms.Reports
{
    public partial class RepIncomingParcel : System.Web.UI.UserControl, IRepIncomingParcel
    {
        LoginDetails _LoginDetails = new LoginDetails();
        DBConnector _host = new DBConnector();
        _RepIncomingParce Buss = new _RepIncomingParce();

        public Int64 TotalPostalCost = 0;
        public Int64 TotalCustomerCost = 0;
        public Int64 TotalVattaxCost = 0;
        public Int64 TotalSumCost = 0;
        public Int64 TotalBarcodeCount = 0;

        public DataSet ds = new DataSet();
        public DataTable dtReport = new DataTable();
        public DataTable dtDetailReport = new DataTable();

        public string ContactAndBaje { get; set; }
        public string ServiceType { get; set; }
        public string UserName { get; set; }
        public string PostNodeName { get; set; }
        public string ReportDate { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            UserValidate();
            tbl_rpt.Visible = false;
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

        private Boolean LoadReport()
        {DataTable dt = new DataTable();
            try
            { tbl_rpt.Visible = false;
                dt = Buss.LoadReport();
                if (dt.Rows.Count > 0)
                {dtReport = dt;
                    tbl_rpt.Visible = true; }
                return true;}
            catch{return false;}
        }

        protected void ddlLastState_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buss.FillLastCity(_LoginDetails.RoleID);
            ddlLastCity_SelectedIndexChanged(null, null);
        }

        protected void ddlBarcodeStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlLastCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buss.FillLastPostNode(_LoginDetails.RoleID);
        }

        #region IRepIncomingParcel Members

        DropDownList IRepIncomingParcel.ddlFirstState
        {
            get { return ddlFirstState; }

        }

        DropDownList IRepIncomingParcel.ddlExchangeState
        {
            get { return ddlExchangeState; }
        }

        DropDownList IRepIncomingParcel.ddlReceiptState
        {
            get { return ddlReceiptState; }
        }

        DropDownList IRepIncomingParcel.ddlLastState
        {
            get { return ddlLastState; }

        }

        DropDownList IRepIncomingParcel.ddlLastCity
        {
            get { return ddlLastCity; }
        }

        DropDownList IRepIncomingParcel.ddlLastPostNode
        {
            get { return ddlLastPostNode; }
        }

        DropDownList IRepIncomingParcel.ddlGC
        {
            get { return ddlGC; }
        }

        DropDownList IRepIncomingParcel.ddlServiceType
        {
            get { return ddlServiceType; }
        }

        DropDownList IRepIncomingParcel.ddlContractType
        {
            get { return ddlContractType; }
        }

        string IRepIncomingParcel.Fdate
        {
            get { return Fdate.Text; }
        }

        string IRepIncomingParcel.Ldate
        {
            get { return Ldate.Text; }
        }

        Button IRepIncomingParcel.btnShow
        {
            get { return btnShow; }

        }

        #endregion

        private bool ValidationForm()
        {
            if ( (Fdate.Text.Length == 10) &&(Ldate.Text.Length == 10) &&
                (ddlLastState.Items.Count > 0) &&(Convert.ToInt32(ddlLastState.SelectedIndex) > -1) &&
                (ddlLastCity.Items.Count > 0) && (Convert.ToInt32(ddlLastCity.SelectedIndex) > -1) &&
                (ddlLastPostNode.Items.Count > 0) && (Convert.ToInt32(ddlLastPostNode.SelectedIndex) > -1) &&
                (ddlFirstState.Items.Count > 0) && (Convert.ToInt32(ddlFirstState.SelectedIndex) > -1) &&
                (ddlReceiptState.Items.Count > 0) && (Convert.ToInt32(ddlReceiptState.SelectedIndex) > -1) &&
                (ddlExchangeState.Items.Count > 0) && (Convert.ToInt32(ddlExchangeState.SelectedIndex) > -1) &&
                (ddlServiceType.Items.Count > 0) && (Convert.ToInt32(ddlServiceType.SelectedIndex) > -1) &&
                (ddlGC.Items.Count > 0) && (Convert.ToInt32(ddlGC.SelectedIndex) > -1) &&
                (ddlContractType.Items.Count > 0) && (Convert.ToInt32(ddlContractType.SelectedIndex) > -1))
                return true;
            else
                return false;
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            ucAlertControl.Hide();
            ServiceType = ddlServiceType.SelectedItem.Text;
            switch (ddlContractType.SelectedValue)
            {
                case  "A" :
                    ContactAndBaje = "باجه ایی و قراردادی";
                    break;
                case "B":
                    ContactAndBaje = "فقط باجه ایی";
                    break;
                case "G":
                    ContactAndBaje = "قرارداد سراسری - " + ddlGC.Text;
                    break;
                case "L":
                    ContactAndBaje = "قرارداد استانی - " + ddlGC.Text;
                    break;
                case "GL":
                    ContactAndBaje = "باجه ایی و قراردادی";
                    break;
                default:
                    ContactAndBaje = "شناخته نشد";
                    break;
            }

            if (ValidationForm())
                LoadReport();
            else
            ucAlertControl.Show("خطا", "لطفا فیلتر های انتخابی را با دقت بیشتری انتخاب کنید", COD.Controls.AlertControl.AlertTypes.danger);
        }
    }
}