using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ANP.Common;
using ANP.Bussiness.Models;
using ANP.Data;
using ANP.Data.Object;
using ANP.Bussiness.Objects;
using ANP.Bussiness.Basic;
using System.Web.UI.WebControls;

namespace ANP.Bussiness.Models
{
    public class LoginInfo
    {
        ILoginModel _host;
        UserData uData = new UserData();
        DataTable dtCounty = new DataTable();

        private string _strUserName
        {
            get { return _host.txt_UserName.Text.Trim(); }
            set { _host.txt_UserName.Text = value; }
        }
        private string _strPassword
        {
            get { return _host.txt_Password.Text.Trim(); }
            set { _host.txt_Password.Text = value; }
        }



        public object chkUser()
        {
            DataTable dtUser = new DataTable();
            LoginDetails login = new LoginDetails();
            int State = Convert.ToInt32(_host.ddl_State.SelectedValue);
            int City = Convert.ToInt32(_host.ddl_City.SelectedValue);
            int postnode = Convert.ToInt32(_host.ddl_PostNode.SelectedValue);
            try
            {
                dtCounty = GetCountyByCity(City);

                if (postnode == 0 && City > 0)
                    return null;

                if (postnode > 0)
                {
                    //if (uData.chkUserWithLinkServer(_strUserName, _strPassword, postnode, out dtUser))
                    //{
                    //    login.Pname = dtUser.Rows[0]["name"].ToString();
                    //    login.UserName = _host.txt_UserName.Text.Trim();
                    //    login.RoleID = 1006;
                    //    login.UserId = Convert.ToInt32(dtUser.Rows[0]["UserId"]);

                    //    if (login.RoleID < 1005)
                    //    {
                    //        login.StateCode = Convert.ToInt32(dtUser.Rows[0]["StateCode"]);
                    //        login.CountyCode = Convert.ToInt32(dtUser.Rows[0]["CountyCode"]);
                    //        login.CityCode = Convert.ToInt32(dtUser.Rows[0]["CityCode"]);
                    //        login.PostNodeCode = Convert.ToInt32(dtUser.Rows[0]["PostNodeCode"]);
                    //    }
                    //    else
                    //    {
                    //        login.StateCode = Convert.ToInt32(_host.ddl_State.SelectedValue);
                    //        login.CountyCode = Convert.ToInt32(dtCounty.Rows[0]["COUNTY_CODE"].ToString());
                    //        login.CityCode = Convert.ToInt32(_host.ddl_City.SelectedValue);
                    //        login.PostNodeCode = Convert.ToInt32(_host.ddl_PostNode.SelectedValue);
                    //    }
                    //    login.StateName = _host.ddl_State.SelectedItem.Text;
                    //    login.CountyName = dtCounty.Rows[0]["COUNTY_Pname"].ToString();
                    //    login.CityName = _host.ddl_City.SelectedItem.Text;
                    //    login.PostNodeName = _host.ddl_PostNode.SelectedItem.Text;
                    //    login.RolePname = "متصدی";
                    //    login.RoleEname = "Menial";
                    //    return login;
                    //}
                    //else
                    //{
                        dtUser = uData.chkUser(_strUserName, _strPassword, postnode);
                        if (dtUser.Rows.Count == 1)
                        {
                            login.ID = dtUser.Rows[0]["ID"].ToString();
                            login.Pname = dtUser.Rows[0]["pname"].ToString();
                            login.UserName = dtUser.Rows[0]["UserName"].ToString();
                            login.RoleID = Convert.ToInt32(dtUser.Rows[0]["Role"]);
                            login.UserId = Convert.ToInt32(dtUser.Rows[0]["UserId"]);

                            if (login.RoleID < 1005)
                            {
                                login.StateCode = Convert.ToInt32(dtUser.Rows[0]["StateCode"]);
                                login.CountyCode = Convert.ToInt32(dtUser.Rows[0]["CountyCode"]);
                                login.CityCode = Convert.ToInt32(dtUser.Rows[0]["CityCode"]);
                                login.PostNodeCode = Convert.ToInt32(dtUser.Rows[0]["PostNodeCode"]);
                            }
                            else
                            {
                                login.StateCode = Convert.ToInt32(_host.ddl_State.SelectedValue);
                                login.CountyCode = Convert.ToInt32(dtCounty.Rows[0]["COUNTY_CODE"].ToString());
                                login.CityCode = Convert.ToInt32(_host.ddl_City.SelectedValue);
                                login.PostNodeCode = Convert.ToInt32(_host.ddl_PostNode.SelectedValue);
                            }
                            login.StateName = dtUser.Rows[0]["StateName"].ToString();
                            login.CountyName = dtUser.Rows[0]["CountyName"].ToString();
                            login.CityName = dtUser.Rows[0]["CityName"].ToString();
                            login.PostNodeName = dtUser.Rows[0]["PostNodeName"].ToString();
                            login.RolePname = dtUser.Rows[0]["RolePname"].ToString();
                            login.RoleEname = dtUser.Rows[0]["RoleEname"].ToString();
                            return login;
                        }
                        else { return null; }
                   // }
                }
                else
                {
                    dtUser = uData.chkTopUser(_strUserName, _strPassword, State);
                    if (dtUser.Rows.Count == 1)
                    {
                        login.ID = dtUser.Rows[0]["ID"].ToString();
                        login.Pname = dtUser.Rows[0]["pname"].ToString();
                        login.UserName = dtUser.Rows[0]["UserName"].ToString();
                        login.RoleID = Convert.ToInt32(dtUser.Rows[0]["Role"]);
                        login.UserId = Convert.ToInt32(dtUser.Rows[0]["UserId"]);

                        if (login.RoleID < 1005)
                        {
                            login.StateCode = Convert.ToInt32(dtUser.Rows[0]["StateCode"]);
                            login.CountyCode = Convert.ToInt32(dtUser.Rows[0]["CountyCode"]);
                            login.CityCode = Convert.ToInt32(dtUser.Rows[0]["CityCode"]);
                            login.PostNodeCode = Convert.ToInt32(dtUser.Rows[0]["PostNodeCode"]);
                        }
                        else
                        {
                            login.StateCode = Convert.ToInt32(_host.ddl_State.SelectedValue);
                            login.CountyCode = Convert.ToInt32(dtCounty.Rows[0]["COUNTY_CODE"].ToString());
                            login.CityCode = Convert.ToInt32(_host.ddl_City.SelectedValue);
                            login.PostNodeCode = Convert.ToInt32(_host.ddl_PostNode.SelectedValue);
                        }
                        login.StateName = dtUser.Rows[0]["StateName"].ToString();
                        login.CountyName = dtUser.Rows[0]["CountyName"].ToString();
                        login.CityName = dtUser.Rows[0]["CityName"].ToString();
                        login.PostNodeName = dtUser.Rows[0]["PostNodeName"].ToString();
                        login.RolePname = dtUser.Rows[0]["RolePname"].ToString();
                        login.RoleEname = dtUser.Rows[0]["RoleEname"].ToString();
                        return login;
                    }
                    else { return null; }
                }
            }

            catch
            {
                return null;
            }
        }

        public void InitializeLogin(ILoginModel hostform)
        {
            this._host = hostform;
        }

        public DataTable GetStateLogin()
        {
            return uData.GetStateLogin();
        }

        public DataTable GetCityLogin(string StateCode)
        {
            return uData.GetCityLogin(StateCode);
        }

        public DataTable GetPostNodeLogin(string CityCode)
        {
            return uData.GetPostNodeLogin(CityCode);
        }

        private DataTable GetCountyByCity(int CityCode)
        {
            dtCounty = uData.ReturnCountyByCityCode(CityCode);
            return dtCounty;
        }
    }
}
