<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_delegated_job.aspx.cs" Inherits="Leave_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title></title>

<style type="text/css" media="all">

@import "css/blue1.css";
</style>
<script language="JavaScript" type="text/javascript" src="js/popup.js"></script>
<script type="text/javascript" src="js/jquery-1.2.2.pack.js"></script>
<script type="text/javascript" src="js/ddaccordion.js"></script>
<script type="text/javascript" src="js/timepicker.js"></script>
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
                <td align="center" valign="top"><img src="images/loading.gif" alt="" /></td>
                </tr>
                <tr>
                <td valign="bottom" align="center" class="txt01" height="23">Please Wait...</td>
                </tr>
                </table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">   
      <tr>
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
             
                      <td width="3%">
                         <img src="images/employee-icon.jpg" width="16" height="16" alt=""/>
                          </td>
                           <td class="txt01">
                            My Leave right delegation Status
                           </td>
                           <td align="right">
                           <%--<a href="leave-user.aspx" target="" class="txt-red">Back</a>--%>
                            <span id="message" runat="server"></span>
                             </td>
                    
            </tr> 
              <tr>
                        <td height="10" colspan="3">
                        </td>
                    </tr>
            <tr>
              <td class="head-2" colspan="3">             
              
                  <asp:GridView ID="GridView1"  runat="server" Font-Size="11px" Font-Names="Arial" 
                  CellPadding="3" CellSpacing="0"  DataKeyNames="id" Width="100%" 
                  AutoGenerateColumns="False" BorderWidth="1px" 
                  EmptyDataText="Sorry no record found"  AllowPaging="True" PageSize="15" 
                  OnRowCommand="GridView1_RowCommand">
                   <Columns>
                   
                            <asp:BoundField DataField="empcode" HeaderText="Emp Code" SortExpression="del_empcode" >
                            <ItemStyle CssClass="frm-rght-clr1234" Width="12%" />
                            <HeaderStyle CssClass="grid-hd" HorizontalAlign="Left" />
                            </asp:BoundField>
                            
                            <asp:BoundField DataField="ename" HeaderText="Emp Name" SortExpression="ename" >
                            <ItemStyle CssClass="frm-rght-clr1234" Width="17%" />
                            <HeaderStyle CssClass="grid-hd" HorizontalAlign="Left" />
                            </asp:BoundField>

                            <asp:BoundField DataField="del_sdate" HeaderText="Delegation Start Date" SortExpression="del_sdate" >
                            <ItemStyle CssClass="frm-rght-clr1234" Width="17%" />
                            <HeaderStyle CssClass="grid-hd" HorizontalAlign="Left" />
                            </asp:BoundField>
                            
                            <asp:BoundField DataField="del_enddate" HeaderText="Delegation End Date" SortExpression="del_enddate" >
                            <ItemStyle CssClass="frm-rght-clr1234" Width="17%" />
                            <HeaderStyle CssClass="grid-hd" HorizontalAlign="Left" />
                            </asp:BoundField>
                            
                            <asp:TemplateField HeaderText="Delegation Status">
                            <HeaderStyle CssClass="grid-hd" HorizontalAlign="Left"/>                  
                            <ItemStyle CssClass= "frm-rght-clr1234" Width="12%"/> 
                            <ItemTemplate>
                            <asp:Label ID="del_status" runat="server" Text='<%# Bind ("status") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="createddate" HeaderText="Requested Date" SortExpression="createddate" >
                            <ItemStyle CssClass="frm-rght-clr1234" Width="17%" />
                            <HeaderStyle CssClass="grid-hd" HorizontalAlign="Left" />
                            </asp:BoundField>

                            <asp:TemplateField >
                            <HeaderStyle CssClass="grid-hd" HorizontalAlign="Left"/>                  
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234" Width="18%"/> 
                            <ItemTemplate>
                            <asp:Button ID="btn_ter" runat="server" CommandArgument='<%#Eval("id") + "," + Eval("empcode")%>' CommandName="accept" CssClass="button3" Text="Accept" Enabled='<%#Bind ("astatus") %>' />l
                            <asp:Button ID="Button1" runat="server" CommandArgument='<%#Eval("id") + "," + Eval("empcode")%>' CommandName="reject" CssClass="button3" Text="Reject" Enabled='<%#Bind ("astatus") %>' />
                            </ItemTemplate>
                            </asp:TemplateField>
                      
                  </Columns> 
                  <HeaderStyle CssClass="grid-hd" />
                  <FooterStyle CssClass="frm-lft-clr123" />
                   <AlternatingRowStyle CssClass="frm-rght-clr12345" />                     
                  <RowStyle Height="5px" />
                      
                  </asp:GridView>
                  &nbsp;
                </td>
            </tr>
        </table>
            <asp:HiddenField ID="HiddenField1" runat="server" />
        </td>
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
