<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="AMS.Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>GST</h2>
        <asp:Label ID="Label1" runat="server" Text="Active GST:"></asp:Label><asp:DropDownList ID="DDLGST" runat="server" Width="162px" OnSelectedIndexChanged="DDLGST_SelectedIndexChanged"></asp:DropDownList>
        <br />
        <asp:Label ID="Label2" runat="server" Text="New GST (%):"></asp:Label><asp:TextBox ID="TXTNewGST" runat="server" Width="127px" ></asp:TextBox>
        <br />
        <asp:Button ID="BTNAddNewGST" runat="server" Text="Add New GST" Width="265px" OnClick="BTNAddNewGST_Click" />
    </div>
    <div class="jumbotron">
        <h2>Condition status</h2>
        <asp:GridView ID="GVConditionStatus" runat="server"></asp:GridView>
    </div>
    <div class="jumbotron">
        <h2>Fee Types</h2>
        <asp:GridView ID="GVFeeTypes" runat="server"></asp:GridView>
    </div>
    <div class="jumbotron">
        <h2>Payment Types</h2>
        <asp:GridView ID="GVPaymentTypes" runat="server"></asp:GridView>
    </div>
</asp:Content>
