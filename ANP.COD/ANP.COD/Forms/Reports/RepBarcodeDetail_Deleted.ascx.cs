using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANP.Data;
using ANP.Bussiness.Objects;
using ANP.Data.BaseData.Report;
using System.Data;
using ANP.Common;
using System.IO;
using System.Text;

namespace ANP.COD.Forms.Reports
{
    public partial class RepBarcodeDetail : System.Web.UI.UserControl
    {
        ReportObject param;
        LoginDetails _LoginDetails = new LoginDetails();
        DBConnector _host = new DBConnector();

        public string UserName { get; set; }
        public string PostNodeName { get; set; }
        public string ReportDate { get; set; }
        public DataTable dtReport = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack){
                UserValidate();
                try
                {
                    if (null != Request.QueryString["pra"])
                    {
                        param = new ReportObject(ANP.Data.BaseData.Library.Encryption.Decrypt(Request.QueryString["pra"].ToString()));
                        LoadReport();
                    }
                }
                catch { }
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
            try
            {
                string Query=
                    string.Format(@"EXECUTE sp_rptBarcodeDetail
                    @UserID={0},@fDate='{1}',@lDate='{2}',@StateCode={3}
                    ,@CityCode={4},@PostNode={5},@StatusID={6}"
                    ,param.UserID,param.FirstDate,param.LastDate,param.StateCode
                    ,param.CityCode,param.PostNodeCode,param.BarcodeStatusID);
                dtReport = _host.SqlDataTable(Query);

                //Label16.Text = "(از تاریخ : " + param.FirstDate + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; تا تاریخ:" +param.LastDate + ")";

            }
            catch (Exception ex)
            {
                string Query = string.Format(@"EXECUTE sp_FilltblErrorProgrammer
                                       @Message=N'{0}'
                                      ,@DateError='{1}'
                                      ,@PhysicalPath=N'{2}'
                                      ,@UserHostAddress='{3}'
                                      ,@Browser='{4}'"
                    , "Error For Load Report :  rptBarcodeDetail ; Detail :  " + ex.Message.Replace("'", "''")
                    , DateAndTime.GetDateTime16Digit_Latin(), "", "", "");
                _host.SqlExecute(Query);
            }
        }

        protected void Unnamed1_Click(object sender, ImageClickEventArgs e)
        {

            exportGridToExcel(ReportTable);

        }


        private void exportGridToExcel(Control ctl)
        {
            string attachment = "attachment; filename=excel_export.xls";
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", attachment);
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            StringWriter stw = new StringWriter();
            HtmlTextWriter htextw = new HtmlTextWriter(stw);

            ctl.RenderControl(htextw);
            HttpContext.Current.Response.Write(stw.ToString());
            HttpContext.Current.Response.End();
        }
    }
}