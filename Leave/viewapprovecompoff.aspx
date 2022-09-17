<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewapprovecompoff.aspx.cs" Inherits="leave_viewapprovecompoff" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Leave Approval</title>
    <style type="text/css" media="all">
@import "../css/blue1.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="718" border="0" cellpadding="0" cellspacing="0">
        
        <tr>
        <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="3%"><img src="../images/employee-icon.jpg" width="16" height="16" /></td>
              <td class="txt01">
                  Comp-off for Approval or Rejection</td>
            </tr>
        </table></td>
      </tr>
      <tr>
        <td height="5" valign="top"></td>
      </tr>
      <tr>
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td height="20" valign="top" class="txt02">
                  <table width="100%" border="0" cellspacing="0" cellpadding="0">
             <tr>
               <td width="27%" class="txt02" style="height: 13px">
                   <asp:Label ID="Label1" runat="server" Text="Comp-off"></asp:Label></td>
               <td width="73%" align="right" class="txt-red" style="height: 13px"><span id="message" runat="server"></span>&nbsp;</td>
             </tr>
           </table></td>
            </tr>
         
            <tr>
                    <td height="5" valign="top"></td>
            </tr>
            <tr>
                <td height="10" valign="top" class="head-2">
                <asp:GridView ID="leave_approval_grid" runat="server" AllowSorting="True" AutoGenerateColumns="False" BorderWidth="0px" CellPadding="4" Width="100%" EmptyDataText="No Data Available !" DataKeyNames="id" PageSize="100" OnRowCommand="leave_approval_grid_RowCommand" >         
                        <HeaderStyle CssClass="frm-lft-clr123" />
                        <FooterStyle CssClass="frm-lft-clr123" />
                        <RowStyle Height="5px" />
                        
                        <Columns>                          
                            
                        <asp:TemplateField HeaderText="EmpCode">
                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                <ItemStyle CssClass="frm-rght-clr1234" Width="10%" HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <%#DataBinder.Eval(Container.DataItem, "empcode")%>                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                        <asp:TemplateField HeaderText="EmpName">
                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemStyle CssClass="frm-rght-clr1234" Width="20%" HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:Label ID="l4" runat="server" Text='<%# Bind("empname") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
                            <asp:TemplateField HeaderText="Date">
                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemStyle CssClass="frm-rght-clr1234" Width="10%" HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:Label ID="l5" runat="server" Text='<%# Bind("date") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>     
                            
                            <asp:TemplateField HeaderText="Day">
                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemStyle CssClass="frm-rght-clr1234" Width="6%" HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:Label ID="l6" runat="server" Text='<%# Bind("day") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>     
                            
                            <asp:TemplateField HeaderText="Reason">
                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemStyle CssClass="frm-rght-clr1234" Width="40%" HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:Label ID="l7" runat="server" Text='<%# Bind("reason") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                    
                            
                            
                            <asp:TemplateField HeaderText="">
                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemStyle CssClass="frm-rght-clr1234" Width="14%" HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="btn_ter" runat="server" CommandArgument='<%#Eval("id") + "," + Eval("empcode")%>' CommandName="accept" CssClass="link05" Text="Accept" />l
                            <asp:LinkButton ID="Button1" runat="server" CommandArgument='<%#Eval("id") + "," + Eval("empcode")%>' CommandName="reject" CssClass="link05" Text="Reject" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
                        </Columns>
                    </asp:GridView>
               </td>
      </tr>
            
        </table>
            <%--<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                DeleteCommand="DELETE FROM [tbl_leave_createleave] WHERE [leaveid] = @leaveid"
                InsertCommand="INSERT INTO [tbl_leave_createleave] ([leavetype]) VALUES (@leavetype)"
                ProviderName="System.Data.SqlClient" SelectCommand="sp_leave_fetchleavesummary_user"
                SelectCommandType="StoredProcedure" UpdateCommand="UPDATE [tbl_leave_createleave] SET [leavetype] = @leavetype WHERE [leaveid] = @leaveid">
                <DeleteParameters>
                    <asp:Parameter Name="leaveid" Type="Int32" />
                </DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="leavetype" Type="String" />
                    <asp:Parameter Name="leaveid" Type="Int32" />
                </UpdateParameters>
                <InsertParameters>
                    <asp:Parameter Name="leavetype" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                    <asp:SessionParameter DefaultValue="" Name="empcode" SessionField="empcode" Type="String" />
                    <asp:QueryStringParameter DefaultValue="0" Name="leavestatus" QueryStringField="leavestatus"
                        Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>--%>
            &nbsp;&nbsp;
        </td>
      </tr>
      
 
    </table>
    </div>
    </form>
</body>
</html>
