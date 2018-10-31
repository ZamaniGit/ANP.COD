using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using ANP.Bussiness.Models;
using ANP.Data.Object;
using ANP.Data;
using ANP.Bussiness.Objects;

namespace ANP.Bussiness.Host
{
    public class _BankReceiptEditation
    {
        string Query = string.Empty;
        IBankReceiptEditation _host;
        LoginDetails UserInfo;
        BankReceipt BI = new BankReceipt();

        public void Init(IBankReceiptEditation hostform, LoginDetails LD)
        {
            this._host = hostform;
            UserInfo = LD;  
        }

        public void Load_MyGrid(string ParentID)
        {
            //_host.MyGrid.DataSource = BI.ReturnDetailOfOrginalReceipt(ParentID,UserInfo.UserId);
            //_host.MyGrid.DataBind();
        }

        public bool Del(int EditID)
        {
            string IsSupplementReceipt= BI.IsSupplementReceipt(EditID);
            if ((IsSupplementReceipt == "Y") || (IsSupplementReceipt == "N" && BI.DontExistSupplementReceipt(EditID)))
            {
                BI.DeleteReceiptInfoByID(EditID);
                return true;
            }
            else
                return false;
        }

        //public void LoadDataForEditSupplement(int EditID)
        //{
           
        //    ReceiptClass rc = new ReceiptClass();
        //    rc= BI.ReturnReceiptInfoByID(EditID);
            
        //}

        public bool IsSupplement(int EditID)
        {
            if (BI.IsSupplementReceipt(EditID) == "Y")
                return true;
            else
                return false;
        }

        public void SendeToFinance()
        {
            foreach (DataGridItem item in _host.MyGrid.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    BI.SentToFinance(item.Cells[0].Text);
                }

            }
            
        }
    }
}
