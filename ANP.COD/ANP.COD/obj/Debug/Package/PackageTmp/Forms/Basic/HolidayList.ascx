<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HolidayList.ascx.cs"
    Inherits="ANP.COD.Forms.Basic.HolidayList" %>

<link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
<%@ Register Src="../../Controls/DateSelector.ascx" TagName="DateSelector" TagPrefix="uc1" %>

<br /><br /><br />
<table border="0" cellpadding="4px" cellspacing="0" width="455x" dir="rtl" align="center" class="table_shadow">
    <tr>
        <td align="left" style="vertical-align: middle; width:250px;">
        <br />
            <div style="float: right; display: block; width:110px;">
                <asp:Label ID="Label3" Text="تاریخ روز تعطیل : " runat="server" />
            </div>
            <div style="float: left; display: block; width:130px;">
                <uc1:DateSelector ID="MyDate" runat="server"  Width="100px" />
            </div>
        </td>
        <td align="left" style="vertical-align: middle;">
        </td>
    </tr>
    <tr>
        <td align="left" style="vertical-align: middle; width:250px;">
            <div style="float: right; display: block; width:110px;">
                <asp:Label ID="Label1" Text="توضیحات : " runat="server" />
            </div>
            <div style="float: left; display: block;  width:130px;">
                <asp:TextBox ID="txtDetail" Width="120px" runat="server" />
            </div>
        </td>
        <td align="center" style="width: 200px; height: 40px; vertical-align: middle;">
            <asp:Button ID="btnSave" Text="ذخیره" runat="server" Width="100px" OnClick="btnSave_Click" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
        <br />
            <div style="width: 100%; box-shadow: 1px 1px 15px #BBB; overflow:auto; height: 180px;">
                <asp:DataGrid ID="MyGrid" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    Width="100%" CssClass="grid" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                    BorderWidth="1px">
                    <ItemStyle ForeColor="#000066" />
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundColumn DataField="id" HeaderText="id" Visible="false"></asp:BoundColumn>
                        <asp:BoundColumn DataField="RowNum" HeaderText="ردیف"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Date" HeaderText="تاریخ"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Detail" HeaderText=" توضیحات "></asp:BoundColumn>
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
