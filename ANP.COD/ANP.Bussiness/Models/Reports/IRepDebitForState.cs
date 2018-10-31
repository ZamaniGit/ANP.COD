using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ANP.Bussiness.Models.Reports
{
    public interface IRepDebitForState
    {
        DropDownList ddlState { get; }
        DropDownList ddlCity { get; }
        DropDownList ddlPostNode { get; }
        DropDownList ddlLastState { get; }
        DropDownList ddlLastCity { get; }
        DropDownList ddlLastPostNode { get; }
        DropDownList ddlBarcodeStatus { get; }
        DropDownList ddlIsReceipt { get; }
        
        string Fdate { get; }
        string Ldate { get; }
        Button btnShow { get; }
        HiddenField hfStateList { get; }
    }
}