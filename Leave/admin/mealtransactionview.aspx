<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mealtransactionview.aspx.cs" Inherits="leave_admin_mealtransactionview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Intranet</title>

<style type="text/css" media="all">

@import "../css/blue1.css";
</style>
<script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>
<script type="text/javascript" src="../js/jquery-1.2.2.pack.js"></script>
<script type="text/javascript" src="../js/ddaccordion.js"></script>
<script type="text/javascript" src="../js/timepicker.js"></script>
<script type="text/javascript">
ddaccordion.init({
headerclass: "expandable", //Shared CSS class name of headers group
contentclass: "submenu", //Shared CSS class name of contents group
collapseprev: true, //Collapse previous content (so only one open at any time)? true/false 
defaultexpanded: [], //index of content(s) open by default [index1, index2, etc] [] denotes no content
animatedefault: false, //Should contents open by default be animated into view?
persiststate: true, //persist state of opened contents within browser session?
toggleclass: ["", "openheader"], //Two CSS classes to be applied to the header when it's collapsed and expanded, respectively ["class1", "class2"]
togglehtml: ["suffix", "<img src='../images/plus3.gif' class='statusicon' />", "<img src='../images/minus3.gif' class='statusicon' />"], //Additional HTML added to the header when it's collapsed and expanded, respectively  ["position", "html1", "html2"] (see docs)
animatespeed: "normal" //speed of animation: "fast", "normal", or "slow"
})
</script>
<script type="text/javascript">
function deleteleave(var id)
{

}
</script>
</head>
<body>
    <form id="form1" runat="server">
<asp:ScriptManager ID="leave" runat="server">
</asp:ScriptManager>

<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax"><table width="100%"><tr><td align="center" valign="top"><img src="../images/loading.gif" /></td><td valign="bottom">Please Wait...</td></tr></table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>--%>

<table width="718" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top" height="463px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="3%"><img src="../images/employee-icon.jpg" width="16" height="16" /></td>
              <td class="txt01">
                  Coupan Details</td>
            </tr>
        </table></td>
      </tr>
      <tr>
      <td><table><tr><td>Employee Code</td>
      <td><asp:TextBox ID="txtempcode" runat="server"></asp:TextBox>&nbsp;<a href="JavaScript:newPopup1('pickemployee.aspx');" class="link05">Pick Employee</a><asp:TextBox ID="txtcardno" BorderColor="white" ForeColor="white" runat="server" CssClass="input2"></asp:TextBox></td><td><asp:Button ID="btnview" runat="server" Text="View" CssClass="button" OnClick="btnview_Click" /></td></tr></table></td>
      
      </tr>
      <tr>
        <td height="5" valign="top"></td>
      </tr>
      <tr>
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td height="20" valign="top" class="txt02"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                     <tr>
                       <td width="27%" class="txt02">
                           Breakfast Coupan</td>
                       <td width="73%" align="right" class="txt-red"><span id="message" runat="server"></span>&nbsp;</td>
                     </tr>
              </table></td>
            </tr>           
            
            <tr>
              <td class="head-2"><asp:GridView ID="brkfstgird" runat="server" Font-Size="11px" Font-Names="Arial" CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="Sorry no record found"   AllowPaging="True" PageSize="30">
                   <Columns>
                   
                       <asp:BoundField DataField="leaveid" HeaderText="leaveid"  InsertVisible="False" ReadOnly="True"
                           SortExpression="leaveid" Visible="False" />
                           
                       <asp:BoundField DataField="month" HeaderText="Month" SortExpression="month" >
                           <ItemStyle CssClass="frm-rght-clr1234" Width="25%" />
                           <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                       </asp:BoundField>
                       
                       <asp:BoundField DataField="noofbrkfstcoupan" HeaderText="Allocated Coupan"    SortExpression="noofbrkfstcoupan" >
                           <ItemStyle CssClass="frm-rght-clr1234" Width="15%" />
                           <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                       </asp:BoundField>
                       
                       <asp:BoundField DataField="status" HeaderText="Number Used"   SortExpression="status" >
                           <ItemStyle CssClass="frm-rght-clr1234" Width="45%" />
                           <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                       </asp:BoundField>
                       
                       
                                       
                      
                  </Columns> 
                      <HeaderStyle CssClass="frm-lft-clr123" />
                      <FooterStyle CssClass="frm-lft-clr123" />
                       <AlternatingRowStyle CssClass="frm-rght-clr12345" />                     
                      <RowStyle Height="5px" />
                      
                  </asp:GridView>             &nbsp;&nbsp;
                </td>
            </tr>
            <tr>
            <td>
            &nbsp;</td>
            </tr>
        </table></td>
      </tr>
      <tr>
        <td height="10" valign="top"></td>
      </tr>
      <tr>
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                     <tr>
                       <td width="27%" class="txt02">
                           Meal Coupan</td>
                       <td width="73%" align="right" class="txt-red"><span id="Span1" runat="server"></span>&nbsp;</td>
                     </tr>
              </table></td>
      </tr>
      <tr>
      <td>
      </td>
      </tr>
      <tr>
              <td class="head-2">   <asp:GridView ID="GridView1" runat="server" Font-Size="11px" Font-Names="Arial" CellPadding="4" DataKeyNames="" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="Sorry no record found" AllowPaging="True" PageSize="30">
                   <Columns>
                   
                       <asp:BoundField DataField="leaveid" HeaderText="leaveid"  InsertVisible="False" ReadOnly="True"
                           SortExpression="leaveid" Visible="False" />
                           
                       <asp:BoundField DataField="month" HeaderText="Month" SortExpression="month" >
                           <ItemStyle CssClass="frm-rght-clr1234" Width="25%" />
                           <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                       </asp:BoundField>
                       
                       <asp:BoundField DataField="noofmainmealcoupan" HeaderText="Allocated Coupan"    SortExpression="noofmainmealcoupan" >
                           <ItemStyle CssClass="frm-rght-clr1234" Width="15%" />
                           <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                       </asp:BoundField>
                       
                       <asp:BoundField DataField="status" HeaderText="Number Used"   SortExpression="status" >
                           <ItemStyle CssClass="frm-rght-clr1234" Width="45%" />
                           <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                       </asp:BoundField>
                       
                       
                                       
                      
                  </Columns> 
                      <HeaderStyle CssClass="frm-lft-clr123" />
                      <FooterStyle CssClass="frm-lft-clr123" />
                       <AlternatingRowStyle CssClass="frm-rght-clr12345" />                     
                      <RowStyle Height="5px" />
                      
                  </asp:GridView>           &nbsp;&nbsp;
                </td>
            </tr>
      
    </table></td>
  </tr>
</table>
<%--</ContentTemplate>
</asp:UpdatePanel>--%>
</form>
</body>
</html>
