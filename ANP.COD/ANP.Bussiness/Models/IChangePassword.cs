using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace ANP.Bussiness.Models
{
    public interface IChangePassword
    {
        TextBox txt_curentpass { get; }
        TextBox txt_newpass { get; }
        TextBox txt_new_repass { get; }
        Button btn_approve { get; }
        HiddenField hf_msg { get; }
    }
}
