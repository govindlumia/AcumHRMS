<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewcompoffstatus.aspx.cs" Inherits="leave_leave_status" %>

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
              <td width="3%" style="height: 16px"><img src="../images/employee-icon.jpg" width="16" height="16" /></td>
              <td class="txt01" style="height: 16px">
                  Comp-Off Status</td>
            </tr>
        </table></td>
      </tr>
      <tr>
        <td height="5" valign="top"></td>
      </tr>
      <tr>
        <td valign="top" style="height: 223px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td height="20" valign="top" class="txt02">
                  <table width="100%" border="0" cellspacing="0" cellpadding="0">
             <tr>
               <td width="27%" class="txt02" style="height: 13px">
                   View Comp-Off Status</td>
               <td width="73%" align="right" class="txt-red" style="height: 13px"><span id="message" runat="server"></span>&nbsp;</td>
             </tr>
           </table></td>
            </tr>
            <tr>
                <td height="10" valign="top" class="head-2">
                    
                       
                  <asp:GridView ID="leave_approval_grid" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                CellPadding="4" CellSpacing="0" DataKeyNames="id" Font-Names="Arial" Font-Size="11px"
                Width="100%" AllowPaging="false"  EmptyDataText="No record found" DataSourceID="SqlDataSource2">
                <Columns>
                     <asp:TemplateField HeaderText="Leave Type">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                        <ItemTemplate>
                            <%#linkleave(DataBinder.Eval(Container.DataItem, "empcode").ToString(), DataBinder.Eval(Container.DataItem, "leavename").ToString(), Convert.ToInt32(DataBinder.Eval(Container.DataItem, "id")), Convert.ToInt32(DataBinder.Eval(Container.DataItem, "approval_status")))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="From Date">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234"  HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                        <ItemTemplate>
                      <asp:Label ID="l5" runat="server" Text='<%# Bind("fromdate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                    
                       <asp:TemplateField HeaderText="To Date">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234"  HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                        <ItemTemplate>
                        <asp:Label ID="l6" runat="server" Text='<%# Bind("todate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                     
                    
                       <asp:TemplateField HeaderText="No of Days">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234"  HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                        <ItemTemplate>
                        <asp:Label ID="l7" runat="server" Text='<%# Bind("nod") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                         
                </Columns>
                <HeaderStyle CssClass="frm-lft-clr123" />
                <FooterStyle CssClass="frm-lft-clr123" />
                <RowStyle Height="5px" />
            </asp:GridView>
                    
               </td>
      </tr>
            
        </table>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                DeleteCommand="DELETE FROM [tbl_leave_createleave] WHERE [leaveid] = @leaveid"
                InsertCommand="INSERT INTO [tbl_leave_createleave] ([leavetype]) VALUES (@leavetype)"
                ProviderName="System.Data.SqlClient" SelectCommand="sp_leave_fetchcompoff_summary_user"
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
                    <asp:SessionParameter DefaultValue="0" Name="empcode" SessionField="empcode" Type="String" />
                    <asp:QueryStringParameter DefaultValue="10" Name="compoffstatus" QueryStringField="compoffstatus"
                        Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            &nbsp;&nbsp;
        </td>
      </tr>
      
 
    </table>
    </div>
    </form>
</body>
</html>
