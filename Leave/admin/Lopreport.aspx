<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Lopreport.aspx.cs" Inherits="Leave_admin_Lopreport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Leave Report</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>
    <script language="JavaScript" type="text/javascript" src="js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="empdetail" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                runat="server">
               
                <ProgressTemplate>
                    <div class="divajax" style="left: 400px;">
                        <table width="100%">
                            <tr>
                                <td align="center" valign="top">
                                    <img src="images/loading.gif" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="bottom" align="center" class="txt01">
                                    Please Wait...
                                </td>
                            </tr>
                        </table>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div>
                <div  height: 512px; width: 968px;">
                    <table width="98%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top" class="blue-brdr-1">
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="3%">
                                            <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                        </td>
                                        <td class="txt01">
                                            LOP Balance
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="34" valign="middle">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td align="left" class="txt02">
                                            Search Employee
                                        </td>
                                        <td align="right">
                                            <a class="txt-red" href="javascript:history.back()" target="name123">Back</a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="5" valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="frm-lft-clr123" width="19%">
                                            Company
                                        </td>
                                        <td class="frm-rght-clr123" width="30%">
                                            <asp:DropDownList ID="ddlbranch" runat="server" CssClass="select"
                                                Width="140px">
                                            </asp:DropDownList>
                                            
                                        </td>
                                        <td width="1%" rowspan="3">
                                            &nbsp;
                                        </td>
                                        <td class="frm-lft-clr123" width="18%">
                                           Month
                                        </td>
                                        <td class="frm-rght-clr123" width="32%">
                                            <asp:DropDownList ID="Ddlmonth" runat="server" CssClass="select2" Width="140px">
                                                    <asp:ListItem Value="4">Apr</asp:ListItem>
                                                    <asp:ListItem Value="5">May</asp:ListItem>
                                                    <asp:ListItem Value="6">Jun</asp:ListItem>
                                                    <asp:ListItem Value="7">Jul</asp:ListItem>
                                                    <asp:ListItem Value="8">Aug</asp:ListItem>
                                                    <asp:ListItem Value="9">Sep</asp:ListItem>
                                                    <asp:ListItem Value="10">Oct</asp:ListItem>
                                                    <asp:ListItem Value="11">Nov</asp:ListItem>
                                                    <asp:ListItem Value="12">Dec</asp:ListItem>
                                                    <asp:ListItem Value="1">Jan</asp:ListItem>
                                                    <asp:ListItem Value="2">Feb</asp:ListItem>
                                                    <asp:ListItem Value="3">Mar</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="2">
                                        </td>
                                        <td height="5" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123">
                                            year
                                        </td>
                                        <td class="frm-rght-clr123">
                                            <asp:DropDownList ID="ddlyear" runat="server" CssClass="select2" Width="140px">
                                            </asp:DropDownList>
                                            
                                        </td>
                                        <td class="frm-lft-clr123">
                                           
                                        </td>
                                        <td class="frm-rght-clr123">
                                            
                                            <asp:Button ID="btnsearch" CssClass="button" runat="server" OnClick="btnsearch_Click" Text="Search" />
                                        </td>
                                    </tr>
                                        <tr>
                                        <td colspan="5" height="5">
                                        </td>
                                    </tr>

                                    <tr>
                                        <td colspan="5" height="5">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="9%" colspan="5" align="right">
                                        
                                       
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                        <td height="20" valign="top" class="txt02">
                        </td>
                        </tr>
                        <tr>
                            <td height="20" valign="top" class="txt02">
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="txt02" height="23" valign="top">
                                            Employee Details
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="head-2" valign="top">
                                            <asp:GridView ID="empgrid" runat="server" Font-Size="11px" Font-Names="Arial" CellPadding="4"
                                                Width="100%" AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="No such employee exists !"
                                                AllowPaging="True" PageSize="10" OnPageIndexChanging="empgrid_PageIndexChanging">
                                                <Columns>
                                                     <asp:TemplateField HeaderText="Employee Code">
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle Width="30%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l100" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Employee Name">
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle Width="30%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("emp_fname") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="LOP">
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                     <ItemStyle Width="40%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                     <ItemTemplate>
                                                            <asp:Label ID="l11" runat="server" Text='<%# Eval ("LWP") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="frm-lft-clr123" />
                                                <FooterStyle CssClass="frm-lft-clr123" />
                                                <RowStyle Height="5px" />
                                                <PagerStyle CssClass="frm-lft-clr123" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                                <asp:SqlDataSource ID="SqlDataSource4" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                    runat="server" SelectCommand="sp_leave_fetch_emp_detail" SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                                        <asp:Parameter DefaultValue="" Name="name" Type="String" />
                                        <asp:Parameter DefaultValue="0" Name="desg" Type="Int32" />
                                        <asp:Parameter DefaultValue="0" Name="CATEGORY" Type="Int32" />
                                        <asp:Parameter DefaultValue="All" Name="status" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td height="7">
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
