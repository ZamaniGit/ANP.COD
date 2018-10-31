using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace ANP.Data.BaseData
{
    public class Base : DBConnector
    {
        public DataTable ReturnStateForCreateUser(string StateCode)
        {
            string Query = string.Format("select Code,pname from State where code>0 ");
            return SqlDataTable(Query);
        }

        public DataTable ReturnCounty(string StateCode)
        {
            string Query = "";
            Query = string.Format("SP_GetAllCountry @State_code={0}", StateCode);
            return SqlDataTable(Query);
        }

        public DataTable ReturnCity(string CountyCode, string StateCode)
        {
            string Query = "exec SP_GetAllCity @State_Code=" + StateCode;
            return SqlDataTable(Query);
        }

        public DataTable ReturnCity(string StateCode)
        {
            string Query = "exec SP_GetAllCity @State_Code=" + StateCode;
            return SqlDataTable(Query);
        }

        public DataTable ReturnAllMovozeh(int PostNodeCode, int UserID)
        {

            string Query = string.Format("exec SP_GetAllMovozeh @PostNodeCode={0} , @UserID={1}", PostNodeCode, UserID);
            return SqlDataTable(Query);
        }

        public DataTable ReturnPostnode(string CityCode)
        {
            DataTable dt = new DataTable();
            string Query = string.Format("select  Code , pname from postnode where City_Code={0} and POSTNODE_GROUP_CODE =6 AND ISACTIVE=1", CityCode);
            return SqlDataTable(Query);

        }

        public DataTable ReturnRolesForCreateUser(string RoleID)
        {
            string Query = string.Format("Select ID , pname from UserRoles  ");
            //تعریف کاربر مالی توسط مدیر استان 
            //if (RoleID == "1001")
            //    Query += " id in (1002,1003)";
            //else if (RoleID=="1003")
            //    Query += " id in (1004)";

            if (RoleID == "1001")
                Query += " where id in (1002,1003,1004,1005)";
            if (RoleID == "1003")
                Query += " where id in (1004,1005)";
            return SqlDataTable(Query);
        }

        public DataTable lstRoles()
        {
            return SqlDataTable("select  id , Pname from UserRoles order by id ");
        }

        public DataTable ReturnStatus()
        {
            return SqlDataTable("select  id , title from UserStatus order by id ");
        }

        public DataTable lstState()
        {
            return SqlDataTable("select  Code , Pname from State where code>0 order by Pname ");
        }

        public bool UniqueUserName(int State, int PostNode, string UserName)
        {
            string Query = string.Format(" select * from Users where UserName='{0}' AND PostnodeID={1} And StateCode={2}  ", UserName, PostNode, State);

            DataTable dt = new DataTable();
            dt = SqlDataTable(Query);
            if (dt.Rows.Count > 0)
                return false;
            else
                return true;
        }

        public DataTable ReturnAllUserInfo(int RoleID, int StateCode)
        {
            string Query = string.Empty;
            DataTable dt = new DataTable();
            Query = string.Format("exec sp_GetAllUsersByRoleFilter {0},{1} ", RoleID, StateCode);
            dt = SqlDataTable(Query);
            return dt;
        }

        public DataTable ReturnReceiptFinancialMood()
        {
            string Query = string.Empty;
            DataTable dt = new DataTable();
            Query = string.Format("select  Value , Title from ReceiptFinancialMood order by Value ");
            dt = SqlDataTable(Query);
            return dt;
        }

        public DataTable ReturnHolidayList()
        {
            string Query = string.Empty;
            DataTable dt = new DataTable();
            Query = string.Format(@"SELECT (ROW_NUMBER()over(order by id )) as RowNum, ID,Detail,[Date],InsertDate
                                    ,EntryDate,UserID,Active FROM Holiday WHERE Active='Y'");
            dt = SqlDataTable(Query);
            return dt;
        }

        public void SaveNewHoliday(string Date, string Detail, int UserID)
        {
            string Query = string.Empty;
            Query = string.Format("Exec sp_ChangeHoliday @Date='{0}',@UserID={1},@Detail=N'{2}'", Date, UserID, Detail);
            SqlExecute(Query);
            return;
        }

        public DataTable ReturnFinancialMoodList()
        {
            DataTable dt = new DataTable();
            string Query = string.Empty;
            Query = string.Format("SELECT (ROW_NUMBER()over(order by id )) as RowNum,Value,Title FROM ReceiptFinancialMood");
            dt = SqlDataTable(Query);
            return dt;
        }

        public void SaveNewFinancialMood(string Detail)
        {
            string Query = string.Empty;
            Query = string.Format("INSERT INTO ReceiptFinancialMood (Value,Title) VALUES ((select MAX(Value)+1 from ReceiptFinancialMood),N'{0}')", Detail);
            SqlExecute(Query);
            return;
        }

        public DataTable GetAllStatusParcels()
        {
            DataTable dt = new DataTable();
            string Query = string.Empty;
            Query = string.Format("SELECT ID ,Status as Name FROM ExchangeStatuses Where ID != 51 order by Ordering");
            dt = SqlDataTable(Query);
            return dt;
        }

        public DataTable GetAllStatusOfOneParcels(String ParentCode)
        {
            DataTable dt = new DataTable();
            string Query = string.Empty;
            Query = string.Format("SELECT ID ,Status as Name FROM ExchangeStatuses Where ID != 51 AND isuse=1 AND StatusGroupCode IN ('{0}')  order by Ordering", ParentCode);
            dt = SqlDataTable(Query);
            return dt;
        }

        public DataTable GetAllLocalContracts(int PostNode)
        {
            DataTable dt = new DataTable();
            string Query = string.Empty;
            Query = string.Format(@"SELECT distinct l.ID ,((select pname from state where code=m.[FirstStateCode])+' -- ' +l.ContractTitle) as ContractTitle FROM LocalContracts l inner join ContractMap m ON l.id=m.ContractID and l.StateCode=m.FirstStateCode where m.PostNodeCode={0}  AND ContractType='LC' Order By ContractTitle", PostNode);
            dt = SqlDataTable(Query);
            return dt;
        }

        public DataTable GetAllParentStatus()
        {
            DataTable dt = new DataTable();
            string Query = string.Empty;
            Query = string.Format("SELECT Code  , Status as Name FROM ExchangeStatusesGroup Where IsActive='Y' order by Ordering");
            dt = SqlDataTable(Query);
            return dt;
        }

        public DataTable GetAllServiceType()
        {
            DataTable dt = new DataTable();
            string Query = string.Empty;
            Query = string.Format("SELECT Code  , Title as Name FROM ServiceCodeType order by Ordering");
            dt = SqlDataTable(Query);
            return dt;
        }

        public DataTable GetAllExchangeStoreByStatus(string Status, int PostNodeCode, int UserId, string Fdate, string Ldate)
        {
            DataTable dt = new DataTable();
            string Query = string.Empty;
            Query = string.Format("exec SP_GetAllExchangeStoreByStatus @postnode={0} ,@UserID={1} , @Status={2}, @Fdate='{3}', @Ldate='{4}' ",
                PostNodeCode, UserId, Status, Fdate, Ldate);
            dt = SqlDataTable(Query);
            return dt;
        }

        public DataTable GetAllExchangeStoreByStatusDetail(string ID)
        {
            DataTable dt = new DataTable();
            string Query = string.Empty;
            Query = string.Format("exec SP_GetAllExchangeStoreByStatusDetail @ExchangeStoreID={0} ", ID);
            dt = SqlDataTable(Query);
            return dt;
        }

        public DataTable ReturnCityByCountry(string CountryCode)
        {
            DataTable dt = new DataTable();
            string Query = string.Empty;
            Query = string.Format("exec SP_GetAllCityByCountry @Country_Code={0} ", CountryCode);
            dt = SqlDataTable(Query);
            return dt;
        }

        public DataTable GetAllGlobalContracts(int PostNode)
        {
            DataTable dt = new DataTable();
            string Query = string.Empty;
            Query = string.Format(@"SELECT distinct G.ID , G.ContractTitle FROM GlobalContracts G inner join ContractMap m ON G.id=m.ContractID where m.PostNodeCode={0}  AND m.ContractType='GC' Order By ContractTitle", PostNode);
            dt = SqlDataTable(Query);
            return dt;
        }
    }
}
