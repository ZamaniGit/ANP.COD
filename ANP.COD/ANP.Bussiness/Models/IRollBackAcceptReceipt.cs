using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ANP.Bussiness.Models
{
    public interface IRollBackAcceptReceipt
    {
        DropDownList ddlState { get; }
        DataGrid dgReceiptList { get; }
        string Date { get; set; }
        Button btnShow { get; }
    }
}