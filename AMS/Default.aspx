<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AMS._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>Auction Listing</h2>
            <asp:Label ID="Label1" runat="server" Text="Year:"></asp:Label>
            <asp:DropDownList ID="DDLAuctionYear" runat="server" OnSelectedIndexChanged="DDLAuctionYear_SelectedIndexChanged">
                <asp:ListItem>2015</asp:ListItem>
                <asp:ListItem>2014</asp:ListItem>
        </asp:DropDownList>
            <br />
         <asp:ListBox ID="LBAuctionList" runat="server" OnSelectedIndexChanged="LBAuctionList_SelectedIndexChanged">
             <asp:ListItem>September 1, 2015</asp:ListItem>
             <asp:ListItem>August 1, 2015</asp:ListItem>
         </asp:ListBox>
    </div>

    

</asp:Content>
