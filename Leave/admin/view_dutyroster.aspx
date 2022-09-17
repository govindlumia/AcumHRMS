<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_dutyroster.aspx.cs"
    MasterPageFile="~/Leave/admin/Admin.master" Inherits="admin_view_tmt_dutyroster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">--%>
    <%--<title>Acuminous Software Intranet</title>--%>
    <%--<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />--%>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        .input3
        {
            font: normal 11px Arial, Helvetica, sans-serif;
            color: #000;
        }
    </style>
    <script type="text/javascript">

        function SelectMeOnly(objRadioButton, grdName) {
            var i, obj;
            //example of radio button id inside the grid (grdAddress): grdAddress__ctl2_radioSelect
            for (i = 0; i < document.all.length; i++) {
                obj = document.all(i);
                if (obj.type == "radio") {
                    if (objRadioButton.id.substr(0, grdName.length) == grdName)
                        if (objRadioButton.id == obj.id)
                            obj.checked = true;
                        else
                            obj.checked = false;
                }
            }
        }

        //function checkStartdate()
        //{
        //    var stDate = new Date(document.forms[0].txt_start_date.value);
        //    var edDate = new Date(document.forms[0].txt_end_date.value);
        //            
        //            if (stDate > edDate) 
        //                {
        //                    alert("From date must be less than To date");
        //                    document.forms[0].txt_start_date.value=document.getElementById('HiddenField1').value;
        //                }
        //}

        //function checkEnddate()
        //{
        //    var stDate = new Date(document.forms[0].txt_start_date.value);
        //    var edDate = new Date(document.forms[0].txt_end_date.value);
        //           
        //            if (stDate > edDate)
        //                {
        //                    alert("To date must be greater than From date");
        //                    document.forms[0].txt_end_date.value=document.getElementById('HiddenField2').value;
        //                }  
        //}
    </script>
    <%--</head>

<body>

<form id="Form1" runat="server">--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </cc1:ToolkitScriptManager>
            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                runat="server">
                <ProgressTemplate>
                    <div class="divajax" style="left: 400px; top: 170px;">
                        <table width="100%">
                            <tr>
                                <td align="center" valign="top">
                                    <img src="../images/loading.gif" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="bottom" align="center" class="txt01" height="23">
                                    Please Wait...
                                </td>
                            </tr>
                        </table>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div style="overflow-x: hidden; overflow-y: scroll; height: 524px; width: 968px;">
                <table width="923" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="7">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td colspan="2" valign="top">
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="txt01">
                                                    View Duty Roster
                                                </td>
                                                <td align="right">
                                                    <span id="message" runat="server" class="txt-red"></span>
                                                </td>
                                                <td align="right">
                                                    <asp:LinkButton ID="lnkrefresh" runat="server" OnClick="lnkrefresh_Click" CssClass="txt-red">Refresh</asp:LinkButton>&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div id="divempsearch" runat="server">
                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="left" class="txt02" colspan="7">
                                                        Search Employee
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123" width="12%">
                                                        Name
                                                    </td>
                                                    <td class="frm-rght-clr123" width="17%">
                                                        <asp:TextBox ID="txt_employee" runat="server" CssClass="input" Width="125px"></asp:TextBox>
                                                    </td>
                                                    <td class="frm-lft-clr123" width="14%">
                                                        Designation
                                                    </td>
                                                    <td class="frm-rght-clr123" width="16%">
                                                        <asp:DropDownList ID="dd_designation" runat="server" CssClass="select" DataSourceID="SqlDataSource1"
                                                            DataTextField="designationname" DataValueField="id" OnDataBound="dd_designation_DataBound"
                                                            Width="132px">
                                                        </asp:DropDownList>
                                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_DesignationMaster]">
                                                        </asp:SqlDataSource>
                                                    </td>
                                                    <td class="frm-lft-clr123" width="11%">
                                                        Category
                                                    </td>
                                                    <td class="frm-rght-clr123" width="16%">
                                                        &nbsp;<asp:DropDownList ID="dd_dpt" runat="server" CssClass="select" DataSourceID="SqlDataSource2"
                                                            DataTextField="CategoryName" DataValueField="ID" OnDataBound="dd_dpt_DataBound"
                                                            Width="145px">
                                                        </asp:DropDownList>
                                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                            ProviderName="System.Data.SqlClient" SelectCommand="select distinct [ID],CategoryName From [tbl_category_master] order by CategoryName">
                                                        </asp:SqlDataSource>
                                                    </td>
                                                    <td class="frm-lft-clr123" width="14%">
                                                        <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="Button1_Click1" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td colspan="8" valign="top">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td align="left" class="txt02" height="20" valign="top">
                                                                Select Employee
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="2">
                                                                <div>
                                                                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:GridView ID="Grid_Emp" runat="server" AllowPaging="True" Width="100%" Font-Size="11px"
                                                                                    Font-Names="Arial" HorizontalAlign="Left" DataKeyNames="empcode" CellPadding="4"
                                                                                    AutoGenerateColumns="False" AllowSorting="True" PageSize="50" OnPageIndexChanging="Grid_Emp_PageIndexChanging"
                                                                                    BorderWidth="0px" OnRowCommand="Grid_Emp_RowCommand" EmptyDataText="No such employee exists.">
                                                                                    <PagerStyle CssClass="frm-lft-clr123" Width="500px" Font-Size="18px" HorizontalAlign="Left"
                                                                                        VerticalAlign="Top" />
                                                                                    <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" Visible="true" LastPageText="last"
                                                                                        NextPageText="next" PreviousPageText="prev" FirstPageText="first" />
                                                                                    <RowStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left"></RowStyle>
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="empcode" HeaderText="Employee code">
                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" Width="12%" />
                                                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234" />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="name" HeaderText="Employee Name" ReadOnly="True">
                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234"
                                                                                                Width="25%" />
                                                                                        </asp:BoundField>
                                                                                        <%--<asp:BoundField DataField="branch_name" HeaderText="Branch">
<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/> 
<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234" Width="15%"/> 
</asp:BoundField>--%>
                                                                                        <asp:BoundField DataField="CategoryName" HeaderText="Category">
                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234"
                                                                                                Width="18%" />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="designationname" HeaderText="Designation">
                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234"
                                                                                                Width="18%" />
                                                                                        </asp:BoundField>
                                                                                        <asp:TemplateField>
                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234"
                                                                                                Width="12%" />
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton ID="lnkbtnedit" runat="server" CommandArgument='<%#Eval("empcode")%>'
                                                                                                    CausesValidation="false" CssClass="link05" Text="View Duty Roster" ToolTip="View"
                                                                                                    CommandName="Select" />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" VerticalAlign="Top">
                                                                                    </HeaderStyle>
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="8">
                                                    <%--<span <a href="leaveadmin.aspx" class="button-txt" target="name123">test</a>
<a href="../leave-user.aspx" class="button-txt" target="name123">test1</a>
<asp:Button ID="btn_back" CssClass="button" runat="server" Text="Back" OnClick="btn_back_Click" />--%>
                                                    <input type="button" id="bck" class="button" value="Back" onclick="javascript:history.go(-1);" />
                                                    <%--<input type="button" id="bck" class="button" value="Back" onclick="javascript:history.go(-1);" />--%>
                                                </td>
                                                <%--<td colspan="8" height="20" valign="bottom"><a href="../leave.aspx" class="link05">Back</a></td>--%>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <div id="divdetail" class="pop21" runat="server" visible="false" align="center">
                    <table width="450" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="pop-brdr">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="95%" valign="top" class="pop-tp-clr" align="left">
                                            Select Date
                                        </td>
                                        <td width="5%" align="right" valign="middle" class="pop-tp-clr">
                                            <a href="#" onclick="document.getElementById('divdetail').style.display='none';"
                                                class="link01">
                                                <img src="../images/action_delete.gif" border="0" /></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left" valign="top">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td valign="top" class="reset">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="4">
                                                            <tr>
                                                                <td height="10">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td width="21%" class="frm-lft-clr123">
                                                                                From Date <span style="color:Red">*</span>
                                                                            </td>
                                                                            <td width="79%" class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_start_date" runat="server" CssClass="input" Width="140px" Enabled="False"></asp:TextBox>
                                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" ToolTip="click to open calender" />
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_start_date"
                                                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="From Date" ValidationGroup="s"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                                                                    TargetControlID="txt_start_date" FirstDayOfWeek="Monday" Format="dd-MMM-yyyy">
                                                                                </cc1:CalendarExtender>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">
                                                                                To Date <span style="color:Red">*</span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_end_date" runat="server" CssClass="input" Width="140px" Enabled="False"></asp:TextBox>
                                                                                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/clndr.gif" ToolTip="click to open calender" />
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_end_date"
                                                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="To Date" ValidationGroup="s"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                <asp:HiddenField ID="HiddenField2" runat="server" />
                                                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="Image2"
                                                                                    TargetControlID="txt_end_date" Format="dd-MMM-yyyy">
                                                                                </cc1:CalendarExtender>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="8">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                            <td>
                                                                                <asp:LinkButton ID="lnkViewEmpDetails" runat="server" OnClick="lnkViewEmpDetails_Click"
                                                                                    ValidationGroup="s" CssClass="txt-red">View Duty Roster</asp:LinkButton>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" class="txt02">
                                                                    <span id="Span2" runat="server"></span>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--</form>

</body>

</html>
    --%>
</asp:Content>
