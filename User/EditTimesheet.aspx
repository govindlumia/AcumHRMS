<%@ Page Title="" Language="C#" MasterPageFile="~/TimeSheet/User/MasterWithoutLeft.master"
    AutoEventWireup="true" CodeFile="EditTimesheet.aspx.cs" Inherits="TimeSheet_User_EditTimesheet" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </Ajax:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
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
                                            Edit TimeSheet For Week
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
                                        <td class="frm-lft-clr123" width="25%">
                                     Edit TimeSheet For Week 
                                        </td>
                                        <td class="frm-lft-clr123" width="35%">
                                      <asp:Label runat="server" ID="lbl_fromweek"></asp:Label> to 
                                      <asp:Label runat="server" ID="lbl_toweek"></asp:Label>
                                        </td>
                                        <td class="frm-lft-clr123">
                                            <%--  <asp:LinkButton ID="lnkAdd" CssClass="link02" runat="server" OnClick="lnkAdd_Click">Add TimeSheet</asp:LinkButton>--%>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="blue-brdr-1">
                                <div id="AddTimeSheet" runat="server" style="display: block;">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td class="frm-lft-clr123" width="36%">
                                             
                                            </td>
                                            <td class="frm-lft-clr123">
                                              &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                            <span style="color:Red">Rows having Blank Project Name/Activity Name will not consider as right Data</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                             <div style='overflow:scroll; width:1000px;height:400px'>
                                <asp:GridView ID="Grd_edit_timesheet" runat="server" AutoGenerateColumns="False" Width="100%"
                               DataKeyNames="ID" BorderWidth="1px" CellPadding="4" PageSize="100" 
                                     AllowPaging="true" ShowFooter="true" GridLines="None"
                                    EmptyDataText="No Record(s) found" 
                                     onselectedindexchanging="Grd_edit_timesheet_SelectedIndexChanging" 
                                     onrowdatabound="Grd_edit_timesheet_RowDataBound">
                                    <Columns>
                                      <asp:TemplateField>
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" Width="130" />
                                            <ItemTemplate>
                                      <asp:CheckBox ID="chk_data"  runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Project Name">
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" Width="130" />
                                            <ItemTemplate>
                                          
                                              <asp:TextBox runat="server" ToolTip='<%#bind("ID")%>' AutoPostBack="true" OnTextChanged="calculateTotal_Click" ID="txt_projectName" Text='<%#bind("ProName") %>' ></asp:TextBox>
                                           <Ajax:AutoCompleteExtender runat="server" ID="AutoCom_Project" MinimumPrefixLength="1" CompletionSetCount="10" CompletionInterval="1000" TargetControlID="txt_projectName" ServiceMethod="AutoComplete_Project" UseContextKey="true" ContextKey='<%# bind("ID") %>'></Ajax:AutoCompleteExtender>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Activity Name">
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" Width="130" />
                                            <ItemTemplate>
                                            <%-- <asp:TextBox runat="server" ID="txt_ActivityName" ToolTip='<%#bind("ID")%>'  Text='<%#bind("ActivityName") %>' AutoPostBack="true" OnTextChanged="calculateTotal_Click"></asp:TextBox>
                                           <Ajax:AutoCompleteExtender runat="server" ID="AutoCom_Activity" UseContextKey="true" ContextKey='<%#bind("ID")%>' MinimumPrefixLength="1" CompletionSetCount="10" CompletionInterval="1000" TargetControlID="txt_ActivityName" ServiceMethod="AutoComplete_Activities"></Ajax:AutoCompleteExtender>--%>
                                        <asp:Label runat="server" ID="lbl_category" Text='<%# bind("ActivityName") %>' Visible="false"></asp:Label>
                                           <asp:DropDownList runat="server"  ID="ddl_category" Width="130px"  OnSelectedIndexChanged="changeStatus" AutoPostBack="true"></asp:DropDownList>
                                           
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
                                          <asp:TextBox runat="server" ID="txt_montime" ToolTip='<%#bind("ID")%>' Width="50px" Text='<%# bind("MonTime") %>' AutoPostBack="true" OnTextChanged="calculateTotal_Click" ></asp:TextBox>
                                            
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
                                              <asp:TextBox runat="server" ID="txt_tuestime" ToolTip='<%#bind("ID")%>' Width="50px" Text='<%# bind("TuesTime") %>' AutoPostBack="true" OnTextChanged="calculateTotal_Click"></asp:TextBox>
                                           
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
                                            <asp:TextBox runat="server" ID="txt_wedtime" ToolTip='<%#bind("ID")%>' Width="50px" Text='<%# bind("WedTime") %>' AutoPostBack="true" OnTextChanged="calculateTotal_Click"></asp:TextBox>
                                           
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
                                            <asp:TextBox runat="server" ID="txt_thutime" ToolTip='<%#bind("ID")%>' Width="50px" Text='<%# bind("ThurTime") %>' AutoPostBack="true" OnTextChanged="calculateTotal_Click"></asp:TextBox>
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
                                               <asp:TextBox runat="server" ID="txt_fritime" ToolTip='<%#bind("ID")%>' Width="50px" Text='<%# bind("FriTime") %>' AutoPostBack="true" OnTextChanged="calculateTotal_Click"></asp:TextBox>
                                               
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
                                             <asp:TextBox runat="server" ID="txt_sattime" ToolTip='<%#bind("ID")%>' Width="50px" Text='<%# bind("SatTime") %>' AutoPostBack="true" OnTextChanged="calculateTotal_Click"></asp:TextBox>
                                               
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
                                             <asp:TextBox runat="server" ID="txt_suntime" ToolTip='<%#bind("ID")%>' Width="50px" Text='<%# bind("SunTime") %>' AutoPostBack="true" OnTextChanged="calculateTotal_Click"></asp:TextBox>
                                              
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
                                                <asp:Label ID="TxtTotal" runat="server" />
                                            </FooterTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                            <FooterStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Comment">
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" Width="45" />
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txt_comment" ToolTip='<%#bind("ID")%>' Text='<%# bind("UserComment") %>' AutoPostBack="true" OnTextChanged="calculateTotal_Click"></asp:TextBox>
                                             
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                              </div>
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
                                            &nbsp;
                                        </td>
                                        <td width="12%" align="center">
                                            <asp:Button ID="btn_save" runat="server" CssClass="button" Text="Save" 
                                                onclick="btn_save_Click" />
                                        </td>
                                        <td width="12%" align="center">
                                            <asp:Button ID="btn_add_row" runat="server" CssClass="button" Text="Add Row" 
                                                onclick="btn_add_row_Click" />
                                        </td>
                                        <td width="12%" align="center">
                                            <asp:Button ID="btn_rmv_row" runat="server" CssClass="button" Text="Remove Row" 
                                                onclick="btn_rmv_row_Click" />
                                        </td>
                                        <td width="12%" align="center">
                                            <asp:Button ID="btn_reset" runat="server" CssClass="button" Text="Reset" 
                                                onclick="btn_reset_Click" />
                                        </td>
                                        <td width="12%" align="center">
                                            <asp:Button ID="btn_cancel" runat="server" CssClass="button" Text="Cancel" 
                                                onclick="btn_cancel_Click" OnClientClick="javascript:history.go(-1);" />
                                        </td>
                                        <td width="12%" align="center">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
     </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>
