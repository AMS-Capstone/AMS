﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuctionMain.aspx.cs" Inherits="AMS.AuctionMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Auction: </h1>
    
    <div class=" col-xs-12" id="AlertDiv" runat="server"></div>

    <asp:GridView ID="GVAuction" runat="server" CssClass="table table-hover col-xs-12" 
        AutoGenerateColumns="False" OnRowDataBound="RowDataBound" OnRowEditing="gv_RowEditing" OnRowUpdating="gv_RowUpdating" OnRowCancelingEdit="gv_RowCancelingEdit"
        AutoGenerateEditButton="true"
        >
        <Columns>
            <asp:BoundField HeaderText="Con Code" DataField="SellerCode" />            
            <asp:BoundField HeaderText="Lot #" DataField="LotNumber" />
            <asp:TemplateField HeaderText="Bidder #">
                <ItemTemplate>
                    <asp:Label ID="lblBidderNumber" runat="server" Text='<%# Eval("BuyerID") %>' Visible="false" />
                    <asp:DropDownList ID="DDLBidderNumbers" runat="server"  OnSelectedIndexChanged="DDLBidderNumbers_SelectedIndexChanged"></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>                   
            <asp:TemplateField  HeaderText="Sale Status">
                <ItemTemplate>
                    <asp:Label ID="lblSaleStatus" runat="server" Text='<%# Eval("ConditionID") %>' Visible="false" />
                    <asp:DropDownList ID="DDLSaleStatuses" runat="server" OnSelectedIndexChanged="DDLSaleStatuses_SelectedIndexChanged"></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>   
            <asp:BoundField HeaderText="Selling Price" DataField="SellingPrice" DataFormatString="{0:c}" />
            <asp:BoundField HeaderText="AuctionSaleID" DataField="AuctionSaleID" Visible="false"/>
            <asp:BoundField HeaderText="Buyer's Fee" DataField="BuyersFee" DataFormatString="{0:c}" />
            <asp:BoundField HeaderText="GST" DataField="GST" DataFormatString="{0:c}" /><%--Auto-calculated and stored field--%>
            <asp:BoundField HeaderText="Total" DataField="Total" DataFormatString="{0:c}" /><%--Auto-calculated and stored field--%>
            <asp:BoundField HeaderText="Deposit" DataField="Deposit" DataFormatString="{0:c}" />
            <asp:BoundField HeaderText="Payments" DataField="PaymentsTotal" DataFormatString="{0:c}" /><%--Payments will show a total with the link to the popup that would add a new payment--%>
            <asp:BoundField HeaderText="Surcharges" DataField="SurchargesTotal" DataFormatString="{0:c}" /><%--Auto-calculated and stored field--%>
            <asp:BoundField HeaderText="Net Total" DataField="NetTotal" DataFormatString="{0:c}" /><%--Auto-calculated and stored field--%>

        </Columns>
    </asp:GridView>
    <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-1" for="TXTNotes">Notes:</label>
        <div class="col-xs-5 row-xs-3">
            <asp:TextBox ID="TXTNotes" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="Notes"/>
        </div>
    </div>
    <div class="btn-group col-xs-12">
        <asp:Button ID="BTNTotals" runat="server" CssClass="btn btn-primary pull-right" Text="Calculate Auction Totals" OnClick="BTNTotals_Click" />
    </div>
</asp:Content>
