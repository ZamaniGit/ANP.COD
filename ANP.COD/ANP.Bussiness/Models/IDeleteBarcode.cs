using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace ANP.Bussiness.Models
{
    public interface IDeleteBarcode
    {
        Button btnSave { get; }
        TextBox txtBarcode { get; }
        TextBox txtComment { get; }
    }
}
