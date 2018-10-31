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
    public partial class ChangePriceMohandesi : System.Web.UI.UserControl, IChangePriceMohandesi
    {
        _ChangePriceMohandesi Buss = new _ChangePriceMohandesi();
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ucAlertControl.Hide();
            Buss.Search();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Result = string.Empty;
            Result = Buss.AllowUpdatePrice();
            if (Result == string.Empty)
            {
                Buss.SavePrice();
                ucAlertControl.Show("عملیات موفق", "قیمت مرسوله مورد نظر بروزرسانی شد ", COD.Controls.AlertControl.AlertTypes.success);
            }
            else
            {
                ucAlertControl.Show("عملیات ناموفق", Result , COD.Controls.AlertControl.AlertTypes.warning);
            }
            Buss.LoadGrid();
        }

        #region IChangePriceMohandesi Members

        Button IChangePriceMohandesi.btnSearch
        {
            get { return btnSearch; }
        }

        Button IChangePriceMohandesi.btnSave
        {
            get { return btnSave; }
        }

        TextBox IChangePriceMohandesi.txtBarcode
        {
            get { return txtBarcode; }
        }

        TextBox IChangePriceMohandesi.txtPostPrice { get { if (txtPostPrice.Text.Trim() == string.Empty) txtPostPrice.Text = "0"; return txtPostPrice; } }
        TextBox IChangePriceMohandesi.txtCustomerPrice { get { if (txtCustomerPrice.Text.Trim() == string.Empty) txtCustomerPrice.Text = "0"; return txtCustomerPrice; } }
        TextBox IChangePriceMohandesi.txtVattax { get { if (txtVattax.Text.Trim() == string.Empty) txtVattax.Text = "0"; return txtVattax; } }
        //TextBox IChangePriceMohandesi.txtPostPrice
        //{
        //    get { return txtPostPrice; }
        //}

        //TextBox IChangePriceMohandesi.txtCustomerPrice
        //{
        //    get { return txtCustomerPrice; }
        //}

        //TextBox IChangePriceMohandesi.txtVattax
        //{
        //    get { return txtVattax; }
        //}

        DataGrid IChangePriceMohandesi.MyGrid
        {
            get { return MyGrid; }
        }

        #endregion

        protected void MyGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            //بخاطر مقایرت با گزارش مدیریتی باید بصورت نامه بهسمت ما برسد و گزارش مدیریتی هم آپدیت شود
            //if (e.CommandName == "Delete")
            //{
            //    string Result = Buss.DeleteBarcode(e.CommandArgument.ToString());
            //    if (Result == string.Empty)
            //    {
            //        ucAlertControl.Show("عملیات موفق", "مرسوله مورد نظر حذف شد ", COD.Controls.AlertControl.AlertTypes.success);
            //    }
            //    else
            //    {
            //        ucAlertControl.Show("عملیات نا موفق", Result, COD.Controls.AlertControl.AlertTypes.warning);
            //    }

            //}

            if (e.CommandName == "Delete")
                ucAlertControl.Show("عملیات نا موفق", "لطفا درخواست حذف مرسوله را بصورت مکتوب به فناوری اطلاعات اعلام کنید ", COD.Controls.AlertControl.AlertTypes.danger);
        }

        protected void MyGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            bool IsDeleted = false;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                IsDeleted =Convert.ToBoolean( e.Item.Cells[10].Text);

                if (IsDeleted )
                {
                    ((LinkButton)e.Item.FindControl("lnk_Delete")).Visible = false;
                    ((Label)e.Item.FindControl("lbl_DontDel")).Visible = true;
                }
                else
                {
                    ((LinkButton)e.Item.FindControl("lnk_Delete")).Visible = true;
                    ((Label)e.Item.FindControl("lbl_DontDel")).Visible = false;
                }
            }
        }
    }
}