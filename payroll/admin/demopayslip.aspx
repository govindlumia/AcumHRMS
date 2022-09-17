<%@ Page Language="C#" AutoEventWireup="true" CodeFile="demopayslip.aspx.cs" Inherits="payroll_admin_demopayslip" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <style type="text/css">
        
        @page { size: landscape; }
         .auto-style1 {
             width: 70%;
             height: 28px;
         }
         .auto-style2 {
             width: 30%;
             height: 28px;
         }
    </style>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:70%;margin:auto;border:1px groove black;" >
      <div style="width:100%" >
       <div style="width:10%;float:left;height:60px;padding-left:2px;padding-top:2px" >
           <img src="http://localhost:61314/upload/Logo/logopayslip.png" style="height:93px" />
       </div>
       <div style="width:89%;float:right;height:60px" >
           <center>
               <p style="font-size: 40px;color: #04aeae;margin-top:5px">
                    Acuminous Software
               </p>
                <p style="font-size: 13px;font-family: calibri;margin-top: -45px;color:rgb(75, 96, 95)">
                    (Division of Rossell India Ltd)<br />
                    <span style="color:black;font-size:14px" >
                    #74, 3rd Cross, Export Promotion Industrial Park, Whitefield, Banglore-560066<br />
                    Ph: 080-3999 9401, Fax: 3999 9400, Email: rossell@rosselltechsys.com</span>
               </p>
           </center>         
       </div>
      </div>
        <div style="width: 100%; height: 40px; border-top-style: groove; border-top-width: 1px; border-top-color: black; border-bottom-style: groove; border-bottom-width: 1px; border-bottom-color: black; margin-top: 100px; font-family: calibri; font-weight: bold; font-size: 20px">
            <div style="float: left; width: 49%">
                Pay slip for the month of 
            </div>
            <div style="float: right; width: 49%">
                <asp:Label ID="lbl_month" runat="server" Text=""></asp:Label>
                -
                  <asp:Label ID="lbl_year" runat="server" Text=""></asp:Label>
            </div>
            </div>
            <div >
             <div style="float: left; width: 60.10%; border-right-style: groove; border-right-width: 1px; border-right-color: black;">
                <table style="width: 100%; font-family: calibri; font-weight: normal; font-size: 13px">
                    <tr>
                        <td style="width: 33%">Employee Name
                        </td>
                        <td style="width: 33%">
                            <asp:Label ID="lbl_empname" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="width: 33%"></td>
                    </tr>
                    <tr>
                        <td style="width: 33%">Employee No
                        </td>
                        <td style="width: 33%">
                            <asp:Label ID="lbl_empcode" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="width: 33%"></td>
                    </tr>
                    <tr>
                        <td style="width: 33%">Designation
                        </td>
                        <td style="width: 33%">
                            <asp:Label ID="lbl_desg" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="width: 33%"></td>
                    </tr>

                    <tr>
                        <td style="width: 33%">D.O.J
                        </td>
                        <td style="width: 33%">
                            <asp:Label ID="lbldoj" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="width: 33%"></td>
                    </tr>
                    <tr>
                        <td style="width: 33%">PF NO. / UAN 
                        </td>
                        <td style="width: 33%">
                            <asp:Label ID="lblPF" runat="server" Text=""></asp:Label>
                            /
                            <asp:Label ID="lblUAN" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="width: 33%"></td>
                    </tr>
                    <tr>
                        <td style="width: 33%">Esi No
                        </td>
                        <td style="width: 33%">
                            <asp:Label ID="lblESI" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="width: 33%"></td>
                    </tr>
                    <tr>
                        <td style="width: 33%">PAN
                        </td>
                        <td style="width: 33%">
                            <asp:Label ID="lblPAN" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="width: 33%"></td>
                    </tr>
                    <tr>
                        <td style="width: 33%">Category / Function
                        </td>
                        <td style="width: 33%">
                            <asp:Label ID="lblCategory" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="width: 33%">DMX
                        </td>
                    </tr>
                </table>
            </div>
            <div style="float: right; width: 39.60%;">
                <table style="width: 100%; font-family: calibri; font-weight: normal; font-size: 13px">
                    <tr>
                        <td style="width: 50%">Total Working Days
                        </td>
                        <td style="width: 50%" align="right">
                            <asp:Label ID="lblworkingdays" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50%">No. of Holidays
                        </td>
                        <td style="width: 50%" align="right">
                            <asp:Label ID="lblHolidays" runat="server" Text=""></asp:Label>
                        </td>

                    </tr>
                    <tr>
                        <td style="width: 50%">No. of Working Days
                        </td>
                        <td style="width: 50%" align="right">
                            <asp:Label ID="lblDays" runat="server" Text=""></asp:Label>
                        </td>

                    </tr>
                    <tr>
                        <td style="width: 50%">No of Days Worked
                        </td>
                        <td style="width: 50%" align="right">
                            <asp:Label ID="lblDayWorked" runat="server" Text=""></asp:Label>
                        </td>

                    </tr>
                    <tr>
                        <td style="width: 50%">Leave Taken
                        </td>
                        <td style="width: 50%" align="right">
                            <asp:Label ID="lblLeaveTaken" runat="server" Text=""></asp:Label>
                        </td>

                    </tr>
                    <tr>
                        <td style="width: 50%">Absent(LOP)
                        </td>
                        <td style="width: 50%" align="right">
                            <asp:Label ID="lbllwp" runat="server" Text=""></asp:Label>
                        </td>

                    </tr>
                    <tr>
                        <td style="width: 50%">Bank A/C No.
                        </td>
                        <td style="width: 50%" align="right">
                            <asp:Label ID="lblacno" runat="server" Text=""></asp:Label>
                        </td>

                    </tr>
                    <tr>
                        <td style="width: 50%">Bank Name
                        </td>
                        <td style="width: 50%" align="right">
                            <asp:Label ID="lbl_bank_details" runat="server" Text=""></asp:Label>
                        </td>

                    </tr>
                </table>
            </div>
        </div>  
        <div style="width:100%;font-family: calibri;font-weight:bold;font-size:25px;" >
                  <table cellspacing="0" style="width:100%;font-family: calibri;font-weight:normal;font-size:13px; border-top-style: groove; border-top-width: 1px; border-top-color: #000000;" >
                   <tr>
                       <th style="width:60.20%;font-size:15px; background-color: #CCCCCC; border-right-style: groove; border-right-width: 1px; border-right-color: black;" align="center" >
                         Salary Structure
                       </th>
                       <th style="width:20%;font-size:15px;background-color: #CCCCCC;; border-right-style: groove; border-right-width: 1px; border-right-color: black;" align="center">
                          Amount
                       </th>
                       <th style="width:20%;font-size:15px;background-color: #CCCCCC;" align="center">
                           Amount
                       </th>
                   </tr>
                         <tr>
                       <td style="width:60.20%; border-right-style: groove; border-right-width: 1px; border-right-color: black;" align="left" >
                         Basic
                       </td>
                       <td style="width:20%; border-right-style: groove; border-right-width: 1px; border-right-color: black;" align="right">
                          
                       </td>
                       <td style="width:20%" align="right">
                           <asp:Label ID="lblbasic" runat="server" Text=""></asp:Label>
                       </td>
                   </tr>
                        <tr>
                       <td style="width:60.20%; border-right-style: groove; border-right-width: 1px; border-right-color: black;" align="left" >
                         House Rent Allowance
                       </td>
                       <td style="width:20%; border-right-style: groove; border-right-width: 1px; border-right-color: black;" align="right">
                         
                       </td>
                       <td style="width:20%" align="right">
                       <asp:Label ID="Lblhra" runat="server" Text=""></asp:Label>
                       </td>
                   </tr>
                        <tr>
                       <td style="width:60.20%; border-right-style: groove; border-right-width: 1px; border-right-color: black;" align="left" >
                        Conveyance Allownace
                       </td>
                       <td style="width:20%; border-right-style: groove; border-right-width: 1px; border-right-color: black;" align="right">
                          
                       </td>
                       <td style="width:20%" align="right">
                         <asp:Label ID="Lblconvynceallowance" runat="server" Text=""></asp:Label>
                       </td>
                   </tr>
                        <tr>
                       <td style="width:60.20%; border-right-style: groove; border-right-width: 1px; border-right-color: black;" align="left" >
                         Special Allowance
                       </td>
                       <td style="width:20%; border-right-style: groove; border-right-width: 1px; border-right-color: black;" align="right">
                          
                       </td>
                       <td style="width:20%" align="right">
                        <asp:Label ID="lblspclallownace" runat="server" Text=""></asp:Label>
                       </td>
                   </tr>
                        <tr>
                       <th style="width:60.20%; border-right-style: groove; border-right-width: 1px; border-right-color: black;background-color: #CCCCCC;" align="right" >
                       Sub Total
                       </th>
                       <td style="width:20%; border-right-style: groove; border-right-width: 1px; border-right-color: black;background-color: #CCCCCC;" align="right">
                          
                       </td>
                       <th style="width:20%;background-color: #CCCCCC;" align="right">
                          <asp:Label ID="lblsubtotal" runat="server" Text=""></asp:Label>
                       </th>
                   </tr>
                        <tr>
                       <td style="width:60.20%; border-right-style: groove; border-right-width: 1px; border-right-color: black;" align="left" >
                         PF Employer's Share
                       </td>
                       <td style="width:20%; border-right-style: groove; border-right-width: 1px; border-right-color: black;" align="right">
                         <asp:Label ID="lblpfund" runat="server" Text=""></asp:Label>
                       </td>
                       <td style="width:20%" align="right">
                           
                       </td>
                   </tr>
                        <tr>
                       <td style="width:60.20%; border-right-style: groove; border-right-width: 1px; border-right-color: black;" align="left" >
                         ESI Employer's Share
                       </td>
                       <td style="width:20%; border-right-style: groove; border-right-width: 1px; border-right-color: black;" align="right">
                           <asp:Label ID="Lblesifund" runat="server" Text=""></asp:Label>  
                       </td>
                       <td style="width:20%" align="right">
                         
                       </td>
                   </tr>
                        <tr>
                       <td style="width:60.20%; border-right-style: groove; border-right-width: 1px; border-right-color: black;" align="left" >
                         Medical Reimbursement
                       </td>
                       <td style="width:20%; border-right-style: groove; border-right-width: 1px; border-right-color: black;" align="right">
                         <asp:Label ID="Lblmedicalallowance" runat="server" Text=""></asp:Label> 
                       </td>
                       <td style="width:20%" align="right">
                           
                       </td>
                   </tr>
                        <tr>
                       <td style="width:60.20%; border-right-style: groove; border-right-width: 1px; border-right-color: black;" align="left" >
                         Transportation Facility
                       </td>
                       <td style="width:20%; border-right-style: groove; border-right-width: 1px; border-right-color: black;" align="right">
                            <asp:Label ID="lbltransportfacility" runat="server" Text=""></asp:Label> 
                       </td>
                       <td style="width:20%" align="right">
                           
                       </td>
                   </tr>
                        <tr>
                       <td style="width:60.20%; border-right-style: groove; border-right-width: 1px; border-right-color: black;" align="left" >
                         Other incentives
                       </td>
                       <td style="width:20%; border-right-style: groove; border-right-width: 1px; border-right-color: black;" align="right">
                          
                       </td>
                       <td style="width:20%" align="right">
                           <asp:Label ID="Lblotherincentives" runat="server" Text=""></asp:Label>
                       </td>
                   </tr>
                        <tr>
                       <th style="width:60.20%; border-right-style: groove;background-color: #CCCCCC; border-right-width: 1px; border-right-color: black;" align="right" >
                         Total CTC PM
                       </th>
                       <td style="width:20%; border-right-style: groove;background-color: #CCCCCC; border-right-width: 1px; border-right-color: black;" align="right">
                          
                       </td>
                       <th style="width:20%;background-color: #CCCCCC;" align="right">
                         <asp:Label ID="lblCTC" runat="server" Text=""></asp:Label>
                       </th>
                   </tr>
                  </table>
              </div>
        <div style="width:100%;height:25px; border-top-style: groove; border-top-width: 1px; border-top-color: black; border-bottom-style: groove; border-bottom-width: 1px; border-bottom-color: black;font-family: calibri;font-weight:bold;font-size:13px" >
              <div style="float:left;width:80%" >
                  Month's Net Earning's
              </div>
              <div style="float:right;width:12%" >
                  <table style="width:100%" >
                      <tr>
                          <td style="width:100%" align="right" >
                            <asp:Label ID="lblnetearnings" runat="server" Text=""></asp:Label>
                          </td>
                      </tr>
                  </table>
                 
              </div>
             </div>
        <div>
              <div style="float:left;width:50%; border-right-style: groove; border-right-width: 1px; border-right-color: black;margin-top:0px;" >
                  <table cellspacing="0" style="width:100%;font-family: calibri;font-weight:normal;font-size:13px;height:100px" >
                   <tr>
                       <td colspan="2" >
                                                           <asp:GridView ID="earning_grid" runat="server" 
                                                            CellSpacing="0" CellPadding="4" DataKeyNames="id" Width="100%" AutoGenerateColumns="False"
                                                           AllowPaging="False" PageSize="5" EmptyDataText="No such employee exists !">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Earnings">
                                                                    <HeaderStyle  Height="20px" HorizontalAlign="left" />
                                                                    <ItemStyle HorizontalAlign="Left" CssClass="line-left" BorderWidth="1"
                                                                        VerticalAlign="Top" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("payhead") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Amount">
                                                                    <HeaderStyle Width="17%"  HorizontalAlign="center" />
                                                                    <ItemStyle HorizontalAlign="Right" CssClass="line-right"  BorderWidth="1"
                                                                        VerticalAlign="Top" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind("amount")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <RowStyle Height="5px" />
                                                        </asp:GridView>
                       </td>
                   </tr>
                      <tr>
                     <td style="width:83%;"  class="line-right"  >
                         <strong>Total Earnings</strong>
                     </td>
                     <td style="width:17%;" align="right">
                         <asp:Label ID="lbl_total_earning" runat="server" Font-Bold="True"></asp:Label>
                     </td>
                    </tr> 
                  </table>
              </div>
              <div style="float:right;width:49.80%;margin-top:-1px ;" >
                 <table style="width:100%;font-family: calibri;font-weight:normal;font-size:13px;height:100px" cellspacing="0" >
                    <tr>
                        <td colspan="2" style="padding:2px"  >
                            <asp:GridView ID="deduction_grid" runat="server" 
                                                            CellSpacing="0" CellPadding="4" DataKeyNames="id" Width="100%" AutoGenerateColumns="False"
                                                            BorderWidth="1px" AllowPaging="False" PageSize="5" EmptyDataText="No deduction !">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Deductions">
                                                                    <HeaderStyle  Height="20px" HorizontalAlign="left" />
                                                                    <ItemStyle HorizontalAlign="Left" CssClass="line-left" 
                                                                        VerticalAlign="Top" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("payhead") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Amount">
                                                                    <HeaderStyle Width="17%" HorizontalAlign="center" />
                                                                    <ItemStyle HorizontalAlign="Right" CssClass="line-right" 
                                                                        VerticalAlign="Top" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("amount") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <RowStyle Height="5px" />
                                                        </asp:GridView>
                        </td>
                    </tr>
                        <tr>
                        <td style="width:83%"  class="line-left">
                           <strong>Total Deductions</strong> 
                        </td>
                        <td style="width:17%"  class="line-right" align="right">
                            <asp:Label ID="lbl_total_deductions" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                       </tr>
                  </table>
              </div>
              
           </div>
       
         <div style="width:100%;  border-bottom-style: groove; border-bottom-width: 1px; border-bottom-color: black;font-family: calibri;font-weight:bold;font-size:25px;" >
              <div style="height:7px" ></div>
             <table cellspacing="0" style="width:100%;font-family: calibri;font-weight:normal;font-size:13px;border-top-style: groove; border-top-width: 1px; border-top-color: #000000;" >
                    <tr>
                        <td style="border-right: 1px groove black;border-bottom-style: groove; border-bottom-width: 1px; border-bottom-color: black;width:80%" align="right"  >
                           <strong>Net Amount</strong>
                        </td>
                        <td align="right" style="border-bottom-style: groove; border-bottom-width: 1px; border-bottom-color: black"  >
                        <asp:Label ID="lbl_amount" Font-Bold="true" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                  <tr>
                      <td colspan="2" >
                        <div id="reimdiv" runat="server" >
                        <table style="width:100%;display:none" border="1"  >
                            <tr>
                                <td colspan="2" >
                                <asp:GridView ID="reimbursement_grid" runat="server" 
                                CellSpacing="0" CellPadding="4" DataKeyNames="id" Width="100%" AutoGenerateColumns="False"
                                BorderWidth="0px" AllowPaging="False" PageSize="5" EmptyDataText="No Reimbursement Exists !">
                                <Columns>
                                    <asp:TemplateField HeaderText="Reimbursement">
                                        <HeaderStyle CssClass="line-left" Height="20px" HorizontalAlign="left" />
                                        <ItemStyle HorizontalAlign="Left" CssClass="line-left"
                                            VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("payhead") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount (Rs.)">
                                        <HeaderStyle Width="17%" CssClass="line-right" HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="Right" CssClass="line-right" 
                                            VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:Label ID="l3" runat="server" Text='<%# Bind("amount")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle Height="5px" />
                                </asp:GridView>
                                </td>
                            </tr>
                          <tr>
                        <td style="width:100%;border-right-style: groove; border-right-width: 1px; border-right-color: black;" align="right" colspan="2" >
                      <strong>Total Reimbursement&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_reimbursement" runat="server" Font-Bold="true" Text=""></asp:Label> </strong> 
                        </td>
                        </tr> 
                        </table>
                        </div>  
                      </td>

                  </tr>
                
                   <tr>
                        <td align="right" colspan="2" >
                      <table width="100%"  cellspacing="0" border="1" style="display:none" >
                                                <tr>
                                                    
                                                    <td  align="right" style="display:none;width:40%" >
                                                      Total Deduction&nbsp;&nbsp;&nbsp; <asp:Label ID="lbl_tot_deduction" runat="server" Text=""></asp:Label>
                                                    </td>
                                                     <td align="right" style="width:30%;display:none">
                                                     <strong>Total Reimbursement</strong>&nbsp;&nbsp;&nbsp; <asp:Label ID="lbl_tot_reimbursement" runat="server" Text="" Font-Bold="true" ></asp:Label>
                                                    </td>
                                                    <td align="right" style="width:30%" >
                                                      <strong>Grand Total</strong>&nbsp;&nbsp;&nbsp; <asp:Label  ID="lbl_tot_grandtotal" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                    </td>
                                                   
                                                </tr>
                                            </table>
                        </td>
                    </tr>
                  </table>
             </div>      
    </div>
          <div style="color:black;font-family:Calibri;font-size:13px;position:inherit;width:70%;margin:auto;" >
            <table style="width:100%"  >
                <tr>
                <td style="width:100%" align="left" >
              <strong>Note: It is computer generated pay slip and the signature is not required</strong>
                </td>
                </tr>
                  <tr>
                <td style="height: 20px;display:none"  colspan="2" >
                </td>
            </tr>
            </table>
        </div>
    </form>
</body>
</html>