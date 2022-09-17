<%@ Page Language="C#" AutoEventWireup="true" CodeFile="empdutyroster.aspx.cs" Inherits="leave_admin_empdutyroster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">

    <title>Acuminous Software.</title>

<style type="text/css" media="all">
@import "../css/blue1.css";
@import "../css/example.css";
</style>

</head>


<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
<div>
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
            <td valign="bottom" align="center" class="txt01" height="23">Please Wait...</td>
            </tr>
            </table></div>
        </ProgressTemplate> 
    </asp:UpdateProgress>





<div style="overflow-x:hidden; overflow-y:scroll; height:524px; width:968px;">              
<table width="98%" border="0" cellpadding="0" cellspacing="0">
<tr>
<td valign="middle" class="txt01" width="5%">Select -</td>
<td valign="middle" width="10%" style="height:45px"><asp:LinkButton ID="lnkcheckAll" runat="server" CssClass="link03" OnClick="lnkcheckAll_Click"><b>All</b></asp:LinkButton> &nbsp;l&nbsp; 
  <asp:LinkButton ID="lnkcheckNone" runat="server" CssClass="link03" OnClick="lnkcheckNone_Click"><b>None</b></asp:LinkButton></td> 
<td valign="middle" align="right" width="83%" style="height: 45px"><asp:Button ID="btndelete" runat="server" CssClass="button" Text="Delete" OnClick="btndelete_Click" /> 
 <asp:Button ID="btnedit" runat="server" CommandName="Edit" Text="Edit" CssClass="button" OnClick="btnedit_Click" />
 <asp:Button ID="btnCancel" runat="server" Visible="false" Text="Cancel" CssClass="button" OnClick="btnCancel_Click" />
 <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="button" OnClick="btnBack_Click" /></td>
<%--<td align="right"><input id="Button1" type="button" value="Back" onclick="javascript:history.back()" /> </td>--%>
</tr>
<tr>
<td colspan="3" height="10"></td>
</tr>
<tr>
<td colspan="3" class="head-2"><asp:GridView ID="empdutyrosterdetails" runat="server" DataKeyNames="DATE" Font-Size="11px" Font-Names="Arial" AutoGenerateColumns="False" Width="100%" AllowPaging="True" OnPageIndexChanging="empdutyrosterdetails_PageIndexChanging" CellPadding="0" PageSize="30" AllowSorting="True" OnRowEditing="empdutyrosterdetails_RowEditing" BorderStyle="None" BorderWidth="0px">
<FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>
<RowStyle ForeColor="#000066" HorizontalAlign="Left"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Select Date">
<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/> 
<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234" Width="10%"/> 
<ItemTemplate>
<asp:CheckBox ID="Chkbox" runat="server" BorderStyle="None" Text='<%# Eval("DATE")%>' ForeColor="White" AutoPostBack="true" OnCheckedChanged="Chkbox_CheckedChanged"/>
</ItemTemplate>
</asp:TemplateField>
                                                               
<asp:BoundField DataField="DATE" HeaderText="Date">
<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/> 
<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234" Width="20%"/> 
</asp:BoundField>
<asp:BoundField DataField="EMPCODE" HeaderText="EmpCode">
<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/> 
<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234" Width="20%"/> 
</asp:BoundField>  
<asp:BoundField DataField="DAYS" HeaderText="Week Days">
<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/> 
<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234" Width="20%"/> 
</asp:BoundField>
<asp:TemplateField HeaderText="Shift">
<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/> 
<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234" Width="20%"/> 
<ItemTemplate>
<%--<asp:BoundField DataField="SHIFT" HeaderText="Shift"></asp:BoundField>--%>
<asp:Label ID="lblShift" Visible="true" runat="server" Text='<%# Bind("SHIFT") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField> 

<asp:TemplateField>
<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/> 
<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234" Width="10%"/> 
<ItemTemplate>
<asp:DropDownList Visible="false" ID="drpShift" runat="server" DataTextField="shiftname" DataValueField="shiftid" CssClass="select2"></asp:DropDownList>
</ItemTemplate>
</asp:TemplateField>
</Columns>
<PagerStyle HorizontalAlign="Center" BackColor="White" ForeColor="#000066"></PagerStyle>
<EmptyDataTemplate>
<span style="text-align:center">Sorry! No Records Found</span>
</EmptyDataTemplate>
<SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
<HeaderStyle Wrap="True" BackColor="#006699" CssClass="link05" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
<PagerSettings PageButtonCount="30" />
</asp:GridView>
                               </td>
                        </tr>
                </table>
</div>  
</ContentTemplate>  
</asp:UpdatePanel>
</div>
 
    </form>

</body>

</html>
