using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ANP.Bussiness.Models.Reports
{
    public interface IRepFinancialParcelOfFirstState
    {

        DropDownList ddlState { get; }
        DropDownList ddlCity { get; }
        DropDownList ddlPostNode { get; }
        DropDownList ddlLastState { get; }
        DropDownList ddlLastCity { get; }
        DropDownList ddlLastPostNode { get; }
        DropDownList ddlBarcodeStatus { get; }
        DropDownList ddlBarcodeSubStatus { get; }
        string Fdate { get; }
        string Ldate { get; }
        DropDownList ddlCredit { get; }
        Button btnShow { get; }

    }
}