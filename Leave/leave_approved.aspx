<%@ Page Language="C#" AutoEventWireup="true" CodeFile="leave_approved.aspx.cs" Inherits="leave_leave_approval" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Leave Approval</title>
    <style type="text/css" media="all">
@import "../css/blue1.css";
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
        
        <tr>
        <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="3%"><img src="../images/employee-icon.jpg" width="16" height="16" /></td>
              <td class="txt01">
                  Leave
              </td>
            </tr>
        </table></td>
      </tr>
      <tr>
        <td height="5" valign="top"></td>
      </tr>
      <tr>
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td height="22" valign="top" class="txt02">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
             <tr>
               <td width="27%" class="txt02">Leave Approval</td>
               <td width="73%" align="right" class="txt-red"><span id="message" runat="server"></span>&nbsp;</td>
             </tr>
           </table>
              
              </td>
            </tr>
<tr>
                <td valign="top" class="head-2" style="height: 10px">
                <asp:GridView ID="leave_approval_grid" runat="server" AllowSorting="True" AutoGenerateColumns="False" BorderWidth="0px" CellPadding="4" Font-Names="Arial" Font-Size="11px" Width="100%" EmptyDataText="No Data Available !" DataSourceID="SqlDataSource1" DataKeyNames="id" >         
                        <HeaderStyle CssClass="frm-lft-clr123" />
                        <FooterStyle CssClass="frm-lft-clr123" />
                        <RowStyle Height="5px" />
                        
                        <Columns>
                            <asp:TemplateField HeaderText="Employee Code">
                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:Label ID="l1" runat="server" Text='<%# Bind("empcode")%>' ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Employee Name">
                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:Label ID="l2" runat="server" Text='<%# Bind("empname")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>   
                            
                        <asp:TemplateField HeaderText="Leave Type">
                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                <ItemStyle CssClass="frm-rght-clr1234" Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <%#linkleave(DataBinder.Eval(Container.DataItem, "empcode").ToString(),DataBinder.Eval(Container.DataItem, "leavename").ToString(), Convert.ToInt32(DataBinder.Eval(Container.DataItem, "id")))%>
                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                            
           <%--             <asp:TemplateField HeaderText="Leave Status">
                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:Label ID="l4" runat="server" Text='<%# Bind("leavestatus") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> --%>
                            
                            <asp:TemplateField HeaderText="From Date">
                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:Label ID="l5" runat="server" Text='<%# Bind("fromdate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>     
                            
                            <asp:TemplateField HeaderText="To Date">
                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:Label ID="l6" runat="server" Text='<%# Bind("todate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>     
                            
                            <asp:TemplateField HeaderText="No of Days">
                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:Label ID="l7" runat="server" Text='<%# Bind("nod") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                    
                            
                            
                        </Columns>
                    </asp:GridView>
                </td>
      </tr>
            
        </table>
            <asp:SqlDataSource ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>" runat="server" SelectCommand="[sp_leave_fetchleavesummary_hr]" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                    <asp:SessionParameter Name="empcode" SessionField="empcode" Type="String" />
                    <asp:QueryStringParameter Name="hr" QueryStringField="hr" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            &nbsp;&nbsp;&nbsp;&nbsp;
        </td>
      </tr>
      
 
    </table>
    </div>
    </form>
</body>
</html>

