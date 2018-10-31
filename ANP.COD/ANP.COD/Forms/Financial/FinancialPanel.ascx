<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FinancialPanel.ascx.cs"
    Inherits="ANP.COD.Forms.Financial.FinancialPanel" %>
<link href="../../Content/MyStyle.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">

    function test() {
        $("#<%=this.ddlDispense.ClientID%>").selectpicker();
        $("#<%=this.ddlCity.ClientID%>").selectpicker();
        $("#<%=this.ddlCountry.ClientID%>").selectpicker();

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
<div id="divDetail" runat="server" visible="false" style="border-style: none; opacity: 0.8;
    border-width: medium; z-index: 1000; display: block; margin: 0pt; padding: 0pt;
    width: 100%; height: 100%; top: 0pt; left: 0pt; background-color: #CCC; cursor: move;
    position: fixed; bottom: 708px;">
</div>
<%--<table cellpadding="0" cellspacing="0" dir="rtl" style="width: 100%; margin-top: 30px;">
    <tr>
        <td>
            <table cellspacing="0" cellpadding="0" style="border: 0; width: 100%;">
                <tr>
                    <td style="background-color: #FFF;">
                        <table align="center" cellspacing="0" style="font-family: BYEKAN;" cellpadding="5"
                            width="90%">
                            <tr>
                                <td colspan="4">
                                    <br />
                                    <div id="DivMessage" runat="server" visible="false" dir="rtl">
                                        <asp:Label ID="lblMessage" Text="" runat="server" />
                                    </div>
                                </td>
                            </tr>
                            <tr style="background-color: #FFF;">
                                <td style="width: 200px;">
                                    <asp:Label ID="lblCountry" runat="server" Text="شهرستان : " Font-Names="byekan" Font-Size="9pt"></asp:Label>
                                    &nbsp;
                                    <asp:DropDownList ID="ddlCountry" runat="server" Width="130px" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" />
                                </td>
                                <td style="width: 200px;">
                                    <asp:Label ID="lblCity" runat="server" Text="شهر : " Font-Names="byekan" Font-Size="9pt" />
                                    &nbsp;
                                    <asp:DropDownList ID="ddlCity" runat="server" Width="130px" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged"
                                        AutoPostBack="True" />
                                </td>
                                <td>
                                    <asp:Label ID="lblDispense" runat="server" Font-Names="byekan" Text=" نقطه توزیع : "
                                        Font-Size="9pt" />&nbsp;
                                    <asp:DropDownList ID="ddlDispense" runat="server" Width="130px" />
                                </td>
                                <td>
                                    <asp:Button ID="btnSearch" Text="جستجو" runat="server" OnClick="btnSearch_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <br />
        </td>
    </tr>
    <tr>

            <div id="divDetail1" visible="false" runat="server" style="z-index: 1150; display: block;
                position: fixed; padding: 0px; margin: 0px; width: 90%; height: auto; top: 30%;
                left: 5%; direction: rtl; color: Blue; border-width: 1px; border-style: solid;
                border-color: gray; background-color: #FFF; text-align: center; font-family: BYekan;
                font-size: 9pt;">
                <div id="PrintDiv">
                    <asp:DataGrid ID="dgDetail" runat="server" AutoGenerateColumns="False" CssClass="grid"
                        Width="100%" OnItemCommand="dgReceiptList_ItemCommand" OnItemDataBound="dgFinancialReceipt_ItemDataBound"
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                        CellPadding="3">
                        <ItemStyle ForeColor="#000066" />
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundColumn DataField="RowNum" HeaderText="ردیف " Visible="true"></asp:BoundColumn>
                            <asp:BoundColumn DataField="id" HeaderText="آی دی" Visible="false"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ReceiptSerialNo" HeaderText="شماره فیش/چک"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Seri" HeaderText="سریال فیش/چک"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Price" HeaderText="مبلغ فیش/چک"></asp:BoundColumn>
                            <asp:BoundColumn DataField="BankName" HeaderText="نام بانک"></asp:BoundColumn>
                            <asp:BoundColumn DataField="PayerName" HeaderText="پرداخت کننده"></asp:BoundColumn>
                            <asp:BoundColumn DataField="PayDate" HeaderText="تاریخ پرداخت"></asp:BoundColumn>
                            <asp:BoundColumn DataField="IsPhish" HeaderText="فیش؟" Visible="false"></asp:BoundColumn>
                            <asp:BoundColumn DataField="PriceType" HeaderText="نحوه پرداخت"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ChequeVajh" HeaderText="در وجه"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ChequeSaderKonandeh" HeaderText="صادر کننده"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ChequeAccountNo" HeaderText="شماره حساب"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ChequeComment" HeaderText="توضیحات چک"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ReceiptType" HeaderText="نوع فیش/چک" ItemStyle-HorizontalAlign="Justify">
                            </asp:BoundColumn>
                        </Columns>
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    </asp:DataGrid>
                </div>
                <br />
                <asp:Button ID="btnDetail" Text="بازگشت" runat="server" Style="margin-right: 0px"
                    Font-Names="byekan" Font-Size="9pt" Width="80px" OnClick="btnDetail_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" Text="چاپ" runat="server" Style="margin-right: 0px" Font-Names="byekan"
                    Font-Size="9pt" Width="80px" OnClientClick="printer('PrintDiv')" />
                <br />
            </div>
            <div id="divDetail2" visible="false" runat="server" style="z-index: 1151; display: block;
                position: fixed; padding: 0px; margin: 0px; width: 72%; height: auto; top: 30%;
                left: 14%; direction: rtl; color: Blue; border-width: 1px; border-style: solid;
                border-color: gray; background-color: #FFF; text-align: center; font-family: BYekan;
                font-size: 9pt;">
                <asp:DataGrid ID="dgParcelsDetail" runat="server" AutoGenerateColumns="False" CssClass="grid"
                    Width="100%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                    CellPadding="3">
                    <ItemStyle ForeColor="#000066" />
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundColumn DataField="id" HeaderText="id " Visible="false"></asp:BoundColumn>
                        <asp:BoundColumn DataField="RowNum" HeaderText="ردیف "></asp:BoundColumn>
                        <asp:BoundColumn DataField="Barcode" HeaderText=" شماره بارکد"></asp:BoundColumn>
                        <asp:BoundColumn DataField="SourceCode" HeaderText="مبدا "></asp:BoundColumn>
                        <asp:BoundColumn DataField="DestCode" HeaderText="مقصد"></asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryDate" HeaderText="تاریخ درج"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ServiceType" HeaderText="نوع سرویس"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Price" HeaderText="قیمت"></asp:BoundColumn>
                    </Columns>
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                    <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                </asp:DataGrid>
                <br />
                <asp:Button ID="btnParcelsDetail" Text="بازگشت" runat="server" Style="margin-right: 0px"
                    Font-Names="byekan" Font-Size="9pt" Width="80px" OnClick="btnDetail_Click" />
                <br />
            </div>
        </td>
    </tr>
</table>--%>
<div class="container-fluid col-xs-12 hidden-xs small">
    <div class="row col-sm-12">
        <div id="DivMessage" runat="server" class="input-group col-xs-12" dir="ltr">
            <span style="height: 50px; text-align: center;">
                <asp:Label ID="lblAlert" Text="" runat="server" />
            </span>
        </div>
    </div>
    <div class="row col-xs-11 col-xs-pull-1 col-xs-push-1 " style="border-width: 0.1px;
        border-color: #F0F0F0; border-style: solid; border-radius: 5px;">
        <div class="input-group col-xs-10 col-sm-10 col-md-3 col-lg-3" dir="rtl">
            <asp:Label ID="lblCountry" runat="server" Text="شهرستان : " class=" pull-right" />
            <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"
                class="form-control input-sm selectpicker " data-style="btn" data-live-search="true"
                data-size="5" />
        </div>
        <div class="input-group col-xs-10 col-sm-10 col-md-3 col-lg-3" dir="rtl">
            <asp:Label ID="lblCity" runat="server" Text="شهر : " class=" pull-right" />
            <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged"
                class="form-control input-sm selectpicker " data-style="btn" data-live-search="true"
                data-size="5" />
        </div>
        <div class="input-group col-xs-10 col-sm-10 col-md-3 col-lg-3" dir="rtl">
            <asp:Label ID="lblDispense" runat="server" Text=" نقطه توزیع : " class=" pull-right" />
            <asp:DropDownList ID="ddlDispense" runat="server" AutoPostBack="True" class="form-control input-sm selectpicker "
                data-style="btn" data-live-search="true" data-size="5" />
        </div>
        <div class="input-group col-xs-5 col-md-3" dir="ltr" style="margin: 0px 5px;">
            <asp:Label ID="Label2" Text="از تاریخ" class=" pull-right" runat="server" />
            <asp:TextBox runat="server" type="text" ID="Fdate" class="form-control" data-englishnumber="true"
                data-MdDateTimePicker="true" value="۱۳۹۲/۰۱/۰۱" data-placement="left" />
        </div>
        <div class="input-group col-xs-5 col-md-3" dir="ltr" style="margin: 0px 5px;">
            <asp:Label ID="Label3" Text="تا تاریخ" class=" pull-right" runat="server" />
            <asp:TextBox runat="server" type="text" ID="Ldate" class="form-control" data-englishnumber="true"
                data-MdDateTimePicker="true" value="۱۳۹۲/۰۱/۰۱" data-placement="left" />
        </div>
        <div class="input-group col-xs-10 col-sm-10 col-md-3" dir="rtl">
            <asp:Button ID="btnSearch" Text="جستجو" runat="server" CssClass="btn btn-primary"
                AccessKey="S" OnClick="btnSearch_Click" />
        </div>
    </div>
    <div class="row col-sm-12">
        <br />
        <div dir="rtl" style="width: 100%; overflow: auto; height: 50px auto; max-height: 350px;">
            <asp:DataGrid ID="dgFinancialReceipt" runat="server" OnItemCommand="dgReceiptList_ItemCommand"
                OnItemDataBound="dgFinancialReceipt_ItemDataBound" AutoGenerateColumns="False"
                CssClass="grid" Width="100%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                BorderWidth="1px" CellPadding="3">
                <Columns>
                    <asp:BoundColumn DataField="RowNum" HeaderText="ردیف " Visible="true"></asp:BoundColumn>
                    <asp:BoundColumn DataField="id" HeaderText="آی دی" Visible="false"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ReceiptSerialNo" HeaderText="سریال فیش/چک"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Seri" HeaderText="سری فیش/چک"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Type" HeaderText="نوع"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Price" HeaderText="مبلغ فیش /چک اصلی"></asp:BoundColumn>
                    <asp:BoundColumn DataField="BankName" HeaderText="نام بانک"></asp:BoundColumn>
                    <asp:BoundColumn DataField="PostalCost" HeaderText="ح.س پست"></asp:BoundColumn>
                    <asp:BoundColumn DataField="CostumerCost" HeaderText="ح.س.ط قرارداد"></asp:BoundColumn>
                    <asp:BoundColumn DataField="VatTax" HeaderText="مالیات"></asp:BoundColumn>
                    <asp:BoundColumn DataField="IsPhish" HeaderText="فیش؟" Visible="false"></asp:BoundColumn>
                    <asp:BoundColumn DataField="PriceType" HeaderText="نوع پرداخت"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ChequeVajh" HeaderText="در وجه" Visible="false"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ChequeSaderKonandeh" HeaderText="صادر کننده چک" Visible="false">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ChequeAccountNo" HeaderText="شماره حساب" Visible="false">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ChequeComment" HeaderText="توضیحات چک" Visible="false">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="BarcodeCount" HeaderText="تعداد مرسوله"></asp:BoundColumn>
                    <asp:TemplateColumn HeaderText=" جزئیات ">
                        <ItemTemplate>
                            <asp:LinkButton ID="lblParcelsDetail" Text="جزئیات مرسولات" runat="server" CommandName="ParcelsDetail"
                                Font-Size="8" Font-Names="byekan" CommandArgument='<%# Eval("id") %>' />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="PayerName" HeaderText="پرداخت کننده"></asp:BoundColumn>
                    <asp:BoundColumn DataField="UserName" HeaderText="کاربر ثبت کننده"></asp:BoundColumn>
                    <asp:TemplateColumn HeaderText=" جزئیات ">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbDetail" Text="جزئیات مالی" runat="server" CommandName="Detail"
                                Font-Size="8" Font-Names="byekan" CommandArgument='<%# Eval("id") %>' />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="ثبت تغییرات">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlReceiptState" runat="server" Width="120" />
                            <br />
                            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" MaxLength="499"
                                Width="120px" Height="50px" Columns="0" Style="resize: none;" />
                            <br />
                            <asp:Button ID="btnOK" Text="ذخیره" runat="server" CommandArgument='<%# Eval("id") %>'
                                Width="50px" Height="19px" CommandName="OK" Font-Size="8" Font-Names="byekan" />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#D9EDF7" Font-Bold="false" ForeColor="Black" HorizontalAlign="Center" />
                <ItemStyle ForeColor="#000066" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                <SelectedItemStyle BackColor="#669999" Font-Bold="false" ForeColor="White" />
            </asp:DataGrid></div>
    </div>
    <div class="row col-sm-12">
        <div id="divDetail1" visible="false" runat="server" style="z-index: 1103; display: block;
            position: fixed; padding: 0px; margin: 0px; height: 10px auto; max-height: 300px;
            top: 20%; width: 80%; left: 10%; direction: rtl; color: Blue; border-width: 0px;
            background-color: #D6D6D6; text-align: center;">
            <div style="width: 98%; box-shadow: 0.1px 0.1px 2px #BBB; overflow: auto; height: 10px auto;
                max-height: 250px; margin: 1%;">
                <div id="PrintDiv">
                    <asp:DataGrid ID="dgDetail" runat="server" AutoGenerateColumns="False" CssClass="grid"
                        Width="100%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                        CellPadding="3">
                        <Columns>
                            <asp:BoundColumn DataField="RowNum" HeaderText="ردیف " Visible="true"></asp:BoundColumn>
                            <asp:BoundColumn DataField="id" HeaderText="آی دی" Visible="false"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ReceiptSerialNo" HeaderText="سریال فیش/چک"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Seri" HeaderText="سری فیش/چک"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Price" HeaderText="مبلغ فیش/چک"></asp:BoundColumn>
                            <asp:BoundColumn DataField="BankName" HeaderText="نام بانک"></asp:BoundColumn>
                            <asp:BoundColumn DataField="PayerName" HeaderText="پرداخت کننده"></asp:BoundColumn>
                            <asp:BoundColumn DataField="PayDate" HeaderText="تاریخ پرداخت"></asp:BoundColumn>
                            <asp:BoundColumn DataField="IsPhish" HeaderText="فیش؟" Visible="false"></asp:BoundColumn>
                            <asp:BoundColumn DataField="PriceType" HeaderText="نحوه پرداخت"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ChequeVajh" HeaderText="در وجه"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ChequeSaderKonandeh" HeaderText="صادر کننده"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ChequeAccountNo" HeaderText="شماره حساب"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ChequeComment" HeaderText="توضیحات چک"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ReceiptType" HeaderText="نوع فیش/چک" ItemStyle-HorizontalAlign="Justify">
                            </asp:BoundColumn>
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#D9EDF7" Font-Bold="false" ForeColor="Black" HorizontalAlign="Center" />
                        <ItemStyle ForeColor="#000066" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                        <SelectedItemStyle BackColor="#669999" Font-Bold="false" ForeColor="White" />
                    </asp:DataGrid>
                    <br />
                </div>
                <asp:Button ID="btnDetail" runat="server" CssClass="btn btn-success btn-md " Text="بازگشت"
                    Style="margin-right: 0px" Font-Names="byekan" Font-Size="9pt" Width="80px" OnClick="btnDetail_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button3" Text="چاپ" runat="server" CssClass="btn btn-info btn-md "
                    Style="margin-right: 0px" Font-Names="byekan" Font-Size="9pt" Width="80px" OnClientClick="printer('PrintDiv')" />
            </div>
        </div>
        <div id="divDetail2" visible="false" runat="server" style="z-index: 1103; display: block;
            position: fixed; padding: 0px; margin: 0px; height: 10px auto; max-height: 300px;
            top: 20%; width: 80%; left: 10%; direction: rtl; color: Blue; border-width: 0px;
            background-color: #D6D6D6; text-align: center;">
            <div id="PrintBarcode" style="width: 98%; box-shadow: 0.1px 0.1px 2px #BBB; overflow: auto;
                direction: rtl; height: 10px auto; text-align: center; max-height: 250px; margin: 1%;">
                <asp:DataGrid ID="dgParcelsDetail" runat="server" AutoGenerateColumns="False" CssClass="grid"
                    Width="100%" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                    CellPadding="3" OnItemDataBound="dgParcelsDetail_ItemDataBound">
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
            <asp:Button ID="Button1" Text="بازگشت" runat="server" Style="margin-right: 0px" Font-Names="byekan"
                Font-Size="9pt" Width="80px" OnClick="btnDetail_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" Text="چاپ" runat="server" Style="margin-right: 0px" Font-Names="byekan"
                Font-Size="9pt" Width="80px" OnClientClick="printer('PrintBarcode')" />
            <br />
        </div>
    </div>
    <br />
</div>
