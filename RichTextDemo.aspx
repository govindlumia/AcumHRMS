<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RichTextDemo.aspx.cs" Inherits="RichTextDemo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="FreeTextBox/wysiwyg.js"></script>
		<script type="text/javascript" src="FreeTextBox/wysiwyg-settings.js"></script>
    <script type="text/javascript">
        // Use it to attach the editor to all textareas with full featured setup
        //WYSIWYG.attach('all', full);

        // Use it to attach the editor directly to a defined textarea
        WYSIWYG.attach('textarea1'); // default setup
        WYSIWYG.attach('textarea2', full); // full featured setup
        WYSIWYG.attach('textarea3', small); // small setup

        // Use it to display an iframes instead of a textareas
        //WYSIWYG.display('all', full);  
		</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="2" cellspacing="0" style="width:100%;">
		<tbody>
			<tr style="vertical-align: top;">
				<td>
					<a href="http://www.openwebware.com" target="_blank">
						<img src="~/FreeTextBox/docs/images/logo.gif" border="0">
					</a>
				</td>
				<td style="text-align: right;">
					<font class="naviblock">
						<a href="~/FreeTextBox/docs/doc.html" class="navi" title="Documentation">DOCUMENTATION</a> | <a href="docs/addons.html" class="navi" title="Addons">ADDONS</a> | <a href="example.html" class="navi" title="Examples">EXAMPLES</a>
					</font>
				</td>
			</tr>
			<tr>
				<td colspan="2">
					<br>
					<table border="0" cellpadding="2" cellspacing="0" style="width:100%;">
					<tbody>
						<tr>
							<td class="headline">
								<h1>Examples</h1>
							</td>
						</tr>
						<tr>
							<td class="info">
							Copyright (c) 2006 openWebWare.com
							</td>
						</tr>
						<tr>
							<td>
								<br>
								<form name="exampleForm" action="example.html" method="post">
<!-- 
	Default settings
 -->								
<h2>
	Default setup applied to this editor: 
</h2>
<br>
<textarea id="textarea1" name="test1" style="width:560px;height:200px;">
 <table border="0" cellpadding="0" cellspacing="0" style="margin-left: 10px;">
 <tr>
  <td style="padding: 0 10 10 0;">
  <a href="http://www.openwebware.com/products/openwysiwyg/">
  	<img	src="http://www.openwebware.com/images/openwysiwyg/logo9060.gif" border="0" height="60" width="90" alt="openWYSIWYG - Cross-browser WYSIWYG editor">
  </a>
  </td>
  <td style="font-family: verdana; font-size: 11px; line-height: 130%; color: #494949;" valign="top">	
  <b>
  	<a href="http://www.openwebware.com/products/openwysiwyg/" style="font-family: arial; font-size: 12px; color: #055F92;">openWYSIWYG - Cross-browser WYSIWYG editor</a>
   </b>
	<br />	   
	</td>
 </tr>
</table>
</textarea>
<br />
<br />

<!-- 
	Three toolbars and dynamicly width applied to this editor
 -->
<h2>
Customized toolbar and openImageLibrary addon applied to this editor:
</h2>
<br>
<textarea id="textarea2" name="test2" style="width:80%;height:200px;">
<h1>GNU Lesser General Public License</h1>
<tt>
<p>Version 2.1, February 1999</p>

<blockquote>
<p>Copyright (C) 1991, 1999 Free Software Foundation, Inc.
59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
Everyone is permitted to copy and distribute verbatim copies
of this license document, but changing it is not allowed.</p>

<p>[This is the first released version of the Lesser GPL.  It also counts
 as the successor of the GNU Library Public License, version 2, hence
 the version number 2.1.]</p>
</blockquote>

<h3>Preamble</h3>
<p>The licenses for most software are designed to take away your freedom to share and change it.</p></tt>
</textarea>

<br />
<br />

<!-- 
	A really small setup applied to this editor
-->
<h2> 
	A really small setup applied to this editor: 
</h2>
<br>
<textarea id="textarea3" name="test3">
A small editor...can come in handy when you just need font size, bold, italic, etc.
</textarea>

</form>
							</td>
						</tr>	
					</tbody>
				</table>
			</td>
		</tr>
		</tbody>
	</table>
    </div>
    </form>
</body>
</html>
