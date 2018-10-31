using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace ANP.Bussiness.Models
{
    public interface IFinancialPanel
    {
        DropDownList ddlCountry { get; }
        DropDownList ddlCity { get; }
        DropDownList ddlDispense { get; }
        DataGrid dgFinancialReceipt { get; }
        Label lblMessage { get; }
        bool Div_Visible { get; set; }
        bool DivDetail { get; set; }
        Button btnDetail { get; }
        DataGrid dgDetail { get; }
        DataGrid dgParcelsDetail { get; }
        bool DivDetail1 { get; set; }
        bool DivDetail2 { get; set; }
        string Fdate { get; set; }
        string Ldate { get; set; }
    }
}
