using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stimulsoft.Report;
using ANP.Data.BaseData.Report;
using ANP.Data;
using ANP.Bussiness.Objects;
using ANP.COD.Properties;
using ANP.Common;

namespace ANP.COD.Forms.Reports
{
    public partial class RepBarcodeDetailes : System.Web.UI.UserControl
    {
        StiReport _StimReport = new StiReport();
        ReportObject param;
        LoginDetails _LoginDetails = new LoginDetails();
        DBConnector _host = new DBConnector();

        protected void Page_Load(object sender, EventArgs e)
        {
            UserValidate();
            if (!Page.IsPostBack)
            {
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

        private void LoadForm()
        {
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                string ConnectionString = _host.ConnectionString;
                Stimulsoft.Report.StiReport _report = new StiReport();
                _report.Load(Resources.mrtBarcodeDetailes);
                _report.Dictionary.Databases.Clear();
                _report.Dictionary.Databases.Add(new Stimulsoft.Report.Dictionary.StiSqlDatabase("PofficeCOD186", ConnectionString));
                _report.Compile();

                _report["UserID"] = (param.UserID.Trim() == string.Empty ? "0" : param.UserID.Trim());
                _report["fDate"] = (param.FirstDate.Trim() == string.Empty ? "1500/01/01" : param.FirstDate.Trim());
                _report["lDate"] = (param.LastDate.Trim() == string.Empty ? "1500/01/01" : param.LastDate.Trim());
                _report["StateCode"] = (param.StateCode.Trim() == string.Empty ? 0 : Convert.ToInt32(param.LastStateCode));
                _report["CityCode"] = (param.CityCode.Trim() == string.Empty ? 0 : Convert.ToInt32(param.CityCode));
                _report["PostNode"] = (param.PostNodeCode.Trim() == string.Empty ? 0 : Convert.ToInt32(param.PostNodeCode));
                _report["StatusID"] = (param.BarcodeStatusID.Trim() == string.Empty ? 0 :Convert.ToInt32(param.BarcodeStatusID));
                _report["UserName"] = _LoginDetails.Pname + " " + _LoginDetails.RolePname + " از " + _LoginDetails.StateName;
                _report["ReportDate"] = DateAndTime.GetSQLDate10DigitShamsi()+" -- " + DateAndTime.GetSQLTime8Digit();

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
                    , "Error For Load Report :  rptBarcodeDetail ; Detail :  " + ex.Message.Replace("'", "''")
                    , DateAndTime.GetDateTime16Digit_Latin(), "", "", "");
                _host.SqlExecute(Query);
            }
        }
    }
}