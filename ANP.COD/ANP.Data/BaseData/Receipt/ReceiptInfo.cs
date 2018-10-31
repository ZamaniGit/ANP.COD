using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ANP.Data
{
    public class ReceiptInfo:DBConnector
    {
        string Query = "";
        DataTable dt = new DataTable();
        public DataTable SearchResult(string ReceiptNo,int StateCode)
        {
            try
            {
                Query = string.Format("exec SerachReceiptHistory '{0}',{1}", ReceiptNo, StateCode);
                dt = SqlDataTable(Query);
            }
            catch { }
            return dt;
        }

        public string ReturnReceiptToState(string ReceiptID, string Descriptions, int UserId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = SqlDataTable(string.Format(@"exec sp_UpdateReceiptInfoForReturnToState @Description='{0}',@ReceiptID={1} ,@UserID={2}", Descriptions, ReceiptID, UserId));
                return "";
            }
            catch { }
            return "خطا در اجرای دستورات";
        }

        public DataTable ReturnAllReceiptStateInOnDay(string StateCode, string Date)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = SqlDataTable(string.Format(@"exec sp_GetReceiptStateOfOnDay @StateCode={0},@Date='{1}' ", StateCode, Date));
            }
            catch { }
            return dt;
        }
    }
}
