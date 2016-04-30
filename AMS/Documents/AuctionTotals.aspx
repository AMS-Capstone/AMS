<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuctionTotals.aspx.cs" Inherits="AMS.Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="body" runat="server">
        <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Auction Summary</title>
    <style type="text/css">
        .style9
        {
            width: 116px;
        }
        .style10
        {
            width: 145px;
        }
    </style>
</head>
<body>
<p class=MsoNormal align=center style='text-align:center'><b style='mso-bidi-font-weight:
normal'><i style='mso-bidi-font-style:normal'><span lang=EN-US
style='font-size:20.0pt;mso-bidi-font-size:10.0pt;font-family:"Arial","sans-serif";
mso-bidi-font-family:"Times New Roman"'>GARY HANNA AUCTIONS LTD.<o:p></o:p></span></i></b></p>

<p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style=' text-align: center;font-size:16.0pt;mso-bidi-font-size:10.0pt;
font-family:"Arial","sans-serif";mso-bidi-font-family:"Times New Roman";'>Auction 
    Details</span></p>

<p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style=' text-align: center;font-size:16.0pt;mso-bidi-font-size:10.0pt;
font-family:"Arial","sans-serif";mso-bidi-font-family:"Times New Roman";'>For 
    Auction on «AUCTION_DATE»</span></p>
    <p class=MsoNormal align=center style='text-align:left'>
    <span lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;line-height:200%;font-family:
"Arial","sans-serif";mso-bidi-font-family:"Times New Roman"'>
    <span style='mso-no-proof:yes'>«CAR_DETAILS»</span></span></p>

    <table style="width:100%;">
        <tr>
            <td class="style9">
                <span lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;line-height:200%;font-family:
"Arial","sans-serif";mso-bidi-font-family:"Times New Roman"'>
    <span style='mso-no-proof:yes'>Total Selling Prices: </span></span></td></td>
            <td class="style10" align="right">
    <span lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;line-height:200%;font-family:
"Arial","sans-serif";mso-bidi-font-family:"Times New Roman"'>
    <span style='mso-no-proof:yes'>«TOTAL_SALES»  </span></span></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                <span lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;line-height:200%;font-family:
"Arial","sans-serif";mso-bidi-font-family:"Times New Roman"'>
                <span style='mso-no-proof:yes'>Total in fees:</span></span></td></td>
            <td class="style10" align="right">
                <span lang="EN-US" style="font-size:8.0pt;mso-bidi-font-size:10.0pt;line-height:200%;font-family:
&quot;Arial&quot;,&quot;sans-serif&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;">
                <span style="mso-no-proof:yes">«BFEE_TOTAL» </span></span></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                <span lang="EN-US" style="font-size:8.0pt;mso-bidi-font-size:10.0pt;line-height:200%;font-family:
&quot;Arial&quot;,&quot;sans-serif&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;">
                <span style="mso-no-proof:yes">Total GST:</span></span></td>
            <td class="style10" align="right">
                <span lang="EN-US" style="font-size:8.0pt;mso-bidi-font-size:10.0pt;line-height:200%;font-family:
&quot;Arial&quot;,&quot;sans-serif&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;">
                <span style="mso-no-proof:yes">«FULL_GST» </span></span></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                <span lang=EN-US style='font-size:8.0pt;mso-bidi-font-size:10.0pt;line-height:200%;font-family:
"Arial","sans-serif";mso-bidi-font-family:"Times New Roman"'>
                <span style='mso-no-proof:yes'>Gross Total:</span></span></td></td>
            <td class="style10" align="right">
                <span lang="EN-US" style="font-size:8.0pt;mso-bidi-font-size:10.0pt;line-height:200%;font-family:
&quot;Arial&quot;,&quot;sans-serif&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;">
                <span style="mso-no-proof:yes">«GROSS» </span></span></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                <span lang="EN-US" style="font-size:8.0pt;mso-bidi-font-size:10.0pt;line-height:200%;font-family:
&quot;Arial&quot;,&quot;sans-serif&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;">
                <span style="mso-no-proof:yes">Deposits and Payments:</span></span></td>
            <td class="style10" align="right">
                <span lang="EN-US" style="font-size:8.0pt;mso-bidi-font-size:10.0pt;line-height:200%;font-family:
&quot;Arial&quot;,&quot;sans-serif&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;">
                <span style="mso-no-proof:yes">«MONIES» </span></span></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                <span lang="EN-US" style="font-size:8.0pt;mso-bidi-font-size:10.0pt;line-height:200%;font-family:
&quot;Arial&quot;,&quot;sans-serif&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;">
                <span style="mso-no-proof:yes">Receivables:</span></span></td>
            <td class="style10" align="right">
                <span lang="EN-US" style="font-size:8.0pt;mso-bidi-font-size:10.0pt;line-height:200%;font-family:
&quot;Arial&quot;,&quot;sans-serif&quot;;mso-bidi-font-family:&quot;Times New Roman&quot;">
                <span style="mso-no-proof:yes">«NET»</span></span></td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

</body>
</html>

    </div>
    </form>
</body>
</html>
