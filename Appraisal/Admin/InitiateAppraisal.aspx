<%@ Page Title="" Language="C#" MasterPageFile="~/Appraisal/AppraisalMasterWithoutLeftPanel.master" AutoEventWireup="true" CodeFile="InitiateAppraisal.aspx.cs" Inherits="Appraisal_Admin_InitiateAppraisal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
<%@ Register Src="../../Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css" media="all">
        @import "../../Css/blue1.css";
        @import "../../Css/example.css";
        @import "../../Css/ajax__tab_xp2.css";

        .style1 {
            border-left: 1px solid #c9dffb;
            border-top: 1px solid #c9dffb;
            border-bottom: 1px solid #c9dffb;
            background: #edf5ff;
            padding: 4px 0 4px 5px;
            font: bold 11px verdana, Helvetica, sans-serif;
            color: #013366;
            height: 42px;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
        }

        .style2 {
            background: #f8fbff;
            border: 1px solid #c9dffb;
            padding: 5px 0 5px 5px;
            font: normal 12px Arial, Helvetica, sans-serif;
            color: #013366;
            height: 42px;
        }
    </style>
    <script type="text/javascript" src="../../js/tabber.js"></script>
    <script type="text/javascript">
        document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>
    <Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </Ajax:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
        <contenttemplate>
            <div class="header">
                
                <div>
                    <asp:UpdatePanel ID="updatepannel1" runat="server">
                        <ContentTemplate>
                            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="updatepannel1"
                                DisplayAfter="1" runat="server">
                                <ProgressTemplate>
                                    <div class="divajax">
                                        <table width="100%">
                                            <tr>
                                                <td align="center" valign="top">
                                                    <img src="../../images/loading.gif" alt="" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="bottom" align="center" class="txt01" height="23">
                                                    Please Wait...
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <div>
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tbody>
                                        <tr>
                                            <td class="blue-brdr-1">
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td class="txt01">
                                                            Initiate Appraisal
                                                        </td>
                                                        <td class="txt-red" align="right">
                                                            <span id="message" runat="server">&nbsp;</span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="7">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td valign="middle" class="txt02 blue-brdr-1" height="15">
                                                            &nbsp;Search Employee
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="5" valign="top">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                  <td class="frm-lft-clr123" width="10%">
                                                                      Company
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="10%">
                                                                    <asp:DropDownList runat="server" CssClass="select" ID="ddl_company"  AutoPostBack="true"
                                                                            onselectedindexchanged="ddl_company_SelectedIndexChanged"></asp:DropDownList>
                                                                    </td>
                                                                    <td class="frm-lft-clr123" width="10%">
                                                                        Emp Name/Code
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="10%">
                                                                        <asp:TextBox ID="txt_employee" runat="server" CssClass="input" Width="90px"></asp:TextBox>
                                                                    </td>
                                                                    <td class="frm-lft-clr123" width="10%">
                                                                        Designation
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="10%">
                                                                        <asp:DropDownList ID="dd_designation" runat="server" CssClass="select">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td class="frm-lft-clr123" width="10%">
                                                                        Category
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="10%">
                                                                        <asp:DropDownList ID="dd_category" runat="server" CssClass="select" >
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    
                                                                   <%-- <td class="frm-lft-clr123" width="10%">
                                                                        Business Unit
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="10%">
                                                                        <asp:DropDownList ID="dd_bu" runat="server" CssClass="select" >
                                                                        </asp:DropDownList>
                                                                    </td>--%>
                                                                    <td class="frm-rght-clr123" width="10%">
                                                                        <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" />&nbsp;
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
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td valign="top">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td valign="top">
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="TABLE1" onclick="return TABLE1_onclick()">
                                                                                        <tr>
                                                                                            <td valign="middle" class="txt02" style="height: 24px">
                                                                                                &nbsp;Employee List
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr style="height: 3px;">
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <table cellpadding="0" cellspacing="0" width="99%">
                                                                                                    <tr>
                                                                                                        <td class="frm-rght-clr123" align="right">
                                                                                                            <table>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        <label>
                                                                                                                            <asp:LinkButton ID="lnkPre" runat="server" SkinID="linkGrid" CommandName="Previous"
                                                                                                                                ForeColor="#013366" OnCommand="ChangePage"><b>Previous</b></asp:LinkButton>
                                                                                                                            &nbsp;&nbsp;|&nbsp;&nbsp;<asp:LinkButton ID="lnkNext" SkinID="linkGrid" runat="server"
                                                                                                                                ForeColor="#013366" CommandName="Next" OnCommand="ChangePage"><b>Next</b></asp:LinkButton>
                                                                                                                        </label>
                                                                                                                    </td>
                                                                                                                    <td width="100px">
                                                                                                                        <span class="p-page">( Page -
                                                                                                                            <asp:Label ID="lblCurrentPage" CssClass="p-page1" runat="server"></asp:Label>
                                                                                                                            of
                                                                                                                            <asp:Label ID="lblTotalPages" runat="server"></asp:Label>
                                                                                                                            ) </span>
                                                                                                                    </td>
                                                                                                                    <td width="150px">
                                                                                                                        <b>Page Size:</b>
                                                                                                                        <asp:DropDownList ID="ddlPageSize" runat="server" EnableViewState="true" AutoPostBack="true"
                                                                                                                            OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                                                                                                            <asp:ListItem Text="25"></asp:ListItem>
                                                                                                                            <asp:ListItem Text="50"></asp:ListItem>
                                                                                                                            <asp:ListItem Text="100"></asp:ListItem>
                                                                                                                        </asp:DropDownList>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>

                                                                                        <tr>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <tabl cellpadding="0" cellspacing="0" width="100%">
                                                                                                    <tr>
                                                                                                        <td class="frm-rght-clr123">
                                                                                                            <table width="100%">
                                                                                                                <tr>
                                                                                                                    <td width="10%">
                                                                                                                        <label>Select Duration</label>                                                                                                                        
                                                                                                                    </td>
                                                                                                                     <td class="frm-rght-clr123">From 
                                                                    <asp:TextBox ID="txtFrom" runat="server" CssClass="blue1" MaxLength="20" Width="100px"></asp:TextBox>
                                                                    &nbsp; &nbsp;<asp:Image ID="Image1" runat="server" ToolTip="click to open calender"
                                                                        ImageUrl="~/images/clndr.gif"></asp:Image><Ajax:CalendarExtender ID="CalendarExtender1"
                                                                            runat="server" TargetControlID="txtFrom" PopupButtonID="Image1" Format="dd-MMM-yyyy">
                                                                        </Ajax:CalendarExtender>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFrom"
                                                                        SetFocusOnError="True" ToolTip="Select From Date" ValidationGroup="c"
                                                                        ErrorMessage="Select From Date"></asp:RequiredFieldValidator>

                                                                    To   
                                                                    <asp:TextBox ID="txtTo" runat="server" CssClass="blue1" MaxLength="20" Width="100px"></asp:TextBox>
                                                                    &nbsp; &nbsp;<asp:Image ID="Image2" runat="server" ToolTip="click to open calender"
                                                                        ImageUrl="~/images/clndr.gif"></asp:Image><Ajax:CalendarExtender ID="CalendarExtender2"
                                                                            runat="server" TargetControlID="txtTo" PopupButtonID="Image2" Format="dd-MMM-yyyy">
                                                                        </Ajax:CalendarExtender>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtTo"
                                                                        SetFocusOnError="True" ToolTip="Select To Date" ValidationGroup="c"
                                                                        ErrorMessage="Select To Date"></asp:RequiredFieldValidator>                                                                   
                                                                </td>
                                                                                                                    <td width="10%">    
                                                                                                                        <asp:Button runat="server" ValidationGroup="c" Text="Initiate" Id="btnInitiate" OnClick="btnInitiate_Click"></asp:Button>                                                                                                                  
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </tabl
                                                                                                    e>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>             
                                                                                                <asp:RadioButtonList id="chkList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="chkList_SelectedIndexChanged" RepeatDirection="Horizontal">
                                                                                                     <asp:ListItem>Select All</asp:ListItem>
                                                                                                    <asp:ListItem>Deselect All</asp:ListItem>
                                                                                                </asp:RadioButtonList>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="head-2" valign="top">
                                                                                                <asp:GridView ID="GvResult" runat="server" Font-Size="11px" Font-Names="Arial" CellSpacing="0"
                                                                                                    CellPadding="4" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False"
                                                                                                    AllowSorting="true" BorderWidth="0px" EmptyDataText="No such employee exists !"
                                                                                                    OnRowDataBound="empgrid_RowDataBound" OnRowEditing="GvResult_RowEditing" OnSorting="gvDetails_Sorting" OnRowCommand="GvResult_RowCommand">
                                                                                                    <Columns>
                                                                                                        <asp:TemplateField HeaderText="" SortExpression=""
                                                                                                            HeaderStyle-ForeColor="#013366">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:CheckBox runat="server" id="chkInitiate"></asp:CheckBox>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Employee Code" SortExpression="empcode" HeaderStyle-ForeColor="#013366">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l0" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Employee Name" SortExpression="name" HeaderStyle-ForeColor="#013366">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l2" runat="server" Text='<%# Bind ("NAME") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Designation" SortExpression="designationname" HeaderStyle-ForeColor="#013366">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l1" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Category Name" SortExpression="CategoryName" HeaderStyle-ForeColor="#013366">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l9" runat="server" Text='<%# Bind ("CategoryName") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                       <%-- <asp:TemplateField HeaderText="Bussiness Unit" SortExpression="BussinessUnitName"
                                                                                                            HeaderStyle-ForeColor="#013366">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l3" runat="server" Text='<%# Bind ("BussinessUnitName") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>--%>
                                                                                                        <asp:TemplateField HeaderText="Action" SortExpression="Action"
                                                                                                            HeaderStyle-ForeColor="#013366" Visible="False">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:LinkButton runat="server" id="lnkInitiate" commandname="Initiate" commandargument='<%# Bind ("empcode") %>' cssclass="link01" Text="Initiate"></asp:LinkButton>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        
                                                                                                        <%--<asp:HyperLinkField DataNavigateUrlFields="empcode" DataNavigateUrlFormatString="viewempdetail.aspx?empcode={0}"
                                                                                                            NavigateUrl="viewempdetail.aspx" Text="V">
                                                                                                            <ControlStyle CssClass="link05" />
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" />
                                                                                                            <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                                                                        </asp:HyperLinkField>--%>
                                                                                                       <%-- <asp:HyperLinkField DataNavigateUrlFields="empcode,companyid" DataNavigateUrlFormatString="editempmaster.aspx?empcode={0}&companyid={1}"
                                                                                                            NavigateUrl="editempmaster.aspx" Text="E">
                                                                                                            <ControlStyle CssClass="link05" />
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" />
                                                                                                            <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                                                                        </asp:HyperLinkField>--%>
                                                                                                        <asp:TemplateField Visible="false">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <%#linkdelete(Convert.ToString(DataBinder.Eval(Container.DataItem, "empcode")))%>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField Visible="false">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <%#linkreset(Convert.ToString(DataBinder.Eval(Container.DataItem, "empcode")))%>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                                                                                    <FooterStyle CssClass="frm-lft-clr123" />
                                                                                                    <RowStyle Height="5px" />
                                                                                                    <PagerStyle CssClass="frm-lft-clr123"></PagerStyle>
                                                                                                </asp:GridView>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>&nbsp;</td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td valign="middle" class="txt02" style="height: 24px">
                                                                                                &nbsp;Initiated Appraisal List
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                              <table width="100%">
                                                                                                  <tr>
                                                                                                      <td width="15%">
                                                                                                           <b>Employee Name</b> 
                                                                                                      </td>
                                                                                                      <td width="25%">
                                                                                                          <asp:TextBox runat="server" CssClass="input" Width="120px" id="txtSearch" Text=""></asp:TextBox> 
                                                                                                      </td>
                                                                                                      <td>
                                                                                                          <asp:Button ID="btnInitiatedSearch" runat="server" CssClass="button" Text="Search" OnClick="btnInitiatedSearch_Click" />&nbsp;
                                                                                                      </td>
                                                                                                  </tr>
                                                                                              </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:GridView ID="grdInitiated" runat="server" Font-Size="11px" Font-Names="Arial" CellSpacing="0"
                                                                                                    CellPadding="4" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False"
                                                                                                    AllowSorting="true" BorderWidth="0px" EmptyDataText="No Records found !" AllowPaging="True" OnPageIndexChanging="grdInitiated_PageIndexChanging">
                                                                                                    <Columns>  
                                                                                                                                                                                 
                                                                                                        <asp:TemplateField HeaderText="Employee Code">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblIEmpCode" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>

                                                                                                         <asp:TemplateField HeaderText="Employee Name">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="30%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblIEmpName" runat="server" Text='<%# Bind ("EmpName") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>

                                                                                                        <asp:TemplateField HeaderText="Duration">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="30%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblIDuration" runat="server" Text='<%# Bind ("Duration") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField> 
                                                                                                        
                                                                                                         <asp:TemplateField HeaderText="Status">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind ("Status") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>                                                                                                       
                                                                                                                                                                                                               
                                                                                                      <%--  <asp:TemplateField HeaderText="Action" SortExpression="Action"
                                                                                                            HeaderStyle-ForeColor="#013366" Visible="False">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:LinkButton runat="server" id="LinkButton1" commandname="Initiate" commandargument='<%# Bind ("empcode") %>' cssclass="link01" Text="Initiate"></asp:LinkButton>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>--%>                                                                                                                                                                                                                                                                                                                                                                                                                              
                                                                                                    </Columns>
                                                                                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                                                                                    <FooterStyle CssClass="frm-lft-clr123" />
                                                                                                    <RowStyle Height="5px" />
                                                                                                    <PagerStyle CssClass="frm-lft-clr123"></PagerStyle>
                                                                                                </asp:GridView>

                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </contenttemplate>
    </asp:UpdatePanel>
</asp:Content>

