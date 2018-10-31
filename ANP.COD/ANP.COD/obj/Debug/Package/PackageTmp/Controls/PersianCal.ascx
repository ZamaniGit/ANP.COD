<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PersianCal.ascx.cs"
    Inherits="ANP.COD.Controls..PersianCal" %>
<script src="../Scripts/jquery.Bootstrap-PersianDateTimePicker.min.js" type="text/javascript"></script>
<%--<script src="../Scripts/js-persian-cal.min.js" type="text/javascript" />--%>

<div>
    <input type="text" id="pcal1" runat="server" style="font-family:BYekan; font-size:12px; width:80px; height:22px; margin:0px; padding:0px; "  class="pdate"/><br/>
</div>

<script type="text/javascript">
    var objCal1 = new AMIB.persianCalendar('pcal1');
</script>