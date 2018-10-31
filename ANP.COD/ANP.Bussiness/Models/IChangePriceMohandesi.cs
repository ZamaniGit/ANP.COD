using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace ANP.Bussiness.Models
{
    public interface IChangePriceMohandesi
    {
        Button btnSearch { get; }
        Button btnSave { get; }
        TextBox txtBarcode { get; }
        TextBox txtPostPrice { get; }
        TextBox txtCustomerPrice { get; }
        TextBox txtVattax { get; }
        DataGrid MyGrid { get; }
    }
}
