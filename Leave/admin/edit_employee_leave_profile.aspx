<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_employee_leave_profile.aspx.cs" Inherits="Leave_admin_createemployeeprofile" Title="Leave Approver" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Untitled Document</title>
<script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>
<style type="text/css" media="all">
@import "../css/blue1.css";
</style>
</head>

<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="leave" runat="server">
</asp:ScriptManager>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax"><table width="100%"><tr><td align="center" valign="top"><img src="../images/loading.gif" /></td><td valign="bottom">Please Wait...</td></tr></table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>

<table width="718" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td width="3%"><img src="../images/employee-icon.jpg" width="16" height="16" /></td>
        <td class="txt01">Employee Leave Profile</td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td height="10" valign="top" align="right" class="txt-red"><span id="message" runat="server"></span></td>
  </tr>
  <tr>
    <td height="22" valign="top" class="txt02">&nbsp;Edit Employee Profile</td>
  </tr>
  <tr>
    <td height="10" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="19%" class="frm-lft-clr123">Employee Code&nbsp;</td>
        <td class="frm-rght-clr123"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td><asp:Label ID="lbl_empcode" runat="server"></asp:Label></td>
            <td width="88px" style="height: 20px"></td>
          </tr>
        </table></td>
      </tr>
    </table></td>
  </tr>
  <tr>
      <td height="10">
      </td>
      </tr>
                       
                <tr>
                    <td height="5">
                    </td>
                </tr>
                <tr runat="server" visible="true">
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr runat="server">
                                <td class="txt02" height="25" valign="top">
                                    &nbsp;Approval Level&nbsp;
                                    <%--<asp:Button ID="btn_resetgrid" runat="server" CssClass="button" Text="Reset Grid" OnClick="btn_greset_Click" ValidationGroup="noone" />--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="head-2" valign="top">
                                    <asp:GridView ID="approvalgrid" runat="server" AutoGenerateColumns="False" 
                                        BorderWidth="0px" CellPadding="4" EmptyDataText="No record found" 
                                        Font-Names="Arial" Font-Size="11px" Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Emp Code">
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" 
                                                    VerticalAlign="Top" Width="24%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind ("approverid") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Approver Name">
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" 
                                                    VerticalAlign="Top" Width="24%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Level">
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" 
                                                    VerticalAlign="Top" Width="24%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("approverpriority") %>'></asp:Label>
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
                                <td height="20">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
           
           
        
    <tr runat="server" visible="true">
        <td valign="top">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td class="frm-lft-clr123" width="19%">
                        HC</td>
                    <td class="frm-rght-clr123">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td width="25%">
                                    <asp:TextBox ID="txt_hr" runat="server" CssClass="input"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ControlToValidate="txt_hr" Display="Dynamic" 
                                        ErrorMessage="&lt;img src=&quot;../images/error1.gif&quot; alt=&quot;Enter HR&quot; /&gt;" 
                                        ValidationGroup=""></asp:RequiredFieldValidator>
                                </td>
                                <td style="height: 20px" width="75%">
                                    &nbsp; <a class="link05" href="JavaScript:newPopup1('pickhr.aspx?code=hr');">Pick HC</a>
                                   <%-- <a class="link05" href="JavaScript:newPopup1('../../pickempwithdata.aspx?HR=1&MSS=0&Emp=0&Con=txt_hr');">Pick HC</a>--%>
                                     <asp:Button ID="Button1" runat="server" CssClass="button" 
                                                    OnClick="btn_add_Click" Text="Add" ValidationGroup="app" align="right" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                  <tr>
                    <td height="5" colspan="3">
                    </td>
                </tr>
                 <tr id="Tr1" runat="server" visible="true">
                    <td colspan="2">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr id="Tr2" runat="server">
                                <td class="txt02" height="25" valign="top">
                                    &nbsp;HC Approval &nbsp;
                                    <%--<asp:Button ID="btn_resetgrid" runat="server" CssClass="button" Text="Reset Grid" OnClick="btn_greset_Click" ValidationGroup="noone" />--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="head-2" valign="top">
                                    <asp:GridView ID="Grid_hr" runat="server" AutoGenerateColumns="False" 
                                        BorderWidth="0px" CellPadding="4" EmptyDataText="No record found" 
                                        Font-Names="Arial" Font-Size="11px" Width="100%" DataKeyNames="empcode" OnRowDeleting="Grid_hr_RowDeleting">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Emp Code">
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" 
                                                    VerticalAlign="Top" Width="24%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Approver Name">
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" 
                                                    VerticalAlign="Top" Width="24%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           <asp:TemplateField>
                                             <ItemTemplate>
                                          <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" CssClass="link04"
                                           Text="Delete"></asp:LinkButton></ItemTemplate>
                                           <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" Width="24%" CssClass="frm-rght-clr1234"></ItemStyle>
                                          </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                        <FooterStyle CssClass="frm-lft-clr123" />
                                        <RowStyle Height="5px" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td height="20">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td height="10" valign="top">
            &nbsp;</td>
    </tr>
   
    <tr>
        <td height="10">
        </td>
    </tr>
    <tr>
        <td class="txt02" height="22" valign="top">
            Set Leave Rule</td>
    </tr>
    <tr>
        <td height="10" valign="top">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td class="frm-lft-clr123" width="19%">
                        Leave Policy&nbsp;</td>
                    <td class="frm-rght-clr123">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td style="height: 20px" width="30%">
                                    <asp:DropDownList ID="drp_policy" runat="server" CssClass="select" 
                                        DataSourceID="SqlDataSource2" DataTextField="policyname" 
                                        DataValueField="policyid" Enabled="true" OnDataBound="drp_policy_DataBound" 
                                        Width="150px">
                                    </asp:DropDownList>
                                    &nbsp;<asp:CompareValidator ID="CompareValidator5" runat="server" 
                                        ControlToValidate="drp_policy" Display="Dynamic" 
                                        ErrorMessage="&lt;img src=&quot;../images/error1.gif&quot; alt=&quot;&quot; /&gt;" 
                                        Operator="NotEqual" ValidationGroup="a" ValueToCompare="0"><img src="../images/error1.gif" alt="" /></asp:CompareValidator>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>" 
                                        SelectCommand="select policyid,policyname from tbl_leave_createleavepolicy where status=1">
                                    </asp:SqlDataSource>
                                </td>
                                <td width="24%">
                                    <asp:Button ID="btn_policy" runat="server" CssClass="button" Text="Set Policy" 
                                        ValidationGroup="a" Visible="False" />
                                </td>
                                <td align="right" width="46%">
                                    <a class="link05" href="#" 
                                        onclick="document.getElementById('light').style.display='block';">Leave 
                                    Policy</a>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td height="10" valign="top">
        </td>
    </tr>
    <tr>
        <td height="10" valign="top">
            <asp:HiddenField ID="hidd_name" runat="server" />
            <asp:HiddenField ID="hiddenlevel" runat="server" Value="1" />
            &nbsp;
            <asp:HiddenField ID="hidden_hr" runat="server" />
        </td>
    </tr>
    <tr>
        <td height="10" valign="top">
        </td>
    </tr>
    <tr>
        <td height="10" valign="top">
            <asp:GridView ID="grid_customizerule" runat="server" 
                AutoGenerateColumns="False" BorderWidth="0px" CellPadding="4" 
                DataKeyNames="leaveid" EmptyDataText="No record found" Font-Names="Arial" 
                Font-Size="11px" Width="100%">
                <Columns>
                    <asp:TemplateField Visible="False">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" 
                            VerticalAlign="Top" Width="0%" />
                        <ItemTemplate>
                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("policyid") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="False">
                        <ItemStyle Width="0%" />
                        <ItemTemplate>
                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("leaveid") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Leave Policy">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" 
                            VerticalAlign="Top" Width="40%" />
                        <ItemTemplate>
                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("policyname") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Leave Type">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" 
                            VerticalAlign="Top" Width="30%" />
                        <ItemTemplate>
                            <asp:Label ID="l4" runat="server" Text='<%# Bind ("leavetype") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Entitled Days">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" 
                            VerticalAlign="Top" Width="30%" />
                        <ItemTemplate>
                            <asp:TextBox ID="txt_entdays" runat="server" CssClass="input" 
                                Text='<%# Bind("entitled_days")%>' onkeyup="checkNumericValueForCntrl(this)" MaxLength="5" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="txt_entdays" Display="Dynamic" 
                                ErrorMessage="&lt;img src=&quot;../images/error1.gif&quot; alt=&quot;Entitled days cannot be blank &quot; /&gt;" 
                                ValidationGroup="az"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                ControlToValidate="txt_entdays" Display="Dynamic" 
                                ErrorMessage="&lt;img src=&quot;../images/error1.gif&quot; alt=&quot;Data should be numeric and greater than 0&quot; /&gt;" 
                                MaximumValue="1000" MinimumValue="0" Type="Double" ValidationGroup="az"></asp:RangeValidator>
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
        <td height="10" valign="top">
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:HiddenField ID="HiddenField2" runat="server" Value="1" />
            &nbsp;
            <asp:HiddenField ID="HiddenField3" runat="server" />
            <%-- <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1" TargetControlID="txt_enforcement">
        </cc1:CalendarExtender>--%>
        </td>
    </tr>
    <tr>
        <td align="right" valign="top">
            <asp:Button ID="btn_submit" runat="server" CssClass="button" 
                OnClick="btn_submit_Click" Text="Submit" ValidationGroup="az" />
            <asp:Button ID="btn_reset" runat="server" CssClass="button" 
                OnClick="btn_reset_Click" Text="Reset" ValidationGroup="x" />
            &nbsp;</td>
    </tr>
    <tr>
        <td height="10">
        </td>
    </tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>    
<%--<div id="light" class="pop1" align="center">
<table width="680" border="0" cellspacing="0" cellpadding="0">
<tr>
<td class="pop-brdr"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="95%" valign="top" class="pop-tp-clr" align="left">Leave Policy </td>
<td width="5%" align="right" valign="top" class="pop-tp-clr"><a href="#" onclick="document.getElementById('light').style.display='none';"><img src="../images/btn-close.gif" width="16" height="19" border="0" /></a></td>
</tr>
<tr>
<td colspan="2" height="10"></td>
</tr>
<tr>
<td colspan="2" align="center" valign="top"><iframe src="check_leavepolicy.aspx" frameborder="0" scrolling="yes" width="670" height="300"></iframe></td>
</tr>
<tr>
<td colspan="2" height="10"></td>
</tr>
</table></td>
</tr>
</table>
</div>--%>
</form> 
</body>
</html>

