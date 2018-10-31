<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowAllParcels_Old.ascx.cs"
    Inherits="ANP.COD.Forms.Exchange.ShowAllParcels_Old" %>

<link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
<%@ Register Src="../../Controls/DateSelector.ascx" TagName="DateSelector" TagPrefix="uc" %>

<div id="divDetail" runat="server" visible="false" style="border-style: none; border-color: inherit;
    opacity: 0.8; border-width: medium; z-index: 1100; display: block; margin: 0pt;
    padding: 0pt; width: 100%; height: 100%; top: 0pt; left: 0pt; background-color: #CCC;
    cursor:move; position: fixed; bottom: 708px;">
</div>
<br />
<br />
<table border="0" cellpadding="4px" cellspacing="0" width="90%" dir="rtl" align="center"
    class="table_shadow">
    <tr>
        <td style="vertical-align: middle; width: 340px;">
            <div style="float: right; display: block; width: 90px;">
                <asp:Label Text="وضعیت مرسوله : " runat="server" />
            </div>
            <div style="float: right; display: block; width: 240px;">
                <asp:DropDownList ID="ddlStatus" Style="direction: rtl; width: 235px; text-align: right;"
                    runat="server" />
            </div>
        </td>
        <td align="left" style="vertical-align: middle; width: 170px;">
            <div style="float: right; display: block; width: 40px;">
                <asp:Label Text="از تاریخ : " runat="server" />
            </div>
            <div style="float: left; display: block; width: 130px;">
                <uc:DateSelector ID="Fdate" Width="125px" runat="server" />
            </div>
        </td>
        <td align="left" style="vertical-align: middle; width: 170px;">
            <div style="float: right; display: block; width: 40px;">
                <asp:Label ID="Label1" Text="تا تاریخ : " runat="server" />
            </div>
            <div style="float: left; display: block; width: 130px;">
                <uc:DateSelector ID="Ldate" Width="125px" runat="server" />
            </div>
        </td>
        <td align="center" style="width: 150px; height: 40px; vertical-align: middle;">
            <asp:Button ID="btnSearch" Text="نمایش" runat="server" Width="100px" OnClick="btnSearch_Click" />
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td colspan="5">
            <div style="width: 98%; box-shadow: 1px 1px 15px #BBB; overflow: scroll; height: 255px;
                margin: 1%;">
                <asp:DataGrid ID="MyGrid" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    HeaderStyle-Height="10px" AllowSorting="true" Width="100%" CssClass="grid" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnItemCommand="MyGrid_ItemCommand">
                    <ItemStyle ForeColor="#000066" Wrap="false" Height="10px" />
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Height="30px" />
                    <Columns>
                        <asp:BoundColumn DataField="RowNum" HeaderText="ردیف"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ID" HeaderText="id" Visible="false"></asp:BoundColumn>
                        <asp:BoundColumn DataField="PostNode" HeaderText="PostNode" Visible="false"></asp:BoundColumn>
                        <asp:BoundColumn DataField="UserID" HeaderText="UserID" Visible="false"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Barcode" HeaderText="بارکد"></asp:BoundColumn>
                        <asp:BoundColumn DataField="StatusID" HeaderText="ای دی وضعیت مرسوله" Visible="false" />
                        <asp:BoundColumn DataField="StatusTitle" HeaderText="وضعیت مرسوله"></asp:BoundColumn>
                        <asp:BoundColumn DataField="StatusChangeDate" HeaderText=" تاریخ تغییر وضعیت "></asp:BoundColumn>
                        <%--<asp:TemplateColumn HeaderText="جزئیات">
                            <ItemTemplate>
                                <asp:LinkButton ID="lblDetail" runat="server" CommandArgument='<%# Eval("ID") %>'
                                    CommandName="Detail" ForeColor="Black" Text="نمایش" />
                            </ItemTemplate>
                        </asp:TemplateColumn>--%>
                    </Columns>
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                    <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                </asp:DataGrid>
                <br />
            </div>
            <br />
        </td>
    </tr>
    <tr>
        <td colspan="5">
            <div id="divDetail2" visible="false" runat="server" style="z-index: 1102; display: block;
                position: fixed; padding: 0px; margin: 0px; width: 72%; height: auto; top: 30%;
                left: 14%; direction: rtl; color: Blue; border-width: 1px; border-style: solid;
                border-color: gray; background-color: #FFF; text-align: center; font-family: BYekan;
                font-size: 9pt; overflow:scroll;">
                <asp:DataGrid ID="MyDetailGrid" runat="server" AutoGenerateColumns="False" CssClass="grid"
                    Width="100%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                    CellPadding="3">
                    <ItemStyle ForeColor="#000066" />
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundColumn DataField="id" HeaderText="id " Visible="false"></asp:BoundColumn>
                        <asp:BoundColumn DataField="RowNum" HeaderText="ردیف "></asp:BoundColumn>
                        <asp:BoundColumn DataField="Barcode" HeaderText=" شماره بارکد"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Status" HeaderText="آی دی وضعیت " Visible="false"></asp:BoundColumn>
                        <asp:BoundColumn DataField="StatusTitle" HeaderText="وضعیت"></asp:BoundColumn>
                        <asp:BoundColumn DataField="UserID" HeaderText="UserID" Visible="false"></asp:BoundColumn>
                        <asp:BoundColumn DataField="PostNode" HeaderText="PostNode" Visible="false"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DateStatus" HeaderText=" تاریخ تغییر وضعیت "></asp:BoundColumn>
                    </Columns>
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                    <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                </asp:DataGrid>
                <br />
                <asp:Button ID="btnReturn" Text="بازگشت" runat="server" Style="margin-right: 0px"
                    Font-Names="byekan" Font-Size="9pt" Width="80px" OnClick="btnReturn_Click" />
                <br />
            </div>
        </td>
    </tr>
</table>
