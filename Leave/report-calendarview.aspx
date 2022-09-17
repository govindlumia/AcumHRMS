<%@ Page Language="C#" AutoEventWireup="true" CodeFile="report-calendarview.aspx.cs" Inherits="Leave_report_calendarview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Leave Calendar View</title>
</head>
<body>
    <form id="form1" runat="server">
   <center>        
       <table>
                                <tr>
                                    <td>
                                        <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFFF" 
                                            BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" 
                                            Font-Size="10pt" ForeColor="#f21818" Height="470" ShowGridLines="True" Width="700px">                                                                                      
                                            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                            <OtherMonthDayStyle ForeColor="#CC9966" />
                                             <SelectedDayStyle BackColor="#e8b36f" Font-Bold="True" />
                                            <SelectorStyle BackColor="#e8b36f" />
                                            <TitleStyle BackColor="#e8b36f" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                            <TodayDayStyle BackColor="#e8b36f" ForeColor="White" />
                                           <%-- <SelectedDayStyle BackColor="#208cb5d1" Font-Bold="True" />
                                            <SelectorStyle BackColor="#208cb5d1" />
                                            <TitleStyle BackColor="#208cb5d1" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                            <TodayDayStyle BackColor="#208cb5d1" ForeColor="White" />--%>
                                        </asp:Calendar>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                       
                                    </td>
                                </tr>
                            </table>

        <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" AutoGenerateColumns="False">
                                            <Columns>
<%--                                                changed date to from date and to date by keerti dwivedi  on july 7 2018--%>
                                                <asp:BoundField DataField="fromdate" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField DataField="todate" HeaderText="To Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField DataField="reason" HeaderText="Description"  />
                                                 <asp:BoundField DataField="Name" HeaderText="Employee Name"  />
                                            </Columns>
                                              
                                            <FooterStyle BackColor="#CCCCCC" />
                                            <HeaderStyle BackColor="#e8b36f" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                            <RowStyle BackColor="White" />
                                              
                                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#808080" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#383838" />                                           
                                        </asp:GridView>
                      </center>
                  </form>
</body>
</html>
