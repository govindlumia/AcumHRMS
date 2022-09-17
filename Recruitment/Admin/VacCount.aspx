<%@ Page Title="" Language="C#" MasterPageFile="~/Recruitment/User/RecruitmentWithoutLink.master"
    AutoEventWireup="true" CodeFile="VacCount.aspx.cs" Inherits="Recruitment_Admin_VacCount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPP1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_message" runat="Server">
    <link href="../Css/tab/tabcontent.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function numberonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) { //if the key isn't the backspace key (which we should allow)
                if (unicode < 48 || unicode > 57) //if not a number
                    return false //disable key press
            }
        }
    </script>
    <div id="Div1" runat="server">
        <table cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td valign="top">
                    <h3>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="3%">
                                    <img alt="" src="../../images/header-icon.png" />
                                </td>
                                <td width="79%" class="comment_text">
                                    Set Vacancy Count
                                </td>
                            </tr>
                        </table>
                    </h3>
                </td>
            </tr>
        </table>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="frm-lft-clr123">
                Vacancy Count (New)
            </td>
            <td class="frm-rght-clr123">
                <asp:TextBox ID="txtCount" runat="server" MaxLength="4" onkeypress=" return isNumber (event);"></asp:TextBox>
            </td>
            <td class="frm-lft-clr123">
                Vacancy Count (Current)
            </td>
            <td class="frm-rght-clr123">
                <asp:Label ID="lblCount" Text="test" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="5px">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button" OnClick="btnUpdate_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
