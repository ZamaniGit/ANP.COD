using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;
using ANP.Data;
using ANP.Bussiness;
using ANP.Common;
using ANP.Bussiness.Models;
using ANP.Bussiness.Objects;
using ANP.Data.Object;
using ANP.Bussiness.Basic;

namespace ANP.Bussiness.Host
{
    public class _FinancialPanel
    {
        IFinancialPanel _host;
        LoginDetails UserInfo;
        Financial finData = new Financial();
        ReceiptClass receipt = new ReceiptClass();
        BankReceipt br = new BankReceipt();
        ANP.Data.BaseData.Base BaseData = new ANP.Data.BaseData.Base();

        public void InitializeFinancialPanel(IFinancialPanel hostform, LoginDetails LD)
        {
            this._host = hostform;
            UserInfo = LD;

        }

        //public void Load_ddlReceiptState()
        //{
        //    Utility.FillCombo(BaseData.ReturnReceiptFinancialMood(), _host.ddlReceiptState, "Value", "Title",false);
        //}

        public void Load_ddlCountry()
        {
            Utility.FillCombo(BaseData.ReturnCounty(UserInfo.StateCode.ToString()), _host.ddlCountry, "Code", "Pname", "همه شهرستانها");
            Load_ddlCity();
        }

        public void Load_ddlCity()
        {
            if (int.Parse(_host.ddlCountry.SelectedValue) == 0)
            {
                //_host.ddlCity.Enabled = false;
                //_host.ddlDispense.Enabled = false;
            }

            else
            {
                //_host.ddlCity.Enabled =
                //_host.ddlDispense.Enabled = true;
                Utility.FillCombo(BaseData.ReturnCityByCountry(_host.ddlCountry.SelectedValue), _host.ddlCity, "Code", "Pname", false);
                Load_ddlDispense();
            }
        }

        public void Load_ddlDispense()
        {
            Utility.FillCombo(BaseData.ReturnPostnode(_host.ddlCity.SelectedValue), _host.ddlDispense, "Code", "Pname", false);
        }

        public void Load_MyGrid()
        {
            DataTable obj = new DataTable();

            string County = _host.ddlCountry.SelectedValue;
            string City = (County == "0" ? "0" : _host.ddlCity.SelectedValue);
            string Dispense = (County == "0" ? "0" : _host.ddlDispense.SelectedValue);
            string FirstDate = _host.Fdate;
            string LastDate = _host.Ldate;

            obj = finData.GetAllFinancialReceipt(UserInfo.StateCode.ToString(), Dispense, FirstDate, LastDate);
            _host.dgFinancialReceipt.DataSource = obj;
            _host.dgFinancialReceipt.DataBind();
        }

        public void Load_ddlCause(System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                DropDownList list = (DropDownList)e.Item.FindControl("ddlReceiptState");
                Utility.FillCombo(BaseData.ReturnReceiptFinancialMood(), list, "Value", "Title", false);
            }


            //if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            //{
            //    CheckBox chk = (CheckBox)e.Item.FindControl("chkHeaderSelect");
            //    if (e.Item.Cells[7].Text != "--")
            //        chk.Checked = true;
            //}


        }

        public bool ItemCommand(DataGridCommandEventArgs e)
        {
            bool Result = false;
            CreateReceiptObject(e);
            switch (e.CommandName)
            {
                case "OK":
                    string flag = "";
                    DropDownList list = (DropDownList)e.Item.FindControl("ddlReceiptState");
                    TextBox txtDescriptions = (TextBox)e.Item.FindControl("txtDescription");
                    if (Convert.ToInt32(list.SelectedValue) == 1)
                        flag = "C";
                    else
                        flag = "D";
                    finData.UpdateReceiptInfoByFinancialUser(receipt, flag, list.SelectedValue, txtDescriptions.Text, DateAndTime.GetDate10Digit());
                    ShowMessage("");
                    Result = true;
                    break;
                //case "NOK":
                //    if (DontEmptyDescription(e))
                //    {
                //        finData.UpdateReceiptInfoByFinancialUser(receipt, "D");
                //        ShowMessage("");
                //        Result = true;
                //    }
                //    else
                //        ShowMessage("قبل از زدن عدم تایید باید فیلد توضیحات را وارد نمایید");
                //    break;
                case "Detail":
                    EnableDetail(receipt.ID);
                    break;

                case "ParcelsDetail":
                    EnableParcelsDetail(receipt.ID);
                    break;

            }
            return Result;
            //  Load_MyGrid();
        }

        private void EnableParcelsDetail(int ReceiptID)
        {
            _host.DivDetail2 = true;
            _host.DivDetail = true;
            _host.DivDetail1 = false;

            _host.dgParcelsDetail.DataSource = finData.ReturnParcelsListByReceiptID(ReceiptID);
            _host.dgParcelsDetail.DataBind();
        }

        private void ShowMessage(string Message)
        {
            if (Message.Trim() == string.Empty)
                _host.Div_Visible = false;
            else
            {
                _host.Div_Visible = true;
                _host.lblMessage.Text = Message;
            }
        }

        private bool DontEmptyDescription(DataGridCommandEventArgs e)
        {
            bool Result = false;
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                TextBox txtDes = (TextBox)e.Item.FindControl("txtDescription");
                if (txtDes.Text.Trim() != string.Empty)
                    Result = true;
            }
            return Result;
        }

        private void CreateReceiptObject(DataGridCommandEventArgs e)
        {
            receipt.ID = int.Parse(e.Item.Cells[1].Text);
            receipt.ApproveDate = DateAndTime.GetDate10Digit();
            receipt.Description = ((System.Web.UI.WebControls.TextBox)e.Item.
                     FindControl("txtDescription")).Text;
        }

        public void DisableDetail()
        {
            _host.DivDetail = false;
            _host.DivDetail1 = false;
            _host.DivDetail2 = false;
        }

        public void EnableDetail(int ReceiptID)
        {
            _host.DivDetail2 = false;
            _host.DivDetail1 = true;
            _host.DivDetail = true;

            _host.dgDetail.DataSource = finData.ReturnDetailReceiptByID(ReceiptID);
            _host.dgDetail.DataBind();
        }
    }
}
