<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vehicles.aspx.cs" Inherits="AMS.Vehicles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Vehicles</h1>
    <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="DDLSeller">Select Consigner:</label>
        <div class="col-xs-9">
            <asp:DropDownList ID="DDLSeller" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>
    </div>
    <div class=" col-xs-12">  </div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="TXTLotNumber">Lot #:</label>
        <div class="col-xs-3">
            <asp:TextBox ID="TXTLotNumber" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="TXTYear">Year:</label>
        <div class="col-xs-3">
            <asp:TextBox ID="TXTYear" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
        <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="TXTMake">Make:</label>
        <div class="col-xs-3">
            <asp:TextBox ID="TXTMake" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
            <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="TXTModel">Model:</label>
        <div class="col-xs-3">
            <asp:TextBox ID="TXTModel" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
  </div>
        <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="TXTVin">VIN:</label>
        <div class="col-xs-3">
            <asp:TextBox ID="TXTVin" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
  </div>
           <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="TXTMileage">Mileage:</label>
        <div class="col-xs-3">
            <asp:TextBox ID="TXTMileage" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-xs-2">
            <asp:DropDownList runat="server" ID="DDLUnits" CssClass="form-control"></asp:DropDownList>
        </div>
  </div>
    <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="TXTTransmission" CssClass="form-control">Transmission</label>
        <div class="col-xs-3">
                        <asp:TextBox ID="TXTTransmission" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="TXTColor" CssClass="form-control">Color</label>
        <div class="col-xs-3">
                        <asp:TextBox ID="TXTColor" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="TXTOptions" CssClass="form-control">Options</label>
        <div class="col-xs-3">
            <asp:TextBox ID="TXTOptions" runat="server" CssClass="form-control" TextMode="MultiLine" ></asp:TextBox>
        </div>
    </div>
        <div class=" col-xs-12"></div>
      <div class="btn-group col-xs-12">
         <asp:Button ID="BTNSaveVehicle" runat="server" CssClass="btn btn-primary" Text="Save" />
        </div>


    
  
</asp:Content>
