<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Employee/Admin.master" AutoEventWireup="true"
    CodeFile="EmpReportColumnWise.aspx.cs" Inherits="Admin_Employee_EmpReportColumnWise" %>

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
                                    <td valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td valign="middle" class="txt02 blue-brdr-1" height="15">
                                                    &nbsp;Select Export Columns
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="5" valign="top">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Button ID="ImgExcel" runat="server" OnClick="ImgExcel_Click" CssClass="button2"
                                                        Text="Export To Excel" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="5" valign="top">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="middle" class="txt02 blue-brdr-1" height="15">
                                                    <asp:CheckBoxList ID="checkcolumns" runat="server" RepeatColumns="8" CssClass="select"
                                                        RepeatDirection="Horizontal" TextAlign="Right" CellSpacing="8" AppendDataBoundItems="True">
                                                    </asp:CheckBoxList>
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
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
