<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_shift.aspx.cs" Inherits="Leave_view_shift" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>KOD Intranet</title>
<style type="text/css" media="all">
@import "css/blue1.css";
</style>

    <script type="text/javascript" src="../js/timepicker.js"></script>
   
    <%--<script type="text/javascript">
    function time()
    {
    var t1=document.getElementById("ctl00_ContentPlaceHolder1_txtstime").toString();

    }
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="718" border="0" cellpadding="0" cellspacing="0">
        
        <tr>
        <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="3%"><img src="../images/employee-icon.jpg" width="16" height="16" /></td>
              <td class="txt01">My Activities</td>
            </tr>
        </table></td>
      </tr>
      <tr>
        <td height="7" valign="top"></td>
      </tr>
      <tr>
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td height="20" valign="top" class="txt02">View Shift</td>
            </tr>
            <tr>
              <td><table style="display:none" width="100%" border="0" cellspacing="0" cellpadding="0">
               <tr>
              <td class="frm-lft-clr123">Branch</td>
              <td width="88%" class="frm-rght-clr123">
                  <asp:DropDownList ID="ddselbranch" runat="server" DataSourceID="SqlDataSource1"
                      DataTextField="branch_name" DataValueField="branch_id" OnDataBound="ddselbranch_DataBound"
                      OnSelectedIndexChanged="ddselbranch_SelectedIndexChanged" CssClass="select" AutoPostBack="True" ToolTip="Select branch to view shift" Width="120px">
                  </asp:DropDownList>
                  </td>
              </tr>
               </table>
                  
                  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                      DeleteCommand="DELETE FROM [tbl_intranet_branch_detail] WHERE [branch_id] = @branch_id"
                      InsertCommand="INSERT INTO [tbl_intranet_branch_detail] ([Branch_Id], [branch_name]) VALUES (@branch_id, @branch_name)"
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
        </table></td>
      </tr>
      <tr>
        <td height="5"></td>
      </tr>
      <tr>
        <td height="10" valign="top" class="head-2">
            <asp:GridView ID="shiftgrid" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                CellPadding="4" CellSpacing="0" DataKeyNames="shiftid" Font-Names="Arial" Font-Size="11px"
                Width="100%" AllowPaging="True" PageSize="5" OnPageIndexChanging="shiftgrid_PageIndexChanging" EmptyDataText="Sorry no record found">
                <Columns>
                
                    <asp:TemplateField HeaderText="Shift Name">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                        <ItemTemplate>
                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("shiftname") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <%--<asp:TemplateField HeaderText="Branch">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234"  HorizontalAlign="Left" VerticalAlign="Top" Width="20%" />
                        <ItemTemplate>
                            <asp:Label ID="l2" runat="server" Text='<%# Bind("branch_id")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    
                    <asp:TemplateField HeaderText="Shift Start Time">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                        <ItemTemplate>
                            <asp:Label ID="l3" runat="server"  Text='<%# Bind("starttime")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Shift End Time">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                        <ItemTemplate>
                            <asp:Label ID="l4" runat="server"  Text='<%# Bind("endtime")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Description">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="left"/>
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                        <ItemTemplate>
                            <asp:Label ID="l5" runat="server"  Text='<%# Bind("shift_description")%>'></asp:Label>
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
        <td valign="top">&nbsp;</td>
      </tr>
    
    </table>
    </div>
    </form>
</body>
</html>
