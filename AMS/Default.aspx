<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AMS._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Auction Listing</h2>
        <div class=" col-xs-12" id="AlertDiv" runat="server"></div>
        <div class="control-group">
            <asp:Label ID="Label1" class="control-label col-xs-1" runat="server" Text="Year:"></asp:Label>            
            <div class="col-xs-2">
                <asp:DropDownList ID="DDLAuctionYear" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
       
        <div class=" col-xs-12"></div>
        <div class="control-group">
            <div class="col-xs-3">
                <asp:ListBox ID="LBAuctionList" CssClass="form-control"  runat="server"></asp:ListBox>
            </div>
        </div>
        <div class="btn-group col-xs-12">
            <asp:Button ID="btnSelectAuction" runat="server" CssClass="btn btn-primary" Text="Go to Selected Auction" OnClick="BTNSubmit_Click" />
        </div>
        
        <div class=" col-xs-12"><hr /></div>
    </div>

    
</asp:Content>
