using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Prs.Bussiness
{
    public interface IBarcodeReceiptEditation
    {
        TextBox txtReceiptNo { get; }
        TextBox txtSeri { get; }
        TextBox txtPrice { get; }
        TextBox txtPayerName { get; }
        DropDownList ddlSeri { get; }
        DropDownList ddl_bank { get; }
        DataGrid dgBarcodeList { get; }
        string ReceiptDate { get; set; }



        DropDownList ddlTypePrice { get; }
        string lblMessage { get; set; }

        TextBox txtVajehCheque { get; }
        TextBox txtSaderKonandehCheque { get; }
        TextBox txtAccountNoCheque { get; }
        TextBox txtComment { get; }

        Label lblAccountNoCheque { get; }
        Label lblSaderKonandehCheque { get; }
        Label lblVajehCheque { get; }
        Label lblComment { get; }
    }
}
