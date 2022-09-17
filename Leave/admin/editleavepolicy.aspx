<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editleavepolicy.aspx.cs"
    Inherits="Leave_admin_editleavepolicy" Title="Acuminous Software." %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Intranet</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
    </style>
    <script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>
    <script type="text/javascript" src="../js/jquery-1.2.2.pack.js"></script>
    <script type="text/javascript" src="../js/ddaccordion.js"></script>
    <script type="text/javascript" src="../js/timepicker.js"></script>
    <script type="text/javascript">
        ddaccordion.init({
            headerclass: "expandable", //Shared CSS class name of headers group
            contentclass: "submenu", //Shared CSS class name of contents group
            collapseprev: true, //Collapse previous content (so only one open at any time)? true/false 
            defaultexpanded: [], //index of content(s) open by default [index1, index2, etc] [] denotes no content
            animatedefault: false, //Should contents open by default be animated into view?
            persiststate: true, //persist state of opened contents within browser session?
            toggleclass: ["", "openheader"], //Two CSS classes to be applied to the header when it's collapsed and expanded, respectively ["class1", "class2"]
            togglehtml: ["suffix", "<img src='../images/plus3.gif' class='statusicon' />", "<img src='../images/minus3.gif' class='statusicon' />"], //Additional HTML added to the header when it's collapsed and expanded, respectively  ["position", "html1", "html2"] (see docs)
            animatespeed: "normal" //speed of animation: "fast", "normal", or "slow"
        })
    </script>
    <%--<script type="text/javascript">
function time()
{
var t1=document.getElementById("ctl00_ContentPlaceHolder1_txtstime").toString();

}
</script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="leave" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <contenttemplate>
    
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


<table width="718" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top" height="463px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="3%"><img src="../images/employee-icon.jpg" width="16" height="16" /></td>
              <td class="txt01">Leave Policy</td>
            </tr>
        </table></td>
      </tr>
      <tr>
        <td height="5" valign="top"></td>
      </tr>
      <tr>
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td height="20" valign="top" class="txt02"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                     <tr>
                       <td width="27%" class="txt02">View Policy</td>
                       <td width="73%" align="right" class="txt-red"><span id="message" runat="server"></span>&nbsp;</td>
                     </tr>
              </table></td>
            </tr>    
            <tr>
              <td class="head-2" >
              
                  <asp:GridView ID="policygrid" runat="server" Font-Size="11px" Font-Names="Arial"  CellSpacing="0" CellPadding="4" DataKeyNames="policyid" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" OnRowDeleting="policygird_RowDeleting1" AllowPaging="True" OnPageIndexChanging="policygrid_PageIndexChanging" PageSize="30" EmptyDataText="Sorry no record found">
                   <Columns>
                   
                   <asp:TemplateField HeaderText="Policy Name">
                   <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                   <ItemStyle Width="30%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                   <ItemTemplate>                  
                        <asp:Label ID="l2" runat="server" Text ='<%# Bind ("policyname") %>'></asp:Label>                  
                   </ItemTemplate>
                   </asp:TemplateField>
                  
                   <asp:TemplateField HeaderText="Policy File">
                   <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  

                  <ItemStyle Width="20%" Font-Size="14px" Font-Names="Arial" HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"/> 
                                                 

                  <ItemTemplate>
                    <a href="../../upload/policydockit/<%#DataBinder.Eval(Container.DataItem,"policy_file_name")%>" target="_blank" class="link05">View File</a></td>

                  </ItemTemplate>
                   </asp:TemplateField>
                   
                   <asp:TemplateField HeaderText="File Type">
                     <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>    
                  <ItemStyle Width="20%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"/>
                  <ItemTemplate>
                  
                  <asp:Label ID="l3" runat="server" Text ='<%# Bind("policy_file_type")%>'></asp:Label>
                
                   </ItemTemplate>
                   </asp:TemplateField>
                   
                   <asp:TemplateField HeaderText="Uploaded Date">
                   <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                   <ItemStyle Width="18%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                  
                  <asp:Label ID="l1" runat="server" Text ='<%# Eval ("date","{0:dd MMM yyyy}") %>'></asp:Label>
                  
                  </ItemTemplate>
                   </asp:TemplateField>
                  
                   <asp:TemplateField>
                     <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>    
                      <ItemStyle Width="12%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"/> 
                      <ItemTemplate>
                         <a class="link05" href="updatepolicy.aspx?policyid=<%#DataBinder.Eval(Container.DataItem, "policyid")%>" target="_self">Edit</a> |
                       
                         <asp:LinkButton ID="LinkButton2" runat="server" CssClass="link05"  OnClientClick="return confirm(' Do you want to Delete this record?');" CommandName="Delete" >Delete</asp:LinkButton>
                    
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
      <tr>
        <td height="10" valign="top"></td>
      </tr>
      <tr>
        <td valign="top"></td>
      </tr>
    </table></td>
  </tr>
</table>
</contenttemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
