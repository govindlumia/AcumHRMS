<%@ Page Title="" Language="C#" MasterPageFile="~/TimeSheet/User/TimesheetUser.master" AutoEventWireup="true" CodeFile="TeamTimeSheet.aspx.cs" Inherits="TimeSheet_User_TeamTimeSheet" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript" src="../js/CalculateWeekTotal.js"></script>
    <ajax:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server">
    </ajax:toolkitscriptmanager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                                            Team TimeSheet
                                        </td>
                                        <td align="right">
                                        </td>
                                    </tr>
                                    <tr>
                                    <td colspan="2"></td>
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
                                <div id="AddTimeSheet" runat="server" style="display: block;">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td class="frm-lft-clr123" width="36%">
                                                Select a week
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddl_week" runat="server" Width="172px" 
                                                  AutoPostBack="false"  >
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                        <td colspan="2"></td>
                                        </tr>
                                          <tr>
                                            <td class="frm-lft-clr123" width="36%">
                                                Select Employee
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddl_employee" runat="server" Width="172px" AutoPostBack="false"
                                                 >
                                                </asp:DropDownList>
                                            </td>
                                        </tr>

                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                            
                            </td>
                        </tr>
                           <tr>
                            <td  style="text-align:center">
                            <asp:Button runat="server" ID="btn_view" Text="View" CssClass="button" 
                                  onclick="btn_view_Click"   />
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                                &nbsp;
                            </td>
                        </tr>
                         <tr>
                            <td height="10">
                            <asp:Label runat="server" ID="lbl_userofsheet"></asp:Label>
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
                                    OnRowDataBound="GrdViewTimeSheet_RowDataBound" BorderWidth="1px" CellPadding="4"
                                    PageSize="10" AllowPaging="true" ShowFooter="true" EmptyDataText="No Record(s) found">
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
                      
                        <tr style="height:60px">
                        <td>
                        &nbsp;
                        </td>
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
                                    <PagerStyle CssClass="frm-lft-clr123" Width="500px" Font-Size="18px"  HorizontalAlign="Left" VerticalAlign="Top"/>
                                                <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" Visible="true" LastPageText="last" NextPageText="next" PreviousPageText="prev"  FirstPageText="first" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
