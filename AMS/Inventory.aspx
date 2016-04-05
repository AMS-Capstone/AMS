<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="AMS.Inventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Inventory</h1>
        <div class="col-xs-12" id="AlertDiv" runat="server"></div>
        <div class="form-group row">
            <div class="col-xs-12 col-sm-7 col-md-7">
                <asp:ListBox ID="LBCarList" CssClass="form-control"  runat="server" Rows="10"></asp:ListBox>
            </div>
        </div>
    </div>
</asp:Content>
