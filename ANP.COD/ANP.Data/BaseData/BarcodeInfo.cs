using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ANP.Data
{
    public class BarcodeInfo : DBConnector
    {
        //string Query = string.Empty;
        //DataTable dt;

        //public void UpdateChangeRowInMyGrid(string RowID, string NewStatus, string Date10Digit)
        //{
        //    try
        //    {
        //        if(NewStatus=="11")
        //            Query = string.Format("UPDATE ParcelList SET StatusID={0} , LastChangeDate='{1}' , WaitingParcel='Y' WHERE id={2}", NewStatus,Date10Digit, RowID);
        //        else
        //            Query = string.Format("UPDATE ParcelList SET StatusID={0} , LastChangeDate='{1}' WHERE id={2}", NewStatus, Date10Digit, RowID);
        //        SqlExecute(Query);
        //        UpdateStateReturning(RowID, NewStatus);
        //    }
        //    catch { }
        //}

        //private void UpdateStateReturning(string RowID, string NewStatus)
        //{
        //    int DayForBack = -1;
        //    Query = string.Format(" SELECT DayForBack FROM NoDelivery where id={0}", NewStatus);
        //    DayForBack= Convert.ToInt32(SqlReturn(Query));
        //    if (DayForBack >= 0)
        //    {
        //        Query = string.Format("UPDATE ParcelList SET Returning='Y' WHERE id={0}", RowID);
        //        SqlExecute(Query);
        //    }
        //}

        //public DataTable ReturnAllStateForBarcode(bool Del_Row)
        //{
        //    dt = new DataTable();
        //    try
        //    {
        //        Query = string.Format("SELECT id,title FROM NoDelivery where deleted='N' ");
        //        if (Del_Row == false)
        //            Query += " AND id>0";
        //        Query += " Order By Orders";
        //        dt = SqlDataTable(Query);
        //    }
        //    catch { }
        //    return dt;
        //}

        //public DataTable GetAllBarcodeStateByBarcode(int PostNodeCode, int UserId, int RoleID, string txtBarcodeSearch, string Returning)
        //{
        //    dt = new DataTable();
        //    try
        //    {
        //        Query = string.Format("EXEC sp_GetPListSetStatusByBarCode {0},{1},{2},N'{3}','{4}'", PostNodeCode, UserId, RoleID, txtBarcodeSearch, Returning);
        //        dt = SqlDataTable(Query);
        //    }
        //    catch { }
        //    return dt;
        //}

        //public DataTable GetAllBarcodeStateByDate(int PostNodeCode, int UserId,int RoleID, string Fdate, string Ldate,string Returning)
        //{
        //    dt = new DataTable();
        //    try
        //    {
        //        Query = string.Format("EXEC sp_GetPListSetStatusByDate {0},{1},{2},N'{3}',N'{4}','{5}'", PostNodeCode, UserId, RoleID, Fdate, Ldate, Returning);
        //        dt = SqlDataTable(Query);
        //    }
        //    catch { }
        //    return dt;
        //}

        //public DataTable ReturnAllStateForReturningBarcode()
        //{
        //    dt = new DataTable();
        //    try
        //    {
        //        Query = string.Format("SELECT id,title FROM NoDelivery Where id in (7,8,9,11,12) ");
        //        dt = SqlDataTable(Query);
        //    }
        //    catch { }
        //    return dt;
        //}

        //public DataTable ReturnAllStateForWaitingBarcode()
        //{
        //    dt = new DataTable();
        //    try
        //    {
        //        Query = string.Format("select -2 as id ,'بدون تغییر' as title union select id,title  from dbo.NoDelivery where id=12");
        //        dt = SqlDataTable(Query);
        //    }
        //    catch { }
        //    return dt;
        //}

        //public void UpdateChangeRowInMyGridForWaiting(string RowID,string Date10Digit)
        //{
        //    try
        //    {
        //        Query = string.Format("UPDATE ParcelList SET WaitingParcel='Y' , LastChangeDate='{0}' WHERE id={1}",Date10Digit, RowID);
        //        SqlExecute(Query);
        //    }
        //    catch { }
        //}
    }
}
