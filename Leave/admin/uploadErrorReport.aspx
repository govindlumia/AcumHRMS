<%@ Page Language="C#" AutoEventWireup="true" CodeFile="uploadErrorReport.aspx.cs"
    Inherits="leave_admin_uploadErrorReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Acuminous Software.</title>
    <style type="text/css" media="all">
@import "../css/blue1.css";
fieldset {
 margin:0; padding:0; border: 1px solid #c9dffb; padding:0 7px 10px 7px;
}
legend {
 font: 12px Arial, Helvetica, sans-serif; color:#08486d; padding-bottom: 0px; padding-top: 2px;
}
</style>

    <script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="leave" runat="server">
        </asp:ScriptManager>
        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax"><table width="100%"><tr><td align="center" valign="top"><img src="../images/loading.gif" /></td><td valign="bottom">Please Wait...</td></tr></table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>--%>
        <table width="718" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="top" height="463px" colspan="5">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top" class="blue-brdr-1">
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="3%">
                                            <img src="../images/employee-icon.jpg" width="16" height="16" /></td>
                                        <td class="txt01">
                                            Upload Attendance Error Report</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="frm-lft-clr123" colspan="4">
                                            <fieldset>
                                                <legend><b>Corrected Attendance Sheet</b></legend>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td class="frm-rght-clr123">
                                                            <asp:FileUpload ID="fupload" runat="server" Width="531px" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fupload"
                                                                ErrorMessage="Select excel file" ValidationGroup="v"></asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td width="73%" align="right" class="txt-red" style="height: 13px">
                                                            <span id="message" runat="server"></span>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                    <td align="right">
                                                    <a class="link05" href="Upload/ErorList.xls" target="_blank">Download Error List Excel Format</a>
                                                     </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frm-rght-clr123" colspan="4">
                                            <asp:Button ID="btn_upload" runat="server" CssClass="button" Text="Upload" OnClick="btn_upload_Click"
                                                ValidationGroup="v" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <%--</ContentTemplate>
</asp:UpdatePanel>  --%>
    </form>
</body>
</html>
