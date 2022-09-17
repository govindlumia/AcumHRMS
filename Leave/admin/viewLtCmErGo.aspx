<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewLtCmErGo.aspx.cs" Inherits="View_late_Come_Early_Go" Title="View late Come Early Go" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title> Intranet</title>

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
    function getConfmBtn() {
        var con = confirm("Are you sure?");
        if (con == true) {
            return true;
        }
        else {
            return false;
        }
    }
</script>
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
    <td valign="top" height="463px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="3%"><img src="../images/employee-icon.jpg" width="16" height="16" /></td>
              <td class="txt01">Late Come & Early Go Approvals</td>
            </tr>
        </table></td>
      </tr>
      <tr>
        <td height="5" valign="top"></td>
      </tr>
      <tr>
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td height="20" valign="top" class="txt02"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                     <tr>
                       <td width="27%" class="txt02"><%--Please Take Action:
                       <br />Accept Option will make half day leave--%>
                       </td>
                       <td width="73%" align="right" class="txt-red"><span id="message" runat="server"></span>&nbsp;</td>
                     </tr>
              </table></td>
            </tr>           
            
            <tr>
              <td class="head-2">             
              
                  <asp:GridView ID="GrdLateCmEarlyGo" runat="server" Font-Size="11px" 
                      Font-Names="Arial" CellPadding="4" DataKeyNames="id" Width="100%" 
                      AutoGenerateColumns="False" BorderWidth="0px" 
                      EmptyDataText="Sorry no record found"  AllowPaging="True" PageSize="30" 
                      onrowcommand="GrdLateCmEarlyGo_RowCommand" 
                      onrowdatabound="GrdLateCmEarlyGo_RowDataBound" 
                      onpageindexchanging="GrdLateCmEarlyGo_PageIndexChanging" 
                    >
                   <Columns>
                   <asp:TemplateField HeaderText="Emp Name">
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                    Width="20%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_empname" runat="server" Text='<%# Bind("EmpName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField> 
                                             <asp:TemplateField HeaderText="Date">
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                    Width="10%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_date" runat="server" Text='<%# Bind("date")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>    
                                             <asp:TemplateField HeaderText="In Time">
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                    Width="20%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_intime" runat="server" Text='<%# Bind("intime")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>   
                                              <asp:TemplateField HeaderText="Out Time">
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                    Width="20%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_outtime" runat="server" Text='<%# Bind("outtime")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>       
                                             <asp:TemplateField HeaderText="Action">
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                    Width="10%" />
                                                <ItemTemplate>
                                  <asp:LinkButton  runat="server" ID="lnk_accept" OnClientClick="return getConfmBtn();" CommandName="accept" CommandArgument='<%# String.Format("{0},{1},{2}",Eval("ID"),Eval("empcode"),Eval("date")) %>' Text="reject" CssClass="link05"></asp:LinkButton> |
                                    <asp:LinkButton  runat="server" ID="lnk_reject" OnClientClick="return getConfmBtn();" CommandName="reject" CommandArgument='<%# String.Format("{0},{1},{2}",Eval("ID"),Eval("empcode"),Eval("date")) %>' Text="accept" CssClass="link05"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>            
                      
                  </Columns> 
                      <HeaderStyle CssClass="frm-lft-clr123" />
                      <FooterStyle CssClass="frm-lft-clr123" />
                       <AlternatingRowStyle CssClass="frm-rght-clr12345" />                     
                      <RowStyle Height="5px" />
                      
                  </asp:GridView>
                  
                 
                </td>
            </tr>
        </table></td>
      </tr>
      <tr>
        <td height="10" valign="top"></td>
      </tr>
      <tr>
        <td valign="top">&nbsp;</td>
      </tr>
    </table></td>
  </tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
</form>
</body>
</html>


