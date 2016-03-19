﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewAuction.aspx.cs" Inherits="AMS.NewAuction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>New Auction</h1>
    <div class=" col-xs-12" id="AlertDiv" runat="server"></div>
    <div class=" col-xs-6" id="ProgressBar" runat="server">
        <%--<div class="progress progress-striped">
            <div class="progress-bar progress-bar-info" style="width: 0%">
                Creating
            </div>
        </div>--%>
        <%--<span class="sr-only">Creating New Auction</span>--%>
    </div>
    <div class="col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="TXTDate">New Auction Date:</label>
            <div class="container">
                <div class="row">
                    <div class='col-sm-4'>
                        <div class="form-group">
                            <div class='input-group date' id='datetimepicker1'>
                                <asp:TextBox type='text' class="form-control dp" readonly id="TXTDate" runat="server" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>
                        </div>
                    </div>
                    <script type="text/javascript">
                        $(function () {
                            $('#datetimepicker1').datetimepicker({
                                format: "DD/MMMM/YYYY",
                                minDate: moment(),
                                ignoreReadonly: true
                            });
                        });

                        $('.dp').on('change', function () {
                            $('.datepicker').hide();
                        });


                        $('.dp').click(function () {
                            $('.datepicker').click();
                        });

                    </script>
                </div>
            </div>
        <div class="col-xs-6"></div>
    </div>
    <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="LVAuctionCars">Auction Cars:</label>
        <div class="col-xs-4 row-fluid">
            <asp:ListBox ID="LBAuctionCars" CssClass="form-control" runat="server" SelectionMode="Multiple"></asp:ListBox>
            <%--<asp:ListView ID="LVAuctionCars" runat="server">
                <ItemTemplate>
                    
                </ItemTemplate>
            </asp:ListView>--%>
        </div>
        <div class="col-xs-6"></div>
    </div>
    <div class=" col-xs-12"><hr /></div>
    <div class="btn-group col-xs-12">
        <asp:Button ID="BTNSubmit" runat="server" CssClass="btn btn-primary" Text="Create New Auction" OnClick="BTNSubmit_Click" />
    </div>
</asp:Content>
