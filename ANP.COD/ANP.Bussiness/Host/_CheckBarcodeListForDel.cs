using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ANP.Bussiness.Objects;
using ANP.Data.BaseData;
using ANP.Bussiness.Models;
using System.Web.UI.WebControls;

namespace ANP.Bussiness.Host
{
    public class _CheckBarcodeListForDel
    {
        ICheckBarcodeListForDel _host;
        LoginDetails UserInfo;
        ExchangeDB Data = new ExchangeDB();

        public void Init(ICheckBarcodeListForDel hostform, LoginDetails LD)
        {
            this._host = hostform;
            UserInfo = LD;
        }
        
        public void loadData()
        {
            _host.MyGrid.DataSource = Data.ReturnBarcodeListForDel_Tecadmin(UserInfo.RoleID);
            _host.MyGrid.DataBind();
            
        }

        public string CheckRequestForDel(string action, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            string Barcode = string.Empty;
            string Comment = string.Empty;
            string Message=string.Empty;
            int RoleID = UserInfo.RoleID;
            int Status = 0;

            TextBox txtDiscription = (TextBox)e.Item.FindControl("txtComment");
            Comment = txtDiscription.Text.Trim() + " ";

            Barcode = e.Item.Cells[1].Text.Trim();

            if (Barcode.Length != 20 && Barcode.Length != 24 && Barcode.Length != 13)
                Message = "بارکد انتخاب شده معتبر نیست لطفا به کارشناس سامانه اطلاع دهید .";
            else
            {
                if (action == "Deny"){ if (RoleID==1000) Status=14; else Status=12;}
                else if (action == "Allow") {if (RoleID==1000) Status=13; else Status=11;}

                Message = Data.Request_DelParcel(UserInfo.RoleID, Barcode, UserInfo.UserId, UserInfo.StateCode, Comment , Status);
            }
            return Message;
        }



        //public string AcceptCheckBarcodeForDel(System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{
        //    string Barcode = string.Empty;
        //    string Comment = string.Empty;
        //    string Message = string.Empty;

        //    try
        //    {
        //        Barcode = e.Item.Cells[1].Text.Trim();
        //        Comment = e.Item.Cells[10].Text.Trim();

        //        if (Barcode.Length == 20 || Barcode.Length == 24)
        //        {
        //            Message = Data.AcceptRequectParcelForDel(UserInfo.RoleID, Barcode, UserInfo.UserId, UserInfo.StateCode, Comment.Trim(), 11);
        //        }
        //        else
        //        {
        //            Message = "بارکد انتخاب شده معتبر نیست لطفا به کارشناس سامانه اطلاع دهید .";
        //        }
        //    }
        //    catch
        //    {
        //        Message = "خطای رخ داده قابل پیگیری نیست برای حل مشکل با کارشناس سامانه تماس بگیرید.";
        //    }
            
        //    return Message;

        //}

        //public string DenyBarcodeForDel(System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{

        //}
    }
}