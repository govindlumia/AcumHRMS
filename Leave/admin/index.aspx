<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Leave_admin_adminindex" Title="Ykk India Pvt. Ltd." %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title> Employee Information</title>

<style type="text/css" media="all">

@import "../css/blue1.css";
</style>
<script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>
<script type="text/javascript" src="../js/jquery-1.2.2.pack.js"></script>
<script type="text/javascript" src="../js/ddaccordion.js"></script>
<script type="text/javascript" src="../js/timepicker.js"></script>
<script type="text/javascript">
ddaccordion.init({
headerclass: "expandable", //Shared CSS class name of headers group
contentclass: "submenu", //Shared CSS class name of contents group
collapseprev: true, //Collapse previous content (so only one open at any time)? true/false 
defaultexpanded: [], //index of content(s) open by default [index1, index2, etc] [] denotes no content
animatedefault: false, //Should contents open by default be animated into view?
persiststate: true, //persist state of opened contents within browser session?
toggleclass: ["", "openheader"], //Two CSS classes to be applied to the header when it's collapsed and expanded, respectively ["class1", "class2"]
togglehtml: ["suffix", "<img src='../images/plus3.gif' class='statusicon' />", "<img src='../images/minus3.gif' class='statusicon' />"], //Additional HTML added to the header when it's collapsed and expanded, respectively  ["position", "html1", "html2"] (see docs)
animatespeed: "normal" //speed of animation: "fast", "normal", or "slow"
})
</script>
<%--<script type="text/javascript">
function time()
{
var t1=document.getElementById("ctl00_ContentPlaceHolder1_txtstime").toString();

}
</script>--%>
</head>
<body>
    <form id="form1" runat="server">
   
   <div class="header">
   <asp:ScriptManager id="leave" runat="server">
     
    </asp:ScriptManager>
<table width="1000" border="0" align="center" cellpadding="0" cellspacing="0">
<tr>
<td height="30" colspan="2" bgcolor="#f1f4f5" class="black1" style="padding-left:5px; ">Leave Management &gt;&gt; Create Leave</td>
<td height="30" bgcolor="#f1f4f5" class="black1" style="padding-left:705px; "  ><a href="../../admin/application.aspx">Back</a></td>
</tr>
<tr>
<td height="5" colspan="3"></td>
</tr>

<tr>
<td width="12%" valign="top" class="blue-brdr"><!--................................LEFT NAVIGAION........................-->
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td class="nav-head">Leave Management</td>
</tr>
<tr>
<td><div class="glossymenu">
<a class="menuitem expandable" href="#">Leave Master</a>
<div class="submenu">
<ul>
<li><a href="createleave.aspx" target="mypage">Create Leave</a></li>
<li><a href="editleave.aspx" target="mypage">View / Edit Leave </a></li>
</ul>
</div>
<a class="menuitem expandable" href="#">Leave Rule / Policy / Adjustment </a>
<div class="submenu">
<ul>
<li><a href="createdefaultrule.aspx" target="mypage">Create Default Rule</a></li>
<li><a href="overviewrule.aspx" target="mypage">View / Edit Default Rule</a></li>
<li><a href="createleavepolicy.aspx" target="mypage">Create Leave Policy </a></li>
<li><a href="editleavepolicy.aspx" target="mypage">View / Edit Leave Policy </a></li>

<li><a href="#">Leave Adjustment Rule</a></li>
<li><a href="#">View / Edit Adjustment Rule</a></li>
</ul>
</div>
<a class="menuitem expandable" href="#">Leave Hierarchy</a>
<div class="submenu">
<ul>
<li><a href="createhierarchy.aspx" target="mypage">Create Hierarchy</a></li>
<li><a href="edithierarchy.aspx" target="mypage">View / Edit Hierarchy</a></li>
</ul>
</div>
<a class="menuitem expandable" href="#">Employee Leave Profile</a>
<div class="submenu">
<ul>
<li><a href="#">Create Employee Profile</a></li>
<li><a href="#">View / Edit Employee Profile</a></li>
</ul>
</div>
<a class="menuitem expandable" href="#">Shift Master</a>
<div class="submenu">
<ul>
<li><a href="createshift.aspx" target="mypage">Create Shift Master</a></li>
<li><a href="editshift.aspx" target="mypage">View / Edit Shift Master </a></li>
</ul>
</div>
<a class="menuitem expandable" href="#">Holiday Master </a>
<div class="submenu">
<ul>
<li><a href="createholiday.aspx" target="mypage">Create Holidays</a></li>
<li><a href="editholiday.aspx" target="mypage">View / Edit Holidays</a></li>
</ul>
</div>	
<a class="menuitem expandable" href="#">Reports</a>
<div class="submenu">
<ul>
<li></li>
</ul>
</div>
</div></td>
</tr>
</table>
<!--................................END LEFT NAVIGAION........................--></td>
<td width="1%" valign="top"><img src="../images/5x5.gif" width="10" height="5" /></td>
<td width="87%" align="left" valign="top" class="blue-brdr-1">


<iframe name="mypage" frameborder="0" width="735px" height="512px" src="createleave.aspx" scrolling="yes"></iframe>



</td>
</tr>
</table>
</div>  
</form>
</body>
</html>
