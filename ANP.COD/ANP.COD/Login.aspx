<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ANP.COD.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>ورود به سامانه کرایه در مقصد</title>
    <link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="Content/bootstrap-select.css" rel="stylesheet" type="text/css" />
    <link href="Content/Login.css" rel="stylesheet" type="text/css" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]> 
	<script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
	<script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
	<![endif]-->
    <script src="Scripts/jquery-2.1.4.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap-select.js" type="text/javascript"></script>
    <script src="Scripts/defaults-fa_IR.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="en">
        function test() {
            $("#<%=this.ddlPostNode.ClientID%>").selectpicker();
            $("#<%=this.ddlCity.ClientID%>").selectpicker();
            $("#<%=this.ddlState.ClientID%>").selectpicker();
        }
    </script>
</head>
<body>
    <div class="text-center" style="padding: 50px 0">
        <div class="logo">
            سامانه مرسولات کرایه در مقصد</div>
        <!-- Main Form -->
        <div class="login_form-1">
            <form id="login_form" class="text-left" runat="server">
            <div class="main-login_form">
                <div style="text-align: center;">
                    <asp:Label ID="lbl_msg" runat="server" Font-Size="13pt" ForeColor="Red" />
                </div>
                            <div class="etc-login_form text-center">
                <p>
                    نسخه  2.4</p>
            </div>
                <div class="login-group" dir="rtl">
                    <div class="form-group">
                        <label for="ddlState" class="sr-only">
                            نام استان
                        </label>
                        <asp:DropDownList ID="ddlState" runat="server" data-live-search="true" data-size="5"
                            class="form-control input-sm selectpicker " AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" />
                    </div>
                    <div class="form-group">
                        <label for="ddlCity" class="sr-only">
                            نام شهر
                        </label>
                        <asp:DropDownList ID="ddlCity" runat="server" data-live-search="true" data-size="5"
                            class="form-control input-sm selectpicker " AutoPostBack="True" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" />
                    </div>
                    <div class="form-group">
                        <label for="ddlPostNode" class="sr-only">
                            نقطه توزیع
                        </label>
                        <asp:DropDownList ID="ddlPostNode" runat="server" data-live-search="true" data-size="5"
                            class="form-control input-sm selectpicker " AutoPostBack="True" />
                    </div>
                    <div class="form-group">
                        <label for="txt_UserName" class="sr-only">
                            نام کاربری</label>
                        <asp:TextBox ID="txt_UserName" runat="server" class="form-control" placeholder="ورود نام کاربری" />
                    </div>
                    <div class="form-group">
                        <label for="txt_Password" class="sr-only">
                        </label>
                        <asp:TextBox ID="txt_Password" runat="server" TextMode="Password" class="form-control"
                            placeholder="ورود کلمه عبور" />
                    </div>
                </div>
                <asp:Button ID="btn_login" runat="server" OnClick="btn_login_Click" class="login-button"
                    Text="ورود" />
            </div>
            <div class="etc-login_form text-center">
                <p>
                    نام کاربری و کلمه عبور شما با سیستم مبادله یکسان است</p>
            </div>
            </form>
        </div>
        <!-- end:Main Form -->
    </div>
</body>
</html>
