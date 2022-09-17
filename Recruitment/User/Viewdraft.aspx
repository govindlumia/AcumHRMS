<%@ Page Title="" Language="C#" MasterPageFile="~/Recruitment/User/RecruitmentMaster.master" AutoEventWireup="true" CodeFile="Viewdraft.aspx.cs" Inherits="Recruitment_User_Viewdraft" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table width="100%" border="1" cellpadding="0" cellspacing="0">
    <tr>
    <td height="5" colspan="4" class="blue-brdr-1">
     <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                            <td class="frm-lft-clr123" style="height: 13px">
                             Name
                            </td>
                             <td class="frm-lft-clr123" style="height: 13px">
                              <asp:TextBox ID="txtCandidateID" runat="server" CssClass="blue1" Width="80px" 
                                     MaxLength='20'></asp:TextBox>
                             
                            </td>
                           <td class="frm-lft-clr123" style="height: 13px">
                            From Date
                            </td>
                            <td class="frm-lft-clr123" style="width:120px">
                                <asp:TextBox ID="txt_FromDate" runat="server" CssClass="blue1" 
                                    EnableViewState="false" Width="80px"></asp:TextBox>
                                <asp:Image ID="Image1" runat="server" 
                                    ImageUrl="~/Calender/images/calendar_icon.gif" 
                                    ToolTip="click to open calender" /><asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1" Format="dd-MMM-yyyy"  TargetControlID="txt_FromDate">
                                    </asp:CalendarExtender>
                                  </td>
                            <td class="frm-lft-clr123" style="height: 13px">
                            ToDate
                            </td>
                            <td class="frm-lft-clr123" style="height: 13px">
                            
                                 <asp:TextBox ID="txt_Todate" runat="server" CssClass="blue1"   Width="80px" EnableViewState="false"></asp:TextBox>
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Calender/images/calendar_icon.gif" ToolTip="click To Open Calender" /><asp:CalendarExtender ID="CalenadarExtender" runat="server" PopupButtonID="Image2" Format="dd-MMM-yyyy" TargetControlID="txt_Todate">
                            </asp:CalendarExtender>
                                 
                                
                                </td>
                            <td class="frm-lft-clr123" style="height: 13px">
                                <asp:Button ID="btnSearch" runat="server" Text="Search"  Width="100px" 
                                    CssClass="button" ValidationGroup="v" onclick="btnSearch_Click"/>
                            </td>
                            </tr>
                        </table>
    </td>
    </tr>
    </table>
    <asp:GridView ID="Grid_draft" runat="server" AutoGenerateColumns="false" AllowPaging="True" Width="100%" HorizontalAlign="Left"
     CellPadding="4" CaptionAlign="Left"  BorderColor="#c9dffb" OnRowCommand="Grid_Cndidate_RowCommand" AllowSorting="True" BorderWidth="1px" >
                    <Columns>
            
                    <asp:TemplateField HeaderText="Name" SortExpression="Candidate_Name">
                    <ItemTemplate>
                    <asp:Label ID="lblcanname" runat ="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                     <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                    <ItemStyle Width="15%" CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Email_Id" SortExpression="Email_Id">
                    <ItemTemplate>
                    <asp:Label ID="lblemail" runat ="server" Text='<%# Bind("Email_Id") %>'></asp:Label>
                    </ItemTemplate>
                     <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                    <ItemStyle Width="20%" CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Contact_No" SortExpression="Contact_No">
                    <ItemTemplate>
                    <asp:Label ID="lblcontactno" runat ="server" Text='<%# Bind("Contact_No") %>'></asp:Label>
                    </ItemTemplate>
                     <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                    <ItemStyle Width="15%" CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:TemplateField>
                       <asp:TemplateField HeaderText="ApplicationDate" SortExpression="ApplicationDate">
                    <ItemTemplate>
                    <asp:Label ID="lblapplicationdate" runat ="server" Text='<%# Bind("ApplicationDate") %>'></asp:Label>
                    </ItemTemplate>
                     <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                    <ItemStyle Width="20%" CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Apply For Tech." SortExpression="Apply For">
                    <ItemTemplate>
                    <asp:Label ID="lblmetakey" runat ="server" Text='<%# Bind("MetaKeyWord") %>'></asp:Label>
                    </ItemTemplate>
                     <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                    <ItemStyle Width="18%" CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:TemplateField>
                     
                      <asp:TemplateField HeaderText="Action" SortExpression="can_id">
                    <ItemStyle HorizontalAlign="left" Width="25%" CssClass="frm-rght-clr1234" />
                     <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
            <ItemTemplate>
                <asp:LinkButton ID="btnsavedraft" class="link01" runat="server" ToolTip="save" CommandName="Savedraft"
                    CommandArgument='<%# Eval("Can_ID") %>'>Edit</asp:LinkButton>
                                                                      
                              </ItemTemplate>
               </asp:TemplateField>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123">
                                                            </HeaderStyle>
                                                            <FooterStyle CssClass="frm-lft-clr123" />
                                                            <RowStyle></RowStyle>
    </asp:GridView>

</asp:Content>

