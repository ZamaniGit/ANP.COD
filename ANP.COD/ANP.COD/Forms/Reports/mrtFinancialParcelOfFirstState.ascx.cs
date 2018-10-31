using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANP.COD.Properties;
using Stimulsoft.Report;
using ANP.Bussiness.Objects;
using ANP.Data;
using ANP.Common;

namespace ANP.COD.Forms.Reports
{
    public partial class mrtFinancialParcelOfFirstState : System.Web.UI.UserControl
    {
        LoginDetails _LoginDetails = new LoginDetails();
        DBConnector _host = new DBConnector();
        //public string UserName { get; set; }
        //public string PostNodeName { get; set; }
        //public string ReportDate { get; set; }
        public string ddlBarcodeStatus { get; set; }
        public string ddlBarcodeSubStatus { get; set; }
        public string ddlCredit { get; set; }
        public string Ldate { get; set; }
        public string Fdate { get; set; }
        public string ddlLastPostNode { get; set; }
        public string ddlLastCity { get; set; }
        public string ddlLastState { get; set; }
        public string ddlPostNode { get; set; }
        public string ddlCity { get; set; }
        public string ddlState { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UserValidate();

                ReportObject(ANP.Data.BaseData.Library.Encryption.Decrypt(Request.QueryString["pra"].ToString()));
                string ConnectionString = _host.ConnectionString;
                Stimulsoft.Report.StiReport _report = new StiReport();
                _report.Load(Resources.mrtFinancialParcelOfFirstState);
                _report.Dictionary.Databases.Clear();
                _report.Dictionary.Databases.Add(new Stimulsoft.Report.Dictionary.StiSqlDatabase("PofficeCOD186", ConnectionString));
                _report.Compile();

                _report["FirstState"] = (ddlState == string.Empty ? 0 : Convert.ToInt32(ddlState));
                _report["FirstCity"] = (ddlCity == string.Empty ? 0 : Convert.ToInt32(ddlCity));
                _report["FirstPostNode"] = (ddlPostNode == string.Empty ? 0 : Convert.ToInt32(ddlPostNode));
                _report["LastState"] = (ddlLastState == string.Empty ? 0 : Convert.ToInt32(ddlLastState));
                _report["LastCity"] = (ddlLastCity == string.Empty ? 0 : Convert.ToInt32(ddlLastCity));
                _report["LastPostNode"] = (ddlLastPostNode == string.Empty ? 0 : Convert.ToInt32(ddlLastPostNode));
                _report["FirstDate"] = Fdate;
                _report["LastDate"] = Ldate;
                _report["PayType"] = (ddlCredit == string.Empty ? 0 : Convert.ToInt32(ddlCredit));
                _report["BarcodeStatus"] = (ddlBarcodeStatus == string.Empty ? 0 : Convert.ToInt32(ddlBarcodeStatus));
                _report["BarcodeSubStatus"] = (ddlBarcodeSubStatus == string.Empty ? 0 : Convert.ToInt32(ddlBarcodeSubStatus));
                _report["UserName"] = _LoginDetails.Pname + " " + _LoginDetails.RolePname + " از " + _LoginDetails.StateName;
                _report["ReportDate"] = DateAndTime.GetSQLDate10DigitShamsi() + " -- " + DateAndTime.GetSQLTime8Digit();

                StiWebViewer1.Report = _report;
            }
            catch (Exception ex)
            {
                string Query = string.Format(@"EXECUTE sp_FilltblErrorProgrammer
                                       @Message=N'{0}'
                                      ,@DateError='{1}'
                                      ,@PhysicalPath=N'{2}'
                                      ,@UserHostAddress='{3}'
                                      ,@Browser='{4}'"
                    , "Error For Load Report :  rptFinancialParcelOfFirstState ; Detail :  " + ex.Message.Replace("'", "''")
                    , DateAndTime.GetDateTime16Digit_Latin(), "", "", "");
                _host.SqlExecute(Query);
            }
        }

        private void UserValidate()
        {
            if (null != Session["UserInfo"])
                _LoginDetails = Session["UserInfo"] as LoginDetails;
            else
                Response.Redirect("~/Login.aspx", true);
        }

        public void ReportObject(string Param)
        {
            if (Param != string.Empty)
            {

                string[] para = Param.Split('#');
                foreach (string s in para)
                {
                    string[] item = s.Split('|');
                    switch (item[0])
                    {
                        case "ddlBarcodeStatus": ddlBarcodeStatus = item[1]; break;
                        case "ddlBarcodeSubStatus": ddlBarcodeSubStatus = item[1]; break;
                        case "ddlCredit": ddlCredit = item[1]; break;
                        case "Ldate": Ldate = item[1]; break;
                        case "Fdate": Fdate = item[1]; break;
                        case "ddlLastPostNode": ddlLastPostNode = item[1]; break;
                        case "ddlLastCity": ddlLastCity = item[1]; break;
                        case "ddlLastState": ddlLastState = item[1]; break;
                        case "ddlPostNode": ddlPostNode = item[1]; break;
                        case "ddlCity": ddlCity = item[1]; break;
                        case "ddlState": ddlState = item[1]; break;
                    }
                }
            }
        }
    }
}