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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ANP.COD.Forms.Reports
{
    public partial class RepGhaboolAndMobadeleh : System.Web.UI.UserControl
    {
        public ReportObject param;
        public string StateName = "--";
        public string CityName = "--";
        public string PostNode_Name = "--";

        LoginDetails _LoginDetails = new LoginDetails();
        DBConnector _host = new DBConnector();

        public string UserName { get; set; }
        public string PostNodeName { get; set; }
        public string ReportDate { get; set; }
        public DataTable dtReport = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            ViewState["RowID"] = null;   
            UserValidate();    
            if (!Page.IsPostBack)
            {
                try
                {
                    if (null != Request.QueryString["pra"])
                    {
                        param = new ReportObject(ANP.Data.BaseData.Library.Encryption.Decrypt(Request.QueryString["pra"].ToString()));
                        ViewState["RowID"] = param;
                        WriteCollection(param);
                        LoadReport();
                    }
                }
                catch { }
            }
        }

        private void WriteCollection(ReportObject param)
        {
            using (MemoryStream omemStrear = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(omemStrear, param);
                string str = Convert.ToBase64String(omemStrear.ToArray());
                hfParamGhaboolMobadeleh.Value = str;
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
                    string.Format(@"EXEC sp_Udate_GhaboolAndMobadeleh_New
		                            @Date1 = '{0}',
		                            @Date2 = '{1}',
		                            @FirstState = {2},
		                            @FirstCity = {3},
		                            @FirstPostNode = {4},
		                            @LastState = {5},
                                    @UserId = '{6}',
                                    @IsInitialize = {7}
"
                                      , param.FirstDate
                                      , param.LastDate
                                      , param.StateCode
                                      , param.CityCode
                                      , param.PostNodeCode
                                      , param.LastStateCode
                                      ,  _LoginDetails.ID
                                      ,1);

                dtReport = _host.SqlDataTable(Query);
                FindName(out StateName, out CityName, out PostNode_Name);
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
                    , "Error For Load Report :  sp_Udate_GhaboolAndMobadeleh in Total Segment ; Detail :  " + ex.Message.Replace("'", "''")
                    , DateAndTime.GetDateTime16Digit_Latin(), "", "", "");
                _host.SqlExecute(Query);
            }
        }

        private void FindName(out string StateName, out string CityName, out string PostNode_Name)
        {
            StateName = _host.SqlDataTable(String.Format("select ISNULL((select Pname from State where code={0}),'کل استان') ", param.StateCode)).Rows[0][0].ToString();
            CityName = _host.SqlDataTable(String.Format("select ISNULL((select Pname from City where code={0}),'کل شهر') ", param.CityCode)).Rows[0][0].ToString();
            PostNode_Name = _host.SqlDataTable(String.Format("select ISNULL((select Pname from PostNode where code={0}),'کل نقاط') ", param.PostNodeCode)).Rows[0][0].ToString();
        }

        protected void lnkDownloadDetail_Click(object sender, EventArgs e)
        {
            param = GetCurrentCollection();
            if (param.FirstDate == null)
                return;
            DataTable dt = new DataTable();
            dt = LoadReportDetail();
            exportGridToExcel(dt);
        }

        private DataTable LoadReportDetail()
        {
            try
            {
                string Query =
                    string.Format(@"EXEC sp_Udate_GhaboolAndMobadeleh_New
		                            @Date1 = '{0}',
		                            @Date2 = '{1}',
		                            @FirstState = {2},
		                            @FirstCity = {3},
		                            @FirstPostNode = {4},
		                            @LastState = {5},
                                    @UserId = '{6}',
                                    @IsInitialize = {7}
"
                                      , param.FirstDate
                                      , param.LastDate
                                      , param.StateCode
                                      , param.CityCode
                                      , param.PostNodeCode
                                      , param.LastStateCode
                                      ,  _LoginDetails.ID
                                      ,2);

                return _host.SqlDataTable(Query);
            }
            catch (Exception ex)
            {
                string Query = string.Format(@"EXECUTE sp_FilltblErrorProgrammer
                                       @Message=N'{0}'
                                      ,@DateError='{1}'
                                      ,@PhysicalPath=N'{2}'
                                      ,@UserHostAddress='{3}'
                                      ,@Browser='{4}'"
                    , "Error For Load Report :  sp_Udate_GhaboolAndMobadeleh  in Detail Segment ; Detail :  " + ex.Message.Replace("'", "''")
                    , DateAndTime.GetDateTime16Digit_Latin(), "", "", "");
                _host.SqlExecute(Query);
                return new DataTable();
            }
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

        public ReportObject GetCurrentCollection()
        {
            try
            {
                if (hfParamGhaboolMobadeleh.Value != "")
                {
                    byte[] b = System.Convert.FromBase64String(hfParamGhaboolMobadeleh.Value);
                    using (MemoryStream omemStrear = new MemoryStream(b))
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        param = ((ReportObject)binaryFormatter.Deserialize(omemStrear));
                    }
                }
                return param;
            }
            catch
            {
                return param;
            }
        }

    }
}