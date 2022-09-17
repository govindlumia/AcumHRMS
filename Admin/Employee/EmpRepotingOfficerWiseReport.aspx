<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Employee/Admin.master" AutoEventWireup="true"
    CodeFile="EmpRepotingOfficerWiseReport.aspx.cs" Inherits="Admin_Employee_EmpRepotingOfficerWiseReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css" media="all">
        @import "../../Css/blue1.css";
        @import "../../Css/example.css";
        @import "../../Css/ajax__tab_xp2.css";
    </style>
    <script type="text/javascript" src="../../js/tabber.js"></script>
    <script type="text/javascript">
        document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>
    <div class="header">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <asp:UpdatePanel ID="updatepannel1" runat="server">
                <ContentTemplate>
                    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="updatepannel1"
                        DisplayAfter="1" runat="server">
                        <ProgressTemplate>
                            <div class="divajax">
                                <table width="100%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <img src="../../images/loading.gif" alt="" />
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td class="blue-brdr-1">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td class="txt01">
                                        Employee Master&nbsp; Reporting Wise View
                                    </td>
                                    <td class="txt-red" align="right">
                                        <span id="message" runat="server">&nbsp;</span>
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
                                    <td valign="middle" class="txt02 blue-brdr-1" height="15">
                                        &nbsp;Search Employee
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
                                           
                                                <td width="23%">
                                                    <asp:Label ID="lblCmpy" runat="server" Text="Company" Font-Bold="true"></asp:Label><span style="color:Red">*</span>
                                                    <asp:DropDownList ID="ddlCmpy" CssClass="select" runat="server" Width="160" OnSelectedIndexChanged="ddlCmpy_SelectedIndexChanged"
                                                        AutoPostBack="true">
                                                     <%--   <asp:ListItem Text="--- Select ---" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Select Company" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="ALL" Value="2"></asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="ddlCmpy"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Company" ValidationGroup="v"
                                                        Width="6px" ErrorMessage="Please Select Company Name" InitialValue="0"> <img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                   <%-- <asp:DropDownList ID="drpCmpy" CssClass="select" runat="server" Visible="false" OnSelectedIndexChanged="drpCmpy_SelectedIndexChanged"
                                                        AutoPostBack="true">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpCmpy"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Company" ValidationGroup="v"
                                                        Width="6px" ErrorMessage="Please Select Company Name" InitialValue="0"> <img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                                </td>
                                                <td width="18%">
                                                    <asp:Label ID="lblBranch" runat="server" Text="Category" Font-Bold="true"></asp:Label><span style="color:Red">*</span>
                                                    <asp:DropDownList ID="ddlBranch" CssClass="select" Width="100" runat="server">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlBranch"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Category" ValidationGroup="v"
                                                        Width="6px" ErrorMessage="Please Select Category" InitialValue="0"> <img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </td>
                                                
                                                <td width="23%">
                                                    <asp:Label ID="lblStatus" runat="server" Text="Status" Font-Bold="true"></asp:Label><span style="color:Red">*</span>
                                                    <asp:DropDownList ID="ddlStatus" Width="120" CssClass="select" runat="server" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged"
                                                        AutoPostBack="true">
                                                      <%--  <asp:ListItem Text="--- Select ---" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Select Status" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="ALL" Value="2"></asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="ddlStatus"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Status" ValidationGroup="v"
                                                        Width="6px" ErrorMessage="Please Select Status" InitialValue="0"> <img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                 <%--   <asp:DropDownList ID="drpStatus" CssClass="select" runat="server" Visible="false">
                                                    </asp:DropDownList>--%>
                                                <%--    <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="drpStatus"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Status" ValidationGroup="v"
                                                        Width="6px" ErrorMessage="Please Select Status" InitialValue="0"> <img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
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
                                                        ValidationGroup="v" />
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
                                     <asp:Button ID="ImgExcel" runat="server" OnClick="ImgExcel_Click" CssClass="button2" Text="Export To Excel" />
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
                                              <PagerStyle CssClass="frm-lft-clr123" Width="500px" Font-Size="18px"  HorizontalAlign="Left" VerticalAlign="Top"/>
                                                <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" Visible="true" LastPageText="last" NextPageText="next" PreviousPageText="prev"  FirstPageText="first" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                                <tr style="height: 3px;">
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                       
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <asp:ValidationSummary ID="ValidationSummary6" ShowMessageBox="True" ShowSummary="False"
        runat="server" ValidationGroup="v"></asp:ValidationSummary>
</asp:Content>
