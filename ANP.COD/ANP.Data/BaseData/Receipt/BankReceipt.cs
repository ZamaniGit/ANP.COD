using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ANP.Data.Object;

namespace ANP.Data
{
    public class BankReceipt : DBConnector
    {
        string Query = string.Empty;
        DataTable dt = new DataTable();

        public DataTable ReturnBankName()
        {
            try
            {
                Query = string.Format("select id,title from Banks order by id");
                dt = SqlDataTable(Query);
            }
            catch { }
            return dt;
        }

        public void SentToFinance(string RID)
        {
            try
            {
                Query = string.Format ("Update ReceiptInfo set ApproveFlag='B' Where  LogFlag='N' AND Deleted='N' AND  RID=" + RID);
                dt = SqlDataTable(Query);
            }
            catch { }
        }

        public DataTable ReturnAllBarcodeDeliveryWithPostalCost(int PostNodeCode, string UserID, string Fdate, string Ldate)
        {
            try
            {
                dt = new DataTable();
                Query = string.Format(@"exec sp_GetBarcodeDeliveryWithPostalCost  @PostNodeCode={0},@UserID='{1}',@Fdate='{2}',@Ldate='{3}' ", PostNodeCode, UserID, Fdate, Ldate);
                dt = SqlDataTable(Query);
            }
            catch { }
            return dt;
        }

        public DataTable ReturnAllBarcodeDeliveryWithOutPostalCost(int PostNodeCode, string UserID, string Fdate, string Ldate)
        {
            try
            {
                dt = new DataTable();
                Query = string.Format(@"exec sp_GetBarcodeDeliveryWithOutPostalCost  @PostNodeCode={0},@UserID='{1}',@Fdate='{2}',@Ldate='{3}' ", PostNodeCode, UserID, Fdate, Ldate);
                dt = SqlDataTable(Query);
            }
            catch { }
            return dt;
        }

        public DataTable ReturnAllBarcodeDelivery_BarcodeForMyReceiptID(int UserID, string ReceiptID, int PostNodeCode)
        {
            try
            {
                Query = string.Format(@"exec sp_GetBarcodeDelivery_BarcodeForMyReceiptID @UserID= {0} , @ReceiptID= {1} , @PostNode = {2} "
                    , UserID, ReceiptID, PostNodeCode);
                dt = SqlDataTable(Query);
            }
            catch { }
            return dt;
        }

        public void SaveReceipt(ReceiptClass ReceiptInfo, string SelectedID, Int16 ReceiptTypeValue)
        {
            // string ReceiptID = "0";
            try
            {
                Query = string.Format(@"exec sp_InsertPostalReceiptInfo @ReceiptSerialNo='{0}',@BankID={1},@Price={2},@PayDate='{3}'
                    ,@InsertDate_SH='{4}',@InsertTime='{5}',@PayerName=N'{6}',@UserId={7},@SelectedParcelsID='{8}',@PostNodeCode={9}
                    ,@ReceiptAlphabetSeri='{10}',@ReceiptNumberSeri='{11}',@IsPhish='{12}',@ChequeAccountNo='{13}',@ChequeComment='{14}'
                    ,@ChequeSaderKonandeh='{15}',@ChequeVajh='{16}',@ReceiptTypeValue={17} "
                    , ReceiptInfo.ReceiptSerialNo, ReceiptInfo.BankID, ReceiptInfo.Price, ReceiptInfo.PayDate, ReceiptInfo.InsertDate_SH
                    , ReceiptInfo.InsertTime, ReceiptInfo.PayerName, ReceiptInfo.UserID, SelectedID, ReceiptInfo.PostNodeCode
                    , ReceiptInfo.ReceiptAlphabetSeri, ReceiptInfo.ReceiptNumberSeri,ReceiptInfo.IsPhish ,ReceiptInfo.ChequeAccountNo
                    , ReceiptInfo.ChequeComment, ReceiptInfo.ChequeSaderKonandeh, ReceiptInfo.ChequeVajh, ReceiptTypeValue);
                SqlExecute(Query);
                //ReceiptID = SqlDataTable(Query).Rows[0][0].ToString();
            }
            catch { }
            //  return ReceiptID;
        }

        //public void UpdateReceiptidInParcelList(string SelectedID, string receiptID)
        //{
        //    try
        //    {
        //        Query = string.Format
        //            (@"update ParcelList set ReceiptID  = '{0}' where id in ({1}) ", receiptID, SelectedID);
        //        SqlExecute(Query);
        //    }
        //    catch { }
        //}

        public void UpdateReceiptidInParcelList(string SelectedID, string DontSelectedID, string receiptID, string Date, string Date_sh)
        {
            try
            {
                Query = string.Format
                    (@"update ParcelCOD set ReceiptID  = {0} , ReceiptDate='{2}'  , ReceiptDate_sh='{3}' where id in ({1}) ", receiptID, SelectedID, Date, Date_sh);
                SqlExecute(Query);
                Query = string.Format
                    (@"update ParcelCOD set ReceiptID  = -1 , ReceiptDate={2} , ReceiptDate_sh={3} where id in ({1}) ", receiptID, DontSelectedID, "NULL", "NULL");
                SqlExecute(Query);
            }
            catch { }
        }

        public DataTable ReturnAllReceiptList(int PostNodeCode)
        {
            try
            {
                Query = string.Format(@"exec sp_GetReceiptListUnpromising @PostNodeCode={0} ",  PostNodeCode);
                dt = SqlDataTable(Query);
            }
            catch { }
            return dt;
        }

        public void UpdateReceiptForupHold(string Date, int UserID,int PostNode)
        {
            try
            {
                Query = string.Format
                    (@"UPDATE ReceiptInfo SET ApproveFlag = 'A' ,ApproveDate ='{0}'  WHERE UserID={1} AND PostNodeCode={2}  and ApproveFlag='Z' and deleted='N'  AND LogFlag='N' ", Date, UserID, PostNode);

                SqlExecute(Query);
            }
            catch { }
        }

        public void DeleteReceiptInfoByID(int ReceiptID)
        {
            try
            {

                Query = string.Format(@"Exec sp_DeleteReceiptInfoByID {0}", ReceiptID);
                SqlExecute(Query);
            }
            catch { }
        }

        public DataTable ReturnAllReceiptListByReceiptState(string ApproveFlag, int UserID, int PostNode,string Fdate,string Ldate)
        {
            try
            {
                Query = string.Format(@"exec sp_GetAllReceiptListByReceiptState @ApproveFlag='{0}' , @UserID={1} , @PostNode={2} ,@Fdate='{3}',@Ldate='{4}' ", ApproveFlag, UserID, PostNode,Fdate,Ldate);
                dt = SqlDataTable(Query);
            }
            catch { }
            return dt;
        }

        public void InsertSupplementReceipt(ReceiptClass rc)
        {
            //int Result = 0;
            try
            {
                Query = string.Format(@" exec sp_InsertSupplementReceipt
		                                     @ReceiptNo='{0}', @BankID ={1} , @Price  ={2} , @PayDate ='{3}' , @InsertTime ='{4}'
		                                    , @ApproveFlag='{5}', @ApproveDate='{6}', @PayerName=N'{7}', @UserID  ={8} , @Deleted ='{9}'
		                                    , @IsSupplementReceipt ='{10}', @ParentReceiptID ={11},@ReceiptTypeValue={12},@RefID={13},@PostNodeCode={14}
                                            ,@ReceiptAlphabetSeri={15} ,@ReceiptNumberSeri={16},@IsPhish='{17}',@ChequeAccountNo='{18}',@ChequeComment='{19}'
                                            ,@ChequeSaderKonandeh='{20}',@ChequeVajh='{21}' "
                                            , rc.ReceiptSerialNo, rc.BankID, rc.Price, rc.PayDate, rc.InsertTime, rc.ApproveFlag, rc.ApproveDate,
                                            rc.PayerName, rc.UserID, rc.Deleted, rc.IsSupplementReceipt, rc.ParentID, rc.ReceiptTypeValue, rc.RefID,rc.PostNodeCode
                                            , rc.ReceiptAlphabetSeri, rc.ReceiptNumberSeri, rc.IsPhish, rc.ChequeAccountNo
                                            , rc.ChequeComment, rc.ChequeSaderKonandeh, rc.ChequeVajh);
                SqlExecute(Query);
                //                Query = string.Format(@" select top 1 id from ReceiptInfo where ReceiptNo='{0}' AND BankID ={1} AND Price  = {2} AND PayDate ='{3}' AND InsertTime ='{4}'
                //		                                    AND ApproveFlag='{5}' AND ApproveDate='{6}' AND PayerName='{7}' AND UserID  ={8} AND Deleted ='{9}'
                //		                                    AND IsSupplementReceipt ='{10}' AND SupplementReceiptID ='{11}' "
                //                                            , rc.ReceiptNo, rc.BankID, rc.Price, rc.PayDate, rc.InsertTime, rc.ApproveFlag, rc.ApproveDate,
                //                                            rc.PayerName, rc.UserID, rc.Deleted, rc.IsSupplementReceipt, rc.SupplementReceiptID);
                //                Result = Convert.ToInt32(SqlDataTable(Query).Rows[0][0]);
            }
            catch { }
            //return Result;
        }

        public void ReturnReceiptNoByReceiptID(int ParentReceiptID, out string ParentSerialNo, out string ParentNumberSeri, out string ParentSeriAlphabet)
        {
            Query = string.Format(@" select top 1 receiptSerialNo,ReceiptNumberSeri,(select top 1 Title from PersianAlphabet where Id=ReceiptAlephabetSeri)ReceiptAlephabetSeri from ReceiptInfo where id={0} ", ParentReceiptID);
            DataTable dt=new DataTable();
            dt=SqlDataTable(Query);
            ParentSerialNo = dt.Rows[0][0].ToString();
            ParentNumberSeri= dt.Rows[0][1].ToString();
            ParentSeriAlphabet = dt.Rows[0][2].ToString();
        }

        //public void UpdateSupplementReceiptID(int ParentReceiptID, int SupplementID)
        //{
        //    string SRid = "";-
        //    Query = string.Format(" Select Top 1 SupplementReceiptID from ReceiptInfo where id={0} ", ParentReceiptID);
        //    SRid = SqlDataTable(Query).Rows[0][0].ToString();
        //    if (SRid == "0") SRid = SupplementID.ToString();
        //    else SRid = SRid + "," + SupplementID.ToString();
        //    Query = string.Format(" update ReceiptInfo set SupplementReceiptID='{0}' where id={1} ", SRid, ParentReceiptID);
        //    SqlExecute(Query);
        //}

        public int ReturnOrginalReceiptID(int SupplementID)
        {
            int Result = 0;
            Query = string.Format(@" select top 1 ParentID from ReceiptInfo where id={0} ", SupplementID);
            Result = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
            return Result;
        }
        //int ParentReceiptID,
        public ReceiptClass ReturnReceiptInfoByID(int receiptID)
        {
            ReceiptClass rc = new ReceiptClass();
            Query = string.Format(@"select id,ParentID,MasterReceiptID,PayDate,ReceiptSerialNo,BankID,Price,PayerName
                    ,IsSupplementReceipt,ReceiptTypeValue,UpdateCount,RefID,ReceiptAlephabetSeri
                    ,ReceiptNumberSeri,IsPhish,ISNULL(ChequeVajh,'--') as ChequeVajh ,ISNULL(ChequeSaderKonandeh,'--') as ChequeSaderKonandeh
					,ISNULL(ChequeAccountNo,'--') as ChequeAccountNo,ISNULL(ChequeComment,'--') as ChequeComment from ReceiptInfo where id={0} "
                , receiptID);

            DataTable dt = SqlDataTable(Query);
            rc.RefID = Convert.ToInt32(dt.Rows[0]["RefID"].ToString());
            rc.PayDate = dt.Rows[0]["PayDate"].ToString();
            rc.PayerName = dt.Rows[0]["PayerName"].ToString();
            rc.ID = Convert.ToInt32(dt.Rows[0]["id"].ToString());
            rc.Price = Convert.ToUInt64(dt.Rows[0]["Price"].ToString());
            rc.BankID = Convert.ToInt32(dt.Rows[0]["BankID"].ToString());
            rc.ReceiptSerialNo = dt.Rows[0]["ReceiptSerialNo"].ToString();
            rc.ParentID = Convert.ToUInt64(dt.Rows[0]["ParentID"].ToString());
            rc.MasterReceiptID = Convert.ToInt32(dt.Rows[0]["MasterReceiptID"].ToString());
            rc.ReceiptTypeValue = Convert.ToUInt64(dt.Rows[0]["ReceiptTypeValue"].ToString());
            rc.UpdateCount = Convert.ToInt32(dt.Rows[0]["UpdateCount"].ToString());
            rc.ReceiptAlphabetSeri = dt.Rows[0]["ReceiptAlephabetSeri"].ToString();
            rc.IsSupplementReceipt = dt.Rows[0]["IsSupplementReceipt"].ToString();
            rc.ChequeSaderKonandeh = dt.Rows[0]["ChequeSaderKonandeh"].ToString();
            rc.ReceiptNumberSeri = dt.Rows[0]["ReceiptNumberSeri"].ToString();
            rc.ChequeAccountNo = dt.Rows[0]["ChequeAccountNo"].ToString();
            rc.RefID = Convert.ToInt32(dt.Rows[0]["RefID"].ToString());
            rc.ChequeComment = dt.Rows[0]["ChequeComment"].ToString();
            rc.ChequeVajh = dt.Rows[0]["ChequeVajh"].ToString();
            rc.IsPhish = dt.Rows[0]["IsPhish"].ToString();
            return rc;
        }

        //public DataTable ReturnDetailOfOrginalReceiptByRefID(string RefID, int UserID)
        //{
        //    try
        //    {
        //        Query = string.Format(@"exec sp_GetDetailOfOrginalReceipt @RefID='{0}' , @UserID={1} ", RefID, UserID);
        //        dt = SqlDataTable(Query);
        //    }
        //    catch { }
        //    return dt;
        //}

        public bool DontExistSupplementReceipt(int ID)
        {
            int Result = -1;
            try
            {
                Query = string.Format("select COUNT(*) as SupplementCount from ReceiptInfo where ParentID={0}", ID);
                Result = Convert.ToInt32(SqlDataTable(Query).Rows[0]["SupplementCount"].ToString());
                if (Result == 0)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        public string IsSupplementReceipt(int EditID)
        {
            string IsSupplementReceipt = "N";
            Query = string.Format("select IsSupplementReceipt from ReceiptInfo where id={0}", EditID);
            IsSupplementReceipt = SqlDataTable(Query).Rows[0]["IsSupplementReceipt"].ToString();
            return IsSupplementReceipt;
        }

        public bool UpdateReceipt(ReceiptClass _Receipt, string RceiptID, string Date10Digit_latin, string Time8Digit, string Date10Digit )
        {
            bool Result = false;
            try
            {
                Query = string.Format(@"EXEC sp_UpdateParcelReceiptForLog @ReceiptNo={0} ,@BankID={1} ,@Price={2} 
                    ,@PayDate='{3}',@InsertDate_M='{4}' ,@InsertDate_SH='{5}' ,@InsertTime='{6}' ,@ApproveFlag='{7}' 
                    ,@ApproveDate='{8}' ,@PayerName='{9}' ,@UserID={10} ,@IsSupplementReceipt='{11}'
                    ,@ChangeFlag='{12}' , @ReceiptID={13},@ReceiptTypeValue={14},@FinancialMoodValue={15} , @Description = N'{16}'
                    ,@ReceiptAlephabetSeri={17},@ReceiptNumberSeri={18},@IsPhish='{19}',@ChequeVajh='{20}',@ChequeSaderKonandeh='{21}'
                          ,@ChequeAccountNo='{22}',@ChequeComment='{23}'"
                    , _Receipt.ReceiptSerialNo, _Receipt.BankID, _Receipt.Price, _Receipt.PayDate
                    , Date10Digit_latin + " " + Time8Digit, Date10Digit
                    , Time8Digit, "D", Date10Digit, _Receipt.PayerName
                    , _Receipt.UserID, "N", "N", RceiptID, _Receipt.ReceiptTypeValue,-1,""
                    , _Receipt.ReceiptAlphabetSeri, _Receipt.ReceiptNumberSeri, _Receipt.IsPhish, _Receipt.ChequeVajh
                    , _Receipt.ChequeSaderKonandeh, _Receipt.ChequeAccountNo, _Receipt.ChequeComment);
                SqlExecute(Query);
                Result = true;
            }
            catch { Result = false; }
            return Result;
        }

        public string ReceiptApproveFlag(string ID)
        {
            string Result = "";
            Query = string.Format(@" select top 1 ApproveFlag from ReceiptInfo where id={0} ", ID);
            Result = SqlDataTable(Query).Rows[0][0].ToString();
            return Result;
        }

        public void UpdateSupplementReceipt(ReceiptClass _Receipt, string Date10Digit_latin, string Time8Digit, string Date10Digit)
        {
            try
            {
                Query = string.Format(@"EXEC sp_UpdateParcelReceiptForLog @ReceiptNo='{0}' ,@BankID={1} ,@Price={2} 
                    ,@PayDate='{3}',@InsertDate_M='{4}' ,@InsertDate_SH='{5}' ,@InsertTime='{6}' ,@ApproveFlag='{7}' 
                    ,@ApproveDate='{8}' ,@PayerName=N'{9}' ,@UserID={10} ,@IsSupplementReceipt='{11}'
                    ,@ChangeFlag='{12}' , @ReceiptID={13},@ReceiptTypeValue={14},@FinancialMoodValue={15} , @Description = N'{16}'
                    ,@ReceiptAlephabetSeri={17},@ReceiptNumberSeri={18},@IsPhish='{19}',@ChequeVajh='{20}',@ChequeSaderKonandeh='{21}'
                          ,@ChequeAccountNo='{22}',@ChequeComment='{23}'"
                    , _Receipt.ReceiptSerialNo, _Receipt.BankID, _Receipt.Price, _Receipt.PayDate
                    , Date10Digit_latin + " " + Time8Digit,Date10Digit
                    , Time8Digit, "D", Date10Digit, _Receipt.PayerName
                    , _Receipt.UserID, "Y", "N", _Receipt.ID, _Receipt.ReceiptTypeValue,-1,""
                    , _Receipt.ReceiptAlphabetSeri, _Receipt.ReceiptNumberSeri, _Receipt.IsPhish, _Receipt.ChequeVajh
                    , _Receipt.ChequeSaderKonandeh, _Receipt.ChequeAccountNo, _Receipt.ChequeComment);
                SqlExecute(Query);
            }
            catch { }
        }

        public DataTable ReturnReceiptType()
        {
            try
            {
                Query = string.Format(@" Select Value,Title From ReceiptType order by Value ");
                dt = SqlDataTable(Query);
            }
            catch { }
            return dt;
        }

        public void SaveOtherReceipt(ReceiptClass rc)
        {
            try
            {
                Query = string.Format(@"Exec sp_InsertOtherReceiptInfo @ReceiptSerialNo='{0}',@BankID={1},@Price={2},@PayDate='{3}',@InsertTime='{4}'
                          ,@PayerName='{5}',@UserID={6},@ReceiptTypeValue={7},@RefID={8},@PostNodeCode={9}
                          ,@ReceiptAlephabetSeri={10},@ReceiptNumberSeri={11},@IsPhish='{12}',@ChequeVajh='{13}',@ChequeSaderKonandeh='{14}'
                          ,@ChequeAccountNo='{14}',@ChequeComment='{15}'", rc.ReceiptSerialNo, rc.BankID, rc.Price
                    , rc.PayDate, rc.InsertTime, rc.PayerName, rc.UserID, rc.ReceiptTypeValue, rc.RefID,rc.PostNodeCode
                    , rc.ReceiptAlphabetSeri, rc.ReceiptNumberSeri, rc.IsPhish, rc.ChequeVajh
                    , rc.ChequeSaderKonandeh, rc.ChequeAccountNo, rc.ChequeComment);
                SqlExecute(Query);
            }
            catch { }
        }

        public DataTable ReturnAllApproveFlag()
        {
            DataTable dt = new DataTable();
            try
            {
                Query = string.Format("SELECT  Flag,Title FROM ReceiptApproveFlag");
                dt = SqlDataTable(Query);
                return dt;
            }
            catch { return dt; }
        }

        public DataTable ReturnAllReceiptListByRefID(string RefID, int UserID, int Postnode)
        {
            try
            {
                Query = string.Format(@"exec sp_GetDetailOfOrginalReceipt @RefID='{0}' , @UserID={1} , @PostNode={2} ", RefID, UserID,Postnode);
                dt = SqlDataTable(Query);
            }
            catch { }
            return dt;
        }

        public DataTable ReturnParcelsListByReceiptID ( string ReceiptID ) {
            try {
                Query = string.Format (@"exec sp_ReturnParcelsListByReceiptID @ReceiptID={0} ", ReceiptID);
                dt = SqlDataTable (Query);
            }
            catch { }
            return dt;
        }

        public bool ISOkForSend(string RefID, string UserID)
        {
            bool Result = false;
            try
            {
                Query = string.Format (@"Select * from ReceiptInfo Where LogFlag='N' AND RefID={0} AND deleted='N' AND ApproveFlag='Z' AND UserID={1}", RefID, UserID);
                dt = SqlDataTable(Query);
                Result = (dt.Rows.Count > 0 ? false : true);
                return Result;
            }
            catch { return false; }
        }

        public void SentToFinanceByRefID(string RefID, string Date10Digit)
        {
            try
            {
                //Query = string.Format("Update ReceiptInfo set ApproveFlag='B' Where RefID=" + RefID);
                Query = string.Format("exec sp_UpdateReceiptInfoByUser @RefID={0},@ApproveDate='{1}',@ApproveFlag='{2}'",RefID, Date10Digit,'B');
                SqlExecute(Query);
            }
            catch { }
        }

        public string ReturnReceiptTypeValueByID(string ID)
        {
            try
            {
                Query = string.Format(@" SELECT ReceiptTypeValue FROM ReceiptInfo WHERE id={0} ", ID);
                return SqlDataTable(Query).Rows[0][0].ToString();
            }
            catch { return "1"; }
        }

        public Int64 ReturnRefIDByID(UInt64 ID)
        {
            try
            {
                Query = string.Format(@" SELECT RefID FROM ReceiptInfo WHERE id={0} ", ID);
                return Convert.ToInt64(SqlDataTable(Query).Rows[0][0].ToString());
            }
            catch { return 0; }
        }

        public void UpdateOtherReceipt(ReceiptClass _Receipt, string Date10Digit_latin, string Time8Digit, string Date10Digit)
        {
            try
            {
                Query = string.Format(@"EXEC sp_UpdateParcelReceiptForLog @ReceiptNo={0} ,@BankID={1} ,@Price={2} 
                    ,@PayDate='{3}',@InsertDate_M='{4}' ,@InsertDate_SH='{5}' ,@InsertTime='{6}' ,@ApproveFlag='{7}' 
                    ,@ApproveDate='{8}' ,@PayerName='{9}' ,@UserID={10} ,@IsSupplementReceipt='{11}',@ChangeFlag='{12}' 
                    ,@ReceiptID={13},@ReceiptTypeValue={14},@FinancialMoodValue={15}, @Description = N'{16}'
                    ,@ReceiptAlephabetSeri={17},@ReceiptNumberSeri={18},@IsPhish='{19}',@ChequeVajh='{20}',@ChequeSaderKonandeh='{21}'
                          ,@ChequeAccountNo='{22}',@ChequeComment='{23}'"
                    , _Receipt.ReceiptSerialNo, _Receipt.BankID, _Receipt.Price, _Receipt.PayDate
                    , Date10Digit_latin + " " + Time8Digit, Date10Digit
                    , Time8Digit, "D",Date10Digit, _Receipt.PayerName
                    , _Receipt.UserID, "N", "N", _Receipt.ID, _Receipt.ReceiptTypeValue, -1, ""
                    , _Receipt.ReceiptAlphabetSeri, _Receipt.ReceiptNumberSeri, _Receipt.IsPhish, _Receipt.ChequeVajh
                    , _Receipt.ChequeSaderKonandeh, _Receipt.ChequeAccountNo, _Receipt.ChequeComment);
                SqlExecute(Query);
            }
            catch { }
        }

        public int ReturnBankIdByReceiptID(int ID)
        {
            try
            {
                Query = string.Format(@" SELECT BankID FROM ReceiptInfo WHERE id={0} ", ID);
                return Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
            }
            catch { return 1; }
        }

        public int ReturnSupCountByID(string ID, int UserID)
        {
            int Count = 1;
            try
            {
                Query = string.Format (@"SELECT Count(id) from ReceiptInfo where LogFlag='N' AND ParentID={0} AND IsSupplementReceipt='Y' AND Deleted='N' AND UserID={1}", ID, UserID);
                Count = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
            }
            catch { }
            return Count;
        }

        public bool IsSendToFinancialById(string ID, int UserID)
        {
            int Count = 1;
            bool Result = true;
            try
            {
                Query = string.Format(@"select COUNT(id) from ReceiptInfo where id ={0} AND ApproveFlag in ('B','C')
                            AND Deleted='N' AND LogFlag='N' AND UserID={1}", ID, UserID);
                dt = SqlDataTable(Query);

                if (dt.Rows.Count > 0)
                    Count = Convert.ToInt32(dt.Rows[0][0].ToString());

                Result = (Count > 0 ? true : false);
            }
            catch { }
            return Result;
        }

        public bool DontExistOtherReceipt(int MasterReceiptID, string ReceiptTypeValue, int UserID, int postnode)
        {
            int Count = 1;
            bool Result = true;
            try
            {
                Query = string.Format(@"select Count(id) from ReceiptInfo Where RefID={0} AND ReceiptTypeValue={1} AND LogFlag='N' AND Deleted='N' AND IsSupplementReceipt='N' AND UserID={2} AND PostNodeCode={3} "
                    , MasterReceiptID, ReceiptTypeValue, UserID, postnode);
                dt = SqlDataTable(Query);

                if (dt.Rows.Count > 0)
                    Count = Convert.ToInt32(dt.Rows[0][0].ToString());

                Result = (Count > 0 ? false : true);
            }
            catch { }
            return Result;
        }

        public int ReturnPostalCommForArsenal(string SelectedID)
        {
            int result=0;
            try
            {
                Query = string.Format("select ISNULL( SUM( PostalCost ),0) from ParcelCOD where ID in ({0})", SelectedID);
                result= Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
            }
            catch { }
            return result;
        }

        public int ReturnCustomerCommForArsenal(string SelectedID)
        {
            int result = 0;
            try
            {
                Query = string.Format("select ISNULL( SUM( CustomerCost ),0) from  ParcelCOD where ID in ({0})", SelectedID);
                result = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
            }
            catch { }
            return result;
        }

        public int ReturnCustomerCommForArsenal(int MasterReceiptID)
        {
            int result = 0;
            try
            {
                Query = string.Format("select  ISNULL( SUM( CustomerCost ),0) from  ParcelCOD where ReceiptID in ({0})", MasterReceiptID);
                result = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
            }
            catch { }
            return result;
        }

        public int ReturnVattaxForArsenal(int MasterReceiptID)
        {
            int result = 0;
            try
            {
                Query = string.Format("select ISNULL( SUM( Vattax ),0) from  ParcelCOD where ReceiptID in ({0})", MasterReceiptID);
                result = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
            }
            catch { }
            return result;
        }

        public int ReturnPostalCommPriceForReceipt(string RceiptID,string NewReceiptPrice)
        {
            int result = 0;
            try
            {
                Query = string.Format ("select ISNULL( SUM( Price ),0) from ReceiptInfo where RefID={0} and ReceiptTypeValue=1 and Deleted='N' AND LogFlag='N' and IsSupplementReceipt='Y' and ID !={0} ", RceiptID);
                result = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString())+ Convert.ToInt32(NewReceiptPrice) ;
            }
            catch { }
            return result;
        }

        public int DisparityPriceForUpdate(string ReceiptID,string ParentID,string ReceiptType,string Price)
        {
            int ReceiptPrice=0;
            int BarcodePrice=0;
            int Result=-1;

            if (ParentID.Trim() == "0")
            {
                if (ReceiptType == "1")
                {
                    Query = string.Format ("select ISNULL( SUM(Price),0) from ReceiptInfo where ReceiptTypeValue=1 and id!={0} AND (ParentID=(select parentid from ReceiptInfo where id={0}) OR id=(select parentid from ReceiptInfo where id={0}))  AND Deleted='N' AND LogFlag='N' ", ReceiptID);
                    ReceiptPrice = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
                    ReceiptPrice += Convert.ToInt32(Price);
                    Query = string.Format("select ISNULL( SUM(PostalCost),0) from ParcelCOD where ReceiptID ={0} ", ReceiptID);
                    BarcodePrice = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
                    Result = ReceiptPrice - BarcodePrice;
                }
                if (ReceiptType == "2")
                {
                    Query = string.Format ("select  ISNULL( SUM(Price),0)  from ReceiptInfo where ReceiptTypeValue=2 and ParentID={0} AND Deleted='N' AND LogFlag='N' ", ReceiptID);
                    ReceiptPrice = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
                    ReceiptPrice += Convert.ToInt32(Price);
                    Query = string.Format("select  ISNULL( SUM(CustomerCost),0) from ParcelCOD where ReceiptID ={0} ", ReceiptID);
                    BarcodePrice = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
                    Result = ReceiptPrice - BarcodePrice;
                }
                if (ReceiptType == "3")
                {
                    Query = string.Format ("select  ISNULL( SUM(Price),0)  from ReceiptInfo where ReceiptTypeValue=3 and ParentID={0} AND Deleted='N'  AND LogFlag='N' ", ReceiptID);
                    ReceiptPrice = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
                    ReceiptPrice += Convert.ToInt32(Price);
                    Query = string.Format("select ISNULL( SUM(Vattax),0) from ParcelCOD where ReceiptID ={0}", ReceiptID);
                    BarcodePrice = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
                    Result = ReceiptPrice - BarcodePrice;
                }
            }
            else if (ParentID.Trim() != "0")
            {
                if (ReceiptType == "1")
                {
                    Query = string.Format ("select ISNULL( SUM(Price),0) from ReceiptInfo where ReceiptTypeValue=1 and id!={0} AND (ParentID=(select parentid from ReceiptInfo where id={0}) OR id=(select parentid from ReceiptInfo where id={0})) AND Deleted='N' AND LogFlag='N' ", ReceiptID);
                    ReceiptPrice = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
                    ReceiptPrice += Convert.ToInt32(Price);
                    Query = string.Format("select  ISNULL( SUM(PostalCost),0) from ParcelCOD where ReceiptID ={0}", ReceiptID);
                    BarcodePrice = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
                    Result = ReceiptPrice - BarcodePrice;
                }
                if (ReceiptType == "2")
                {
                    Query = string.Format ("select ISNULL( SUM(Price),0) from ReceiptInfo where ReceiptTypeValue=2 and id!={0} AND (ParentID=(select parentid from ReceiptInfo where id={0}) OR id=(select parentid from ReceiptInfo where id={0})) AND Deleted='N'  AND LogFlag='N' ", ReceiptID);
                    ReceiptPrice = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
                    ReceiptPrice += Convert.ToInt32(Price);
                    Query = string.Format("select ISNULL( SUM(CustomerCost),0) from ParcelCOD where ReceiptID ={0}", ReceiptID);
                    BarcodePrice = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
                    Result = ReceiptPrice - BarcodePrice;
                }
                if (ReceiptType == "3")
                {
                    Query = string.Format ("select ISNULL( SUM(Price),0) from ReceiptInfo where ReceiptTypeValue=3 and id!={0} AND RefID in (select RefID from ReceiptInfo where id={0}) AND Deleted='N'  AND LogFlag='N' ", ReceiptID);
                    ReceiptPrice = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
                    ReceiptPrice += Convert.ToInt32(Price);
                    Query = string.Format("select ISNULL( SUM(Vattax),0) from  ParcelCOD where ReceiptID ={0}", ReceiptID);
                    BarcodePrice = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
                    Result = ReceiptPrice - BarcodePrice;
                }
            }
            return Result;

        }

        public int DisparityPriceForSaveSupp(string ParentID, string ReceiptType, string Price)
        {
            int Result = -1;
            int ReceiptPrice = 0;
            int BarcodePrice = 0;

            if (ReceiptType == "1")
            {
                Query = string.Format ("select ISNULL( SUM(Price),0) from ReceiptInfo where  (ParentID={0} OR id={0}) AND Deleted='N'  AND LogFlag='N' ", ParentID);
                ReceiptPrice = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
                ReceiptPrice += Convert.ToInt32(Price);
                Query = string.Format("select  ISNULL( SUM(PostalCost),0) from  ParcelCOD where ReceiptID ={0}", ParentID);
                BarcodePrice = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
                Result = ReceiptPrice - BarcodePrice;
            }

            if (ReceiptType == "2")
            {
                Query = string.Format ("select ISNULL( SUM(Price),0) from ReceiptInfo where  (ParentID={0} OR id={0}) AND Deleted='N' AND LogFlag='N' ", ParentID);
                ReceiptPrice = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
                ReceiptPrice += Convert.ToInt32(Price);
                Query = string.Format("select  ISNULL( SUM(CustomerCost),0) from  ParcelCOD where ReceiptID ={0}", ParentID);
                BarcodePrice = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
                Result = ReceiptPrice - BarcodePrice;
            }
            if (ReceiptType == "3")
            {
                Query = string.Format ("select ISNULL( SUM(Price),0)from ReceiptInfo where  (ParentID={0} OR id={0}) AND Deleted='N' AND LogFlag='N' ", ParentID);
                ReceiptPrice = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
                ReceiptPrice += Convert.ToInt32(Price);
                Query = string.Format("select ISNULL( SUM(Vattax),0) from  ParcelCOD where ReceiptID ={0}", ParentID);
                BarcodePrice = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
                Result = ReceiptPrice - BarcodePrice;
            }
            return Result;
        }

        public bool AllowForDelete(int ID )
        {
            bool Result = false;
            int CountRow = 1;
            Query = string.Format ("select COUNT(id) from ReceiptInfo where id<>{0}  and  RefID ={0}  and Deleted='N' AND LogFlag='N'", ID);
            CountRow = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
            if (CountRow == 0)
                Result = true;
            return Result;
        }

        public DataTable ReturnAllAlephabetSeri()
        {
            DataTable dt = new DataTable();
            try
            {
                Query = string.Format("SELECT ID,Title FROM PersianAlphabet Order by ID");
                dt = SqlDataTable(Query);
                return dt;
            }
            catch { return dt; }
        }

        public bool ReceiptCheckForUnique(string Serial, string NumberSeri, string AlephabetSeri)
        {
            bool Result = false;
            DataTable dt = new DataTable();
            try
            {
                Query = string.Format(@"SELECT id  FROM ReceiptInfo where ReceiptSerialNo='{0}'  AND ReceiptAlephabetSeri={1}  
                            AND ReceiptNumberSeri={2}  AND Deleted='N' AND LogFlag='N'", Serial, AlephabetSeri, NumberSeri);
                dt = SqlDataTable(Query);
                if (dt.Rows.Count < 1)
                    Result = true;
                return Result;
            }
            catch { return false; }
        }

        public bool IsExistEqualOtherReceipt(string Serial, string NumberSeri, string AlephabetSeri,string ReceiptID)
        {
            bool Result = true;
            DataTable dt = new DataTable();
            try
            {
                Query = string.Format(@"SELECT id  FROM ReceiptInfo where ReceiptSerialNo='{0}'  AND ReceiptAlephabetSeri={1}  
                                         AND ReceiptNumberSeri={2}  AND Deleted='N' AND LogFlag='N' AND id != {3}"
                                        , Serial, AlephabetSeri, NumberSeri, ReceiptID);
                dt = SqlDataTable(Query);
                if (dt.Rows.Count > 0)
                    Result = true;
                else
                    Result = false;

                return Result;
            }
            catch { return true; }
        }

        public void ReturnParentReceiptNoByReceiptID(string IsSup, UInt64 ID, out string ParentSerialNo, out string ParentNumberSeri, out string ParentSeriAlphabet)
        {

            Query = string.Format(@" select top 1 receiptSerialNo,ReceiptNumberSeri,(select top 1 Title from PersianAlphabet where Id=ReceiptAlephabetSeri)ReceiptAlephabetSeri from ReceiptInfo where ID={0}  and Deleted='N' AND LogFlag='N' ", ID);

            
            DataTable dt = new DataTable();
            dt = SqlDataTable(Query);
            ParentSerialNo = dt.Rows[0][0].ToString();
            ParentNumberSeri = dt.Rows[0][1].ToString();
            ParentSeriAlphabet = dt.Rows[0][2].ToString();
        }

        public Int64 GetPriceByReceiptInfo(string ReceiptType, string Serial, string SeriNumber, string SeriHarf, int PostNodeCode)
        {
            try
            {
                Query =string.Format( @"Exec sp_GetPriceByReceiptInfo 
                    @ReceiptType={0},
                    @ReceiptSerialNo ='{1}' ,
                    @ReceiptAlephabetSeri  ={2} ,
                    @ReceiptNumberSeri  ={3} ,
                    @PostNodeCode  ={4}", 
                    ReceiptType, 
                    Serial, 
                    SeriHarf, 
                    SeriNumber, 
                    PostNodeCode);

                return Convert.ToInt64(SqlDataTable(Query).Rows[0][0].ToString());
            }
            catch { return 0; }
        }

        public DataTable ReturnMovazehSearch(int postnode)
        {
            DataTable dt = new DataTable();
            try
            {
                
                Query = string.Format(@"SELECT UserID as Value,Name+' '+Family as Title
                     FROM [Users]
                      where RoleID=1006  and IsActive=1 and PostnodeID ={0}" , postnode);
                dt = SqlDataTable(Query);
                return dt;
            }
            catch { return dt; }
        }

        public int ParcelCodeZeroPrice(string SelectedID)
        {
            Query = string.Format( @"select count (id) from ParcelCOD where id in ({0}) and ( PostalCost<1 AND CustomerCost<1 and VatTax<1 )", SelectedID);
            dt = SqlDataTable(Query);
            return Convert.ToInt32(dt.Rows[0][0].ToString());
        }

        public int SumVattax(string RefID)
        {
            Query = string.Format(@"select sum(vattax) from ParcelCOD where ReceiptID={0}", RefID);
            dt = SqlDataTable(Query);
            return Convert.ToInt32(dt.Rows[0][0].ToString());
            
        }

        public bool IsSavedReceiptVattax(string RefID)
        {
            try
            {
                int i = 0;
                Query = string.Format(@"select count(id) from ReceiptInfo where ReceiptTypeValue=3 and Deleted='N' and LogFlag='N' AND RefID={0} and ApproveFlag!='Z'", RefID);
                i = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
                if (i > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
