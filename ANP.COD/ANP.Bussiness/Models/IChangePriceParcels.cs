using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace ANP.Bussiness.Models
{
    public interface IChangePriceParcels
    {
        //System.Web.UI.HtmlControls.HtmlGenericControl DivDetailPage { get; }
        //System.Web.UI.HtmlControls.HtmlGenericControl DivDetail { get; }
        //System.Web.UI.HtmlControls.HtmlGenericControl divPageMessages { get; }
        //Literal litPageMessages { get; }
        //Button btnReturn { get; }
        //Button btnUpdate { get; }
        HtmlGenericControl DivDetail { get; }
        HtmlGenericControl DivAllPage { get; }
        Label lblSumVatTax { get; }
        Label lblSumPostal { get; }
        Label lblSumCustomer { get; }
        Label txtSumPrice { get; }
        DropDownList ddlStatus { get; }
        DropDownList ddlMovazeh { get; }
        DropDownList ddlFinancial { get; }
        DropDownList ddlParentState { get; }
        DropDownList ddlParcelType { get; }
        DropDownList ddlGC { get; }
        DropDownList ddlLC { get; }

        Button btnSearch { get; }
        Button btnReturn { get; }
        
        string Fdate { get;  }
        string Ldate { get; set; }
        DataGrid MyGrid { get; }
        DataGrid MyDetailGrid { get; }
        TextBox txtBracodeSearch { get; }
        LinkButton lblDetail { get; }
        CheckBox chkDontPayPrice { get; }
        CheckBox ChkNonContract { get; }
    }
}