using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ANP.Bussiness.Models;
using ANP.Bussiness.Objects;
using ANP.Data.BaseData;
using ANP.Bussiness.Basic;
using ANP.Data;
using ANP.Common;

namespace ANP.Bussiness.Host
{

    public class UsersManagment
    {
        public enum UserLevel { Techadmin = 1001, Superadmin = 1002, Padmin = 1003, Financial = 1004, Menial = 1005, MenialWaiting = 1006, Analyze = 1007 };
        DataTable dt = new DataTable();
        IUsersManagment _host;
        LoginDetails UserInfo;
        Base BD = new Base();
        ANP.Data.UserData userData = new ANP.Data.UserData();

        public void Init(IUsersManagment host, LoginDetails UserDetail)
        {
            _host = host;
            UserInfo = UserDetail;
        }

        private void DisableControles()
        {
            _host.divState.Visible = true;
            _host.divCity.Visible = true;
            _host.divPostNode.Visible = true;
            switch (_host.ddl_Role.SelectedValue)
            {
                case "1002":
                    {
                        _host.divState.Visible = false;
                        _host.divCity.Visible = false;
                        _host.divPostNode.Visible = false;
                        break;
                    }
                case "1003":
                case "1004":
                    {
                        _host.divCity.Visible = false;
                        _host.divPostNode.Visible = false;
                        break;
                    }
            }

        }

        public void Role_Action()
        {
            DisableControles();
        }

        public void Fill_ddlRole()
        {
            Utility.FillCombo(BD.ReturnRolesForCreateUser(UserInfo.RoleID.ToString())
                , _host.ddl_Role, "ID", "Pname", false);

        }

        public void Fill_ddlState()
        {
            Utility.FillCombo(BD.ReturnStateForCreateUser(UserInfo.StateCode.ToString())
                    , _host.ddl_State, "Code", "Pname", false);
            if (UserInfo.RoleID > 1002)
            {
                _host.divState.Visible= false;
                _host.ddl_State.SelectedValue = UserInfo.StateCode.ToString();
            }

        }

        public void Fill_ddlStatus()
        {
            Utility.FillCombo(BD.ReturnStatus(), _host.ddl_Status, "id", "title", false);
        }

        public bool IsUniqueUserName()
        {
            int postnode = (_host.divPostNode.Visible ? Convert.ToInt32(_host.ddl_PostNode.SelectedValue.ToString()) : 0);
            return BD.UniqueUserName(Convert.ToInt32(_host.ddl_State.SelectedValue), postnode, _host.txt_Ename.Text.Trim());
        }

        public bool SaveNewUser()
        {

            UserData UD = new UserData();

            string StateCode = "0", CityCode = "0", PostNodeCode = "0";
            if (_host.divState.Visible == true)
                StateCode = _host.ddl_State.SelectedValue;
            if (_host.divCity.Visible == true)
                CityCode = _host.ddl_City.SelectedValue;
            if (_host.divPostNode.Visible == true)
                PostNodeCode = _host.ddl_PostNode.SelectedValue;

            bool Result = UD.SaveNewUser(_host.txt_Ename.Text, _host.txt_Pname.Text
                           , _host.txt_Pass.Text, _host.ddl_Role.SelectedValue
                           , StateCode,PostNodeCode
                           , (_host.ddl_Status.SelectedValue == "1" ? true : false)
                           , _host.hf_update.Value, _host.txt_Fmily.Text);
            return Result;
        }

        public string Validate(string ID)
        {
            string Message = string.Empty;

            if (_host.txt_Pname.Text == string.Empty)
                Message += "وارد کردن نام فارسی الزامی می باشد. \r\n";
            if (_host.txt_Ename.Text == string.Empty)
                Message += "وارد کردن نام کاربری الزامی می باشد. \r\n";
            if (_host.txt_Pass.Text == string.Empty && ID=="0")
                Message += "وارد کردن پسورد الزامی می باشد. \r\n";
            if (_host.txt_Pass.Text != _host.txt_RePass.Text)
                Message += "یکسان بودن رمزهای وارد شده الزامی می باشد. \r\n";
            if (_host.ddl_State.SelectedValue == "0")
                Message += "مشخص شدن استان مورد نظر الزامی میباشد. \r\n";
            if (_host.ddl_Role.SelectedValue == "1005" && _host.ddl_PostNode.SelectedValue == "0")
                Message += "مشخص شدن نقطه مبادله مورد نظر الزامی میباشد. \r\n";
            return Message;
        }

        public void Fill_MyGrid()
        {
            DataTable obj = BD.ReturnAllUserInfo(UserInfo.RoleID, UserInfo.StateCode);
            _host.Mygrd.DataSource = obj;
            _host.Mygrd.DataBind();
        }

        public void LoadUserInfoForEdit(string ID)
        {
            DataTable dtUser = userData.ReturnUserInfo(ID);
            if (dtUser.Rows.Count > 0)
            {
                _host.txt_Ename.Text = dtUser.Rows[0]["UserName"].ToString();
                _host.txt_Pname.Text = dtUser.Rows[0]["name"].ToString();
                _host.txt_Fmily.Text = dtUser.Rows[0]["family"].ToString();
                Fill_ddlRole();
                _host.ddl_Role.SelectedValue = dtUser.Rows[0]["RoleID"].ToString();

                DisableControles();

                if (_host.divState.Visible == true)
                    _host.ddl_State.SelectedValue = dtUser.Rows[0]["StateCode"].ToString();

                if (_host.divCity.Visible == true)
                {
                    Fill_ddlCity();
                    _host.ddl_City.SelectedValue = userData.ReturnCityByPostNodeCode(dtUser.Rows[0]["PostNodeID"].ToString());
                   
                }
                if (_host.divPostNode.Visible == true)
                {
                    Fill_ddlPostNode();
                    _host.ddl_PostNode.SelectedValue = dtUser.Rows[0]["PostNodeID"].ToString();
                }
                Fill_ddlStatus();
                _host.ddl_Status.SelectedValue = dtUser.Rows[0]["IsActive"].ToString() == "0" ? "2" : "1";


                _host.divState.Visible= false;
                _host.divCity.Visible = false;
                _host.divPostNode.Visible= false;
                _host.divRole.Visible= false;
                _host.divEname.Visible= false;

            }
        }

        public void ClearForm()
        {
            _host.txt_Ename.Text =
                _host.txt_Pname.Text =
                _host.txt_Fmily.Text=
                string.Empty;
        }

        public void Fill_ddlCity()
        {
            Utility.FillCombo(BD.ReturnCity(_host.ddl_State.SelectedValue), _host.ddl_City, "Code", "Pname", false);
        }

        public void Fill_ddlPostNode()
        {
            Utility.FillCombo(BD.ReturnPostnode(_host.ddl_City.SelectedValue), _host.ddl_PostNode, "Code", "pname", false);

        }
    }
}
