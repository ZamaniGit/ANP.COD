<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BankReceiptEditation.ascx.cs"
    Inherits="ANP.COD.Forms.Financial.BankReceiptEditation" %>

<%@ Register Src="../../Controls/AlertControl.ascx" TagPrefix="uc" TagName="AlertControl" %>
<link href="../../Content/bootstrap.css" rel="stylesheet" type="text/css" />

<div class="container col-xs-12">
    <div class="panel panel-primary hidden-xs small">
        <div class="panel-heading">
            ویرایش فیش و چک
        </div>
        <div class="panel-body ">
            <div class="row col-sm-12">
                <div class="input-group col-xs-12" dir="ltr">
                    <uc:AlertControl runat="server" ID="lblMessage" />
                </div>
            </div>
            <br />
            <div class="row col-sm-12 ">
                <br />
                <div style="overflow: scroll; box-shadow: 1px 1px 15px #BBB; position: relative;
                    height: 300px; width: 100%; min-height: 100px;">
                    <asp:DataGrid ID="MyGrid" runat="server" AutoGenerateColumns="False" CellPadding="3" Width="100%"
                        OnItemCommand="MyGrid_ItemCommand" OnItemDataBound="MyGrid_ItemDataBound" CssClass="grid"
                        OnDataBinding="MyGrid_DataBinding" OnSelectedIndexChanged="MyGrid_SelectedIndexChanged"
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <ItemStyle ForeColor="#000066" />
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundColumn DataField="id" HeaderText="id " Visible="false"></asp:BoundColumn>
                            <asp:BoundColumn DataField="RowNum" HeaderText="ردیف"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ReceiptNo" HeaderText="شماره فیش "></asp:BoundColumn>
                            <asp:BoundColumn DataField="BankName" HeaderText="نام بانک "></asp:BoundColumn>
                            <asp:BoundColumn DataField="Price" HeaderText="مبلغ فیش"></asp:BoundColumn>
                            <asp:BoundColumn DataField="PayerName" HeaderText="پرداخت کننده "></asp:BoundColumn>
                            <asp:BoundColumn DataField="PayDate" HeaderText="تاریخ واریز"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ParcelCount" HeaderText="تعداد مرسوله"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ReceiptType" HeaderText="نوع فیش"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ReceiptState" HeaderText="وضعیت فیش"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Description" HeaderText="توضیحات"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="ویرایش">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblSupplementReceipt" runat="server" CommandArgument='<%# Eval("id") %>'
                                        CommandName="Edit">ویرایش</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="حذف">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblReceiptEdit" runat="server" CommandArgument='<%# Eval("id") %>'
                                        CommandName="Del">حذف</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    </asp:DataGrid>
                </div>
            </div>
            <div class="row col-xs-6 col-md-4 col-sm-pull-3 col-md-pull-4">
                <div class="input-group col-xs-12 " dir="ltr">
                    <asp:Button ID="btnCancel" runat="server" Text="ارسال به امور مالی" CssClass="btn btn-success btn-md "
                        OnClick="btnCancel_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnBack" runat="server" CssClass="btn btn-success btn-md " Text="بازگشت"
                        OnClick="btnBack_Click" />
                </div>
            </div>
        </div>
    </div>
</div>
