<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeleteBarcode.ascx.cs"
    Inherits="ANP.COD.Forms.Exchange.DeleteBarcode" %>
<%@ Register Src="../../Controls/AlertControl.ascx" TagPrefix="uc" TagName="AlertControl" %>
<link href="../../Content/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="../../Content/bootstrap-select.css" rel="stylesheet" type="text/css" />
<link href="../../Content/MyStyle.css" rel="stylesheet" type="text/css" />
<%--<link href="../../Styles/Receipt.css" rel="stylesheet" type="text/css" />--%>
<%--<script src="../../Scripts/MyJavaScript.js" type="text/javascript"></script>--%>

<%--<script type="text/javascript" language="en">
    function calculateTotal() {

        var Posal = 0;
        var Customer = 0;
        var Vattax = 0;

        var Posal_Select = 0;
        var Customer_Select = 0;
        var Vattax_Select = 0;

        var theGridView

        document.getElementById('ctl11_txtPrice').value = 0;

        if (document.getElementById('dgBarcodeListWithPostalCost') != null)
            theGridView = document.getElementById('dgBarcodeListWithPostalCost');

        if (document.getElementById('dgBarcodeListWithOutPostalCost') != null)
            theGridView = document.getElementById('dgBarcodeListWithOutPostalCost');

        for (i = 1; i < theGridView.rows.length; i++) {

            var chkType = theGridView.rows[i].cells[1].children[0];
            if (chkType.type == 'checkbox') {
                if (chkType.checked) {

                    Posal_Select += parseInt(theGridView.rows[i].cells[7].textContent);
                    Customer_Select += parseInt(theGridView.rows[i].cells[8].textContent);
                    Vattax_Select += parseInt(theGridView.rows[i].cells[9].textContent);
                }
                Posal += parseInt(theGridView.rows[i].cells[7].textContent);
                Customer += parseInt(theGridView.rows[i].cells[8].textContent);
                Vattax += parseInt(theGridView.rows[i].cells[9].textContent);
            }
        }


        if (document.getElementById('dgBarcodeListWithPostalCost') != null)
            document.getElementById('ctl11_txtPrice').value = Posal_Select;

        if (document.getElementById('dgBarcodeListWithOutPostalCost') != null)
            document.getElementById('ctl11_txtPrice').value = Customer_Select;


        document.getElementById('ctl11_lblSumPostal_All').textContent = Posal.toLocaleString();
        document.getElementById('ctl11_lblSumCustomer_All').textContent = Customer.toLocaleString();
        document.getElementById('ctl11_lblSumVatTax_All').textContent = Vattax.toLocaleString();
        document.getElementById('ctl11_lblSumPrice_All').textContent = (Posal + Customer + Vattax).toLocaleString();

        document.getElementById('ctl11_lblSumPostal_Select').textContent = Posal_Select.toLocaleString();
        document.getElementById('ctl11_lblSumCustomer_Select').textContent = Customer_Select.toLocaleString();
        document.getElementById('ctl11_lblSumVatTax_Select').textContent = Vattax_Select.toLocaleString();
        document.getElementById('ctl11_lblSumPrice_Select').textContent = (Posal_Select + Customer_Select + Vattax_Select).toLocaleString();
    }



    $(document).ready(function () {
        $("#<%=this.ddlMovazehSearch.ClientID%>").multiselect({
            enableFiltering: true

        });
    });

    function test() {

        $("#<%=this.ddlTypePrice.ClientID%>").selectpicker();
        $("#<%=this.ddlSearechPostReceiptSeri.ClientID%>").selectpicker();
        $("#<%=this.ddlReceiptType.ClientID%>").selectpicker();
        $("#<%=this.ddl_bank.ClientID%>").selectpicker();
        $("#<%=this.ddlSeri.ClientID%>").selectpicker();
        $("#<%=this.ddlMovazehSearch.ClientID%>").selectpicker();

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

        $("#<%=this.Fdate.ClientID%>").MdPersianDateTimePicker({
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

        $("#<%=this.Ldate.ClientID%>").MdPersianDateTimePicker({
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
    }

    function FillHiddenField() {

        document.getElementById('hfMovazeh').value = $("#<%=this.ddlMovazehSearch.ClientID%>").val();

    }

    function CheckAll_Approved(chk) {
        all = document.getElementsByTagName("input");
        for (i = 0; i < all.length; i++) {
            if (all[i].type == "checkbox" && all[i].name.indexOf("dgBarcodeList") > -1 && all[i].name.indexOf("chkSelect") > -1) {
                if (all[i].disabled == false)
                    all[i].checked = chk.checked;
            }
        }
        calculateTotal();
    }   
</script>--%>

<div class=" col-sm-9">
    <div class="panel panel-primary small  " >
        <div class="panel-heading ">
            ثبت درخواست حذف بارکد 
        </div>
        <div class="panel-body" >
            
                <div class="input-group col-xs-12 col-md-8 col-lg-12" dir="rtl">
                    <uc:AlertControl runat="server" ID="ucAlertControl" />
                </div>
            
            <div class="row  list-inline ">

            <div  id="trBarcode" class="input-group col-xs-11 col-md-6 col-lg-4" style="padding-right:5px;">
                <asp:Label ID="lblBarcode" Text="بارکد" class="" runat="server" Font-Size="13px" />
                <asp:TextBox ID="txtBarcode" runat="server" class="form-control input-sm  " MaxLength="24" />
            </div>

                <div id="trDescription" class="input-group col-xs-11 col-md-6 col-lg-5" style="padding-right:5px;">
                    <asp:Label ID="lblDescription" Text="توضیحات :" runat="server" Font-Size="13px" />
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Style="resize: none; margin: 0px; padding: 1px;" 
                        class="form-control input-sm" Rows=1 ToolTip="توضیحات"  MaxLength="2000" />
                </div>
                <div class="input-group col-xs-11 col-sm-9 col-md-6 col-lg-2" >
                <asp:Button ID="btnSave" runat="server" Text="ثبت" 
                        CssClass="btn btn-success btn btn-success col-xs-12 " onclick="btnSave_Click"/>
                </div>
            </div>
        </div>
    </div>
</div>

