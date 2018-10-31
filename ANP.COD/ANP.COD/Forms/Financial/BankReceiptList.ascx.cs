using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANP.Bussiness.Host;

using ANP.Bussiness.Models;
using ANP.COD.Controls;
using ANP.Bussiness.Objects;
using ANP.Common;


namespace ANP.COD.Forms.Financial
{
    public partial class BankReceiptList : System.Web.UI.UserControl, IBankReceiptList {
        _BankReceiptList BU = new _BankReceiptList ();
        ANP.Bussiness.Objects.LoginDetails UserInfo = new ANP.Bussiness.Objects.LoginDetails();
        int SumVattax, SumCustomerCost, SumPostalCost, SumAllPrice = 0;

        protected void Page_Load ( object sender, EventArgs e ) {
            UserValidate ();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "anything", "test();", true);
            BU.Init (this, UserInfo);
            if (!IsPostBack) {
                Fdate.Text = DateAndTime.GetDate10DigitManyAgoDays(-7);
                Ldate.Text = DateAndTime.GetDate10Digit();
                BU.FillddlReceiptState ();
                BU.Load_MyGrid ();

            }

        }

        private void UserValidate () {
            if (null != Session["UserInfo"])
                UserInfo = Session["UserInfo"] as LoginDetails;
            else
                Response.Redirect ("~/frmLogin.aspx", true);
        }

        #region Interface Implement

        string IBankReceiptList.Fdate
        {
            get { return Fdate.Text; }
        }

        string IBankReceiptList.Ldate
        {
            get { return Ldate.Text; }
        }

        DropDownList IBankReceiptList.ddlReceiptState {
            get { return ddlReceiptState; }
        }

        DataGrid IBankReceiptList.MyGrid {
            get { return MyGrid; }
        }

        Label IBankReceiptList.lblAlert
        {
            get { return lblAlert; }
            set{lblAlert=  value; }
        }

        //public bool divDetail_visible
        //{
        //    get { return divDetail.Visible; }
        //    set { divDetail.Visible = value; }
        //}

        public bool divReceiptDetail_visible
        {
            get { return divReceiptDetail.Visible; }
            set { divReceiptDetail.Visible = value; }
        }

        public bool divParcelDetail_visible {
            get { return divParcelDetail.Visible; }
            set { divParcelDetail.Visible = value; }
        }

        public bool DivAllPage_visibale {
            get { return DivAllPage.Visible; }
            set { DivAllPage.Visible = value; }
        }

        DataGrid IBankReceiptList.dgReceiptDetail {
            get { return dgReceiptDetail; }
        }

        DataGrid IBankReceiptList.dgParcelDetail {
            get { return dgParcelsDetail; }
        }

        #endregion

        protected void MyGrid_ItemCommand ( object source, DataGridCommandEventArgs e )
        {
            switch (e.CommandName)
            {
                case "Send":
                    //BU.SendReceiptToFinancial(e.Item.Cells[13].Text);
                    BU.SendReceiptToFinancial(e.CommandArgument.ToString());
                    break;
                case "ReceiptDetail":
                    //BU.ShowDetailReceiptInfo(e.Item.Cells[13].Text);
                    BU.ShowDetailReceiptInfo(e.CommandArgument.ToString());
                    break;
                case "ParcelDetail":
                    BU.ShowParcelDetail (e.CommandArgument.ToString());
                    break;
                
            }

        }

        protected void MyGrid_ItemDataBound ( object sender, DataGridItemEventArgs e ) 
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
                if (e.Item.Cells[18].Text == "C") {
                    e.Item.Style.Add("background-color", "#98FB98");
                    ((Label)e.Item.FindControl("lblNokSend")).Visible = true;
                    ((Label)e.Item.FindControl("lblNokSend")).Text = "تایید شده";
                    ((Label)e.Item.FindControl("lblNotSave")).Visible = false;
                    ((LinkButton)e.Item.FindControl("lblOkSend")).Visible = false;
                    ((Label)e.Item.FindControl("lblNotSave")).Visible = false; 
                }
                else if (e.Item.Cells[18].Text == "D" || e.Item.Cells[18].Text == "A")
                {
                    e.Item.Style.Add("background-color", "#f7e8bb");
                    ((Label) e.Item.FindControl ("lblNokSend")).Visible = false;
                    ((Label)e.Item.FindControl("lblNotSave")).Visible = false;
                    ((Label)e.Item.FindControl("lblNotSave")).Visible = false;
                    ((LinkButton)e.Item.FindControl("lblOkSend")).Visible = true;
                    ((LinkButton)e.Item.FindControl("lblOkSend")).Text = "کلیک جهت ارسال ";
                }
                else if (e.Item.Cells[18].Text == "B")
                {
                    e.Item.Style.Add("background-color", "#fdfdfe");
                    ((Label)e.Item.FindControl("lblNokSend")).Visible = true;
                    ((Label)e.Item.FindControl("lblNokSend")).Text = "در دست بررسی";
                    ((Label)e.Item.FindControl("lblNotSave")).Visible = false;
                    ((Label)e.Item.FindControl("lblNotSave")).Visible = false;
                    ((LinkButton)e.Item.FindControl("lblOkSend")).Visible = false;
                }
                else if (e.Item.Cells[18].Text == "Z")
                {
                    e.Item.Style.Add("background-color", "#fcf3e8");
                    ((Label)e.Item.FindControl("lblNokSend")).Visible = false;
                    ((Label)e.Item.FindControl("lblNotSave")).Visible = true;
                    ((Label)e.Item.FindControl("lblNotSave")).Text = "عدم ثبت نهایی";               
                    ((LinkButton)e.Item.FindControl("lblOkSend")).Visible = false;
                    ((LinkButton)e.Item.FindControl("lblReceiptDetail")).Visible = false;
                }
            }
        }

        protected void btnDetail_Click ( object sender, EventArgs e ) {
            DivAllPage_visibale = false;
            //divDetail.Visible = false;
            divReceiptDetail_visible = false;
            divParcelDetail_visible = false;
        }

        protected void dgDetail_ItemDataBound ( object sender, DataGridItemEventArgs e ) {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
                int AllowUpdateCounter = 30;
                bool DontAllowEditation = true;
                bool IsExistentSup = true;
                int UpdateCounter = 1;
                string IsSub = "Y";

                UpdateCounter = Convert.ToInt32 (e.Item.Cells[9].Text);
                IsSub = e.Item.Cells[10].Text;
                IsExistentSup = BU.ExistentSupplement (e.Item.Cells[1].Text);
                DontAllowEditation = BU.IsSendToFinancial (e.Item.Cells[1].Text, UserInfo.UserId);

                if (!DontAllowEditation) {
                    if (UpdateCounter > AllowUpdateCounter)
                    {
                        // e.Item.Style.Add("background-color", "#8FBC8B");
                        ((LinkButton) e.Item.FindControl ("lblReceiptEdit")).Visible = false;
                        ((Label) e.Item.FindControl ("lblDontReceiptEdit")).Visible = true;
                        ((Label) e.Item.FindControl ("lblDontReceiptEdit")).Text = "غیر قابل ویرایش";
                    }
                    if (IsSub == "Y") {
                        ((LinkButton) e.Item.FindControl ("lblSupReceipt")).Visible = false;
                        ((Label) e.Item.FindControl ("lbl_SupReceipt")).Visible = true;
                        ((Label) e.Item.FindControl ("lbl_SupReceipt")).Text = "";
                    }
                    if (IsSub == "N" && IsExistentSup) {

                            //e.Item.Style.Add("background-color", "#F08080");
                            ((LinkButton)e.Item.FindControl("lblSupReceipt")).Visible = false;
                            ((Label)e.Item.FindControl("lbl_SupReceipt")).Visible = true;
                            ((Label)e.Item.FindControl("lbl_SupReceipt")).Text = "فیش متمم دارد";

                    }
                                        
                    if (e.Item.Cells[14].Text == "4")
                    {
                        //e.Item.Style.Add("background-color", "#F08080");
                        ((LinkButton)e.Item.FindControl("lblSupReceipt")).Visible = false;
                        ((Label)e.Item.FindControl("lbl_SupReceipt")).Visible = true;
                        ((Label)e.Item.FindControl("lbl_SupReceipt")).Text = "این نوع فیش متمم ندارد";
                    }
                }
                else if (DontAllowEditation) {
                    ((LinkButton) e.Item.FindControl ("lblReceiptEdit")).Visible = false;
                    ((Label) e.Item.FindControl ("lblDontReceiptEdit")).Visible = true;
                    ((Label) e.Item.FindControl ("lblDontReceiptEdit")).Text = " ";
                    ((LinkButton) e.Item.FindControl ("lblSupReceipt")).Visible = false;
                    ((Label) e.Item.FindControl ("lbl_SupReceipt")).Visible = true;
                    ((Label) e.Item.FindControl ("lbl_SupReceipt")).Text = " ";
                }
            }
        }

        protected void dgDetail_ItemCommand ( object source, DataGridCommandEventArgs e ) {
            string ReceiptID = e.Item.Cells[1].Text;
            string OrginalReceipt = e.Item.Cells[13].Text;

            switch (e.CommandName) {
                case "Edit":
                EditReceipt (ReceiptID, OrginalReceipt);
                break;
                case "Sup":
                Session["ParentID"] = e.CommandArgument.ToString ();
                Response.Redirect ("~/Default.aspx?action=A503DF13-A237-4278-9614-A22A09E61579");
                break;
            }
        }

        private void EditReceipt ( string EditID, string IsOrginalReceipt ) {
            if (IsOrginalReceipt == "N") {
                Session["ReceiptID"] = EditID;
                Session["ReceiptIsSupplement_Param"] = "E";
                ///ثبت فیش متمم
                Response.Redirect ("~/Default.aspx?action=a503df13-a237-4278-9614-a22a09e61579", true);
            }
            else {
                Session["ReceiptID"] = EditID;
                ///ویرایش مرسولات فیش واریزی
                Response.Redirect ("~/Default.aspx?action=eb76fbc1-5cc3-43c4-ae9c-354c78055a70", true);
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            BU.Load_MyGrid();
        }

        protected void dgParcelsDetail_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SumPostalCost += Convert.ToInt32(e.Item.Cells[7].Text);
                SumVattax += Convert.ToInt32(e.Item.Cells[8].Text);
                SumCustomerCost += Convert.ToInt32(e.Item.Cells[9].Text);
                SumAllPrice += Convert.ToInt32(e.Item.Cells[10].Text);
            }
            lblPostalCost.Text = SumPostalCost.ToString();
            lblVattax.Text = SumVattax.ToString();
            lblCostumerCost.Text = SumCustomerCost.ToString();
            lblAllPrice.Text = SumAllPrice.ToString();
        }
    }
}