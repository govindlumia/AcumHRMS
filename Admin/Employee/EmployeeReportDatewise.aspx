<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Employee/Admin.master" AutoEventWireup="true"
    CodeFile="EmployeeReportDatewise.aspx.cs" Inherits="Admin_Employee_EmployeeReportDatewise" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ContentPlaceHolderID="cph_header" runat="server" ID="Content_head">
    <style type="text/css" media="all">
        @import "../../Css/blue1.css";
        @import "../../Css/example.css";
        @import "../../Css/ajax__tab_xp2.css";
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../../js/tabber.js"></script>
    <script type="text/javascript">
        document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>
    <script type="text/javascript">
        function hideShow(drp, div1) {



            var ddl = document.getElementById(drp);
            var D1 = document.getElementById(div1);



            if (ddl.value == 1) {
                D1.style["display"] = "block";
            }

            else {
                D1.style["display"] = "none";
            }


        }
    </script>
    <div>
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td class="blue-brdr-1">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td class="txt01">
                                    Employee Master&nbsp; Date Wise View
                                </td>
                                <td class="txt-red" align="right">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="7">
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                                        OnSelectedIndexChanged="RadioButtonList1_SelectedIndex" AutoPostBack="true">
                                        <asp:ListItem Text="Search By Date of Joining" Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Search By Date of Leaving" Value="0" Selected="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td height="5" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <div id="DivDoj" runat="server" style="display: none;">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td valign="middle" class="txt02 blue-brdr-1" height="15">
                                                                &nbsp;Search Employee By Date Of joining
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="5" valign="top">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <ajaxToolkit:ToolkitScriptManager EnablePartialRendering="true" runat="Server" ID="ToolkitScriptManager1" />
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td width="22%">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <div>
                                                                                            <asp:Label ID="lblCmpy" runat="server" Text="Company" Font-Bold="true"></asp:Label><span style="color:Red">*</span>
                                                                                            <asp:DropDownList ID="ddlCmpy" CssClass="select" runat="server">
                                                                                                <asp:ListItem Text="--- Select ---" Value="0"></asp:ListItem>
                                                                                                <asp:ListItem Text="Select Company" Value="1"></asp:ListItem>
                                                                                                <asp:ListItem Text="ALL" Value="2"></asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                            <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="ddlCmpy"
                                                                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Company" ValidationGroup="v"
                                                                                                Width="6px" ErrorMessage="Please Select Company Name" InitialValue="0"> <img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                    </td>
                                                                                    <td>
                                                                                        <div id="DivCmpy" runat="server" style="display: none;">
                                                                                            <asp:DropDownList ID="drpCmpy" CssClass="select" runat="server" OnSelectedIndexChanged="drpCmpy_SelectedIndexChanged"
                                                                                                AutoPostBack="true">
                                                                                            </asp:DropDownList>
                                                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpCmpy"
                                                                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Company" ValidationGroup="v"
                                                                                                Width="6px" ErrorMessage="Please Select Company Name" InitialValue="0"> <img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                                                                        </div>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td width="18%">
                                                                            <asp:Label ID="lblBranch" runat="server" Text="Category" Font-Bold="true"></asp:Label>
                                                                            &nbsp; &nbsp;
                                                                            <asp:DropDownList ID="ddlBranch" CssClass="select" runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td width="19%">
                                                                            <asp:Label ID="lblFromDate" runat="server" Text="From Date" Font-Bold="true"></asp:Label>
                                                                            &nbsp; &nbsp;
                                                                            <asp:TextBox ID="txtFromDate" runat="server" Width="90px"></asp:TextBox><span style="color:Red">*</span>
                                                                            <asp:ImageButton ID="imgFromDate" runat="server" ImageUrl="../../images/clndr.gif"
                                                                                ToolTip="Click to open/close calender" />
                                                                            <ajaxToolkit:CalendarExtender ID="ceFromDate" runat="server" TargetControlID="txtFromDate"
                                                                                Enabled="True" PopupButtonID="imgFromDate" Format="dd-MMM-yyyy">
                                                                            </ajaxToolkit:CalendarExtender>
                                                                            <asp:RequiredFieldValidator ID="RRFV1" runat="server" ControlToValidate="txtFromDate"
                                                                                Display="Dynamic" SetFocusOnError="True" ToolTip="From Date" ValidationGroup="v"
                                                                                Width="6px" ErrorMessage="Please Select From Date"> <img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td width="18%">
                                                                            <asp:Label ID="lblToDate" runat="server" Text="To Date" Font-Bold="true"></asp:Label><span style="color:Red">*</span>
                                                                            &nbsp; &nbsp;
                                                                            <asp:TextBox ID="txtToDate" runat="server" Width="100px"></asp:TextBox>
                                                                            <asp:ImageButton ID="imgToDate" runat="server" ImageUrl="../../images/clndr.gif"
                                                                                ToolTip="Click to open/close calender" />
                                                                            <ajaxToolkit:CalendarExtender ID="ceToDate" runat="server" TargetControlID="txtToDate"
                                                                                Enabled="True" PopupButtonID="imgToDate" Format="dd-MMM-yyyy">
                                                                            </ajaxToolkit:CalendarExtender>
                                                                            <asp:RequiredFieldValidator ID="RRFV" runat="server" ControlToValidate="txtToDate"
                                                                                Display="Dynamic" SetFocusOnError="True" ToolTip="To Date" ValidationGroup="v"
                                                                                Width="6px" ErrorMessage="Please Select To Date" > <img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td width="23%">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <div>
                                                                                            <asp:Label ID="lblStatus" runat="server" Text="Status" Font-Bold="true"></asp:Label>
                                                                                            &nbsp; &nbsp;
                                                                                            <asp:DropDownList ID="ddlStatus" CssClass="select" runat="server">
                                                                                                <asp:ListItem Text="--- Select ---" Value="0"></asp:ListItem>
                                                                                                <asp:ListItem Text="Select Status" Value="1"></asp:ListItem>
                                                                                                <asp:ListItem Text="ALL" Value="2"></asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                            <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="ddlStatus"
                                                                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Status" ValidationGroup="v"
                                                                                                Width="6px" ErrorMessage="Please Select Status" InitialValue="0"> <img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                    </td>
                                                                                    <td>
                                                                                        <div id="divstatus" runat="server" style="display: none;">
                                                                                            <asp:DropDownList ID="drpStatus" CssClass="select" runat="server">
                                                                                            </asp:DropDownList>
                                                                                            <%--<asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="drpStatus"
                                                                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Status" ValidationGroup="v"
                                                                                                Width="6px" ErrorMessage="Please Select Status" InitialValue="0"> <img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                                                                        </div>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="5" valign="top">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-rght-clr123" colspan="2">
                                                                <table cellpadding="0" cellspacing="0" width="99%" border="0">
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="Search" OnClick="btnSearch_Click"
                                                                                ValidationGroup="v"></asp:Button>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="5" valign="top">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:DropDownList ID="drpAll" runat="server" CssClass="input" AutoPostBack="true"
                                                                                OnSelectedIndexChanged="drpAll_SelectedIndexChanged">
                                                                                <asp:ListItem>Allow paging</asp:ListItem>
                                                                                <asp:ListItem>View all on one page</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td class="frm-rght-clr123" align="right">
                                                                            <div id="div1" runat="server" visible="true" class="paging-heading" style="display: block;">
                                                                                <span class="p-page"><i>Total Records : <b>
                                                                                    <asp:Label ID="lblTotalRecord" Text="" runat="server"></asp:Label></b></i></span>
                                                                                <span class="p-page"><i>|| Page Size : <b>
                                                                                    <%=gvODReport.Rows.Count%>
                                                                                </b>|| You are viewing page <b>
                                                                                    <%=gvODReport.PageIndex + 1%>
                                                                                </b>of <b>
                                                                                    <%=gvODReport.PageCount%>
                                                                                </b></i></span>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="5" valign="top">
                                                            </td>

                                                        </tr>

                                                          <tr>
                                                            <td align="right">
                                                            
<asp:Button ID="Btn_dol" runat="server" CssClass="button2" OnClick="Btn_dol_Click"
                                                                    Text="Export To Excel" />
                                                            </td>

                                                        </tr>
                                                          <tr>
                                                            <td height="5" valign="top">
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <div style="width: 1000px; height: 800px; overflow: scroll;">
                                                                    <asp:GridView ID="gvODReport" runat="server" Width="100%" BorderColor="#c9dffb" BorderStyle="Solid"
                                                                        BorderWidth="1px" CellPadding="4" Font-Names="Arial" Font-Size="11px" EmptyDataText="No Record(s) Found"
                                                                        OnPageIndexChanging="gvODReport_PageIndexChanging" AllowPaging="true" PageSize="15">
                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                        <FooterStyle CssClass="frm-lft-clr123" />
                                                                        <RowStyle Height="5px" CssClass="frm-rght-clr1234" />
                                                                        <PagerStyle CssClass="frm-lft-clr123" Width="500px" Font-Size="18px" HorizontalAlign="Left"
                                                                            VerticalAlign="Top" />
                                                                        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" Visible="true" LastPageText="last"
                                                                            NextPageText="next" PreviousPageText="prev" FirstPageText="first" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr style="height: 3px;">
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" style="padding-right: 30px">
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
                                <td>
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <div id="DivDOL" runat="server" style="display: none;">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td valign="middle" class="txt02 blue-brdr-1" height="15">
                                                                &nbsp;Search Employee By Data of leaving
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="5" valign="top">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td width="22%">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <div>
                                                                                            <asp:Label ID="lbl_type" runat="server" Text="Company" Font-Bold="true"></asp:Label><span style="color:Red">*</span>
                                                                                            <asp:DropDownList ID="DDL_CMPY" CssClass="select" runat="server">
                                                                                                <asp:ListItem Text="--- Select ---" Value="0"></asp:ListItem>
                                                                                                <asp:ListItem Text="Select Company" Value="1"></asp:ListItem>
                                                                                                <asp:ListItem Text="ALL" Value="2"></asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                            <asp:RequiredFieldValidator ID="RRFV2" runat="server" ControlToValidate="DDL_CMPY"
                                                                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Company" ValidationGroup="p"
                                                                                                Width="6px" ErrorMessage="Please Select Company Name" InitialValue="0"> <img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                    </td>
                                                                                    <td>
                                                                                        <div id="Divcmpydol" runat="server" style="display: none;">
                                                                                            <asp:DropDownList ID="Drp_Cmpy" CssClass="select" runat="server" OnSelectedIndexChanged="Drp_Cmpy_SelectedIndexChanged"
                                                                                                AutoPostBack="true">
                                                                                            </asp:DropDownList>
                                                                                            <%--<asp:RequiredFieldValidator ID="RRFV3" runat="server" ControlToValidate="DRPCMPY"
                                                                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Company" ValidationGroup="p"
                                                                                                Width="6px" ErrorMessage="Please Select Company Name" InitialValue="0"> <img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                                                                        </div>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td width="18%">
                                                                            <asp:Label ID="Label2" runat="server" Text="Category" Font-Bold="true"></asp:Label>
                                                                            &nbsp; &nbsp;
                                                                            <asp:DropDownList ID="Drp_Branch" CssClass="select" runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td width="19%">
                                                                            <asp:Label ID="LBL_fromdol" runat="server" Text="From Date" Font-Bold="true"></asp:Label>
                                                                            &nbsp; &nbsp;
                                                                            <asp:TextBox ID="txt_fromdol" runat="server" Width="90px"></asp:TextBox><span style="color:Red">*</span>
                                                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../../images/clndr.gif"
                                                                                ToolTip="Click to open/close calender" />
                                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_fromdol"
                                                                                Enabled="True" PopupButtonID="ImageButton1" Format="dd-MMM-yyyy">
                                                                            </ajaxToolkit:CalendarExtender>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_fromdol"
                                                                                Display="Dynamic" SetFocusOnError="True" ToolTip="From date" ValidationGroup="p"
                                                                                Width="6px" ErrorMessage="Please Enter From date"> <img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td width="18%">
                                                                            <asp:Label ID="lbl_todol" runat="server" Text="To Date" Font-Bold="true"></asp:Label>
                                                                            &nbsp; &nbsp;
                                                                            <asp:TextBox ID="txttodol" runat="server" Width="100px"></asp:TextBox><span style="color:Red">*</span>
                                                                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="../../images/clndr.gif"
                                                                                ToolTip="Click to open/close calender" />
                                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodol"
                                                                                Enabled="True" PopupButtonID="ImageButton2" Format="dd-MMM-yyyy">
                                                                            </ajaxToolkit:CalendarExtender>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttodol"
                                                                                Display="Dynamic" SetFocusOnError="True" ToolTip="To date" ValidationGroup="p"
                                                                                Width="6px" ErrorMessage="Please Enter To date"> <img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td width="23%">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <div>
                                                                                            <asp:Label ID="Lbl_status" runat="server" Text="Status" Font-Bold="true"></asp:Label><span style="color:Red">*</span>
                                                                                            &nbsp; &nbsp;
                                                                                            <asp:DropDownList ID="DDLSTATUSDOL" CssClass="select" runat="server">
                                                                                                <asp:ListItem Text="--- Select ---" Value="0"></asp:ListItem>
                                                                                                <asp:ListItem Text="Select Status" Value="1"></asp:ListItem>
                                                                                                <asp:ListItem Text="ALL" Value="2"></asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DDLSTATUSDOL"
                                                                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Status" ValidationGroup="p"
                                                                                                Width="6px" ErrorMessage="Please Select Status" InitialValue="0"> <img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                    </td>
                                                                                    <td>
                                                                                        <div id="Div_Status" runat="server" style="display: none;">
                                                                                            <asp:DropDownList ID="DRP_status" CssClass="select" runat="server">
                                                                                            </asp:DropDownList>
                                                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DRP_status"
                                                                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Status" ValidationGroup="p"
                                                                                                Width="6px" ErrorMessage="Please Select Status" InitialValue="0"> <img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                                                                        </div>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="5" valign="top">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-rght-clr123" colspan="2">
                                                                <table cellpadding="0" cellspacing="0" width="99%" border="0">
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Button ID="btn_search1" runat="server" CssClass="button" Text="Search" OnClick="btn_search1_Click"
                                                                                ValidationGroup="p" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="5" valign="top">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:DropDownList ID="drpAlldol" runat="server" CssClass="input" AutoPostBack="true"
                                                                                OnSelectedIndexChanged="drpAll_SelectedIndexChanged">
                                                                                <asp:ListItem>Allow paging</asp:ListItem>
                                                                                <asp:ListItem>View all on one page</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td class="frm-rght-clr123" align="right">
                                                                            <div id="div5" runat="server" visible="true" class="paging-heading" style="display: block;">
                                                                                <span class="p-page"><i>Total Records : <b>
                                                                                    <asp:Label ID="LBL_total" Text="" runat="server"></asp:Label></b></i></span>
                                                                                <span class="p-page"><i>|| Page Size : <b>
                                                                                    <%=Grdleaving.Rows.Count%>
                                                                                </b>|| You are viewing page <b>
                                                                                    <%=Grdleaving.PageIndex + 1%>
                                                                                </b>of <b>
                                                                                    <%=Grdleaving.PageCount%>
                                                                                </b></i></span>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                      
                                                            <tr>
                                                                <td height="5px" valign="top">
                                                                </td>
                                                            </tr>
                                                              <tr>
                                                            <td align="right">
                                                                <asp:Button ID="ImgExcel" runat="server" CssClass="button2" OnClick="ImgExcel_Click"
                                                                    Text="Export To Excel" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="5px" valign="top">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <div style="width: 1000px; height: 800px; overflow: scroll;">
                                                                    <asp:GridView ID="Grdleaving" runat="server" Width="100%" BorderColor="#c9dffb" BorderStyle="Solid"
                                                                        BorderWidth="1px" CellPadding="4" Font-Names="Arial" Font-Size="11px" EmptyDataText="No Record(s) Found"
                                                                        OnPageIndexChanging="Grdleaving_PageIndexChanging" AllowPaging="true" PageSize="15">
                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                        <FooterStyle CssClass="frm-lft-clr123" />
                                                                        <RowStyle Height="5px" CssClass="frm-rght-clr1234" />
                                                                        <PagerStyle CssClass="frm-lft-clr123" Width="500px" Font-Size="18px" HorizontalAlign="Left"
                                                                            VerticalAlign="Top" />
                                                                        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" Visible="true" LastPageText="last"
                                                                            NextPageText="next" PreviousPageText="prev" FirstPageText="first" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr style="height: 3px;">
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" style="padding-right: 30px">
                                                                
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <asp:ValidationSummary ID="ValidationSummary6" ShowMessageBox="True" ShowSummary="False"
        runat="server" ValidationGroup="v"></asp:ValidationSummary>
    <asp:ValidationSummary ID="ValidationSummary7" ShowMessageBox="True" ShowSummary="False"
        runat="server" ValidationGroup="p"></asp:ValidationSummary>
</asp:Content>
