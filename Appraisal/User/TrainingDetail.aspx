<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TrainingDetail.aspx.cs" Inherits="Appraisal_User_TrainingDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Css/blue1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td valign="top" class="blue-brdr-1">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="3%">
                                        <img src="../../images/employee-icon.jpg" width="16" height="16" alt="" />
                                    </td>
                                    <td class="txt01">Training Detail
                                    </td>
                                    <td align="right"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="head-2">
                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                <tr runat="server" id="trCreate">
                                    <td valign="top">
                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                            <tbody>
                                                <tr>
                                                    <td width="30%" class="frm-lft-clr123">Name of Training<span style="color: Red">*</span>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label runat="server" Style="word-wrap: break-word;" ID="lblName"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" height="5"></td>
                                                </tr>
                                                <tr>
                                                    <td width="30%" class="frm-lft-clr123">Training Type
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label runat="server" ID="lblType"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" height="5"></td>
                                                </tr>
                                                <tr runat="server" visible="false">
                                                    <td class="frm-lft-clr123">Training Date<span style="color: Red">*</span>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label runat="server" ID="lblDate"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" height="5"></td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">Training Venue<span style="color: Red">*</span>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label runat="server" Style="word-wrap: break-word;" ID="lblVenue"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" height="5"></td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">Conducted By<span style="color: Red">*</span>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label runat="server" Style="word-wrap: break-word;" ID="lblConducted"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" height="5"></td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">Training Duration<span style="color: Red">*</span>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label runat="server" ID="lblDuration"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">No of Hours
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label runat="server" ID="lblHours"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" height="5"></td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">Certification Received<span style="color: Red">*</span>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label runat="server" ID="lblCertification"></asp:Label>
                                                        &nbsp;                                                        
                                                        <a runat="server" id="lnkFile" href="" target="_blank" class="link05">Attachment</a>&nbsp;       
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" height="5"></td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">Comments<span style="color: Red">*</span>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label runat="server" Style="word-wrap: break-word;" ID="lblComments"></asp:Label>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
