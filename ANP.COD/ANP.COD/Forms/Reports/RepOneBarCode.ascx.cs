using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANP.Data.BaseData.Report;
using ANP.Bussiness.Objects;
using ANP.Data;
using System.Data;
using ANP.Common;

namespace ANP.COD.Forms.Reports
{
    public partial class RepOneBarCode : System.Web.UI.UserControl
    {
        ReportObject param;
        LoginDetails _LoginDetails = new LoginDetails();
        DBConnector _host = new DBConnector();

        public string UserName { get; set; }
        public string PostNodeName { get; set; }
        public string ReportDate { get; set; }
        public string IsDeleted = string.Empty;
        public DataTable dtReport = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
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

        private void LoadReport()
        {
            try
            {
                string Query =
                    string.Format(@"EXECUTE  sp_rptOneBarCodeDetail
                                   @RoleID={0}
                                  ,@StateCode={1}
                                  ,@CityCode={2}
                                  ,@PostNode={3}
                                  ,@BarCode='{4}'
                                  ,@UserID={5}",

                _LoginDetails.RoleID,
                _LoginDetails.StateCode,
                _LoginDetails.CityCode,
                _LoginDetails.PostNodeCode,
                param.BarCode,
                _LoginDetails.UserId);

                dtReport = _host.SqlDataTable(Query);
                
                IsDeleted=dtReport.Rows[0]["IsDeleted"].ToString();
                //_StimReport["UserName"] = UserName;
                //_StimReport["PostNodeName"] = _LoginDetails.CityName + "-" + _LoginDetails.PostNodeName;
                //_StimReport["ReportDate"] = ReportDate;
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