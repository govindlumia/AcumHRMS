<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updatepolicy.aspx.cs" Inherits="leave_admin_updatepolicy" Title="Update Policy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<%--<title>Acuminous Software Intranet</title>--%>

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

  <table width="718" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
    
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="3%"><img src="../images/employee-icon.jpg" width="16" height="16" /></td>
              <td class="txt01">Leave Policy</td>
              
            </tr>
        </table>
         <asp:HiddenField ID="prvimg" runat="server" />
        </td>
      </tr>
      
     <tr>
        <td height="5" valign="top"></td>
      </tr>
      
      <tr>
       <td height="20" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
         <tr>
           <td width="27%" class="txt02">
               Update Policy</td>
           <td width="73%" align="right" class="txt-red"><span id="message" runat="server"></span>&nbsp;</td>
         </tr>
       </table></td>
      </tr>
       
      <tr>
        <td valign="top" style="height: 123px">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
       
            <tr>
              <td width="25%" class="frm-lft-clr123">
                  Policy Name (<img src="../images/error1.gif" alt="" />)</td>
              <td width="75%" class="frm-rght-clr123">
                  &nbsp;<asp:TextBox ID="txt_policy" runat="server" MaxLength="20" CssClass="input"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_policy"
                      Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                      SetFocusOnError="True" ToolTip="Select Leave" ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>&nbsp;
              </td>
            </tr>
            
            <tr>
              <td height="5" colspan="2"></td>
            </tr>
             <tr>
              <td width="25%" class="frm-lft-clr123">
                  Policy Description</td>
              <td width="75%" class="frm-rght-clr123">
                  &nbsp;<asp:TextBox ID="txt_policy_desc" runat="server" MaxLength="100" CssClass="input" TextMode="MultiLine" Width="280px"></asp:TextBox>
                  &nbsp;
              </td>
            </tr>
             <tr>
              <td height="5" colspan="2"></td>
            </tr>
            <tr>
              <td width="25%" class="frm-lft-clr123">Upload File</td>
              <td width="75%" class="frm-rght-clr123">              
                    <asp:Label ID="lbl_file" runat="server"></asp:Label><br />
                    <asp:FileUpload ID="fupload" runat="server" CssClass="input2" Width="287px" ToolTip="Upload File here" />&nbsp;
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fupload" CssClass="txt-red" ErrorMessage="file not supported..." ValidationExpression="^.+(.doc|.DOC|.docx|.DOCX|.rtf|.RTF|.pdf|.PDF|.xls|.XLS|.ppt|.PPT)$"></asp:RegularExpressionValidator><br />
                    (Replace Existing File)
              </td>
            </tr>
            
            <tr>
              <td height="5" colspan="2"></td>
            </tr>
         
            <tr>
              <td width="25%" class="frm-lft-clr123">&nbsp;</td>
              <td width="75%" class="frm-rght-clr123">
                  <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click" ValidationGroup="v" ToolTip="Click to submit the updated leave policy" />
                  <input id="Reset1" class="button" type="reset" value="Reset" />
                  <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="button" OnClick="btncancel_Click" ToolTip="Click to cancel the updation" />
              </td>
            </tr>
            
            <tr>
              <td align="left" colspan="2" style="width: 66%; height: 22px;">Mandatory Fields (<img src="../images/error1.gif" alt="" />)</td>
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
    
</form>

</body>

</html>