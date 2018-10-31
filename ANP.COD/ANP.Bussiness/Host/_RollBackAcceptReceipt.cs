using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ANP.Bussiness.Objects;
using ANP.Data;
using ANP.Bussiness.Models;
using ANP.Bussiness.Basic;
using ANP.Data.BaseData;
using System.Web.UI.WebControls;
using System.Data;

namespace ANP.Bussiness.Host
{
    public class _RollBackAcceptReceipt
    {
        IRollBackAcceptReceipt _host;
        LoginDetails UserInfo;
        ReceiptInfo RI = new ReceiptInfo();
        Base Data = new Base();

        public void InitializeIRollBackAcceptReceipt(IRollBackAcceptReceipt hostform, LoginDetails LD)
        {
            this._host = hostform;
            UserInfo = LD;
        }

        public void Load_ddlState()
        {
            Utility.FillCombo(Data.lstState(), _host.ddlState, "Code", "Pname", false);
        }
        
        public void GetSelectedRowInGrid(out string SelectedID)
        {
            SelectedID = string.Empty;
            SelectedID = GetidOfSelectedRow();
        }

        public void Load_dgReceiptList( string StateCode , string Date)
        {
            DataTable dt = new DataTable();
            dt = RI.ReturnAllReceiptStateInOnDay(StateCode, Date);
            _host.dgReceiptList.DataSource = dt;
            _host.dgReceiptList.DataBind();

        }

        private string GetidOfSelectedRow()
        {
            string Result = string.Empty;

            if (_host.dgReceiptList.Visible == true)
            {
                foreach (DataGridItem item in _host.dgReceiptList.Items)
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                        if (((CheckBox)item.Cells[2].FindControl("chkSelect")).Checked)
                            if (item.Cells[7].Text == "--")
                                Result += item.Cells[0].Text + ",";
            }
            Result = Result.TrimEnd(',');
            return Result;
        }

        public string ReturnReceiptToState(DataGridCommandEventArgs e)
        {
           string ReceiptID= e.CommandArgument.ToString();
            TextBox txtDescriptions = (TextBox)e.Item.FindControl("txtDescription");
            return RI.ReturnReceiptToState(ReceiptID, txtDescriptions.Text.Trim(), UserInfo.UserId);
        }
    }
}