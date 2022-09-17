<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AttendanceReport.aspx.cs" MasterPageFile="~/Leave/admin/Admin.master" Inherits="Leave_admin_AttendanceReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<%--<html xmlns="http://www.w3.org/1999/xhtml">--%>
<%--<head id="Head1" runat="server">
    <title>Attendance</title>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />--%>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        .input3
        {
            font: normal 11px Arial, Helvetica, sans-serif;
            color: #000;
        }
    </style>
<%--    <script type="text/javascript" src="../js/timepicker.js"></script>--%>
    <script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>

    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
   
            <div class="header">
                <script type="text/javascript">
                    var TotalChkBx;
                    var Counter;

                    window.onload = function () {
                        //Get total no. of CheckBoxes in side the GridView.
                        TotalChkBx = parseInt('<%= this.adjustgrid.Rows.Count %>');

                        //Get total no. of checked CheckBoxes in side the GridView.
                        Counter = 0;
                    }

                    function HeaderClick(CheckBox) {
                        //Get target base & child control.
                        var TargetBaseControl =
       document.getElementById('<%= this.adjustgrid.ClientID %>');
                        var TargetChildControl = "chkselect";

                        //Get all the control of the type INPUT in the base control.
                        var Inputs = TargetBaseControl.getElementsByTagName("input");

                        //Checked/Unchecked all the checkBoxes in side the GridView.
                        for (var n = 0; n < Inputs.length; ++n)
                            if (Inputs[n].type == 'checkbox' &&
                Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                                Inputs[n].checked = CheckBox.checked;

                        //Reset Counter
                        Counter = CheckBox.checked ? TotalChkBx : 0;
                    }

                    function ChildClick(CheckBox, HCheckBox) {
                        //get target control.
                        var HeaderCheckBox = document.getElementById(HCheckBox);

                        //Modifiy Counter; 
                        if (CheckBox.checked && Counter < TotalChkBx)
                            Counter++;
                        else if (Counter > 0)
                            Counter--;

                        //Change state of the header CheckBox.
                        if (Counter < TotalChkBx)
                            HeaderCheckBox.checked = false;
                        else if (Counter == TotalChkBx)
                            HeaderCheckBox.checked = true;
                    }
                </script>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" colspan="2">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top" width="50%">
                                        <h3>
                                            Employee Attendance</h3>
                                           
                                    </td>
                                     <td  align="right">
                                     </td> 
                                 
                                </tr>
                                <tr>
                                    <td colspan="2" valign="top" style="height: 5px" class="txt-red" align="left">
                                        <span id="message" runat="server"></span>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" colspan="2">
                                        <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                            <tr>
                                                <td valign="middle" class="frm-lft-clr123">
                                                    From Date (<img src="../images/error1.gif" alt="" />)
                                                </td>
                                                <td valign="bottom" class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_frmdate" runat="server" CssClass="input2"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_frmdate"
                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                    <asp:Image ID="img" runat="server" ImageUrl="../images/clndr.gif" />&nbsp;
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="img" TargetControlID="txt_frmdate" Format="dd-MMM-yyyy">
                                                    </cc1:CalendarExtender>
                                                </td>
                                                <td valign="middle" class="frm-lft-clr123">
                                                    To Date (<img src="../images/error1.gif" alt="" />)
                                                </td>
                                                <td valign="bottom" class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_todate" runat="server" CssClass="input2"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_todate"
                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="../images/clndr.gif" />&nbsp;
                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="Image1"
                                                        TargetControlID="txt_todate" Format="dd-MMM-yyyy">
                                                    </cc1:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <div id="dvempcode" runat="server">
                                                                <table width="100%">
                                                                <tr>
                                                                    <td width="30%" valign="middle" class="frm-lft-clr123">
                                                Emp Code (<img src="../images/error1.gif" alt="" />) 
                                                                    </td>
                                                                    <td valign="bottom" class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_employee" runat="server" CssClass="input2" ClientIDMode="Static" ></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_employee"
                                                                            ErrorMessage='<img src="../images/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                                        &nbsp;<%--<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"
                                                                            CssClass="link05" ValidationGroup="noone">Pick</asp:LinkButton>--%>
                                                                             <a href="JavaScript:newPopup1('../../pickempwithdata.aspx?HR=0&MSS=0&Emp=1&Con=txt_employee');" class="link05">Pick Employee</a>
                                                                        &nbsp;<br />
                                                                       
                                                                    </td>
                                                                    <td valign="bottom" class="frm-rght-clr123" align="right">
                                                                        <asp:Button ID="Button3" runat="server" CssClass="button1" OnClick="Button1_Click"
                                                                            Text="Fetch Attendance" />
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
                                                <td colspan="4">
                                                <div id="dvsearch" runat="server">
                                                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                        
                                                            <tr>
                                                                <td width="52%" class="frm-rght-clr123">
                                                                    <asp:RadioButtonList runat="server" ID="rbtn" RepeatDirection="Horizontal" 
                                                                        AutoPostBack="true" OnSelectedIndexChanged="rbtn_OnSelectedIndexChanged" 
                                                                        style="margin-bottom: 0px">
                                                                        <asp:ListItem Value="0">View Process Data</asp:ListItem>
                                                                        <asp:ListItem Value="1">View Movement(Not for OD)</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                  
                                                                </td>
                                                                <td align="right" class="frm-rght-clr123" valign="bottom">
                                                                 <asp:Button ID="btn_exporttoexcel" runat="server" CssClass="button" Text="Export Excel" 
                                                                                    ValidationGroup="search" onclick="btn_exporttoexcel_Click" />&nbsp;
                                                                    <asp:Button ID="BtnSearch" runat="server" CssClass="button1" OnClick="BtnSearch_Click"
                                                                        Text="Search" />
                                                                </td>
                                                            </tr>
                                                        
                                                    </table>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" height="10" valign="middle" class="txt1">
                                                </td>
                                            </tr>
                                            <tr id="update" runat="server" visible="false">
                                                <td class="head-2" valign="top" colspan="5">
                                                    <asp:GridView ID="empgrid" runat="server" Font-Size="11px" Font-Names="Arial" CellSpacing="0"
                                                        CellPadding="3" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" AllowPaging="True"
                                                        PageSize="50" EmptyDataText="No data exists !" OnPageIndexChanging="empgrid_PageIndexChanging"
                                                        OnRowDataBound="empgrid_rowDataBound">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Emp Code">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblempcode" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Emp Name">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblempname" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Date">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbldateg" runat="server" Text='<%# Bind ("date", "{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField Visible="false" HeaderText="Card No">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblcardnog" runat="server" Text='<%# Bind ("Empcode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Mode">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblmodeg" runat="server" Text='<%# Bind ("mode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="INTime(AM)">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="txtintime" runat="server" Text='<%# Eval("intime", "{0:HH:mm tt}") %>' Width="81px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="OUTTime(PM)">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="txtouttime" runat="server" Text='<%# Eval("outtime", "{0:HH:mm tt}") %>' Width="78px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Action">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234"
                                                                    Width="10%" />
                                                                <ItemTemplate>
                                                                    <a href="javascript:void(window.open('AttendanceSummary.aspx?date=<%#DataBinder.Eval(Container.DataItem, "date")%>&empcode=<%#DataBinder.Eval(Container.DataItem,"empcode")%>','title','height=550,width=778,left=100,top=30'));"
                                                                        class="link05">View Details </a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                        <FooterStyle CssClass="frm-lft-clr123" />
                                                        <RowStyle Height="5px" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-2" valign="top" colspan="5">
                                                    <div runat="server" id="dvViewMovement" visible="false" >
                                                        <asp:GridView ID="GridViewMovement" runat="server" Font-Size="11px" Font-Names="Arial"
                                                            CellSpacing="0" CellPadding="3" Width="100%" AutoGenerateColumns="False" BorderWidth="0px"
                                                            AllowPaging="True" PageSize="50" EmptyDataText="No data exists !" OnPageIndexChanging="GridViewMovements_PageIndexChanging">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Emp Code">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblempcode" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Emp Name">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle Width="30%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblempname" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Year">
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                    <ItemStyle  HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblyear" runat="server" Text='<%# Bind ("year") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Date">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle  HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbldateg" runat="server" Text='<%# Bind ("date") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="InTime1">
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblintime1" runat="server" Text='<%# Bind ("Intime1") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="OutTime1">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle  HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblouttime1" runat="server" Text='<%# Bind ("outtime1") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="InTime2">
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="txtintime2" runat="server" Text='<%# Eval("intime2") %>' ></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="OutTime2">
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                    <ItemStyle  HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="txtouttime2" runat="server" Text='<%# Eval("outtime2") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="InTime3">
                                                                    <HeaderStyle  CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234"
 />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="txtintime3" runat="server" Text='<%# Eval("intime3") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="OutTime3">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234"
                                                                        />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="txtouttime3" runat="server" Text='<%# Eval("outtime3") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="InTime4">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234"
                                                                        />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="txtintime4" runat="server" Text='<%# Eval("intime4") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="OutTime4">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234"
                                                                         />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="txtouttime4" runat="server" Text='<%# Eval("outtime4") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="InTime4">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234"
                                                                        />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="txtintime5" runat="server" Text='<%# Eval("intime5") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="OutTime5">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234"
                                                                        />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="txtouttime5" runat="server" Text='<%# Eval("outtime5") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle CssClass="frm-lft-clr123" />
                                                            <FooterStyle CssClass="frm-lft-clr123" />
                                                            <RowStyle Height="5px" />
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" height="10" valign="middle" class="txt1" align="right">
                                        <%--<asp:Button ID="Button1" runat="server" CssClass="button1" OnClick="Button1_Click2"
         Text="Update Attendance" Visible="False" />--%></td>
                                </tr>
                              <tr>
                                    <td colspan="2" height="5" valign="top">
                                    </td></tr>
                            </table>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:HiddenField ID="HiddenField2" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="p3" runat="server" visible="false" class="pop2" align="center">
                <table width="450" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="pop-brdr">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="95%" valign="top" class="pop-tp-clr" align="left">
                                        Pick Employee
                                                           
                                    </td>
                                    <td width="5%" align="right" valign="top" class="pop-tp-clr">
                                        <a href="#" onclick="document.getElementById('divdetail').style.display='none';"
                                            class="pop-tp-clr">
                                            <asp:ImageButton ID="img_close" runat="server" ImageUrl="~/images/btn-close.gif"
                                                OnClick="img_close_Click" ValidationGroup="close" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left" valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td valign="top">
                                                    <table width="100%" border="1" cellspacing="0" cellpadding="3" bordercolor="#93b5c8"
                                                        style="border-collapse: collapse;">
                                                        <tr>
                                                            <td colspan="3" valign="top" width="100%">
                                                                <div id="divscrol" runat="server" style="position: static; width: 480px; height: 450px;
                                                                    overflow-x: hidden; overflow-y: scroll; left: 1px; top: 3px;">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="19%">
                                                                                Employee Name
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="30%">
                                                                                <asp:TextBox ID="txtempcode" runat="server" CssClass="input" Width="140"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="5" colspan="2">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="18%">
                                                                                Designation
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="32%">
                                                                                <asp:DropDownList ID="dd_designation" runat="server" CssClass="select2" DataSourceID="SqlDataSource1"
                                                                                    DataTextField="designationname" DataValueField="id" OnDataBound="dd_designation_DataBound"
                                                                                    Width="140px">
                                                                                </asp:DropDownList>
                                                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_DesignationMaster] order by designationname">
                                                                                </asp:SqlDataSource>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="5" colspan="2">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">
                                                                                Category
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:DropDownList ID="dd_branch" runat="server" CssClass="select2" DataSourceID="SqlDataSource2"
                                                                                    DataTextField="CategoryName" DataValueField="ID" OnDataBound="dd_branch_DataBound"
                                                                                    Width="140px">
                                                                                </asp:DropDownList>
                                                                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  ID,CategoryName FROM [tbl_category_master] order by CategoryName">
                                                                                </asp:SqlDataSource>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="5" height="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">
                                                                                Bussiness Unit
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:DropDownList ID="ddlbranch" runat="server" CssClass="select" DataSourceID="SqlDataSource21"
                                                                                    DataTextField="BussinessUnitName" DataValueField="ID" OnDataBound="ddlbranch_DataBound"
                                                                                    Width="140px">
                                                                                </asp:DropDownList>
                                                                                <asp:SqlDataSource ID="SqlDataSource21" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  ID, BussinessUnitName FROM tbl_bussinessunit_master">
                                                                                </asp:SqlDataSource>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="9%" colspan="2" align="right">
                                                                                <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_click"
                                                                                    ValidationGroup="search" />
                                                                           
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <asp:GridView ID="adjustgrid" runat="server" Font-Size="11px" Font-Names="Arial"
                                                                        DataKeyNames="empcode" CellPadding="4" Width="100%" AutoGenerateColumns="False"
                                                                        BorderWidth="0px" EmptyDataText="No Emp record found" OnRowDataBound="adjustgrid_RowDataBound">
                                                                        <Columns>
                                                                            <asp:TemplateField>
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                <HeaderTemplate>
                                                                                    <asp:CheckBox ID="chkBxHeader" onclick="javascript:HeaderClick(this);" runat="server" />
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkselect" runat="server" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Emp Code">
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                <ItemStyle Width="30%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Emp Name">
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                <ItemStyle Width="60%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <FooterStyle CssClass="frm-lft-clr123" />
                                                                        <RowStyle Height="5px" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="20" colspan="3" align="right" valign="middle">
                                                                <asp:Button ID="btn_ok" runat="server" CssClass="button" Text="Add" OnClick="btn_ok_Click"
                                                                    ValidationGroup="no" />
                                                                <asp:Button ID="btn_close" runat="server" CssClass="button" Text="Close" OnClick="btn_close_Click"
                                                                    ValidationGroup="no" />
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
       <%-- </ContentTemplate>--%>
    <%--</asp:UpdatePanel>--%>
    <%--</form>--%>
<%--</body>
</html>--%>
</asp:Content>