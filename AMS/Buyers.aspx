<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Buyers.aspx.cs" Inherits="AMS.Buyers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 
    <div class="control-group">
        <label class="control-label col-xs-3" for="DDLBuyerName">Select Existing Buyer:</label>
        <div class="col-xs-9">
            <asp:DropDownList class="form-control" ID="DDLBuyerName" runat="server"></asp:DropDownList>
        </div>         
    </div>
    <br />
    <div class="control-group">
        <label class="control-label col-xs-3" for="TXTFirstName">First Name:</label>
        <div class="col-xs-9">
            <asp:TextBox ID="TXTFirstName" runat="server" CssClass="form-control" placeholder="First Name"/>
        </div>
    </div>
    <br />
    <div class="control-group">
        <label class="control-label col-xs-3" for="TXTLastName">Last Name:</label>
        <div class="col-xs-9">
            <asp:TextBox ID="TXTLastName" runat="server" CssClass="form-control" placeholder="Last Name"/>
        </div>
    </div>    
    <br />
    <div class="control-group">
        <label class="control-label col-xs-3" for="TextBox1">Bidder #:</label>
        <div class="col-xs-3">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Bidder Number"/>
            <div class="checkbox">
                <label><input type="checkbox" id="Permanent">Permanent</label>
            </div>
        </div>
    </div>
    <br />
    <div class="control-group">
        <label class="control-label col-xs-3" for="TextBox2">Last Name:</label>
        <div class="col-xs-9">
            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Last Name"/>
        </div>
    </div>
    <br />
</asp:Content>
