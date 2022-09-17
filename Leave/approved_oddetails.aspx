<%@ Page Language="C#" AutoEventWireup="true" CodeFile="approved_oddetails.aspx.cs" Inherits="leave_approved_oddetails" %>

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
    <td valign="top" height="463px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="3%"><img src="../images/employee-icon.jpg" width="16" height="16" /></td>
              <td class="txt01">Official Duty&nbsp;</td>
            </tr>
        </table></td>
      </tr>
      <tr>
        <td height="5" valign="top"></td>
      </tr>
      <tr>
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td height="20" valign="top" class="txt02">View Approved OD</td>
            </tr>
            <tr>
              <td class="head-2">
            <asp:GridView ID="pendinggrid" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                CellPadding="4" CellSpacing="0" DataKeyNames="id" Font-Names="Arial" Font-Size="11px"
                  Width="100%" EmptyDataText="No record found">
                <Columns> 
                
                    <asp:TemplateField HeaderText="From Date" HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle CssClass="frm-lft-clr123" />
                        <ItemStyle CssClass="frm-rght-clr1234"  HorizontalAlign="Left"
                            VerticalAlign="Top" Width="17%" />
                        <ItemTemplate>
                            <asp:Label ID="l3" runat="server" Text='<%# Bind("date")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                     <asp:TemplateField HeaderText="To Date" HeaderStyle-HorizontalAlign="left">
                        <HeaderStyle CssClass="frm-lft-clr123" />
                        <ItemStyle CssClass="frm-rght-clr1234"  HorizontalAlign="Left"
                            VerticalAlign="Top" Width="17%" />
                        <ItemTemplate>
                            <asp:Label ID="l3" runat="server" Text='<%# Bind("fromtime")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    
                     <asp:TemplateField HeaderText="Days" HeaderStyle-HorizontalAlign="left">
                        <HeaderStyle CssClass="frm-lft-clr123" />
                        <ItemStyle CssClass="frm-rght-clr1234"  HorizontalAlign="Left"
                            VerticalAlign="Top" Width="17%" />
                        <ItemTemplate>
                            <asp:Label ID="l3" runat="server" Text='<%# Bind("working_hour")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                      <asp:TemplateField HeaderText="OD Status" HeaderStyle-HorizontalAlign="Left">
                        <HeaderStyle CssClass="frm-lft-clr123" />
                        <ItemStyle CssClass="frm-rght-clr1234"  HorizontalAlign="Left"
                            VerticalAlign="Top" Width="17%" />
                        <ItemTemplate>
                            <asp:Label ID="l3" runat="server" Text="Approved" ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    
                     <asp:TemplateField>
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="20%" />
                        <ItemTemplate>
                          <a class="link05" href="view_approvedod_details.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>&empcode=<%#DataBinder.Eval(Container.DataItem,"empcode")%>"
                                target="_self">View</a>
                          </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="frm-lft-clr123" />
                <FooterStyle CssClass="frm-lft-clr123" />
                <RowStyle Height="5px" />
            </asp:GridView>
           
                </td>
            </tr>
        </table></td>
      </tr>
      <tr>
        <td height="10" valign="top">&nbsp;</td>
      </tr>
     
    </table></td>
  </tr>
</table>

</form>

</body>

</html>
