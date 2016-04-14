<%@ Page Title="Auction Listing" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AMS._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Auction Listing</h2>
        <div class="row" id="AlertDiv" runat="server"></div>

        <div class="form-group row">
            <label class="control-label col-xs-6 col-md-1 col-sm-1" for="DDLAuctionYear">Year:</label>            
            <div class="col-xs-6 col-md-3 col-sm-4">
                <asp:DropDownList ID="DDLAuctionYear" CssClass="form-control" runat="server" OnSelectedIndexChanged="DDLAuctionYear_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </div>
        </div>

        <div class="form-group row">
            <div class="col-xs-12 col-md-4 col-sm-5">
                <asp:ListBox ID="LBAuctionList" CssClass="form-control"  runat="server" Rows="10"></asp:ListBox>
            </div>
        </div>
        <div id="resetBidderNumbersModal" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Confirm Resetting Bidder Numbers</h4>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="BTNReset" runat="server" CssClass="btn btn-primary" Text="Confirm" OnClick="BTNReset_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row"><hr /></div>
        <div class="form-group row">
            <div class="btn-group col-xs-12">
                <asp:Button ID="btnSelectAuction" runat="server" CssClass="btn btn-primary" Text="Go to Selected Auction" OnClick="BTNSubmit_Click" />
            </div>
        </div>
        <div class="form-group row">
            <div class="btn-group col-xs-12">
                <button type="button" class="btn btn-warning" data-toggle="modal" title="Car List Modal" data-target="#resetBidderNumbersModal">Reset Bidder Numbers</button>
            </div>
        </div>
    </div>

    
</asp:Content>
