<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuctionListing.aspx.cs" Inherits="AMS.AuctionListing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <asp:Label ID="Label1" runat="server" Text="Year:"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        <asp:ListBox ID="lstAuctions" runat="server"></asp:ListBox>
        <asp:Button ID="btnSelectAuction" runat="server" Text="Go to Selected Auction" />
        <asp:Button ID="btnManageCars" runat="server" Text=" Manager Cars" />
        <asp:Button ID="btnManageBuyers" runat="server" Text="Manager Buyers" />
        <asp:Button ID="btnManageSellers" runat="server" Text="Manage Sellers" />
        <asp:Button ID="btnCreateNewAuction" runat="server" Text="Create New Auction" />
        <asp:Button ID="btnManageInventory" runat="server" Text="Manage Inventory" />
        <asp:Button ID="btnManageSettings" runat="server" Text="Manage Settings" />
    </form>
</body>
</html>
