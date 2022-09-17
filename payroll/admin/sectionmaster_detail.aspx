<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sectionmaster_detail.aspx.cs"
    Inherits="payroll_admin_sectionmaster_detail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Employee Information</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>
    <script language="JavaScript" type="text/javascript" src="../../js/popup.js"></script>
    <script type="text/javascript" src="../../js/jquery-1.2.2.pack.js"></script>
    <script type="text/javascript" src="../../js/ddaccordion.js"></script>
    <script type="text/javascript">
        ddaccordion.init({
            headerclass: "expandable", //Shared CSS class name of headers group that are expandable
            contentclass: "categoryitems", //Shared CSS class name of contents group
            revealtype: "click", //Reveal content when user clicks or onmouseover the header? Valid value: "click" or "mouseover
            collapseprev: false, //Collapse previous content (so only one open at any time)? true/false 
            defaultexpanded: [0, 0], //index of content(s) open by default [index1, index2, etc]. [] denotes no content
            onemustopen: true, //Specify whether at least one header should be open always (so never all headers closed)
            animatedefault: true, //Should contents open by default be animated into view?
            persiststate: true, //persist state of opened contents within browser session?
            toggleclass: ["", "openheader"], //Two CSS classes to be applied to the header when it's collapsed and expanded, respectively ["class1", "class2"]
            togglehtml: ["prefix", "", ""], //Additional HTML added to the header when it's collapsed and expanded, respectively  ["position", "html1", "html2"] (see docs)
            animatespeed: "normal", //speed of animation: "fast", "normal", or "slow"
            oninit: function (headers, expandedindices) { //custom code to run when headers have initalized
                //do nothing
            },
            onopenclose: function (header, index, state, isuseractivated) { //custom code to run whenever a header is opened or closed
                //do nothing
            }
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="leave" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%--<asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax">
                <table width="100%">
                <tr>
                <td align="center" valign="top"><img src="../../images/loading.gif" /></td>
                </tr>
                <tr>
                <td valign="bottom" align="center" class="txt01">Please Wait...</td>
                </tr>
                </table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>--%>
            <table width="718" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top" class="blue-brdr-1">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="3%">
                                                <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                            </td>
                                            <td class="txt01">
                                                Section Master
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="5" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td height="20" valign="top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="27%" class="txt02">
                                            </td>
                                            <td width="73%" align="right" class="txt-red">
                                                <span id="message" runat="server"></span>&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" class="txt02">
                                    Create Section<%--<div class="glossymenu1">
  <a class="menuheader1 expandable" href="#">Create Section</a>
  <div class="categoryitems">
  <ul>
  <li>--%><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
          <td height="5">
          </td>
      </tr>
      <tr>
          <td width="25%" class="frm-lft-clr123">
              Section Name<span style="color: Red">*</span>
          </td>
          <td width="75%" class="frm-rght-clr123">
              &nbsp;<asp:TextBox ID="txtsectionname" runat="server" CssClass="input" Width="152px"
                  MaxLength="50"></asp:TextBox>&nbsp;
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtsectionname"
                  Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                  ValidationGroup="s"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
          </td>
      </tr>
      <tr>
          <td height="5" colspan="2">
          </td>
      </tr>
      <tr>
          <td width="25%" class="frm-lft-clr123">
              Section Description<span style="color: Red">*</span>
          </td>
          <td width="75%" class="frm-rght-clr123">
              &nbsp;<asp:TextBox ID="txtsectdescription" runat="server" CssClass="input" Width="152px"
                  TextMode="MultiLine"></asp:TextBox>&nbsp;
              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtsectionname"
                  Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                  ValidationGroup="s"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
          </td>
      </tr>
      <tr>
          <td height="5" colspan="2">
          </td>
      </tr>
      <tr>
          <td width="25%" class="frm-lft-clr123">
              Mandatory Fields (<img src="../../images/error1.gif" alt="" />)&nbsp;
          </td>
          <td width="75%" class="frm-rght-clr123">
              <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click"
                  ValidationGroup="s" ToolTip="Click to submit " />&nbsp;
          </td>
      </tr>
      <tr>
          <td align="left" colspan="2">
          </td>
      </tr>
  </table>
                                    <%--</li>
                              </ul></div></div>--%>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="5" valign="top">
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="glossymenu1">
                            <%-- <a  href="#">View Section</a>--%>
                            <div>
                                <ul>
                                    <li>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="5">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-rght-clr123" colspan="2">
                                                    &nbsp;&nbsp;
                                                    <asp:GridView ID="sectiongird" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                        BorderWidth="0px" CellPadding="4" DataKeyNames="ID" EmptyDataText="Sorry no record found"
                                                        Font-Names="Arial" Font-Size="11px" PageSize="10" Width="100%" OnPageIndexChanging="sectiongird_PageIndexChanging"
                                                        OnRowEditing="sectiongird_RowEditing" OnRowUpdating="sectiongird_RowUpdating"
                                                        OnRowCancelingEdit="sectiongird_RowCancelingEdit">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Section Name">
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lbl_sectionName" Text='<%# Eval("sname") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label runat="server" ID="lbl_sectionName" Text='<%# Eval("sname") %>'></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemStyle CssClass="frm-rght-clr123" />
                                                                <HeaderStyle CssClass="frm-lft-clr123" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Description">
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lbl_sectionDesc" Text='<%# Eval("description") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox runat="server" ID="txt_sectionDesc" Text='<%# Eval("description") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemStyle CssClass="frm-rght-clr123" />
                                                                <HeaderStyle CssClass="frm-lft-clr123" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Action">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" Text="edit" ID="lnk_edit" CommandName="Edit" CssClass="link01"></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:LinkButton runat="server" Text="update" ID="lnk_edit" CommandName="Update" CssClass="link01"></asp:LinkButton>|
                                                                    <asp:LinkButton runat="server" Text="cancel" ID="lnk_cancel" CommandName="Cancel"
                                                                        CssClass="link01"></asp:LinkButton>
                                                                </EditItemTemplate>
                                                                <ItemStyle CssClass="frm-rght-clr123" />
                                                                <HeaderStyle CssClass="frm-lft-clr123" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                        <FooterStyle CssClass="frm-lft-clr123" />
                                                        <AlternatingRowStyle CssClass="frm-rght-clr12345" />
                                                        <RowStyle Height="5px" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2">
                                                </td>
                                            </tr>
                                        </table>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td height="5" valign="top">
                    </td>
                </tr>
                <tr>
                    <td class="txt02">
                        Create Section Detail
                        <%--<div class="glossymenu1">
  <a class="menuheader1 expandable" href="#">Create Section Detail</a>
  <div class="categoryitems">
  <ul>
  <li>--%>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td height="5" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123">
                                                Section Name
                                            </td>
                                            <td width="75%" class="frm-rght-clr123">
                                                <asp:DropDownList ID="ddlsectionname" runat="server" Width="162px" CssClass="select"
                                                    DataSourceID="SqlDataSource12" DataTextField="sname" DataValueField="sname">
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                    ProviderName="System.Data.SqlClient" SelectCommand="select distinct sname from tbl_payroll_sectionmaster">
                                                </asp:SqlDataSource>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123">
                                                &nbsp;Section Details<span style="color: Red">*</span>
                                            </td>
                                            <td width="75%" class="frm-rght-clr123">
                                                <asp:TextBox ID="txtsectiondetail" runat="server" CssClass="input" Width="158px"
                                                    MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtsectiondetail"
                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                    ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123">
                                                &nbsp;Section Details Despt.<span style="color: Red">*</span>
                                            </td>
                                            <td width="75%" class="frm-rght-clr123">
                                                <asp:TextBox ID="txtsecdetaildesc" runat="server" CssClass="input" Width="158px"
                                                    TextMode="MultiLine"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtsectiondetail"
                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                    ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123">
                                                Mandatory Fields (<img src="../../images/error1.gif" alt="" />)&nbsp;
                                            </td>
                                            <td width="75%" class="frm-rght-clr123">
                                                &nbsp;
                                                <asp:Button ID="btncreatsection" runat="server" Text="Submit" CssClass="button" ValidationGroup="v"
                                                    ToolTip="Click to submit " OnClick="btncreatsection_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                        </table>
                        <%--</li></ul></div></div>--%>
                    </td>
                </tr>
                <tr>
                    <td height="5" valign="top">
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <%-- <a href="#">Section Detail's </a>--%>
                            <div>
                                <ul>
                                    <li>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="5">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-rght-clr123" colspan="2">
                                                    &nbsp;&nbsp;
                                                    <asp:GridView ID="sectiondetailgrid" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                        BorderWidth="0px" CellPadding="4" DataKeyNames="ID" EmptyDataText="Sorry no record found" 
                                                        Font-Names="Arial" Font-Size="11px" PageSize="10" Width="100%" OnPageIndexChanged="sectiondetailgrid_PageIndexChanged"
                                                        OnPageIndexChanging="sectiondetailgrid_PageIndexChanging" 
                                                        onrowcancelingedit="sectiondetailgrid_RowCancelingEdit" 
                                                        onrowediting="sectiondetailgrid_RowEditing" 
                                                        onrowupdating="sectiondetailgrid_RowUpdating">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Section Name">
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lbl_sectionName" Text='<%# Eval("section_name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label runat="server" ID="lbl_sectionName_Edit" Text='<%# Eval("section_name") %>'></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemStyle CssClass="frm-rght-clr123" />
                                                                <HeaderStyle CssClass="frm-lft-clr123" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Section Detail">
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lbl_sectionDetail" Text='<%# Eval("section_detail") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label runat="server" ID="lbl_sectionDetail_Edit" Text='<%# Eval("section_detail") %>'></asp:Label>
                                                                </EditItemTemplate>
                                                                <ItemStyle CssClass="frm-rght-clr123" />
                                                                <HeaderStyle CssClass="frm-lft-clr123" />
                                                            </asp:TemplateField>
                                                       
                                                                <asp:TemplateField HeaderText="Description">
                                                                <ItemTemplate>
                                                                <asp:Label runat="server" ID="lbl_sectionDesc" Text='<%# Eval("Description") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox runat="server" ID="txt_sectionDesc_Edit" Text='<%# Eval("Description") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemStyle CssClass="frm-rght-clr123" />
                                                                <HeaderStyle CssClass="frm-lft-clr123" />
                                                            </asp:TemplateField>

                                                                 <asp:TemplateField HeaderText="Action">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" Text="edit" ID="lnk_edit" CommandName="Edit" CssClass="link01"></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:LinkButton runat="server" Text="update" ID="lnk_edit" CommandName="Update" CssClass="link01"></asp:LinkButton>|
                                                                    <asp:LinkButton runat="server" Text="cancel" ID="lnk_cancel" CommandName="Cancel"  CssClass="link01"></asp:LinkButton>
                                                                </EditItemTemplate>
                                                                <ItemStyle CssClass="frm-rght-clr123" />
                                                                <HeaderStyle CssClass="frm-lft-clr123" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                        <FooterStyle CssClass="frm-lft-clr123" />
                                                        <AlternatingRowStyle CssClass="frm-rght-clr12345" />
                                                        <RowStyle Height="5px" />
                                                    </asp:GridView>
                                                 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2">
                                                </td>
                                            </tr>
                                        </table>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnsbmit" />
            <asp:PostBackTrigger ControlID="btncreatsection" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
