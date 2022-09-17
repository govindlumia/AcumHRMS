<%@ Page Title="" Language="C#" MasterPageFile="~/Recruitment/User/RecruitmentWithoutLink.master"
    AutoEventWireup="true" CodeFile="CanEval.aspx.cs" Inherits="Recruitment_User_CandidateEvaluation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Css/tab/tabcontent.css" rel="stylesheet" type="text/css" />
    <script src="../Css/tab/tabcontent.js" type="text/javascript"></script>
    <script type="text/javascript">
        function Check(textBox, maxLength) {
            if (textBox.value.length > maxLength) {
                alert("You cannot enter more than " + maxLength + " characters.");
                textBox.value = textBox.value.substr(0, maxLength);
            }
        }
    </script>
    <div id="DivCanInfo" runat="server">
        <fieldset id="Fieldset0" runat="server">
            <legend><b>Candidate Information</b></legend>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="2px">
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="frm-lft-clr123">
                        Vacancy ID
                    </td>
                    <td width="30%" class="frm-rght-clr123">
                        <asp:Label ID="lblvacID" runat="server"></asp:Label>
                    </td>
                    <td width="20%" class="frm-lft-clr123">
                        Vacancy Name
                    </td>
                    <td width="30%" class="frm-rght-clr123">
                        <asp:Label ID="lblvacName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="2px">
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="frm-lft-clr123">
                        Candidate ID
                    </td>
                    <td width="30%" class="frm-rght-clr123">
                        <asp:Label ID="lblCanId" runat="server"></asp:Label>
                    </td>
                    <td width="20%" class="frm-lft-clr123">
                        Candidate Name
                    </td>
                    <td width="30%" class="frm-rght-clr123">
                        <asp:Label ID="lblName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="2px">
                    </td>
                </tr>
                <tr>
                    <td class="frm-lft-clr123">
                        Email ID
                    </td>
                    <td class="frm-rght-clr123">
                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                    </td>
                    <td class="frm-lft-clr123">
                        Contact No.
                    </td>
                    <td class="frm-rght-clr123">
                        <asp:Label ID="lblContactno" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="2px">
                    </td>
                </tr>
                <tr>
                    <td class="frm-lft-clr123">
                        Application Date
                    </td>
                    <td class="frm-rght-clr123">
                        <asp:Label ID="lblapplicationdate" runat="server"></asp:Label>
                    </td>
                    <td class="frm-lft-clr123">
                        Created Date
                    </td>
                    <td class="frm-rght-clr123">
                        <asp:Label ID="lblCCreatedDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="2px">
                    </td>
                </tr>
                <tr>
                    <td class="frm-lft-clr123">
                        Remarks
                    </td>
                    <td class="frm-rght-clr123" colspan="3">
                        <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="2px">
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    <div id="DivRoundInfo" runat="server">
        <fieldset id="Fieldset2" runat="server">
            <legend><b>Round Information</b></legend>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="2px">
                    </td>
                </tr>
                <tr>
                    <td width="20%" class="frm-lft-clr123">
                        Round Code
                    </td>
                    <td width="80%" class="frm-rght-clr123">
                        <asp:Label ID="lblRoundCode" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    <div id="DivEvalInfo" runat="server">
        <fieldset id="Fieldset1" runat="server">
            <legend><b>Evaluation Information</b></legend>
            <table width="100%" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="5">
                        <asp:GridView ID="GvCanEvalSkills" runat="server" AutoGenerateColumns="False" BorderColor="#c9dffb"
                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Names="Arial" Font-Size="11px"
                            Width="100%" OnRowDataBound="GvCanEvalSkills_DataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Candidate Skills">
                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Middle"
                                        Width="15%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblEvalSkillsID" Visible="false" runat="server" SkinID="gridLabel"
                                            Text='<%# bind("ID") %>'></asp:Label>
                                        <asp:Label ID="lblEvalSkills" runat="server" SkinID="gridLabel" Text='<%# bind("Dsca") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Evaluation Parameter">
                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                        Width="60%" />
                                    <ItemTemplate>
                                        <asp:RadioButtonList ID="rdList" Width="100%" runat="server" RepeatDirection="Horizontal">
                                        </asp:RadioButtonList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remarks">
                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                        Width="25%" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtRemarks" runat="server" Height="50px" Width="220px" Style="resize: none"
                                            TextMode="MultiLine" onkeyup="javascript:Check(this, 200);" onchange="javascript:Check(this, 200);"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td height="5px">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Status : &nbsp;&nbsp;
                        <asp:DropDownList ID="ddlCanStatus" runat="server" CssClass="Select">
                            <asp:ListItem Value="0">Move To Next Round</asp:ListItem>
                            <asp:ListItem Value="1">Not Suitable </asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>
