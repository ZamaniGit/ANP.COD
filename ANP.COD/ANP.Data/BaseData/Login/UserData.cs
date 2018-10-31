using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ANP.Data
{
    public class UserData:DBConnector
    {
        string Query = string.Empty;

        public bool chkUserWithLinkServer(string UserName, string pass, int PostNode, out DataTable dtUser)
        {
            dtUser = new DataTable();
            try
            {
                string Query = string.Format("exec [LNK172_COD].PostExchangeCenter..CODAuthenticate @UserName='{0}' , @Password='{1}' ,  @PostnodeID={2}", UserName, pass, PostNode);
                dtUser = SqlDataTable(Query);
                if (dtUser.Rows.Count == 1)
                    return true;
                else
                    return false;
            }
            catch {
                return false;
            }
        }

        public DataTable chkUser(string UserName, string pass, int PostNode)
        {
            DataTable dtUser = new DataTable();
            dtUser = SqlDataTable(string.Format("exec SP_login @UserName='{0}' , @Password='{1}' ,  @Postnode={2}",UserName,pass,PostNode));

            return dtUser;
        }

        public bool SaveNewUser(string Ename, string Pname, string Pass, string Role, string State, string Postnode, bool IsActive, string ID, string Family)
        {

                Query = string.Format(@"exec sp_InsertNewUser @UserName='{0}',@Pname= N'{1}',@Password = '{2}',@Role= {3}
                ,@StateCode={4},@PostNodeCode={5},@IsActive={6},@UserID='{7}',@Family=N'{8}',@ID={9}", Ename, Pname, Pass, Role, State
                , Postnode, IsActive, ID, Family,0);
           try
           {
               SqlExecute(Query);
               return true;
           }
           catch { return false; }
        }

        public DataTable ReturnCurrentMenu(string Guid)
        {
            Query = "Select * from Prs_AdminMenu Where uID='" + Guid + "'";
            return SqlDataTable(Query);
        }

        public DataTable ReturnV_Menu(string permission, string ID)
        {
           Query = @"select MenuImage,id, ModuleKey,ltrim(rtrim(menuTitle))menuTitle, ParentID, ModuleFile,Ordering,uID,(select count(*) from Prs_AdminMenu pm Where pm.ParentID=Prs_AdminMenu.ID ) ChildCount 
            from Prs_AdminMenu Where showInMenu='Y' AND (Permission like ('%" + permission + "%') OR UserIDReservation like '%" + ID + "%' )     AND  AccessDenyUserID NOT LIKE  ('%" + ID + "%') order by Ordering";
             return SqlDataTable(Query);
        }

        public DataTable ReturnUserMenu(string permission,string ID)
        {
            Query = @"select MenuImage,id, ModuleKey,ltrim(rtrim(menuTitle))menuTitle, ParentID, ModuleFile,Ordering,uID,(select count(*) from Prs_AdminMenu pm Where pm.ParentID=Prs_AdminMenu.ID ) ChildCount 
            from Prs_AdminMenu Where showInMenu='Y' AND (Permission like ('%" + permission + "%') OR UserIDReservation like '%" + ID + "%' )     AND  AccessDenyUserID NOT LIKE  ('%" + ID + "%') order by Ordering";
            return SqlDataTable(Query);
        }

        public DataTable ReturnUserInfo(string  ID)
        {
            Query = string.Format("Select * From Users  where ID='{0}' ", ID);
            return SqlDataTable(Query);
        }

        public DataTable ReturnUserByUserNameAndPostnode(int postnode, string UserName)
        {
            Query = string.Format("Select * From Users  where PostnodeID={0} and UserName='{1}'", postnode, UserName);
            return SqlDataTable(Query);
        }

        public DataTable ReturnCountUserByUserNameAndPostnode(int postnode, string UserName)
        {
            Query = string.Format("Select Count(*) From Users  where PostnodeID={0} and UserName='{1}'", postnode, UserName);
            return SqlDataTable(Query);
        }

        public bool UpdatePassByPostNode(string Pass, string Username, int postnode)
        {
            try
            {
                Query = string.Format("exec sp_UpdatePass @pass='{0}' , @UserName='{1}' , @Postnode={2}", Pass, Username, postnode);
                SqlExecute(Query);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdatePassByState(string Pass, string Username, int postnode,int RoleID)
        {
            try
            {
                Query = string.Format("exec sp_UpdatePass @pass='{0}' , @UserName='{1}' , @Postnode={2} , @RoleID={3}", Pass, Username, postnode, RoleID);
                SqlExecute(Query);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable GetStateLogin()
        {
            try
            {
                Query = string.Format("exec SP_GetAllState ");
                return SqlDataTable(Query);
            }
            catch
            {
                return new DataTable();
            }
        }

        public DataTable GetCityLogin(string StateCode )
        {
            try
            {
                Query = string.Format("exec SP_GetAllCity @State_Code={0} ", Convert.ToInt32(StateCode));
                return SqlDataTable(Query);
            }
            catch
            {
                return new DataTable();
            }
        }

        public DataTable GetPostNodeLogin(string CityCode)
        {
            try
            {
                Query = string.Format("exec SP_GetAllPostNode @City_Code={0} ", Convert.ToInt32(CityCode));
                return SqlDataTable(Query);
            }
            catch
            {
                return new DataTable();
            }
        }

        public string ReturnCityByPostNodeCode(string PostNodeCode)
        {
            try
            {
                Query = string.Format("select City_CODE from PostNode where Code={0} ", PostNodeCode);
                return SqlDataTable(Query).Rows[0][0].ToString();
            }
            catch
            {
                return "0";
            }
        }

        public DataTable ReturnCountyByCityCode(int CityCode)
        {
            try
            {
                Query = string.Format(@"select 
                                        (select isnull((SELECT COUNTY_CODE FROM City where code={0} ),0)) COUNTY_CODE,
                                        (select isnull((SELECT PNAME FROM County where code in 
                                            (SELECT  COUNTY_CODE FROM City where code= {0})),'--')) COUNTY_Pname", CityCode);
                return SqlDataTable(Query);
            }
            catch
            {
                return new DataTable();
            }
        }

        public DataTable ReturnUserInfoByUserIdAndPass(string CurentPass, int PostNodeCode, string UserName, int RoleID, int StateCode)
        {
            try
            {
                if(RoleID==1005)
                    Query = string.Format("select * from users where Password='{0}' AND PostNodeID={1} AND UserName='{2}' AND RoleID={3} AND StateCode=0",
                        CurentPass, PostNodeCode, UserName, RoleID);
                else
                    Query = string.Format("select * from users where Password='{0}' AND PostNodeID=0 AND UserName='{1}' AND RoleID={2} AND StateCode={3}",
                        CurentPass, UserName, RoleID, StateCode);
                return SqlDataTable(Query);
            }
            catch
            {
                return new DataTable();
            }
        }

        public DataTable chkTopUser(string UserName, string Password, int State)
        {
            DataTable dtUser = new DataTable();
            dtUser = SqlDataTable(string.Format("exec SP_loginTopUser @UserName='{0}' , @Password='{1}' ,  @StateCode={2}", UserName, Password, State));

            return dtUser;
        }
    }
}
