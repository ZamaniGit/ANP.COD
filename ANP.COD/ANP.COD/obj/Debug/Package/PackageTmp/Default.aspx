<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ANP.COD._Default" %>

<%@ Register Src="~/Controls/ShortMenu.ascx" TagPrefix="uc" TagName="ShortMenu" %>
<%@ Register Src="Controls/HorizentalUserMenuBootstrap.ascx" TagPrefix="uc" TagName="HorizentalUserMenuBootstrap" %>
<%@ Register Src="Controls/VerticalUserMenuBootStrap.ascx" TagPrefix="ucv" TagName="VerticalUserMenuBootStrap" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1,user-scale=no" />
    
    <link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="Content/BootstrapVerticalMenu.css" rel="stylesheet" type="text/css" />
    <link href="Content/BootstrapHorizentalMenu.css" rel="stylesheet" type="text/css" />
    <link href="Content/bootstrap-select.css" rel="stylesheet" type="text/css" />
    <link href="Content/jquery.Bootstrap-PersianDateTimePicker.css" rel="stylesheet"
        type="text/css" />
    <link href="Content/calendar.css" rel="stylesheet" type="text/css" />
<%--     HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries 
     WARNING: Respond.js doesn't work if you view the page via file:// --%>
<%--    [if lt IE 9]
	<script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js" language="javascript" type="text/javascript""></script>
	<script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js" language="javascript" type="text/javascript""></script>
	[endif]--%>
    <script src="Scripts/jquery-2.1.4.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap-select.js" type="text/javascript"></script>
    <script src="Scripts/defaults-fa_IR.min.js" type="text/javascript"></script>
    <script src="Scripts/calendar.js" type="text/javascript"></script>
    <script src="Scripts/jquery.Bootstrap-PersianDateTimePicker.js" type="text/javascript"></script>
    <script src="Scripts/MyJavaScrip.js" type="text/javascript"></script>
    
    <title>کرایه در مقصد</title>
</head>
<body style="font-style: normal; font-weight: normal; overflow:auto;" class="form-inline" >
    <form id="form1" runat="server" lang="en" role="form">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <div class="container " dir="rtl">
        <div class="row">
            <%--Hedear--%>
            <div class="col-xs-12 ">
                <img src="Images/header.jpg" alt="---" class="img img-responsive" style="padding:0px; margin:0px;"/>
            </div>
            <%--Divider--%>
            <div class="   col-sm-12 col-md-12 col-lg-12 ">
                <div class="hidden-xs  col-sm-12 col-md-12 col-lg-12 " style="height: 2px; background-color: #ccc;">
                </div>
            </div>
            <%--Info Hedaer--%>
            <div class=" hidden-xs col-sm-12 col-md-12 col-lg-12 ">
                <div class=" bg-info hidden-xs col-sm-6 col-md-5" style="direction: rtl; height: 25px;">
                    <asp:Label CssClass="small " ID="lbl_Navigator" Text="" runat="server" ForeColor="#00599C" />
                </div>
                <div class="bg-info hidden-xs col-sm-6 col-md-4 " style="direction: rtl; height: 25px;">
                    <asp:Label CssClass="small" ID="Label1" runat="server" ForeColor="#00599C" Text="" />
                </div>
                <div class=" bg-info hidden-sm  col-md-3 " style="direction: rtl; height: 25px;">
                    <asp:Label CssClass="small" ID="Label2" runat="server" Text="" ForeColor="#00599C" />
                </div>
            </div>
            <%--Divider--%>
            <div class="  hidden-xs col-sm-12 col-md-12 col-lg-12 ">
                <div class="col-sm-12 col-md-12 col-lg-12 " style="height: 2px; background-color: #eee;">
                </div>
            </div>
            <%--Horizental-Menu--%>
            <div id="Menu" class="col-xs-12">
                <uc:HorizentalUserMenuBootstrap runat="server" ID="ucHorizentalUserMenuBootstrap" />
            </div>
            <%-- VerticalMenu--%>
            <div class="col-xs-6 col-sm-4 col-md-3 col-lg-2 pull-right " style="padding: 0px;">
                <ucv:VerticalUserMenuBootStrap runat="server" ID="ucVerticalUserMenuBootStrap" />
            </div>
            <div class="col-xs-6 col-sm-8 col-md-9 col-lg-10 pull-left " style="border-width: 0.1px;   border-color: #F0F0F0; border-style: solid; border-radius: 5px; padding: 20px 5px;">
                <asp:PlaceHolder ID="plReport" runat="server" ></asp:PlaceHolder>
            </div>
            <asp:UpdatePanel runat="server" ID="up" UpdateMode="Conditional" ClientIDMode="Static">
                <ContentTemplate>
                    <%--Main--%>
                    <div class="col-xs-6 col-sm-8 col-md-9 col-lg-9 pull-left " style="border-width: 0.1px;
                        border-color: #F0F0F0; border-style: solid; border-radius: 5px; padding: 20px 5px;">
                        <asp:PlaceHolder ID="ph" runat="server"></asp:PlaceHolder>
                    </div>
                    <asp:UpdateProgress runat="server" ID="PageUpdateProgress" AssociatedUpdatePanelID="up"
                        DisplayAfter="0">
                        <ProgressTemplate>
                            <div style="z-index: 1000; border: 1px solid #000; margin: 0pt; padding: 0pt; width: 100%; 
                                height: 100%; top: 0; left: 0; background-color: gray; opacity: 0.6; cursor: wait;
                                position: fixed;" class="blockUI blockOverlay">
                            </div>
                            <div style="z-index: 1001; position: fixed; padding: 0px; margin: 0px; width: 30%;
                                top: 40%; left: 30%; direction: rtl; color: Blue; border: 0; background-color: transparent;
                                text-align: center; font-family: Tahoma; font-size: 14px;" class="blockUI blockMsg blockPage">
                                <img src="../../Images/328.gif" alt="" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </ContentTemplate>
            </asp:UpdatePanel>
            <%--Footer--%>
            <div class="  hidden-xs col-sm-12 col-md-12 col-lg-12  " style="background-color: #BFCDDB;
                margin-top: 0px;">
                <div style="width: 100%; text-align: center;">
                    <span>کلیه حقوق این سامانه متعلق به شرکت پست جمهوری اسلامی ایران می باشد</span>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
