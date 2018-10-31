<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RepGhaboolAndMobadeleh.ascx.cs" Inherits="ANP.COD.Forms.Reports.RepGhaboolAndMobadeleh" %>



<%@ Import Namespace="ANP.COD" %>
<%@ Import Namespace="System.Data" %>
<script src="../../Scripts/jquery-2.1.4.js" type="text/javascript"></script>
<link href="../../Content/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="../../Content/Report.css" rel="stylesheet" type="text/css" />
<style type="text/css" media="print">
    @page
    {
    	overflow:scroll;
    }
</style>
<script type="text/javascript">
    function printer(_div) {
        var prtContent = document.getElementById(_div);
        var WinPrint = window.open('', '', 'left=0,top=0,width=auto,height=auto,toolbar=0,scrollbars=1,status=0,');
        WinPrint.document.write(prtContent.innerHTML);
        WinPrint.document.dir = "rtl";
        WinPrint.document.close();
        WinPrint.focus();
        WinPrint.print();
        WinPrint.close();
    }
</script>
<script type="text/javascript">
    var tableToExcel = (function () {
        var uri = 'data:application/vnd.ms-excel;base64,'
                , template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table>{table}</table></body></html>'
                , base64 = function (s) { return window.btoa(unescape(encodeURIComponent(s))) }
                , format = function (s, c) { return s.replace(/{(\w+)}/g, function (m, p) { return c[p]; }) }
        return function (table, name) {
            if (!table.nodeType) table = document.getElementById(table)
            var ctx = { worksheet: name || 'Worksheet', table: table.innerHTML }
            window.location.href = uri + base64(format(template, ctx))
        }
    })()

</script>
<br />
<span >
    <img src="../../Images/print.png" alt="print" onclick="printer('print');" style="height: 25px;
        width: 25px" />&nbsp;
    <img src="../../Images/excel.png" alt="Excel" onclick="tableToExcel('tbl_rpt', 'W3C Example Table')" style="height: 25px;
        width: 25px"/>
    <asp:LinkButton ID="lnkDownloadDetail" Text="دانلود جزئیات مرسولات" 
    runat="server" onclick="lnkDownloadDetail_Click" />
</span>
<asp:UpdatePanel runat="server" ID="up" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="print" style="overflow:auto; min-height: 209px;">

<style type="text/css">

     #ReportTable td ,#ReportTable th  
    {
        color:Black;
        height:30px; 
        text-align:center;k
        background-color:#EEE;    
        border-style:solid;
        border-width:1px;
        border-color:Black;
        padding-left:5px;	 
        padding-right:5px;	 
        margin:15px;
    }

</style>

            <div id="tbl_rpt">
                <div>
                    <table id="ReportTable" border="0" cellpadding="0" cellspacing="0"
                     class="col-sm-9 table-bordered table-striped table-condensed ">
                        <thead class="cf">
                            <tr>
                                <th colspan="74" style="font-family:B Nazanin; font-size:22px; font-weight:bold;">
                                    مرسولات کرایه در مقصد
                                </th>
                            </tr>
                            <tr>
                                <th colspan="10" data-title="Code" style="font-family:B Nazanin; font-size:18px; font-weight:bold;">
                                      <%Response.Write(param.FirstDate + " الی " + param.LastDate); %>
                                </th>
                                <th colspan="48"  style="font-family:B Nazanin; font-size:18px; font-weight:bold;">
                                    گزارش موازنه قبول با مبادله 
                                </th>
                                <th colspan="16" data-title="Code" style="font-family:B Nazanin; font-size:18px; font-weight:bold;">
                                      <%Response.Write(StateName + "--" + CityName+ "--" + PostNode_Name); %>
                                </th>
                            </tr>
                            <tr>
                                <th colspan="14" data-title="Code" style="font-family:B Nazanin; font-size:16px; font-weight:bold;">
                                     بررسی ترافیک مرسولات
                                </th>
                                <th colspan="28"  style="font-family:B Nazanin; font-size:16px; font-weight:bold;">
                                                                         بررسی وضعیت مرسولات 
                                </th>
                                <th colspan="28" data-title="Code" style="font-family:B Nazanin; font-size:16px; font-weight:bold;">
                                    بررسی وضعیت مالی مرسولات  
                                </th>
                                <th colspan="4" data-title="Code" style="font-family:B Nazanin; font-size:16px; font-weight:bold;">
                                    &nbsp;حذف شده
                                </th>
                            </tr>
                            <tr>
                                <th colspan="2"  style="font-family:B Nazanin; font-size:14px; font-weight:normal;">
                                </th>
                                <th colspan="4"  style="font-family:B Nazanin; font-size:14px; font-weight:normal;">
                                    مرسولات قبول شده
                                </th>
                                <th colspan="4"  style="font-family:B Nazanin; font-size:14px; font-weight:normal;">
                                    بارکد مخدوش
                                </th>
                                <th colspan="4"  style="font-family:B Nazanin; font-size:14px; font-weight:normal;">
                                    مرسولات حذف شده فعال در شبکه
                                </th>
                                <th colspan="4"  style="font-family:B Nazanin; font-size:14px; font-weight:normal;">
                                   تعیین وضعیت نشده
                                </th>
                                <th colspan="4"  style="font-family:B Nazanin; font-size:14px; font-weight:normal;">
                                    تعداد مرسولات باجه معطله
                                </th>
                                <th colspan="4"  style="font-family:B Nazanin; font-size:14px; font-weight:normal;">
                                    تعداد مرسولات برگشتی
                                </th>
                                <th colspan="4"  style="font-family:B Nazanin; font-size:14px; font-weight:normal;">
                                    غیر قابل توزیع
                                </th>
                                
                                <th colspan="4"  style="font-family:B Nazanin; font-size:14px; font-weight:normal;">
                                    بلاتکلیف
                                </th>
                                <th colspan="4"  style="font-family:B Nazanin; font-size:14px; font-weight:normal;">
                                    قبض دوم
                                </th>
                                <th colspan="4"  style="font-family:B Nazanin; font-size:14px; font-weight:normal;">
                                    مرسولات تحویل شده
                                </th>
                                <th colspan="4"  style="font-family:B Nazanin; font-size:14px; font-weight:normal;">
                                    تسویه شده
                                </th>
                                <th colspan="4"  style="font-family:B Nazanin; font-size:14px; font-weight:normal;">
                                    تسویه نشده
                                </th>

                                <th colspan="4"  style="font-family:B Nazanin; font-size:14px; font-weight:normal;">
                                    تحویلی - بدون ثبت فیش
                                </th>
                                <th colspan="4"  style="font-family:B Nazanin; font-size:14px; font-weight:normal; ">
                                    تحویلی _عدم ارسال فیش به مالی
                                </th>
                                <th colspan="4"  style="font-family:B Nazanin; font-size:14px; font-weight:normal; ">
                                    &nbsp;تحویلی - عدم تایید فیش توسط مالی</th>
                                <th colspan="4"  style="font-family:B Nazanin; font-size:14px; font-weight:normal;">
                                    بررسی فیش توسط مالی
                                </th>
                                <th colspan="4"  style="font-family:B Nazanin; font-size:14px; font-weight:normal;">
                                     تایید فیش توسط مالی</th>
                                <th colspan="4"  style="font-family:B Nazanin; font-size:14px; font-weight:normal;">
                                    مرسولات حذف شده
                                </th>
                                
                            </tr>
                            <tr style="font-family:B Nazanin; font-size:12px; font-weight:bold;">
                                <th> 
                                    ردیف
                                </th>
                                <th>
                                    نام استان
                                </th>
                                <th>
                                    تعداد
                                </th>
                                <th>
                                    ح س پست
                                </th>
                                <th>
                                    طرف قرارداد
                                </th>
                                <th>
                                        مالیات
                                </th>
                                <th>
                                    تعداد
                                </th>
                                <th>
                                    ح س پست
                                </th>
                                <th>
                                    طرف قرارداد
                                </th>
                                <th>
                                        مالیات
                                </th>
                                <th>
                                    تعداد
                                </th>
                                <th>
                                    ح س پست
                                </th>
                                <th>
                                    طرف قرارداد
                                </th>
                                <th>
                                        مالیات
                                </th>
                                <th>
                                    تعداد
                                </th>
                                <th>
                                    ح س پست
                                </th>
                                <th>
                                    طرف قرارداد
                                </th>
                                <th>
                                        مالیات
                                </th><th>
                                    تعداد
                                </th>
                                <th>
                                    ح س پست
                                </th>
                                <th>
                                    طرف قرارداد
                                </th>
                                <th>
                                        مالیات
                                </th>
                                <th>
                                    تعداد
                                </th>
                                <th>
                                    ح س پست
                                </th>
                                <th>
                                    طرف قرارداد
                                </th>
                                <th>
                                        مالیات
                                </th>
                                <th>
                                    تعداد
                                </th>
                                <th>
                                    ح س پست
                                </th>
                                <th>
                                    طرف قرارداد
                                </th>
                                <th>
                                        مالیات
                                </th>
                                <th>
                                    تعداد
                                </th>
                                <th>
                                    ح س پست
                                </th>
                                <th>
                                    طرف قرارداد
                                </th>
                                <th>
                                        مالیات
                                </th>
                                <th>
                                    تعداد
                                </th>
                                <th>
                                    ح س پست
                                </th>
                                <th>
                                    طرف قرارداد
                                </th>
                                <th>
                                        مالیات
                                </th>
                                <th>
                                    تعداد
                                </th>
                                <th>
                                    ح س پست
                                </th>
                                <th>
                                    طرف قرارداد
                                </th>
                                <th>
                                        مالیات
                                </th>
                                <th>
                                    تعداد
                                </th>
                                <th>
                                    ح س پست
                                </th>
                                <th>
                                    طرف قرارداد
                                </th>
                                <th>
                                      مالیات  
                                </th>
                                <th>
                                    تعداد
                                </th>
                                <th>
                                    ح س پست
                                </th>
                                <th>
                                    طرف قرارداد
                                </th>
                                <th>
                                      مالیات  
                                </th>
                                <th>
                                    تعداد
                                </th>
                                <th>
                                    ح س پست
                                </th>
                                <th>
                                    طرف قرارداد
                                </th>
                                <th>
                                      مالیات  
                                </th>
                                <th>
                                    تعداد
                                </th>
                                <th>
                                    ح س پست
                                </th>
                                <th>
                                    طرف قرارداد
                                </th>
                                <th>
                                      مالیات  
                                </th>
                                <th>
                                    تعداد
                                </th>
                                <th>
                                    ح س پست
                                </th>
                                <th>
                                    طرف قرارداد
                                </th>
                                <th>
                                      مالیات  
                                </th>
                                <th>
                                    تعداد
                                </th>
                                <th>
                                    ح س پست
                                </th>
                                <th>
                                    طرف قرارداد
                                </th>
                                <th>
                                      مالیات  
                                </th>
                                <th>
                                    تعداد
                                </th>
                                <th>
                                    ح س پست
                                </th>
                                <th>
                                    طرف قرارداد
                                </th>
                                <th>
                                      مالیات  
                                </th>
                                <th>
                                    تعداد
                                </th>
                                <th>
                                    ح س پست
                                </th>
                                <th>
                                    طرف قرارداد
                                </th>
                                <th>
                                      مالیات  
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <% if (dtReport.Rows.Count > 0)
                               {
                                   foreach (DataRow dr in dtReport.Rows)
                                   {
                            %>
                            <tr style="font-family:B Nazanin; font-size:13px; font-weight:normal; ">
                                <td data-title="Code" class="style1">
                                    <%Response.Write(dr["RowNum"].ToString()); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(dr["LastStateName"].ToString()); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["GhaboolShodeh_Count"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["GhaboolShodeh_PostalCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["GhaboolShodeh_CustomerCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["GhaboolShodeh_Vattax"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["Makhdoosh_Count"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["Makhdoosh_PostalCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["Makhdoosh_CustomerCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["Makhdoosh_Vattax"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["HazfShode_Faal_Count"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["HazfShode_Faal_PostalCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["HazfShode_Faal_CustomerCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["HazfShode_Faal_Vattax"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TaeenVazeatNaShodeh_Count"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TaeenVazeatNaShodeh_PostalCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TaeenVazeatNaShodeh_CustomerCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TaeenVazeatNaShodeh_Vattax"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["Moatal_Count"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["Moatal_PostalCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["Moatal_CustomerCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["Moatal_Vattax"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["Return_Count"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["Return_PostalCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["Return_CustomerCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["Return_Vattax"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["GherGhabelTozee_Count"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["GherGhabelTozee_PostalCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["GherGhabelTozee_CustomerCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["GherGhabelTozee_Vattax"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["Belatklif_Count"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["Belatklif_PostalCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["Belatklif_CustomerCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["Belatklif_Vattax"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["GhabzDovom_Count"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["GhabzDovom_PostalCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["GhabzDovom_CustomerCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["GhabzDovom_Vattax"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["Tahvil_Count"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["Tahvil_PostalCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["Tahvil_CustomerCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["Tahvil_Vattax"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehShode_Count"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehShode_PostalCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehShode_CustomerCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehShode_Vattax"].ToString()).ToString("#,##0")); %>
                                </td>
                                 <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehNaShode_Count"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehNaShode_PostalCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehNaShode_CustomerCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehNaShode_Vattax"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehNaShode_BedonFish_Count"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehNaShode_BedonFish_PostalCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehNaShode_BedonFish_CustomerCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehNaShode_BedonFish_Vattax"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehNaShode_BedoneErsalFish_Count"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehNaShode_BedoneErsalFish_PostalCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehNaShode_BedoneErsalFish_CustomerCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehNaShode_BedoneErsalFish_Vattax"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehNaShode_AdamTaeedMali_Count"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehNaShode_AdamTaeedMali_PostalCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehNaShode_AdamTaeedMali_CustomerCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehNaShode_AdamTaeedMali_Vattax"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehNaShode_BaresiMali_Count"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehNaShode_BaresiMali_PostalCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehNaShode_BaresiMali_CustomerCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehNaShode_BaresiMali_Vattax"].ToString()).ToString("#,##0")); %>
                                </td>
                               <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehShode_Count"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehShode_PostalCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehShode_CustomerCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["TasviehShode_Vattax"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["HazfShodeh_Count"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["HazfShodeh_PostalCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["HazfShodeh_CustomerCost"].ToString()).ToString("#,##0")); %>
                                </td>
                                <td data-title="Code" class="style1">
                                    <%Response.Write(Convert.ToInt64(dr["HazfShodeh_Vattax"].ToString()).ToString("#,##0")); %>
                                </td>




                                
                                
                            </tr>
                            <% }} %>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>

<asp:HiddenField ID="hfParamGhaboolMobadeleh" runat="server" ClientIDMode="Static" />
