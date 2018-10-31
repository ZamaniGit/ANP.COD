<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DateSelector.ascx.cs" Inherits="ANP.COD.Controls.DateSelector" %>

<link href="../Content/calendar.css" rel="stylesheet" media="all" type="text/css" />





<table>
<tr>	
	<td style="vertical-align:middle;text-align:right;" align="right" runat="server" id="tdlabel" visible="false">
        <asp:Label ID="lt" runat="server" Text="تاریخ :" ></asp:Label>
	</td>
	<td  style="vertical-align:middle;text-align:right;" align="right">
		<input  dir="ltr" id="faDate" runat="server" size="12" style="width: 100px" type="text" />
	</td>
</tr>
</table>