<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.ascx.cs"
    Inherits="ANP.COD.Forms.Accounts.ChangePassword" %>
<%@ Register Src="../../Controls/AlertControl.ascx" TagPrefix="uc" TagName="AlertControl" %>
<link href="../../Content/bootstrap.css" rel="stylesheet" type="text/css" />
<%--<br />
<asp:HiddenField ID="hf_msg" runat="server" />
<div class="container col-xs-9 col-sm-9 col-md-9 col-lg-9">
    <div class="input-group  col-xs-12 col-sm-12 col-md-12 col-lg-12  ">
        <div class="row" >
            <div class="input-group col-xs-8 col-sm-8 col-md-8 col-lg-8  col-lg-push-2 ">
                <uc:AlertControl runat="server" ID="ucAlertControl" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="input-group col-xs-3 col-sm-3 col-md-3 col-lg-3 col-lg-push-5   " dir="ltr">
                <asp:TextBox ID="txt_curentpass" runat="server" type="password" class="form-control input-sm"
                    Style="text-align: center;" placeholder="رمز فعلی را وارد کنید" />
                <span class="input-group-addon">رمز فعلی </span>
                <!-- Append element using class input-group-addon -->
            </div>
        </div>
        <br />
        <div class="row">
            <div class="input-group col-xs-3 col-sm-3 col-md-3 col-lg-3   ">
                <asp:TextBox ID="txt_newpass" runat="server" type="password" class="form-control input-sm"
                    Style="text-align: center;" placeholder="رمز جدید را وارد کنید" />
                <span class="input-group-addon">رمز جدید </span>
                <!-- Append element using class input-group-addon -->
            </div>
        </div>
        <br />
        <div class="row">
            <div class="input-group col-xs-3 col-sm-3 col-md-3 col-lg-3   ">
                <asp:TextBox ID="txt_new_repass" runat="server" type="password" class="form-control input-sm"
                    Style="text-align: center;" placeholder="رمز جدید را مجددا وارد کنید" />
                <span class="input-group-addon">تکرار رمز </span>
                <!-- Append element using class input-group-addon -->
            </div>
        </div>
        <br />
        <div class="row">
            <div class="input-group col-xs-5 col-sm-2 col-md-2 col-lg-1 col-lg-pull-1  ">
                <asp:Button ID="btn_approve" runat="server" Text="ذخیره" CssClass="btn btn-success btn-md btn-block "
                    OnClick="btn_approve_Click" />
            </div>
        </div>
    </div>
</div>
--%>
<asp:HiddenField ID="hf_msg" runat="server" />


<div class="container col-sm-6 col-sm-pu11-3 ">
<div class="panel panel-primary small"  style="margin-top:20px;" >
<div class="panel-heading">
تغییررمز
</div>
<div class="panel-body" style="margin-right:20px; margin-left:20px;">

    <div class="row">
        <div class="input-group col-xs-12 col-sm-12 col-md-12 col-lg-12 "  dir="rtl">
            <uc:AlertControl runat="server" ID="ucAlertControl" />
        </div>
    </div>
    <div class="row">
        <div class="input-group col-xs-6  col-sm-pull-3" dir="ltr">
            <asp:Label ID="Label4" Text="پسورد فعلی" class=" pull-right " runat="server" Font-Size="13px" />
            <asp:TextBox ID="txt_curentpass" runat="server" type="password" class="form-control input-sm"
                Style="text-align: center;" placeholder="پسورد فعلی را وارد نمایید" />
        </div>
    </div>
    <div class="row">
        <div class="input-group col-xs-6  col-sm-pull-3" dir="ltr">
            <asp:Label ID="Label5" Text="پسورد جدید" class=" pull-right" runat="server" />
            <asp:TextBox ID="txt_newpass" runat="server" type="password" class="form-control input-sm"
                Style="text-align: center;" placeholder="پسورد جدید را وارد نمایید" />
        </div>
    </div>
    <div class="row">
        <div class="input-group col-xs-6 col-sm-pull-3" dir="ltr">
            <asp:Label ID="Label6" Text="تکرار پسورد" class=" pull-right" runat="server" />
            <asp:TextBox ID="txt_new_repass" runat="server" type="password" class="form-control input-sm"
                Style="text-align: center;" placeholder="تکرار پسورد جدید" />
        </div>
    </div>
    <br />
    <div class="row">
        <div class="input-group col-xs-12" dir="ltr">
            <div dir="ltr" class="input-group col-xs-8 col-sm-5 col-md-3 col-lg-3 col-xs-push-2 col-sm-push-4 col-md-push-5  ">
               <asp:Button ID="btn_approve" runat="server" Text="ذخیره" CssClass="btn btn-success btn-md"
                    OnClick="btn_approve_Click" />
            </div>
        </div>
    </div>
</div>

</div>
</div>