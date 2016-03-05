﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuctionMain.aspx.cs" Inherits="AMS.AuctionMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Auction: </h1>
    <asp:GridView ID="GVAuction" runat="server" CssClass="table table-hover">
        <Columns>
            <asp:BoundField HeaderText="Con Code" DataField="SellerCode" />            
            <asp:BoundField HeaderText="Lot #" DataField="LotNumber" />
            <asp:TemplateField HeaderText="Bidder #">
                <ItemTemplate>
                    <asp:Label ID="lblBidderNumber" runat="server" Text='<%# Eval("BidderNumber") %>' Visible="false" />
                    <asp:DropDownList ID="ddlBidderNumbers" runat="server"></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>                   
            <asp:TemplateField  HeaderText="Sale Status">
                <ItemTemplate>
                    <asp:Label ID="lblSaleStatus" runat="server" Text='<%# Eval("SaleStatus") %>' Visible="false" />
                    <asp:DropDownList ID="ddlSaleStatuses" runat="server"></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>   
            <asp:BoundField HeaderText="Selling Price" DataField="SellingPrice" />
            <asp:BoundField HeaderText="Buyer's Fee" DataField="BuyersFee" />
            <asp:BoundField HeaderText="GST" DataField="GST" /><%--Auto-calculated and stored field--%>
            <asp:BoundField HeaderText="Total" DataField="Total" /><%--Auto-calculated and stored field--%>
            <asp:BoundField HeaderText="Deposit" DataField="Deposit" />
            <asp:BoundField HeaderText="Payments" DataField="PaymentsTotal" /><%--Payments will show a total with the link to the popup that would add a new payment--%>
            <asp:BoundField HeaderText="Surcharges" DataField="SurchargesTotal" /><%--Auto-calculated and stored field--%>
            <asp:BoundField HeaderText="Net Total" DataField="NetTotal" /><%--Auto-calculated and stored field--%>
        </Columns>
    </asp:GridView>
    <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-1" for="TXTNotes">Notes:</label>
        <div class="col-xs-5 row-xs-3">
            <asp:TextBox ID="TXTNotes" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="Notes"/>
        </div>
    </div>
</asp:Content>