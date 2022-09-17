<%@ Page Language="C#" AutoEventWireup="true" CodeFile="casualworkcaptureview.aspx.cs" Inherits="leave_casualworkcaptureview" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Casual Work Capture View</title>
    <style type="text/css" media="all">
@import "../css/blue1.css";
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager id="leaveapply" runat="server">
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
    <div>
        <table width="718" border="0" cellpadding="0" cellspacing="0">
        
        <tr>
        <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td class="txt01">Casual Work</td>
            </tr>
        </table></td>
      </tr>
      <tr>
        <td height="8"></td>
      </tr>
      <tr>
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td height="20" valign="top" class="txt02">&nbsp;Casual Work View</td>
            </tr>
         
            <tr>
                    <td height="3"></td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:GridView ID="casualgrid" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" BorderWidth="0px" CellPadding="4" Font-Names="Arial" Font-Size="11px" Width="100%" EmptyDataText="No Data Available !" OnPageIndexChanging="casualgrid_PageIndexChanging" OnRowCancelingEdit="casualgrid_RowCancelingEdit" OnRowDeleting="casualgrid_RowDeleting" OnRowUpdating="casualgrid_RowUpdating" OnRowEditing="casualgrid_RowEditing" AllowPaging="True">         
                        <HeaderStyle CssClass="frm-lft-clr123" />
                        <FooterStyle CssClass="frm-lft-clr123" />
                        <RowStyle Height="5px" />
                        
                        <Columns>
                            <asp:TemplateField HeaderText="Department">
                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="20%" />
                                <ItemTemplate>
                                    <asp:Label ID="l1" runat="server" Text='<%# Bind("deptname")%>' ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="No of Persons">
                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="20%" />
                                <ItemTemplate>
                                    <asp:Label ID="l2" runat="server" Text='<%# String.Format("{0:#,##,##,##0}", DataBinder.Eval(Container.DataItem,"casualno"))%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtnoofpersonsg" runat="server" Text='<%# String.Format("{0:#,##,##,##0}", DataBinder.Eval(Container.DataItem,"casualno"))%>' Width="123px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtnoofpersonsg"
                      ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="grid" SetFocusOnError="True" ToolTip="Enter number of Persons"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>   
                            
                            <asp:TemplateField HeaderText="No of Hours">
                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                <ItemStyle CssClass="frm-rght-clr123" HorizontalAlign="Left" VerticalAlign="Top" Width="20%" />
                                <ItemTemplate>
                                    <asp:Label ID="l3" runat="server" Text='<%# String.Format("{0:#,##,##,##0}", DataBinder.Eval(Container.DataItem,"noofhours"))%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtnoofhoursg" runat="server" Text='<%# String.Format("{0:#,##,##,##0}", DataBinder.Eval(Container.DataItem,"noofhours"))%>' Width="118px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtnoofhoursg"
                      ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="grid" SetFocusOnError="True" ToolTip="Enter number of hours"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Casual Date">
                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" Width="20%" />
                                <ItemStyle CssClass="frm-rght-clr123" HorizontalAlign="Left" VerticalAlign="Top" Width="20%" />
                                <ItemTemplate>
                                    <asp:Label ID="l4" runat="server" Text='<%# Bind("casualdate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                
                            
                            <asp:TemplateField>
                <EditItemTemplate>
                    <asp:LinkButton ID="Button3" runat="Server" CommandName="Update"  Text="Update"
                         CssClass="link05" ValidationGroup="grid"  /> | 
                    <asp:LinkButton ID="Button4" runat="Server" CommandName="Cancel"  Text="Cancel"
                         CssClass="link05" />
                </EditItemTemplate>
              <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                <ItemStyle Width="35%" CssClass="frm-rght-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                <ItemTemplate>
                    <asp:LinkButton ID="Button1" runat="Server" CommandName="Edit"  Text="Edit" CssClass="link05" /> | 
                    <asp:LinkButton ID="Button2" runat="Server" CommandName="Delete"  Text="Delete" CssClass="link05"  OnClientClick="return confirm(' Do you want to Delete this record?');" />
                </ItemTemplate>
            </asp:TemplateField>  
                        </Columns>
                    </asp:GridView>
                </td>
      </tr>
            
        </table>
            
        </td>
      </tr>
      
 
    </table>
    </div>
    </ContentTemplate> 
</asp:UpdatePanel>
    </form>
</body>
</html>
