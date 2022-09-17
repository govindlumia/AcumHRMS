<%@ Page Language="C#" AutoEventWireup="true" CodeFile="holidaylist.aspx.cs" Inherits="Leave_holidaylist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Holiday List</title>
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
              <td class="txt01">My Holiday List</td>
            </tr>
        </table></td>
      </tr>
      <tr>
        <td height="7" valign="top"></td>
      </tr>
      <tr>
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td height="20" valign="top" class="txt02">&nbsp;List of Holidays</td>
            </tr>
            <tr>
              <td><table style="display:none;" width="100%" border="0" cellspacing="0" cellpadding="0">
                
               <%-- <tr>
                      <td class="frm-lft-clr123" style="width: 15%">Branch</td>
                      <td width="60%" class="frm-rght-clr123">
                          <asp:LinkButton ID="lbBranch" runat="server" OnClick="lbBranch_Click" Text="EmpBranch" ToolTip="Click here to view Holiday List of Employee's Branch" CssClass="link05"></asp:LinkButton> | <asp:LinkButton ID="lbAllBranch" runat="server" OnClick="lbAllBranch_Click" CssClass="link05" ToolTip="Click here to view Holiday List of All Branch">For All Branch</asp:LinkButton>&nbsp;
                      </td>                    
                </tr>--%>
               
              </table></td>    
            </tr>
            <tr>
                <td height="7"></td>
            </tr>
            <tr>
                <td height="10" valign="top" class="head-2">
                    <asp:GridView ID="holidaygrid" runat="server" AllowSorting="True"
                     AutoGenerateColumns="False" BorderWidth="1px" CellPadding="4" CellSpacing="0"
                      DataKeyNames="holidayid" Font-Names="Arial" Font-Size="11px" Width="100%"
                       AllowPaging="True" PageSize="100" OnPageIndexChanging="holidaygrid_PageIndexChanging" EmptyDataText="No Data Available !" BorderColor="#c9dffb">         
                        <Columns>
                        
                            <asp:TemplateField HeaderText="Holiday Name">
                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                                <ItemTemplate>
                                    <asp:Label ID="l1" runat="server" Text='<%# Bind("name")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                   
                            
                             <asp:TemplateField HeaderText="Date">
                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                                <ItemTemplate>
                                   <%-- <asp:Label ID="l3" runat="server" Text='<%# Bind("Date")%>' ></asp:Label>--%>
                                      <asp:Label ID="Label1" runat="server" Text='<%# Eval("Date", "{0:dd MMM yyyy}")%>' ></asp:Label>
                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                         <asp:TemplateField HeaderText="Day">
                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                                <ItemTemplate>
                                    <asp:Label ID="l3" runat="server" Text='<%# GetDay(Eval("Date").ToString())%>' ></asp:Label>
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
      
 
    </table>
    </div>
    </form>
</body>
</html>
