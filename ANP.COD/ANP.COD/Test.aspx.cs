using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANP.Bussiness.Objects;

namespace ANP.COD
{
    public partial class Test : System.Web.UI.Page
    {
        LoginDetails UserInfo = new LoginDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            UserValidate();
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "anything", "test();", true);
        }

        private void UserValidate()
        {


        }
    }
}