<%@ Page Title="" Language="C#" MasterPageFile="~/Recruitment/User/RecruitmentMaster.master" AutoEventWireup="true" CodeFile="InterviewReschedule.aspx.cs" Inherits="Recruitment_User_InterviewReschedule" %>

 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </Ajax:ToolkitScriptManager>
<div id="Vac_Info" runat="server">
 <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
 <tr>
 <td colspan="4" align="left">
 <span class="txt02" style="float: left">Candidate Interview Rechedule</span>
 </td>
 </tr>
 <tr>
            <td height="5" colspan="4">
            </td>
        </tr>
          <tr>
            <td width="20%" class="frm-lft-clr123">
                Candidate_Id
            </td>
            <td width="30%" class="frm-rght-clr123">
                <asp:Label ID="lblCanId" runat="server"></asp:Label>
            </td>
            <td width="20%" class="frm-lft-clr123">
              Interview_Date 
            </td>
           <td class="frm-rght-clr123">
                <asp:TextBox ID="txt_reqdate" runat="server" CssClass="blue1" Width="122px"></asp:TextBox>

                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Calender/images/calendar_icon.gif" ToolTip="click to open calender" />
               <asp:RequiredFieldValidator
                                                                                ID="RequiredFieldValidator18" runat="server" ControlToValidate="txt_reqdate" Display="Dynamic"
                                                                                ErrorMessage="Enter Date of Required" SetFocusOnError="True" ToolTip="Enter Date of Required"
                                                                                ValidationGroup="v" Width="6px">
                                                                            <img src="../../images/error1.gif" alt="" />
                                                                            </asp:RequiredFieldValidator>
               
          <Ajax:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1" Format="dd-MMM-yyyy"
                                                                            TargetControlID="txt_reqdate">
                                                                        </Ajax:CalendarExtender>
 
            </td>
        </tr>
         <tr>
            <td width="10%" class="frm-lft-clr123">
               Interview Time
            </td>
            <td width="35%">
            Hr
                <asp:DropDownList ID="ddlHtime" runat="server" OnDataBound="ddlHtime_BoundHour"></asp:DropDownList>
                 Min
                <asp:DropDownList ID="ddlMtime" runat="server" OnDataBound="ddlMtime_BoundHour"></asp:DropDownList>
                <asp:RadioButton ID="rdo1" runat ="server" GroupName="Software" Text="AM" OnCheckedChanged="RadioButton_ChackedChange" AutoPostBack="true"  />
                 <asp:RadioButton ID="rdo2" runat ="server" GroupName="Software" Text="PM" OnCheckedChanged="RadioButton_ChackedChange"  AutoPostBack ="true" Checked="true"/>
                       <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlHtime"
                    Display="Dynamic" ErrorMessage="Select Hour." ToolTip="Select Hour"
                    ValidationGroup="v" Width="6px" SetFocusOnError="True" InitialValue="-1">
                      
<img src="../../images/error1.gif" alt="" />
</asp:RequiredFieldValidator>
  <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlMtime"
                    Display="Dynamic" ErrorMessage="Select Minute" ToolTip="Select Minute"
                    ValidationGroup="v" Width="6px" SetFocusOnError="True" InitialValue="-1">
                    <img src="../../images/error1.gif" alt="" />
</asp:RequiredFieldValidator>

            </td>
            <td class="frm-rght-clr123"></td>
           <td class="frm-rght-clr123"></td>
        </tr>
     <tr>
      <td width="20%" class="frm-lft-clr123">
                InterViewer
            </td>
            <td width="30%" class="frm-rght-clr123">
               <asp:DropDownList ID="ddlInterviewer" Width="142px" runat="server" OnDataBound="ddlInterviewer_databound"></asp:DropDownList>
             <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlInterviewer"
                    Display="Dynamic" ErrorMessage="Select Interviewer" ToolTip="Select Interviewer"
                    ValidationGroup="v" Width="6px" SetFocusOnError="True" InitialValue="0">
                    <img src="../../images/error1.gif" alt="" />
</asp:RequiredFieldValidator>
            </td>
     <td width="20%" class="frm-lft-clr123">
     </td>
     <td width="30%" class="frm-rght-clr123"></td>
     </tr>
       
      
        <tr>
            <td width="20%" class="frm-lft-clr123">
              
            </td>
            
            <td width="30%" class="frm-rght-clr123">
             <asp:Button ID="btnSelect" runat="server" Text="Submit" CssClass="button" 
                    onclick="btnSelect_Click" ValidationGroup="v" />
              
            </td>
            <td width="20%" class="frm-lft-clr123">
                
            </td>
            <td width="30%" class="frm-rght-clr123">
               <asp:Label ID="lblrdo" runat="server" Text="" Visible="false"></asp:Label>
               <asp:Label ID="lbldate" runat="server" Text="" Visible="false"></asp:Label>
            </td>
        </tr>
     

 </table>

</div>
 <asp:ValidationSummary ID="ValidationSummary6" ShowMessageBox="True" ShowSummary="False"
        runat="server" ValidationGroup="v"></asp:ValidationSummary>
</asp:Content>
