using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANP.Bussiness;
using ANP.Bussiness.Models;

using ANP.Bussiness.Basic;
using ANP.Bussiness.Objects;
using ANP.Common;

namespace ANP.COD
{
    public partial class Login : System.Web.UI.Page, ILoginModel
    {
        LoginInfo Logins = new LoginInfo();
        //UserData Udata = new UserData();

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "anything", "test();", true);
            Logins.InitializeLogin(this);
            Session["UserInfo"] = null;
            if (false == Page.IsPostBack)
            {
                LoadFrom();
            }
        }

        private void LoadFrom()
        {
            if (Request.Cookies["CookUserInfo"] == null)
            {
                Utility.FillCombo(Logins.GetStateLogin(), ddlState, "CODE", "PNAME", true);
                ddlState_SelectedIndexChanged(null, null);
                ddlCity_SelectedIndexChanged(null, null);
            }
            else
            {
                Utility.FillCombo(Logins.GetStateLogin(), ddlState, "CODE", "PNAME", true);
                ddlState.SelectedValue = Request.Cookies["CookUserInfo"]["State"];
                ddlState_SelectedIndexChanged(null, null);
                ddlCity.SelectedValue = Request.Cookies["CookUserInfo"]["City"];
                ddlCity_SelectedIndexChanged(null, null);
                ddlPostNode.SelectedValue = Request.Cookies["CookUserInfo"]["PostNode"]; 

            }
            txt_Password.Text = txt_UserName.Text = string.Empty;

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            lbl_msg.Text = string.Empty;
            string Query = "";
            string Message= string.Format("userName= {0} , Pass= {1} , Date= {2} , IP= {3} , Browser= {4}", txt_UserName.Text, txt_Password.Text
                            , DateAndTime.GetDateTime16Digit(), Request.UserHostAddress , Request.Browser.Browser );

            Query = string.Format(@"insert INTO tblLog ( Title,Detail ) VALUES (N'{0}',N'{1}')", "صفحه ورود ",Message.Replace("'", "") );
            Utility.RunQuery(Query);
            if (Request.UserHostAddress.Replace("'", "") == "10.1.1.52" || Request.UserHostAddress == "10.1.1.52")
                {
                     Query = string.Format(@"EXECUTE sp_FilltblErrorProgrammer
                                       @Message=N'{0}'
                                      ,@DateError='{1}'
                                      ,@PhysicalPath=N'{2}'
                                      ,@UserHostAddress='{3}'
                                      ,@Browser='{4}'"
                                , string.Format("userName= {0} , Pass= {1}", txt_UserName.Text, txt_Password.Text)
                                , DateAndTime.GetDateTime16Digit_Latin()
                                , "صفحه ورود . کاربر مشکوک سعی در ورود به نرم افزار کرد ."
                                , Request.UserHostAddress.Replace("'", "")
                                , Request.Browser.Browser.Replace("'", ""));
                    Utility.RunQuery(Query);
                    Response.Redirect("~/Wrongdoer.aspx", true);

                }
            
            object UserData = Logins.chkUser();
            if (UserData != null)
            {
                Session["UserInfo"] = UserData;
                lbl_msg.Text = "";
                FillCookie(UserData);
                Response.Redirect("~/Default.aspx?action=b4c96ed1-30a8-4766-9c07-80172e0cd1dd", true);
            }
            lbl_msg.Text = "کاربر مورد نظر یافت نشد";
        }

        private void FillCookie(object UserData)
        {
            LoginDetails LD = (LoginDetails)UserData;

            HttpCookie CookUserInfo = new HttpCookie("CookUserInfo");

            CookUserInfo.Values["PostNode"]=LD.PostNodeCode.ToString();
            CookUserInfo.Values["City"]=LD.CityCode.ToString();
            CookUserInfo.Values["State"]=LD.StateCode.ToString();

            CookUserInfo.Expires = DateTime.Now.AddDays(3);
            Response.Cookies.Add(CookUserInfo); 
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utility.FillCombo(Logins.GetCityLogin(ddlState.SelectedValue), ddlCity, "CODE", "PNAME", true);
            ddlCity_SelectedIndexChanged(null, null);

        }

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utility.FillCombo(Logins.GetPostNodeLogin(ddlCity.SelectedValue), ddlPostNode, "CODE", "PNAME", true);           
        }

        #region ILoginModel Members
        TextBox ILoginModel.txt_UserName
        {
            get { return txt_UserName; }
        }
        TextBox ILoginModel.txt_Password
        {
            get { return txt_Password; }
        }

        DropDownList ILoginModel.ddl_State
        {
            get { return ddlState; }
        }

        DropDownList ILoginModel.ddl_City
        {
            get { return ddlCity; }
        }

        DropDownList ILoginModel.ddl_PostNode
        {
            get { return ddlPostNode; }
        }
        #endregion ILoginModel Members
    }
}