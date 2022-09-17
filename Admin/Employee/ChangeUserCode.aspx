<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Employee/EmployeeMaster.master" AutoEventWireup="true" CodeFile="ChangeUserCode.aspx.cs" Inherits="Admin_Employee_ChangeUserCode" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content_head" ContentPlaceHolderID="cph_header" runat="server" >
    <style type="text/css" media="all">
        @import "../../Css/blue1.css";
        @import "../../Css/example.css";
      
    </style>
      <link href="../../css/blue1.css" rel="stylesheet" type="text/css" />
    <link href="../../Calender/css/calendar.css" rel="stylesheet" type="text/css" />

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
    <script type="text/javascript" src="../../js/tabber.js"></script>
    <script type="text/javascript">
        document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>
    

    <ajaxToolkit:ToolkitScriptManager EnablePartialRendering="true" runat="Server" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
        <ContentTemplate>
  
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="middle" class="txt02 blue-brdr-1" height="23" colspan="2">
                    &nbsp;Change Employee Code
                </td>
            </tr>
            <tr>
                <td height="5" valign="top" colspan="2">
                </td>
            </tr>
            <tr>
                <td class="frm-lft-clr123" style="width:50%"> 
                   Enter Current Code
                    <asp:TextBox ID="txt_currentCode" CssClass="input" runat="server"></asp:TextBox>
               
                </td>
                <td class="frm-lft-clr123">
                <asp:Button runat="server" ID="btn_check" Text="check" CssClass="button" 
                        onclick="btn_check_Click" />

                <span style="padding-left:30px;color:Red">
                <asp:Label runat="server" ID="lbl_check_result"></asp:Label>
                </span>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
               <tr>
                <td  class="frm-lft-clr123" colspan="2">
                <asp:Label runat="server" ID="lbl_emp_detail"></asp:Label>
                </td>
           
           
            </tr>
           <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
            <div runat="server" id="dv_newcode" visible="false">

                <td class="frm-lft-clr123" colspan="2">
                  
               Enter New Code&nbsp;&nbsp; <asp:TextBox runat="server" ID="txt_new_emp_code"></asp:TextBox>
               <span style="padding-left:10px">
                   <asp:Button runat="server" Text="Change" ID="btn_change" CssClass="button" 
                        onclick="btn_change_Click"/> 
               
                   </span>
             <span style="padding-left:10px;color:Red">
             <asp:Label runat="server" ID="lbl_new_result"></asp:Label>
             </span>
                </td>
                </div>
            </tr>
              <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center" class="frm-lft-clr123">
            
                </td>
            </tr>
           <%-- <tr>
                <td>
                    &nbsp;
                </td>
            </tr>--%>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        
        </table>
  </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>



