<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RepDebitForState.ascx.cs"
    Inherits="ANP.COD.Forms.Reports.RepDebitForState" %>
<%@ Register Src="../../Controls/AlertControl.ascx" TagPrefix="uc" TagName="AlertControl" %>
<%@ Import Namespace="ANP.COD" %>
<%@ Import Namespace="System.Data" %>
<link href="../../Content/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="../../Content/bootstrap-select.css" rel="stylesheet" type="text/css" />
<link href="../../Content/MyStyle.css" rel="stylesheet" type="text/css" />
<link href="../../Content/Report.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">

    function Test() {

        $("#<%=this.ddlState.ClientID%>").selectpicker();
        $("#<%=this.ddlCity.ClientID%>").selectpicker();
        $("#<%=this.ddlPostNode.ClientID%>").selectpicker();
        $("#<%=this.ddlLastState.ClientID%>").selectpicker();
        $("#<%=this.ddlBarcodeStatus.ClientID%>").selectpicker();

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

</script>
<script type="text/javascript">
    function FillHiddenField() {
        document.getElementById('hfStateList').value = $("#<%=this.ddlBarcodeStatus.ClientID%>").val();   
    }
    $(document).ready(function () {
        $("#<%=this.ddlState.ClientID%>").multiselect({
            enableFiltering: true
        });
    });
</script>

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
        var uri = 'data:application/vnd.ms-excel;charset=utf-8;base64,'
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

<script type="text/javascript">
    $(document).ready(function () {
        $("#excelFile").click(function (e) {
            window.open('data:application/vnd.ms-excel,' + encodeURIComponent($('div[id$=tbl_rpt]').html()));
            e.preventDefault();
        });
    });
</script>
<style type="text/css" media="print">
    @page
    {
        size: landscape;
    }
</style>
<br />
<div class="container col-sm-12  ">
    <div class="panel panel-primary small " style="margin-top: 20px;">
        <div class="panel-heading">
            پنل فیلتر گذاری گزارش مرسوله براساس قبول
        </div>
        <div class="panel-body" style="margin: 0px 20px;">
            <div class="row">
                <div class="input-group col-xs-11 " dir="rtl">
                    <uc:AlertControl runat="server" ID="ucAlertControl" />
                </div>
            </div>
            <div class="row">
                <div id="trState" runat="server" class="input-group col-xs-3 ">
                    <asp:Label ID="lblState" Text="نام استان مبدا:" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:DropDownList ID="ddlState" runat="server" class="form-control input-sm selectpicker pull-right "
                        data-width="220px auto" data-style="btn" AutoPostBack="True" data-size="5" data-live-search="true"
                        OnSelectedIndexChanged="ddlState_SelectedIndexChanged" />
                </div>
                <div runat="server" id="trCity" class="input-group col-xs-3 ">
                    <asp:Label ID="lblCity" Text="نام شهر مبدا:" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:DropDownList ID="ddlCity" runat="server" class="form-control input-sm selectpicker pull-right "
                        data-width="220px auto" data-style="btn" AutoPostBack="True" data-size="5" data-live-search="true"
                        OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" />
                </div>
                <div id="trPostNode" runat="server" class="input-group col-xs-3">
                    <asp:Label ID="lblPostNode" Text="نام نقطه قبول :" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:DropDownList ID="ddlPostNode" runat="server" class="form-control input-sm selectpicker pull-right "
                        data-width="220px auto" data-style="btn" AutoPostBack="false" data-size="5" data-live-search="true" />
                </div>
            </div>
            <div class="row">
                <div id="trLastState" runat="server" class="input-group  col-xs-3 ">
                    <asp:Label ID="lblLastState" Text="نام استان مقصد:" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:DropDownList ID="ddlLastState" runat="server" class="form-control input-sm selectpicker pull-right col-xs-3"
                        data-width="220px auto" data-style="btn" AutoPostBack="true" data-size="5" data-live-search="true"
                        OnSelectedIndexChanged="ddlLastState_SelectedIndexChanged" />
                </div>
                <div runat="server" id="trLastCity" class="input-group col-xs-3 ">
                    <asp:Label ID="Label1" Text="نام شهر مقصد:" class=" pull-right " runat="server" Font-Size="13px" />
                    <asp:DropDownList ID="ddlLastCity" runat="server" class="form-control input-sm selectpicker pull-right "
                        data-width="220px auto" data-style="btn" AutoPostBack="True" data-size="5" data-live-search="true"
                        OnSelectedIndexChanged="ddlLastCity_SelectedIndexChanged" />
                </div>
                <div id="trLastPostNode" runat="server" class="input-group col-xs-3">
                    <asp:Label ID="Label2" Text="نام نقطه مبادله :" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:DropDownList ID="ddlLastPostNode" runat="server" class="form-control input-sm selectpicker pull-right "
                        data-width="220px auto" data-style="btn" AutoPostBack="false" data-size="5" data-live-search="true" />
                </div>
            </div>
            <div class="row">
                <div id="trBarcodeStatus" runat="server" class="input-group col-xs-3" style="padding-bottom: 0px;">
                    <asp:Label ID="lblBarcodeStatus" Text="وضعیت بارکد :" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:DropDownList ID="ddlBarcodeStatus" runat="server" class="form-control input-sm selectpicker pull-right"
                        data-width="220px auto" data-style="btn" data-live-search="true" data-size="5"
                        showTick="true" multiple="true" data-selected-text-format="count > 2" />
                </div>
                <div id="trFDate" runat="server" class="input-group col-xs-3" style="padding-bottom: 0px;">
                    <asp:Label ID="lblFdate" Text="از تاریخ قبول:" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:TextBox runat="server" type="text" ID="Fdate" class="form-control" data-englishnumber="true"
                        data-TargetSelector="#ctl11_Fdate" data-GroupId="group1" data-FromDate="true"
                        data-MdDateTimePicker="true" value="۱۳۹۲/۰۱/۰۱" data-placement="left" />
                </div>
                <div id="trTDate" runat="server" class="input-group col-xs-3" style="padding-bottom: 0px;">
                    <asp:Label ID="lblTdate" Text="تا تاریخ قبول:" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:TextBox runat="server" type="text" ID="Ldate" class="form-control" data-englishnumber="true"
                        data-TargetSelector="#ctl11_Ldate" data-GroupId="group1" data-ToDate="true" data-MdDateTimePicker="true"
                        value="۱۳۹۲/۰۱/۰۱" data-placement="left" />
                </div>
            </div>
            <div class="row">
                <div id="trIsReceipt" runat="server" class="input-group  col-xs-3">
                    <asp:Label ID="lblIsReceipt" Text="وضعیت مالی" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:DropDownList ID="ddlIsReceipt" runat="server" class="form-control input-sm selectpicker pull-right col-xs-3"
                        data-width="220px auto" data-style="btn" AutoPostBack="false" data-size="5">
                        <asp:ListItem Text="بدون انتخاب" Value="-1" Enabled="true" />
                        <asp:ListItem Text="ثبت فیش شده" Value="1" />
                        <asp:ListItem Text="ثبت فیش نشده" Value="0" />
                    </asp:DropDownList>
                </div>
                <div runat="server" id="trShowButton" class="input-group col-xs-3">
                    <asp:Button ID="btnShow" Text="نمایش" runat="server" Class="form-control input-sm btn btn-success btn-md"
                        OnClientClick="FillHiddenField()" OnClick="btnShow_Click" />
                </div>
            </div>
            <br />
        </div>
    </div>
</div>
<br />
<br />
<span style="padding-left: 2%;">
    <img src="../../Images/print.png" alt="print" onclick="printer('print');" style="height: 25px;
        width: 25px; margin-right: 10px;" />&nbsp;
    <img src="../../Images/excel.png" alt="Excel" id="excelFile" onclick="tableToExcel('ReportTable', 'W3C Example Table')"
        style="height: 25px; width: 25px; margin-right: 10px;" />
    <asp:LinkButton ID="lnkDownloadDetail" Text="دانلود جزئیات مرسولات" runat="server" OnClientClick="FillHiddenField()"
        OnClick="lnkDownloadDetail_Click" />
</span>
<br />
<div class="container col-xs-12">
    <div id="print" style="overflow: auto; height: 400px;">
        <style type="text/css">
            #ReportTable td, #ReportTable th
            {
                color: Black;
                height: 30px;
                text-align: center;
                background-color: #EEE;
                border-style: solid;
                border-width: 1px;
                border-color: Black;
                padding-left: 5px;
                padding-right: 5px;
            }
        </style>
        <div id="tbl_rpt" class="row" runat="server">
            <div class="col-md-12">
                <table id="ReportTable" border="0" cellpadding="0" cellspacing="0" width="96%" class=" table-bordered table-striped table-condensed ">
                    <thead class="cf">
                        <tr>
                            <th colspan="11" style="font-family: B Nazanin; font-size: 16px; font-weight: bold;
                                text-align: center;">
                                مرسولات کرایه در مقصد
                            </th>
                        </tr>
                        <tr>
                            <th colspan="6" data-title="Code" style="font-family: B Nazanin; font-size: 14px;
                                font-weight: normal; text-align: center; border-left-width: 0px;">
                                <%Response.Write(Fdate.Text + " الی " + Ldate.Text); %>
                            </th>
                            <th colspan="5" data-title="Code" style="font-family: B Nazanin; font-size: 14px;
                                font-weight: normal; text-align: center; border-right-width: 0px;">
                                <%Response.Write(ddlState.SelectedItem + "--" + ddlCity.SelectedItem + "--" + ddlPostNode.SelectedItem); %>
                            </th>
                        </tr>
                        <tr style="font-family: B Nazanin; font-size: 12px; font-weight: bold;">
                            <th>
                                ردیف
                            </th>
                            <th colspan="2">
                                تاریخ
                            </th>
                            <th>
                                تعداد
                            </th>
                            <th colspan="2">
                                ح س پست
                            </th>
                            <th colspan="2">
                                طرف قرارداد
                            </th>
                            <th>
                                مالیات
                            </th>
                            <th colspan="2">
                                جمع کل
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <% if (dtReport.Rows.Count > 0)
                           {
                               foreach (DataRow dr in dtReport.Rows)
                               {
                        %>
                        <tr style="font-family: B Nazanin; font-size: 14px; font-weight: normal;">
                            <td data-title="Code">
                                <%Response.Write(dr["RowNum"].ToString()); %>
                            </td>
                            <td data-title="Code" colspan="2">
                                <%Response.Write(dr["GenerateBarcodeDateShamsi"].ToString()); %>
                            </td>
                            <td data-title="Code">
                                <%Response.Write(Convert.ToInt64(dr["BarcodeCount"].ToString())); %>
                            </td>
                            <td data-title="Code" colspan="2">
                                <%Response.Write(Convert.ToInt64(dr["PostalCost"].ToString()).ToString("#,##0")); %>
                            </td>
                            <td data-title="Code" colspan="2">
                                <%Response.Write(Convert.ToInt64(dr["CustomerCost"].ToString()).ToString("#,##0")); %>
                            </td>
                            <td data-title="Code">
                                <%Response.Write(Convert.ToInt64(dr["VatTax"].ToString()).ToString("#,##0")); %>
                            </td>
                            <td data-title="Code" colspan="2">
                                <%Response.Write(Convert.ToInt64(dr["TotalCost"].ToString()).ToString("#,##0")); %>
                            </td>
                        </tr>
                        <%
                                  TotalPostalCost += Convert.ToInt64(dr["PostalCost"].ToString());
                                  TotalCustomerCost += Convert.ToInt64(dr["CustomerCost"].ToString());
                                  TotalVattaxCost += Convert.ToInt64(dr["VatTax"].ToString());
                                  TotalSumCost += Convert.ToInt64(dr["TotalCost"].ToString());
                                  TotalBarcodeCount += Convert.ToInt64(dr["BarcodeCount"].ToString());
                               }
                           } %>
                        <tr style="font-family: B Nazanin; font-size: 14px; font-weight: normal;">
                            <td data-title="Code" colspan="3" style="background-color: Black;">
                            </td>
                            <td data-title="Code">
                                <%Response.Write(TotalBarcodeCount.ToString()); %>
                            </td>
                            <td data-title="Code" colspan="2">
                                <%Response.Write(TotalPostalCost.ToString()); %>
                            </td>
                            <td data-title="Code" colspan="2">
                                <%Response.Write(TotalCustomerCost.ToString()); %>
                            </td>
                            <td data-title="Code">
                                <%Response.Write(TotalVattaxCost.ToString()); %>
                            </td>
                            <td data-title="Code" colspan="2">
                                <%Response.Write(TotalSumCost.ToString()); %>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>
<asp:HiddenField ID="hfStateList" runat="server" ClientIDMode="Static" />
