<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Permission.aspx.cs" Inherits="ANP.COD.Permission" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center><BR /><BR /><BR />
    <h1>
    سطح کاربری شما مجوز ورود به این صفحه را ندارد
    </h1>
    <h4>
        <asp:LinkButton Text="بازگشت " PostBackUrl="~/Default.aspx" runat="server" />
    </h4>
    </center>
    </div>
    </form>
</body>
</html>
