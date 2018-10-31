
//function test() {

//    if (document.getElementById('ctl11_ddlTypePrice') != null)
//        $('#<%=this.ddlTypePrice.ClientID%>').selectpicker();

//    if (document.getElementById('ctl11_ddlSearechPostReceiptSeri') != null)
//        $('#<%=this.ddlSearechPostReceiptSeri.ClientID%>').selectpicker();

//    if (document.getElementById('ctl11_ddlReceiptType') != null)
//        $('#<%=this.ddlReceiptType.ClientID%>').selectpicker();

//    if (document.getElementById('ctl11_ddl_bank') != null)
//        $('#<%=this.ddl_bank.ClientID%>').selectpicker();

//    if (document.getElementById('ctl11_ddlSeri') != null)
//        $('#<%=this.ddlSeri.ClientID%>').selectpicker();

//    if (document.getElementById('ctl11_ddlMovazehSearch') != null)
//        $('#<%=this.ddlMovazehSearch.ClientID%>').selectpicker();

//    if (document.getElementById('ctl11_ddlMovazehSearch') != null)
//        $('#<%=this.ddlMovazehSearch.ClientID%>').multiselect({
//            enableFiltering: true
//        });

//    if (document.getElementById('ctl11_DateSelector1') != null)
//        $('#<%=this.DateSelector1.ClientID%>').MdPersianDateTimePicker({
//            Placement: 'left',
//            Trigger: 'focus',
//            EnableTimePicker: false,
//            TargetSelector: '',
//            GroupId: '',
//            ToDate: false,
//            FromDate: false,
//            EnglishNumber: true,
//            Disabled: false
//        });

//    if (document.getElementById('ctl11_Fdate') != null)
//        $('#<%=this.Fdate.ClientID%>').MdPersianDateTimePicker({
//            Placement: 'left',
//            Trigger: 'focus',
//            EnableTimePicker: false,
//            TargetSelector: '#ctl11_Fdate',
//            GroupId: 'group1',
//            ToDate: false,
//            FromDate: true,
//            EnglishNumber: true,
//            Disabled: false
//        });

//    if (document.getElementById('ctl11_Ldate') != null)
//        $('#<%=this.Ldate.ClientID%>').MdPersianDateTimePicker({
//            Placement: 'left',
//            Trigger: 'focus',
//            EnableTimePicker: false,
//            TargetSelector: '#ctl11_Ldate',
//            GroupId: 'group1',
//            ToDate: true,
//            FromDate: false,
//            EnglishNumber: true,
//            Disabled: false
//        });
//}

//function BarcodeReader() {
//    var theGridView
//    var BarcodeForSearch = document.getElementById('ctl11_txtBarcodeSearch').value;
//    if (BarcodeForSearch.length == 24 || BarcodeForSearch.length == 20 || BarcodeForSearch.length == 13) {


//        if (document.getElementById('dgBarcodeListWithPostalCost') != null)
//            theGridView = document.getElementById('dgBarcodeListWithPostalCost');
//        if (document.getElementById('dgBarcodeListWithOutPostalCost') != null)
//            theGridView = document.getElementById('dgBarcodeListWithOutPostalCost');

//        for (i = 1; i < theGridView.rows.length; i++) {
//            var BarcodeInTable = theGridView.rows[i].cells[2].textContent;
//            if (BarcodeInTable != null) {
//                if (BarcodeInTable.toString() == BarcodeForSearch.toString()) {
//                    var chkType = theGridView.rows[i].cells[1].children[0];
//                    if (chkType.type == 'checkbox') { theGridView.rows[i].cells[1].children[0].checked = true; }
//                }
//            }
//        }
//    }
//}

///////////////////////////////////////////////////////////////////////////////////////    ///////////////////////////////////////////////////////////////////////////////////
//function MycalculateTotal() {

//    var Posal = 0;
//    var Customer = 0;
//    var Vattax = 0;

//    var Posal_Select = 0;
//    var Customer_Select = 0;
//    var Vattax_Select = 0;

//    var theGridView

//    document.getElementById('ctl11_txtPrice').value = 0;

//    if (document.getElementById('dgBarcodeListWithPostalCost') != null)
//        theGridView = document.getElementById('dgBarcodeListWithPostalCost');

//    if (document.getElementById('dgBarcodeListWithOutPostalCost') != null)
//        theGridView = document.getElementById('dgBarcodeListWithOutPostalCost');

//    for (i = 1; i < theGridView.rows.length; i++) {

//        var chkType = theGridView.rows[i].cells[1].children[0];
//        if (chkType.type == 'checkbox') {
//            if (chkType.checked) {

//                Posal_Select += parseInt(theGridView.rows[i].cells[7].textContent);
//                Customer_Select += parseInt(theGridView.rows[i].cells[8].textContent);
//                Vattax_Select += parseInt(theGridView.rows[i].cells[9].textContent);
//            }
//            Posal += parseInt(theGridView.rows[i].cells[7].textContent);
//            Customer += parseInt(theGridView.rows[i].cells[8].textContent);
//            Vattax += parseInt(theGridView.rows[i].cells[9].textContent);
//        }
//    }


//    if (document.getElementById('dgBarcodeListWithPostalCost') != null)
//        document.getElementById('ctl11_txtPrice').value = Posal_Select;

//    if (document.getElementById('dgBarcodeListWithOutPostalCost') != null)
//        document.getElementById('ctl11_txtPrice').value = Customer_Select;


//    document.getElementById('ctl11_lblSumPostal_All').textContent = Posal.toLocaleString();
//    document.getElementById('ctl11_lblSumCustomer_All').textContent = Customer.toLocaleString();
//    document.getElementById('ctl11_lblSumVatTax_All').textContent = Vattax.toLocaleString();
//    document.getElementById('ctl11_lblSumPrice_All').textContent = (Posal + Customer + Vattax).toLocaleString();

//    document.getElementById('ctl11_lblSumPostal_Select').textContent = Posal_Select.toLocaleString();
//    document.getElementById('ctl11_lblSumCustomer_Select').textContent = Customer_Select.toLocaleString();
//    document.getElementById('ctl11_lblSumVatTax_Select').textContent = Vattax_Select.toLocaleString();
//    document.getElementById('ctl11_lblSumPrice_Select').textContent = (Posal_Select + Customer_Select + Vattax_Select).toLocaleString();
//}

///////////////////////////////////////////////////////////////
//function calculateTotal() {

//    var Posal = 0;
//    var Customer = 0;
//    var Vattax = 0;
//    var Posal_Select = 0;
//    var Customer_Select = 0;
//    var Vattax_Select = 0;
//    var theGridView
//    if ((document.getElementById('dgBarcodeListWithOutPostalCost') != null) || (document.getElementById('dgBarcodeListWithPostalCost') != null)) {
//        document.getElementById('ctl11_txtPrice').value = 0;

//        if (document.getElementById('dgBarcodeListWithPostalCost') != null)
//            theGridView = document.getElementById('dgBarcodeListWithPostalCost');

//        if (document.getElementById('dgBarcodeListWithOutPostalCost') != null)
//            theGridView = document.getElementById('dgBarcodeListWithOutPostalCost');

//        for (i = 1; i < theGridView.rows.length; i++) {

//            var chkType = theGridView.rows[i].cells[1].children[0];
//            if (chkType.type == 'checkbox') {
//                if (chkType.checked) {

//                    Posal_Select += parseInt(theGridView.rows[i].cells[7].textContent);
//                    Customer_Select += parseInt(theGridView.rows[i].cells[8].textContent);
//                    Vattax_Select += parseInt(theGridView.rows[i].cells[9].textContent);
//                }
//                Posal += parseInt(theGridView.rows[i].cells[7].textContent);
//                Customer += parseInt(theGridView.rows[i].cells[8].textContent);
//                Vattax += parseInt(theGridView.rows[i].cells[9].textContent);
//            }
//        }


//        if (document.getElementById('dgBarcodeListWithPostalCost') != null)
//            document.getElementById('ctl11_txtPrice').value = Posal_Select;

//        if (document.getElementById('dgBarcodeListWithOutPostalCost') != null)
//            document.getElementById('ctl11_txtPrice').value = Customer_Select;


//        document.getElementById('ctl11_lblSumPostal_All').textContent = Posal.toLocaleString();
//        document.getElementById('ctl11_lblSumCustomer_All').textContent = Customer.toLocaleString();
//        document.getElementById('ctl11_lblSumVatTax_All').textContent = Vattax.toLocaleString();
//        document.getElementById('ctl11_lblSumPrice_All').textContent = (Posal + Customer + Vattax).toLocaleString();

//        document.getElementById('ctl11_lblSumPostal_Select').textContent = Posal_Select.toLocaleString();
//        document.getElementById('ctl11_lblSumCustomer_Select').textContent = Customer_Select.toLocaleString();
//        document.getElementById('ctl11_lblSumVatTax_Select').textContent = Vattax_Select.toLocaleString();
//        document.getElementById('ctl11_lblSumPrice_Select').textContent = (Posal_Select + Customer_Select + Vattax_Select).toLocaleString();
//    }
//}
/////////////////////////////////////////////////////////////////////////////////////    ///////////////////////////////////////////////////////////////////////////////////    
//function Mytest() {

//    $('#<%=this.ddlTypePrice.ClientID%>').selectpicker();
//    $('#<%=this.ddlSearechPostReceiptSeri.ClientID%>').selectpicker();
//    $('#<%=this.ddlReceiptType.ClientID%>').selectpicker();
//    $('#<%=this.ddl_bank.ClientID%>').selectpicker();
//    $('#<%=this.ddlSeri.ClientID%>').selectpicker();
//    $('#<%=this.ddlMovazehSearch.ClientID%>').selectpicker();

//    $('#<%=this.DateSelector1.ClientID%>').MdPersianDateTimePicker({
//        Placement: 'left',
//        Trigger: 'focus',
//        EnableTimePicker: false,
//        TargetSelector: '',
//        GroupId: '',
//        ToDate: false,
//        FromDate: false,
//        EnglishNumber: true,
//        Disabled: false
//    });

//    $('#<%=this.Fdate.ClientID%>').MdPersianDateTimePicker({
//        Placement: 'left',
//        Trigger: 'focus',
//        EnableTimePicker: false,
//        TargetSelector: '#ctl11_Fdate',
//        GroupId: 'group1',
//        ToDate: false,
//        FromDate: true,
//        EnglishNumber: true,
//        Disabled: false
//    });

//    $('#<%=this.Ldate.ClientID%>').MdPersianDateTimePicker({
//        Placement: 'left',
//        Trigger: 'focus',
//        EnableTimePicker: false,
//        TargetSelector: '#ctl11_Ldate',
//        GroupId: 'group1',
//        ToDate: true,
//        FromDate: false,
//        EnglishNumber: true,
//        Disabled: false
//    });
//}

///////////////////////////////////////////////////////////////////////////////////////    ///////////////////////////////////////////////////////////////////////////////////    

//function MyCheckAll_Approved(chk) {
//    all = document.getElementsByTagName('input');
//    for (i = 0; i < all.length; i++) {
//        if (all[i].type == 'checkbox' && all[i].name.indexOf('dgBarcodeList') > -1 && all[i].name.indexOf('chkSelect') > -1) {
//            if (all[i].disabled == false)
//                all[i].checked = chk.checked;
//        }
//    }
//    calculateTotal();
//}





















function ModifyEnterKeyPress() {
    if (window.event && window.event.keyCode == 13) {
        BarcodeReader();
        test();
        window.event.keyCode = null;
    }
}
function BarcodeReader() {
    var theGridView
    if (document.getElementById('#ctl11_txtBarcodeSearch') != null) {
        var BarcodeForSearch = document.getElementById('#ctl11_txtBarcodeSearch').value;
        if (BarcodeForSearch.length == 24 || BarcodeForSearch.length == 20 || BarcodeForSearch.length == 13) {
            if (document.getElementById('#dgBarcodeListWithPostalCost') != null)
                theGridView = document.getElementById('#dgBarcodeListWithPostalCost');
            if (document.getElementById('#dgBarcodeListWithOutPostalCost') != null)
                theGridView = document.getElementById('#dgBarcodeListWithOutPostalCost');
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

    if (document.getElementById('#dgBarcodeListWithPostalCost') != null || document.getElementById('#dgBarcodeListWithOutPostalCost') != null) {

        if (document.getElementById('#ctl11_txtPrice') != null)
            document.getElementById('#ctl11_txtPrice').value = 0;

        if (document.getElementById('#dgBarcodeListWithPostalCost') != null)
            theGridView = document.getElementById('#dgBarcodeListWithPostalCost');

        if (document.getElementById('#dgBarcodeListWithOutPostalCost') != null)
            theGridView = document.getElementById('#dgBarcodeListWithOutPostalCost');
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

        if (document.getElementById('#dgBarcodeListWithPostalCost') != null)
            document.getElementById('#ctl11_txtPrice').value = Posal_Select;

        if (document.getElementById('#dgBarcodeListWithOutPostalCost') != null)
            document.getElementById('#ctl11_txtPrice').value = Customer_Select;

        if (document.getElementById('#ctl11_lblCount_Value') != null)
            document.getElementById('#ctl11_lblCount_Value').textContent = Counter.toLocaleString();

        if (document.getElementById('#ctl11_lblSumPostal_All') != null)
            document.getElementById('#ctl11_lblSumPostal_All').textContent = Posal.toLocaleString();
        if (document.getElementById('#ctl11_lblSumCustomer_All') != null)
            document.getElementById('#ctl11_lblSumCustomer_All').textContent = Customer.toLocaleString();
        if (document.getElementById('#ctl11_lblSumVatTax_All') != null)
            document.getElementById('#ctl11_lblSumVatTax_All').textContent = Vattax.toLocaleString();
        if (document.getElementById('#ctl11_lblSumPrice_All') != null)
            document.getElementById('#ctl11_lblSumPrice_All').textContent = (Posal + Customer + Vattax).toLocaleString();

        if (document.getElementById('#ctl11_lblSumPostal_Select') != null)
            document.getElementById('#ctl11_lblSumPostal_Select').textContent = Posal_Select.toLocaleString();
        if (document.getElementById('#ctl11_lblSumCustomer_Select') != null)
            document.getElementById('#ctl11_lblSumCustomer_Select').textContent = Customer_Select.toLocaleString();
        if (document.getElementById('#ctl11_lblSumVatTax_Select') != null)
            document.getElementById('#ctl11_lblSumVatTax_Select').textContent = Vattax_Select.toLocaleString();
        if (document.getElementById('#ctl11_lblSumPrice_Select') != null)
            document.getElementById('#ctl11_lblSumPrice_Select').textContent = (Posal_Select + Customer_Select + Vattax_Select).toLocaleString();
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
            document.getElementById('#hfMovazeh').value = $('#<%=this.ddlMovazehSearch.ClientID%>').val();
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
