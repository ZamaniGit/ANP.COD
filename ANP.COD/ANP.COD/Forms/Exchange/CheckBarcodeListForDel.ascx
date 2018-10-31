<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CheckBarcodeListForDel.ascx.cs"
    Inherits="ANP.COD.Forms.Exchange.CheckBarcodeListForDel" %>
<%@ Register Src="../../Controls/AlertControl.ascx" TagPrefix="uc" TagName="AlertControl" %>
<link href="../../Content/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="../../Content/bootstrap-toggle.min.css" rel="stylesheet" type="text/css" />
<script src="../../Scripts/bootstrap-toggle.min.js" type="text/javascript"></script>
<link href="../../Content/MyStyle.css" rel="stylesheet" type="text/css" />
<div class="container col-xs-12">
    <div class="panel panel-primary hidden-xs small">
        <div class="panel-heading">
            بررسی درخواست حذف مرسولات
        </div>
        <div class="panel-body ">
            <div class="row col-xs-12 ">
                <div class="input-group col-xs-9" dir="ltr">
                    <uc:AlertControl runat="server" ID="ucAlertControl" />
                </div>
                <div class="col-xs-4 form-inline small hidden" >
                    <a>محدودیت</a>
                    <input checked="checked" data-toggle="toggle" data-style="slow" type="checkbox" class=" col-xs-1" />

                    <a>حالت دستی</a>
                    <input checked="checked" data-toggle="toggle" data-style="slow" type="checkbox" class=" col-xs-1" />
                </div>
            </div>
            <br />
            <div class="row col-xs-12 ">
                <br />
                <div style="overflow: scroll; box-shadow: 1px 1px 15px #BBB; position: relative;
                    height: 300px; width: 100%; min-height: 100px;">
                    <asp:DataGrid ID="dgBarcodeList" runat="server" AutoGenerateColumns="False" CellPadding="3"
                        Width="100%" CssClass="grid" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                        BorderWidth="1px" OnItemCommand="dgBarcodeList_ItemCommand">
                        <ItemStyle ForeColor="#000066" />
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundColumn DataField="RowNum" HeaderText="ردیف"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Barcode" HeaderText="بارکد"></asp:BoundColumn>
                            <asp:BoundColumn DataField="FirstStateName" HeaderText="مبدا"></asp:BoundColumn>
                            <asp:BoundColumn DataField="LastStateName" HeaderText="مقصد"></asp:BoundColumn>
                            <asp:BoundColumn DataField="EntryDate" HeaderText="تاریخ قبول"></asp:BoundColumn>
                            <asp:BoundColumn DataField="StatusTitle" HeaderText="آخرین وضعیت"></asp:BoundColumn>
                            <asp:BoundColumn DataField="StatusDate" HeaderText="تاریخ آخرین وضعیت"></asp:BoundColumn>
                            <asp:BoundColumn DataField="CommentUser" HeaderText="توضیحات"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="ویرایش">
                                <ItemTemplate>
                                    <div>
                                    </div>
                                    <div class="btn-group btn-group-xs center-block" role="group">
                                        <asp:Button ID="btnAccept" CommandName="btnAccept" CommandArgument='<%# Eval("Barcode") %>'
                                            runat="server" type="button" Text="تایید" class="btn btn-xs btn-success col-xs-5"
                                            Style="margin: 3px; padding: 3px;" />
                                        <asp:Button ID="btnDeny" CommandName="btnDeny" CommandArgument='<%# Eval("Barcode") %>'
                                            runat="server" type="button" Text="کنسل " class="btn btn-xs btn-danger col-xs-5"
                                            Style="margin: 3px; padding: 3px;" />
                                    </div>
                                    <asp:TextBox ID="txtComment" runat="server" ToolTip="توضیحات" TextMode="MultiLine"
                                        CssClass="col-xs-12 " Style="resize: none; margin: 0px; padding: 1px;" MaxLength="2000" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    </asp:DataGrid>
                </div>
            </div>
        </div>
    </div>
</div>
