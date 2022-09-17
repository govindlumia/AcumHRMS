<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updateholiday.aspx.cs" Inherits="Leave_admin_updateholiday" Title="Acuminous Software." %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Employee Information</title>

<style type="text/css" media="all">
@import "../css/blue1.css";
</style>
<script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>
<script type="text/javascript" src="../js/timepicker.js"></script>
<%--<script type="text/javascript">
function time()
{
var t1=document.getElementById("ctl00_ContentPlaceHolder1_txtstime").toString();

}
</script>--%>
</head>
<body>
    <form id="form1" runat="server">
   
   <asp:ScriptManager id="leave" runat="server">
     
    </asp:ScriptManager>
    <table width="718" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                
                     <tr>
                        <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                              <td width="3%"><img src="../images/employee-icon.jpg" width="16" height="16" /></td>
                              <td class="txt01">Holiday Master</td>
                            </tr>
                        </table></td>
                    </tr>
                    <tr>
                    <td height="7"></td>
                    </tr>
                    <tr>
                       <td height="20" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                         <tr>
                           <td width="27%" class="txt02">&nbsp;Update Holiday</td>
                           <td width="73%" align="right" class="txt-red"><span id="message" runat="server"></span>&nbsp;</td>
                         </tr>
                       </table></td>
                   </tr>
                    <tr>
                        <td valign="top" style="height: 123px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td width="19%" class="frm-lft-clr123">Year</td>
                            <td class="frm-rght-clr123">
                                    <asp:DropDownList ID="ddlyear" runat="server" Width="103px" ToolTip="Select Year" CssClass="select">
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="cmpvyear" runat="server" ControlToValidate="ddlyear" ErrorMessage='<img src="../images/error1.gif" alt="" />' Operator="NotEqual" ValueToCompare="Select" ToolTip="Select Year of holiday" ValidationGroup="v"><img src="../images/error1.gif" alt="" />
                                    </asp:CompareValidator>
                            </td>
                          </tr>
                          
                          <tr>
                            <td height="5" colspan="2"></td>
                          </tr>
                          
                         <%-- <tr>
                            <td width="19%" class="frm-lft-clr123">Branch</td>
                            <td class="frm-rght-clr123">
                                    <asp:DropDownList ID="ddlbranch" runat="server"  Width="182px" ToolTip="Select Branch" DataSourceID="SqlDataSource1" DataTextField="branch_name" DataValueField="branch_id" CssClass="select" AppendDataBoundItems="True">
                                        <asp:ListItem Value="0">For all Branch</asp:ListItem>
                                    </asp:DropDownList>
                            </td>
                          </tr>
                          
                          <tr>
                            <td height="5" colspan="2"></td>
                          </tr>--%>
                          <tr>
                                    <td width="19%" class="frm-lft-clr123">Name</td>
                                    <td class="frm-rght-clr123">
                                        <asp:TextBox ID="txtholiday" MaxLength="20" runat="server" Width="175px" CssClass="input2"></asp:TextBox>                                
                                        <asp:RequiredFieldValidator id="rfvhname" runat="server" ErrorMessage='<img src="../images/error1.gif" alt="" />' ControlToValidate="txtholiday" ValidationGroup="v" ToolTip="Enter Holiday Name" Display="Dynamic" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                    </td>
                          </tr>
                                                  
                          <tr>
                            <td height="5" colspan="2"></td>
                          </tr>
                                                   
                          <tr>
                            <td width="19%" class="frm-lft-clr123">Detail</td>
                            <td class="frm-rght-clr123">
                                <asp:TextBox ID="txtdetail" runat="server" Width="175px" CssClass="input2" TextMode="MultiLine" ToolTip="Add detail of the holiday" MaxLength="100"></asp:TextBox>                                                                
                            </td>
                          </tr>
                         <tr>
                            <td height="5" colspan="2"></td>
                          </tr>
                          <tr>
                            <td width="19%" class="frm-lft-clr123"> Date</td>
                            <td class="frm-rght-clr123">
                                <asp:TextBox ID="txtdate" runat="server" CssClass="input2"></asp:TextBox>
                                <asp:Image ID="imagedate" runat="server" ImageUrl="~/Leave/images/clndr.gif" />
                                <asp:RequiredFieldValidator ID="rfvdate" runat="server" ControlToValidate="txtdate"
                                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' SetFocusOnError="True"
                                    ToolTip="Enter Holiday Name" ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>&nbsp;
                                <cc1:calendarextender id="CalendarExtender1" runat="server" popupbuttonid="imagedate"
                                    targetcontrolid="txtdate" Format="dd-MMM-yyyy"></cc1:calendarextender>                        
                            </td>                            
                          </tr>
                          
                           <tr>
                              <td height="5" colspan="2"></td>
                           </tr>
                           <tr>
                              <td width="25%" class="frm-lft-clr123">&nbsp;</td>
                              <td width="75%" class="frm-rght-clr123">
                                  <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsubmit_Click" ValidationGroup="v" ToolTip="Click to submit the updated holiday" />
                                  <input id="Reset1" class="button" type="reset" value="Reset" />
                                  <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="button" OnClick="btncancel_Click" ToolTip="Click to cancel the updation" />
                              </td>
                           </tr>
                           
                           <%--<tr>
                              <td align="left" colspan="2" style="width: 66%; height: 22px;">Mandatory Fields (<img src="../images/error1.gif" alt="" />)
                                  <asp:SqlDataSource ID="SqlDataSource1" runat="server"  ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"   SelectCommand="SELECT [branch_id], [branch_name] FROM [tbl_intranet_branch_detail]">
                                  </asp:SqlDataSource>
                              </td>
                           </tr>--%>
                                          
                          <tr>
                                 <td colspan="2" style="height: 5px">&nbsp;</td>
                          </tr>
                            
                          </table></td>
                      </tr>                         
                                      
                </table>
                
            </td>
        </tr>
    </table>
</form>
</body>
</html>


