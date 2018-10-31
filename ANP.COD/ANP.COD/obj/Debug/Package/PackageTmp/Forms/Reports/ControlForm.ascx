<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlForm.ascx.cs"
    Inherits="ANP.COD.Forms.Reports.ControlForm" %>
<%@ Register Src="../../Controls/AlertControl.ascx" TagPrefix="uc" TagName="AlertControl" %>
<link href="../../Content/bootstrap.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="en">
    function Test() {

        if ($("#<%=this.trState.ClientID%>").is(":visible") == true)
            $("#<%=this.ddlState.ClientID%>").selectpicker();
        if ($("#<%=this.trCity.ClientID%>").is(":visible") == true)
            $("#<%=this.ddlCity.ClientID%>").selectpicker();
        if ($("#<%=this.trPostNodeName.ClientID%>").is(":visible") == true)
            $("#<%=this.ddlPostNode.ClientID%>").selectpicker();
        if ($("#<%=this.trLastState.ClientID%>").is(":visible") == true)
            $("#<%=this.ddlLastState.ClientID%>").selectpicker();
        if ($("#<%=this.trLastCity.ClientID%>").is(":visible") == true)
            $("#<%=this.ddlLastCity.ClientID%>").selectpicker();
        if ($("#<%=this.trLastPostNode.ClientID%>").is(":visible") == true)
            $("#<%=this.ddlLastPostNode.ClientID%>").selectpicker();
        if ($("#<%=this.trUser.ClientID%>").is(":visible") == true)
            $("#<%=this.ddlUser.ClientID%>").selectpicker();
        if ($("#<%=this.trBarcodeStatus.ClientID%>").is(":visible") == true)
            $("#<%=this.ddlBarcodeStatus.ClientID%>").selectpicker();
        if ($("#<%=this.trPayType.ClientID%>").is(":visible") == true)
            $("#<%=this.ddlPayType.ClientID%>").selectpicker();
        if ($("#<%=this.trReceiptNo.ClientID%>").is(":visible") == true)
            $("#<%=this.ddlReceiptSeriAlepha.ClientID%>").selectpicker();
        if ($("#<%=this.trReceiptType.ClientID%>").is(":visible") == true)
            $("#<%=this.ddlReceiptType.ClientID%>").selectpicker();
        if ($("#<%=this.trReceiptState.ClientID%>").is(":visible") == true)
            $("#<%=this.ddlReceiptState.ClientID%>").selectpicker();
        if ($("#<%=this.trReceiptSaveState.ClientID%>").is(":visible") == true)
            $("#<%=this.ddlReceiptSaveState.ClientID%>").selectpicker();
        if ($("#<%=this.trCredit.ClientID%>").is(":visible") == true)
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

<div class="container col-sm-11  ">
    <div class="panel panel-primary small " style="margin-top: 20px;">
        <div class="panel-heading">
            پنل گزارشات مرسولات کرایه در مقصد
        </div>
        <div class="panel-body" style="margin: 0px 20px;">
            <div class="row">
                <div class="input-group col-xs-11 " dir="rtl">
                    <uc:AlertControl runat="server" ID="ucAlertControl" />
                </div>
            </div>
            <div class="row">
                <div id="trState" runat="server" class="input-group col-xs-3 ">
                    <asp:Label ID="lblState" Text="نام استان :" class=" pull-right " runat="server" Font-Size="13px" />
                    <asp:DropDownList ID="ddlState" runat="server" class="form-control input-sm selectpicker pull-right "
                        data-width="220px auto" data-style="btn" AutoPostBack="True" data-size="5" data-live-search="true"
                        OnSelectedIndexChanged="ddlState_SelectedIndexChanged" />
                </div>
                <div runat="server" id="trCity" class="input-group col-xs-3 ">
                    <asp:Label ID="lblCity" Text="نام شهر :" class=" pull-right " runat="server" Font-Size="13px" />
                    <asp:DropDownList ID="ddlCity" runat="server" class="form-control input-sm selectpicker pull-right "
                        data-width="220px auto" data-style="btn" AutoPostBack="True" data-size="5" data-live-search="true"
                        OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" />
                </div>
                <div id="trPostNodeName" runat="server" class="input-group col-xs-3">
                    <asp:Label ID="lblPostNode" Text="نام نقطه  :" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:DropDownList ID="ddlPostNode" runat="server" class="form-control input-sm selectpicker pull-right "
                        data-width="220px auto" data-style="btn" AutoPostBack="True" data-size="5" data-live-search="true"
                        OnSelectedIndexChanged="ddlPostNode_SelectedIndexChanged" />
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
                <div id="trUser" runat="server" class="input-group col-xs-3">
                    <asp:Label ID="lblUser" Text="نام کابری :" class=" pull-right " runat="server" Font-Size="13px" />
                    <asp:DropDownList ID="ddlUser" runat="server" class="form-control input-sm selectpicker pull-right "
                        data-width="220px auto" data-style="btn" data-size="5" data-live-search="true" />
                </div>
                <div id="trFDate" runat="server" class="input-group col-xs-3" style="padding-bottom: 4px;">
                    <asp:Label ID="lblFdate" Text="از تاریخ :" class=" pull-right " runat="server" Font-Size="13px" />
                    <asp:TextBox runat="server" type="text" ID="Fdate" class="form-control" data-englishnumber="true"
                        data-TargetSelector="#ctl11_Fdate" data-GroupId="group1" data-FromDate="true"
                        data-MdDateTimePicker="true" value="۱۳۹۲/۰۱/۰۱" data-placement="left" />
                </div>
                <div id="trTDate" runat="server" class="input-group col-xs-3" style="padding-bottom: 4px;">
                    <asp:Label ID="lblTdate" Text="تا تاریخ :" class=" pull-right " runat="server" Font-Size="13px" />
                    <asp:TextBox runat="server" type="text" ID="Ldate" class="form-control" data-englishnumber="true"
                        data-TargetSelector="#ctl11_Ldate" data-GroupId="group1" data-ToDate="true" data-MdDateTimePicker="true"
                        value="۱۳۹۲/۰۱/۰۱" data-placement="left" />
                </div>
            </div>
            <div class="row">
                <div id="trBarCode" runat="server" class="input-group col-xs-3">
                    <asp:Label ID="lblBarCode" Text="بارکد :" class=" pull-right " runat="server" Font-Size="13px" />
                    <asp:TextBox ID="txtBarCode" runat="server" class="form-control input-sm" MaxLength="30" />
                </div>
                <div id="trBarcodeStatus" runat="server" class="input-group col-xs-3" style="padding-bottom: 3px;">
                    <asp:Label ID="lblBarcodeStatus" Text="وضعیت بارکد :" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:DropDownList ID="ddlBarcodeStatus" runat="server" class="form-control input-sm selectpicker pull-right"
                        data-width="220px auto" data-style="btn" data-live-search="true" data-size="5" />
                </div>
                <div id="trPayType" runat="server" class="input-group col-xs-3" style="padding-bottom: 3px;">
                    <asp:Label ID="lblPayType" Text="نحوه پرداخت :" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:DropDownList ID="ddlPayType" runat="server" class="form-control input-sm selectpicker pull-right "
                        data-style="btn" data-width="220px auto">
                        <asp:ListItem Value="2">همه</asp:ListItem>
                        <asp:ListItem Value="1">فیش</asp:ListItem>
                        <asp:ListItem Value="0">چک</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div id="trReceiptType" runat="server" class="input-group col-xs-3">
                    <asp:Label ID="lblReceiptType" Text="نوع فیش/چک :" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:DropDownList ID="ddlReceiptType" runat="server" class="form-control input-sm selectpicker "
                        data-width="220px auto" data-style="btn" data-size="5" />
                </div>
                <div id="trReceiptSaveState" runat="server" class="input-group col-xs-3">
                    <asp:Label ID="lblReceiptSaveState" Text="بررسی فیش/چک" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:DropDownList ID="ddlReceiptSaveState" runat="server" class="form-control input-sm selectpicker  "
                        data-width="220px auto" data-style="btn" data-size="5" />
                </div>
                <div runat="server" id="trReceiptState" class="input-group col-xs-3">
                    <asp:Label ID="lblReceiptState" Text="وضعیت فیش/چک" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:DropDownList ID="ddlReceiptState" runat="server" class="form-control input-sm selectpicker "
                        data-width="220px auto" data-style="btn" data-size="5" />
                </div>
            </div>
            <div class="row">
                <div id="trReceiptNo" runat="server" class="input-group col-xs-3" style="padding: 0px;
                    margin: 0px;">
                    <div class="container col-xs-12" style="padding: 0px; margin: 0px;">
                        <div class="row" style="padding: 0px; margin: 0px;">
                            <div class="input-group col-xs-5" style="padding: 0px; margin: 0px; top: 0px; left: 0px;">
                                <asp:Label ID="lblReceiptNo" Text="سریال فیش/چک" class=" pull-right " runat="server"
                                    Font-Size="13px" />
                                <asp:TextBox ID="txtReceiptNo" runat="server" class="form-control input-sm  " MaxLength="6" />
                            </div>
                            <div class="input-group col-xs-6" style="padding: 0px; margin: 0px;">
                                <div class="container col-xs-12" style="padding: 0px; margin: 0px;">
                                    <div class="row " style="padding: 0px; margin: 0px;">
                                        <div class="input-group col-xs-5" style="padding: 0px; margin-right: 8px;">
                                            <asp:Label ID="Label2" Text="سری فیش" class=" pull-left " runat="server" Font-Size="13px" />
                                            <asp:TextBox ID="txtReceiptSeriNo" runat="server" class="form-control input-sm" MaxLength="6" />
                                        </div>
                                        <div class="input-group col-xs-6" style="padding: 0px; margin: 0px;">
                                            <asp:Label ID="Label3" Text="چک/" class=" pull-right " runat="server" Font-Size="13px" />
                                            <asp:DropDownList ID="ddlReceiptSeriAlepha" runat="server" class="form-control input-sm selectpicker  "
                                                data-width="50px auto" data-style="btn" data-size="5" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="trCredit" runat="server" class="input-group col-xs-3" style="padding-bottom: 96px auto;">
                    <asp:Label ID="lblCredit" Text="نحوه پرداخت :" class=" pull-right " runat="server"
                        Font-Size="13px" />
                    <asp:DropDownList ID="ddlCredit" runat="server" class="form-control input-sm selectpicker pull-right "
                        data-style="btn" data-width="220px auto">
                        <asp:ListItem Value="-1">همه</asp:ListItem>
                        <asp:ListItem Value="1">تسویه شده</asp:ListItem>
                        <asp:ListItem Value="0">عدم تسویه</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="input-group col-xs-3" style="padding-bottom: 96px auto;">
                    &nbsp;
                </div>
            </div>
            <br />
            <div class="row">
                <div class="input-group col-xs-3" style="padding-bottom: 30px auto;">
                    &nbsp;
                </div>
                <div runat="server" id="trShowButton" class="input-group col-xs-3">
                    <asp:Button ID="btnShow" Text="نمایش" runat="server" OnClick="btnShow_Click" Class="form-control input-sm btn btn-success btn-md" />
                </div>
                <div class="input-group col-xs-3" style="padding-bottom: 30px auto;">
                    &nbsp;
                </div>
                <br />
                <br />
                <div class="row">
                    <div id="DivPateTracking" runat="server" class="input-group col-xs-11  text-right">
                        <asp:Label ID="lblPateTracking_" Text="وضعیت مرسولات پته :" runat="server" Font-Size="14px" />
                        <br />
                        <br />
                        <asp:Label ID="lblPateTracking" Text="" class=" text-justify " runat="server" Font-Size="13px" />
                    </div>
                </div>
                <br />
                <br />
            </div>
        </div>
    </div>
</div>
