<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShortMenu.ascx.cs" Inherits="ANP.COD.Controls.ShortMenu" %>
<link href="../Content/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="../Content/ShortMenu.css" rel="stylesheet" type="text/css" />
<script src="../Scripts/jquery-2.1.4.js" type="text/javascript"></script>
<script src="../Scripts/bootstrap.js" type="text/javascript"></script>
<script src="../Scripts/ShortMenu.js" type="text/javascript"></script>


<div class="container">
    <div class="flyout-wrap">
        <a class="flyout-btn" href="#" title="Toggle"><span>Flyout Menu Toggle</span></a>
        <ul class="flyout flyout-init">
            <li><a href="#"><span>Item</span></a></li>
            <li><a href="#"><span>Item</span></a></li>
            <li><a href="#"><span>Item</span></a></li>
            <li><a href="#"><span>Item</span></a></li>
            <li><a href="#"><span>Item</span></a></li>
            <li><a href="#"><span>Item</span></a></li>
        </ul>
    </div>
</div>


<script type="text/javascript">
    (function () {
        $(".flyout-btn").click(function () {
            return $(".flyout-btn").toggleClass("btn-rotate"), $(".flyout").find("a").removeClass(), $(".flyout").removeClass("flyout-init fade").toggleClass("expand")
        }), $(".flyout").find("a").click(function () {
            return $(".flyout-btn").toggleClass("btn-rotate"), $(".flyout").removeClass("expand").addClass("fade"), $(this).addClass("clicked")
        })
    }).call(this);
</script>
<script type="text/javascript">

    var _gaq = _gaq || [];
    _gaq.push(['_setAccount', 'UA-36251023-1']);
    _gaq.push(['_setDomainName', 'jqueryscript.net']);
    _gaq.push(['_trackPageview']);

    (function () {
        var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
        ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
    })();

</script>
