<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogSheet.aspx.cs" Inherits="AMS.Documents.LogSheet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consignment Agreement</title>
    <style>
<!--
 /* Style Definitions */
p.MsoNormal, li.MsoNormal, div.MsoNormal
	{mso-style-parent:"";
	margin:0cm;
	margin-bottom:.0001pt;
	mso-pagination:widow-orphan;
	font-size:10.0pt;
	font-family:"Times New Roman";
	mso-fareast-font-family:"Times New Roman";
	mso-ansi-language:EN-US;
	mso-bidi-language:HE;}
h1
	{mso-style-next:Normal;
	margin:0cm;
	margin-bottom:.0001pt;
	text-align:center;
	mso-pagination:widow-orphan;
	page-break-after:avoid;
	mso-outline-level:1;
	font-size:16.0pt;
	mso-bidi-font-size:10.0pt;
	font-family:Arial;
	mso-bidi-font-family:"Times New Roman";
	mso-font-kerning:0pt;
	mso-ansi-language:EN-US;
	mso-bidi-language:HE;
	mso-bidi-font-weight:normal;
	font-style:italic;
	mso-bidi-font-style:normal;
	text-decoration:underline;
	text-underline:single;}
h2
	{mso-style-next:Normal;
	margin:0cm;
	margin-bottom:.0001pt;
	text-align:center;
	line-height:150%;
	mso-pagination:widow-orphan;
	page-break-after:avoid;
	mso-outline-level:2;
	font-size:10.0pt;
	font-family:Arial;
	mso-bidi-font-family:"Times New Roman";
	mso-ansi-language:EN-US;
	mso-bidi-language:HE;
	mso-bidi-font-weight:normal;}
h3
	{mso-style-next:Normal;
	margin:0cm;
	margin-bottom:.0001pt;
	text-align:center;
	line-height:150%;
	mso-pagination:widow-orphan;
	page-break-after:avoid;
	mso-outline-level:3;
	font-size:8.0pt;
	mso-bidi-font-size:10.0pt;
	font-family:Arial;
	mso-bidi-font-family:"Times New Roman";
	mso-ansi-language:EN-US;
	mso-bidi-language:HE;
	mso-bidi-font-weight:normal;}
h4
	{mso-style-next:Normal;
	margin:0cm;
	margin-bottom:.0001pt;
	line-height:200%;
	mso-pagination:widow-orphan;
	page-break-after:avoid;
	mso-outline-level:4;
	font-size:8.0pt;
	mso-bidi-font-size:10.0pt;
	font-family:"Times New Roman";
	mso-ansi-language:EN-US;
	mso-bidi-language:HE;
	font-weight:normal;
	text-decoration:underline;
	text-underline:single;}
h5
	{mso-style-next:Normal;
	margin:0cm;
	margin-bottom:.0001pt;
	mso-pagination:widow-orphan;
	page-break-after:avoid;
	mso-outline-level:5;
	tab-stops:571.5pt;
	font-size:8.0pt;
	mso-bidi-font-size:10.0pt;
	font-family:Arial;
	mso-bidi-font-family:"Times New Roman";
	mso-ansi-language:EN-US;
	mso-bidi-language:HE;
	mso-bidi-font-weight:normal;
	text-decoration:underline;
	text-underline:single;}
p.MsoTitle, li.MsoTitle, div.MsoTitle
	{margin:0cm;
	margin-bottom:.0001pt;
	text-align:center;
	mso-pagination:widow-orphan;
	font-size:20.0pt;
	mso-bidi-font-size:10.0pt;
	font-family:Arial;
	mso-fareast-font-family:"Times New Roman";
	mso-bidi-font-family:"Times New Roman";
	mso-ansi-language:EN-US;
	mso-bidi-language:HE;
	font-weight:bold;
	mso-bidi-font-weight:normal;}
p.MsoBodyText, li.MsoBodyText, div.MsoBodyText
	{margin:0cm;
	margin-bottom:.0001pt;
	text-align:justify;
	mso-pagination:widow-orphan;
	font-size:10.0pt;
	font-family:Arial;
	mso-fareast-font-family:"Times New Roman";
	mso-bidi-font-family:"Times New Roman";
	mso-ansi-language:EN-US;
	mso-bidi-language:HE;}
p.MsoBodyText2, li.MsoBodyText2, div.MsoBodyText2
	{margin:0cm;
	margin-bottom:.0001pt;
	text-align:justify;
	mso-pagination:widow-orphan;
	tab-stops:9.0pt;
	font-size:8.0pt;
	mso-bidi-font-size:10.0pt;
	font-family:Arial;
	mso-fareast-font-family:"Times New Roman";
	mso-bidi-font-family:"Times New Roman";
	mso-ansi-language:EN-US;
	mso-bidi-language:HE;}
a:link, span.MsoHyperlink
	{color:blue;
	text-decoration:underline;
	text-underline:single;}
a:visited, span.MsoHyperlinkFollowed
	{color:purple;
	text-decoration:underline;
	text-underline:single;}
@page Section1
	{size:612.0pt 792.0pt;
	margin:18.0pt 18.0pt 15.1pt 18.0pt;
	mso-header-margin:36.0pt;
	mso-footer-margin:36.0pt;
	mso-paper-source:0;}
div.Section1
	{page:Section1;}
@page Section2
	{size:612.0pt 792.0pt;
	margin:18.0pt 18.0pt 15.1pt 18.0pt;
	mso-header-margin:36.0pt;
	mso-footer-margin:36.0pt;
	mso-columns:2 even 36.0pt;
	mso-paper-source:0;}
div.Section2
	{page:Section2;}
@page Section3
	{size:612.0pt 792.0pt;
	margin:18.0pt 18.0pt 15.1pt 18.0pt;
	mso-header-margin:36.0pt;
	mso-footer-margin:36.0pt;
	mso-paper-source:0;}
div.Section3
	{page:Section3;}
-->
</style>
</head>
<body  lang=EN-CA link=blue vlink=purple style='tab-interval:36.0pt'>
    <form id="form1" runat="server">
    <div id="body" runat="server">

<div class=Section1>

<p class=MsoNormal align=center style='text-align:center'><b style='mso-bidi-font-weight:
normal'><span lang=EN-US style='font-size:18.0pt;mso-bidi-font-size:10.0pt;
font-family:Arial;mso-bidi-font-family:"Times New Roman"'>AUCTIONEER / CLERK LOG SHEET <br/>
Sale Date <a id="auctionDate" runat="server" >«AUCTION_DATE»</a></span></b></p>
<br />
<div id="carList" runat="server" >«LOGSHEET_TABLE»</div>
    </div>

    </div>
    </form>
</body>
</html>
