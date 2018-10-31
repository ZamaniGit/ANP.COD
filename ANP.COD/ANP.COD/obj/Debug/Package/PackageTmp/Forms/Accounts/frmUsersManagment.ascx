<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="frmUsersManagment.ascx.cs"
    Inherits="ANP.COD.Forms.Accounts.frmUsersManagment" %>
<%@ Register Src="../../Controls/AlertControl.ascx" TagPrefix="uc" TagName="AlertControl" %>

<link href="../../Content/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="../../Content/bootstrap-select.css" rel="stylesheet" type="text/css" />
<link href="../../Content/MyStyle.css" rel="stylesheet" type="text/css" />
<%--<link href="../../Styles/Receipt.css" rel="stylesheet" type="text/css" />--%>

<script type="text/javascript" language="en"  >

    function test() {
        $("#<%=this.ddl_State.ClientID%>").selectpicker();
        $("#<%=this.ddl_City.ClientID%>").selectpicker();
        $("#<%=this.ddl_PostNode.ClientID%>").selectpicker();
    }
</script>




<br />
<asp:HiddenField ID="hf_update" runat="server" Value="0" />
<div class="container-fluid col-xs-12 col-sm-12 col-md-12 col-lg-12">
    <div class="panel panel-primary hidden-xs small">
        <div class="panel-heading">
            تعریف/ویرایش کاربران
        </div>
        <div class="panel-body " >
            <div class="row">
                <div class="input-group col-xs-12" dir="ltr">
                    <uc:AlertControl runat="server" ID="ucAlertControl" />
                </div>
            </div>
            <div class="row col-xs-12 col-sm-pull-1">
                <div class="input-group col-xs-6 col-sm-4 col-md-3 col-lg-3 " dir="ltr">
                    <asp:Label ID="Label1" Text="نام" class=" pull-right" runat="server" />
                    <asp:TextBox ID="txt_Pname" runat="server" class="form-control input-sm" Style="text-align: center;"
                        placeholder="نام را وارد کنید" />
                </div>
                <div class="input-group col-xs-6 col-sm-4 col-md-3 col-lg-3 " dir="ltr">
                    <asp:Label ID="Label2" Text="فامیلی" class=" pull-right" runat="server" />
                    <asp:TextBox ID="txt_Family" runat="server" class="form-control input-sm" Style="text-align: center;"
                        placeholder="نام خانوادگی را وارد کنید" />
                </div>
                <div id="divEname" runat="server" class="input-group col-xs-6 col-sm-4 col-md-3 col-lg-3  "
                    dir="ltr">
                    <asp:Label ID="Label3" Text="نام کاربري" class=" pull-right" runat="server" />
                    <asp:TextBox ID="txt_Ename" runat="server" class="form-control input-sm" Style="text-align: center;"
                        placeholder="نام کاربري را وارد کنید" />
                </div>
            </div>
            <div class="row col-xs-12 col-sm-pull-1">
                <div id="divState" runat="server" class="input-group col-xs-6 col-sm-4 col-md-3 col-lg-3 " 
                    dir="rtl">
                    <asp:Label ID="Label6" Text="استان" class=" pull-right" runat="server" />
                    <asp:DropDownList ID="ddl_State" runat="server" data-live-search="true" class="form-control input-xs selectpicker" 
                        AutoPostBack="True" data-size="5" OnSelectedIndexChanged="ddl_State_SelectedIndexChanged" />
                </div>
                <div id="divCity" runat="server" class="input-group col-xs-6 col-sm-4 col-md-3 col-lg-3  "
                    dir="rtl">
                    <asp:Label ID="Label7" Text="شهر" class="  pull-right" runat="server" />
                    <asp:DropDownList ID="ddl_City" runat="server" data-live-search="true" class="form-control input-xs selectpicker"
                        AutoPostBack="True" data-size="5" OnSelectedIndexChanged="ddl_City_SelectedIndexChanged" />
                </div>
                <div id="divPostNode" runat="server" class="input-group col-xs-6 col-sm-4 col-md-3 col-lg-3 "
                    dir="rtl">
                    <asp:Label ID="Label8" Text="نقطه مبادله" class=" pull-right" runat="server" />
                    <asp:DropDownList ID="ddl_PostNode" runat="server" class="form-control input-xs selectpicker"
                        data-size="5" />
                </div>
            </div>
            <div class="row col-xs-12 col-sm-pull-1">
                <div id="divRole" runat="server" class="input-group col-xs-6 col-sm-4 col-md-3 col-lg-3 "
                    dir="rtl">
                    <asp:Label ID="Label4" Text="سمت" class=" pull-right" runat="server" />
                    <asp:DropDownList ID="ddl_Role" runat="server" class="form-control input-sm " AutoPostBack="True"
                        OnSelectedIndexChanged="ddl_Role_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="input-group col-xs-6 col-sm-4 col-md-3 col-lg-3  " dir="ltr">
                    <asp:Label ID="Label9" Text="رمز ورود" class=" pull-right" runat="server" />
                    <asp:TextBox ID="txt_Pass" runat="server" type="password" class="form-control input-sm"
                        Style="text-align: center;" placeholder="رمز را وارد کنید" />
                </div>
                <div class="input-group col-xs-6 col-sm-4 col-md-3 col-lg-3 " dir="ltr">
                    <asp:Label ID="Label10" Text="تکرار رمز" class=" pull-right" runat="server" />
                    <asp:TextBox ID="txt_RePass" runat="server" type="password" class="form-control input-sm"
                        Style="text-align: center;" placeholder="تکرار رمز را وارد کنید" />
                </div>
            </div>
            <div class="row col-xs-12 col-sm-pull-1">
                <div id="div2" runat="server" class="input-group col-xs-6 col-sm-4 col-md-3 col-lg-3 "
                    dir="rtl">
                    <asp:Label ID="Label5" Text="وضعیت" class=" pull-right" runat="server" />
                    <asp:DropDownList ID="ddl_Status" runat="server" class="form-control input-sm">
                    </asp:DropDownList>
                </div>
                <div id="div4" runat="server" class="input-group col-xs-6 col-sm-4 col-md-3 col-lg-3 "
                    dir="ltr">
                    <asp:Button ID="btn_save" CssClass="btn btn-success btn-md " runat="server" Text="دخيره اطلاعات"
                        OnClick="btn_save_Click" />
                </div>
                <div id="div3" runat="server" class="input-group col-xs-6 col-sm-4 col-md-3 col-lg-3 "
                    dir="rtl">
                    <asp:Button ID="btn_cancel" CssClass="btn btn-success btn-md " runat="server" Text="انصراف"
                        OnClick="btn_cancel_Click" />
                </div>
            </div>
            <br />
            <div class="row col-sm-12 " style="padding:0px; width:100%">
                <br />
                <div dir="rtl" style="width: 100%; box-shadow: 1px 1px 15px #BBB; overflow: auto;
                    height: 180px;">
                    <asp:DataGrid ID="MyGrid" runat="server" AutoGenerateColumns="False" CellPadding="3"
                        Width="100%" PageSize="20" Height="50px" OnItemCommand="MyGrid_ItemCommand" BackColor="White"
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <Columns>
                            <asp:BoundColumn DataField="RowNo" HeaderText="ردیف " HeaderStyle-Font-Size="12px">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="ID" HeaderText="آی دی" Visible="false"></asp:BoundColumn>
                            <asp:BoundColumn DataField="UserId" HeaderText="کد کاربر" HeaderStyle-Font-Size="12px">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Name" HeaderText="نام"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Family" HeaderText="فامیلی"></asp:BoundColumn>
                            <asp:BoundColumn DataField="UserName" HeaderText="نام کاربری"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Password" HeaderText="پسورد" Visible="false"></asp:BoundColumn>
                            <asp:BoundColumn DataField="StateName" HeaderText="استان"></asp:BoundColumn>
                            <asp:BoundColumn DataField="StateCode" HeaderText="آی دی استان" Visible="false">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="PostNodeName" HeaderText="باجه"></asp:BoundColumn>
                            <asp:BoundColumn DataField="PostNodeCode" HeaderText="آی دی باجه" Visible="false">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="RoleID" HeaderText="آی دی سمت" Visible="false"></asp:BoundColumn>
                            <asp:BoundColumn DataField="RoleTitle" HeaderText="سمت"></asp:BoundColumn>
                            <asp:BoundColumn DataField="IsActive" HeaderText="فعال" Visible="false"></asp:BoundColumn>
                            <asp:BoundColumn DataField="IsActiveName" HeaderText="وضعیت" HeaderStyle-Font-Size="12px">
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="ویرایش" HeaderStyle-Font-Size="12px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbl_Edit" runat="server" CommandArgument='<%# Eval("Id") %>'
                                        CommandName="Edit"> ویرایش </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" ForeColor="White" Font-Bold="false" Font-Size="16px"
                            HorizontalAlign="Center" Wrap="false" />
                        <ItemStyle ForeColor="#000066" Font-Names="BYekan" Font-Bold="false" Font-Size="12px"
                            HorizontalAlign="Center" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Mode="NumericPages" />
                        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    </asp:DataGrid>
                </div>
            </div>
        </div>
    </div>
</div>
