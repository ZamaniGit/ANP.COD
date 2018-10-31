using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace ANP.Bussiness.Models
{
    public interface IRepIncomingParcel
    {

        DropDownList ddlFirstState { get; }
        DropDownList ddlExchangeState { get; }
        DropDownList ddlReceiptState { get; }
        DropDownList ddlLastState { get; }
        DropDownList ddlLastCity { get; }
        DropDownList ddlLastPostNode { get; }
        DropDownList ddlGC { get; }
        DropDownList ddlContractType { get; }
        DropDownList ddlServiceType { get; }

        string Fdate { get; }
        string Ldate { get; }
        Button btnShow { get; }
    }
}
