<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Buyers.aspx.cs" Inherits="AMS.Buyers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
    <h1>BUYERS</h1>
        <asp:Table ID="Table2" runat="server">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">

                    <asp:Table ID="Table1" runat="server">
                        <asp:TableRow><asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label></asp:TableCell>
                            <asp:TableCell Width="345" HorizontalAlign="Left">
                                <asp:DropDownList Width="95%" ID="DDLBuyerName" runat="server"></asp:DropDownList></asp:TableCell>

                        </asp:TableRow>
            
                        <asp:TableRow><asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="Label2" runat="server" Text="BIDDER #:"></asp:Label></asp:TableCell><asp:TableCell HorizontalAlign="Left">
                                <asp:TextBox ID="TXTBidnum" Width="50%" runat="server"></asp:TextBox>&nbsp;<asp:CheckBox ID="CHKPermanent" Text="&nbsp;Permanent" runat="server"/>
                                </asp:TableCell>                
                        </asp:TableRow><asp:TableRow><asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="Label3" runat="server" Text="Address:"></asp:Label></asp:TableCell><asp:TableCell HorizontalAlign="Left">
                                <asp:TextBox ID="TextBox2" Width="95%" runat="server"></asp:TextBox></asp:TableCell></asp:TableRow>
            
                        <asp:TableRow><asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="Label4" runat="server" Text="City:"></asp:Label></asp:TableCell><asp:TableCell HorizontalAlign="Left">
                                <asp:TextBox ID="TextBox3" Width="95%" runat="server"></asp:TextBox></asp:TableCell></asp:TableRow>
            
                        <asp:TableRow><asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="Label5" runat="server" Text="Province:"></asp:Label></asp:TableCell><asp:TableCell HorizontalAlign="Left">
                                <asp:TextBox ID="TextBox4" Width="95%" runat="server"></asp:TextBox></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="Label6" runat="server" Text="Postal Code:"></asp:Label></asp:TableCell><asp:TableCell HorizontalAlign="Left">
                                <asp:TextBox ID="TextBox5" Width="95%" runat="server"></asp:TextBox></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="Label7" runat="server" Text="Phone:"></asp:Label></asp:TableCell><asp:TableCell HorizontalAlign="Left">
                                <asp:TextBox ID="TXTPhone" Width="95%" runat="server"></asp:TextBox></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="Label8" runat="server" Text="Driver's License:"></asp:Label></asp:TableCell><asp:TableCell HorizontalAlign="Left">
                                <asp:TextBox ID="TXTDriversLicense" Width="95%" runat="server"></asp:TextBox></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell HorizontalAlign="Left">
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left">
                                <asp:CheckBox ID="CHKBanned"  runat="server" Text="&nbsp;BANNED" Font-Bold="True" />
                                </asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="Label10" runat="server" Text="NOTES:"></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left">
                                <asp:TextBox ID="TXTNotes" Height="90px" Width="95%" runat="server" Rows="3" WordWrap="true"></asp:TextBox></asp:TableCell></asp:TableRow>

                        <asp:TableRow><asp:TableCell HorizontalAlign="Right"></asp:TableCell></asp:TableRow>
                    </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
</asp:Content>
