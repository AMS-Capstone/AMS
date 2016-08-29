<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BidderRegistration.aspx.cs" Inherits="AMS.BidderRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="row" id="AlertDiv" runat="server"></div>

        <div class="form-group row">
            <label class="control-label col-xs-6 col-md-1 col-sm-1" for="DDLAuctionYear">Year:</label>            
            <div class="col-xs-6 col-md-3 col-sm-4">
                <asp:DropDownList ID="DDLAuctionYear" CssClass="form-control" runat="server" OnSelectedIndexChanged="DDLAuctionYear_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </div>
        </div>

        <div class="form-group row">
            <div class="col-xs-12 col-md-4 col-sm-5">
                <asp:ListBox ID="LBAuctionList" CssClass="form-control"  runat="server" Rows="10"  AutoPostBack="true" OnSelectedIndexChanged="LBAuctionList_SelectedIndexChanged" ></asp:ListBox>
            </div>
        </div>
        
        <div class="form-group row">
            <label class="control-label col-xs-12 col-sm-2" for="TXTFirstName">Bidder Number:</label>
            <div class="col-xs-12 col-sm-2">
                <asp:TextBox ID="TXTBidderNumber" runat="server" CssClass="form-control" placeholder=""/>
            </div>
        </div>

        <div class="form-group row">
            <div class="btn-group col-xs-12">
                <asp:Button ID="btnAddBidder" runat="server" CssClass="btn btn-primary" Text="Add Bidder to the Aucttion" OnClick="btnAddBidder_Click" /><%--OnClick="BTNSubmit_Click"--%>
            </div>
        </div>


        <div class="form-group row">
            <div class="col-xs-12 col-md-4 col-sm-5">
                <asp:ListBox ID="LBAuctionBidderList" CssClass="form-control"  runat="server" Rows="10" >
                </asp:ListBox>
            </div>
        </div>
        <div class="form-group row">
            <div class="btn-group col-xs-12">
                <asp:Button ID="btnEditBidder" runat="server" CssClass="btn btn-primary" Text="Edit bidder number" OnClick="btnEditBidder_Click"  /><%--OnClick="BTNSubmit_Click"--%>
                <%-- true functionality of this button is to copy the selected bidder number into the above textbox and then delete it from the database and the list --%>
            </div>
        </div>
    </div>
</asp:Content>
