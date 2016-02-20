<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Buyers.aspx.cs" Inherits="AMS.Buyers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Buyers</h1>
    <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="DDLBuyerName">Select Buyer:</label>
        <div class="col-xs-9">
            <asp:DropDownList class="form-control" ID="DDLBuyerName" runat="server"></asp:DropDownList>
        </div>         
    </div>
    <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="TXTFirstName">First Name:</label>
        <div class="col-xs-9">
            <asp:TextBox ID="TXTFirstName" runat="server" CssClass="form-control" placeholder="First Name"/>
        </div>
    </div>
    <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="TXTLastName">Last Name:</label>
        <div class="col-xs-9">
            <asp:TextBox ID="TXTLastName" runat="server" CssClass="form-control" placeholder="Last Name"/>
        </div>
    </div>    
    <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="TXTBidNum">Bidder #:</label>
        <div class="col-xs-3">
            <asp:TextBox ID="TXTBidNum" runat="server" CssClass="form-control" placeholder="Bidder Number" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/>
            <div class="checkbox">
                <label><asp:CheckBox runat="server" id="CHKPermanent" Text="Permanent"></asp:CheckBox></label>
            </div>
        </div>
    </div>
    <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="TXTAddress">Address:</label>
        <div class="col-xs-9">
            <asp:TextBox ID="TXTAddress" runat="server" CssClass="form-control" placeholder="Address"/>
        </div>
    </div>
    <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="TXTCIty">City:</label>
        <div class="col-xs-9">
            <asp:TextBox ID="TXTCIty" runat="server" CssClass="form-control" placeholder="City"/>
        </div>
    </div>
    <div class=" col-xs-12"></div>
    
    <div class="control-group">
        <label class="control-label col-xs-2" for="DDLProvince">Province:</label>
        <div class="col-xs-9">
            <asp:DropDownList class="form-control" ID="DDLProvince" runat="server"></asp:DropDownList>
        </div>         
    </div>
    <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="TXTPostal">Postal Code:</label>
        <div class="col-xs-9">
            <asp:TextBox ID="TXTPostal" runat="server" CssClass="form-control" placeholder="Postal Code"/>
        </div>
    </div>
    <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="TXTPhone">Phone:</label>
        <div class="col-xs-9">
            <asp:TextBox ID="TXTPhone" runat="server" CssClass="form-control" placeholder="Phone"/>
        </div>
    </div>
    <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="TXTDLicense">Driver's License:</label>
        <div class="col-xs-9">
            <asp:TextBox ID="TXTDLicense" runat="server" CssClass="form-control" placeholder="Driver's License"/>
        </div>
    </div>
    <div class=" col-xs-12"></div>
    <div class=" col-xs-2"></div>
    <div class="control-group">
        
        <div class="col-xs-3">
            
            <div class="checkbox">
                <label><asp:CheckBox runat="server" id="CHKBanned" Text="Banned"></asp:CheckBox></label>
            </div>
        </div>
    </div>
    <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="TXTNotes">Notes:</label>
        <div class="col-xs-9 row-xs-3">
            <asp:TextBox ID="TXTNotes" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="Notes"/>
        </div>
    </div>
    
    <div class="col-xs-12"></div>
    <div class="btn-group col-xs-12">
        <asp:Button ID="BTNClear" runat="server" class="btn btn-warning" Text="Clear Form" OnClick="BTNClear_Click" />
    </div>
    <div class=" col-xs-12"><hr /></div>
    <div class="btn-group col-xs-12">
        <asp:Button ID="BTNSubmit" runat="server" class="btn btn-primary" Text="Submit Form" OnClick="BTNSubmit_Click" />
        <asp:Button ID="Button1" runat="server" class="btn btn-primary hide" disabled="true" Text="Update Form" />
        <asp:Button ID="Button2" runat="server" class="btn btn-primary hide" disabled="true" Text="Delete Form" />
    </div>
</asp:Content>
