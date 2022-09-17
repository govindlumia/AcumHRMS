<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Employee/Admin.master" AutoEventWireup="true"
    CodeFile="EmpReport.aspx.cs" Inherits="Admin_Employee_EmpReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css" media="all">
        @import "../../Css/blue1.css";
        @import "../../Css/example.css";
        @import "../../Css/ajax__tab_xp2.css";
        .style1
        {
            border-left: 1px solid #c9dffb;
            border-top: 1px solid #c9dffb;
            border-bottom: 1px solid #c9dffb;
            background: #edf5ff;
            padding: 4px 0 4px 5px;
            font: bold 11px verdana, Helvetica, sans-serif;
            color: #013366;
            height: 42px;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
        }
        .style2
        {
            background: #f8fbff;
            border: 1px solid #c9dffb;
            padding: 5px 0 5px 5px;
            font: normal 12px Arial, Helvetica, sans-serif;
            color: #013366;
            height: 42px;
        }
    </style>
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
    <div class="header">
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>--%>
        <div>
            <%-- <asp:UpdatePanel ID="updatepannel1" runat="server">
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
                    </asp:UpdatePanel>--%>
        </div>
        <div>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td class="blue-brdr-1">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td class="txt01">
                                        Employee Master View
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
                                                <td width="30%">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <div>
                                                                    <asp:Label ID="lblCmpy" runat="server" Text="Company" Font-Bold="true"></asp:Label><span style="color:Red">*</span>
                                                                    <asp:DropDownList ID="ddlCmpy" CssClass="select" runat="server" AutoPostBack="True"
                                                                        OnSelectedIndexChanged="ddlCmpy_SelectedIndexChanged">
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
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpCmpy"
                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Company" ValidationGroup="v"
                                                                        Width="6px" ErrorMessage="Please Select Company Name" InitialValue="0"> <img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="18%">
                                                    <asp:Label ID="lblBranch" runat="server" Text="Category" Font-Bold="true"></asp:Label>
                                                    <asp:DropDownList ID="ddlBranch" CssClass="select" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="18%">
                                                    <asp:Label ID="lblDesg" runat="server" Text="Designation" Font-Bold="true"></asp:Label>
                                                    <asp:DropDownList ID="ddlDesg" CssClass="select" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="30%">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <div>
                                                                    <asp:Label ID="lblStatus" runat="server" Text="Status" Font-Bold="true"></asp:Label><span style="color:Red">*</span>
                                                                    <asp:DropDownList ID="ddlStatus" CssClass="select" runat="server" AutoPostBack="True"
                                                                        OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
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
                                                                    <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="drpStatus"
                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Status" ValidationGroup="v"
                                                                        Width="6px" ErrorMessage="Please Select Status" InitialValue="0"> 
                                                                        <img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
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
                                                <td align="right" colspan="3">
                                                    <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="Search" OnClick="btnSearch_Click"
                                                        OnClientClick="return validate();" ValidationGroup="v" />
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
                                        <asp:Button ID="ImgExcel" CssClass="button2" runat="server" OnClick="ImgExcel_Click"
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
                                                OnPageIndexChanging="gvODReport_PageIndexChanging" AllowPaging="true" PageSize="15"
                                                OnRowDataBound="gvODReport_RowDataBound" OnSelectedIndexChanged="gvODReport_SelectedIndexChanged">
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
