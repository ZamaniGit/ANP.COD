using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace ANP.Bussiness.Models
{
    public interface ILoginModel
    {
        //frmLogin.aspx Controls
        TextBox txt_UserName { get; }
        TextBox txt_Password { get; }
        DropDownList ddl_State { get; }
        DropDownList ddl_City { get; }
        DropDownList ddl_PostNode { get; }
    }
}
