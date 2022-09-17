<%@ Page Title="" Language="C#" MasterPageFile="~/TimeSheet/User/TimesheetUser.master"
    AutoEventWireup="true" CodeFile="MyEmployeeTimeSheet.aspx.cs" Inherits="TimeSheet_User_MyEmployeeTieSheet" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajax:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <Triggers>

    </Triggers>
        <ContentTemplate>
            <div id="HomePage" runat="server">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tbody>
                        <tr>
                            <td class="blue-brdr-1">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td class="txt01">
                                            <img alt="" src="../../images/header-icon.png" />
                                            Employee TimeSheet
                                        </td>
                                        <td align="right">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="blue-brdr-1">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td class="frm-lft-clr123" width="25%">
                                            TimeSheet Pending for Action(s)
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="grd_pending" runat="server" AutoGenerateColumns="False" Width="100%"
                                    BorderWidth="1px" CellPadding="4" DataKeyNames="TimeSheetID" PageSize="10" 
                                    AllowPaging="true" EmptyDataText="No Record(s) found"  ViewStateMode="Enabled"
                                    onrowdatabound="grd_pending_RowDataBound"
                                    onrowcommand="grd_pending_RowCommand" 
                                    onpageindexchanging="grd_pending_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Employee Name">
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" Width="130" />
                                            <ItemTemplate>
                                           <asp:Label runat="server" ID="lbl_empcode" Text='<%#bind("Empcode")%>' Visible="false"></asp:Label>
                                           <asp:Label runat="server" ID="lbl_weekID" Text='<%#bind("WeekID") %>' Visible="false"></asp:Label>
                                                <asp:Label runat="server" ID="lbl_projectname" Text='<%# bind("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Timesheet Period">
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" Width="130" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_actname" Text='<%# Convert.ToDateTime(Eval("StartDate")).ToString("dd-MMM-yyyy")+" to "+ Convert.ToDateTime(Eval("EndDate")).ToString("dd-MMM-yyyy")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" Width="45" />
                                            <ItemTemplate >
                                           
                                    
                             
                           <asp:LinkButton ID="lnk_viewed" runat="server" Text="view" CommandName="Viewed" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'></asp:LinkButton>
                                     
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                    <tr>
                                        <td width="40%">
                                            <div runat="server" id="dv_status" visible="false">
                                            
                                            </div>
                                        </td>
                                        <td width="12%" align="center">
                                           <%-- <asp:Button ID="btnEdit" runat="server" CssClass="button" Text="Edit" OnClick="btnEdit_Click" />--%></td>
                                        <td width="12%" align="center">
                                          <%--  <asp:Button ID="btn_submit" runat="server" CssClass="button" Text="Submit" OnClick="btn_submit_Click" />--%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr style="height: 60px">
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                                <h5>
                                 &nbsp;</h5>
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
