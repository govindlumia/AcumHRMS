<%@ Page Title="" Language="C#" MasterPageFile="~/TimeSheet/User/TimesheetUser.master" AutoEventWireup="true" CodeFile="TimesheetView.aspx.cs" Inherits="TimeSheet_User_TimesheetView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </Ajax:ToolkitScriptManager>
   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="HomePage" runat="server">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tbody>
                        <tr>
                            <td class="blue-brdr-1">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td class="txt01">
                                            <img alt="" src="../../images/header-icon.png" />
                                            Employee TimeSheet for Approval
                                        </td>
                                        <td align="right">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="blue-brdr-1">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td class="frm-lft-clr123" width="45%">
                                        Time Sheet of <asp:Label runat="server" ID="lbl_employee"></asp:Label>
                                        </td>
                                        <td class="frm-lft-clr123" width="35%">
                                      For Week   <asp:Label runat="server" ID="lbl_week"></asp:Label>
                                        </td>
                                        <td class="frm-lft-clr123">
                                         
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="blue-brdr-1">
                             
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GrdViewTimeSheet" runat="server" AutoGenerateColumns="False" Width="100%"
                                    BorderWidth="1px" CellPadding="4" PageSize="10" AllowPaging="true" ShowFooter="true" EmptyDataText="No Record(s) found">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Project Name">
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" Width="130" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_projectname" Text='<%# bind("ProName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                             <FooterStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Activity Name">
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" Width="130" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_actname" Text='<%#  bind("ActivityName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="Lbl_Total" runat="server" Text="Total"></asp:Label>
                                            </FooterTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mon">
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" Width="45" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_mondatwork" Text='<%# bind("MonTime") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="MonTotal" runat="server" />
                                            </FooterTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tue">
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" Width="45" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_tueswork" Text='<%# bind("TuesTime") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="TueTotal" runat="server" />
                                            </FooterTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Wed">
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" Width="45" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_wedwork" Text='<%# bind("WedTime") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="WedTotal" runat="server" />
                                            </FooterTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Thu">
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" Width="45" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_thuwork" Text='<%# bind("ThurTime") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="ThuTotal" runat="server" />
                                            </FooterTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" Width="45" />
                                            <FooterStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fri">
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" Width="45" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_friwork" Text='<%# bind("FriTime") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="FriTotal" runat="server" />
                                            </FooterTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" Width="45" />
                                            <FooterStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sat">
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" Width="45" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_satwork" Text='<%# bind("SatTime") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="SatTotal" runat="server" />
                                            </FooterTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sun">
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" Width="45" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_sunwork" Text='<%# bind("SunTime") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="SunTotal" runat="server" />
                                            </FooterTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total">
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" Width="45" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_total" Text='<%# bind("Total") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="TxtTotal" runat="server" Text='<%# bind("Total") %>' />
                                            </FooterTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Comment">
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" Width="45" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_comment" Text='<%# bind("UserComment") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                             <FooterStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                    <tr>
                                        <td width="40%">
                                         
                                        </td>
                                        <td width="12%" align="center">
                                          &nbsp; 
                                        </td>
                                        <td width="12%" align="center">
                                            <asp:Button ID="btnEdit" runat="server" CssClass="button" Text="Edit" 
                                                onclick="btnEdit_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                        <td>
                     <table style="width:100%">
                    <tr>
                    <td style="width:50%">
                   <span style="float:left"> Enter Comment <span style="color:Red"> (*)</span></span>
                    <span style="float:right"><asp:TextBox runat="server" ID="txt_comment" 
                            TextMode="MultiLine" Width="220px" Height="80px" CssClass="input_miltiline"
                        ></asp:TextBox></span>
                    </td>
                    <td></td>
                    </tr>
                    <tr>
                   <td colspan="2">
                        <asp:Button ID="btn_approve" runat="server" CssClass="button" Text="Approve" 
                            onclick="btn_approve_Click" />
                        <span style="padding-left:40px">     <asp:Button ID="btn_reject" runat="server" 
                            CssClass="button" Text="Reject" onclick="btn_reject_Click" /></span>
                   </td>
                    </tr>
                     </table>
                        </td>
                        </tr>
                        <tr style="height:40px">
                        <td></td>
                        </tr>
                        
                        <tr>
                        <td height="10">
                      <h5>  Actions Performed On TimeSheet</h5>
                        </td>
                        </tr>
                        <tr>
                           
                       
                            <td height="10">
                                <asp:GridView ID="grd_status" runat="server" AutoGenerateColumns="False" Width="100%"
                                    BorderWidth="1px" CellPadding="4" PageSize="10" AllowPaging="true"
                                    EmptyDataText="No Record(s) found" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" Width="130" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_projectname" Text='<%# bind("Action") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Performed By">
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" Width="130" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_actname" Text='<%#  bind("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                           
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                          
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" Width="45" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_mondatwork" Text='<%# bind("EnterDate") %>'></asp:Label>
                                            </ItemTemplate>
                                         
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                           
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Comment">
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" Width="45" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_tueswork" Text='<%# bind("Comment") %>'></asp:Label>
                                            </ItemTemplate>
                                        
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                            
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
