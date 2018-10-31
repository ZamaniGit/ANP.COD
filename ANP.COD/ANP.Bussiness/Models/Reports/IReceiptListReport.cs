using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;


namespace ANP.Bussiness.Models.Reports
{
    public interface IReceiptListReport
    {
        Button btnReport { get; }
        string ddlFdate { get; set; }
        string ddlLdate { get; set; }
        DropDownList ddlStatus { get; }
    }
}
