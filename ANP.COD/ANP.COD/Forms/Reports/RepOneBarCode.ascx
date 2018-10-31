<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RepOneBarCode.ascx.cs" Inherits="ANP.COD.Forms.Reports.RepOneBarCode" %>

<%@ Import Namespace="ANP.COD" %>
<%@ Import Namespace="System.Data" %>

<script src="../../Scripts/jquery-2.1.4.js" type="text/javascript"></script>
<link href="../../Content/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="../../Content/Report.css" rel="stylesheet" type="text/css" />
<style type="text/css" media="print">
    @page
    {
        size: landscape;
    }
</style>
<script type="text/javascript">
    function printer(_div) {
        var prtContent = document.getElementById(_div);
        var WinPrint = window.open('', '', 'left=0,top=0,width=1000,height=900,toolbar=0,scrollbars=0,status=0');
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
</span>
<asp:UpdatePanel runat="server" ID="up" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="print" class="container col-xs-12" style="overflow: auto; height: 400px;">

<style type="text/css">

     #ReportTable td ,#ReportTable th  
    {
        color:Black;
        height:30px; 
        text-align:center;
        background-color:#EEE;   
        border-style:solid;
        border-width:1px;
        border-color:Black;
        padding-left:5px;	 
        padding-right:5px;	 
    }

</style>
            <div id="tbl_rpt" class="row">
                <div >
                    <table  border="0" cellpadding="0" cellspacing="0" id="ReportTable"
                     class="col-md-12 table-bordered table-striped table-condensed ">
                        <thead >
                            <tr>
                                <th colspan="13" style="font-family:B Nazanin; font-size:14px; font-weight:bold;">
                                    مرسولات کرایه در مقصد
                                </th>
                            </tr>
                            <tr>
                                <th colspan="6"  style="font-family:B Nazanin; font-size:14px; font-weight:normal;  border-left-style:none; text-align:left;">
                                    گزارش جزئیات مرسولات
                                </th>
                                <th  colspan="7" data-title="Code" style=" border-style:none; color:Red; border-left-style:solid;  text-align:left;">
                                    <%Response.Write(IsDeleted.ToString()); %>
                                </th>
                            </tr>
                            <tr  style="font-family:B Nazanin; font-size:12px; font-weight:bold;">
                                <th>
                                    ردیف
                                </th>
                                <th>
                                    بارکد
                                </th>
                                <th>
                                    نقطه پستی
                                </th>
                                <th>
                                   مبدا
                                </th>
                                <th>
                                    مقصد
                                </th>
                                <th>
                                    کاربر
                                </th>
                                <th>
                                    وضعیت
                                </th>
                                <th>
                                    تاریخ
                                </th>
                                <th>
                                    ح س پست
                                </th>
                                <th>
                                    ط قرارداد
                                </th>
                                <th>
                                    مالیات
                                </th>
                                <th>
                                    شماره فیش/چک
                                </th>
                                <th>
                                    تاریخ ثبت
                                </th>
                            </tr>
                        </thead>
                        <tbody >
                            <% if (dtReport.Rows.Count > 0)
                               {
                                   foreach (DataRow dr in dtReport.Rows)
                                   { %>
                            <tr style="font-family:B Nazanin; font-size:13px; font-weight:normal; " >
                                <td data-title="Code">
                                    <%Response.Write(dr["RowNum"].ToString()); %>
                                </td>
                                <td data-title="Code">
                                    <%Response.Write(dr["Barcode"].ToString()); %>
                                </td>
                                <td data-title="Code">
                                    <%Response.Write(dr["PostNodeName"].ToString()); %>
                                </td>
                                <td data-title="Code">
                                    <%Response.Write(dr["Era"].ToString()); %>
                                </td>
                                <td data-title="Code">
                                    <%Response.Write(dr["Aim"].ToString()); %>
                                </td>
                                <td data-title="Code">
                                    <%Response.Write(dr["UserName"].ToString()); %>
                                </td>
                                <td data-title="Code">
                                    <%Response.Write(dr["Status"].ToString()); %>
                                </td>
                                <td data-title="Code">
                                    <%Response.Write(dr["DateStatus"].ToString()); %>
                                </td>
                                <td data-title="Code">
                                    <%Response.Write(dr["PostalCost"].ToString()); %>
                                </td>
                                <td data-title="Code">
                                    <%Response.Write(dr["CustomerCost"].ToString()); %>
                                </td>
                                <td data-title="Code">
                                    <%Response.Write(dr["VatTax"].ToString()); %>
                                </td>
                                <td data-title="Code">
                                    <%Response.Write(dr["ReceiptNO"].ToString()); %>
                                </td>
                                <td data-title="Code">
                                    <%Response.Write(dr["PayDate"].ToString()); %>
                                </td>
                            </tr>
                            <% }
                        } %>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
