<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Intranet/IntranetMasterWithoutLink.master"
    AutoEventWireup="true" CodeFile="BannerMaster.aspx.cs" Inherits="Admin_Company_BannerMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css" media="all">
        @import "../../Css/blue1.css";
    </style>
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <div id="FillGrid" runat="server">
        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
            <tr>
                <td valign="top" class="blue-brdr-1">
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="3%">
                                <img src="../../images/employee-icon.jpg" width="16" height="16" />
                            </td>
                            <td class="txt01">
                                Banner Master
                            </td>
                            <td align="right">
                                <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
             <tr style="height: 3px;">
                <td>
                <p style="color:Red">
                * Please Upload only gif,jpg,png images.<br />
                * Please Upload Banner of Size width 730 & Height 144<br />
                </p>
                </td>
            </tr>
            <tr>
                <td height="100" align="right">
              <table style="width:100%;text-align:left" id="tbl_svdata">
                       <tr>
                       <td style="width:25%;text-align:right" class="frm-lft-clr123">Name</td>
                       <td style="width:25%" class="frm-rght-clr123"><input type="text" id="txt_imagename" runat="server" placeholder="Name of Image" /></td>
                       <td style="width:25%;text-align:right" class="frm-lft-clr123">URL</td>
                       <td style="width:25%"  class="frm-rght-clr123"> <input type="text" runat="server"  id="txt_url" placeholder="Image URL" /></td>
                        </tr>
                        <tr>
                          <td style="width:25%;text-align:right" class="frm-lft-clr123">Image</td>
                       <td style="width:25%" colspan="3"  class="frm-rght-clr123"><asp:FileUpload runat="server" ID="file_image"  ToolTip="Upload Banner Image" EnableTheming="true"/></td>
                      
                        </tr>
                        <tr>
                        <td colspan="4">
                        <span style="float:right">
                          <asp:Button runat="server" ID="btn_add" Text="Add" Width="100" CssClass="button" 
                                onclick="btn_add_Click"/></span>
                        </td>
                        </tr>


                       

                       </table>
                </td>
            </tr>
           
            <tr>
                <td>
                    <div id="dvResult" runat="server" style="display: block;">
                   <asp:GridView ID="grd_banners" runat="server" AllowPaging="true"  
                            AutoGenerateColumns="false" DataKeyNames="ID"  Width="100%" PageSize="5"
                            onrowdatabound="grg_banners_RowDataBound" 
                            onrowcommand="grd_banners_RowCommand" onpageindexchanging="grd_banners_PageIndexChanging" 
                          >
                  <EmptyDataTemplate>
                  <table style="width:100%">
                  <tr>
                  <td class="frm-lft-clr123">No Data Found</td>
                  </tr>
                  </table>
                  </EmptyDataTemplate>
                    <Columns>
                    
                    <asp:TemplateField>
                  
                    <HeaderTemplate>
                    <table style="width:100%">
                    <tr>
                    <td style="width:20%">Image Name</td>
                    <td style="width:20%">URL</td>
                    <td style="width:20%">Image</td>
                    <td style="width:20%">Status</td>
                    <td style="width:20%">Action</td>
                    </tr>
                    </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                     <table style="width:100%">
                    <tr>
                    <td style="width:20%"><asp:Label runat="server" ID="lbl_imagename" ToolTip="Image Name" Text='<%# Eval("ImageName") %>'>'></asp:Label></td>
                    <td style="width:20%"><asp:Label runat="server" ID="lbl_url" ToolTip="URL" Text='<%# Eval("URL") %>'>'></asp:Label></td>
                    <td style="width:20%"><asp:Image runat="server" ID="img_banner" Width="100" Height="80" ToolTip=' <%#Eval("FilePath")%>'></asp:Image></td>
                    <td style="width:20%"><asp:Image runat="server"  ID="img_status" AlternateText='<%#Eval("isActive") %>'/></td>
                    <td style="width:20%">
                    <asp:LinkButton runat="server" ID="lnk_delete"  Text="delete" CommandName='deleted' CommandArgument='<%# Eval("ID")%>' CssClass="link-red"></asp:LinkButton> |
                      <asp:LinkButton runat="server" ID="lnk_changestatus"  Text=" change status" CommandName='status' CommandArgument='<%# Eval("ID")%>' CssClass="link-red"></asp:LinkButton>
                    </td>
                    </tr>
                    </table>
                    </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                   </asp:GridView>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                 </td>
            </tr>
        </table>
    </div>
</asp:Content>
