using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using ANP.Common;
using ANP.Bussiness.Basic;

namespace ANP.COD
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            if ((Server != null) &&
             (Server.GetLastError() != null) &&
             (Server.GetLastError().GetBaseException() != null))
            {
                 
                System.Exception ex =
                    Server.GetLastError().GetBaseException();
                try
                {
                    string Query = string.Format(@"EXECUTE sp_FilltblErrorProgrammer
                                       @Message=N'{0}'
                                      ,@DateError='{1}'
                                      ,@PhysicalPath=N'{2}'
                                      ,@UserHostAddress='{3}'
                                      ,@Browser='{4}'"
                        , ex.Message.Replace("'","")
                        , DateAndTime.GetDateTime16Digit_Latin()
                        , Request.PhysicalPath.Replace("'", "")
                        , Request.UserHostAddress.Replace("'", "")
                        , Request.Browser.Browser.Replace("'", ""));
                    Utility.RunQuery(Query);
                }
                catch
                {
                    string strErrorMessage =
                        string.Format
                            (
                                "{0} Time: {1:yyyy/MM/dd - HH:mm:ss}, Path: {2}, User IP: {3}",
                                ex.Message,
                                System.DateTime.Now,
                                Request.PhysicalPath,
                                Request.UserHostAddress
                            );
                    Application.Lock();
                    System.IO.StreamWriter oStream = null;

                    try
                    {
                        string strApplicationLogRootRelativePathName =
                            "~/App_Data/Logs/Application.log";

                        string strApplicationLogPathName =
                            Server.MapPath(strApplicationLogRootRelativePathName);

                        oStream =
                            new System.IO.StreamWriter
                                (strApplicationLogPathName, true, System.Text.Encoding.UTF8);

                        oStream.WriteLine(strErrorMessage);
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
                    Application.UnLock();
                }

            }

            Response.Redirect("~/erorr.aspx", true);

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
