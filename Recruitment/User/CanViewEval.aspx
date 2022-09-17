<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CanViewEval.aspx.cs" Inherits="Recruitment_CanViewEval" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <link href="../Css/tab/tabcontent.css" rel="stylesheet" type="text/css" />
    <link href="../Css/blue1.css" rel="stylesheet" type="text/css" />
    <script src="../Css/tab/tabcontent.js" type="text/javascript"></script>
    <div id="DataDiv" style="overflow: auto; border: 0px solid olive; background-color: White;
        height: 500px;">
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
                        <td width="10%" class="frm-lft-clr123">
                            Round Code
                        </td>
                        <td width="10%" class="frm-rght-clr123">
                            <asp:Label ID="lblRoundCode" runat="server"></asp:Label>
                        </td>
                        <td width="10%" class="frm-lft-clr123">
                            Round Name
                        </td>
                        <td width="20%" class="frm-rght-clr123">
                            <asp:Label ID="lblRoundName" runat="server"></asp:Label>
                        </td>
                        <td width="8%" class="frm-lft-clr123">
                            Employee
                        </td>
                        <td width="20%" class="frm-rght-clr123">
                            <asp:Label ID="lblEmployee" runat="server"></asp:Label>
                        </td>
                        <td width="10%" class="frm-lft-clr123">
                            Candidate Status
                        </td>
                        <td width="20%" class="frm-rght-clr123">
                            <asp:Label ID="lblStatus" runat="server"></asp:Label>
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
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="25%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblEvalSkills" runat="server" SkinID="gridLabel" Text='<%# bind("EskillN") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Evaluation">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="25%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblEvalPara" Visible="false" runat="server" SkinID="gridLabel" Text='<%# bind("EPara") %>'></asp:Label>
                                            <asp:RadioButtonList ID="rdList" Width="100%" runat="server" RepeatDirection="Horizontal" >
                                            </asp:RadioButtonList>
                                            <asp:Label ID="lblParaSel" runat="server" SkinID="gridLabel"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="50%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblRemarks" runat="server" SkinID="gridLabel" Text='<%# bind("Remarks") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td height="2px">
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </div>
    </form>
</body>
</html>
