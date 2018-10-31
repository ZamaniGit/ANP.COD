using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANP.Bussiness.Objects;
using ANP.Data;
using ANP.Bussiness.Host.Reports;
using System.Data;
using ANP.Bussiness.Models.Reports;
using ANP.Common;
using ANP.Data.BaseData;
using System.IO;
using System.Text;


namespace ANP.COD.Forms.Reports
{
    public partial class RepDebitForState : System.Web.UI.UserControl, IRepDebitForState
    {
        LoginDetails _LoginDetails = new LoginDetails();
        DBConnector _host = new DBConnector();
        _RepDebitForState Buss = new _RepDebitForState();

        public Int64 TotalPostalCost = 0;
        public Int64 TotalCustomerCost = 0;
        public Int64 TotalVattaxCost = 0;
        public Int64 TotalSumCost = 0;
        public Int64 TotalBarcodeCount = 0;

        public DataSet ds = new DataSet();
        public DataTable dtReport = new DataTable();
        public DataTable dtDetailReport = new DataTable();

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

        private void LoadReport()
        {
            tbl_rpt.Visible = false;
            ds = Buss.LoadReport();
            if (ds.Tables.Count > 0)
            {
                dtReport = ds.Tables[0];
                dtDetailReport = ds.Tables[1];
                tbl_rpt.Visible = true;
            }

        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buss.ddlState_SelectedIndexChanged();
        }

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buss.ddlCity_SelectedIndexChanged();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            ucAlertControl.Hide();
            if (ComplateFilter())
            {
                if (DiffDate() == true)
                {
                    LoadReport();
                }
                else
                    ucAlertControl.Show("خطا", "حداکثر بازه انتخابی دو ماه میباشد .", COD.Controls.AlertControl.AlertTypes.danger);
            }
            else
                ucAlertControl.Show("خطا", "لطفا فیلتر های انتخابی را با دقت بیشتری انتخاب کنید", COD.Controls.AlertControl.AlertTypes.danger);
        }

        private bool DiffDate()
        {
            if (DateAndTime.DiffDateShamsi(Fdate.Text, Ldate.Text) > 186)
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
                (ddlBarcodeStatus.Items.Count > 0) &&
                (Convert.ToInt32(ddlBarcodeStatus.SelectedValue) > -2))
                return true;
            else
                return false;
        }

        protected void lnkDownloadDetail_Click(object sender, EventArgs e)
        {
            ds = Buss.LoadReport();
            dtDetailReport = ds.Tables[1];
            exportGridToExcel(dtDetailReport);
        }

        public void exportGridToExcel(DataTable dt)
        {
            string fileName = "Export.xls";
            string Extension = ".xls";
            if (Extension == ".xls")
            {

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                GridView GridView1 = new GridView();

                GridView1.AllowPaging = false;
                GridView1.DataSource = dt;
                GridView1.DataBind();
                
                GridView1.RenderControl(hw);

                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
                
            }
        }

        #region IRepDebitForState Members

        HiddenField IRepDebitForState.hfStateList
        {
            get { return hfStateList; }
        }

        DropDownList IRepDebitForState.ddlIsReceipt
        {
            get { return ddlIsReceipt; }
        }

        DropDownList IRepDebitForState.ddlState
        {
            get { return ddlState; }
        }

        DropDownList IRepDebitForState.ddlCity
        {
            get { return ddlCity; }
        }

        DropDownList IRepDebitForState.ddlPostNode
        {
            get { return ddlPostNode; }
        }

        DropDownList IRepDebitForState.ddlLastState
        {
            get { return ddlLastState; }
        }

        DropDownList IRepDebitForState.ddlLastCity
        {
            get { return ddlLastCity; }
        }

        DropDownList IRepDebitForState.ddlLastPostNode
        {
            get { return ddlLastPostNode; }
        }

        DropDownList IRepDebitForState.ddlBarcodeStatus
        {
            get { return ddlBarcodeStatus; }
        }

        string IRepDebitForState.Fdate
        {
            get { return Fdate.Text; }
        }

        string IRepDebitForState.Ldate
        {
            get { return Ldate.Text; }
        }

        Button IRepDebitForState.btnShow
        {
            get { return btnShow; }
        }

        #endregion

        protected void ddlLastCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buss.ddlLastCity_SelectedIndexChanged();
        }

        protected void ddlLastState_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buss.ddlLastState_SelectedIndexChanged();
        }
    }
}