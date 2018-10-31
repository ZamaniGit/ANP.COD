<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RepIncomingParcel.ascx.cs"
    Inherits="ANP.COD.Forms.Reports.RepIncomingParcel" %>
<%@ Register Src="../../Controls/AlertControl.ascx" TagPrefix="uc" TagName="AlertControl" %>
<%@ Import Namespace="ANP.COD" %>
<%@ Import Namespace="System.Data" %>
<link href="../../Content/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="../../Content/bootstrap-select.css" rel="stylesheet" type="text/css" />
<link href="../../Content/MyStyle.css" rel="stylesheet" type="text/css" />
<link href="../../Content/Report.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">
    function Test() {
        $("#<%=this.ddlFirstState.ClientID%>").selectpicker();
        $("#<%=this.ddlLastState.ClientID%>").selectpicker();
        $("#<%=this.ddlLastCity.ClientID%>").selectpicker();
        $("#<%=this.ddlLastPostNode.ClientID%>").selectpicker();
        $("#<%=this.lblExchangeState.ClientID%>").selectpicker();
//        $("#<%=this.ddlReceiptState.ClientID%>").selectpicker();
        $("#<%=this.ddlGC.ClientID%>").selectpicker();
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

    function ShowGlobalContractDetail() {
        var selectedItem = $('#ddlContractType').val();
         if (selectedItem == 'G') {
            $('#trGContract').show();
        }
        else {
            $('#trGContract').hide();
        }
    }
</script>
<br />
<div class="container col-sm-12">
    <div class="panel panel-primary small">
        <div class="panel-heading" enableviewstate="True">
            پنل فیلتر گذاری گزارش مدیریتی مرسولات وارده
        </div>
        <div class="panel-body" style="margin: 0px 20px;">
            <div class="row">
                <div class="input-group  col-xs-11  " dir="rtl">
                    <uc:AlertControl runat="server" ID="ucAlertControl" />
                </div>
            </div>
            <div class="clearfix">
            </div>
            <div class="row">
                <div id="trFirstState" runat="server" class="input-group  col-xs-3 ">
                    <asp:Label ID="lblFirstState" Text="نام استان مبدا:" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:DropDownList ID="ddlFirstState" runat="server" class="form-control input-sm selectpicker pull-right "
                        data-width="220px auto" data-style="btn" AutoPostBack="false" data-size="5" data-live-search="true" />
                </div>
                <div runat="server" id="trExchangeState" class="input-group  col-xs-4 ">
                    <asp:Label ID="lblExchangeState" Text="وضعیت توزیع :" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:DropDownList ID="ddlExchangeState" runat="server" class="form-control input-sm selectpicker pull-right"
                        data-width="220px auto" data-style="btn" data-size="5" />
                </div>
                <div id="trReceiptState" runat="server" class="input-group   col-xs-4">
                    <asp:Label ID="lblReceiptState" Text="وضعیت مالی" class=" pull-right " runat="server"
                        Font-Size="13px" />

<%--          <select  ID="ddlReceiptState_"  runat="server"  
                        data-width="220px auto" >
                <optgroup label="سرگروه">
                            <option title="تسویه شده و نشده" value="0" />
                            <option title="تسویه شده" value="Y" />
                            <option title="تسویه نشده" value="N" />
                       </optgroup>
                  <optgroup label="&nbsp;&nbsp;&nbsp;&nbsp;جزئیات">  
                                <option value="X">&nbsp;&nbsp;&nbsp;&nbsp; بدون فیش</option>
                                <option value="Z">&nbsp;&nbsp;&nbsp;&nbsp; ثبت موقت فیش</option>
                                <option value="A">&nbsp;&nbsp;&nbsp;&nbsp; عدم ارسال به حسابداري </option>
                                <option value="B">&nbsp;&nbsp;&nbsp;&nbsp; ارسال به حسابداري </option>
                                <option value="C">&nbsp;&nbsp;&nbsp;&nbsp; تاييد توسط حسابداري </option>
                                <option value="D">&nbsp;&nbsp;&nbsp;&nbsp; عدم تاييد توسط حسابداري </option>
                     </optgroup>
            </select>--%>
        <asp:DropDownList ID="ddlReceiptState" runat="server" class="form-control input-sm selectpicker pull-right  col-xs-4"  data-width="220px auto" data-style="btn"  >
            <asp:ListItem Text="همه-(تسویه شده و نشده) " value="0" Selected="True"  />
            <asp:ListItem Text="تسویه شده" value="Y"  />
            <asp:ListItem Text="تسویه نشده" value="N"  />
            <asp:ListItem Text=" بدون فیش" value="X"  />
            <asp:ListItem Text="ثبت موقت فیش" value="Z"  />
            <asp:ListItem Text="عدم ارسال به حسابداري" value="A"  />
            <asp:ListItem Text="ارسال به حسابداري" value="B"  />
            <asp:ListItem Text="تاييد توسط حسابداري" value="C"  />
            <asp:ListItem Text="عدم تاييد توسط حسابداري" value="D"  />
        </asp:DropDownList>
                </div>
            </div>
            <div class="clearfix">
            </div>
            <div class="row">
                <div id="trLastState" runat="server" class="input-group   col-xs-3 ">
                    <asp:Label ID="lblLastState" Text="نام استان مقصد:" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:DropDownList ID="ddlLastState" runat="server" class="form-control input-sm selectpicker pull-right  col-xs-4"
                        data-width="220px auto" data-style="btn" AutoPostBack="true" data-size="5" data-live-search="true"
                        OnSelectedIndexChanged="ddlLastState_SelectedIndexChanged" />
                </div>
                <div runat="server" id="trLastCity" class="input-group  col-xs-4 ">
                    <asp:Label ID="Label1" Text="نام شهر مقصد:" class=" pull-right " runat="server" Font-Size="13px" />
                    <asp:DropDownList ID="ddlLastCity" runat="server" class="form-control input-sm selectpicker pull-right "
                        data-width="220px auto" data-style="btn" AutoPostBack="True" data-size="5" data-live-search="true"
                        OnSelectedIndexChanged="ddlLastCity_SelectedIndexChanged" />
                </div>
                <div id="trLastPostNode" runat="server" class="input-group  col-xs-4">
                    <asp:Label ID="Label2" Text="نام نقطه مبادله :" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:DropDownList ID="ddlLastPostNode" runat="server" class="form-control input-sm selectpicker pull-right "
                        data-width="220px auto" data-style="btn" AutoPostBack="false" data-size="5" data-live-search="true" />
                </div>
            </div>
            <div class="clearfix">
            </div>
            <div class="row">
                <div id="trServiceType" runat="server" class="input-group  col-xs-3" style="padding-bottom: 0px;">
                    <asp:Label ID="Label4" Text="نوع سرویس" class=" pull-right " runat="server" Font-Size="13px" />
                    <asp:DropDownList ID="ddlServiceType" runat="server" class="form-control input-sm selectpicker pull-right  col-xs-4"
                        data-width="220px auto" data-style="btn" AutoPostBack="false" data-size="5">
                        <asp:ListItem Text="همه" Value="0" Enabled="true" />
                        <asp:ListItem Text="پیشتاز" Value="1001" Enabled="true" />
                        <asp:ListItem Text="سفارشی" Value="1002" />
                        <asp:ListItem Text="ویژه" Value="1003" />
                        <asp:ListItem Text="امانت" Value="1004" />
                    </asp:DropDownList>
                </div>
                <div id="trFDate" runat="server" class="input-group  col-xs-4" style="padding-bottom: 0px;">
                    <asp:Label ID="lblFdate" Text="توزیع  از  تاریخ:" class=" pull-right " runat="server" />
                    <asp:TextBox runat="server" type="text" ID="Fdate" class="form-control" data-englishnumber="true"
                        data-TargetSelector="#ctl11_Fdate" data-GroupId="group1" data-FromDate="true"
                        data-MdDateTimePicker="true" value="۱۳۹۲/۰۱/۰۱" data-placement="left" />
                </div>
                <div id="trTDate" runat="server" class="input-group  col-xs-4" style="padding-bottom: 0px;">
                    <asp:Label ID="lblTdate" Text="تا تاریخ :" class=" pull-right " runat="server" Font-Size="13px" />
                    <asp:TextBox runat="server" type="text" ID="Ldate" class="form-control" data-englishnumber="true"
                        data-TargetSelector="#ctl11_Ldate" data-GroupId="group1" data-ToDate="true" data-MdDateTimePicker="true"
                        value="۱۳۹۲/۰۱/۰۱" data-placement="left" />
                </div>
            </div>
            <div class="clearfix">
            </div>
            <div class="row">
                <div id="trIsContract" runat="server" class="input-group  col-xs-3" style="padding-bottom: 0px;">
                    <asp:Label ID="Label3" Text="قراردادی/باجه ایی" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:DropDownList ID="ddlContractType" runat="server" class="form-control input-sm selectpicker pull-right  col-xs-4"
                        data-width="220px auto" data-style="btn" AutoPostBack="false" 
                        data-size="5" onchange="javascript:ShowGlobalContractDetail();" 
                        ClientIDMode="Static">
                        <asp:ListItem Text="همه" Value="A" Enabled="true" />
                        <asp:ListItem Text="فقط باجه ایی" Value="B" />
                        <asp:ListItem Text="قرارداد سراسری و استانی" Value="GL" />
                        <asp:ListItem Text="فقط قرارداد سراسری" Value="G" />
                        <asp:ListItem Text="فقط قرارداد استانی" Value="L" />
                    </asp:DropDownList>
                </div>
                <div id="trGContract" runat="server" class="input-group  col-xs-3" style="padding-bottom: 0px;"
                    clientidmode="Static" Visible="False">
                    <asp:Label ID="lblGC" Text="قرارداد سراسری : " runat="server" class=" pull-right" />
                    <asp:DropDownList ID="ddlGC" runat="server" data-live-search="true" class="form-control input-sm selectpicker pull-right"
                        data-style="btn" data-size="5" ClientIDMode="Static"  />
                </div>
                <div runat="server" id="trShowButton" class="input-group  col-xs-2">
                    <asp:Button ID="btnShow" Text="نمایش" runat="server" Class="form-control input-sm btn btn-success btn-md"
                        OnClientClick="FillHiddenField()" OnClick="btnShow_Click" />
                </div>
            </div>
        </div>
        <br />
    </div>
</div>
<br />
<br />
<span style="padding-left: 1%;">
    <img src="../../Images/print.png" alt="print" onclick="printer('print');" style="height: 25px;
        width: 25px; margin-right: 10px;" />&nbsp; </span>
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
            <div class="col-md-12" style="padding: 0px; margin: 0px;">
                <table id="ReportTable" border="0" cellpadding="0" cellspacing="0" width="98%" class=" table-bordered table-striped table-condensed ">
                    <thead class="cf">
                        <tr>
                            <th colspan="13" style="font-family: B Nazanin; font-size: 16px; font-weight: bold;
                                text-align: center;">
                                گزارش مدیریتی مرسولات کرایه در مقصد وارده به استان
                            </th>
                        </tr>
                        <tr>
                            <th colspan="7" data-title="Code" style="font-family: B Nazanin; font-size: 14px;
                                font-weight: normal; text-align: center; border-left-width: 0px;">
                                <%Response.Write(Fdate.Text + " الی " + Ldate.Text); %>
                            </th>
                            <th colspan="6" data-title="Code" style="font-family: B Nazanin; font-size: 14px;
                                font-weight: normal; text-align: center; border-right-width: 0px;">
                                <%Response.Write(ddlLastState.SelectedItem + "--" + ddlLastCity.SelectedItem + "--" + ddlLastPostNode.SelectedItem); %>
                            </th>
                        </tr>
                        <tr style="font-family: B Nazanin; font-size: 12px; font-weight: bold;">
                            <th>
                                ردیف
                            </th>
                            <th>
                                مقصد
                            </th>
                            <th>
                                مبدا
                            </th>
                            <th>
                                تعداد
                            </th>
                            <th>
                                نوع مرسوله ثبتی
                            </th>
                            <th>
                                نوع سرویس
                            </th>
                            <th colspan="1">
                                ح س پست
                            </th>
                            <th colspan="1">
                                طرف قرارداد
                            </th>
                            <th>
                                مالیات
                            </th>
                            <th colspan="1">
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
                        <tr style="font-family: B Nazanin; font-size: 11px; font-weight: normal;">
                            <td data-title="Code">
                                <%Response.Write(dr["RowNum"].ToString()); %>
                            </td>
                            <td data-title="Code" colspan="1">
                                <%Response.Write(dr["LastAddress"].ToString()); %>
                            </td>
                            <td data-title="Code" colspan="1">
                                <%Response.Write(dr["FirstStateName"].ToString()); %>
                            </td>
                            <td data-title="Code">
                                <%Response.Write(Convert.ToInt64(dr["CountRow"].ToString())); %>
                            </td>
                            <td data-title="Code" colspan="1">
                                <%Response.Write(ContactAndBaje); %>
                            </td>
                            <td data-title="Code" colspan="1">
                                <%Response.Write(ServiceType); %>
                            </td>
                            <td data-title="Code" colspan="1">
                                <%Response.Write(Convert.ToInt64(dr["PostalCost"].ToString()).ToString("#,##0")); %>
                            </td>
                            <td data-title="Code" colspan="1">
                                <%Response.Write(Convert.ToInt64(dr["CustomerCost"].ToString()).ToString("#,##0")); %>
                            </td>
                            <td data-title="Code" colspan="1">
                                <%Response.Write(Convert.ToInt64(dr["VatTax"].ToString()).ToString("#,##0")); %>
                            </td>
                            <td data-title="Code" colspan="1">
                                <%Response.Write(Convert.ToInt64(dr["TotalCost"].ToString()).ToString("#,##0")); %>
                            </td>
                        </tr>
                        <%
                                  TotalPostalCost += Convert.ToInt64(dr["PostalCost"].ToString());
                                  TotalCustomerCost += Convert.ToInt64(dr["CustomerCost"].ToString());
                                  TotalVattaxCost += Convert.ToInt64(dr["VatTax"].ToString());
                                  TotalSumCost += Convert.ToInt64(dr["TotalCost"].ToString());
                                  TotalBarcodeCount += Convert.ToInt64(dr["CountRow"].ToString());
                               }
                           } %>
                        <tr style="font-family: B Nazanin; font-size: 14px; font-weight: normal;">
                            <td data-title="Code" colspan="3" style="background-color: Black;">
                                <h5 style="color: White; font-family: B Nazanin; font-weight: bold;">
                                    جمع کل</h5>
                            </td>
                            <td data-title="Code">
                                <%Response.Write(TotalBarcodeCount.ToString()); %>
                            </td>
                            <td data-title="Code">
                                --
                            </td>
                            <td data-title="Code">
                                --
                            </td>
                            <td data-title="Code">
                                <%Response.Write(TotalPostalCost.ToString()); %>
                            </td>
                            <td data-title="Code">
                                <%Response.Write(TotalCustomerCost.ToString()); %>
                            </td>
                            <td data-title="Code">
                                <%Response.Write(TotalVattaxCost.ToString()); %>
                            </td>
                            <td data-title="Code">
                                <%Response.Write(TotalSumCost.ToString()); %>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>
