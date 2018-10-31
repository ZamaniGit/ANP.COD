using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ANP.Data.BaseData.Report
{
    public class ReportData : DBConnector
    {
        string Query = string.Empty;
        DataTable dt;

        public DataTable ReturnReceiptState()
        {
            try
            {
                Query = string.Format("select Flag,Title From ReceiptApproveFlag union All Select 'X','بدون فیش'");
                dt = SqlDataTable(Query);
            }
            catch (Exception ex)
            {
                string Query = string.Format(@"EXECUTE sp_FilltblErrorProgrammer
                                                                   @Message=N'{0}'
                                                                  ,@DateError='{1}'
                                                                  ,@PhysicalPath=N'{2}'
                                                                  ,@UserHostAddress='{3}'
                                                                  ,@Browser='{4}'"
                                                            , "Error For Load Report :  rptCountDebitForState ; Detail :  " + ex.Message.Replace("'", "''"), "", "", "", "");
                SqlDataSet(Query);
                dt = new DataTable();
            }
            return dt;
        }

        public DataTable ReturnOneState(int StateCode)
        {
            try
            {
                Query = string.Format("select Code,PName From State Where Code={0}", StateCode);
                dt = SqlDataTable(Query);
            }
            catch (Exception ex)
            {
                string Query = string.Format(@"EXECUTE sp_FilltblErrorProgrammer
                                                                   @Message=N'{0}'
                                                                  ,@DateError='{1}'
                                                                  ,@PhysicalPath=N'{2}'
                                                                  ,@UserHostAddress='{3}'
                                                                  ,@Browser='{4}'"
                                                            , "Error For Load Report :  rptCountDebitForState ; Detail :  " + ex.Message.Replace("'", "''"), "", "", "", "");
                SqlDataSet(Query);
                dt = new DataTable();
            }
            return dt;
        }

        public DataTable ReturnState()
        {
            try
            {
                Query = string.Format("exec SP_GetAllState");
                dt = SqlDataTable(Query);
            }
            catch (Exception ex)
            {
                string Query = string.Format(@"EXECUTE sp_FilltblErrorProgrammer
                                                                   @Message=N'{0}'
                                                                  ,@DateError='{1}'
                                                                  ,@PhysicalPath=N'{2}'
                                                                  ,@UserHostAddress='{3}'
                                                                  ,@Browser='{4}'"
                                                            , "Error For Load Report :  rptCountDebitForState ; Detail :  " + ex.Message.Replace("'", "''"), "", "", "", "");
                SqlDataSet(Query);
                dt = new DataTable();
            }
            return dt;
        }

        public DataTable ReturnStateBedonehManategh()
        {
            try
            {
                Query = string.Format("Select [CODE],[PNAME] From [State] where Code>0 and Code<40 order by PNAME");
                dt = SqlDataTable(Query);
            }
            catch (Exception ex)
            {
                string Query = string.Format(@"EXECUTE sp_FilltblErrorProgrammer
                                                                   @Message=N'{0}'
                                                                  ,@DateError='{1}'
                                                                  ,@PhysicalPath=N'{2}'
                                                                  ,@UserHostAddress='{3}'
                                                                  ,@Browser='{4}'"
                                                            , "Error For Load Report :  rptCountDebitForState ; Detail :  " + ex.Message.Replace("'", "''"), "", "", "", "");
                SqlDataSet(Query);
                dt = new DataTable();
            }
            return dt;
        }

        public DataTable ReturnOneCity(string StateCode, int City)
        {
            try
            {
                Query = string.Format("select Code,Pname from City Where STATE_CODE={0} AND Code={1} ", Convert.ToInt32(StateCode), City);
                dt = SqlDataTable(Query);
            }
            catch (Exception ex)
            {
                string Query = string.Format(@"EXECUTE sp_FilltblErrorProgrammer
                                                                   @Message=N'{0}'
                                                                  ,@DateError='{1}'
                                                                  ,@PhysicalPath=N'{2}'
                                                                  ,@UserHostAddress='{3}'
                                                                  ,@Browser='{4}'"
                                                            , "Error For Load Report :  rptCountDebitForState ; Detail :  " + ex.Message.Replace("'", "''"), "", "", "", "");
                SqlDataSet(Query);
                dt = new DataTable();
            }
            return dt;
        }

        public DataTable ReturnCity(string StateCode)
        {
            try
            {
                Query = string.Format("exec SP_GetAllCity @State_Code={0} ", Convert.ToInt32(StateCode));
                dt = SqlDataTable(Query);
            }
            catch (Exception ex)
            {
                string Query = string.Format(@"EXECUTE sp_FilltblErrorProgrammer
                                                                   @Message=N'{0}'
                                                                  ,@DateError='{1}'
                                                                  ,@PhysicalPath=N'{2}'
                                                                  ,@UserHostAddress='{3}'
                                                                  ,@Browser='{4}'"
                                                            , "Error For Load Report :  rptCountDebitForState ; Detail :  " + ex.Message.Replace("'", "''"), "", "", "", "");
                SqlDataSet(Query);
                dt = new DataTable();
            }
            return dt;
        }

        public DataTable ReturnOnePostNode(string CityCode, int postnode)
        {
            try
            {
                Query = string.Format("select Code,Pname from PostNode Where City_CODE={0} AND Code={1} ", Convert.ToInt32(CityCode), postnode);
                dt = SqlDataTable(Query);
            }
            catch (Exception ex)
            {
                string Query = string.Format(@"EXECUTE sp_FilltblErrorProgrammer
                                                                   @Message=N'{0}'
                                                                  ,@DateError='{1}'
                                                                  ,@PhysicalPath=N'{2}'
                                                                  ,@UserHostAddress='{3}'
                                                                  ,@Browser='{4}'"
                                                            , "Error For Load Report :  rptCountDebitForState ; Detail :  " + ex.Message.Replace("'", "''"), "", "", "", "");
                SqlDataSet(Query);
                dt = new DataTable();
            }
            return dt;
        }

        public DataTable ReturnPostNode(string CityCode)
        {
            try
            {
                Query = string.Format("exec SP_GetAllPostNode @City_Code={0} ", Convert.ToInt32(CityCode));
                dt = SqlDataTable(Query);
            }
            catch (Exception ex)
            {
                string Query = string.Format(@"EXECUTE sp_FilltblErrorProgrammer
                                                                   @Message=N'{0}'
                                                                  ,@DateError='{1}'
                                                                  ,@PhysicalPath=N'{2}'
                                                                  ,@UserHostAddress='{3}'
                                                                  ,@Browser='{4}'"
                                                            , "Error For Load Report :  rptCountDebitForState ; Detail :  " + ex.Message.Replace("'", "''"), "", "", "", "");
                SqlDataSet(Query);
                dt = new DataTable();
            }
            return dt;
        }

        public DataTable ReturnPostNodeGhabool(string CityCode)
        {
            try
            {
                Query = string.Format("exec SP_GetAllPostNodeGhabool @City_Code={0} , @PostNodeCode=-1 ", Convert.ToInt32(CityCode));
                dt = SqlDataTable(Query);
            }
            catch (Exception ex)
            {
                string Query = string.Format(@"EXECUTE sp_FilltblErrorProgrammer
                                                                   @Message=N'{0}'
                                                                  ,@DateError='{1}'
                                                                  ,@PhysicalPath=N'{2}'
                                                                  ,@UserHostAddress='{3}'
                                                                  ,@Browser='{4}'"
                                                            , "Error For Load Report :  rptCountDebitForState ; Detail :  " + ex.Message.Replace("'", "''"), "", "", "", "");
                SqlDataSet(Query);
                dt = new DataTable();
            }
            return dt;
        }

        public DataTable ReturnUser(int RoleID, int UserID, int StateCode, int PostNodeCode, int SelectedStateCode, int SelectedCityCode, int SelectedPostNodeCode)
        {
            try
            {
                Query = string.Format(
                    @"Exec sp_GetUsersReport @RoleID={0} , @UserID={1} , @StateCode={2} , @PostnodeID={3} 
                        , @SelectedStateCode={4},@SelectedCityCode={5}, @SelectedPostNodeCode={6}"
                        , RoleID, UserID, StateCode, PostNodeCode, SelectedStateCode, SelectedCityCode, SelectedPostNodeCode);

                //                Query =
                //                    string.Format(@"select 
                //	                    UserID,(Name+' '+Family + ' _ ' + ( select pname from UserRoles where id=Users.RoleID )) as Name 
                //                    from 
                //	                    Users 
                //                    Where 
                //	                    (
                //                            (
                //		                        ((PostnodeID = {0}) OR ({0}=0)) AND
                //		                        ((PostnodeID in ( select code from postnode where  CITY_CODE={1})) OR ({1}=-1)) AND
                //		                        ((PostnodeID in (select code from postnode where  CITY_CODE in 
                //								    (
                //									        (select code from city where STATE_CODE= {2} and {2}<100)
                //									    union all (select code from city where CODE= {2} and {2}>100) 
                //								    )
                //							    ) OR ({2}=-1)))
                //                            ) OR
                //                            (
                //                               StateCode in ((select code from city where STATE_CODE= {2} and {2}<100)
                //								union all (select code from city where CODE= {2} and {2}>100) )
                //                            )
                //                        )
                //	                    AND IsActive=1 
                //	                    Order By RoleID,Name"
                //                    , Convert.ToInt32(PostNodeCode)
                //                    , Convert.ToInt32(CityCode)
                //                    , Convert.ToInt32(StateCode));
                dt = SqlDataTable(Query);
            }
            catch (Exception ex)
            {
                string Query = string.Format(@"EXECUTE sp_FilltblErrorProgrammer
                                                                   @Message=N'{0}'
                                                                  ,@DateError='{1}'
                                                                  ,@PhysicalPath=N'{2}'
                                                                  ,@UserHostAddress='{3}'
                                                                  ,@Browser='{4}'"
                                                            , "Error For Load Report :  rptCountDebitForState ; Detail :  " + ex.Message.Replace("'", "''"), "", "", "", "");
                SqlDataSet(Query);
                dt = new DataTable();
            }
            return dt;
        }

        public DataTable ReturnReceiptSeriAlepha()
        {
            try
            {
                Query = string.Format("SELECT [ID],[Title] FROM [PersianAlphabet] order by id desc");
                dt = SqlDataTable(Query);
            }
            catch (Exception ex)
            {
                string Query = string.Format(@"EXECUTE sp_FilltblErrorProgrammer
                                                                   @Message=N'{0}'
                                                                  ,@DateError='{1}'
                                                                  ,@PhysicalPath=N'{2}'
                                                                  ,@UserHostAddress='{3}'
                                                                  ,@Browser='{4}'"
                                                            , "Error For Load Report :  rptCountDebitForState ; Detail :  " + ex.Message.Replace("'", "''"), "", "", "", "");
                SqlDataSet(Query);
                dt = new DataTable();
            }
            return dt;
        }

        public DataTable ReturnReceiptType()
        {
            try
            {
                Query = string.Format("SELECT Value,Title FROM ReceiptType order by ID");
                dt = SqlDataTable(Query);
            }
            catch (Exception ex)
            {
                string Query = string.Format(@"EXECUTE sp_FilltblErrorProgrammer
                                                                   @Message=N'{0}'
                                                                  ,@DateError='{1}'
                                                                  ,@PhysicalPath=N'{2}'
                                                                  ,@UserHostAddress='{3}'
                                                                  ,@Browser='{4}'"
                                                            , "Error For Load Report :  rptCountDebitForState ; Detail :  " + ex.Message.Replace("'", "''"), "", "", "", "");
                SqlDataSet(Query);
                dt = new DataTable();
            }
            return dt;
        }

        public DataTable ReturnGlobalContract()
        {
            try
            {
                Query = string.Format("SELECT  G.ID Code , G.ContractTitle Title FROM GlobalContracts G Order By G.ContractTitle");
                dt = SqlDataTable(Query);
            }
            catch (Exception ex)
            {
                string Query = string.Format(@"EXECUTE sp_FilltblErrorProgrammer
                                                                   @Message=N'{0}'
                                                                  ,@DateError='{1}'
                                                                  ,@PhysicalPath=N'{2}'
                                                                  ,@UserHostAddress='{3}'
                                                                  ,@Browser='{4}'"
                                                            , "Error For Load Report :  rptCountDebitForState ; Detail :  " + ex.Message.Replace("'", "''"), "", "", "", "");
                SqlDataSet(Query);
                dt = new DataTable();
            }
            return dt;
        }

        public DataTable ReturnBarcodeStatus()
        {
            try
            {
                Query = string.Format(@"select Code,Status as Title from  ExchangeStatusesGroup Where IsActive='Y'  order by Ordering");
                dt = SqlDataTable(Query);
            }
            catch (Exception ex)
            {
                string Query = string.Format(@"EXECUTE sp_FilltblErrorProgrammer
                                                                   @Message=N'{0}'
                                                                  ,@DateError='{1}'
                                                                  ,@PhysicalPath=N'{2}'
                                                                  ,@UserHostAddress='{3}'
                                                                  ,@Browser='{4}'"
                                                            , "Error For Load Report :  rptCountDebitForState ; Detail :  " + ex.Message.Replace("'", "''"), "", "", "", "");
                SqlDataSet(Query);
                dt = new DataTable();
            }
            return dt;
        }

        public DataTable ReturnBarcodeSubStatus(string StatusID)
        {
            try
            {
                Query = string.Format(@"select ID as Code,Status as Title from 
                    ExchangeStatuses Where  ID != 51 AND IsUse=1 AND StatusGroupCode={0} order by Ordering", StatusID);
                dt = SqlDataTable(Query);
            }
            catch { dt = new DataTable(); }
            return dt;
        }

        public DataTable ReturnReceiptSaveState()
        {
            try
            {
                Query = string.Format(@"SELECT Value,Title FROM ReceiptFinancialMood");
                dt = SqlDataTable(Query);
            }
            catch (Exception ex)
            {
                string Query = string.Format(@"EXECUTE sp_FilltblErrorProgrammer
                                                                   @Message=N'{0}'
                                                                  ,@DateError='{1}'
                                                                  ,@PhysicalPath=N'{2}'
                                                                  ,@UserHostAddress='{3}'
                                                                  ,@Browser='{4}'"
                                                            , "Error For Load Report :  rptCountDebitForState ; Detail :  " + ex.Message.Replace("'", "''"), "", "", "", "");
                SqlDataSet(Query);
                dt = new DataTable();
            }
            return dt;
        }

        public DataTable ReturnPostNodeGhabool(string CityCode, int PostNode)
        {
            try
            {
                Query = string.Format("exec SP_GetAllPostNodeGhabool @City_Code={0} , @PostNodeCode={1} ", Convert.ToInt32(CityCode), PostNode);
                dt = SqlDataTable(Query);
            }
            catch (Exception ex)
            {
                string Query = string.Format(@"EXECUTE sp_FilltblErrorProgrammer
                                                                   @Message=N'{0}'
                                                                  ,@DateError='{1}'
                                                                  ,@PhysicalPath=N'{2}'
                                                                  ,@UserHostAddress='{3}'
                                                                  ,@Browser='{4}'"
                                                            , "Error For Load Report :  rptCountDebitForState ; Detail :  " + ex.Message.Replace("'", "''"), "", "", "", "");
                SqlDataSet(Query);
                dt = new DataTable();
            }
            return dt;
        }
    }
}
