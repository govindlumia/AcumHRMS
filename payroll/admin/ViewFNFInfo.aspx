<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewFNFInfo.aspx.cs" Inherits="payroll_admin_ViewFNFInfo" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>--%>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
<%@ Register Src="../../Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css" media="all">
@import "../../css/blue1.css";
        .auto-style1 {
            font: bold 11px verdana;
            color: #d17100;
            height: 13px;
        }
    </style>
     <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width:100%">                 
           <tr>
           <td class="head-2" valign="top">
               <asp:GridView ID="Gridviewviewfnfinfo" runat="server" DataKeyNames="EMPCODE" Font-Size="11px" Font-Names="Arial" CellSpacing="0"
                   CellPadding="4"  Width="100%" AutoGenerateColumns="False" OnRowDataBound="Gridviewviewfnfinfo_RowDataBound"
                   BorderWidth="0px" EmptyDataText="No such employee exists !" OnRowCommand="Gridviewviewfnfinfo_RowCommand">
                   <Columns>
                         <asp:BoundField visible="true" DataField="EMPNAME" HeaderText="Name">
                           <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                           <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                           </asp:BoundField>
                       <asp:BoundField DataField="DATE_OF_FNF" HeaderText="Date Of Fnf">
                           <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                           <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                        </asp:BoundField>
                       <asp:BoundField DataField="INCLUDE_ONHOLD_SALARY" HeaderText="On Hold Salary">
                           <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                           <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                       </asp:BoundField>
                       <asp:BoundField visible="true" DataField="total_workindays" HeaderText="Working Days">
                           <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                           <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                           </asp:BoundField>
                       <asp:BoundField DataField="bankname" visible="true" HeaderText="Bank">
                           <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                           <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                        </asp:BoundField>
                       <asp:BoundField DataField="TOTAL_EARNINGS" HeaderText="Earnings">
                           <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                           <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                       </asp:BoundField>
                       <asp:BoundField DataField="TOTAL_DEDUCTIONS" HeaderText="Deductions">
                           <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                           <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                        </asp:BoundField>
                       <asp:BoundField DataField="TOTAL_PAY" HeaderText="Net Pay">
                           <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                           <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                       </asp:BoundField>
                       <asp:BoundField DataField="REIMBURSEMENT_TYPE" HeaderText="Pay Type">
                           <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                           <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                       </asp:BoundField>
                       <asp:ButtonField CommandName="View Fnf Info" Text="View" ButtonType="Button" ControlStyle-CssClass="frm-lft-clr123 frm-rght-clr1234" />
                        <asp:ButtonField CommandName="Edit Info" Text="Edit" ButtonType="Button" ControlStyle-CssClass="frm-lft-clr123 frm-rght-clr1234" />
                 
                        </Columns>
                   <HeaderStyle CssClass="frm-lft-clr123" />
                   <FooterStyle CssClass="frm-lft-clr123" />
                   <RowStyle Height="5px" />
                   <PagerStyle CssClass="frm-lft-clr123"></PagerStyle>
               </asp:GridView>
         </tr>
        </table>
    </div>
          
    </form>
</body>
</html>
