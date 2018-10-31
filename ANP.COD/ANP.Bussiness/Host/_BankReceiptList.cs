using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ANP.Data;
using ANP.Bussiness;
using ANP.Common;
using ANP.Bussiness.Models;
using ANP.Bussiness.Objects;
using ANP.Bussiness.Basic;

namespace ANP.Bussiness.Host
{
    public class _BankReceiptList
    {
        IBankReceiptList _host;
        LoginDetails UserInfo;
        BankReceipt BI = new BankReceipt();

        public void Init(IBankReceiptList hostform, LoginDetails LD)
        {
            this._host = hostform;
            UserInfo = LD;
        }

        public void Load_MyGrid()
        {
            string ApproveFlag = _host.ddlReceiptState.SelectedValue;
            _host.MyGrid.DataSource = BI.ReturnAllReceiptListByReceiptState(ApproveFlag, UserInfo.UserId, UserInfo.PostNodeCode
                    ,_host.Fdate,_host.Ldate);
            _host.MyGrid.DataBind();
        }

        public void ItemCommand(System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Supplement":

                    BI.DeleteReceiptInfoByID(Convert.ToInt32(e.CommandArgument));
                    break;
            }
            Load_MyGrid();
        }

        public int FindOrginalReceiptID(int SupplementID)
        {
            return BI.ReturnOrginalReceiptID(SupplementID);
        }

        public void ShowMessage(string Message)
        {
            if (Message.Trim() == string.Empty)
            {
                _host.lblAlert.Text = "";
                _host.lblAlert.Visible = false;
            }
            else
            {
                _host.lblAlert.Text = @"<div id=""DivMessage"" runat=""server"" class=""alert alert-info"">
                    <!-- success alert -->
                    <strong> توجه ! </strong> " + Message + "</div>";
            }
        }

        public string ApproveFlag(string ID)
        {
            string Result = "";
            Result = BI.ReceiptApproveFlag(ID);
            return Result;
        }

        public void FillddlReceiptState()
        {
            Utility.FillCombo(BI.ReturnAllApproveFlag(), _host.ddlReceiptState, "Flag", "Title", "همه");
        }

        public void SendReceiptToFinancial(string RefID)
        {
            _host.lblAlert.Text = "";

            if (DontProblemForSend(RefID))
                if (VattaxIsOk(RefID))
                SendToFinancial(RefID);
                else
                    _host.lblAlert.Text = "فیش مالیات بر ارزش افزوده ثبت نشده و قابل ارسال به مالی نیست";
            else
                _host.lblAlert.Text = "فیشی که تایید نهایی نشده قابل ارسال نمی باشد";

            Load_MyGrid();
        }

        private bool VattaxIsOk(string RefID)
        {
            bool Result=true;
            if(BI.SumVattax(RefID)>0 )
                Result=BI.IsSavedReceiptVattax(RefID);
            return Result;



            



        }

        private void SendToFinancial(string RefID)
        {
            BI.SentToFinanceByRefID(RefID, DateAndTime.GetDate10Digit());
        }

        private bool DontProblemForSend(string RefID)
        {
            bool Result = false;
            Result = BI.ISOkForSend(RefID, UserInfo.UserId.ToString());
            return Result;
        }

        public void ShowDetailReceiptInfo(string RefID)
        {
            _host.DivAllPage_visibale = true;
            //_host.divDetail_visible = true;
            _host.divReceiptDetail_visible = true;
            _host.divParcelDetail_visible = false;
            Load_dgReceiptDetail(RefID);
        }

        public void Load_dgReceiptDetail(string RefID)
        {
            _host.dgReceiptDetail.DataSource = BI.ReturnAllReceiptListByRefID(RefID, UserInfo.UserId, UserInfo.PostNodeCode);
            _host.dgReceiptDetail.DataBind();
        }

        public void Load_dgParcelDetail(string RefID)
        {
            _host.dgParcelDetail.DataSource = BI.ReturnParcelsListByReceiptID(RefID);
            _host.dgParcelDetail.DataBind();
        }

        public bool ExistentSupplement(string ID)
        {
            bool ExistSup = true;
            if (BI.ReturnSupCountByID(ID, UserInfo.UserId) == 0)
                ExistSup = false;
            return ExistSup;
        }

        public bool IsSendToFinancial(string ID, int UserID)
        {
            bool Result = true;
            try
            {
                Result = BI.IsSendToFinancialById(ID, UserID);
            }
            catch { }
            return Result;
        }

        public void ShowParcelDetail(string RefID)
        {
            _host.DivAllPage_visibale = true;
            //_host.divDetail_visible = true;
            _host.divReceiptDetail_visible = false;
            _host.divParcelDetail_visible = true;
            Load_dgParcelDetail(RefID);
        }
    }
}
