<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ANP.COD.WebForm1" %>
<%--<%@ Register Src="../../../Controls/AlertControl.ascx" TagPrefix="uc" TagName="AlertControl" %>
<%@ Register Src="../../../Controls/DateSelector.ascx" TagName="DateSelector" TagPrefix="uc" %>--%>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script type="text/javascript" lang="en"  >

    function test() {

        $("#<%=this.ddlStatus.ClientID%>").selectpicker();
        $("#<%=this.ddlMovazeh.ClientID%>").selectpicker();

        $("#<%=this.Ldate.ClientID%>").MdPersianDateTimePicker({
            Placement: 'left',
            Trigger: 'focus',
            EnableTimePicker: false,
            TargetSelector: '',
            GroupId: '',
            ToDate: false,
            FromDate: false,
            EnglishNumber: true,
            Disabled: false
        });

        $("#<%=this.Fdate.ClientID%>").MdPersianDateTimePicker({
            Placement: 'left',
            Trigger: 'focus',
            EnableTimePicker: false,
            TargetSelector: '',
            GroupId: '',
            ToDate: false,
            FromDate: false,
            EnglishNumber: true,
            Disabled: false
        });

    }

    function ClientSideAgeValidation(sender, e) {
        if (((e.Value >= 0) && (e.Value <= 2147483647)) == false) {
            e.IsValid = false;
        }
    }
</script>


<html xmlns="http://www.w3.org/1999/xhtml"> 
<head runat="server">
<link href="../../../Content/MyStyle.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>  
    <form id="form1" runat="server">





<%--<div id="DivAllPage" runat="server" visible="false" style="border-style: none; opacity: 0.8;
    border-width: medium; z-index: 1100; display: block; margin: 0pt; padding: 0pt;
    width: 100%; height: 100%; top: 0pt; left: 0pt; background-color: #CCC; cursor: move;
    position: fixed; bottom: 708px;">
</div>--%>

<div class="container-fluid col-xs-12 hidden-xs small" >

            <div class="row">
                <div class="input-group col-xs-12 col-sm-12 col-md-12 col-lg-12 " dir="ltr">
                    
                </div>
            </div>
            <div class="row col-xs-10 col-sm-pull-1" style="border-width:0.1px; border-color:#F0F0F0; border-style:solid; border-radius: 5px;">
                <div class="input-group col-xs-5 col-md-3 col-lg-3" dir="ltr" style="margin:0px 5px;">
                    <asp:Label ID="Label2" Text="از تاریخ" class=" pull-right" runat="server" />
                    <asp:TextBox runat="server" type="text" ID="Fdate" class="form-control" data-englishnumber="true" data-MdDateTimePicker="true"  data-placement="left" />

                </div>
                <div class="input-group col-xs-5 col-md-3 col-lg-3" dir="ltr" style="margin:0px 5px;">
                    <asp:Label ID="Label3" Text="تا تاریخ" class=" pull-right" runat="server" />
                    <asp:TextBox runat="server" type="text" ID="Ldate" class="form-control" data-englishnumber="true" data-MdDateTimePicker="true" value="۱۳۹۲/۰۱/۰۱" data-placement="left" />
                </div>
                <div id="divEname" runat="server" class="input-group col-xs-10 col-sm-10 col-md-4" style="margin:0px 5px;"
                    dir="ltr">
                    <asp:Label ID="Label1" Text="بارکد" class=" pull-right" runat="server" />
                    <asp:TextBox ID="txtBracodeSearch" runat="server"  class="form-control input-sm" Style="text-align: center;"
                        placeholder="بارکد را وارد کنید" />
                </div>
                <div class="input-group col-xs-10 col-sm-10 "><br /></div>
                <div id="divFilter_Financial" runat="server" class="input-group col-xs-5 col-md-3 col-lg-3" style="margin:0px 5px;" dir="rtl">
                    <asp:Label ID="lblFinancial" Text="وضعیت مالی : " runat="server" class=" pull-right" />
                    <asp:DropDownList ID="ddlFinancial" runat="server" class="form-control input-sm  selectpicker"  data-style="btn" AutoPostBack="false" data-size="5"   >
                        <asp:ListItem Text="همه" Value="0" Selected="True" >  </asp:ListItem>
                        <asp:ListItem Text="تسویه شده " Value="1" >  </asp:ListItem>
                        <asp:ListItem Text="تسویه نشده" Value="2"  >  </asp:ListItem>
                     </asp:DropDownList>
                </div>
                <div id="divFilter_ParentState" runat="server" class="input-group col-xs-5 col-md-3 col-lg-3" style="margin:0px 5px;"
                    dir="rtl">
                    <asp:Label ID="lblParentState" Text="سرگروه وضعیت : " runat="server" class=" pull-right" />
                    <asp:DropDownList ID="ddlParentState" runat="server" data-live-search="true" class="form-control input-sm  selectpicker"  data-style="btn"
                        AutoPostBack="True" data-size="5"   />
                </div>
                <div id="divState" runat="server" class="input-group col-xs-5 col-md-3 col-lg-3" style="margin:0px 5px;"
                    dir="rtl">
                    <asp:Label ID="lblStatus" Text="وضعیت مرسوله : " runat="server" class=" pull-right" />
                    <asp:DropDownList ID="ddlStatus" runat="server" data-live-search="true" class="form-control input-sm  selectpicker"  data-style="btn"
                        AutoPostBack="True" data-size="5"   />
                </div>

                <div id="divFilter_ParcelType" runat="server" class="input-group col-xs-5 col-md-3 col-lg-3" style="margin:0px 5px;"
                    dir="rtl">
                    <asp:Label ID="lblParcelType" Text="نوع مرسوله : " runat="server" class=" pull-right" />
                    <asp:DropDownList ID="ddlParcelType" runat="server" class="form-control input-sm  selectpicker"  data-style="btn" data-size="5"   />
                </div>

                <div id="divMovazeh" runat="server" class="input-group col-xs-5 col-md-3 col-lg-3" style="margin:0px 5px;" dir="rtl">
                    <asp:Label ID="Label6" Text="نامه رسان : "  runat="server" class=" pull-right"  />
                    <asp:DropDownList ID="ddlMovazeh" runat="server" data-live-search="true"  class="form-control input-sm selectpicker pull-right"  data-style="btn" AutoPostBack="True" data-size="5" />
                </div>
                <div id="divbtnSearch" runat="server" class="input-group col-xs-10 col-sm-10 col-md-4" style="margin:0px 5px;" dir="rtl">
                    <span><asp:CheckBox ID="chkDontPayPrice" runat="server"  />&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblDontReceipt"  Text="عدم ثبت فیش" runat="server" /></span>
                    <span class="pull-left">
                    <asp:Button ID="btnSearch" CssClass="btn btn-success btn-md " runat="server" 
                        Text="نمایش" /></span>
                </div>
                <br />
                <br />
            </div>
            <div class="row col-sm-12">
                <br />
                <div dir="rtl" style="width: 100%; overflow: auto;
                    height:50px auto; max-height:350px;">
                    <asp:DataGrid ID="MyGrid" runat="server" AutoGenerateColumns="False" CellPadding="3"
                            CssClass="grid" PageSize="20" BackColor="White">
                    <Columns>
                        <asp:BoundColumn DataField="RowNum" HeaderText="ردیف" />
                        <asp:BoundColumn DataField="ID" HeaderText="id" Visible="false" />
                        <asp:BoundColumn DataField="Barcode" HeaderText="بارکد" />
                        <asp:BoundColumn DataField="LocalStart" HeaderText="مبدا" />
                        <asp:BoundColumn DataField="LocalEnd" HeaderText="مقصد" />
                        <asp:BoundColumn DataField="ServiceTypeTitle" HeaderText="نوع سرویس" />
                        <asp:BoundColumn DataField="ServiceTitle" HeaderText="جزئیات سرویس" />
                        <asp:BoundColumn DataField="GenerateBarcodeDate" HeaderText="قبول مرسوله" />
                        <asp:BoundColumn DataField="EntryDate" HeaderText="ورود به مبادله" />
                        <asp:BoundColumn DataField="EndStatus" HeaderText="آخرین وضعیت" />
                        <%--<asp:BoundColumn DataField="EntryDateChangeStatus" HeaderText="تغییر حالت در مبادله" />--%>
                        <asp:BoundColumn DataField="PostalCost" HeaderText="ح.س پست" />
                        <asp:BoundColumn DataField="CustomerCost" HeaderText="ح.س.ط قرارداد" />
                        <asp:BoundColumn DataField="VatTax" HeaderText="مالیات" />
                        <asp:BoundColumn DataField="TotalCost" HeaderText="جمع کل" />
                        <asp:BoundColumn DataField="ReceiptDate" HeaderText="تاریخ ثبت فیش" />
                        <asp:TemplateColumn HeaderText="جزئیات">
                            <ItemTemplate>
                                <asp:LinkButton ID="lblDetail" runat="server" CommandArgument='<%# Eval("ID") %>'
                                    CommandName="Detail" ForeColor="Black" Text="" >
                                    <img src="../../Images/search.png" alt="#" />
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#D9EDF7" Font-Bold="false"  ForeColor="Black"
                                HorizontalAlign="Center" />
                            <ItemStyle ForeColor="#000066" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                            <SelectedItemStyle BackColor="#669999" Font-Bold="false" ForeColor="White" />
                </asp:DataGrid>
                </div>
            </div>
            <br />

            <div class="row col-sm-12" style="height:20px;"  >
            <div class="input-group col-xs-12" style=" background-color:#FEFDFD; border-width:0.1px; border-color:#337AB7; border-style:solid; border-radius: 5px; padding: 5px;">
                <asp:Label ID="lable15" Text="ح.س.پست:" runat="server" CssClass="col-sm-1" ForeColor="Red" />
                <asp:Label ID="lblSumPostal" Text="0" runat="server" ForeColor="Red" CssClass="col-sm-2" />
            
                <asp:Label ID="Label7" Text="ط.قرارداد:" runat="server" CssClass="col-sm-1" ForeColor="Red"/>
                <asp:Label ID="lblSumCustomer" Text="0" runat="server" ForeColor="Red" CssClass="col-sm-2"/>
            
                <asp:Label ID="Label9" Text="مالیات:" runat="server" CssClass="col-sm-1" ForeColor="Red"/>
                <asp:Label ID="lblSumVatTax" Text="0" runat="server" ForeColor="Red" CssClass="col-sm-2" />
            
                <asp:Label ID="Label4" Text="جمع کل" runat="server" CssClass="col-sm-1" ForeColor="Red" />
                <asp:Label ID="txtSumPrice" Text="0" runat="server" ForeColor="Red" CssClass="col-sm-2"/>
            </div>
            </div>
            <div class="row col-sm-12">
                <div class="container-fluid col-xs-12 col-sm-12 col-md-12 col-lg-12">
                    <div class="row col-sm-12">
            <div id="DivDetail" visible="false" runat="server" style="z-index: 1102; display: block; 
                position: fixed; padding: 0px; margin: 0px; height:10px auto; max-height:200px; top: 20%; width: 80%;
                left: 10%; direction: rtl; color: Blue; border-width: 0px; background-color:#D6D6D6; text-align: center;">
                            <div style="width: 98%; box-shadow: 0.1px 0.1px 2px #BBB; overflow: auto; height:10px auto; max-height:150px;
                                margin: 1%;">
                                <asp:DataGrid ID="DetailGrid" runat="server"  AutoGenerateColumns="False" CellPadding="3"
                            CssClass="grid" PageSize="20" BackColor="White" BorderColor="#D6D6D6" BorderStyle="None" 
                            BorderWidth="1px">
                                    <Columns>
                                        <asp:BoundColumn DataField="RowNum" HeaderText="ردیف" />
                                        <asp:BoundColumn DataField="ID" HeaderText="id" Visible="false" />
                                        <asp:BoundColumn DataField="barcode" HeaderText="بارکد" />
                                        <asp:BoundColumn DataField="UserName" HeaderText="نام موزع" />
                                        <asp:BoundColumn DataField="StatusName" HeaderText="وضعیت مبادله" />
                                        <asp:BoundColumn DataField="StatusDate" HeaderText="تاریخ مبادله" />
                                        <asp:BoundColumn DataField="StateName" HeaderText="محل مبادله" />
                                    </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="false" Font-Size="10pt" ForeColor="White"
                                HorizontalAlign="Center" />
                            <ItemStyle ForeColor="#000066" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                            <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                </asp:DataGrid>
                                <br />
                            </div>

                <br />
                <asp:Button ID="btnReturn" Text="بازگشت" CssClass="btn btn-primary" runat="server" Style="margin-right: 0px"
                    Font-Names="byekan" Font-Size="9pt" Width="80px" AccessKey="R"  />
                <br />
                <br />
            </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
