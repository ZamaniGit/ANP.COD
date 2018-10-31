<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LstReceiptInfo.ascx.cs" Inherits="ANP.COD.Forms.Financial.LstReceiptInfo" %>
<br />
<table cellspacing="0" cellpadding="0" style="border: 0; width: 100%;">
    
    <tr>
        <td align="center" style="background-color: #FFF;">
            <asp:Label ID="Label1" Text="جستجو بر اساس شماره فیش : " runat="server" 
                Font-Names="byekan" Font-Size="12px" />
            &nbsp;&nbsp;
            <asp:TextBox ID="txt_ReceiptInfo" runat="server" Width="120px"></asp:TextBox> 
            <asp:Button ID="btn_Search" runat="server" Text="جستجو" 
                onclick="btn_Search_Click" />
        </td>
    </tr>
    <tr>
        <td align="center" style="width: 100%; height: 350px; vertical-align: top;">
            <br />
            <div style="overflow: scroll; box-shadow: 1px 1px 15px #BBB; position: relative;
                height: 350px; width: 98%; min-height: 350px;">
                <asp:UpdatePanel runat="server" UpdateMode="Always" ID="upg">
                    <ContentTemplate>
                        <asp:DataGrid ID="MyGrid" runat="server" AutoGenerateColumns="False" CellPadding="3"
                            PageSize="20" 
                            CssClass="grid" 
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                            <Columns>
                                <asp:BoundColumn DataField="id" HeaderText="id " Visible="false"></asp:BoundColumn>
                                <asp:BoundColumn DataField="RowNum" HeaderText="ردیف"></asp:BoundColumn>
                                <asp:BoundColumn DataField="ReceiptNo" HeaderText="شماره فیش "></asp:BoundColumn>
                                <asp:BoundColumn DataField="BankName" HeaderText="نام بانک "></asp:BoundColumn>
                                <asp:BoundColumn DataField="TotalPrice" HeaderText="ج.م اصلی و متمم"></asp:BoundColumn>
                                <asp:BoundColumn DataField="PayerName" HeaderText="پرداخت کننده "></asp:BoundColumn>
                                <asp:BoundColumn DataField="PayDate" HeaderText="تاریخ واریز"></asp:BoundColumn>

                                 <asp:BoundColumn DataField="InsertDate_SH" HeaderText="تاریخ درج در سامانه"></asp:BoundColumn>
                                  <asp:BoundColumn DataField="InsertTime" HeaderText="ساعت درج در سامانه"></asp:BoundColumn>

                                <asp:BoundColumn DataField="ParcelCount" HeaderText="تعداد مرسوله"></asp:BoundColumn>
                                <asp:BoundColumn DataField="ReceiptType" HeaderText="نوع فیش"></asp:BoundColumn>
                                <asp:BoundColumn DataField="ReceiptState" HeaderText="وضعیت فیش"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Description" HeaderText="توضیحات"></asp:BoundColumn>                                
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <ItemStyle ForeColor="#000066" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                            <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        </asp:DataGrid>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </td>
    </tr>
</table>