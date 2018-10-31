<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SupplementReceiptRegistration.ascx.cs"
    Inherits="ANP.COD.Forms.Financial.SupplementReceiptRegistration" %>
<%--<%@ Register Src="../../Controls/DateSelector.ascx" TagName="DateSelector" TagPrefix="uc1" %>
<link href="../../Styles/Receipt.css" rel="stylesheet" type="text/css" />--%>

<link href="../../Content/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="../../Content/bootstrap-select.css" rel="stylesheet" type="text/css" />
<link href="../../Content/MyStyle.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">
    function CheckAll_Approved(chk) {
        all = document.getElementsByTagName('input');
        for (i = 0; i < all.length; i++) {
            if (all[i].type == 'checkbox' && all[i].id.indexOf('dgBarcodeList') > -1 && all[i].id.indexOf('chkHeaderSelect') > -1) {
                if (all[i].disabled == false)
                    all[i].checked = chk.checked;
            }
        }
    }   
</script>

<%--<div id="DivMessage" runat="server" visible="false" dir="rtl" style="width: 100%;">
    <asp:Label ID="lblMessage" Text="" runat="server" />
</div>
<table style="width: 100%; padding-top: 80px;">
    <tr>
        <td align="center">
            <div style="width: 90%;">
                <asp:ValidationSummary ID="myValidationSummary" runat="server" CssClass="validationSummary"
                    EnableClientScript="true" DisplayMode="BulletList" ShowSummary="true" ShowMessageBox="false"
                    ValidationGroup="MyGroup" Height="80px" />
                <table align="center" width="680px" style="box-shadow: 1px 1px 35px #CCC; border-radius: 5px;
                    border: 1px solid #CCC; padding-right: 10px;">
                    <tr>
                        <td colspan="4" style="height: 70px; vertical-align: middle;">
                        </td>
                    </tr>
                    <tr>
                        <td class="lblTitle">
                            <asp:Label ID="lblTypePrice" runat="server" Text="نحوه پرداخت :"></asp:Label>
                        </td>
                        <td class="tdvalue">
                            <asp:DropDownList ID="ddlTypePrice" runat="server" Width="90px" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlTypePrice_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="1">فیش</asp:ListItem>
                                <asp:ListItem Value="0">چک</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="lblTitle">
                        </td>
                        <td class="tdvalue">
                        </td>
                    </tr>
                    <tr>
                        <td class="lblTitle">
                            <asp:Label ID="Label6" runat="server" Text="نوع فیش :" Font-Size="10pt" ForeColor="Red"></asp:Label>
                        </td>
                        <td class="tdvalue">
                            <asp:DropDownList ID="ddlReceiptType" runat="server" Width="190px" Enabled="false">
                            </asp:DropDownList>
                        </td>
                        <td class="lblTitle">
                            <asp:Label ID="lblParentReceipt" runat="server" Text="شماره فیش اصلی :" Font-Size="10pt"
                                ForeColor="Red"></asp:Label>
                        </td>
                        <td class="tdvalue">
                            <asp:TextBox ID="txtParentReceiptID" runat="server" Text="" Enabled="False" Width="77px" />
                            &nbsp;
                            <asp:TextBox ID="txtParentSeriAlphabet" runat="server" Width="41px" Enabled="False" />
                            <asp:Label ID="lblSlash" Text=" / " runat="server" Font-Size="10pt" ForeColor="Red" />
                            <asp:TextBox ID="txtParentSeri" runat="server" Width="48px" MaxLength="6" Enabled="False" />
                        </td>
                    </tr>
                    <tr>
                        <td class="lblTitle">
                            <asp:Label ID="Label10" Text="سری فیش" runat="server" Font-Size="10pt" ForeColor="Red" />
                        </td>
                        <td class="tdvalue">
                            <asp:TextBox ID="txtSeri" runat="server" Width="110px" MaxLength="6" />
                            &nbsp;
                            <asp:Label ID="Label11" Text="/" runat="server" Font-Size="10pt" ForeColor="Red" />&nbsp;
                            <asp:DropDownList ID="ddlSeri" runat="server" Width="52px" Height="21px" />
                        </td>
                        <td class="lblTitle">
                            <asp:Label ID="Label1" runat="server" Text="شماره فیش :" Font-Size="10pt" ForeColor="Red"></asp:Label>
                        </td>
                        <td class="tdvalue">
                            <asp:TextBox ID="txtReceiptNo" runat="server" Width="190px" Font-Size="10pt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvReceiptNo" runat="server" ControlToValidate="txtReceiptNo"
                                CssClass="validator" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true"
                                Text="*" ErrorMessage="وارد کردن شماره فیش الزامي مي باشد ." InitialValue=""
                                ValidationGroup="MyGroup" />
                        </td>
                    </tr>
                    <tr>
                        <td class="lblTitle">
                            <asp:Label ID="Label4" runat="server" Text="تاریخ پرداخت :" Font-Size="10pt" ForeColor="Red"></asp:Label>
                        </td>
                        <td class="tdvalue">
                            <uc1:DateSelector ID="DateSelector1" runat="server" Width="110px" />
                        </td>
                        <td class="lblTitle">
                            <asp:Label ID="Label2" runat="server" Text="بانک عامل :" Font-Size="10pt" ForeColor="Red"></asp:Label>
                        </td>
                        <td class="tdvalue">
                            <asp:DropDownList ID="ddl_bank" runat="server" Width="190px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="lblTitle">
                            <asp:Label ID="Label3" runat="server" Text="مبلغ فیش (ریال) :" Font-Size="10pt" ForeColor="Red"></asp:Label>
                        </td>
                        <td class="tdvalue">
                            <asp:TextBox ID="txtPrice" runat="server" Width="190px" Font-Size="10pt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtPrice"
                                CssClass="validator" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true"
                                Text="*" ErrorMessage="وارد کردن مبلغ فیش الزامي مي باشد ." InitialValue="" ValidationGroup="MyGroup" />
                            <asp:RegularExpressionValidator ID="revPrice" runat="server" ControlToValidate="txtPrice"
                                CssClass="validator" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true"
                                Text="*" ErrorMessage="مبلغ وارد شده معتبر نمي باشد" ValidationExpression="[0-9]{1,11}"
                                ValidationGroup="MyGroup" />
                        </td>
                        <td class="lblTitle">
                            <asp:Label ID="Label5" runat="server" Text="نام  پرداخت کننده :" Font-Size="10pt"
                                ForeColor="Red"></asp:Label>
                        </td>
                        <td class="tdvalue">
                            <asp:TextBox ID="txtPayerName" runat="server" Width="190px" Font-Size="10pt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPayerName" runat="server" ControlToValidate="txtPayerName"
                                CssClass="validator" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true"
                                Text="*" ErrorMessage="وارد کردن نام پرداخت کننده الزامي مي باشد ." InitialValue=""
                                ValidationGroup="MyGroup" />
                        </td>
                    </tr>
                    <tr>
                        <td class="lblTitle">
                            <asp:Label ID="lblSaderKonandehCheque" runat="server" Text="صادر کننده چک"></asp:Label>
                        </td>
                        <td class="tdvalue">
                            <asp:TextBox ID="txtSaderKonandehCheque" runat="server" Width="180px" Font-Size="10pt"
                                MaxLength="40"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtSaderKonandehCheque" runat="server" ControlToValidate="txtSaderKonandehCheque"
                                CssClass="validator" Display="Static" EnableClientScript="true" SetFocusOnError="true"
                                Text="*" ErrorMessage="لطفا نام صادر کننده چک را وارد کنید." InitialValue=""
                                ValidationGroup="MyGroup" Font-Size="12pt" />
                        </td>
                        <td class="lblTitle">
                            <asp:Label ID="lblAccountNoCheque" runat="server" Text="شماره حساب :"></asp:Label>
                        </td>
                        <td class="tdvalue">
                            <asp:TextBox ID="txtAccountNoCheque" runat="server" Width="180px" Font-Size="10pt"
                                MaxLength="40" />
                            <asp:RequiredFieldValidator ID="rfvtxtAccountNo" runat="server" ControlToValidate="txtAccountNoCheque"
                                CssClass="validator" Display="Static" EnableClientScript="true" SetFocusOnError="true"
                                Text="*" ErrorMessage="لطفا شماره حساب  را وارد کنید." InitialValue="" ValidationGroup="MyGroup" />
                        </td>
                    </tr>
                    <tr>
                        <td class="lblTitle">
                            <asp:Label ID="lblVajehCheque" runat="server" Text="در وجه :"></asp:Label>
                        </td>
                        <td class="tdvalue">
                            <asp:TextBox ID="txtVajehCheque" runat="server" Width="180px" Font-Size="10pt" MaxLength="40" />
                            <asp:RequiredFieldValidator ID="rfvVajehCheque" runat="server" ControlToValidate="txtVajehCheque"
                                CssClass="validator" Display="Static" EnableClientScript="true" SetFocusOnError="true"
                                Text="*" ErrorMessage="لطفا در وجه چک را وارد کنید." InitialValue="" ValidationGroup="MyGroup"
                                Font-Size="12pt" />
                        </td>
                        <td class="lblTitle">
                            <asp:Label ID="lblComment" runat="server" Text="توضیحات : "></asp:Label>
                        </td>
                        <td class="tdvalue">
                            <asp:TextBox ID="txtComment" runat="server" Width="180px" TextMode="MultiLine" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <br />
                            <asp:Button ID="btn_addToList" runat="server" Text="ثبت اطلاعات" Width="80px" Font-Names="byekan"
                                ValidationGroup="MyGroup" OnClick="btn_addToList_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="انصراف" Width="80px" Font-Names="byekan"
                                OnClick="btnCancel_Click" />
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
            </div>
            <br />
        </td>
    </tr>
</table>--%>

<script type="text/javascript" language="en">
    function test() {
        $("#<%=this.ddlTypePrice.ClientID%>").selectpicker();
        $("#<%=this.ddlReceiptType.ClientID%>").selectpicker();
        $("#<%=this.ddl_bank.ClientID%>").selectpicker();
        $("#<%=this.ddlSeri.ClientID%>").selectpicker();
        
        $("#<%=this.DateSelector1.ClientID%>").MdPersianDateTimePicker({
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
    }
</script>

        <br />
        <div class="container-fluid col-xs-12 small">
            <div class="row col-sm-12">
                <div class="input-group col-xs-12" dir="rtl">
                    <asp:ValidationSummary ID="myValidationSummary" runat="server" CssClass="validationSummary"
                        EnableClientScript="true" DisplayMode="BulletList" ShowSummary="true" ShowMessageBox="false"
                        ValidationGroup="MyGroup" Height="100px" Font-Size="Small" />
                </div>
            </div>
            <div class="row col-sm-12">
                <div class="input-group col-xs-12" dir="rtl">
                        <span style="height: 50px; text-align: center;">
                            <asp:Label ID="lblAlert" Text="" runat="server" />
                        </span>
                </div>
            </div>
            <div class="row col-xs-10 col-md-pull-1" style="border-width: 0.1px; border-color: #F0F0F0;
                border-style: solid; border-radius: 5px;">
                <div class="input-group col-xs-6 col-md-3 " dir="rtl">
                    <asp:Label ID="Label13" Text="نحوه پرداخت" runat="server" class=" pull-right" />
                    <asp:DropDownList ID="ddlTypePrice" runat="server" class="form-control input-sm selectpicker pull-right "
                        data-style="btn" AutoPostBack="True" data-size="5" OnSelectedIndexChanged="ddlTypePrice_SelectedIndexChanged">
                        <asp:ListItem Value="1" data-icon="glyphicon-edit">فیش</asp:ListItem>
                        <asp:ListItem Value="0" data-icon="glyphicon-usd">چک</asp:ListItem>
                    </asp:DropDownList>

                </div>
                <div id="DivParentReceiptID" runat="server" class="input-group col-xs-6 col-md-3"
                    dir="rtl">
                    <asp:Label ID="lblParentReceipt" Text="شماره سریال ح.س پست" runat="server" class=" pull-right" />
                    <asp:TextBox ID="txtParentReceiptID" runat="server" ReadOnly class="form-control input-sm "
                        Style="text-align: center;" placeholder="ورود شماره سریال ح.س پست " MaxLength="50" />
                </div>
                <div id="tr_SearchReceiptInfo" runat="server" class=" input-group col-xs-9 col-md-5 col-lg-4"
                    dir="rtl">
                    <div class="container-fluid col-xs-12 small">
                        <div class="row col-sm-12" dir="rtl">
                            <div class="input-group col-xs-5 col-md-5" dir="rtl">
                                <asp:Label ID="Label12" Text="سری ح.س"  runat="server" class="pull-left"></asp:Label>
                                <asp:TextBox ID="txtParentSeriAlphabet" ReadOnly  runat="server" class="form-control input-sm " />
                            </div>
                            <div class="input-group col-xs-6" dir="rtl">
                                <asp:Label ID="Label8" Text="پست" runat="server" class="pull-right"></asp:Label>
                                <asp:TextBox ID="txtParentSeri" runat="server" ReadOnly MaxLength="6" class=" form-control input-sm"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <br />
                <div class="input-group col-xs-6 col-md-3" dir="rtl">
                    <asp:Label ID="Label9" Text="نوع فیش/چک" runat="server" class="ipull-right" />
                    <asp:DropDownList ID="ddlReceiptType" runat="server" class="form-control input-sm selectpicker pull-right"
                        data-style="btn" AutoPostBack="True" OnSelectedIndexChanged="ddlTypePrice_SelectedIndexChanged" />
                </div>
                <div class="input-group col-xs-6 col-md-3" dir="rtl">
                    <asp:Label ID="Label3" runat="server" Text="مبلغ فیش/چک (ریال) :" Class="pull-right" />
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
                    <asp:Label ID="Label1" runat="server" Text="شماره سریال فیش/چک :" class=" pull-right" />
                    <asp:TextBox ID="txtReceiptNo" runat="server" class="form-control input-sm" MaxLength="50" />
                    <asp:RequiredFieldValidator ID="rfvReceiptNo" runat="server" ControlToValidate="txtReceiptNo"
                        CssClass="validator" Display="Dynamic" EnableClientScript="true" SetFocusOnError="true"
                        Text="*" ErrorMessage="وارد کردن سریال فیش الزامي مي باشد ." InitialValue=""
                        ValidationGroup="MyGroup" ForeColor="#7E2D14" Font-Size="12pt" />
                </div>
                <br />
                <br />
                <div class="input-group col-xs-6 col-md-3" dir="rtl">
                    <asp:Label ID="Label2" runat="server" Text="بانک عامل :" class=" pull-right" />
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
                                <asp:TextBox ID="txtSeri" runat="server" MaxLength="6" class=" form-control input-sm"></asp:TextBox>
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
                        Text="پست جمهوری اسلامی ایران" />
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
                <div class="input-group col-xs-3 col-md-1 " dir="rtl">
                    <asp:Button ID="btn_addToList" runat="server" Text="ثبت اطلاعات" CssClass=" btn btn-success btn-sm m-btn mini "
                        ValidationGroup="MyGroup" OnClick="btn_addToList_Click" />
                </div>
                <div class="input-group col-xs-2 col-md-1 " dir="rtl">
                    <asp:Button ID="btnCancel" runat="server" Text="انصراف" CssClass=" btn btn-danger btn-sm m-btn mini "
                        ValidationGroup="MyGroup" OnClick="btnCancel_Click" />
                </div>
                <br />
                <br />
            </div>
<%--            <div id="div_BarcodeListTitle" runat="server" class="input-group col-xs-12 ">
                <div class="input-group col-xs-12 " style="background-color: #EEE; text-align: center;">
                    <asp:Label ID="Label6" runat="server" Text="لیست مرسولات"></asp:Label>
                </div>
            </div>--%>
<%--            <div class="input-group col-xs-12 " style="overflow: scroll; height: 180px;">
                <asp:DataGrid ID="dgBarcodeList" OnItemDataBound="dgBarcodeList_ItemDataBound" runat="server" AutoGenerateColumns="False"
                    CellPadding="3" CssClass="grid" PageSize="20"  BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                    <Columns>
                        <asp:BoundColumn DataField="id" HeaderText="آی دی" Visible="false"></asp:BoundColumn>
                        <asp:BoundColumn DataField="RowNum" HeaderText="ردیف "></asp:BoundColumn>
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkHeaderSelect" runat="server" />
                            </ItemTemplate>
                            <HeaderTemplate>
                                <input type="checkbox" id="chkSelect" onclick="javascript:CheckAll_Approved(this);" />انتخاب
                            </HeaderTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="Barcode" HeaderText=" شماره بارکد"></asp:BoundColumn>
                        <asp:BoundColumn DataField="SourceCode" HeaderText="مبدا "></asp:BoundColumn>
                        <asp:BoundColumn DataField="DestCode" HeaderText="مقصد"></asp:BoundColumn>
                        <asp:BoundColumn DataField="EntryDate" HeaderText="تاریخ درج"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ReceiptID" HeaderText="شماره فیش/چک"></asp:BoundColumn>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="false" Font-Size="10pt" ForeColor="White"
                        HorizontalAlign="Center" />
                    <ItemStyle ForeColor="#000066" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                    <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                </asp:DataGrid>
            </div>--%>
        </div>
