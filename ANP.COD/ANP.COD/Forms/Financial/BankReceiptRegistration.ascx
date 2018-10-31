<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BankReceiptRegistration.ascx.cs" Inherits="ANP.COD.Forms.Financial.BankReceiptRegistration" %>
<link href="../../Content/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="../../Content/bootstrap-select.css" rel="stylesheet" type="text/css" />
<link href="../../Content/MyStyle.css" rel="stylesheet" type="text/css" />

<script src="../../Scripts/bootstrap-select.min.js" type="text/javascript"></script>
<script src="../../Scripts/defaults-fa_IR.min.js" type="text/javascript"></script>


<script type="text/javascript">
    function ModifyEnterKeyPress() {
        if (window.event && window.event.keyCode == 13) {
            BarcodeReader();
            test();
            window.event.keyCode = null;
        }
    }
    function BarcodeReader() {
        var theGridView
        if (document.getElementById('ctl11_txtBarcodeSearch') != null) {
            var BarcodeForSearch = document.getElementById('ctl11_txtBarcodeSearch').value;
            if (BarcodeForSearch.length == 24 || BarcodeForSearch.length == 20 || BarcodeForSearch.length == 13) {
                if (document.getElementById('dgBarcodeListWithPostalCost') != null)
                    theGridView = document.getElementById('dgBarcodeListWithPostalCost');
                if (document.getElementById('dgBarcodeListWithOutPostalCost') != null)
                    theGridView = document.getElementById('dgBarcodeListWithOutPostalCost');
                if (theGridView != null) {
                    for (i = 1; i < theGridView.rows.length; i++) {
                        var BarcodeInTable = theGridView.rows[i].cells[2].textContent;
                        if (BarcodeInTable != null) {
                            if (BarcodeInTable.toString() == BarcodeForSearch.toString()) {
                                var chkType = theGridView.rows[i].cells[1].children[0];
                                if (chkType.type == 'checkbox') {
                                    theGridView.rows[i].cells[1].children[0].checked = true;
                                }
                            }
                        }
                    }
                }
                calculateTotal();
            }
            else {
                if (BarcodeForSearch.length != 0)
                alert('بارکد وارد شده نامعتبر است  \r\n  طول بارکد = ' + BarcodeForSearch.length.toString());
            }
        }
    }
    function calculateTotal() {
        var Posal = 0;
        var Customer = 0;
        var Vattax = 0;
        var Counter = 0;
        var Posal_Select = 0;
        var Customer_Select = 0;
        var Vattax_Select = 0;
        var theGridView

        if (document.getElementById('dgBarcodeListWithPostalCost') != null || document.getElementById('dgBarcodeListWithOutPostalCost') != null) {

            if (document.getElementById('ctl11_txtPrice') != null)
                document.getElementById('ctl11_txtPrice').value = 0;

            if (document.getElementById('dgBarcodeListWithPostalCost') != null)
                theGridView = document.getElementById('dgBarcodeListWithPostalCost');

            if (document.getElementById('dgBarcodeListWithOutPostalCost') != null)
                theGridView = document.getElementById('dgBarcodeListWithOutPostalCost');
            if (theGridView != null) {
                for (i = 1; i < theGridView.rows.length; i++) {

                    var chkType = theGridView.rows[i].cells[1].children[0];
                    if (chkType.type == 'checkbox') {
                        if (chkType.checked) {
                            Counter += 1;
                            Posal_Select += parseInt(theGridView.rows[i].cells[7].textContent);
                            Customer_Select += parseInt(theGridView.rows[i].cells[8].textContent);
                            Vattax_Select += parseInt(theGridView.rows[i].cells[9].textContent);
                        }
                        Posal += parseInt(theGridView.rows[i].cells[7].textContent);
                        Customer += parseInt(theGridView.rows[i].cells[8].textContent);
                        Vattax += parseInt(theGridView.rows[i].cells[9].textContent);
                    }
                }
            }

            if (document.getElementById('dgBarcodeListWithPostalCost') != null)
                document.getElementById('ctl11_txtPrice').value = Posal_Select;

            if (document.getElementById('dgBarcodeListWithOutPostalCost') != null)
                document.getElementById('ctl11_txtPrice').value = Customer_Select;

            if (document.getElementById('ctl11_lblCount_Value') != null)
                document.getElementById('ctl11_lblCount_Value').textContent = Counter.toLocaleString();

            if (document.getElementById('ctl11_lblSumPostal_All') != null)
                document.getElementById('ctl11_lblSumPostal_All').textContent = Posal.toLocaleString();
            if (document.getElementById('ctl11_lblSumCustomer_All') != null)
                document.getElementById('ctl11_lblSumCustomer_All').textContent = Customer.toLocaleString();
            if (document.getElementById('ctl11_lblSumVatTax_All') != null)
                document.getElementById('ctl11_lblSumVatTax_All').textContent = Vattax.toLocaleString();
            if (document.getElementById('ctl11_lblSumPrice_All') != null)
                document.getElementById('ctl11_lblSumPrice_All').textContent = (Posal + Customer + Vattax).toLocaleString();

            if (document.getElementById('ctl11_lblSumPostal_Select') != null)
                document.getElementById('ctl11_lblSumPostal_Select').textContent = Posal_Select.toLocaleString();
            if (document.getElementById('ctl11_lblSumCustomer_Select') != null)
                document.getElementById('ctl11_lblSumCustomer_Select').textContent = Customer_Select.toLocaleString();
            if (document.getElementById('ctl11_lblSumVatTax_Select') != null)
                document.getElementById('ctl11_lblSumVatTax_Select').textContent = Vattax_Select.toLocaleString();
            if (document.getElementById('ctl11_lblSumPrice_Select') != null)
                document.getElementById('ctl11_lblSumPrice_Select').textContent = (Posal_Select + Customer_Select + Vattax_Select).toLocaleString();
        }
    }

    function test() {
        if ($('#<%=this.ddlTypePrice.ClientID%>') != null)
            $('#<%=this.ddlTypePrice.ClientID%>').selectpicker();
        if ($('#<%=this.ddlSearechPostReceiptSeri.ClientID%>') != null)
            $('#<%=this.ddlSearechPostReceiptSeri.ClientID%>').selectpicker();
        if ($('#<%=this.ddlReceiptType.ClientID%>') != null)
            $('#<%=this.ddlReceiptType.ClientID%>').selectpicker();
        if ($('#<%=this.ddl_bank.ClientID%>') != null)
            $('#<%=this.ddl_bank.ClientID%>').selectpicker();
        if ($('#<%=this.ddlSeri.ClientID%>') != null)
            $('#<%=this.ddlSeri.ClientID%>').selectpicker();
        if ($('#<%=this.ddlMovazehSearch.ClientID%>') != null)
            $('#<%=this.ddlMovazehSearch.ClientID%>').selectpicker();


        if ($('#<%=this.DateSelector1.ClientID%>') != null)
            $('#<%=this.DateSelector1.ClientID%>').MdPersianDateTimePicker({
                Placement: 'left',
                Trigger: 'focus',
                EnableTimePicker: false,
                TargetSelector: '',
                GroupId: '',
                ToDate: false,
                FromDate: false,
                EnglishNumber: true,
                Disabled: false
            });

        if ($('#<%=this.Fdate.ClientID%>') != null)
            $('#<%=this.Fdate.ClientID%>').MdPersianDateTimePicker({
                Placement: 'left',
                Trigger: 'focus',
                EnableTimePicker: false,
                TargetSelector: '#ctl11_Fdate',
                GroupId: 'group1',
                ToDate: false,
                FromDate: true,
                EnglishNumber: true,
                Disabled: false
            });

        if ($('#<%=this.Ldate.ClientID%>') != null)
            $('#<%=this.Ldate.ClientID%>').MdPersianDateTimePicker({
                Placement: 'left',
                Trigger: 'focus',
                EnableTimePicker: false,
                TargetSelector: '#ctl11_Ldate',
                GroupId: 'group1',
                ToDate: true,
                FromDate: false,
                EnglishNumber: true,
                Disabled: false
            });

        calculateTotal();
    }

    function FillHiddenField() {
        try {
        if ($('#<%=this.ddlMovazehSearch.ClientID%>') != null) {
            document.getElementById('hfMovazeh').value = $('#<%=this.ddlMovazehSearch.ClientID%>').val();
        }
        } catch (e) {

        }

    }

    function CheckAll_Approved(chk) {
        var all = document.getElementsByTagName('input');
        for (i = 0; i < all.length; i++) {
            if (all[i].type == 'checkbox' && all[i].name.indexOf('dgBarcodeList') > -1 && all[i].name.indexOf('chkSelect') > -1) {
                if (all[i].disabled == false)
                    all[i].checked = chk.checked;
            }
        }
        calculateTotal();
    }
</script>




<br />

<div class="container-fluid small"  >
    <div class=" col-xs-12 hidden-xs">
        <div class="input-group col-xs-12" dir="rtl">
            <asp:ValidationSummary ID="myValidationSummary" runat="server" CssClass="validationSummary"
                EnableClientScript="true" DisplayMode="BulletList" ShowSummary="true" ShowMessageBox="false"
                ValidationGroup="MyGroup" Height="100px" Font-Size="Small" />
        </div>
    </div>
    <div class="row col-sm-12">
        <div class="input-group col-xs-11" dir="rtl">
            <div class="input-group col-xs-12">
                <span style="height: 50px; text-align: center;">
                    <asp:Label ID="lblAlert" Text="" runat="server" />
                </span>
            </div>
        </div>
    </div>

    <div id="DivBarcodeSearch" runat="server" class="row col-xs-10 col-md-pull-1" style="border-width: 0.1px; 
        border-color: #F0F0F0; border-style: solid; border-radius: 5px;">
        <div class="input-group col-xs-8 col-md-6 col-lg-3 " dir="rtl">
          <asp:Label ID="lblBarcodeSearch" Text="انتخاب مرسوله با بارکد" runat="server" class="pull-right"></asp:Label>
           <asp:TextBox id="txtBarcodeSearch"  type="text" name="txtBar_Search" value=""  onkeypress ="BarcodeReader( )"  runat="server"/>
            
        </div>
        <div class="input-group col-xs-4 col-md-2" dir="rtl">
            <asp:Label ID="Label1" Text="تعداد بارکد انتخابی : " runat="server" CssClass="pull-right"></asp:Label>
            <asp:Label ID="lblCount_Value" Text="0" runat="server" CssClass="pull-right danger" ViewStateMode="Enabled"></asp:Label>
        </div>
    </div>

    <div id="DivSearch" runat="server" class="row col-xs-10 col-md-pull-1" style="border-width: 0.1px;
        border-color: #F0F0F0; border-style: solid; border-radius: 5px;">
        <div class="input-group col-xs-11 col-md-3 " dir="rtl">
            <asp:Label ID="Label22" Text="موزع" runat="server" class="pull-right"></asp:Label>
            <asp:DropDownList ID="ddlMovazehSearch" data-size="5" runat="server" class="form-control input-sm selectpicker"
                data-live-search="true" showTick="true" multiple data-actions-box="true" data-width="300px" />
            <%-- multiple data-selected-text-format="count"--%>
        </div>
        <div class="input-group col-xs-6 col-md-2 " dir="rtl">
            <asp:Label ID="lblFdate" Text="از تاریخ :" class=" pull-right " runat="server" Font-Size="13px" />
            <asp:TextBox runat="server" type="text" ID="Fdate" class="form-control" data-englishnumber="true"
                data-TargetSelector="#ctl11_Fdate" data-GroupId="group1" data-FromDate="true"
                data-MdDateTimePicker="true" value="1395/05/31" data-placement="left" />
        </div>
        <div class="input-group col-xs-6 col-md-2 " dir="rtl">
            <asp:Label ID="lblTdate" Text="تا تاریخ :" class=" pull-right " runat="server" Font-Size="13px" />
            <asp:TextBox runat="server" type="text" ID="Ldate" class="form-control" data-englishnumber="true"
                data-TargetSelector="#ctl11_Ldate" data-GroupId="group1" data-ToDate="true" data-MdDateTimePicker="true"
                value="1395/05/31" data-placement="left" />
        </div>
        <div class="input-group col-xs-4 col-md-1" dir="rtl">
            <asp:Label ID="Label23" Text="&nbsp" runat="server" class="pull-right"></asp:Label>
            <asp:Button ID="btnSearch" runat="server" Text="جستجو" CssClass="form-control input-sm btn btn-success"
                OnClientClick="FillHiddenField()" OnClick="btnSearch_Click" />
        </div>
        <br />
        <br />
    </div>
    <div class="row col-xs-10 col-md-pull-1" style="border-width: 0.1px; border-color: #F0F0F0;
        border-style: solid; border-radius: 5px;">
        <div class="input-group col-xs-6 col-md-3 " dir="rtl">
            <asp:Label ID="Label13" Text="نحوه پرداخت" runat="server" class=" pull-right" />
            <asp:DropDownList ID="ddlTypePrice" runat="server" class="form-control input-sm selectpicker pull-right "
                data-style="btn" AutoPostBack="True" data-size="5" OnSelectedIndexChanged="ddlTypePrice_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="1" data-icon="glyphicon-edit">فیش</asp:ListItem>
                <asp:ListItem Value="0" data-icon="glyphicon-usd">چک</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div id="DivtxtSearechPostReceiptSerial" runat="server" class="input-group col-xs-6 col-md-3"
            dir="rtl">
            <asp:Label ID="lblMasterReceiptNo" Text="شماره سریال ح.س پست" runat="server" class=" pull-right" />
            <asp:TextBox ID="txtSearechPostReceiptSerial" runat="server" class="form-control input-sm "
                Style="text-align: center;" placeholder="ورود شماره سریال ح.س پست " MaxLength="50" />
        </div>
        <div id="tr_SearchReceiptInfo" runat="server" class=" input-group col-xs-9 col-md-5"
            dir="rtl">
            <div class="container-fluid col-xs-12 small">
            </div>
            <div class="row col-sm-12" dir="rtl">
                <div class="input-group col-xs-5 col-md-3" dir="rtl">
                    <asp:Label ID="Label12" Text="سری ح.س" runat="server" class="pull-left"></asp:Label>
                    <asp:DropDownList ID="ddlSearechPostReceiptSeri" data-live-search="true" data-size="5"
                        runat="server" class="form-control input-sm selectpicker" />
                </div>
                <div class="input-group col-xs-4" dir="rtl">
                    <asp:Label ID="Label8" Text="پست" runat="server" class="pull-right"></asp:Label>
                    <asp:TextBox ID="txtSearechPostReceiptSeri" runat="server" MaxLength="6" class="form-control input-sm "></asp:TextBox>
                </div>
                <div class="input-group col-xs-2" dir="rtl">
                    <asp:Label ID="Label21" Text="&nbsp" runat="server" class="pull-right"></asp:Label>
                    <asp:Button ID="Button1" Text="بارگذاری قیمت" runat="server" class="form-control  input-sm btn-info btn-xs "
                        OnClick="Button1_Click" />
                </div>
            </div>
        </div>
        <br />
        <br />
        <div class="input-group col-xs-6 col-md-3" dir="rtl">
            <asp:Label ID="Label9" Text="نوع فیش/چک" runat="server" class="ipull-right" />
            <asp:DropDownList ID="ddlReceiptType" runat="server" class="form-control input-sm selectpicker pull-right"
                data-style="btn" AutoPostBack="True" OnSelectedIndexChanged="ddlReceiptType_SelectedIndexChanged" />
        </div>
        <div class="input-group col-xs-6 col-md-3" dir="rtl">
            <asp:Label ID="lblPrice" runat="server" Text="مبلغ فیش/چک (ریال) :" Class="pull-right" />
            <asp:TextBox ID="txtPrice" runat="server" class="form-control input-sm" MaxLength="10" />
            <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtPrice"
                CssClass="validator" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true"
                Text="*" ErrorMessage="وارد کردن مبلغ فیش الزامي مي باشد ." InitialValue="" ForeColor="#7E2D14"
                ValidationGroup="MyGroup" Font-Size="12pt" />
            <asp:RegularExpressionValidator ID="revPrice" runat="server" ControlToValidate="txtPrice"
                CssClass="validator" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true"
                Text="*" ErrorMessage="مبلغ وارد شده معتبر نمي باشد" ValidationExpression="[0-9]{1,11}"
                ValidationGroup="MyGroup" ForeColor="#7E2D14" Font-Size="12pt" BorderColor="#FF3300" />
        </div>
        <div class="input-group col-xs-6 col-md-3" dir="rtl">
            <asp:Label ID="Label2" runat="server" Text="شماره سریال فیش/چک :" class=" pull-right" />
            <asp:TextBox ID="txtReceiptSerialNo" runat="server" class="form-control input-sm"
                MaxLength="50" />
            <asp:RequiredFieldValidator ID="rfvReceiptNo" runat="server" ControlToValidate="txtReceiptSerialNo"
                CssClass="validator" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true"
                Text="*" ErrorMessage="وارد کردن سریال فیش الزامي مي باشد ." InitialValue=""
                ValidationGroup="MyGroup" ForeColor="#7E2D14" Font-Size="12pt" />
        </div>
        <br />
        <br />
        <div class="input-group col-xs-6 col-md-3" dir="rtl">
            <asp:Label ID="Label3" runat="server" Text="بانک عامل :" class=" pull-right" />
            <asp:DropDownList ID="ddl_bank" runat="server" class="form-control input-sm selectpicker pull-right"
                data-style="btn" />
        </div>
        <div class="input-group col-xs-5 col-md-3" dir="ltr" style="margin: 0px 5px;">
            <asp:Label ID="Label14" Text="تاریخ" class=" pull-right" runat="server" />
            <asp:TextBox runat="server" type="text" ID="DateSelector1" class="form-control" data-englishnumber="true"
                data-MdDateTimePicker="true" value="۱۳۹۲/۰۱/۰۱" data-placement="left" />
        </div>
        <div id="Div1" runat="server" class=" input-group col-xs-9 col-md-5 col-lg-4" dir="rtl">
            <div class="container-fluid col-xs-12 small">
                <div class="row col-sm-12" dir="rtl">
                    <div class="input-group col-xs-5 col-md-5" dir="rtl">
                        <asp:Label ID="Label11" Text="سری فیش" runat="server" class="pull-left"></asp:Label>
                        <asp:DropDownList ID="ddlSeri" runat="server" data-live-search="true" data-size="5"
                            class="form-control input-sm selectpicker " />
                    </div>
                    <div class="input-group col-xs-6" dir="rtl">
                        <asp:Label ID="Label10" Text="/چک" runat="server" class="pull-right"></asp:Label>
                        <asp:TextBox ID="txtSeri" runat="server" MaxLength="6" class=" form-control input-sm"
                            Width="80%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtSeri" runat="server" ControlToValidate="txtSeri"
                            CssClass="validator" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true"
                            Text="*" ErrorMessage="وارد کردن سری فیش الزامي مي باشد ." ValidationGroup="MyGroup"
                            ForeColor="#7E2D14" Font-Size="12pt" />
                    </div>
                </div>
            </div>
        </div>
        <br />
        <br />
        <div class="input-group col-xs-6 col-md-3" dir="rtl">
            <asp:Label ID="Label5" runat="server" Text="نام  پرداخت کننده :" class=" pull-right" />
            <asp:TextBox ID="txtPayerName" runat="server" class="form-control input-sm" MaxLength="150" />
            <asp:RequiredFieldValidator ID="rfvPayerName" runat="server" ControlToValidate="txtPayerName"
                CssClass="validator" Display="Static" EnableClientScript="true" SetFocusOnError="true"
                Text="*" ErrorMessage="لطفا نام پرداخت کننده را وارد کنید." InitialValue="" ValidationGroup="MyGroup"
                ForeColor="#7E2D14" Font-Size="12pt" />
        </div>
        <div id="DivtxtVajehCheque" runat="server" class="input-group col-xs-6 col-md-3"
            dir="rtl">
            <asp:Label ID="lblVajehCheque" runat="server" Text="در وجه :" class=" pull-right" />
            <asp:TextBox ID="txtVajehCheque" runat="server" class="form-control input-sm" MaxLength="150"
                placeholder="پست جمهوری اسلامی ایران" />
            <asp:RequiredFieldValidator ID="rfvtxtVajehCheque" runat="server" ControlToValidate="txtVajehCheque"
                CssClass="validator" Display="Static" EnableClientScript="true" SetFocusOnError="true"
                Text="*" ErrorMessage="لطفا در وجه چک را مشخص کنید." InitialValue="" ValidationGroup="MyGroup"
                ForeColor="#7E2D14" Font-Size="12pt" />
        </div>
        <div id="DivtxtSaderKonandehCheque" runat="server" class="input-group col-xs-6 col-md-3"
            dir="rtl">
            <asp:Label ID="lblSaderKonandehCheque" runat="server" Text="صادر کننده چک" class=" pull-right" />
            <asp:TextBox ID="txtSaderKonandehCheque" runat="server" class="form-control input-sm"
                MaxLength="150" />
        </div>
        <div id="DivtxtAccountNoCheque" runat="server" class="input-group col-xs-6 col-md-6"
            dir="rtl">
            <asp:Label ID="lblAccountNoCheque" runat="server" Text="شماره حساب :" class=" pull-right"></asp:Label>
            <asp:TextBox ID="txtAccountNoCheque" runat="server" class="form-control input-sm"
                MaxLength="20" />
        </div>
        <div id="DivtxtComment" runat="server" class="input-group col-xs-6 col-md-6" dir="rtl">
            <asp:Label ID="lblComment" runat="server" Text="توضیحات : " class=" pull-right" />
            <asp:TextBox ID="txtComment" runat="server" class="form-control input-sm" TextMode="MultiLine"
                Style="resize: none; overflow: auto;" MaxLength="500" />
            <br />
            <br />
        </div>
        <div class="input-group col-xs-6 col-md-3 pull-left" dir="rtl">
            <asp:Button ID="btn_addToList" runat="server" Text="ثبت اطلاعات" CssClass=" btn btn-success btn-sm m-btn mini "
                ValidationGroup="MyGroup" OnClick="btn_addToList_Click" />
        </div>
        <br />
        <br />
    </div>
    <div id="div_BarcodeListTitle" runat="server" class="row col-xs-12 ">
        <div class="input-group col-xs-12 " style="background-color: #EEE; text-align: center;">
            <asp:Label ID="Label6" runat="server" Text="لیست مرسولات"></asp:Label>
        </div>
    </div>
    <div id="div_dgBarcodeList" runat="server" class="row col-xs-12 " style="width: 100%;
        overflow: auto; height: 50px auto; max-height: 350px;">
        <div class="input-group col-xs-12 ">
            <asp:DataGrid ID="dgBarcodeListWithPostalCost" runat="server" AutoGenerateColumns="False"
                CellPadding="3" CssClass="grid" PageSize="20" OnItemDataBound="dgBarcodeList_ItemDataBound"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                ClientIDMode="Static">
                <Columns>
                    <asp:BoundColumn DataField="id" HeaderText="آی دی" Visible="false"></asp:BoundColumn>
                    <asp:BoundColumn DataField="RowNum" HeaderText="ردیف "></asp:BoundColumn>
                    <asp:TemplateColumn>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" onclick="javascript:calculateTotal();" />
                        </ItemTemplate>
                        <HeaderTemplate>
                            <input type="checkbox" id="chkHeader" onclick="javascript:CheckAll_Approved(this);" />انتخاب
                        </HeaderTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="Barcode" HeaderText=" شماره بارکد"></asp:BoundColumn>
                    <asp:BoundColumn DataField="SourceCode" HeaderText="مبدا "></asp:BoundColumn>
                    <asp:BoundColumn DataField="DestCode" HeaderText="مقصد"></asp:BoundColumn>
                    <asp:BoundColumn DataField="EntryDate" HeaderText="تاریخ تحویل"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ReceiptID" HeaderText="شماره فیش/چک"></asp:BoundColumn>
                    <asp:BoundColumn DataField="PostalCost" HeaderText="ح.س پست"></asp:BoundColumn>
                    <asp:BoundColumn DataField="CustomerCost" HeaderText="ح.س.ط قرارداد"></asp:BoundColumn>
                    <asp:BoundColumn DataField="VatTax" HeaderText="مالیات"></asp:BoundColumn>
                    <asp:BoundColumn DataField="InsurCost" HeaderText="بیمه" Visible="false"></asp:BoundColumn>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="false" Font-Size="10pt" ForeColor="White"
                    HorizontalAlign="Center" />
                <ItemStyle ForeColor="#000066" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            </asp:DataGrid>
            <asp:DataGrid ID="dgBarcodeListWithOutPostalCost" runat="server" AutoGenerateColumns="False" ViewStateMode="Enabled"
                CellPadding="3" CssClass="grid" PageSize="20" OnItemDataBound="dgBarcodeList_ItemDataBound"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                ClientIDMode="Static">
                <Columns>
                    <asp:BoundColumn DataField="id" HeaderText="آی دی" Visible="false"></asp:BoundColumn>
                    <asp:BoundColumn DataField="RowNum" HeaderText="ردیف "></asp:BoundColumn>
                    <asp:TemplateColumn>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" onclick="javascript:calculateTotal();" />
                        </ItemTemplate>
                        <HeaderTemplate>
                            <input type="checkbox" id="chkHeader" onclick="javascript:CheckAll_Approved(this);" />انتخاب
                        </HeaderTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="Barcode" HeaderText=" شماره بارکد"></asp:BoundColumn>
                    <asp:BoundColumn DataField="SourceCode" HeaderText="مبدا "></asp:BoundColumn>
                    <asp:BoundColumn DataField="DestCode" HeaderText="مقصد"></asp:BoundColumn>
                    <asp:BoundColumn DataField="EntryDate" HeaderText="تاریخ تحویل"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ReceiptID" HeaderText="شماره فیش/چک"></asp:BoundColumn>
                    <asp:BoundColumn DataField="PostalCost" HeaderText="ح.س پست"></asp:BoundColumn>
                    <asp:BoundColumn DataField="CustomerCost" HeaderText="ح.س.ط قرارداد"></asp:BoundColumn>
                    <asp:BoundColumn DataField="VatTax" HeaderText="مالیات"></asp:BoundColumn>
                    <asp:BoundColumn DataField="InsurCost" HeaderText="بیمه" Visible="false"></asp:BoundColumn>
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
    <div id="DivSelectedPrice" runat="server" class="row col-sm-12" style="height: 60px;
        top: 0px; left: 0px;">
        <div class="input-group col-xs-12" style="background-color: #FEFDFD; border-width: 0.1px;
            border-color: #337AB7; border-style: solid; borderadius: 5px; padding: 5px;">
            <asp:Label ID="lable15" Text="ح.س.پست:" runat="server" CssClass="col-sm-1" ForeColor="Red" />
            <asp:Label ID="lblSumPostal_All" Text="0" runat="server" ForeColor="Red" Font-Size="11"
                CssClass="col-sm-2"   ViewStateMode="Enabled"/>
            <asp:Label ID="Label4" Text="ط.قرارداد:" runat="server" CssClass="col-sm-1" ForeColor="Red" />
            <asp:Label ID="lblSumCustomer_All" Text="0" runat="server" ForeColor="Red" Font-Size="11"
                CssClass="col-sm-2"   ViewStateMode="Enabled"/>
            <asp:Label ID="Label15" Text="مالیات:" runat="server" CssClass="col-sm-1" ForeColor="Red" />
            <asp:Label ID="lblSumVatTax_All" Text="0" runat="server" ForeColor="Red" Font-Size="11"
                CssClass="col-sm-2"   ViewStateMode="Enabled"/>
            <asp:Label ID="Label16" Text="جمع کل" runat="server" CssClass="col-sm-1" ForeColor="Red" />
            <asp:Label ID="lblSumPrice_All" Text="0" runat="server" ForeColor="Red" Font-Size="11"
                CssClass="col-sm-2"   ViewStateMode="Enabled"/>
            <asp:Label ID="Label17" Text="انتخاب" runat="server" CssClass="col-sm-1" ForeColor="Red" />
            <asp:Label ID="lblSumPostal_Select" Text="0" runat="server" ForeColor="Red" Font-Size="11"
                CssClass="col-sm-2"   ViewStateMode="Enabled"/>
            <asp:Label ID="Label18" Text="انتخاب" runat="server" CssClass="col-sm-1" ForeColor="Red" />
            <asp:Label ID="lblSumCustomer_Select" Text="0" runat="server" ForeColor="Red" Font-Size="11"
                CssClass="col-sm-2"  ViewStateMode="Enabled" />
            <asp:Label ID="Label19" Text="انتخاب" runat="server" CssClass="col-sm-1" ForeColor="Red" />
            <asp:Label ID="lblSumVatTax_Select" Text="0" runat="server" ForeColor="Red" Font-Size="11"
                CssClass="col-sm-2"   ViewStateMode="Enabled"/>
            <asp:Label ID="Label20" Text="انتخاب" runat="server" CssClass="col-sm-1" ForeColor="Red" />
            <asp:Label ID="lblSumPrice_Select" Text="0" runat="server" ForeColor="Red" Font-Size="11"
                CssClass="col-sm-2"   ViewStateMode="Enabled"/>
        </div>
    </div>
    <div class="row col-xs-12 ">
        <div class="input-group col-xs-12 " style="background-color: #EEE; text-align: center;">
            <asp:Label ID="Label7" runat="server" Text="مشخصات فیش های واریزی"></asp:Label>
        </div>
    </div>
    <div class="row col-xs-12 ">
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
                    <asp:BoundColumn DataField="BarcodeCount" HeaderText="تعداد مرسوله"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Price" HeaderText="مبلغ فیش /چک"></asp:BoundColumn>
                    <asp:BoundColumn DataField="BankName" HeaderText="نام بانک"></asp:BoundColumn>
                    <asp:BoundColumn DataField="PayerName" HeaderText="پرداخت کننده"></asp:BoundColumn>
                    <asp:BoundColumn DataField="TypeValue" HeaderText="نوع فیش/چک"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ChequeVajh" HeaderText="در وجه"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ChequeSaderKonandeh" HeaderText="صادر کننده"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ChequeAccountNo" HeaderText="شماره حساب"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ChequeComment" HeaderText="توضیحات چک"></asp:BoundColumn>
                    <asp:TemplateColumn HeaderText="حذف">
                        <ItemTemplate>
                            <asp:LinkButton ID="lblReceiptDel" runat="server" CommandArgument='<%# Eval("id") %>'
                                CommandName="Delete">حذف</asp:LinkButton>
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
    <div class="row col-xs-12 ">
        <div class="input-group col-xs-5 col-sm-4 col-md-3 col-xs-pull-3 col-sm-pull-4 col-md-pull-5">
            <asp:Button ID="btnReceiptSend" Text="تایید نهایی " ToolTip="ارسال به پنل مالی" runat="server"
                CssClass="btn btn-success btn-md " OnClick="btnReceiptSend_Click" />
        </div>
    </div>
</div>

<asp:HiddenField ID="hfMovazeh" runat="server" ClientIDMode="Static" />


<script type="text/javascript">
    $(document).ready(function () {
        ModifyEnterKeyPress();
        if (document.getElementById('ddlMovazehSearch') != null) {
            $('#<%=this.ddlMovazehSearch.ClientID%>').multiselect({
                enableFiltering: true
            });
        }
    });
    
</script>



