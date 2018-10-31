using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using ANP.Bussiness.Objects;

namespace ANP.Bussiness.Models
{
    public interface IBankReceiptRegistration
    {
        TextBox txtPrice { get; }
        TextBox txtPayerName { get; }
        DropDownList ddlReceiptType { get; }
        DropDownList ddl_bank { get; }
        DataGrid dgBarcodeListWithOutPostalCost { get; }
        DataGrid dgBarcodeListWithPostalCost { get; }
        DataGrid dgReceiptList { get; }
        string ReceiptDate { get; set; }
        Button btn_addToList { get; }
        Label lblMessage { get; set; }
        TextBox txtSearechPostReceiptSerial { get; }
        DropDownList ddlSearechPostReceiptSeri { get; }
        TextBox txtSearechPostReceiptSeri { get; }
        TextBox txtReceiptSerialNo { get; }
        TextBox txtSeri { get; }
        TextBox txtVajehCheque { get; }
        TextBox txtSaderKonandehCheque { get; }
        TextBox txtAccountNoCheque { get; }
        TextBox txtComment { get; }
        DropDownList ddlSeri { get; }
        DropDownList ddlTypePrice { get; }
        DropDownList ddlMovazehSearch { get; }
        Label lblAccountNoCheque { get; }
        Label lblSaderKonandehCheque { get; }
        Label lblVajehCheque { get; }
        Label lblComment { get; }
        bool DivtxtSearechPostReceiptSerial { get; set; }
        bool DivtxtComment { get; set; }
        bool DivtxtSaderKonandehCheque { get; set; }
        bool DivtxtVajehCheque { get; set; }
        bool DivtxtAccountNoCheque { get; set; }
        HiddenField hfMovazeh { get; }
        string Fdate { get; set; }
        string Ldate { get; set; }
    }
}
