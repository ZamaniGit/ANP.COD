using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using ANP.Bussiness.Objects;

namespace ANP.Bussiness.Models
{
    public interface IBankReceiptList
    {
        DropDownList ddlReceiptState { get; }
        
        Label lblAlert { get; set; }
        bool DivAllPage_visibale { get; set; }
        bool divParcelDetail_visible { get; set; }
        //bool divDetail_visible { get; set; }
        bool divReceiptDetail_visible { get; set; }
        DataGrid dgReceiptDetail { get; }
        DataGrid dgParcelDetail { get; }
        DataGrid MyGrid { get; }
        string Fdate { get; }
        string Ldate { get; }
    }
}
