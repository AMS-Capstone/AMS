﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewAuction.aspx.cs" Inherits="AMS.NewAuction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>New Auction</h1>
    <div class=" col-xs-12" id="AlertDiv" runat="server"></div>

    <div class="control-group">
        <label class="control-label col-xs-2" for="TXTNotes">New Auction Date:</label>
        <div class="col-xs-3">
            <div class="container">
                <div class="row">
                    <div class='col-sm-3'>
                        <div class="form-group">
                            <div class='input-group date' id='datetimepicker1'>
                                <input type='text' class="form-control" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>
                        </div>
                    </div>
                    <script type="text/javascript">
                        $(function () {
                            $('#datetimepicker1').datetimepicker();
                        });
                    </script>
                </div>
            </div>
        </div>
    </div>
    <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="LVAuctionCars">Auction Cars:</label>
        <div class="col-xs-4">
            <asp:ListView ID="LVAuctionCars" runat="server" placeholder="">
                <ItemTemplate>
                    <div class="col-md-4 portfolio-item">
                        <!-- Some content -->
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div class="col-xs-6"></div>
    </div>  
</asp:Content>
