<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editshift.aspx.cs" Inherits="Leave_admin_editshift" Title="Acuminous Software." %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<%--<title>Acuminous Software Intranet</title>--%>
<style type="text/css" media="all">
@import "../css/blue1.css";
</style>
<script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>
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
    <td valign="top" height="463px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="3%"><img src="../images/employee-icon.jpg" width="16" height="16" /></td>
              <td class="txt01">View/Edit Shift</td>
            </tr>
        </table></td>
      </tr>
      <tr>
        <td height="7"></td>
      </tr>
      <tr>
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
             <tr>
              <td valign="bottom" class="txt02"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                     <tr>
                       <td width="27%" class="txt02">&nbsp;View Shift</td>
                       <td width="73%" align="right" class="txt-red"><span id="message" runat="server"></span>&nbsp;</td>
                     </tr>
                    
              </table></td> 
            </tr> 
            <tr>
            <td height="5"></td>
            </tr>
         <%--   <tr>
              <td><table width="100%" border="0" cellspacing="0" cellpadding="0">                
              <tr runat="server" visible="false">
              <td class="frm-lft-clr123" width="20%">Select Branch</td>
              <td width="80%" class="frm-rght-clr123">
                  <asp:DropDownList ID="ddselbranch" runat="server" CssClass="select" DataSourceID="SqlDataSource1"
                      DataTextField="branch_name" DataValueField="branch_id" OnDataBound="ddselbranch_DataBound"
                      OnSelectedIndexChanged="ddselbranch_SelectedIndexChanged" Width="120px" AutoPostBack="True">
                  </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server"   ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>" 
                      DeleteCommand="DELETE FROM [tbl_intranet_branch_detail] WHERE [branch_id] = @branch_id"
                      InsertCommand="INSERT INTO [tbl_intranet_branch_detail] ([branch_id], [branch_name]) VALUES (@branch_id, @branch_name)"
                      ProviderName="System.Data.SqlClient" SelectCommand="SELECT [branch_id], [branch_name] FROM [tbl_intranet_branch_detail]"
                      UpdateCommand="UPDATE [tbl_intranet_branch_detail] SET [branch_name] = @branch_name WHERE [branch_id] = @branch_id">
                      <DeleteParameters>
                          <asp:Parameter Name="branch_id" Type="Int32" />
                      </DeleteParameters>
                      <UpdateParameters>
                          <asp:Parameter Name="branch_name" Type="String" />
                          <asp:Parameter Name="branch_id" Type="Int32" />
                      </UpdateParameters>
                      <InsertParameters>
                          <asp:Parameter Name="branch_id" Type="Int32" />
                          <asp:Parameter Name="branch_name" Type="String" />
                      </InsertParameters>
                  </asp:SqlDataSource>        
               </td>
              </tr>
              <tr>
              <td colspan="2" height="5"></td>
              </tr>               
              </table></td>              
            </tr>--%>
        </table></td>
      </tr>
      <tr>
        <td valign="top" class="head-2">
            <asp:GridView ID="shiftgrid" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                CellPadding="4" CellSpacing="0" DataKeyNames="shiftid" Font-Names="Arial" Font-Size="11px"
                Width="100%" AllowPaging="True" PageSize="30" OnRowEditing="shiftgrid_RowEditing" OnPageIndexChanging="shiftgrid_PageIndexChanging" OnRowDeleting="shiftgrid_RowDeleting" EmptyDataText="Sorry no record found">
                <Columns>
                
                    <asp:TemplateField HeaderText="Shift Name">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="13%" />
                        <ItemTemplate>
                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("shiftname") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Start Time">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="12%" />
                        <ItemTemplate>
                            <asp:Label ID="l4" runat="server"  Text='<%# Bind("starttime")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="End Time">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="12%" />
                        <ItemTemplate>
                            <asp:Label ID="l5" runat="server"  Text='<%# Bind("endtime")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                     <asp:TemplateField HeaderText="Description">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234"  HorizontalAlign="Left" VerticalAlign="Top" Width="50%" />
                        <ItemTemplate>
                            <asp:Label ID="l3" runat="server" Text='<%# Bind("shift_description")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField>
                        <HeaderStyle CssClass="frm-lft-clr123" />
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="13%" />
                        <ItemTemplate>
                            <a class="link05" href="updateshift.aspx?shiftid=<%#DataBinder.Eval(Container.DataItem, "shiftid")%>"
                                target="_self">Edit</a> |
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" CssClass="link05"
                                OnClientClick="return confirm(' Do you want to Delete this record?');">Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
                <HeaderStyle CssClass="frm-lft-clr123" />
                <FooterStyle CssClass="frm-lft-clr123" />
                <RowStyle Height="5px" />
            </asp:GridView>
        </td>
      </tr>
      <tr>
        <td align="right" valign="top"></td>
      </tr>
      <tr>
        <td valign="top"></td>
      </tr>
    </table></td>
  </tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>  
</form>
</body>
</html>

