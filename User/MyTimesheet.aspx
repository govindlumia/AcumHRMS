<%@ Page Title="" Language="C#" MasterPageFile="~/TimeSheet/User/TimesheetUser.master"
    AutoEventWireup="true" CodeFile="MyTimesheet.aspx.cs" Inherits="TimeSheet_User_MyTimesheet" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../js/CalculateWeekTotal.js"></script>
    <script type="text/javascript">
        function CalculateTotalAmount(txtA, Trow) {

            var TxtAmount = document.getElementById(txtA);
            var TSum = 0;

            var getElement;
            var getElementP;
            var getElementT;
            var getElementF;
            Trow = parseInt(Trow) + 1;
            for (var i = 2; i <= parseInt(Trow); i++) {
                if (parseInt(i) <= 9) {
                    getElement = document.getElementById("ctl00_ContentPlaceHolder1_GrdViewTimeSheet_ctl0" + i + "_txtAmount");
                    getElementP = document.getElementById("ctl00_ContentPlaceHolder1_GrdViewTimeSheet_ctl0" + i + "_txtParking");
                    getElementT = document.getElementById("ctl00_ContentPlaceHolder1_GrdViewTimeSheet_ctl0" + i + "_txtToll");
                    getElementF = document.getElementById("ctl00_ContentPlaceHolder1_GrdViewTimeSheet_ctl0" + i + "_txtFuel");
                }
                else {
                    getElement = document.getElementById("ctl00_ContentPlaceHolder1_GrdViewTimeSheet_ctl" + i + "_txtAmount");
                    getElementP = document.getElementById("ctl00_ContentPlaceHolder1_GrdViewTimeSheet_ctl" + i + "_txtParking");
                    getElementT = document.getElementById("ctl00_ContentPlaceHolder1_GrdViewTimeSheet_ctl" + i + "_txtToll");
                    getElementF = document.getElementById("ctl00_ContentPlaceHolder1_GrdViewTimeSheet_ctl0" + i + "_txtFuel");
                }
                TSum = parseFloat(TSum) + parseFloat(getElement.value) + parseFloat(getElementP.value) + parseFloat(getElementT.value) + parseFloat(getElementF.value);
            }

            sum.value = parseFloat(TSum)
        }
    </script>
    <Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </Ajax:ToolkitScriptManager>
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
                                            My TimeSheet
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
                                            Current week is
                                        </td>
                                        <td class="frm-lft-clr123" width="35%">
                                            <asp:Label ID="lblFromDate" runat="server"></asp:Label>
                                            &nbsp; To
                                            <asp:Label ID="lblToDate" runat="server"></asp:Label>
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
                                                Select a week to add Timesheet
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddl_week" runat="server" Width="172px" AutoPostBack="true"
                                                    OnSelectedIndexChanged="ddl_week_SelectedIndexChanged">
                                                </asp:DropDownList>
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
                        <tr>
                            <td>
                                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                    <tr>
                                        <td width="40%">
                                            <div runat="server" id="dv_status" visible="false">
                                                Status:<asp:Label runat="server" ID="lbl_status"></asp:Label>
                                            </div>
                                        </td>
                                        <td width="12%" align="center">
                                            <asp:Button ID="btnEdit" runat="server" CssClass="button" Text="Edit" OnClick="btnEdit_Click" />
                                        </td>
                                        <td width="12%" align="center">
                                            <asp:Button ID="btn_submit" runat="server" CssClass="button" Text="Submit" OnClick="btn_submit_Click" />
                                        </td>
                                    </tr>
                                </table>
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
                                </asp:GridView>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
