<%@ Page Title="Vehicles" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vehicles.aspx.cs" Inherits="AMS.Vehicles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Vehicles</h1>
    
    <div class="row" id="AlertDiv" runat="server"></div>
    <div class="form-group row">
        <label class="control-label col-xs-12 col-sm-2" for="DDLSeller">Select Consigner:</label>
        <div class="col-xs-12 col-sm-5">
            <asp:DropDownList ID="DDLSeller" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>
    </div>

    <div class="form-group row">
        <label class="control-label col-xs-12 col-sm-2" for="TXTLotNumber">Lot #:</label>
        <div class="col-xs-12 col-sm-5">
            <asp:TextBox ID="TXTLotNumber" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="form-group row">
        <label class="control-label col-xs-12 col-sm-2" for="TXTYear">Year:</label>
        <div class="col-xs-12 col-sm-5">
            <asp:TextBox ID="TXTYear" runat="server" CssClass="form-control numbersOnly"></asp:TextBox>
        </div>
    </div>

    <div class="form-group row">
        <label class="control-label col-xs-12 col-sm-2" for="TXTMake">Make:</label>
        <div class="col-xs-12 col-sm-5">
            <asp:TextBox ID="TXTMake" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="form-group row">
        <label class="control-label col-xs-12 col-sm-2" for="TXTModel">Model:</label>
        <div class="col-xs-12 col-sm-5">
            <asp:TextBox ID="TXTModel" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
  </div>

    <div class="form-group row">
        <label class="control-label col-xs-12 col-sm-2" for="TXTVin">VIN:</label>
        <div class="col-xs-12 col-sm-5">
            <asp:TextBox ID="TXTVin" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="form-group row">
        <label class="control-label col-xs-12 col-sm-2" for="TXTMileage">Mileage:</label>
        <div class="col-xs-7 col-sm-3">
            <asp:TextBox ID="TXTMileage" runat="server" CssClass="form-control numbersOnly"></asp:TextBox>
        </div>
        <div class="col-xs-5 col-sm-2">
            <asp:DropDownList runat="server" ID="DDLUnits" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>

    <div class="form-group row">
        <label class="control-label col-xs-12 col-sm-2" for="TXTTransmission">Transmission</label>
        <div class="col-xs-12 col-sm-5">
            <asp:TextBox ID="TXTTransmission" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="form-group row">
        <label class="control-label col-xs-12 col-sm-2" for="TXTColor">Color</label>
        <div class="col-xs-12 col-sm-5">
            <asp:TextBox ID="TXTColor" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="form-group row">
        <label class="control-label col-xs-12 col-sm-2" for="TXTOptions">Options</label>
        <div class="col-xs-12 col-sm-5">
            <asp:TextBox ID="TXTOptions" runat="server" CssClass="form-control" TextMode="MultiLine" ></asp:TextBox>
        </div>
    </div>    
        
    <div class="col-xs-12 col-sm-12"><hr /></div>

    <div class="form-group row">
        <div class="col-xs-12 col-sm-12">
            <asp:FileUpload ID="FUVehicle" CssClass="fileupload fileupload-new" runat="server" />
        </div>
        <div class="col-xs-12 col-sm-3">
            <asp:Button ID="BTNUpload" runat="server" CssClass="btn btn-primary" Text="Upload" OnClick="BTNUpload_Click" PostBackUrl="~/Vehicles.aspx" />
        </div>

                
        <%--<div class="col-xs-12 col-sm-12" id="ImageDiv" runat="server"></div>--%>
    </div>
    <style>
        .carousel-inner > .item > img,
        .carousel-inner > .item > a > img {
            width: 70%;
            height: auto;
            margin: auto;
        }
    </style>
    <div class="row"></div>
    <div class="col-xs-12 col-sm-5 col-lg=3">
        <div class="carousel slide" data-ride="carousel" id="actualCarousel">
            <div class="carousel-inner" role="listbox" id="imageCarousel" runat="server">
            </div>
            <a class="left carousel-control" href="#actualCarousel" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#actualCarousel" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>
    </div>
    <div class="col-xs-12 col-sm-12"><hr /></div>

    <div class="form-group row">        
        <div class="col-xs-12 col-sm-12">
            <asp:Button ID="BTNClear" runat="server" class="btn btn-warning" Text="Clear Form" OnClick="BTNClear_Click" />
        </div>
    </div>
    <div class="col-xs-12 col-sm-12"><hr /></div>
    
    <div class="form-group row">
        <div class="col-xs-12 col-sm-12">
            <asp:Button ID="BTNSubmit" runat="server" CssClass="btn btn-primary" Text="Create" OnClick="BTNSubmit_Click" />
            <asp:Button ID="BTNUpdate" runat="server" CssClass="btn btn-primary hidden"  Text="Update" OnClick="BTNUpdate_Click" />
        </div>
    </div>    
    <script type="text/javascript">
        jQuery('.numbersOnly').keyup(function () {
            this.value = this.value.replace(/[^0-9\.]/g, '');
        });
    </script>
</asp:Content>
