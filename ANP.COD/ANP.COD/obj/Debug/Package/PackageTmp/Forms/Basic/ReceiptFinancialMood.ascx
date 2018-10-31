<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReceiptFinancialMood.ascx.cs" 
    Inherits="ANP.COD.Forms.Basic.ReceiptFinancialMood" %>

<link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
<%@ Register Src="../../Controls/DateSelector.ascx" TagName="DateSelector" TagPrefix="uc" %>
<br /><br /><br />
<table border="0" cellpadding="4px" cellspacing="0" width="400x" dir="rtl" align="center" class="table_shadow">
    <tr>
        <td align="left" style="vertical-align: middle; width:245px;">
    <br />
            <div style="float: right; display: block; width:85px;">
                <asp:Label ID="Label1" Text="علت عدم تایید : " runat="server" style=" margin-top:1px; " />
            </div>
            <div style="float: left; display: block;  width:145px;">
                <asp:TextBox ID="txtDetail" Width="140px" runat="server" style="padding:3px 8px 3px 8px;" />
            </div>
        </td>
        <td align="center" style="width: 145px; height: 40px; vertical-align: middle;">
    <br />
            <asp:Button ID="btnSave" Text="ذخیره" runat="server" Width="100px" OnClick="btnSave_Click" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
        <br />
            <div style="width: 100%; box-shadow: 1px 1px 15px #BBB; overflow:auto; height: 140px;">
                <asp:DataGrid ID="MyGrid" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    Width="100%" CssClass="grid" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                    BorderWidth="1px">
                    <ItemStyle ForeColor="#000066" />
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundColumn DataField="RowNum" HeaderText="ردیف"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Value" HeaderText="ارزش" Visible="false"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Title" HeaderText=" عنوان "></asp:BoundColumn>
                    </Columns>
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                    <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                </asp:DataGrid>
                <br />
            </div>
            <br />
        </td>
    </tr>
</table>
