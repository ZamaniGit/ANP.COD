using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANP.Bussiness.Host;
using ANP.Bussiness.Objects;
using ANP.Bussiness.Models;


namespace ANP.COD.Forms.Financial
{
    public partial class LstReceiptInfo : System.Web.UI.UserControl,ILstReceiptInfo
    {
        _LstReceiptInfo BU = new _LstReceiptInfo();
        LoginDetails UserInfo = new LoginDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            UserValidate();
            BU.Init(this, UserInfo);
            //if (!IsPostBack)
            //{
            //    BU.Load_MyGrid();
            //}

        }

        private void UserValidate()
        {
            if (null != Session["UserInfo"])
                UserInfo = Session["UserInfo"] as LoginDetails;
            else
                Response.Redirect("~/Login.aspx", true);
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            BU.Load_MyGrid();
        }
        #region Interface Implement

        Button ILstReceiptInfo.btn_Search
        {
            get { return btn_Search; }
        }

        TextBox ILstReceiptInfo.txt_ReceiptInfo
        {
            get { return txt_ReceiptInfo; }
        }

        DataGrid ILstReceiptInfo.MyGrid
        {
            get { return MyGrid; }
        }

        #endregion
    }
}