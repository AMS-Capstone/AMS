<%@ Page Title="Sellers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sellers.aspx.cs" Inherits="AMS.Sellers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Sellers</h1>
    <div class=" col-xs-12" id="AlertDiv" runat="server"></div>
    <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="DDLSellerName">Select Seller:</label>
        <div class="col-xs-9">
            <asp:DropDownList CssClass="form-control" ID="DDLSellerName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLSellerName_SelectedIndexChanged"></asp:DropDownList>
        </div>         
    </div>
    <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="TXTCode">Code:</label>
        <div class="col-xs-9">
            <asp:TextBox ID="TXTCode" runat="server" CssClass="form-control" placeholder="Code"/>
        </div>
    </div>
    <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="TXTName">Name:</label>
        <div class="col-xs-9">
            <asp:TextBox ID="TXTName" runat="server" CssClass="form-control" placeholder="Name"/>
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
        <label class="control-label col-xs-2" for="TXTCity">City:</label>
        <div class="col-xs-9">
            <asp:TextBox ID="TXTCity" runat="server" CssClass="form-control" placeholder="City"/>
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
        <label class="control-label col-xs-2" for="TXTOtherPhone">Other Phone:</label>
        <div class="col-xs-9">
            <asp:TextBox ID="TXTOtherPhone" runat="server" CssClass="form-control" placeholder="Other Phone"/>
        </div>
    </div>
    <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="TXTFax">Fax:</label>
        <div class="col-xs-9">
            <asp:TextBox ID="TXTFax" runat="server" CssClass="form-control" placeholder="Fax"/>
        </div>
    </div>
    <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="TXTFirstName">Contact First Name:</label>
        <div class="col-xs-9">
            <asp:TextBox ID="TXTFirstName" runat="server" CssClass="form-control" placeholder="Contact First Name"/>
        </div>
    </div>
    <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="TXTLastName">Contact Last Name:</label>
        <div class="col-xs-9">
            <asp:TextBox ID="TXTLastName" runat="server" CssClass="form-control" placeholder="Contact Last Name"/>
        </div>
    </div>
    <div class=" col-xs-12"></div>
    <div class="control-group">
        <label class="control-label col-xs-2" for="TXTGSTNumber">GST Number:</label>
        <div class="col-xs-9">
            <asp:TextBox ID="TXTGSTNumber" runat="server" CssClass="form-control" placeholder="GST Number"/>
        </div>
    </div>
    <div class=" col-xs-12"></div>
    <div class=" col-xs-2"></div>
    <div class="control-group">
        
        <div class="col-xs-3">
            
            <div class="checkbox">
                <label><asp:CheckBox runat="server" id="CHKPrivate" Text="Private"></asp:CheckBox></label>
            </div>
        </div>
    </div>
    <div class="col-xs-12"></div>
    <div class="btn-group col-xs-12">
        <asp:Button ID="BTNClear" runat="server" class="btn btn-warning" Text="Clear Form" OnClick="BTNClear_Click" />
    </div>
    <div class=" col-xs-12"><hr /></div>
    <div class="control-group col-xs-12">
        <asp:Button ID="BTNSubmit" runat="server" CssClass="btn btn-primary" Text="Create" OnClick="BTNSubmit_Click" />
        <asp:Button ID="BTNUpdate" runat="server" CssClass="btn btn-primary hidden"  Text="Update" OnClick="BTNUpdate_Click" />
        <asp:Button ID="BTNDelete" runat="server" CssClass="btn btn-primary hidden" Text="Delete" OnClick="BTNDelete_Click" />
    </div>
</asp:Content>
