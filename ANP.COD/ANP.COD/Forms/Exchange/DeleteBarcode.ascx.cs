using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANP.Bussiness.Models;
using ANP.Bussiness.Host;
using ANP.Bussiness.Objects;

namespace ANP.COD.Forms.Exchange
{
    public partial class DeleteBarcode : System.Web.UI.UserControl, IDeleteBarcode
    {
        _DeleteBarcode Buss = new _DeleteBarcode();
        LoginDetails UserInfo = new LoginDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            UserValidate();
            Buss.Init(this, UserInfo);
            if (!IsPostBack)
            {
                ucAlertControl.Hide();
            }
        }

        private void UserValidate()
        {
            if (null != Session["UserInfo"])
                UserInfo = Session["UserInfo"] as LoginDetails;
            else
                Response.Redirect("~/Login.aspx", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Result = Buss.InsertRequestForDeleteBarcode();
            ucAlertControl.Show("نتیجه عملیات ", Result, COD.Controls.AlertControl.AlertTypes.info);
        }

        #region IDeleteBarcode Members

        Button IDeleteBarcode.btnSave
        {
            get { return btnSave; }
        }

        TextBox IDeleteBarcode.txtBarcode
        {
            get { return txtBarcode; }
        }

        public TextBox txtComment
        {
            get { return txtDescription; }
        }

        #endregion
    }
}