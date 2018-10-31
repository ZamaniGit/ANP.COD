using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANP.Bussiness.Objects
{
    public class LoginDetails
    {
        private string _ID = "";
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _Pname = "";
        public string Pname
        {
            get { return _Pname; }
            set { _Pname = value; }
        }

        private string _UserName = "";
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private int _UserId;
        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        private int _RoleID;
        public int RoleID
        {
            get { return _RoleID; }
            set { _RoleID = value; }
        }

        private string _RolePname;
        public string RolePname
        {
            get { return _RolePname; }
            set { _RolePname = value; }
        }

        private string _RoleEname;
        public string RoleEname
        {
            get { return _RoleEname; }
            set { _RoleEname = value; }
        }

        private int _StateCode;
        public int StateCode
        {
            get { return _StateCode; }
            set { _StateCode = value; }
        }

        private string _StateName;
        public string StateName
        {
            get { return _StateName; }
            set { _StateName = value; }
        }

        private int _CountyCode;
        public int CountyCode
        {
            get { return _CountyCode; }
            set { _CountyCode = value; }
        }

        private string _CountyName;
        public string CountyName
        {
            get { return _CountyName; }
            set { _CountyName = value; }
        }

        private int _CityCode;
        public int CityCode
        {
            get { return _CityCode; }
            set { _CityCode = value; }
        }

        private string _CityName;
        public string CityName
        {
            get { return _CityName; }
            set { _CityName = value; }
        }

        private int _PostNodeCode;
        public int PostNodeCode
        {
            get { return _PostNodeCode; }
            set { _PostNodeCode = value; }
        }

        private string _PostNodeName;
        public string PostNodeName
        {
            get { return _PostNodeName; }
            set { _PostNodeName = value; }
        }

        public LoginDetails()
        {

        }

    }
}
