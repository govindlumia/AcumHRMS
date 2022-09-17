<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editleave.aspx.cs" Inherits="Leave_admin_editleave" Title="Leave Edit" %>

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
//function deleteleave(var id)
//{

//}
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
              <td class="txt01">Leave Types</td>
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
                       <td width="27%" class="txt02">View Leave</td>
                       <td width="73%" align="right" class="txt-red"><span id="message" runat="server"></span>&nbsp;</td>
                     </tr>
              </table></td>
            </tr>           
            
            <tr>
              <td class="head-2">             
              
                  <asp:GridView ID="leavegird" runat="server" Font-Size="11px" Font-Names="Arial" CellPadding="4" DataKeyNames="leaveid" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="Sorry no record found" OnPageIndexChanging="leavegird_PageIndexChanging" DataSourceID="SqlDataSource1" AllowPaging="True" PageSize="30">
                   <Columns>
                   
                       <asp:BoundField DataField="leaveid" HeaderText="leaveid"  InsertVisible="False" ReadOnly="True"
                           SortExpression="leaveid" Visible="False" />
                           
                       <asp:BoundField DataField="leavetype" HeaderText="Leave Name" SortExpression="leavetype" >
                           <ItemStyle CssClass="frm-rght-clr1234" Width="25%" />
                           <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                       </asp:BoundField>
                       
                       <asp:BoundField DataField="displayleave" HeaderText="Display Leave"    SortExpression="displayleave" >
                           <ItemStyle CssClass="frm-rght-clr1234" Width="15%" />
                           <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                       </asp:BoundField>
                       
                       <asp:BoundField DataField="description" HeaderText="Description"   SortExpression="Description" >
                           <ItemStyle CssClass="frm-rght-clr1234" Width="45%" />
                           <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                       </asp:BoundField>
                       
                       
                    <asp:TemplateField >
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="15%" />
                        <ItemTemplate>
                            <a class="link05" href="updateleave.aspx?leaveid=<%#DataBinder.Eval(Container.DataItem, "leaveid")%>" target="_self">Edit</a> |
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" CssClass="link05" OnClientClick="return confirm(' Do you want to Delete this record?');">Delete</asp:LinkButton>                           
                        </ItemTemplate>
                    </asp:TemplateField>                    
                      
                  </Columns> 
                      <HeaderStyle CssClass="frm-lft-clr123" />
                      <FooterStyle CssClass="frm-lft-clr123" />
                       <AlternatingRowStyle CssClass="frm-rght-clr12345" />                     
                      <RowStyle Height="5px" />
                      
                  </asp:GridView>
                  
                  <asp:SqlDataSource ID="SqlDataSource1" runat="server"  ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>" 
                      DeleteCommand="UPDATE tbl_leave_createleave SET status = 0 WHERE (leaveid = @leaveid)"
                      InsertCommand="INSERT INTO [tbl_leave_createleave] ([leavetype], [displayleave], [description]) VALUES (@leavetype, @displayleave, @description)"
                     SelectCommand="SELECT leaveid, leavetype, displayleave, description FROM tbl_leave_createleave WHERE (status = 1)AND (leaveid!=0)"
                      UpdateCommand="UPDATE [tbl_leave_createleave] SET [leavetype] = @leavetype, [displayleave] = @displayleave, [description] = @description WHERE [leaveid] = @leaveid">
                      <DeleteParameters>
                          <asp:Parameter Name="leaveid" Type="Int32" />
                      </DeleteParameters>
                      <UpdateParameters>
                          <asp:Parameter Name="leavetype" Type="String" />
                          <asp:Parameter Name="displayleave" Type="String" />
                          <asp:Parameter Name="description" Type="String" />
                          <asp:Parameter Name="leaveid" Type="Int32" />
                      </UpdateParameters>
                      <InsertParameters>
                          <asp:Parameter Name="leavetype" Type="String" />
                          <asp:Parameter Name="displayleave" Type="String" />
                          <asp:Parameter Name="description" Type="String" />
                      </InsertParameters>
                  </asp:SqlDataSource>
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


