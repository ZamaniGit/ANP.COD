using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ANP.Data.Object;

namespace ANP.Data
{
    public class Financial : DBConnector
    {
        string Query = string.Empty;
        DataTable dt;

        public DataTable GetAllFinancialReceipt(string StateCode, string Dispense , string Fdate,string Ldate)
        {
            try
            {
                Query = string.Format(@"exec sp_GetFinancialReceiptList @StateCodeMali={0}, @PostNodeCode={1} , @Fdate='{2}' , @Ldate='{3}'   ", StateCode, Dispense, Fdate, Ldate);
                dt = SqlDataTable(Query);
            }
            catch { }
            return dt;
        }

        public DataTable ReceiptCause()
        {
            try
            {
                Query = string.Format(@"SELECT ID,Title FROM ReceiptState");
                dt = SqlDataTable(Query);
            }
            catch { }
            return dt;
        }

        public void UpdateReceiptInfoByFinancialUser(ReceiptClass receipt, string ApproveFlag, string FinancialMoodValue,
            string Description, string Date10Digit)
        {
            try
            {
                Query = string.Format(@"EXEC sp_UpdateParcelReceiptForLog @ReceiptNo={0} ,@BankID={1} ,@Price={2} 
                    ,@PayDate='{3}',@InsertDate_M='{4}' ,@InsertDate_SH='{5}' ,@InsertTime='{6}' ,@ApproveFlag='{7}' 
                    ,@ApproveDate='{8}' ,@PayerName='{9}' ,@UserID={10} ,@IsSupplementReceipt='{11}'
                    ,@ChangeFlag='{12}' , @ReceiptID={13}, @ReceiptTypeValue={14} , @FinancialMoodValue = {15} , @Description = N'{16}'
                    ,@ReceiptAlephabetSeri={17},@ReceiptNumberSeri={18}
                    ,@IsPhish=''
	                ,@ChequeVajh=''
	                ,@ChequeSaderKonandeh=''
                    ,@ChequeAccountNo=''
	                ,@ChequeComment='' "
                    , 0, 0, 0, 0
                    , "2015-05-24 17:45:26.973", 0
                    , 0, ApproveFlag,Date10Digit, 0
                    , 0, "N", "Y", receipt.ID, -1, FinancialMoodValue, Description
                    ,0,0);
                SqlExecute(Query);
//                Query = string.Format(@"exec sp_UpdateReceiptInfoByFinancialUser 
//                            @ID={0} , @ApproveDate='{1}' , @Description=N'{2}' ,@ApproveFlag='{3}'"
//                            , receipt.ID, receipt.ApproveDate, receipt.Description, ApproveFlag);
//                SqlExecute(Query);
            }
            catch { }
        }

        public DataTable ReturnDetailReceiptByID(int ReceiptID)
        {
            try
            {
                Query = string.Format(@"exec sp_GetDetailReceiptByID @ID='{0}' ", ReceiptID);
                dt = SqlDataTable(Query);
            }
            catch { }
            return dt;
        }

        public DataTable ReturnParcelsListByReceiptID ( int ReceiptID ) {
            try {
                Query = string.Format (@"exec sp_ReturnParcelsListByReceiptID @ReceiptID='{0}' ", ReceiptID);
                dt = SqlDataTable (Query);
            }
            catch { }
            return dt;
        }
    }
}
