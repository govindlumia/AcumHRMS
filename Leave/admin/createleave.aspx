<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="createleave.aspx.cs" Inherits="Leave_admin_createleave" Title="Create Leave" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title> Employee Information</title>

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
<%--<script type="text/javascript">
function time()
{
var t1=document.getElementById("ctl00_ContentPlaceHolder1_txtstime").toString();

}
</script>--%>
</head>
<body>
<form id="form1" runat="server">

<asp:ScriptManager ID="leave" runat="server">
</asp:ScriptManager>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax">
                <table width="100%">
                <tr>
                <td align="center" valign="top"><img src="../images/loading.gif" /></td>
                </tr>
                <tr>
                <td valign="bottom" align="center" class="txt01">Please Wait...</td>
                </tr>
                </table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>

  <table width="718" border="0" cellspacing="0" cellpadding="0">
  <tr>     
    <td valign="top">
    
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="3%"><img src="../images/employee-icon.jpg" width="16" height="16" /></td>
              <td class="txt01">Leave Master</td>
              
            </tr>
        </table></td>
      </tr>
     <tr>
        <td height="5" valign="top"></td>
      </tr>
      <tr>
       <td height="20" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
         <tr>
           <td width="27%" class="txt02">Create Leave</td>
           <td width="73%" align="right" class="txt-red"><span id="message" runat="server"></span>&nbsp;</td>
         </tr>
       </table></td>
      </tr>
       
      <tr>
        <td valign="top" style="height: 123px">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">

       
            <tr>
              <td width="25%" class="frm-lft-clr123">Leave Name(<img src="../images/error1.gif" alt="" />)</td>
              <td width="75%" class="frm-rght-clr123">              
                  <asp:TextBox ID="txt_leave_type"  CssClass="input2" MaxLength="20" runat="server" ToolTip="Leave Name"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_leave_type"
                      ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v" Display="Dynamic" ToolTip="Enter Leave Name"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
              <td height="5" colspan="2"></td>
            </tr>
            <tr>
              <td width="25%" class="frm-lft-clr123">Description</td>
              <td width="75%" class="frm-rght-clr123">
              
                  <asp:TextBox ID="txt_description" runat="server" TextMode="MultiLine" MaxLength="100" Width="224px" ToolTip="Description of Leave"></asp:TextBox>
              </td>
            </tr>
            <tr>
              <td height="5" colspan="2"></td>
            </tr>
            <tr>
              <td width="25%" class="frm-lft-clr123">Display Name(<img src="../images/error1.gif" alt="" />)</td>
              <td width="75%" class="frm-rght-clr123">
                  <asp:TextBox ID="txt_display_name" runat="server" CssClass="input2" MaxLength="20" ToolTip="Display name of leave "></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_display_name"
                      ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v" SetFocusOnError="True" ToolTip="Enter Display Name"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
              <td height="5" colspan="2"></td>
            </tr>
            <tr>
              <td width="25%" class="frm-lft-clr123">&nbsp;</td>
              <td width="75%" class="frm-rght-clr123">
                  <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click" ValidationGroup="v" ToolTip="Click to submit the created leave" />
                  <asp:Button ID="btn_reset" runat="server" CssClass="button" ValidationGroup="nothing" Text="Reset" OnClick="btn_reset_Click"/>
              </td>
            </tr>
            <tr>
              <td align="left" colspan="2" >Mandatory Fields (<img src="../images/error1.gif" alt="" />)</td>
            </tr>
         </table>
       </td>
      </tr>
    <tr>
        <td valign="top">&nbsp;</td>
      </tr>
    </table>
    </td>
  </tr>
</table>
</ContentTemplate> 
</asp:UpdatePanel>
</form>
</body>
</html>

