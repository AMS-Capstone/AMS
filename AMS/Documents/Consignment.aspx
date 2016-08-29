<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consignment.aspx.cs" Inherits="AMS.Documents.Consignment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="body" runat="server">
    <html xmlns:o="urn:schemas-microsoft-com:office:office"
xmlns:w="urn:schemas-microsoft-com:office:word"
xmlns="http://www.w3.org/TR/REC-html40">

<head>
<meta http-equiv=Content-Type content="text/html; charset=windows-1251">
<meta name=ProgId content=Word.Document>
<meta name=Generator content="Microsoft Word 9">
<meta name=Originator content="Microsoft Word 9">
<link rel=File-List href="./Consignment%20Agreement_files/filelist.xml">
<title>Consignment Agreement</title>
<!--[if gte mso 9]><xml>
 <o:DocumentProperties>
  <o:Author>Gary Hanna</o:Author>
  <o:Template>consignment agreement.dot</o:Template>
  <o:LastAuthor>Serj</o:LastAuthor>
  <o:Revision>2</o:Revision>
  <o:TotalTime>763</o:TotalTime>
  <o:LastPrinted>2013-10-04T20:04:00Z</o:LastPrinted>
  <o:Created>2013-10-28T15:19:00Z</o:Created>
  <o:LastSaved>2013-10-28T15:19:00Z</o:LastSaved>
  <o:Pages>1</o:Pages>
  <o:Words>643</o:Words>
  <o:Characters>3668</o:Characters>
  <o:Company> </o:Company>
  <o:Lines>30</o:Lines>
  <o:Paragraphs>7</o:Paragraphs>
  <o:CharactersWithSpaces>4504</o:CharactersWithSpaces>
  <o:Version>9.8968</o:Version>
 </o:DocumentProperties>
</xml><![endif]--><!--[if gte mso 9]><xml>
 <w:WordDocument>
  <w:MailMergeMainDocType>FormLetters</w:MailMergeMainDocType>
  <w:MailMergeLinkToQuery/>
  <w:MailMergeDataType>Excel</w:MailMergeDataType>
  <w:MailMergeConnectString>Entire Spreadsheet</w:MailMergeConnectString>
  <w:MailMergeQueryString>SELECT * FROM Z:\Car Auction\OCT 5 2013\OCT 5 2013.xls</w:MailMergeQueryString>
  <w:MailMergeDataSource HRef="C:\Users\Serj\Desktop\OCT 5 2013\OCT 5 2013.xls"></w:MailMergeDataSource>
  <w:MailMergeActiveRecord>41</w:MailMergeActiveRecord>
  <w:DisplayHorizontalDrawingGridEvery>0</w:DisplayHorizontalDrawingGridEvery>
  <w:DisplayVerticalDrawingGridEvery>0</w:DisplayVerticalDrawingGridEvery>
  <w:UseMarginsForDrawingGridOrigin/>
  <w:Compatibility>
   <w:FootnoteLayoutLikeWW8/>
   <w:ShapeLayoutLikeWW8/>
   <w:AlignTablesRowByRow/>
   <w:ForgetLastTabAlignment/>
   <w:LayoutRawTableWidth/>
   <w:LayoutTableRowsApart/>
  </w:Compatibility>
 </w:WordDocument>
</xml><![endif]-->
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

<body lang=EN-CA link=blue vlink=purple style='tab-interval:36.0pt'>

<div class=Section1>

<p class=MsoNormal align=center style='text-align:center'><b style='mso-bidi-font-weight:
normal'><span lang=EN-US style='font-size:18.0pt;mso-bidi-font-size:10.0pt;
font-family:Arial;mso-bidi-font-family:"Times New Roman"'>LOT # <u><span
style='mso-field-code:"MERGEFIELD LOT"'>�LOT�</span><o:p></o:p></u></span></b></p>

<p class=MsoNormal align=center style='text-align:center'><b style='mso-bidi-font-weight:
normal'><span lang=EN-US style='font-size:26.0pt;mso-bidi-font-size:10.0pt;
font-family:Arial;mso-bidi-font-family:"Times New Roman"'>GARY HANNA AUCTIONS
LTD.<o:p></o:p></span></b></p>

<p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
style='font-size:9.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;mso-bidi-font-family:
"Times New Roman"'>LICENSE #302414<o:p></o:p></span></p>

<p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
style='font-size:9.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;mso-bidi-font-family:
"Times New Roman"'>11303 Yellowhead Trail NW, Edmonton, Alberta T5G 3J8<o:p></o:p></span></p>

<p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
style='font-size:9.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;mso-bidi-font-family:
"Times New Roman"'>Phone (780) 440-1075<span style="mso-spacerun: yes">&#160;
</span>/ Fax (780) 453-3975<o:p></o:p></span></p>

<p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
style='font-size:9.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;mso-bidi-font-family:
"Times New Roman"'><a href="http://www.auctions.ab.ca/"><span style='font-family:
"Times New Roman"'>www.auctions.ca</span></a><o:p></o:p></span></p>

<p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
style='font-family:Arial;mso-bidi-font-family:"Times New Roman"'><![if !supportEmptyParas]>&nbsp;<![endif]><o:p></o:p></span></p>

<h1><span lang=EN-US style='font-size:14.0pt;mso-bidi-font-size:10.0pt'>CONSIGNMENT
AGREEMENT<o:p></o:p></span></h1>

<p class=MsoNormal><span lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:
10.0pt;font-family:Arial;mso-bidi-font-family:"Times New Roman"'><![if !supportEmptyParas]>&nbsp;<![endif]><o:p></o:p></span></p>

<span lang=EN-US style='font-size:
8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;mso-bidi-font-family:"Times New Roman"'>It
is hereby mutually agreed between GARY HANNA AUCTIONS LTD. as Auctioneer and:<o:p></o:p></span>
    <span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'><span style='mso-tab-count:1'>               &nbsp;</span><table style="width:100%;">
        <tr>
            <td>
                <span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'>Name<span style='mso-tab-count:1'>               </span></span>
            </td>
            <td>
                <span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'><span
style='mso-field-code:"MERGEFIELD CON_NAME"'>�CON_NAME�</span></span></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'>Code<span style='mso-tab-count:1'>               </span></span>
            </td>
            <td>
                <span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'><span
style='mso-field-code:"MERGEFIELD CON_CODE"'>�CON_CODE�</span><o:p></o:p></span></td>
        </tr>
        <tr>
            <td>
                <span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'>Address<span style='mso-tab-count:1'>               </span></span>
            </td>
            <td>
                <span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'>
                <span
style='mso-field-code:"MERGEFIELD CON_STREET_CITY_PROV"'>�CON_STREET_CITY_PROV�</span></span></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'>Postal Code</span></td>
            <td>
                <span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'><span style='mso-field-code:
"MERGEFIELD POSTAL"'>�POSTAL�</span><o:p></o:p></span></td>
        </tr>
        <tr>
            <td>
                <span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'>Phone<span style='mso-tab-count:1'>               </span></span>
            </td>
            <td>
                <span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'><span
style='mso-field-code:"MERGEFIELD CON_PHONE"'>�CON_PHONE�</span></span></td>
            <td>
                <span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'>Fax<span style='mso-tab-count:1'>               </span></span>
            </td>
            <td>
                <span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'><span
style='mso-field-code:"MERGEFIELD CON_FAX"'>�CON_FAX�</span></span></td>
            <td>
                <span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'>Contact<span style='mso-tab-count:
1'>               </span></span>
            </td>
            <td>
                <span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'><span style='mso-field-code:"MERGEFIELD CON_CONTACT"'>�CON_CONTACT�</span></span></td>
        </tr>
        <tr>
            <td>
                <span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'>Notes</span></td>
            <td colspan="3">
                <span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'><span
style='mso-field-code:"MERGEFIELD CON_FILE"'>�NOTES�</span></span></td>
            <td>
                <span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'>Debtor Name</span></td>
            <td>
                <span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'><span style='mso-field-code:
"MERGEFIELD DEBTOR_NAME"'>�DEBTOR_NAME�</span><o:p></o:p></span></td>
        </tr>
        <tr>
            <td>
                <span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'>Reserve</span></td>
            <td>
                <span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'><span
style='mso-field-code:"MERGEFIELD RESERVE"'>�RESERVE�</span></span></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'>Date</span></td>
            <td>
                <span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'><span
style='mso-field-code:"MERGEFIELD SALE_DATE"'>�SALE_DATE�</span></span></td>
        </tr>
    </table>
    </span><span
lang=EN-US style='font-size:6.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'><o:p></o:p></span>

</div>

<div class=Section2>

<p class=MsoNormal style='text-align:justify;tab-stops:9.0pt'><span lang=EN-US
style='font-size:6.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;mso-bidi-font-family:
"Times New Roman"'>1.<span style='mso-tab-count:1'>&#160;&#160; </span>The Auctioneer
shall be entitled to charge a commission of <u><span style="mso-spacerun:
yes">&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;</span>%</u> of proceeds, minimum $100.00 to a maximum of $<u><span
style='mso-tab-count:1'>&#160;&#160;&#160;               </span><span style='mso-tab-count:
2'>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;               </span></u>per vehicle, plus additional charges if
applicable and deemed reasonable by GARY HANNA AUCTIONS LTD.<o:p></o:p></span></p>

<p class=MsoNormal style='text-align:justify;tab-stops:9.0pt'><span lang=EN-US
style='font-size:6.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;mso-bidi-font-family:
"Times New Roman"'>2.<span style='mso-tab-count:1'>&#160;&#160; </span>All goods and
chattels are to be insured by the Consignor and left at the Consignor&#39;s risk.<o:p></o:p></span></p>

<p class=MsoNormal style='text-align:justify;tab-stops:9.0pt'><span lang=EN-US
style='font-size:6.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;mso-bidi-font-family:
"Times New Roman"'>3.<span style='mso-tab-count:1'>&#160;&#160; </span>Articles sold by
private sale by either the Consignor or GARY HANNA AUCTIONS LTD. with the
consent of the Consignor shall be subject to regular commissions as
hereinbefore mentioned.<o:p></o:p></span></p>

<p class=MsoNormal style='text-align:justify;tab-stops:9.0pt'><span lang=EN-US
style='font-size:6.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;mso-bidi-font-family:
"Times New Roman"'>4.<span style='mso-tab-count:1'>&#160;&#160; </span>The Consignor
shall pay to GARY HANNA AUCTIONS LTD. the regular commission on the appraised
value of goods and chattels withdrawn from the sale by the Consignor or GARY
HANNA AUCTIONS LTD., such appraised value<span style="mso-spacerun: yes">&#160;
</span>to be determined by GARY HANNA AUCTIONS LTD.<o:p></o:p></span></p>

<p class=MsoBodyText2><span lang=EN-US style='font-size:6.0pt;mso-bidi-font-size:
10.0pt'>5.<span style='mso-tab-count:1'>&#160;&#160; </span>The Consignor shall pay to
GARY HANNA AUCTIONS LTD. out of pocket expenses including but not limited to
advertising if the sale does not proceed for any reason not the fault of GARY
HANNA AUCTIONS LTD., and a further sum equal to one-half of the commission
otherwise payable on the actual value of the goods listed for sale, such value
to be determined by GARY HANNA AUCTIONS LTD.<o:p></o:p></span></p>

<p class=MsoNormal style='text-align:justify;tab-stops:9.0pt'><span lang=EN-US
style='font-size:6.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;mso-bidi-font-family:
"Times New Roman"'>6.<span style='mso-tab-count:1'>&#160;&#160; </span>The Consignor
agrees to pay to GARY HANNA AUCTIONS LTD. all storage and handling charges
applicable from the date of receipt of the goods and chattels.<o:p></o:p></span></p>

<p class=MsoNormal style='text-align:justify;tab-stops:9.0pt'><span lang=EN-US
style='font-size:6.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;mso-bidi-font-family:
"Times New Roman"'>7.<span style='mso-tab-count:1'>&#160;&#160; </span>The Consignor and
GARY HANNA AUCTIONS LTD. mutually covenant and agree that any items sold and
not paid for by the Purchaser shall remain the property of the Consignor and
will be resold by GARY HANNA AUCTIONS LTD.<o:p></o:p></span></p>

<p class=MsoNormal style='text-align:justify;tab-stops:9.0pt'><span lang=EN-US
style='font-size:6.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;mso-bidi-font-family:
"Times New Roman"'>8.<span style='mso-tab-count:1'>&#160;&#160; </span>The Consignor
covenants and agrees that the goods and chattels listed in Exhibit �A� hereto
are free and clear of all encumbrances.<span style="mso-spacerun: yes">&#160;
</span>The Consignor covenants and agrees that any sale of the goods and
chattels will be void should encumbrances be registered against the said goods
and chattels.<o:p></o:p></span></p>

<p class=MsoNormal style='text-align:justify;tab-stops:9.0pt'><span lang=EN-US
style='font-size:6.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;mso-bidi-font-family:
"Times New Roman"'>9.<span style='mso-tab-count:1'>&#160;&#160; </span>The Consignor
agrees that there will be no payout unless the Purchaser has made full payment
on the purchase.<o:p></o:p></span></p>

<p class=MsoNormal><span lang=EN-US style='font-size:6.0pt;mso-bidi-font-size:
10.0pt;font-family:Arial;mso-bidi-font-family:"Times New Roman"'>10. All
vehicles consigned, are sold within $200.00 of the reserve.<o:p></o:p></span></p>

</div>

<span lang=EN-US style='font-size:6.0pt;mso-bidi-font-size:10.0pt;font-family:
Arial;mso-fareast-font-family:"Times New Roman";mso-bidi-font-family:"Times New Roman";
mso-ansi-language:EN-US;mso-fareast-language:EN-US;mso-bidi-language:HE'><br
clear=all style='page-break-before:auto;mso-break-type:section-break'>
</span>

<div class=Section3>

<h3><span lang=EN-US style='font-size:6.0pt;mso-bidi-font-size:10.0pt'>THE
ABOVE TERMS AND CONDITIONS DO NOT APPLY TO CONTRACT CONSIGNORS<o:p></o:p></span></h3>

<h3><span lang=EN-US>EXHIBIT &#8220;A&#8221; &#8211; GOODS AND CHATTELS</span></h3>

    <table style="width:100%;">
        <tr>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                YEAR</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                �YEAR�</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                MAKE</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                &nbsp;�MAKE�</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                MODEL</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                �MODEL�</td>
        </tr>
        <tr>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                SERIAL NUMBER</td>
            <td class="MsoBodyText" colspan="5" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                &nbsp;�VIN�</td>
        </tr>
        <tr>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                COLOR</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                �COLOR�</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                ODOMETER</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                �MILEAGE�</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                HOURS</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                �HOURS�</td>
        </tr>
        <tr>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                OPTIONS</td>
            <td class="MsoBodyText" colspan="5" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                �OPTIONS�</td>
        </tr>
        <tr>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                STATUS</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                �STATUS�</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                &nbsp;</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                &nbsp;</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                &nbsp;</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                &nbsp;</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                &nbsp;</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">

                                  Deductions</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                &nbsp;</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                &nbsp;</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                Sale Price</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                �SELLING_PRICE�</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                Commission<td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                �COMMISSION�</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                GST on Commission:<td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                Yes / No</td>
        </tr>
        <tr>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                GST</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                �GST�</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                Towing</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                �TOWING�</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                &nbsp;</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                Net Sale</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                ____________</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                Cleaning</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                �CLEANING�</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                ____________</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                ____________</td>
        </tr>
        <tr>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                Total Deductions</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                ____________</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                Keys</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                ____________</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                ____________</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                ____________</td>
        </tr>
        <tr>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                GST on Deductions</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                ____________</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                Repairs</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                ____________</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                ____________</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                ____________</td>
        </tr>
        <tr>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                NET PROCEEDS</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                ____________</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                &nbsp;</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                &nbsp;</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                TOTAL DEDUCTIONS</td>
            <td class="MsoBodyText" 
                style="font-size: 8.0pt; font-family: Arial; mso-bidi-font-size: 10.0pt;">
                ____________</td>
        </tr>
    </table>

<h2 style='line-height:normal'><span lang=EN-US style='font-size:8.0pt;
mso-bidi-font-size:10.0pt'>STATUTORY DECLARATION<o:p></o:p></span></h2>

<p class=MsoNormal style='text-align:justify'><span lang=EN-US
style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;mso-bidi-font-family:
"Times New Roman"'>I, <u><span style='mso-tab-count:2'>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;</span><span
style='mso-tab-count:2'>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;</span><span
style='mso-tab-count:1'>&#160;&#160;&#160;&#160;&#160;&#160;&#160;</span><span style='mso-tab-count:1'>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;</span></u>,
of the City/Town of <u><span style='mso-tab-count:1'>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;</span><span
style='mso-tab-count:2'>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;</span></u><span
style="mso-spacerun: yes">&#160;</span>in the Province of <u><span style='mso-tab-count:
1'>&#160;&#160;&#160;&#160;</span><span style='mso-tab-count:1'>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;</span></u>, DO
SOLEMNLY DECLARE THAT:<o:p></o:p></span></p>

<p class=MsoNormal style='text-align:justify;tab-stops:18.0pt'><span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'>1.<span style='mso-tab-count:1'>&#160;&#160;&#160;&#160; </span>I
am (agent of) the owner of the goods and chattels listed in Exhibit &#8220;A&#8221; herein.<o:p></o:p></span></p>

<p class=MsoNormal style='text-align:justify;tab-stops:18.0pt'><span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'>2.<span style='mso-tab-count:1'>&#160;&#160;&#160;&#160; </span>The
said goods and chattels are not subject to any mortgage, charge, lien, or any
encumbrance except those listed in Exhibit &#8220;B&#8221;.<o:p></o:p></span></p>

<p class=MsoNormal style='text-align:justify;tab-stops:18.0pt'><span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman"'>3.<span style='mso-tab-count:1'>&#160;&#160;&#160;&#160; </span>I
have consigned the said goods and chattels with GARY HANNA AUCTIONS LTD. and
this declaration is furnished pursuant to the provisions of the Public Auctions
Act of Alberta.<o:p></o:p></span></p>

<p class=MsoNormal style='text-align:justify;tab-stops:18.0pt'><b
style='mso-bidi-font-weight:normal'><span lang=EN-US style='font-size:8.0pt;
mso-bidi-font-size:10.0pt;font-family:Arial;mso-bidi-font-family:"Times New Roman";
letter-spacing:-.15pt'><span style='mso-tab-count:1'>&#160;&#160;&#160;&#160;&#160;&#160;&#160; </span>AND</span></b><span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman";letter-spacing:-.15pt'> I make this solemn
declaration conscientiously believing it to be true, and knowing that it is of
the same force and effect as if made under oath, and by virtue of the Canada
Evidence Act.<o:p></o:p></span></p>

<p class=MsoNormal style='text-align:justify;mso-hyphenate:none;tab-stops:-36.0pt'><b
style='mso-bidi-font-weight:normal'><span lang=EN-US style='font-size:8.0pt;
mso-bidi-font-size:10.0pt;font-family:Arial;mso-bidi-font-family:"Times New Roman";
letter-spacing:-.15pt'>DECLARED before me</span></b><span lang=EN-US
style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;mso-bidi-font-family:
"Times New Roman";letter-spacing:-.15pt'> at Edmonton, Alberta, this <u><span
style='mso-tab-count:1'>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; </span><span style='mso-tab-count:1'>               </span></u><o:p></o:p></span></p>

<p class=MsoNormal style='text-align:justify;mso-hyphenate:none;tab-stops:-36.0pt'><span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman";letter-spacing:-.15pt'>day of <u><span
style='mso-tab-count:2'>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;</span><span style='mso-tab-count:
1'>&#160;&#160;&#160;&#160;&#160;&#160;&#160;</span><span style='mso-tab-count:1'>&#160;&#160;&#160;&#160;&#160;&#160;</span></u>,
<u><span style='mso-tab-count:1'>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; </span><span style='mso-tab-count:
1'>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;</span></u>.<o:p></o:p></span></p>

<p class=MsoNormal style='text-align:justify;mso-hyphenate:none;tab-stops:-36.0pt'><span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman";letter-spacing:-.15pt'><![if !supportEmptyParas]>&nbsp;<![endif]><o:p></o:p></span></p>

<p class=MsoNormal style='text-align:justify;mso-hyphenate:none;tab-stops:-36.0pt'><u><span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman";letter-spacing:-.15pt'><span
style='mso-tab-count:2'>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;               </span><span
style='mso-tab-count:2'>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;               </span><span
style='mso-tab-count:2'>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;               </span></span></u><span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman";letter-spacing:-.15pt'><u><span
style='mso-tab-count:2'>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;              </span><span
style='mso-tab-count:2'>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;               </span><span
style='mso-tab-count:1'>               </span><span style='mso-tab-count:1'>               </span><span
style='mso-tab-count:2'>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;               </span></u><o:p></o:p></span></p>

<p class=MsoNormal style='text-align:justify;mso-hyphenate:none;tab-stops:-36.0pt'><span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman";letter-spacing:-.15pt'>Commissioner for
Oaths in and for the Province of Alberta<span style='mso-tab-count:1'> </span><span
style='mso-tab-count:1'>               </span><span style='mso-tab-count:1'>               </span>Consignor
Signature<o:p></o:p></span></p>

<p class=MsoNormal style='text-align:justify;line-height:150%;mso-hyphenate:
none;tab-stops:-36.0pt'><span lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:
10.0pt;font-family:Arial;mso-bidi-font-family:"Times New Roman";letter-spacing:
-.15pt'>Name: <u><span style='mso-tab-count:2'>&#160;&#160;&#160;&#160;&#160;               </span><span
style='mso-tab-count:2'>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;               </span><span
style='mso-tab-count:2'>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;               </span></u><o:p></o:p></span></p>

<p class=MsoNormal style='text-align:justify;mso-hyphenate:none;tab-stops:-36.0pt'><span
lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;font-family:Arial;
mso-bidi-font-family:"Times New Roman";letter-spacing:-.15pt'>Commission
Expires: <u><span style='mso-tab-count:2'>&#160;&#160;               </span><span
style='mso-tab-count:2'>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;</span><o:p></o:p></u></span></p>

</div>

</body>

</html>

    </div>
    </form>
</body>
</html>