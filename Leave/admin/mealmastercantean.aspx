<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mealmastercantean.aspx.cs" Inherits="leave_admin_mealmastercantean" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
                      <td class="txt01">
                          Coupan Meal Master</td>
                      
                    </tr>
                </table></td>
           </tr>
         <tr>
            <td height="5" valign="top"></td>
          </tr>
          <tr>
           <td height="20" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
             <tr>
                 <td align="left" class="txt-red" colspan="2">
                     &nbsp;Coupan Meal Master for Employee&nbsp;</td>
             </tr>
           </table></td>
          </tr>
                      
              <tr>
                <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  
                  <tr>
                    <td width="25%" class="frm-lft-clr123">
                        Breakfast per Coupan Cost</td>
                    <td width="75%"class="frm-rght-clr123">
                        &nbsp;<asp:TextBox ID="txtbrkfst" runat="server" CssClass="input2"
                            Width="92px"></asp:TextBox>&nbsp;</td>
                  </tr>
                  
                  <tr>
                    <td height="5" colspan="2"></td>
                  </tr>
                  
                  <tr>
                    <td width="25%" class="frm-lft-clr123">
                        Main Meal per Coupan Cost</td>
                    <td width="75%" class="frm-rght-clr123">
                        <asp:TextBox ID="txtmeal" runat="server" Width="92px" CssClass="input2"></asp:TextBox>&nbsp;
                    </td>
                  </tr>
                  
                  <tr>
                    <td height="5" colspan="2"></td>
                  </tr>
                  
                    <tr>
                      <td width="25%" class="frm-lft-clr123">&nbsp;</td>
                      <td width="75%" class="frm-rght-clr123">
                          <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="button" OnClick="btnsave_Click" ValidationGroup="v" ToolTip="Click here to save coupan" />&nbsp;&nbsp;
                          
                          <span id="message" class="txt-red" runat="server"></span>
                          </td>
                    </tr>
                    
                    <tr>
                      <td align="left" colspan="2" style="width: 66%; height: 22px;"></td>
                    </tr>  
                                                                               
                </table></td>
              </tr>
                      
              <tr>
                <td height="10" valign="top"></td>
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
