<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PrintPDF.ascx.cs" Inherits="Appraisal_UserControl_PrintPDF" %>

<asp:Button runat="server" ID="btnPDF" Text="Print PDF" OnClick="btnPDF_Click" />
<script type="text/javascript" src="http://cdn.rawgit.com/niklasvh/html2canvas/master/dist/html2canvas.min.js"></script>
<script type="text/javascript">
    function ConvertToImage() {
        html2canvas($("#kraDiv")[0]).then(function (canvas) {
            var base64 = canvas.toDataURL();
            $("[id*=hfImageData]").val(base64);
            __doPostBack(btnPDF.name, "");
        });
        return false;
    }
</script>
<asp:HiddenField ID="hfImageData" runat="server" />


<div id="kraDiv" runat="server">
    <table style="width: 100%">
        <tr>
            <td style="148px; text-align:left;">
                <a href="#" style="border: 0">
                    <img runat="server" id="imagePath" src="http://103.16.140.21:9001/Images/Rossel-Techsys-Logo1(1).png" alt="Acuminous Software" />
                </a>
            </td>
        </tr>
        <tr>
            <td style="height: 1px; text-align: center">
                <h3>Acuminous Software </h3>
                <br />
                ( Division of Rossell India Ltd )<br />
                # 74,#rd Cross , Export Promotion Industrial Park , Whitefield, Bangalore -560066<br />
                Ph: 080-3999 9401, Fax: 3999 9400, e-mail: rossell@rosselltechsys.com

            </td>
        </tr>
        <tr>
            <td style="font: bold 11px verdana; color: #d17100;">Employee Information
            </td>
        </tr>
        <tr>
            <td>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 140px"><b>Employee Name</b>
                        </td>
                        <td style="width: 140px">
                            <asp:Label ID="lbl_emp_name" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td style="width: 140px"><b>Employee Code</b>
                        </td>
                        <td style="width: 140px">
                            <asp:Label ID="lbl_emp_code" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px"><b>Category</b>
                        </td>
                        <td style="width: 140px">
                            <asp:Label ID="lbl_department" runat="server" Text="Label"></asp:Label>

                        </td>
                        <td style="width: 140px"><b>Designation</b>
                        </td>
                        <td style="width: 140px">
                            <asp:Label ID="lbl_Designation" runat="server" Text="Label"></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px"><b>Date of Joining</b>
                        </td>
                        <td style="width: 140px">
                            <asp:Label ID="lbl_dated" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td style="width: 140px"><b>Review Period</b>
                        </td>
                        <td style="width: 140px">
                            <asp:Label runat="server" ID="lblPeriod" Text=""></asp:Label>
                            <asp:Label ID="lbl_Location" Visible="false" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 140px"><b>Current Experience</b>
                        </td>
                        <td style="width: 140px">
                            <asp:Label ID="lblExp" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td style="width: 140px"><b></b>
                        </td>
                        <td style="width: 140px">
                            
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdOverAllRating" runat="server" Font-Size="11px" Font-Names="Arial"
                    Width="100%" CellPadding="4" AutoGenerateColumns="False" OnRowDataBound="grdOverAllRating_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Performance Review">
                            <HeaderStyle Font-Bold="true" Font-Size="Small" HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <h3>
                                    <asp:Label ID="lblKRA" runat="server" Text='<%# Bind ("KRAHead") %>'></asp:Label>
                                    (<asp:Label ID="lblweightage" runat="server" Text='<%# UtilMethods.ConvertToDecimelUptoZero(Eval("Weightage")) %>'></asp:Label>)
                                </h3>

                                <asp:Label ID="lblKRAHeadID" runat="server" Visible="false" Text='<%# Bind ("KRAHeadID") %>'></asp:Label>
                                <asp:Label ID="lblKRAFormID" runat="server" Visible="false" Text='<%# Bind ("ID") %>'></asp:Label>

                                <asp:GridView ID="grdDetails2" CellPadding="4" runat="server" Font-Size="11px" Font-Names="Arial"
                                    Width="100%" AutoGenerateColumns="False" BorderWidth="0px" OnRowDataBound="grdDetails2_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="KRA" HeaderStyle-ForeColor="#013366">
                                            <HeaderStyle Width="45%" HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblKRASettingDetail" Visible="false" runat="server" Text='<%# Bind ("KRASettingDetailId") %>'></asp:Label>
                                                <asp:Label ID="txtKRA" Style="word-wrap: break-word;" runat="server" Text='<%# Bind ("KRA") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Weightage" HeaderStyle-ForeColor="#013366">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label8" runat="server" Text='<%# UtilMethods.ConvertToDecimelUptoZero(Eval("Weightage")) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Self Rating" HeaderStyle-ForeColor="#013366">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblSelfRating" runat="server" Text='<%# Bind ("SelfRating") %>'></asp:Label>
                                                <asp:HiddenField runat="server" ID="lblManagerRating" Value='<%# Bind ("ManagerRating") %>'></asp:HiddenField>
                                                <asp:Label ID="lblSelfComment" Visible="false" runat="server" Text='<%# Bind ("SelfComment") %>'></asp:Label>
                                                <asp:Label ID="lblManagerComment" Visible="false" runat="server" Text='<%# Bind ("ManagerComment") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Manager Rating" HeaderStyle-ForeColor="#013366">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label9" runat="server" Text='<%# Bind ("ManagerRating") %>'></asp:Label>
                                                <asp:Label ID="Label10" Visible="false" runat="server" Text='<%# Bind ("SelfComment") %>'></asp:Label>
                                                <asp:Label ID="Label23" Visible="false" runat="server" Text='<%# Bind ("ManagerComment") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Reviewer Rating" HeaderStyle-ForeColor="#013366">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblRR" runat="server" Text='<%# Bind ("ReviewerRating") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Final Rating" HeaderStyle-ForeColor="#013366">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblOverAllRating" runat="server" Text='<%# Bind ("ReviewerRating") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%-- <asp:TemplateField HeaderText="" HeaderStyle-ForeColor="#013366">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td width="20%"><b>Over All Rating Weighted Score:</b>
                <asp:Label runat="server" ID="lblScore" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="font: bold 11px verdana; color: #d17100;">Skills/Competencies</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdSkills" runat="server" AllowPaging="True" Width="100%" HorizontalAlign="Left"
                    CellPadding="2" CaptionAlign="Left" AutoGenerateColumns="False" BorderWidth="1px"
                    EmptyDataText="No Record(s) Found.."
                    BorderColor="#C9DFFB">
                    <Columns>
                        <%--<asp:TemplateField>
                            <HeaderTemplate>
                                <table style="width: 100%; border: 0px; border-collapse: collapse;">
                                    <tr>
                                        <td style="background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right: none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;" width="60%">Skills/Competencies</td>
                                        <td style="background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right: none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;" width="20%">Self Rating</td>
                                        <td style="background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right: none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;" width="20%">Manager's Rating</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table style="width: 100%; border: 0px; border-collapse: collapse;">
                                    <tr>
                                        <td style="background: #f8fbff; border: 1px solid #c9dffb; border-right: none; border-top: none; padding: 5px 0 5px 5px; font: normal 12px Arial, Helvetica, sans-serif; color: #013366;" width="30%">
                                            <asp:Label ID="lblSkills" Style="word-wrap: break-word;" runat="server" Text='<%# Bind("Skills") %>'></asp:Label>
                                        </td>
                                        <td style="background: #f8fbff; border: 1px solid #c9dffb; border-right: none; border-top: none; padding: 5px 0 5px 5px; font: normal 12px Arial, Helvetica, sans-serif; color: #013366;" width="20%">
                                            <asp:Label ID="lblSR" runat="server" Text='<%# Bind("SelfRating") %>'></asp:Label>
                                        </td>
                                        <td style="background: #f8fbff; border: 1px solid #c9dffb; border-right: none; border-top: none; padding: 5px 0 5px 5px; font: normal 12px Arial, Helvetica, sans-serif; color: #013366;" width="20%">
                                            <asp:Label ID="lblMR" runat="server" Text='<%# Bind("ManagerRating") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="Skills/Competencies" HeaderStyle-ForeColor="#013366">
                            <HeaderStyle Width="60%" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="l0" runat="server" Style="word-wrap: break-word;" Text='<%# Bind ("Skills") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Self Rating" HeaderStyle-ForeColor="#013366">
                            <HeaderStyle Width="20%" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="l0" runat="server" Text='<%# Bind ("SelfRating") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Manager's Rating" HeaderStyle-ForeColor="#013366">
                            <HeaderStyle Width="20%" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="l0" runat="server" Text='<%# Bind ("ManagerRating") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="font: bold 11px verdana; color: #d17100;">Training Attended </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdTrainingAttended" runat="server" Width="100%" HorizontalAlign="Left"
                    CellPadding="2" CaptionAlign="Left" AutoGenerateColumns="False"
                    BorderWidth="1px" EmptyDataText="No Record(s) Found.." BorderColor="#C9DFFB">
                    <Columns>
                        <%--<asp:TemplateField>
                            <HeaderTemplate>
                                <table style="width: 100%; border: 0px; border-collapse: collapse;">
                                    <tr>
                                        <td style="background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right: none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;" width="50%">Training</td>
                                        <td style="background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right: none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;" width="50%">Duration</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table style="width: 100%; border: 0px; border-collapse: collapse;">
                                    <tr>
                                        <td style="background: #f8fbff; border: 1px solid #c9dffb; border-right: none; border-top: none; padding: 5px 0 5px 5px; font: normal 12px Arial, Helvetica, sans-serif; color: #013366;" width="50%">
                                            
                                        </td>
                                        <td style="background: #f8fbff; border: 1px solid #c9dffb; border-right: none; border-top: none; padding: 5px 0 5px 5px; font: normal 12px Arial, Helvetica, sans-serif; color: #013366;" width="50%">
                                            
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="Training" HeaderStyle-ForeColor="#013366">
                            <HeaderStyle Width="50%" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("TrainingName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Duration" HeaderStyle-ForeColor="#013366">
                            <HeaderStyle Width="50%" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Duration") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="font: bold 11px verdana; color: #d17100;">Training Required - Employee </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdTrainingEmployee" runat="server" Width="100%" HorizontalAlign="Left"
                    CellPadding="2" CaptionAlign="Left" AutoGenerateColumns="False"
                    BorderWidth="1px" EmptyDataText="No Record(s) Found.." BorderColor="#C9DFFB">
                    <Columns>
                        <%--<asp:TemplateField>
                            <HeaderTemplate>
                                <table style="width: 100%; border: 0px; border-collapse: collapse;">
                                    <tr>
                                        <td style="background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right: none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;" width="50%">Training Type</td>
                                        <td style="background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right: none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;" width="50%">Training</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table style="width: 100%; border: 0px; border-collapse: collapse;">
                                    <tr>
                                        <td style="background: #f8fbff; border: 1px solid #c9dffb; border-right: none; border-top: none; padding: 5px 0 5px 5px; font: normal 12px Arial, Helvetica, sans-serif; color: #013366;" width="50%">
                                           
                                        </td>
                                        <td style="background: #f8fbff; border: 1px solid #c9dffb; border-right: none; border-top: none; padding: 5px 0 5px 5px; font: normal 12px Arial, Helvetica, sans-serif; color: #013366;" width="50%">
                                           
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="Training Type" HeaderStyle-ForeColor="#013366">
                            <HeaderStyle Width="50%" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("TrainingType") %>'></asp:Label>

                                <asp:Label ID="Label4" Visible="false" runat="server" Text='<%# Eval("TrainingTypeId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Training" HeaderStyle-ForeColor="#013366">
                            <HeaderStyle Width="50%" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("Training") %>'></asp:Label>
                                <asp:Label ID="Label6" runat="server" Visible="false" Text='<%# Eval("TrainingId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="font: bold 11px verdana; color: #d17100;">Training Required - Manager </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdTManager" runat="server" Width="100%" HorizontalAlign="Left"
                    CellPadding="2" CaptionAlign="Left" AutoGenerateColumns="False"
                    BorderWidth="1px" EmptyDataText="No Record(s) Found.." BorderColor="#C9DFFB">
                    <Columns>
                        <%--<asp:TemplateField>
                            <HeaderTemplate>
                                <table style="width: 100%; border: 0px; border-collapse: collapse;">
                                    <tr>
                                        <td style="background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right: none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;" width="50%">Training Type</td>
                                        <td style="background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right: none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;" width="50%">Training</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table style="width: 100%; border: 0px; border-collapse: collapse;">
                                    <tr>
                                        <td style="background: #f8fbff; border: 1px solid #c9dffb; border-right: none; border-top: none; padding: 5px 0 5px 5px; font: normal 12px Arial, Helvetica, sans-serif; color: #013366;" width="50%">
                                            
                                        </td>
                                        <td style="background: #f8fbff; border: 1px solid #c9dffb; border-right: none; border-top: none; padding: 5px 0 5px 5px; font: normal 12px Arial, Helvetica, sans-serif; color: #013366;" width="50%">
                                            
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="Training Type" HeaderStyle-ForeColor="#013366">
                            <HeaderStyle Width="50%" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="Label11" runat="server" Text='<%# Eval("TrainingType") %>'></asp:Label>

                                <asp:Label ID="Label16" Visible="false" runat="server" Text='<%# Eval("TrainingTypeId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Training" HeaderStyle-ForeColor="#013366">
                            <HeaderStyle Width="50%" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="Label17" runat="server" Text='<%# Eval("Training") %>'></asp:Label>
                                <asp:Label ID="Label18" runat="server" Visible="false" Text='<%# Eval("TrainingId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="font: bold 11px verdana; color: #d17100;">Training Required - Reviewer </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdTReviewer" runat="server" Width="100%" HorizontalAlign="Left"
                    CellPadding="2" CaptionAlign="Left" AutoGenerateColumns="False"
                    BorderWidth="1px" EmptyDataText="No Record(s) Found.." BorderColor="#C9DFFB">
                    <Columns>
                        <%-- <asp:TemplateField>
                            <HeaderTemplate>
                                <table style="width: 100%; border: 0px; border-collapse: collapse;">
                                    <tr>
                                        <td style="background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right: none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;" width="50%">Training Type</td>
                                        <td style="background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right: none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;" width="50%">Training</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table style="width: 100%; border: 0px; border-collapse: collapse;">
                                    <tr>
                                        <td style="background: #f8fbff; border: 1px solid #c9dffb; border-right: none; border-top: none; padding: 5px 0 5px 5px; font: normal 12px Arial, Helvetica, sans-serif; color: #013366;" width="50%"></td>
                                        <td style="background: #f8fbff; border: 1px solid #c9dffb; border-right: none; border-top: none; padding: 5px 0 5px 5px; font: normal 12px Arial, Helvetica, sans-serif; color: #013366;" width="50%"></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="Training Type" HeaderStyle-ForeColor="#013366">
                            <HeaderStyle Width="50%" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="Label19" runat="server" Text='<%# Eval("TrainingType") %>'></asp:Label>

                                <asp:Label ID="Label20" Visible="false" runat="server" Text='<%# Eval("TrainingTypeId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Training" HeaderStyle-ForeColor="#013366">
                            <HeaderStyle Width="50%" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="Label21" runat="server" Text='<%# Eval("Training") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="font: bold 11px verdana; color: #d17100;">Promotion and Future Direction  </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdPromotion" runat="server" Width="100%" HorizontalAlign="Left"
                    CellPadding="2" CaptionAlign="Left" AutoGenerateColumns="False"
                    BorderWidth="1px" EmptyDataText="No Record(s) Found.." BorderColor="#C9DFFB" OnRowDataBound="grdPromotion_RowDataBound">
                    <Columns>
                        <%--<asp:TemplateField>
                            <HeaderTemplate>
                                <table style="width: 100%; border: 0px; border-collapse: collapse;">
                                    <tr>
                                        <td style="background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right: none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;" width="10%">Status</td>
                                        <td style="background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right: none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;" width="25%">Post Appraisal Actions</td>
                                        <td style="background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right: none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;" width="5%"></td>
                                        <td style="background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right: none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;" width="60%">Comments</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table style="width: 100%; border: 0px; border-collapse: collapse;">
                                    <tr>
                                        <td style="background: #f8fbff; border: 1px solid #c9dffb; border-right: none; border-top: none; padding: 5px 0 5px 5px; font: normal 12px Arial, Helvetica, sans-serif; color: #013366;" width="10%">
                                            <asp:Label ID="Label25" runat="server" ToolTip='<%# Eval("Status") %>' Text='<%# Eval("Status") %>'></asp:Label>
                                        </td>
                                        <td style="background: #f8fbff; border: 1px solid #c9dffb; border-right: none; border-top: none; padding: 5px 0 5px 5px; font: normal 12px Arial, Helvetica, sans-serif; color: #013366;" width="25%">
                                            <asp:Label ID="Label7" runat="server" ToolTip='<%# Eval("Promotion") %>' Text='<%# Eval("Promotion") %>'></asp:Label>
                                        </td>
                                        <td style="background: #f8fbff; border: 1px solid #c9dffb; border-right: none; border-top: none; padding: 5px 0 5px 5px; font: normal 12px Arial, Helvetica, sans-serif; color: #013366;" width="5%">
                                            <asp:Label ID="Label32" runat="server" ToolTip='<%# Eval("Promoted") %>' Text='<%# Eval("Promoted") %>'></asp:Label>
                                        </td>
                                        <td style="background: #f8fbff; border: 1px solid #c9dffb; border-right: none; border-top: none; padding: 5px 0 5px 5px; font: normal 12px Arial, Helvetica, sans-serif; color: #013366;" width="60%">
                                            <asp:Label ID="Label27" runat="server" Text='<%# Eval("Comment") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="Status" HeaderStyle-ForeColor="#013366">
                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="Label25" runat="server" Style="word-wrap: break-word;" Text='<%# Bind ("Status") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Post Appraisal Actions" HeaderStyle-ForeColor="#013366">
                            <HeaderStyle Width="25%" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind ("Promotion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" HeaderStyle-ForeColor="#013366">
                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="Label32" runat="server" Text='<%# Bind ("Promoted") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Comments" HeaderStyle-ForeColor="#013366">
                            <HeaderStyle Width="60%" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="Label27" Style="word-wrap: break-word;" runat="server" Text='<%# Bind ("Comment") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="font: bold 11px verdana; color: #d17100;">Comments History
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdHistory" runat="server" Width="100%" HorizontalAlign="Left"
                    CellPadding="2" CaptionAlign="Left" AutoGenerateColumns="False"
                    BorderWidth="1px"
                    EmptyDataText="No Record(s) Found.."
                    BorderColor="#c9dffb">
                    <Columns>
                        <%--<asp:TemplateField>
                            <HeaderTemplate>
                                <table style="width: 100%; border: 0px; border-collapse: collapse;">
                                    <tr>
                                        <td style="background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right: none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;" width="30%">Status</td>
                                        <td style="background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right: none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;" width="70%">Comments</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table style="width: 100%; border: 0px; border-collapse: collapse;">
                                    <tr>
                                        <td style="background: #f8fbff; border: 1px solid #c9dffb; border-right: none; border-top: none; padding: 5px 0 5px 5px; font: normal 12px Arial, Helvetica, sans-serif; color: #013366;" width="30%">
                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                        </td>
                                        <td style="background: #f8fbff; border: 1px solid #c9dffb; border-right: none; border-top: none; padding: 5px 0 5px 5px; font: normal 12px Arial, Helvetica, sans-serif; color: #013366;" width="70%">
                                            <asp:Label ID="lblDuration" runat="server" Text='<%# Eval("Comment") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="Status" HeaderStyle-ForeColor="#013366">
                            <HeaderStyle Width="30%" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# Bind ("Status") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Comments" HeaderStyle-ForeColor="#013366">
                            <HeaderStyle Width="70%" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblDuration" runat="server" Style="word-wrap: break-word;" Text='<%# Bind ("Comment") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
            </td>
        </tr>
    </table>
</div>
<div style="display: none;">
    <table>
        <tr>
            <td>
                <table style="width: 100%; border: 0px;">
                    <tr>
                        <td>
                            <table width="100%" runat="server">
                                <tr>
                                    <td style="font: bold 11px verdana; color: #d17100;">Training Comments History
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="grdTComments" runat="server" Width="100%" HorizontalAlign="Left"
                                            CellPadding="2" CaptionAlign="Left" AutoGenerateColumns="False"
                                            BorderWidth="1px"
                                            EmptyDataText="No Record(s) Found.."
                                            BorderColor="#c9dffb">
                                            <%-- <PagerSettings PageButtonCount="100"></PagerSettings>--%>
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <table style="width: 100%; border: 0px;">
                                                            <tr>
                                                                <td style="background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right: none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;" width="30%">Status</td>
                                                                <td style="background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right: none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;" width="70%">Comments</td>
                                                            </tr>
                                                        </table>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <table style="width: 100%; border: 0px;">
                                                            <tr>
                                                                <td style="background: #f8fbff; border: 1px solid #c9dffb; border-right: none; border-top: none; padding: 5px 0 5px 5px; font: normal 12px Arial, Helvetica, sans-serif; color: #013366;" width="30%">
                                                                    <asp:Label ID="Label12" runat="server" Text='<%# Eval("RecommendedBy") %>'></asp:Label>
                                                                </td>
                                                                <td style="background: #f8fbff; border: 1px solid #c9dffb; border-right: none; border-top: none; padding: 5px 0 5px 5px; font: normal 12px Arial, Helvetica, sans-serif; color: #013366;" width="70%">
                                                                    <asp:Label ID="Label13" runat="server" Text='<%# Eval("TrainingDesc") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table style="width: 100%; border: 0px;">
                    <tr>
                        <td>
                            <table width="100%" runat="server">
                                <tr>
                                    <td style="font: bold 11px verdana; color: #d17100;">KRA Comments History
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="grdKCommentsHistory" runat="server" Width="100%" HorizontalAlign="Left"
                                            CellPadding="2" CaptionAlign="Left" AutoGenerateColumns="False"
                                            BorderWidth="1px"
                                            EmptyDataText="No Record(s) Found.."
                                            BorderColor="#c9dffb">
                                            <%-- <PagerSettings PageButtonCount="100"></PagerSettings>--%>
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <table style="width: 100%; border: 0px;">
                                                            <tr>
                                                                <td style="background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right: none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;" width="15%">Status</td>
                                                                <td style="background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right: none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;" width="30%">KRA</td>
                                                                <td style="background: #edf5ff; padding: 4px 0 4px 5px; border: 1px solid #c9dffb; border-right: none; font: bold 11px verdana, Helvetica, sans-serif; color: #013366;" width="55%">Comments</td>
                                                            </tr>
                                                        </table>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <table style="width: 100%; border: 0px;">
                                                            <tr>
                                                                <td style="background: #f8fbff; border: 1px solid #c9dffb; border-right: none; border-top: none; padding: 5px 0 5px 5px; font: normal 12px Arial, Helvetica, sans-serif; color: #013366;" width="15%">
                                                                    <asp:Label ID="Label14" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                                </td>
                                                                <td style="background: #f8fbff; border: 1px solid #c9dffb; border-right: none; border-top: none; padding: 5px 0 5px 5px; font: normal 12px Arial, Helvetica, sans-serif; color: #013366;" width="30%">
                                                                    <asp:Label ID="Label24" runat="server" Text='<%# Eval("KRA") %>'></asp:Label>
                                                                </td>
                                                                <td style="background: #f8fbff; border: 1px solid #c9dffb; border-right: none; border-top: none; padding: 5px 0 5px 5px; font: normal 12px Arial, Helvetica, sans-serif; color: #013366;" width="55%">
                                                                    <asp:Label ID="Label15" runat="server" Text='<%# Eval("Comment") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
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
</div>

