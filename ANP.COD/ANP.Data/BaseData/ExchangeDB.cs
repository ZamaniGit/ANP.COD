using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ANP.Data.BaseData
{
    public class ExchangeDB : DBConnector
    {
        string Query = string.Empty;
        DataTable dt = new DataTable();

        public DataTable LoadDeliveryParcels(int PostNode, string Fdate, string Ldate, int IsBaje, int UserID, string Barcode, int status, bool DontPayPrice, int ParentState, int Financial, int ParcelType, int LC, int GC)
        {
            Query = string.Format(@"Exec [SP_GetAllParcelCODForSuperMenial_New]  @PostNode={0} , @Fdate='{1}' , @Ldate='{2}',@UserID={3},@Barcode='{4}' ,@Status={5},@DontPayPrice={6}
                                                , @ParentState={7}, @Financial={8} , @ParcelType={9},@LC={10},@GC={11},@IsBaje={12}",
                PostNode, Fdate, Ldate, UserID, Barcode, status, DontPayPrice, ParentState, Financial, ParcelType, LC, GC, IsBaje);

            return SqlDataTable(Query);
        }

        public void EditPrice(string CustomerCost, string PostalCost, string Vattax, int UserId, int RowIDForEditPrice)
        {
            Query = string.Format(@"EXECUTE SP_EditParcelPrice
                       @PostalCost={0},@CustomerCost={1},@VatTax={2}
                      ,@UserId_PriceEdit={3},@ID={4} ",
                        PostalCost, CustomerCost, Vattax, UserId, RowIDForEditPrice);
            SqlExecute(Query);
        }

        public void EditPrice(string CustomerCost, string PostalCost, string Vattax, int UserId, string Barcode)
        {
            Query = string.Format(@"EXECUTE SP_EditParcelPriceByBarcode
                       @PostalCost={0},@CustomerCost={1},@VatTax={2}
                      ,@UserId_PriceEdit={3},@BarCode='{4}' ",
            PostalCost, CustomerCost, Vattax, UserId, Barcode);
            SqlExecute(Query);
        }

        public DataTable LoadParcelsByBarcode(string Barcode)
        {
            Query = string.Format("Exec sp_GetAllParcelsByBarcode  @Barcode='{0}' ", Barcode);
            return SqlDataTable(Query);
        }

        public DataTable LoadPateByBarcode(string Barcode)
        {
            Query = string.Format("Exec sp_GetAllPateByBarcode  @Barcode='{0}' ", Barcode);
            return SqlDataTable(Query);

        }

        public int CountIpdatePrice(string RowID)
        {
            int Result = 0;
            Query = string.Format("select isnull (( select EditPriceCount from ParcelCOD where ID={0} AND UserId_PriceEdit>0 And (ReceiptID is null OR ReceiptID<1) ),-1)", RowID);
            try
            {
                Result = Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString());
            }
            catch { Result = 0; }
            return Result;
        }

        public object LoadDetailDeliveryParcels(string ParcelID)
        {
            Query = string.Format("Exec SP_GetAllDetailParcelCODForSuperMenial  @ParcelID={0}", ParcelID);

            return SqlDataTable(Query);
        }

        public string ValidationForRequestDelete(string Barcode, int StateCode)
        {
            string Result = string.Empty;
            try
            {
                if (Barcode.Trim().Length != 24 && Barcode.Trim().Length != 20 && Barcode.Trim().Length != 13)
                    Result = "تعداد کاراکترهای بارکد نامعتبر میباشد";
                else
                {
                    //Check ParcelCOD
                    Query = string.Format(
                              @"SELECT 
                                     ISNULL(ReceiptID,0) as ReceiptID
                                    ,PC.Deleted AS Deleted
	                                ,(select isnull((select top 1 EndTask From ParcelRequestDel Where Barcode=PC.Barcode AND IsLog=0 Order By ID DESC),'True')) as EndTask
	                                ,(case when ((select COUNT(ID) From ParcelRequestDel Where Barcode=PC.Barcode AND IsLog=0)>0 )
		                                Then DateDiff(day,(Select top 1 dbo.shamsitomiladi(Padmin_Date) From ParcelRequestDel Where Barcode=PC.Barcode AND IsLog=0 Order By ID DESC),(select GetDate()))
		                                Else 1 end) BarcodeDateDiff	
                                FROM 
                                    ParcelCOD PC 
                                Where PC.Barcode='{0}' ORDER BY PC.ID DESC", Barcode);
                    DataTable dtParcel = SqlDataTable(Query);

                    if (dtParcel.Rows.Count > 0)
                    {
                        //if (Convert.ToInt32(dtParcel.Rows[0]["StateCode"].ToString()) != StateCode)
                        //    Result = "این مرسوله در اختیار شما نیست و ثبت درخواست حذف توسط شما غیر مجاز می باشد .";

                        //else 
                            if (Convert.ToBoolean(dtParcel.Rows[0]["Deleted"].ToString()))
                            Result = "این مرسوله قبلا حذف شده و نیازی به ثبت درخواست جدید  نمی باشد.";
                        //چک کردن فیش برای این بارکد
                            else if (Convert.ToInt32(dtParcel.Rows[0]["ReceiptID"].ToString())>0)
                                Result = "برای این مرسوله فیش ثبت شده و تا قبل از حذف فیش مربوطه امکان ابطال مرسوله وجود ندارد.";
                        //Check ParcelRequestDel
                            else if (Convert.ToBoolean(dtParcel.Rows[0]["EndTask"].ToString())==false)
                                Result = "درخواست حذف برای این بارکد قبلا ذخیره شده است .";
                            else if (Convert.ToInt32(dtParcel.Rows[0]["BarcodeDateDiff"].ToString()) == 0)
                                Result = "جهت ثبت درخواست جدید ، باید حداقل یک روز از مدت زمان ثبت درخواست قبلی سپری شده باشد";
                    }
                    else { Result = "هیچ مرسوله ایی با بارکد وارد شده یافت نشد !!!"; }

                }
            }
            catch { Result = "ثبت درخواست برای این بارکد بدرستی انجام نشد .\r\n لطفا به کارشناس مربوطه اطلاع دهید"; }
            return Result;
        }


        public string Request_DelParcel(int RoleID, string Barcode, int UserID, int StateCode, string Comment, int Status)
        {
            string Result = "";
            try
            {
                Query = string.Format("Exec sp_InsertParcelRequestDel @RoleID={0} , @Barcode='{1}' , @UserID={2},	@StateCode={3},	@Comment=N'{4}', @PRD_StatusCode={5}"
                    , RoleID, Barcode, UserID, StateCode, Comment, Status);
                SqlExecute(Query);
                Result = "درخواست شما جهت حذف مرسوله وارد شده ثبت گردید. بعد از تایید مدیر سیستم بارکد حذف می شود ";
            }
            catch
            {
                Result = "ثبت درخواست برای این بارکد بدرستی ثبت نشد .\r\n لطفا به کارشناس مربوطه اطلاع دهید";
            }
            return Result;
        }
//        public void DeleteParcel(string ParcelID, int StateCode, int PostnodeID, int RoleID, int UserID, string Date)
//        {

//            Query = string.Format(@"select (((CONVERT([nvarchar],right('0000'+CONVERT([varchar],'{0}',(0)),(4)),(0))+CONVERT([nvarchar],right('00000'+CONVERT([varchar],'{1}',(0)),(5)),(0)))
//                        +CONVERT([nvarchar],right('0000'+CONVERT([varchar],'{2}',(0)),(4)),(0)))+CONVERT([nvarchar],right('000000'+CONVERT([varchar],'{3}',(0)),(6)),(0)))", StateCode, PostnodeID, RoleID, UserID);
//            string UserInfoID = SqlDataTable(Query).Rows[0][0].ToString();

//            Query = string.Format("update ParcelCOD set Deleted=1,Deleted_EntryDate='{0}',Deleted_Users_ID='{1}' where ID={2}", Date, UserInfoID, ParcelID);
//            SqlExecute(Query);
//        }

        public bool IsDeleted(string Barcode)
        {
            Query = string.Format("select top 1 isnull (Deleted,1) Deleted From ParcelCOD Where Barcode='{0}' ", Barcode);
            return Convert.ToBoolean(SqlDataTable(Query).Rows[0][0].ToString());
        }

        public bool IsReceipt(string Barcode)
        {
            Query = string.Format("select top 1 ReceiptID From ParcelCOD Where Barcode='{0}' ", Barcode);
            if (Convert.ToInt32(SqlDataTable(Query).Rows[0][0].ToString()) > 0)
                return true;
            else
                return false;
        }

        public DataTable ReturnBarcodeListForDel_Tecadmin(int RoleID)
        {
            Query = string.Format(@"EXEC sp_GetBarcodeListForDel @RoleID={0}", RoleID);
            return SqlDataTable(Query);
        }

        //public string AnswerToRequestForDelParcel(string pAction, string pBarcode, int pRoleID, int pUserID,int pStateCode, string pDate,string pComment)
        //{
        //    string Message = string.Empty;
        //    if (pAction == "Deny")
        //    {
        //        Message=Request_DelParcel(pRoleID,pBarcode,pUserID,pStateCode,pComment,12);
        //    }
        //    else if (pAction == "Allow")
        //    {
        //         Message=Request_DelParcel(pRoleID,pBarcode,pUserID,pStateCode,pComment,11);
        //    }
        //    return Message;
        //}

    }
}