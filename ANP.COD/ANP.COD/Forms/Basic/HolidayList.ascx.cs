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
    public partial class HolidayList : System.Web.UI.UserControl, IHoliday
    {
        LoginDetails UserInfo = new LoginDetails();
        _Holiday BU = new _Holiday();

        protected void Page_Load(object sender, EventArgs e)
        {

            UserValidate();
            BU.InitializeIHoliday(this, UserInfo);
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

        Button IHoliday.btnSave
        {
            get { return btnSave; }
        }

        DataGrid IHoliday.MyGrid
        {
            get { return MyGrid; }
        }

        string IHoliday.MyDate
        {
            get
            {
                return MyDate.SelectedPersianDate;
            }
            set
            {
                MyDate.SelectedPersianDate = value;
            }
        }

        TextBox IHoliday.txtDetail
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