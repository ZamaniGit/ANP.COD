<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RepBarcodeDetail_Deleted.ascx.cs"
    Inherits="ANP.COD.Forms.Reports.RepBarcodeDetail" %>
<%@ Import Namespace="ANP.COD" %>
<%@ Import Namespace="System.Data" %>
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
<%--<asp:UpdatePanel runat="server" ID="up" UpdateMode="Conditional">
    <ContentTemplate>--%>
<span >
    <img src="../../Images/print.png" alt="print" onclick="printer('print');" style="height: 25px;
        width: 25px" />&nbsp;
   <%-- <img src="../../Images/excel.png" alt="Excel" onclick="tableToExcel('tbl_rpt', 'W3C Example Table')" style="height: 25px;
        width: 25px"/>--%>
    <asp:ImageButton ImageUrl="~/Images/excel.png"  runat="server" style="height: 25px;
        width: 25px" ImageAlign="Middle" onclick="Unnamed1_Click" />
</span>

        <div id="print" class="container col-xs-12" style="overflow: auto; height: 400px;">
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
                <div>
                   <%-- <div dir="rtl" style="width: 100%; overflow: auto;
                    height:50px auto; max-height:350px;">
                    <asp:DataGrid ID="MyGrid" runat="server" AutoGenerateColumns="False" CellPadding="3"
                            CssClass="grid" PageSize="20" BackColor="White" >
                    <Columns>
                        <asp:BoundColumn DataField="RowNum" HeaderText="ردیف" />
                        <asp:BoundColumn DataField="Barcode" HeaderText="بارکد" />
                        <asp:BoundColumn DataField="PostNodeName" HeaderText="نام نقطه مبادله" Visible="false" />
                        <asp:BoundColumn DataField="StatusName" HeaderText="وضعیت بارکد" />
                        <asp:BoundColumn DataField="StatusDate_Shamsi" HeaderText="تاریخ آخرین وضعیت" />
                        <asp:BoundColumn DataField="Era" HeaderText="مبدا" />
                        <asp:BoundColumn DataField="Aim" HeaderText="مقصد" />
                        <asp:BoundColumn DataField="ReceiptDate" HeaderText="تاریخ ثبت فیش" />
                        <asp:BoundColumn DataField="PostalCost" HeaderText=" ح س پست" />
                        <asp:BoundColumn DataField="VatTax" HeaderText="مالیات" />
                        <asp:BoundColumn DataField="CustomerCost" HeaderText="ح س ط قرارداد" />
                        <asp:BoundColumn DataField="SumPrice" HeaderText="جمع" />
                       <asp:TemplateColumn HeaderText="جزئیات">
                            <ItemTemplate>
                                <asp:LinkButton ID="lblDetail" runat="server" CommandArgument='<%# Eval("ID") %>'
                                    CommandName="Detail" ForeColor="Black" Text="" >
                                    <img src="../../Images/search.png" alt="#" />
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#D9EDF7" Font-Bold="false"  ForeColor="Black"
                                HorizontalAlign="Center" />
                            <ItemStyle ForeColor="#000066" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                            <SelectedItemStyle BackColor="#669999" Font-Bold="false" ForeColor="White" />
                </asp:DataGrid>
                </div>--%>
                    <table id="ReportTable" border="0" cellpadding="0" cellspacing="0" runat="server"
                     class="col-md-12 table-bordered table-striped table-condensed ">
                        <thead class="cf">
                            <tr>
                                <th colspan="12" 
                                    style="font-family:B Nazanin; font-size:14px; font-weight:bold;">
                                    مرسولات کرایه در مقصد
                                </th>
                            </tr>
                            <tr>
                                <th colspan="12"  
                                    style="font-family:B Nazanin; font-size:14px; font-weight:normal;">
                                    گزارش مالی آماری مرسولات بصورت تفصیلی
                                </th>
                            </tr>
                            <tr style="font-family:B Nazanin; font-size:12px; font-weight:bold;">
                                <th>
                                    ردیف
                                </th>
                                <th>
                                    بارکد
                                </th>
                                <th>
                                    نام نقطه مبادله
                                </th>
                                <th>
                                    وضعیت بارکد
                                </th>
                                <th>
                                    تاریخ آخرین وضعیت
                                </th>
                                <th>
                                    مبدا
                                </th>
                                <th>
                                    مقصد
                                </th>
                                <th>
                                    تاریخ ثبت فیش
                                </th>
                                <th>
                                    ح س پست
                                </th>
                                <th>
                                    مالیات
                                </th>
                                <th>
                                    ح س ط قرارداد
                                </th>
                                <th>
                                    جمع
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <% if (dtReport.Rows.Count > 0)
                               {
                                   int AllPostalCost = 0;
                                   int AllVatTax = 0;
                                   int AllCustomerCost = 0;
                                   int AllSumPrice = 0;
                                   
                                   foreach (DataRow dr in dtReport.Rows)
                                   {
                                       AllPostalCost += Convert.ToInt32(dr["PostalCost"].ToString());
                                       AllVatTax += Convert.ToInt32(dr["VatTax"].ToString());
                                       AllCustomerCost += Convert.ToInt32(dr["CustomerCost"].ToString());
                                       AllSumPrice += Convert.ToInt32(dr["SumPrice"].ToString());
                                       
                            %>
                            <tr style="font-family:B Nazanin; font-size:13px; font-weight:normal; ">
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
                                    <%Response.Write(dr["StatusName"].ToString()); %>
                                </td>
                                <td data-title="Code">
                                    <%Response.Write(dr["StatusDate_Shamsi"].ToString()); %>
                                </td>
                                <td data-title="Code">
                                    <%Response.Write(dr["Era"].ToString()); %>
                                </td>
                                <td data-title="Code">
                                    <%Response.Write(dr["Aim"].ToString()); %>
                                </td>
                                <td data-title="Code">
                                    <%Response.Write(dr["ReceiptDate"].ToString()); %>
                                </td>
                                <td data-title="Code">
                                    <%Response.Write(dr["PostalCost"].ToString()); %>
                                </td>
                                <td data-title="Code">
                                    <%Response.Write(dr["VatTax"].ToString()); %>
                                </td>
                                <td data-title="Code">
                                    <%Response.Write(dr["CustomerCost"].ToString()); %>
                                </td>
                                <td data-title="Code">
                                    <%Response.Write(dr["SumPrice"].ToString()); %>
                                </td>
                            </tr>
                            <% } %>
                            <tr style="font-family:B Nazanin; font-size:13px; font-weight:normal; " >
                                <td data-title="Code" colspan="8">
                                    جمع کل
                                </td>
                                <td data-title="Code">
                                    <%Response.Write(AllPostalCost.ToString("#,##0")); %>
                                </td>
                                <td data-title="Code">
                                    <%Response.Write(AllVatTax.ToString("#,##0")); %>
                                </td>
                                <td data-title="Code">
                                    <%Response.Write(AllCustomerCost.ToString("#,##0")); %>
                                </td>
                                <td data-title="Code">
                                    <%Response.Write(AllSumPrice.ToString("#,##0")); %>
                                </td>
                            </tr>
                            <% } %>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
<%--    </ContentTemplate>
</asp:UpdatePanel>
--%>