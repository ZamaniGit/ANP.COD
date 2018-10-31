using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ANP.Bussiness.Models
{
    public interface IShowAllParcels
    {
        DropDownList ddlStatus { get; }
        Button btnSearch { get; }
        Button btnReturn { get; }
        DataGrid MyGrid { get; }
        DataGrid MyDetailGrid { get; }
        string FDate { get; set; }
        string LDate { get; set; }
        bool DivDetailVisibale { get; set; }
        bool DivDetail2Visibale { get; set; }

    }
}