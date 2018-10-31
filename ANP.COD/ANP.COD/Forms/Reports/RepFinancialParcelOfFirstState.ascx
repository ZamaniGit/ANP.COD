<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RepFinancialParcelOfFirstState.ascx.cs"
    Inherits="ANP.COD.Forms.Reports.RepFinancialParcelOfFirstState" %>
<%@ Register Src="../../Controls/AlertControl.ascx" TagPrefix="uc" TagName="AlertControl" %>
<%@ Import Namespace="ANP.COD" %>
<%@ Import Namespace="System.Data" %>
<link href="../../Content/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="../../Content/bootstrap-select.css" rel="stylesheet" type="text/css" />
<link href="../../Content/MyStyle.css" rel="stylesheet" type="text/css" />
<link href="../../Content/Report.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="en">
    function Test() {
        $("#<%=this.ddlState.ClientID%>").selectpicker();
        $("#<%=this.ddlCity.ClientID%>").selectpicker();
        $("#<%=this.ddlPostNode.ClientID%>").selectpicker();
        $("#<%=this.ddlLastState.ClientID%>").selectpicker();
        $("#<%=this.ddlLastCity.ClientID%>").selectpicker();
        $("#<%=this.ddlLastPostNode.ClientID%>").selectpicker();
        $("#<%=this.ddlBarcodeStatus.ClientID%>").selectpicker();
        $("#<%=this.ddlCredit.ClientID%>").selectpicker();


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
<style type="text/css" media="print">
    @page
    {
        size: landscape;
    }
</style>
<br />
<div class="container col-sm-11  ">
    <div class="panel panel-primary small " style="margin-top: 20px;">
        <div class="panel-heading">
            پنل فیلتر گذاری گزارش مرسوله براساس قبول
        </div>
        <div class="panel-body" style="margin: 0px 20px;">
            <div class="row">
                <div class="input-group col-xs-12 " dir="rtl">
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
                        data-width="220px auto" data-style="btn" AutoPostBack="True" data-size="5" data-live-search="true" />
                </div>
            </div>
            <div class="row">
                <div id="trLastState" runat="server" class="input-group col-xs-3 ">
                    <asp:Label ID="lblLastState" Text="نام استان مقصد:" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:DropDownList ID="ddlLastState" runat="server" class="form-control input-sm selectpicker pull-right "
                        data-width="220px auto" data-style="btn" AutoPostBack="True" data-size="5" data-live-search="true"
                        OnSelectedIndexChanged="ddlLastState_SelectedIndexChanged" />
                </div>
                <div runat="server" id="trLastCity" class="input-group col-xs-3 ">
                    <asp:Label ID="lblLastCity" Text="نام شهر مقصد:" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:DropDownList ID="ddlLastCity" runat="server" class="form-control input-sm selectpicker pull-right "
                        data-width="220px auto" data-style="btn" AutoPostBack="True" data-size="5" data-live-search="true"
                        OnSelectedIndexChanged="ddlLastCity_SelectedIndexChanged" />
                </div>
                <div id="trLastPostNode" runat="server" class="input-group col-xs-3">
                    <asp:Label ID="lblLastPostNode" Text="نام نقطه مبادله مقصد:" class=" pull-right "
                        runat="server" Font-Size="13px" />
                    <asp:DropDownList ID="ddlLastPostNode" runat="server" class="form-control input-sm selectpicker pull-right "
                        data-width="220px auto" data-style="btn" AutoPostBack="True" data-size="5" data-live-search="true" />
                </div>
            </div>
            <div class="row">
                <div id="trCredit" runat="server" class="input-group col-xs-3" style="padding-bottom: 96px auto;
                    top: 0px; left: 0px;">
                    <asp:Label ID="lblCredit" Text="نحوه پرداخت :" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:DropDownList ID="ddlCredit" runat="server" class="form-control input-sm selectpicker pull-right "
                        data-style="btn" data-width="220px auto">
                        <asp:ListItem Value="-1">همه</asp:ListItem>
                        <asp:ListItem Value="1">تسویه شده</asp:ListItem>
                        <asp:ListItem Value="0">عدم تسویه</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="trFDate" runat="server" class="input-group col-xs-3" style="padding-bottom: 4px;">
                    <asp:Label ID="lblFdate" Text="از تاریخ قبول:" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:TextBox runat="server" type="text" ID="Fdate" class="form-control" data-englishnumber="true"
                        data-TargetSelector="#ctl11_Fdate" data-GroupId="group1" data-FromDate="true"
                        data-MdDateTimePicker="true" value="۱۳۹۲/۰۱/۰۱" data-placement="left" />
                </div>
                <div id="trTDate" runat="server" class="input-group col-xs-3" style="padding-bottom: 4px;">
                    <asp:Label ID="lblTdate" Text="تا تاریخ قبول:" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:TextBox runat="server" type="text" ID="Ldate" class="form-control" data-englishnumber="true"
                        data-TargetSelector="#ctl11_Ldate" data-GroupId="group1" data-ToDate="true" data-MdDateTimePicker="true"
                        value="۱۳۹۲/۰۱/۰۱" data-placement="left" />
                </div>
            </div>
            <div class="row">
                <div id="trBarcodeStatus" runat="server" class="input-group col-xs-3" style="padding-bottom: 3px;">
                    <asp:Label ID="lblBarcodeStatus" Text="عنوان سرگروه:" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:DropDownList ID="ddlBarcodeStatus" runat="server" class="form-control input-sm selectpicker pull-right"
                        data-width="220px auto" data-style="btn" data-live-search="true" AutoPostBack="true"
                        data-size="5" onselectedindexchanged="ddlBarcodeStatus_SelectedIndexChanged" />
                </div>
                <div id="trBarcodeSubStatus" runat="server" class="input-group col-xs-3" style="padding-bottom: 3px;">
                    <asp:Label ID="lblBarcodeSubStatus" Text="وضعیت بارکد :" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:DropDownList ID="ddlBarcodeSubStatus" runat="server" class="form-control input-sm selectpicker pull-right"
                        data-width="220px auto" data-style="btn" data-live-search="true" data-size="5" />
                </div>
                <div runat="server" id="trShowButton" class="input-group col-xs-3">
                    <asp:Button ID="btnShow" Text="نمایش" runat="server" Class="form-control input-sm btn btn-success btn-md"
                        OnClick="btnShow_Click" />
                </div>
            </div>
            <br />
        </div>
    </div>
</div>
