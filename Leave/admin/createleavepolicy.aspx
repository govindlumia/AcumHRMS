<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createleavepolicy.aspx.cs" Inherits="Leave_admin_createleavepolicy" 
Title="Leave Policy" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Leave/admin/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Acuminous Software Employee Information</title>

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

    <link href="images/mes.css" rel="stylesheet" type="text/css" />
    <link href="images/mes.css" rel="stylesheet" type="text/css" />
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
        <td valign="top" class="blue-brdr-1" style="width: 725px"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="3%" style="height: 16px"><img src="../images/employee-icon.jpg" width="16" height="16" /></td>
              <td class="txt01" style="height: 16px">Leave Policy</td>
            </tr>
        </table></td>
      </tr>
      <tr>
        <td height="5" valign="top"></td>
      </tr>
      <tr>
       <td height="20" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
         <tr>
           <td width="27%" class="txt02">Create Leave Policy</td>
           <td width="73%" align="right" class="txt-red"><span id="message" runat="server"></span>&nbsp;</td>
         </tr>
       </table></td>
      </tr>
      <tr>
        <td valign="top" style="width: 725px" >
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td width="25%" class="frm-lft-clr123">
                  Policy Name(<img src="../images/error1.gif" alt="" />)</td>
              <td width="75%" class="frm-rght-clr123">
                  <asp:TextBox ID="txt_policy" MaxLength="20" runat="server" CssClass="input"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_policy"
                      Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Select Leave" ValidationGroup="s5"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
              <td height="5" colspan="2"></td>
            </tr>
                            <tr>
              <td width="25%" class="frm-lft-clr123">
                  Policy Descrption</td>
              <td width="75%" class="frm-rght-clr123">
                  <asp:TextBox ID="txt_policy_desc" MaxLength="100" runat="server" CssClass="input" TextMode="MultiLine" Width="283px"></asp:TextBox>
                  </td>
            </tr>
            <tr>
              <td height="5" colspan="2"></td>
            </tr>
            
            
            
            <tr>
              <td width="25%" class="frm-lft-clr123">
                  Upload File(<img src="../images/error1.gif" alt="" />)</td>
              <td width="75%" class="frm-rght-clr123">
                  <asp:FileUpload ID="fupload" runat="server" CssClass="input2" ToolTip="Upload File here"
                      Width="287px" />
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fupload"
                      CssClass="txt-red" ErrorMessage='<img src="../images/error1.gif" alt="file not supported" />'
                      ValidationExpression="^.+(.doc|.DOC|.docx|.DOCX|.rtf|.RTF|.pdf|.PDF|.xls|.XLS|.ppt|.PPT)$" ValidationGroup="s5" Display="Dynamic"></asp:RegularExpressionValidator>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="fupload"
                      Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' Height="1px"
                      ToolTip="Select Upload File" ValidationGroup="s5" Width="3px"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
              <td height="5" colspan="2"></td>
            </tr>
            
    <%--         <tr>
              <td width="25%" class="frm-lft-clr123">
                  Upload Date</td>
              <td width="75%" class="frm-rght-clr123">
                  <asp:TextBox ID="txt_date" runat="server" CssClass="input"></asp:TextBox>
                  <asp:Image ID="img" runat="server" ImageUrl="~/Leave/images/clndr.gif" />
                  (mm/dd/yyyy)<cc1:calendarextender id="CalendarExtender1" runat="server"
                      targetcontrolid="txt_date" PopupButtonID="img"></cc1:calendarextender>
                  </td>
             </tr>--%>
            
            
            <tr>
              <td width="25%" class="frm-lft-clr123">&nbsp;</td>
              <td width="75%" class="frm-rght-clr123">
                  <asp:Button ID="btnsubmit" runat="server"  CssClass="button" Text="Submit" ValidationGroup="s5" OnClick="btnsubmit_Click" />
                  <asp:Button ID="btn_reset" runat="server" CssClass="button" ValidationGroup="nothing" Text="Reset" OnClick="btn_reset_Click"/>
              </td>
            </tr>
            <tr>
              <td align="left" colspan="2" style="width: 66%; height: 22px;">Mandatory Fields (<img src="../images/error1.gif" alt="" />)</td>
            </tr>          
        </table></td>
      </tr>     
      
      <tr>
        <td valign="top"  style="width: 725px">&nbsp;</td>
      </tr>
     
    </table>
</td>
</tr>
</table>
</form>
</body>
</html>


