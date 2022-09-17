<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editemployeeprofile.aspx.cs" Inherits="Leave_admin_createemployeeprofile" Title="Leave Approver" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Untitled Document</title>
<style type="text/css" media="all">
@import "../css/blue1.css";
</style>

</head>
<body>
    <form id="form1" runat="server">

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td width="3%"><img src="../images/employee-icon.jpg" width="16" height="16" /></td>
        <td class="txt01">Employee Leave Profile</td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td height="5" valign="top" align="right" class="txt-red"><span id="message" runat="server"></span>&nbsp;</td>
  </tr>
  <tr>
    <td height="20" valign="top" class="txt02">&nbsp;Edit Employee Profile</td>
  </tr>
  <tr>
    <td height="10" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="19%" class="frm-lft-clr123">
            Employee Code</td>
        <td class="frm-rght-clr123"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td style="height: 20px; width: 29%;">
                &nbsp;<asp:Label ID="lbl_empcode" runat="server"></asp:Label></td>
            <td width="88px" style="height: 20px">
                </td>
          </tr>
        </table></td>
      </tr>
    </table></td>
  </tr>
  <tr>
  <tr>
    <td height="10" valign="top">&nbsp;</td>
  </tr>
  <tr>
    <td height="20" valign="top" class="txt02">&nbsp;Add Approver</td>
  </tr>
  <tr>
    <td height="10" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="19%" class="frm-lft-clr123">Approver Name </td>
        <td class="frm-rght-clr123"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="30%" style="height: 28px">
                <asp:TextBox ID="txt_approver" runat="server" CssClass="input"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                    ValidationGroup="app" ControlToValidate="txt_approver"></asp:RequiredFieldValidator></td>
            <td width="60%" style="height: 28px">
                &nbsp;<a href="JavaScript:newPopup5('pickapprover.aspx,'height=700,width=750,left=200,top=20,resizable=yes,scrollbars=yes,toolbar=no,menubar=no,location=no,directories=no,status=no');" class="link05">Pick Approver</a></td>
            <td width="10%" style="height: 28px" align="right">
                <asp:Button ID="btn_add" runat="server" CssClass="button" Text="Add" OnClick="Button2_Click" ValidationGroup="app" /></td>
          </tr>
        </table></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td valign="top" style="height: 10px">&nbsp;</td>
  </tr>
  <tr>
    <td valign="top" class="head-2" style="height: 10px">
    
    
    
    
    <table width="100%" border="0" cellspacing="0" cellpadding="4">
     
     
   <tr>
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td height="20" valign="top" class="txt02">Approval Level
                  <asp:Button ID="btn_resetgrid" runat="server" CssClass="button" Text="Reset Grid" OnClick="btn_greset_Click" /></td>
            </tr>
            <tr>
              <td class="head-2" style="height: 292" valign="top" >
              
              
              
                  <asp:GridView ID="approvalgrid" runat="server" Font-Size="11px" Font-Names="Arial" CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px"  EmptyDataText="No record found">
                   <Columns>
                   <asp:TemplateField HeaderText="Emp Code">
                   <HeaderStyle CssClass="frm-lft-clr123"/>                  
                   <ItemStyle Width="24%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                  
                  <asp:Label ID="Label1" runat="server" Text ='<%# Bind ("empcode") %>'></asp:Label>
                  </ItemTemplate>
                   </asp:TemplateField>
                  
                  
                   <asp:TemplateField HeaderText="Approver Name">
                   <HeaderStyle CssClass="frm-lft-clr123"/>                  
                   <ItemStyle Width="24%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                  
                  <asp:Label ID="l2" runat="server" Text ='<%# Bind ("name") %>'></asp:Label>
                  </ItemTemplate>
                   </asp:TemplateField>
                   
                                  
                   <asp:TemplateField HeaderText="Level">
                   <HeaderStyle CssClass="frm-lft-clr123"/>                  
                   <ItemStyle Width="24%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                  
                  <asp:Label ID="l1" runat="server" Text ='<%# Bind ("level") %>'></asp:Label>
                  
                  </ItemTemplate>
                   </asp:TemplateField>
                   </Columns> 
                      <HeaderStyle CssClass="frm-lft-clr123" />
                      <FooterStyle CssClass="frm-lft-clr123" />
                      <RowStyle Height="5px" />
                  
                  
                  </asp:GridView></td>
            </tr>
        </table></td>
        
      </tr>
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
    
    </table><table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td width="19%" class="frm-lft-clr123">
                HC&nbsp;</td>
            <td class="frm-rght-clr123">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="height: 20px; width: 28%;">
                            <asp:TextBox ID="txt_hr" runat="server" CssClass="input"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_hr"
                                ErrorMessage='<img src="../images/error1.gif" alt="" />'></asp:RequiredFieldValidator></td>
                        <td width="88px" style="height: 20px">
                            &nbsp; <a href="JavaScript:newPopup1('pickhr.aspx');" class="link05">Pick HC</a></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </td>
  </tr>
  <tr>
    <td height="10" valign="top">&nbsp;</td>
  </tr>
  <tr>
    <td height="20" valign="top" class="txt02">&nbsp;Set Leave Rule</td>
  </tr>
  <tr>
    <td height="10" valign="top">
    
    <div id="divscrol" runat="server" style="position:static;width:800px; height:161px;overflow: scroll; left: 1px; top: 3px;" >
    
    <asp:GridView ID="grid_customizerule" runat="server" Font-Size="11px" Font-Names="Arial" DataKeyNames="leaveid" CellPadding="4" Width="1200px" AutoGenerateColumns="False" BorderWidth="0px"  EmptyDataText="No record found" DataSourceID="SqlDataSource1">
        <Columns>
        
          <asp:TemplateField HeaderText="Leave Type">
                <HeaderStyle CssClass="frm-lft-clr123"/>
                <ItemStyle Width="10%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  />
                <ItemTemplate>
                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("leavename") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        <asp:TemplateField HeaderText="Entitled Days">
                <HeaderStyle CssClass="frm-lft-clr123"/>
                <ItemStyle Width="10%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  />
                <ItemTemplate>
                <asp:DropDownList id="ddentitled" SelectedValue='<%# Bind("entitled_days") %>'  runat="server" CssClass="select2">
        
        <asp:ListItem Value="0">Select Days</asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>13</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>17</asp:ListItem>
                <asp:ListItem>18</asp:ListItem>
                <asp:ListItem>19</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>21</asp:ListItem>
                <asp:ListItem>22</asp:ListItem>
                <asp:ListItem>23</asp:ListItem>
                <asp:ListItem>24</asp:ListItem>
                <asp:ListItem>25</asp:ListItem>
                <asp:ListItem>26</asp:ListItem>
                <asp:ListItem>27</asp:ListItem>
                <asp:ListItem>28</asp:ListItem>
                <asp:ListItem>29</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
                <asp:ListItem>31</asp:ListItem>
                <asp:ListItem>32</asp:ListItem>
                <asp:ListItem>33</asp:ListItem>
                <asp:ListItem>34</asp:ListItem>
                <asp:ListItem>35</asp:ListItem>
                <asp:ListItem>36</asp:ListItem>
                <asp:ListItem>37</asp:ListItem>
                <asp:ListItem>38</asp:ListItem>
                <asp:ListItem>39</asp:ListItem>
                <asp:ListItem>40</asp:ListItem>
                <asp:ListItem>41</asp:ListItem>
                <asp:ListItem>42</asp:ListItem>
                <asp:ListItem>43</asp:ListItem>
                <asp:ListItem>44</asp:ListItem>
                <asp:ListItem>45</asp:ListItem>
                <asp:ListItem>46</asp:ListItem>
                <asp:ListItem>47</asp:ListItem>
                <asp:ListItem>48</asp:ListItem>
                <asp:ListItem>49</asp:ListItem>
                <asp:ListItem>50</asp:ListItem>
                <asp:ListItem>51</asp:ListItem>
                <asp:ListItem>52</asp:ListItem>
                <asp:ListItem>53</asp:ListItem>
                <asp:ListItem>54</asp:ListItem>
                <asp:ListItem>55</asp:ListItem>
                <asp:ListItem>56</asp:ListItem>
                <asp:ListItem>57</asp:ListItem>
                <asp:ListItem>58</asp:ListItem>
                <asp:ListItem>59</asp:ListItem>
                <asp:ListItem>60</asp:ListItem>
                 <asp:ListItem>61</asp:ListItem>
                <asp:ListItem>62</asp:ListItem>
                <asp:ListItem>63</asp:ListItem>
                <asp:ListItem>64</asp:ListItem>
                <asp:ListItem>65</asp:ListItem>
                <asp:ListItem>66</asp:ListItem>
                <asp:ListItem>67</asp:ListItem>
                <asp:ListItem>68</asp:ListItem>
                <asp:ListItem>69</asp:ListItem>
                <asp:ListItem>70</asp:ListItem>
                <asp:ListItem>71</asp:ListItem>
                <asp:ListItem>72</asp:ListItem>
                <asp:ListItem>73</asp:ListItem>
                <asp:ListItem>74</asp:ListItem>
                <asp:ListItem>75</asp:ListItem>
                <asp:ListItem>76</asp:ListItem>
                <asp:ListItem>77</asp:ListItem>
                <asp:ListItem>78</asp:ListItem>
                <asp:ListItem>79</asp:ListItem>
                <asp:ListItem>80</asp:ListItem>
                <asp:ListItem>81</asp:ListItem>
                <asp:ListItem>82</asp:ListItem>
                <asp:ListItem>83</asp:ListItem>
                <asp:ListItem>84</asp:ListItem>
                <asp:ListItem>85</asp:ListItem>
                <asp:ListItem>86</asp:ListItem>
                <asp:ListItem>87</asp:ListItem>
                <asp:ListItem>88</asp:ListItem>
                <asp:ListItem>89</asp:ListItem>
                <asp:ListItem>90</asp:ListItem>
        </asp:DropDownList><asp:CompareValidator id="CompareValidator5" runat="server" ValueToCompare="0" ValidationGroup="v" Operator="NotEqual" ErrorMessage='<img src="../images/error1.gif" alt="" />' Display="Dynamic" ControlToValidate="ddentitled"><img src="../images/error1.gif" alt="" /></asp:CompareValidator>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Days before leave applied" >
                <HeaderStyle CssClass="frm-lft-clr123"/>
                <ItemStyle Width="10%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  />
                <ItemTemplate>
               
                <asp:DropDownList id="ddbfrdays" runat="server" SelectedValue='<%# Bind("days_before_leaveapply") %>' CssClass="select2" Width="85px">
                <asp:ListItem Value="0">Select Days</asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>13</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>17</asp:ListItem>
                <asp:ListItem>18</asp:ListItem>
                <asp:ListItem>19</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>21</asp:ListItem>
                <asp:ListItem>22</asp:ListItem>
                <asp:ListItem>23</asp:ListItem>
                <asp:ListItem>24</asp:ListItem>
                <asp:ListItem>25</asp:ListItem>
                <asp:ListItem>26</asp:ListItem>
                <asp:ListItem>27</asp:ListItem>
                <asp:ListItem>28</asp:ListItem>
                <asp:ListItem>29</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
            </asp:DropDownList><asp:CompareValidator id="CompareValidator2" runat="server" ValueToCompare="0" ValidationGroup="v" Operator="NotEqual" ErrorMessage='<img src="../images/error1.gif" alt="" />' Display="Dynamic" ControlToValidate="ddbfrdays"><img src="../images/error1.gif" alt="" /></asp:CompareValidator>
                </ItemTemplate>
                
            </asp:TemplateField>
          
            
            <asp:TemplateField HeaderText="Minimum Days">
                <HeaderStyle CssClass="frm-lft-clr123"/>
                <ItemStyle Width="10%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  />
                <ItemTemplate>
                    <asp:DropDownList id="ddminimumdays" SelectedValue='<%# Bind("minimum_no_days") %>' runat="server" CssClass="select2">
            <asp:ListItem Value="0">Select Days</asp:ListItem>
         <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>13</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>17</asp:ListItem>
                <asp:ListItem>18</asp:ListItem>
                <asp:ListItem>19</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>21</asp:ListItem>
                <asp:ListItem>22</asp:ListItem>
                <asp:ListItem>23</asp:ListItem>
                <asp:ListItem>24</asp:ListItem>
                <asp:ListItem>25</asp:ListItem>
                <asp:ListItem>26</asp:ListItem>
                <asp:ListItem>27</asp:ListItem>
                <asp:ListItem>28</asp:ListItem>
                <asp:ListItem>29</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
        
        </asp:DropDownList><asp:CompareValidator id="CompareValidator3" runat="server" ValueToCompare="0" ValidationGroup="v" Operator="NotEqual" ErrorMessage='<img src="../images/error1.gif" alt="" />' Display="Dynamic" ControlToValidate="ddminimumdays"><img src="../images/error1.gif" alt="" /></asp:CompareValidator>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Maximum Days">
                <HeaderStyle CssClass="frm-lft-clr123"/>
                <ItemStyle Width="10%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  />
                <ItemTemplate>
                    <asp:DropDownList id="ddmaximumdays" SelectedValue='<%# Bind("maximum_no_days") %>' runat="server" CssClass="select2">
        <asp:ListItem Value="0">Select Days</asp:ListItem>
         <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>13</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>17</asp:ListItem>
                <asp:ListItem>18</asp:ListItem>
                <asp:ListItem>19</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>21</asp:ListItem>
                <asp:ListItem>22</asp:ListItem>
                <asp:ListItem>23</asp:ListItem>
                <asp:ListItem>24</asp:ListItem>
                <asp:ListItem>25</asp:ListItem>
                <asp:ListItem>26</asp:ListItem>
                <asp:ListItem>27</asp:ListItem>
                <asp:ListItem>28</asp:ListItem>
                <asp:ListItem>29</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
        </asp:DropDownList><asp:CompareValidator id="CompareValidator6" runat="server" ValueToCompare="0" ValidationGroup="v" Operator="NotEqual" ErrorMessage='<img src="../images/error1.gif" alt="" />' Display="Dynamic" ControlToValidate="ddmaximumdays"><img src="../images/error1.gif" alt="" /></asp:CompareValidator>
                </ItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Back Date Leave Allowing">
                <HeaderStyle CssClass="frm-lft-clr123"/>
                <ItemStyle Width="10%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  />
                <ItemTemplate>
                    <asp:DropDownList ID="DropDownList1" SelectedValue='<%# Bind("backdate_leave_applicable") %>'  runat="server" CssClass="select2">
                        <asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList>
                    
                </ItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Encashment Percentage">
                <HeaderStyle CssClass="frm-lft-clr123"/>
                <ItemStyle Width="10%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  />
                <ItemTemplate>
                <asp:TextBox id="txtper" runat="server" Text='<%# Bind ("encashment_percentage") %>' CssClass="input2" Width="80px"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ValidationGroup="v" ErrorMessage='<img src="../images/error1.gif" alt="" />' Display="Dynamic" ControlToValidate="txtper"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                </ItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Allowed days for leave modification">
                <HeaderStyle CssClass="frm-lft-clr123"/>
                <ItemStyle Width="10%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  />
                <ItemTemplate>
                   <asp:DropDownList id="ddmax" SelectedValue='<%# Bind("ext_max_days") %>' runat="server" CssClass="select2">
          <asp:ListItem Value="0">Select Days</asp:ListItem>
         <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>13</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>17</asp:ListItem>
                <asp:ListItem>18</asp:ListItem>
                <asp:ListItem>19</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>21</asp:ListItem>
                <asp:ListItem>22</asp:ListItem>
                <asp:ListItem>23</asp:ListItem>
                <asp:ListItem>24</asp:ListItem>
                <asp:ListItem>25</asp:ListItem>
                <asp:ListItem>26</asp:ListItem>
                <asp:ListItem>27</asp:ListItem>
                <asp:ListItem>28</asp:ListItem>
                <asp:ListItem>29</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
        </asp:DropDownList><asp:CompareValidator id="CompareValidator9" runat="server" ValueToCompare="0" ValidationGroup="v" Operator="NotEqual" ErrorMessage='<img src="../images/error1.gif" alt="" />' Display="Dynamic" ControlToValidate="ddmax"><img src="../images/error1.gif" alt="" /></asp:CompareValidator>
                </ItemTemplate>
            </asp:TemplateField>
                 
        </Columns>
        <HeaderStyle CssClass="frm-lft-clr123" />
        <FooterStyle CssClass="frm-lft-clr123" />
        <RowStyle Height="5px" />
    </asp:GridView>
    </div>
    </td>
  </tr>
    <tr>
        <td height="10" valign="top">
        </td>
    </tr>
  <tr>
    <td height="10" valign="top">
        <asp:HiddenField ID="hidd_name" runat="server" />
        <asp:HiddenField ID="hiddenlevel" runat="server" Value="1" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
            ProviderName="<%$ ConnectionStrings:RossellConnectionString.ProviderName %>"
            SelectCommand="select leaveid,leavename,days_before_leaveapply,entitled_days,minimum_no_days,&#13;&#10;maximum_no_days,convert(char(1),backdate_leave_applicable) backdate_leave_applicable,ext_max_days,encashment_percentage&#13;&#10;&#13;&#10;from tbl_leave_employee_customizerule where status=1 and employeeid=@employeeid">
            <SelectParameters>
                <asp:QueryStringParameter Name="employeeid" QueryStringField="empcode" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:HiddenField ID="hidden_hr" runat="server" />
        </td>
  </tr>
  
  <tr>
    <td align="right" valign="top">
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Button ID="btn_submit" runat="server" CssClass="button" Text="Submit" OnClick="btn_submit_Click" />
        <asp:Button ID="btn_reset" runat="server" CssClass="button" Text="Reset" OnClick="btn_reset_Click" />&nbsp;</td>
  </tr>
  <tr>
    <td valign="top">&nbsp;</td>
  </tr>
</table>

</form>
</body>
</html>

