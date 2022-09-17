<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updateshift.aspx.cs" Inherits="Leave_admin_updateshift" Title="Acuminous Software." %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<%--<title>Acuminous Software Intranet</title>--%>
<style type="text/css" media="all">
@import "../css/blue1.css";
</style>
<script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>
<script type="text/javascript" src="../js/timepicker-admin.js"></script>
<%--<script type="text/javascript">
function time()
{
var t1=document.getElementById("ctl00_ContentPlaceHolder1_txtstime").toString();

}
</script>--%>
</head>
<body>
    <form id="form1" runat="server">

   <asp:ScriptManager id="leave" runat="server">
     
    </asp:ScriptManager>
    <table width="718" border="0" cellspacing="0" cellpadding="0"> 
    <tr>
    <td valign="top">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
    <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
    <td width="3%"><img src="../images/employee-icon.jpg" width="16" height="16" /></td>
    <td class="txt01">Shift Master</td>                  
    </tr>
    </table></td>
    </tr>
    <tr>
    <td height="7"></td>
    </tr>
    <tr>
    <td height="20" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
     <tr>
     <td width="27%" class="txt02">&nbsp;Update Shift</td>
     <td width="73%" align="right" class="txt-red"><span id="message" runat="server"></span>&nbsp;</td>
     </tr>
     </table></td>
     </tr>
     <tr>
     <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
       <tr>
       <td width="20%" class="frm-lft-clr123">Shift Name</td>
       <td width="80%" class="frm-rght-clr123"><asp:TextBox ID="txtshift" MaxLength="20" runat="server" CssClass="input2"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtshift"
                                ErrorMessage='<img src="../images/error1.gif" alt="" />' SetFocusOnError="True"
                                ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
       </tr>
       <tr>
       <td height="5" colspan="2"></td>
       </tr>
       <tr runat="server" visible="false">
       <td class="frm-lft-clr123">Branch</td>
       <td class="frm-rght-clr123">
                        <asp:DropDownList ID="ddbranch" runat="server" CssClass="select"
                            DataTextField="branch_name" DataValueField="branch_id" Width="130px" DataSourceID="SqlDataSource1" AppendDataBoundItems="True">
                            <asp:ListItem Value="0">For all Branch</asp:ListItem>
                        </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddbranch"
                            ErrorMessage='<img src="../images/error1.gif" alt="" />' InitialValue="0" SetFocusOnError="True"
                            ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
             </tr>
              <tr>
             <td height="5" colspan="2"></td>
             </tr>
             <tr>
          <td class="frm-lft-clr123">Night Allowance Applicable</td>
          <td class="frm-rght-clr123"><asp:CheckBox id="chknightallowance" runat="Server" Checked="True"></asp:CheckBox></td>
          </tr>
             <tr>
             <td height="5" colspan="2"></td>
             </tr>
             <tr>
             <td class="frm-lft-clr123">Start Time</td>
             <td class="frm-rght-clr123"><asp:TextBox ID="txtstime" runat="server" CssClass="input2"></asp:TextBox>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Leave/images/clndr.gif" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtstime"
                            ErrorMessage='<img src="../images/error1.gif" alt="" />' SetFocusOnError="True"
                            ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
             </tr>
             <tr>
             <td height="5" colspan="2"></td>
             </tr>
             <tr>
             <td class="frm-lft-clr123">End Time</td>
             <td class="frm-rght-clr123"><asp:TextBox ID="txtetime" runat="server" CssClass="input2"></asp:TextBox>
              <asp:Image ID="Image2" runat="server" ImageUrl="~/Leave/images/clndr.gif" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtetime"
                            ErrorMessage='<img src="../images/error1.gif" alt="" />' SetFocusOnError="True"
                            ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
             </tr>
             <tr>
             <td height="5" colspan="2"></td>
             </tr>
             <tr>
             <td class="frm-lft-clr123">Shift Description</td>
             <td class="frm-rght-clr123"><asp:TextBox ID="txtshiftDesc" runat="server" MaxLength="50" CssClass="input2" Width="202px"></asp:TextBox></td>
             </tr>
             <tr>
             <td height="5" colspan="2"></td>
             </tr>
             <tr>
              <td class="frm-lft-clr123">&nbsp;</td>
              <td class="frm-rght-clr123"><asp:Button ID="Button3" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click" ValidationGroup="v" ToolTip="Click to submit the updated leave" />
                  <input id="Reset1" type="reset" value="Reset" class="button" />
              <asp:Button ID="Button4" runat="server" Text="Cancel" CssClass="button" OnClick="btncncl_Click" ToolTip="Click to cancel the updation" /> </td>
              </tr>
              <tr>
             <td height="22" colspan="2" valign="bottom">&nbsp;Mandatory Fields (<img src="../images/error1.gif" alt="" />)</td>
             </tr>
             </table></td>
              </tr>
    </table>
    </td>
    </tr>
    </table>
</form>
</body>
</html>


