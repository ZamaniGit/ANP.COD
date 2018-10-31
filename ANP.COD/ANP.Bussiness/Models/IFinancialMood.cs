using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace ANP.Bussiness.Models
{
    public interface IFinancialMood
    {
        Button btnSave { get; }
        DataGrid MyGrid { get; }
        TextBox txtDetail { get; }
    }
}
