<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AMS._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>Auction Listing</h2>
            <asp:Label ID="Label1" runat="server" Text="Year:"></asp:Label>
            <asp:DropDownList ID="DDLAuctionYear" runat="server">
        </asp:DropDownList>
            <br />
         <asp:ListBox ID="LBAuctionList" runat="server">
         </asp:ListBox>
    </div>

    
</asp:Content>
