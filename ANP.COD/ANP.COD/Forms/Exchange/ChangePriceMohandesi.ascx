<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChangePriceMohandesi.ascx.cs"
    Inherits="ANP.COD.Forms.Exchange.ChangePriceMohandesi" %>
<%@ Register Src="../../Controls/AlertControl.ascx" TagPrefix="uc" TagName="AlertControl" %>
<link href="../../Content/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="../../Content/bootstrap-select.css" rel="stylesheet" type="text/css" />
<link href="../../Content/MyStyle.css" rel="stylesheet" type="text/css" />


<div class="container-fluid col-xs-12 col-sm-12 col-md-12 col-lg-12">
    <div class="panel panel-primary hidden-xs small">
        <div class="panel-heading">
            ویرایش مرسوله
        </div>
        <div class="panel-body ">
            <div class="row col-xs-12 col-sm-pull-1">
                <div class="input-group col-xs-10" dir="ltr">
                    <uc:AlertControl runat="server" ID="ucAlertControl" />
                </div>
            </div>
            <div class="row col-xs-12 col-sm-pull-1">
                <div class="input-group col-xs-6 col-sm-4 col-md-3 col-lg-3 " dir="ltr">
                    <asp:Label ID="Label11" Text="بارکد" ForeColor="Red" class=" pull-right" runat="server" />
                    <asp:TextBox ID="txtBarcode" runat="server" class="form-control input-sm" Style="text-align: center;"
                        placeholder="بارکد را وارد کنید" />
                </div>
                <div id="div4" runat="server" class="input-group col-xs-6 col-sm-4 col-md-3 col-lg-3 "
                    dir="rtl">
                    <asp:Button ID="btnSearch" OnClick="btnSearch_Click" CssClass="btn btn-success btn-md "
                        runat="server" Text="جستجو" />
                </div>
            </div>
            <div class="row col-xs-12 col-sm-pull-1">
                <div class="input-group col-xs-6 col-sm-4 col-md-3 col-lg-3 " dir="rtl">
                    <asp:Label ID="Label12" Text="ح.س.پست" class=" pull-right" runat="server" />
                    <asp:TextBox ID="txtPostPrice" runat="server" class="form-control input-sm" Style="text-align: center;"
                        placeholder="مبلغ ح.س.پست" />
                </div>
                <div class="input-group col-xs-6 col-sm-4 col-md-3 col-lg-3 " dir="rtl">
                    <asp:Label ID="Label3" Text="ح.س.ط. قرارداد" runat="server" class=" pull-right" />
                    <asp:TextBox ID="txtCustomerPrice" runat="server" class="form-control input-sm" Style="text-align: center;"
                        placeholder="ح.س.ط. قرارداد" />
                </div>
                <div class="input-group col-xs-6 col-sm-4 col-md-2 col-lg-2 " dir="rtl">
                    <asp:Label ID="Label13" Text="مالیات" runat="server" class=" pull-right" />
                    <asp:TextBox ID="txtVattax" runat="server" class="form-control input-sm" Style="text-align: center;"
                        placeholder="مبلغ مالیات" />
                </div>
                <div class="input-group col-xs-6 col-sm-4 col-md-1 col-lg-1 " dir="rtl">
                    <asp:Button ID="btnSave" Text="ذخیره" runat="server" OnClick="btnSave_Click" CssClass="btn btn-success btn-md " />
                </div>
                <br />
            <br />
            </div>
            <div dir="rtl" style="width: 100%; box-shadow: 1px 1px 15px #BBB; overflow: auto;
                height: 70px;">
                <asp:DataGrid ID="MyGrid" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    Width="100%" PageSize="20" Height="50px" OnItemCommand="MyGrid_ItemCommand" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnItemDataBound="MyGrid_ItemDataBound">
                    <Columns>
                        <asp:BoundColumn DataField="RowNum" HeaderText="ردیف"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ID" HeaderText="id" Visible="false"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Barcode" HeaderText="بارکد"></asp:BoundColumn>
                        <asp:BoundColumn DataField="GenerateBarcodeDate" HeaderText="تاریخ قبول مرسوله" />
                        <asp:BoundColumn DataField="LocalStart" HeaderText="مبدا" />
                        <asp:BoundColumn DataField="LocalEnd" HeaderText="مقصد" />
                        <asp:BoundColumn DataField="PostalCost" HeaderText="ح.س پست"></asp:BoundColumn>
                        <asp:BoundColumn DataField="CustomerCost" HeaderText="ح.س.ط قرارداد"></asp:BoundColumn>
                        <asp:BoundColumn DataField="VatTax" HeaderText="مالیات"></asp:BoundColumn>
                        <asp:BoundColumn DataField="AllPrice" HeaderText="جمع کل"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Deleted" HeaderText="حذف شده" Visible="false"></asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="ویرایش" HeaderStyle-Font-Size="12px">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnk_Delete" runat="server" CommandArgument='<%# Eval("Id") %>'
                                    Text="حذف" CommandName="Delete" />
                                <asp:Label ID="lbl_DontDel" Text="غیر قابل حذف" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" ForeColor="White" Font-Bold="false" Font-Size="14px"
                        HorizontalAlign="Center" Wrap="false" />
                    <ItemStyle ForeColor="#000066" Font-Names="BYekan" Font-Bold="false" Font-Size="12px"
                        HorizontalAlign="Center" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                    <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                </asp:DataGrid>
            </div>
        </div>
    </div>
</div>
