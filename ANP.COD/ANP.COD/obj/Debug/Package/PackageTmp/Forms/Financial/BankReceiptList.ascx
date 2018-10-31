<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BankReceiptList.ascx.cs"
    Inherits="ANP.COD.Forms.Financial.BankReceiptList" %>
<link href="../../Content/MyStyle.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="en">

    function test() {
        $("#<%=this.ddlReceiptState.ClientID%>").selectpicker();

        $("#<%=this.Fdate.ClientID%>").MdPersianDateTimePicker({
            Placement: 'left', 
            Trigger: 'focus', 
            EnableTimePicker: false,
            TargetSelector: '', 
            GroupId: '',
            ToDate: false, 
            FromDate: false, 
            EnglishNumber: true,
            Disabled: false
            } );

        $("#<%=this.Ldate.ClientID%>").MdPersianDateTimePicker({
            Placement: 'left', 
            Trigger: 'focus', 
            EnableTimePicker: false,
            TargetSelector: '', 
            GroupId: '',
            ToDate: false, 
            FromDate: false, 
            EnglishNumber: true,
            Disabled: false
            } );
    }
    
    function printer(_div) {
        var prtContent = document.getElementById(_div);
        var WinPrint = window.open('', '', 'left=0,top=0,width=1000,height=900,toolbar=0,scrollbars=0,status=0');
//        prtContent.style.direction =  "rtl";
        WinPrint.document.write(prtContent.innerHTML);
        WinPrint.document.dir = "rtl";
        WinPrint.document.close();
        WinPrint.focus();
        WinPrint.print();
        WinPrint.close();
    }
</script>
<div id="DivAllPage" runat="server" visible="false" style="border-style: none; opacity: 0.8;
    border-width: medium; z-index: 1100; display: block; margin: 0pt; padding: 0pt;
    width: 100%; height: 100%; top: 0pt; left: 0pt; background-color: #CCC; cursor: move;
    position: fixed; bottom: 708px;">
</div>
<div class="container-fluid col-xs-12 hidden-xs small">
    <div class="row col-sm-12">
        <div class="input-group col-xs-12" dir="rtl" style="text-align: center;">
            <span style="height: 50px; text-align: center;">
                <asp:Label ID="lblAlert" Text="" runat="server" Font-Size="16" ForeColor="#CC0000" />
            </span>
        </div>
        <br />
    </div>
    <div class="row col-xs-10 col-xs-pull-1 col-xs-push-1 " style="border-width: 0.1px;
        border-color: #F0F0F0; border-style: solid; border-radius: 5px;">
        <div class="input-group col-xs-5 col-md-2" dir="ltr" style="margin: 0px 5px;">
            <asp:Label ID="Label2" Text="از تاریخ" class=" pull-right" runat="server" />
            <asp:TextBox runat="server" type="text" ID="Fdate" class="form-control" data-englishnumber="true"
                data-MdDateTimePicker="true" value="۱۳۹۲/۰۱/۰۱" data-placement="left" />
        </div>
        <div class="input-group col-xs-5 col-md-2" dir="ltr" style="margin: 0px 5px;">
            <asp:Label ID="Label3" Text="تا تاریخ" class=" pull-right" runat="server" />
            <asp:TextBox runat="server" type="text" ID="Ldate" class="form-control" data-englishnumber="true"
                data-MdDateTimePicker="true" value="۱۳۹۲/۰۱/۰۱" data-placement="left" />
        </div>
        <div class="input-group col-xs-10 col-sm-10 col-md-3" dir="ltr">
            <asp:Label ID="Label1" Text="وضعیت" class=" pull-right" runat="server" />
            <asp:DropDownList ID="ddlReceiptState" runat="server" class="form-control input-sm selectpicker  "
                data-size="6" />
        </div>
        <div class="input-group col-xs-10 col-sm-10 col-md-2" dir="ltr">
            <asp:Button ID="btnShow" CssClass="btn btn-primary" Text="نمایش" runat="server" AccessKey="S"
                OnClick="btnShow_Click" />
        </div>
    </div>
    <div class="row col-sm-12">
        <br />
        <div dir="rtl" style="width: 100%; overflow: auto; height: 50px auto; max-height: 350px;">
            <asp:DataGrid ID="MyGrid" runat="server" AutoGenerateColumns="False" CellPadding="3"
                CssClass="grid" PageSize="20" BackColor="White" OnItemCommand="MyGrid_ItemCommand"
                OnItemDataBound="MyGrid_ItemDataBound">
                <Columns>
                    <asp:BoundColumn DataField="id" HeaderText="id " Visible="false"></asp:BoundColumn>
                    <asp:BoundColumn DataField="RowNum" HeaderText="ردیف"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ReceiptSerialNo" HeaderText="سریال فیش/چک"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ReceiptSeri" HeaderText="سری فیش/چک"></asp:BoundColumn>
                    <asp:BoundColumn DataField="BankName" HeaderText="نام بانک "></asp:BoundColumn>
                    <asp:BoundColumn DataField="Price" HeaderText="م.ف اصلی"></asp:BoundColumn>
                    <asp:BoundColumn DataField="TotalPrice" HeaderText="ج.م اصلی و متمم" Visible="false" />
                    <asp:BoundColumn DataField="PayerName" HeaderText="پرداخت کننده "></asp:BoundColumn>
                    <asp:BoundColumn DataField="PayDate" HeaderText="تاریخ واریز"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ParcelCount" HeaderText="تعداد مرسوله"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ReceiptType" HeaderText="نوع فیش"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ReceiptState" HeaderText="وضعیت فیش"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Description" HeaderText="توضیحات"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ParentReceiptSerialNo" HeaderText="ش.ف متمم" Visible="false" />
                    <asp:BoundColumn DataField="RefID" HeaderText="شماره مرجع" Visible="false"></asp:BoundColumn>
                    <asp:TemplateColumn HeaderText="جزئیات فیش/چک">
                        <ItemTemplate>
                            <asp:LinkButton ID="lblReceiptDetail" Font-Size="8pt" runat="server" ForeColor="Black"
                                CommandArgument='<%# Eval("id") %>' CommandName="ReceiptDetail">نمایش فیش/چک</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="جزئیات مرسوله">
                        <ItemTemplate>
                            <asp:LinkButton ID="lblParcelDetail" Font-Size="8pt" ForeColor="Black" runat="server"
                                CommandArgument='<%# Eval("id") %>' CommandName="ParcelDetail">نمایش مرسوله</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="وضعیت ارسال">
                        <ItemTemplate>
                            <asp:LinkButton ID="lblOkSend" runat="server" CommandArgument='<%# Eval("id") %>'
                                CommandName="Send" ForeColor="Black" Text="آماده ارسال" Visible="false"></asp:LinkButton>
                            <asp:Label ID="lblNotSave" Text="عدم تایید نهایی فیش" runat="server" Visible="false" />
                            <asp:Label ID="lblNokSend" Text="غیرقابل ارسال" runat="server" Visible="false" />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="ApproveFlag" HeaderText="فلگ حالت مرسوله" Visible="false" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#D9EDF7" Font-Bold="false" ForeColor="Black" HorizontalAlign="Center" />
                <ItemStyle ForeColor="#000066" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                <SelectedItemStyle BackColor="#669999" Font-Bold="false" ForeColor="White" />
            </asp:DataGrid></div>
    </div>
    <%--    <div class="row col-sm-12" id="divDetail" runat="server" visible="false"  style="z-index: 1102;
            display: block; position: fixed; padding: 0px; margin: 0px; height: 300px auto; top: 25%;
            overflow: auto; left: 5%; direction: rtl; color: Blue; border-width: 1px; border-style: solid;
            border-color: gray; background-color: #FFF; text-align: center; font-family: BYekan;
            font-size: 9pt;">--%>
    <div class="row col-sm-12">
        <div id="divReceiptDetail" visible="false" runat="server" style="z-index: 1103; display: block;
            position: fixed; padding: 0px; margin: 0px; height: 10px auto; max-height: 300px;
            top: 20%; width: 80%; left: 10%; direction: rtl; color: Blue; border-width: 0px;
            background-color: #D6D6D6; text-align: center;">
            <div style="width: 98%; box-shadow: 0.1px 0.1px 2px #BBB; overflow: auto; height: 10px auto;
                max-height: 250px; margin: 1%;">
                <div id="ReceiptPrint">
                    <asp:DataGrid ID="dgReceiptDetail" runat="server" AutoGenerateColumns="False" CssClass="grid"
                        Width="100%" OnItemCommand="dgDetail_ItemCommand" OnItemDataBound="dgDetail_ItemDataBound"
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                        CellPadding="3">
                        <ItemStyle ForeColor="#000066" />
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundColumn DataField="RowNum" HeaderText="ردیف "></asp:BoundColumn>
                            <asp:BoundColumn DataField="id" HeaderText="آی دی" Visible="false"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ReceiptSerialNo" HeaderText="سریال فیش/چک"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Seri" HeaderText="سری فیش/چک"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Price" HeaderText="مبلغ فیش "></asp:BoundColumn>
                            <asp:BoundColumn DataField="BankName" HeaderText="نام بانک"></asp:BoundColumn>
                            <asp:BoundColumn DataField="PayerName" HeaderText="پرداخت کننده"></asp:BoundColumn>
                            <asp:BoundColumn DataField="PayDate" HeaderText="تاریخ پرداخت"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ReceiptType" HeaderText="نوع فیش"></asp:BoundColumn>
                            <asp:BoundColumn DataField="UpdateCount" HeaderText="تعداد ویرایشات" Visible="false" />
                            <asp:BoundColumn DataField="IsSupplementReceipt" HeaderText="فیش متمم می باشد" Visible="false" />
                            <asp:TemplateColumn HeaderText="ویرایش">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblReceiptEdit" ForeColor="Black" runat="server" CommandArgument='<%# Eval("id") %>'
                                        CommandName="Edit">ویرایش</asp:LinkButton>
                                    <asp:Label ID="lblDontReceiptEdit" Text="غیر قابل ویرایش" runat="server" Visible="false" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="ثبت متمم">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblSupReceipt" ForeColor="Black" runat="server" CommandArgument='<%# Eval("id") %>'
                                        CommandName="Sup">فیش متمم</asp:LinkButton>
                                    <asp:Label ID="lbl_SupReceipt" Text="فیش متمم دارد" runat="server" Visible="false" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="OrginalReceipt" HeaderText="فیش ح.س پست است" Visible="false" />
                            <asp:BoundColumn DataField="ReceiptTypeID" HeaderText="نوع فیش" Visible="false" />
                        </Columns>
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    </asp:DataGrid>
                </div>
                <br />
                <asp:Button ID="btnDetail" runat="server" CssClass="btn btn-success btn-md " Text="بازگشت"
                    Style="margin-right: 0px" Font-Names="byekan" Font-Size="9pt" Width="80px" OnClick="btnDetail_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" Text="چاپ" runat="server" CssClass="btn btn-info btn-md "
                    Style="margin-right: 0px" Font-Names="byekan" Font-Size="9pt" Width="80px" OnClientClick="printer('ReceiptPrint')" />
            </div>
        </div>
        <div id="divParcelDetail" visible="false" runat="server" style="z-index: 1103; display: block;
            position: fixed; padding: 0px; margin: 0px; height: 10px auto; max-height: 300px;
            top: 20%; width: 80%; left: 10%; direction: rtl; color: Blue; border-width: 0px;
            background-color: #D6D6D6; text-align: center;">
            <div id="BarcodePrint" style="width: 98%; box-shadow: 0.1px 0.1px 2px #BBB; overflow: auto;
                height: 10px auto; max-height: 250px; margin: 1%;">
                <asp:DataGrid ID="dgParcelsDetail" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    CssClass="grid" PageSize="20" BackColor="White" OnItemDataBound="dgParcelsDetail_ItemDataBound">
                    <Columns>
                        <asp:BoundColumn DataField="id" HeaderText="id " Visible="false"></asp:BoundColumn>
                        <asp:BoundColumn DataField="RowNum" HeaderText="ردیف "></asp:BoundColumn>
                        <asp:BoundColumn DataField="Barcode" HeaderText=" شماره بارکد"></asp:BoundColumn>
                        <asp:BoundColumn DataField="SourceCode" HeaderText="مبدا "></asp:BoundColumn>
                        <asp:BoundColumn DataField="DestCode" HeaderText="مقصد"></asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryDate" HeaderText="تاریخ درج"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ServiceType" HeaderText="نوع سرویس"></asp:BoundColumn>
                        <asp:BoundColumn DataField="PostalCost" HeaderText="ح.س پست"></asp:BoundColumn>
                        <asp:BoundColumn DataField="VatTax" HeaderText="مالیات"></asp:BoundColumn>
                        <asp:BoundColumn DataField="CustomerCost" HeaderText="ح.ط قرارداد"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Price" HeaderText="قیمت"></asp:BoundColumn>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#D9EDF7" Font-Bold="false" ForeColor="Black" HorizontalAlign="Center" />
                    <ItemStyle ForeColor="#000066" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                    <SelectedItemStyle BackColor="#669999" Font-Bold="false" ForeColor="White" />
                </asp:DataGrid>
                <br />
                <div style="background-color: #FEFDFD; border-width: 0.1px; border-color: #337AB7;
                    border-style: solid; borderadius: 5px; padding: 5px; height: 30px;">
                    <asp:Label ID="Label4" Text="جمع ح.س پست" runat="server" CssClass="col-xs-1" ForeColor="Red" />
                    <asp:Label ID="lblPostalCost" Text="0" runat="server" CssClass="col-xs-2" Style="text-align: right;
                        color: Red; font-size: 14;" />
                    <asp:Label ID="Label5" Text="جمع مالیات" runat="server" CssClass="col-xs-1" ForeColor="Red" />
                    <asp:Label ID="lblVattax" Text="0" runat="server" Style="text-align: right; color: Red;
                        font-size: 14;" CssClass="col-xs-2" />
                    <asp:Label ID="Label6" Text="جمع ح.س.ط قرارداد" runat="server" CssClass="col-xs-1"
                        ForeColor="Red" />
                    <asp:Label ID="lblCostumerCost" Text="0" runat="server" Style="text-align: right;
                        color: Red; font-size: 14;" CssClass="col-xs-2" />
                    <asp:Label ID="Label7" Text="جمع کل" runat="server" CssClass="col-xs-1" ForeColor="Red" />
                    <asp:Label ID="lblAllPrice" Text="0" runat="server" Style="text-align: right; color: Red;
                        font-size: 14;" CssClass="col-xs-2" />
                </div>
            </div>
            <br />
            <asp:Button ID="btnParcelDetail" runat="server" CssClass="btn btn-success btn-md "
                Text="بازگشت" Style="margin-right: 0px" Font-Names="byekan" Font-Size="9pt" Width="80px"
                AccessKey="R" OnClick="btnDetail_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" Text="چاپ" runat="server" CssClass="btn btn-info btn-md "
                Style="margin-right: 0px" Font-Names="byekan" Font-Size="9pt" Width="80px" OnClientClick="printer('BarcodePrint')" />
            <br />
            <br />
        </div>
        <%-- </div>--%>
    </div>
    <br />
    <%--    <div class="row col-sm-12" style="height: 20px;">
        <div class="input-group col-xs-12" style="background-color: #FEFDFD; border-width: 0.1px;
            border-color: #337AB7; border-style: solid; border-radius: 5px; padding: 5px;">
            <asp:Label ID="lable15" Text="ح.س.پست:" runat="server" CssClass="col-sm-1" ForeColor="Red" />
            <asp:Label ID="lblSumPostal" Text="0" runat="server" ForeColor="Red" CssClass="col-sm-2" />
            <asp:Label ID="Label7" Text="ط.قرارداد:" runat="server" CssClass="col-sm-1" ForeColor="Red" />
            <asp:Label ID="lblSumCustomer" Text="0" runat="server" ForeColor="Red" CssClass="col-sm-2" />
            <asp:Label ID="Label9" Text="مالیات:" runat="server" CssClass="col-sm-1" ForeColor="Red" />
            <asp:Label ID="lblSumVatTax" Text="0" runat="server" ForeColor="Red" CssClass="col-sm-2" />
            <asp:Label ID="Label4" Text="جمع کل" runat="server" CssClass="col-sm-1" ForeColor="Red" />
            <asp:Label ID="txtSumPrice" Text="0" runat="server" ForeColor="Red" CssClass="col-sm-2" />
        </div>
    </div>--%>
</div>
