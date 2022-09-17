<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddComments.aspx.cs" Inherits="TimeSheet_User_AddComments" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Css/blue1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table width="100%"  border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td class="txt01" colspan="2">Comments </td>
      </tr>
      <tr>
      <td height="10" colspan="2">&nbsp;</td>
      </tr>
      <tr>
      <td width="36%" class="frm-lft-clr123">
      <asp:Label ID="Lbl_Project" runat="server" Text="Project Name"></asp:Label>
      </td>
      <td width="64%" class="frm-rght-clr1234">
      <asp:Label ID="Lbl_ProjectName" runat="server"></asp:Label>
      </td>
      </tr>
      <tr>
      <td colspan="2" height="10">&nbsp;</td>
      </tr>
      <tr>
      <td width="36%" class="frm-lft-clr123">
      <asp:Label ID="Lbl_activity" runat="server" Text="Activity Name"></asp:Label>
      </td>
      <td width="64%" class="frm-rght-clr1234">
      <asp:Label ID="Lbl_ActivityName" runat="server"></asp:Label>
      </td>
      </tr>
      <tr>
      <td colspan="2" height="10"></td>
      </tr>
      <tr>
      <td width="36%" class="frm-lft-clr123">
      Week
      </td>
      <td width="64%" class="frm-rght-clr1234">
      <asp:Label ID="Lbl_week" runat="server"></asp:Label>
      </td>
      </tr>
      <tr>
      <td colspan="2" height="10"></td>
      </tr>
      <tr>
        <td colspan="2" align="center">
            <asp:TextBox ID="txtComments" runat="server" Height="150px" 
                TextMode="MultiLine" Width="600px"></asp:TextBox>
                
                <asp:TextBox ID="TextBox1" style="border:#FFFFFF 1px solid;" runat="server"  
                 Width="1px"></asp:TextBox>
          </td>
      </tr>
      <tr>
        <td height="10" colspan="2"></td>
      </tr>
      <tr>
        <td colspan="2" align ="right"><asp:Button 
                ID="btnSubmit" runat="server" Text="Save" class="button" />
&nbsp;<input type="submit" name="btn_reset22222" value="Cancel" id="btn_reset22222" onclick="window.close();" class="button" />
(Maximum 200 characters)</td>
      </tr>
    </table>
    </div>
    </form>
</body>
</html>
