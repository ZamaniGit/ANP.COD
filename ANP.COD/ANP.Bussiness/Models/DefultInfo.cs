using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ANP.Data;
using ANP.Common;

namespace ANP.Bussiness.Models
{
    public class DefultInfo
    {
        UserData User_Data = new UserData();
        DBConnector db = new DBConnector();

        public DataTable ReturnMenu(string Guid)
        {
            return User_Data.ReturnCurrentMenu(Guid);
        }

        public DataTable ReturnV_Menu(string permission, string ID)
        {
            return User_Data.ReturnV_Menu(permission, ID);
        }

        public DataTable ReturnUserMenu(string permission, string ID)
        {
            return User_Data.ReturnUserMenu(permission, ID);
        }

        public string ReturnQueryString(string QueryString)
        {
            return db.FilteringQuery(QueryString);
        }

        public void SaveLogError(Exception e, string ctlName, HttpServerUtility Server)
        {
                try
                {
                    string Query = string.Format(@"EXECUTE sp_FilltblErrorProgrammer
                                       @Message=N'{0}'
                                      ,@DateError='{1}'
                                      ,@PhysicalPath=N'{2}'
                                      ,@UserHostAddress='{3}'
                                      ,@Browser='{4}'"
                        , e.Message.Replace("'", "")
                        , DateAndTime.GetDateTime16Digit_Latin()
                        , ctlName
                        , "", "");
                    db.SqlExecute(Query);
                }
                catch
                {
                    string strErrorMessage =
                        string.Format
                            (
                                "{0} Time: {1:yyyy/MM/dd - HH:mm:ss}, Path: {2}, User IP: {3}",
                                e.Message,
                                System.DateTime.Now,
                                ctlName,
                                ""
                            );
                  
                        System.IO.StreamWriter oStream = null;

                        try
                        {
                            string strApplicationLogRootRelativePathName =
                                "~/App_Data/Logs/Application.log";

                            string strApplicationLogPathName =
                                Server.MapPath(strApplicationLogRootRelativePathName);

                              lock (this)
                    {
                            oStream =
                                new System.IO.StreamWriter
                                    (strApplicationLogPathName, true, System.Text.Encoding.UTF8);

                            oStream.WriteLine(strErrorMessage);}
                        }
                        catch
                        {
                        }
                        finally
                        {
                            if (oStream != null)
                            {
                                oStream.Dispose();
                                oStream = null;
                            }
                        }
                    }
                
            }
        
    }
}