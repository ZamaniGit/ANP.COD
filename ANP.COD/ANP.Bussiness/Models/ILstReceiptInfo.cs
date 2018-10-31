using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace ANP.Bussiness.Models
{
    public interface ILstReceiptInfo
    {
        TextBox txt_ReceiptInfo { get; }
        DataGrid MyGrid { get; }
        Button btn_Search { get; }
    }
}
