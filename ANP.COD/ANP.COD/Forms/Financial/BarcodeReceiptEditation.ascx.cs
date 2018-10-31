using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Prs.Bussiness;
using ANP.Bussiness.Host;
using ANP.Bussiness.Objects;

namespace ANP.COD.Forms.Financial
{
    public partial class BarcodeReceiptEditation : System.Web.UI.UserControl, IBarcodeReceiptEditation
    {
        _BarcodeReceiptEditation BU = new _BarcodeReceiptEditation();
        LoginDetails UserInfo = new LoginDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            UserValidate();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "anything", "test();", true);
            BU.InitializeIBankReceiptRegistration(this, UserInfo);
            if (!IsPostBack)
            {
                BU.LoadReceiptInfo(Session["ReceiptID"].ToString());
                BU.Load_dgBarcodeList(Session["ReceiptID"].ToString());
            }
        }

        private void UserValidate()
        {
            if (null != Session["UserInfo"])
            {
                UserInfo = Session["UserInfo"] as LoginDetails;
                if (UserInfo.RoleID != 1005 && UserInfo.RoleID != 1006)
                    Response.Redirect("~/Permission.aspx", true);
            }
            else
                Response.Redirect("~/Login.aspx", true);

        }

        protected void btn_addToList_Click(object sender, EventArgs e)
        {
            string SelectedID = string.Empty;
            string DontSelectedID = string.Empty;
            string Result = "";

            BU.GetSelectedRowIndgBarcodeList(out SelectedID);
            BU.GetDontSelectedRowIndgBarcodeList(out DontSelectedID);
            if (SelectedID.Trim() == string.Empty)
            {
                ShowMessage("حداقل یکی از بارکدها باید انتخاب شود.");
                return;
            }
            else
            {
                ShowMessage("");
                Result = BU.UpdateInfo(SelectedID, DontSelectedID, Session["ReceiptID"].ToString());
                if (Result != "") { ShowMessage(Result); return; }
            }
            finish();
            Response.Redirect("~/Default.aspx?action=DF5ACBB6-B2DA-4C87-B737-988DBFB5054B", true);
        }

        public void ShowMessage(string Message)
        {
            if (Message.Trim() == string.Empty)
            {
                lblAlert.Text = "";
                lblAlert.Visible = false;
            }
            else
            {
                lblAlert.Visible = true;
                lblAlert.Text = @"<div id=""DivMessage"" runat=""server"" class=""alert alert-info"">
                    <!-- success alert -->
                    <strong> توجه ! </strong> " + Message + "</div>";
            }
        }

        protected void dgBarcodeList_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                CheckBox chk = (CheckBox)e.Item.FindControl("chkHeaderSelect");
                if (e.Item.Cells[7].Text != "--")
                    chk.Checked = true;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            finish();
            Response.Redirect("~/Default.aspx?action=DF5ACBB6-B2DA-4C87-B737-988DBFB5054B", true);
        }

        private void finish()
        {
            Session["ReceiptID"] = null;
        }

        protected void ddlTypePrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            BU.FormItemesVisible(ddlTypePrice.SelectedValue);
        }

        #region Implemant

        TextBox IBarcodeReceiptEditation.txtSeri
        {
            get { return txtSeri; }
        }

        DropDownList IBarcodeReceiptEditation.ddlSeri
        {
            get { return ddlSeri; }
        }

        TextBox IBarcodeReceiptEditation.txtReceiptNo
        {
            get { return txtReceiptNo; }
        }

        TextBox IBarcodeReceiptEditation.txtPrice
        {
            get { return txtPrice; }
        }

        TextBox IBarcodeReceiptEditation.txtPayerName
        {
            get { return txtPayerName; }
        }

        DropDownList IBarcodeReceiptEditation.ddl_bank
        {
            get { return ddl_bank; }
        }

        DataGrid IBarcodeReceiptEditation.dgBarcodeList
        {
            get { return dgBarcodeList; }
        }

        DropDownList IBarcodeReceiptEditation.ddlTypePrice
        {
            get { return ddlTypePrice; }
        }

        TextBox IBarcodeReceiptEditation.txtVajehCheque
        {
            get { return txtVajehCheque; }
        }

        TextBox IBarcodeReceiptEditation.txtSaderKonandehCheque
        {
            get { return txtSaderKonandehCheque; }
        }

        TextBox IBarcodeReceiptEditation.txtAccountNoCheque
        {
            get { return txtAccountNoCheque; }
        }

        TextBox IBarcodeReceiptEditation.txtComment
        {
            get { return txtComment; }
        }

        Label IBarcodeReceiptEditation.lblAccountNoCheque
        {
            get { return lblAccountNoCheque; }
        }

        Label IBarcodeReceiptEditation.lblSaderKonandehCheque
        {
            get { return lblSaderKonandehCheque; }
        }

        Label IBarcodeReceiptEditation.lblVajehCheque
        {
            get { return lblVajehCheque; }
        }

        Label IBarcodeReceiptEditation.lblComment
        {
            get { return lblComment; }
        }

        public string ReceiptDate
        {
            get
            {
                return DateSelector1.Text;
            }
            set
            {
                DateSelector1.Text = value;
            }
        }

        string IBarcodeReceiptEditation.lblMessage
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

    }
}