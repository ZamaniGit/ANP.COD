using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANP.Bussiness.Models;
using ANP.Bussiness.Objects;
using ANP.Bussiness.Host;

namespace ANP.COD.Forms.Exchange
{
    public partial class CheckBarcodeListForDel : System.Web.UI.UserControl, ICheckBarcodeListForDel
    {
        _CheckBarcodeListForDel Buss = new _CheckBarcodeListForDel();
        LoginDetails UserInfo = new LoginDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            UserValidate();
            Buss.Init(this, UserInfo);
            if (!IsPostBack)
            {
                ucAlertControl.Hide();
                Buss.loadData();
            }
        }

        private void UserValidate()
        {
            if (null != Session["UserInfo"])
                UserInfo = Session["UserInfo"] as LoginDetails;
            else
                Response.Redirect("~/Login.aspx", true);
        }
        protected void dgBarcodeList_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            ucAlertControl.Hide();
          
            if (e.CommandName == "btnAccept")
                ucAlertControl.Show("نتیجه عملیات", Buss.CheckRequestForDel("Allow", e), COD.Controls.AlertControl.AlertTypes.info);
            else
                ucAlertControl.Show("نتیجه عملیات", Buss.CheckRequestForDel("Deny", e), COD.Controls.AlertControl.AlertTypes.info);

            Buss.loadData();
        }

        #region ICheckBarcodeListForDel Members

        DataGrid ICheckBarcodeListForDel.MyGrid
        {
            get { return dgBarcodeList; }
        }

        #endregion
    }
}