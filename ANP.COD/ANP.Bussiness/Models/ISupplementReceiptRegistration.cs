using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace ANP.Bussiness.Models
{
    public interface ISupplementReceiptRegistration
    {

        string PayDate { get; set; }
        DropDownList ddl_bank { get; }
        DropDownList ddlReceiptType { get; }
        DropDownList ddlSeri { get; }
        TextBox txtParentSeriAlphabet { get; }
        
        TextBox txtSeri { get; }
        TextBox txtReceiptNo { get; }
        TextBox txtPrice { get; }
        TextBox txtParentReceiptID { get; }
        TextBox txtPayerName { get; }
        TextBox txtParentSeri { get; }

        Button btn_addToList { get; }
        Label lblParentReceipt { get; }



        TextBox txtSaderKonandehCheque { get; }
        TextBox txtAccountNoCheque { get; }
        TextBox txtComment { get; }
        TextBox txtVajehCheque { get; }

        Label lblAccountNoCheque { get; }
        Label lblSaderKonandehCheque { get; }
        Label lblVajehCheque { get; }
        Label lblComment { get; }

        DropDownList ddlTypePrice { get; }
        //Button btn_addToList { get; }
        //Label lblMessage { get; set; }
        //string ReceiptDate { get; set; }
        //DropDownList ddl_bank { get; }
        //DropDownList ddlReceiptType { get; }
        //DropDownList ddlSeri { get; }
        //DropDownList ddlTypePrice { get; }
        //DropDownList ddlSearechPostReceiptSeri { get; }
        //TextBox txtSeri { get; }
        //TextBox txtReceiptSerialNo { get; }
        //TextBox txtPrice { get; }
        //TextBox txtPayerName { get; }
        //TextBox txtVajehCheque { get; }
        //TextBox txtSaderKonandehCheque { get; }
        //TextBox txtAccountNoCheque { get; }
        //TextBox txtComment { get; }
        //TextBox txtSearechPostReceiptSerial { get; }
        //TextBox txtSearechPostReceiptSeri { get; }
        //Label lblAccountNoCheque { get; }
        //Label lblSaderKonandehCheque { get; }
        //Label lblVajehCheque { get; }
        //Label lblComment { get; }
        
    }
}
