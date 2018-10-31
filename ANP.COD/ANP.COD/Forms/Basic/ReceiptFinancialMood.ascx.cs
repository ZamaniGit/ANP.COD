using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANP.Bussiness.Objects;
using ANP.Bussiness.Host;
using ANP.Bussiness.Models;


namespace ANP.COD.Forms.Basic
{
    public partial class ReceiptFinancialMood : System.Web.UI.UserControl,IFinancialMood
    {
        LoginDetails UserInfo = new LoginDetails();
        _FinancialMood BU = new _FinancialMood();

        protected void Page_Load(object sender, EventArgs e)
        {

            UserValidate();
            BU.InitializeIFinancialMood(this, UserInfo);
            if (!IsPostBack)
            {
                BU.LoadMyGrid();
            }
        }

        private void UserValidate()
        {
            if (null != Session["UserInfo"])
                UserInfo = Session["UserInfo"] as LoginDetails;
            else
                Response.Redirect("~/Login.aspx", true);
        }

        #region Implement

        Button IFinancialMood.btnSave
        {
            get { return btnSave; }
        }

        DataGrid IFinancialMood.MyGrid
        {
            get { return MyGrid; }
        }

        TextBox IFinancialMood.txtDetail
        {
            get { return txtDetail; }
        }

        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BU.SaveData();
                BU.LoadMyGrid();
            }
            catch { }
        }
    }
}