<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RollBackAcceptReceipt.ascx.cs"
    Inherits="ANP.COD.Forms.Financial.RollBackAcceptReceipt" %>
<%@ Register Src="../../Controls/AlertControl.ascx" TagPrefix="uc" TagName="AlertControl" %>
<link href="../../Content/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="../../Content/bootstrap-select.css" rel="stylesheet" type="text/css" />
<link href="../../Content/MyStyle.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="en">
    function test() {
        $("#<%=this.ddlState.ClientID%>").selectpicker();

        if ($('#<%=this.Date.ClientID%>') != null)
            $('#<%=this.Date.ClientID%>').MdPersianDateTimePicker({
                Placement: 'left',
                Trigger: 'focus',
                EnableTimePicker: false,
                TargetSelector: '#ctl11_Date',
                GroupId: 'group1',
                ToDate: false,
                FromDate: true,
                EnglishNumber: true,
                Disabled: false
            });

    }
</script>
<script type="text/javascript">
    function CheckAll_Approved(chk) {
        all = document.getElementsByTagName("input");
        for (i = 0; i < all.length; i++) {
            if (all[i].type == "checkbox" && all[i].id.indexOf("dgBarcodeList") > -1 && all[i].id.indexOf("chkHeaderSelect") > -1) {
                if (all[i].disabled == false)
                    all[i].checked = chk.checked;
            }
        }
    }   
</script>
<br />

<div class="container col-xs-12">
    <div class="panel panel-primary small">
        <div class="panel-heading" enableviewstate="True">
            تغییر وضعیت فیش های تایید شده توسط کارشناس استان
        </div>
        <div class="panel-body" style="margin: 0px 20px;">
            <div class="row">
                <div class="input-group  col-xs-11  " dir="rtl">
                    <uc:alertcontrol runat="server" id="ucAlertControl" />
                </div>
            </div>
            <div class="clearfix" />
            <div class="row col-xs-12">
                <div id="trFirstState" runat="server" class="input-group   col-xs-3 col-md-2  ">
                    <asp:Label ID="lblFirstState" Text="نام استان :" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:DropDownList ID="ddlState" runat="server" class="form-control input-sm selectpicker pull-right "
                        data-width="220px auto" data-style="btn" AutoPostBack="false" data-size="5" data-live-search="true" />
                </div>
                <div id="trFDate" runat="server" class="input-group  col-xs-3 col-md-2 col-lg-2" style="padding-bottom: 0px;">
                    <asp:Label ID="lblFdate" Text="تاریخ واریز فیش:" class=" pull-right " runat="server" />
                    <asp:TextBox runat="server" type="text" ID="Date" class="form-control" data-englishnumber="true"
                        data-TargetSelector="#ctl11_Date" data-GroupId="group1" data-FromDate="true"
                        data-MdDateTimePicker="true" value="۱۳۹۲/۰۱/۰۱" data-placement="left" />
                </div>
                <div runat="server" id="trShowButton" class="input-group  col-xs-1">
                    <asp:Button ID="btnShow" Text="نمایش" runat="server" Class="form-control input-sm btn btn-success btn-md" OnClick="btnShow_Click" />
                </div>
            </div>
            <div class="clearfix" />
            <div class="row">
                <div class="input-group col-xs-12" style="box-shadow: 1px 1px 15px #BBB; overflow: scroll;
                    height: 200px;">
                    <asp:DataGrid ID="dgReceiptList" runat="server" AutoGenerateColumns="False" CellPadding="3"
                        CssClass="grid" PageSize="20" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                        BorderWidth="1px" OnItemCommand="dgReceiptList_ItemCommand">
                        <Columns>
                            <asp:BoundColumn DataField="RowNum" HeaderText="ردیف " Visible="true"></asp:BoundColumn>
                            <asp:BoundColumn DataField="id" HeaderText="آی دی" Visible="false"></asp:BoundColumn>
                            <asp:BoundColumn DataField="IsPhish" HeaderText="آی دی نحوه پرداخت" Visible="false">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IsPhishTitle" HeaderText="نحوه پرداخت"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ReceiptSerialNo" HeaderText="سریال فیش/چک"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Seri" HeaderText="سری فیش/چک"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Price" HeaderText="مبلغ فیش /چک"></asp:BoundColumn>
                            <asp:BoundColumn DataField="BankName" HeaderText="نام بانک"></asp:BoundColumn>
                            <asp:BoundColumn DataField="PayerName" HeaderText="پرداخت کننده"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ChequeVajh" HeaderText="در وجه"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ChequeSaderKonandeh" HeaderText="صادر کننده"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ChequeAccountNo" HeaderText="شماره حساب"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ChequeComment" HeaderText="توضیحات چک"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="برگشت به حسابداری استان">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkChangeState" runat="server" CommandArgument='<%# Eval("id") %>'
                                        CommandName="ChangeState">تغییر وضعیت</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="توضیحات ">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDescription" runat="server" MaxLength="1000" TextMode="MultiLine"/>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="false" Font-Size="10pt" ForeColor="White"
                            HorizontalAlign="Center" />
                        <ItemStyle ForeColor="#000066" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    </asp:DataGrid>
                </div>
            </div>
            <br />
        </div>
    </div>
</div>
