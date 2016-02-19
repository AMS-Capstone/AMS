<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Buyers.aspx.cs" Inherits="AMS.Buyers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
    <div class="container-fluid">
    <h1>BUYERS</h1>
        <asp:Table ID="Table2" runat="server">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">

                    <asp:Table ID="Table1" runat="server">
                        <asp:TableRow  ToolTip="Select a buyer from the list to edit">
                            <asp:TableCell HorizontalAlign="Right">
                                <asp:Label ID="Label1" runat="server" Text="Select Existing Buyer:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="345" HorizontalAlign="Left">
                                <asp:DropDownList Width="95%" ID="DDLBuyerName" runat="server"></asp:DropDownList>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right">
                                <asp:Label ID="Label9" runat="server" Text="First Name:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="345" HorizontalAlign="Left">
                                <asp:TextBox ID="TXTFirstName" Width="95%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right">
                                <asp:Label ID="Label11" runat="server" Text="Last Name:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Width="345" HorizontalAlign="Left">
                                <asp:TextBox ID="TXTLastName" Width="95%" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
            
                        <asp:TableRow><asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="Label2" runat="server" Text="BIDDER #:"></asp:Label></asp:TableCell><asp:TableCell HorizontalAlign="Left">
                                <asp:TextBox ID="TXTBidnum" Width="50%" runat="server"></asp:TextBox>&nbsp;<asp:CheckBox ID="CHKPermanent" Text="&nbsp;Permanent" runat="server"/>
                                </asp:TableCell>                
                        </asp:TableRow><asp:TableRow><asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="Label3" runat="server" Text="Address:"></asp:Label></asp:TableCell><asp:TableCell HorizontalAlign="Left">
                                <asp:TextBox ID="TXTAddress" Width="95%" runat="server"></asp:TextBox></asp:TableCell></asp:TableRow>
            
                        <asp:TableRow><asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="Label4" runat="server" Text="City:"></asp:Label></asp:TableCell><asp:TableCell HorizontalAlign="Left">
                                <asp:TextBox ID="TXTCity" Width="95%" runat="server"></asp:TextBox></asp:TableCell></asp:TableRow>
            
                        <asp:TableRow><asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="Label5" runat="server" Text="Province:"></asp:Label></asp:TableCell><asp:TableCell HorizontalAlign="Left">
                                <asp:TextBox ID="TXTProvince" Width="95%" runat="server"></asp:TextBox></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="Label6" runat="server" Text="Postal Code:"></asp:Label></asp:TableCell><asp:TableCell HorizontalAlign="Left">
                                <asp:TextBox ID="TXTPostalCode" Width="95%" runat="server"></asp:TextBox></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="Label7" runat="server" Text="Phone:"></asp:Label></asp:TableCell><asp:TableCell HorizontalAlign="Left">
                                <asp:TextBox ID="TXTPhone" Width="95%" runat="server"></asp:TextBox></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="Label8" runat="server" Text="Driver's License:"></asp:Label></asp:TableCell><asp:TableCell HorizontalAlign="Left">
                                <asp:TextBox ID="TXTDriversLicense" Width="95%" runat="server"></asp:TextBox></asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell HorizontalAlign="Left">
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left">
                                <asp:CheckBox ID="CHKBanned"  runat="server" Text="&nbsp;BANNED" Font-Bold="True" />
                                </asp:TableCell></asp:TableRow>
                        <asp:TableRow><asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="Label10" runat="server" Text="NOTES:"></asp:Label></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left">
                                <asp:TextBox ID="TXTNotes" Height="90px" TextMode="MultiLine" Columns="50" Rows="5" Width="95%" runat="server"></asp:TextBox></asp:TableCell></asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right">
                                <asp:Button ID="BTNClearForm" runat="server" Text="Clear Form" />
                            </asp:TableCell>

                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top" HorizontalAlign="Right">
                                <asp:Button ID="Button3" runat="server" Text="Save" />
                            </asp:TableCell>
                            <asp:TableCell  VerticalAlign="Middle" HorizontalAlign="Left">
                                <asp:Button ID="Button4" runat="server" Text="Update" Visible="false" />
                                <asp:Button ID="Button5" runat="server" Text="Delete" Visible="false" />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:TableCell>
                <%--<asp:TableCell>
                    <asp:Table runat="server" Height="100%" BorderStyle="Groove">
                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Top">
                                <asp:Image ID="IMGPicture" Height="250" Width="400" runat="server" BorderStyle="Groove" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" VerticalAlign="Bottom">
                                <asp:ListBox ID="LBPictureNames" Height="100" Width="100%" runat="server" ToolTip="Picture Names"></asp:ListBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell  HorizontalAlign="Right">
                                <asp:Button ID="Button1" runat="server" Text="Add File" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" Text="Remove Selected File" />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:TableCell>--%>
            </asp:TableRow>
        </asp:Table>
    </div>
        <div class="container-fluid">
    <div class="row">
        <div class="col-xs-4">
            <h2>HTML</h2>
            <p>HTML is a markup language that is used for creating web pages. The HTML tutorial section will help you understand the basics of HTML, so that you can create your own web pages or website.</p>
            <p><a href="http://www.tutorialrepublic.com/html-tutorial/" target="_blank" class="btn btn-success">Learn More &raquo;</a></p>
        </div>
        <div class="col-xs-4">
            <h2>CSS</h2>
            <p>CSS is used for describing the presentation of web pages. The CSS tutorial section will help you learn the essentials of CSS, so that you can fine control the style and layout of your HTML document.</p>
            <p><a href="http://www.tutorialrepublic.com/css-tutorial/" target="_blank" class="btn btn-success">Learn More &raquo;</a></p>
        </div>
        <div class="col-xs-4">
            <h2>Bootstrap</h2>
            <p>Bootstrap is a powerful front-end framework for faster and easier web development. The Bootstrap tutorial section will help you learn the techniques of Bootstrap so that you can create web your own website.</p>
            <p><a href="http://www.tutorialrepublic.com/twitter-bootstrap-tutorial/" target="_blank" class="btn btn-success">Learn More &raquo;</a></p>
        </div>
    </div>
    <hr>
    <div class="row">
        <div class="col-xs-12">
            <footer>
                <p>&copy; Copyright 2013 Tutorial Republic</p>
            </footer>
        </div>
    </div>
</div>
    </div>
</asp:Content>
