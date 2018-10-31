using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ANP.Bussiness;
using ANP.Bussiness.Models;
using ANP.Bussiness.Objects;
using ANP.Common;

namespace ANP.COD
{
    public partial class _Default : System.Web.UI.Page
    {
        LoginDetails UserInfo = new LoginDetails();
        DefultInfo defaultClass = new DefultInfo();
        string actiontype = "";
        string ControlsPath = "~/";

        protected void Page_Load(object sender, EventArgs e)
        {

            UserValidate();
            StartRequest();
            if (!Page.IsPostBack)
            {
                Label1.Text = "  کاربر :    ";
                Label1.Text += UserInfo.Pname + "  [" + UserInfo.RolePname + " - " + UserInfo.StateName + "]";
                Label2.Text = DateAndTime.PersianDate("") + "&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            up.Update();

        }
        private void UserValidate()
        {
            if (null != Session["UserInfo"])
                UserInfo = Session["UserInfo"] as LoginDetails;
            else
                Response.Redirect("~/Login.aspx", true);
            //Response.Redirect("~/Test.aspx", true);
        }
        private void StartRequest()
        { 
            if (null == Request.QueryString["action"])
            {
                LoadOption("~/login.aspx");
                return;
            }
            else if (Request.QueryString["action"].Length != 36)
            {
                Response.Redirect("~/erorr.aspx");
            }
            else if (Request.QueryString["action"].ToString() == "fdaa5608-ac0a-4c8d-b01a-94cc5239f513")
            {
                Response.Redirect("~/Default.aspx?action=b4c96ed1-30a8-4766-9c07-80172e0cd1dd");
            }
            else if (Request.QueryString["action"].ToString() == "819acab1-8f83-425b-97e0-fda9e8c90fdf")
            {
                Session["UserInfo"] = null;
                Response.Redirect("~/Default.aspx");
            }
            actiontype = defaultClass.ReturnQueryString(Request.QueryString["action"].ToString());
            Guid g = new Guid();
            try
            {
                g = new Guid(actiontype);
            }
            catch (Exception ex)
            {
                Response.Redirect("~/erorr.aspx");
            }
            string controlname = "";
            DefultInfo defultInfo = new DefultInfo();
            DataTable dt = defultInfo.ReturnMenu(g.ToString());
            if (null == dt || dt.Rows.Count != 1)
                return;
            controlname = dt.Rows[0]["ModuleFile"].ToString();
            lbl_Navigator.Text = "  مکان فعلی :" + dt.Rows[0]["navigator"].ToString();
            if (string.Empty != controlname)
            {
                string controltoembed = ControlsPath + controlname;
                LoadOption(controltoembed);
            }
            else
                LoadOption("~/Forms/StartPage.ascx");
        }
        private bool LoadOption(string ctlName)
        {
            try
            {
                if (string.Empty != ctlName)
                {
                    
                        ph.Controls.Clear();
                        Control c = LoadControl(ctlName);
                        if (ctlName.Contains("Rep"))
                            plReport.Controls.Add(c);
                        else
                            ph.Controls.Add(c);

                    
                }
                return true;
            }
            catch (Exception e)
            {
                defaultClass.SaveLogError(e, ctlName,Server);
                return false;
            }
        }

        #region Implemante

        #endregion
    }
}