using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace ANP.Bussiness.Models
{
    public interface IUsersManagment
    {
        TextBox txt_Pname { get; }
        TextBox txt_Ename { get; }
        TextBox txt_Pass { get; }
        TextBox txt_RePass { get; }
        TextBox txt_Fmily { get; }
        
        DropDownList ddl_Role { get; }
        DropDownList ddl_State { get; }
        DropDownList ddl_City { get;  }
        DropDownList ddl_PostNode { get; }
        DropDownList ddl_Status { get; }

        Button btn_cancel { get; }
        Button btn_save { get; }

        DataGrid Mygrd { get; }
        HiddenField hf_update { get; }

        System.Web.UI.HtmlControls.HtmlGenericControl divState { get; }
        System.Web.UI.HtmlControls.HtmlGenericControl divCity { get; }
        System.Web.UI.HtmlControls.HtmlGenericControl divPostNode { get; }
        System.Web.UI.HtmlControls.HtmlGenericControl divEname { get; }
        System.Web.UI.HtmlControls.HtmlGenericControl divRole { get; }

    }
}
