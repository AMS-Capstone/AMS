<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuctionMain.aspx.cs" Inherits="AMS.AuctionMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Auction: </h1>
    
    <div class=" col-xs-12" id="AlertDiv" runat="server"></div>

    <asp:GridView ID="GVAuction" runat="server" CssClass="table table-hover col-xs-12" 
        AutoGenerateColumns="False" OnRowDataBound="RowDataBound" OnRowEditing="gv_RowEditing" 
        OnRowUpdating="gv_RowUpdating" OnRowCancelingEdit="gv_RowCancelingEdit" >         
        <Columns>
            <asp:TemplateField  HeaderText="Con Code">
                <ItemTemplate>
                    <asp:Label ID="lblSellerCode" runat="server" Text='<%# Eval("SellerCode") %>' Visible="true" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField  HeaderText="Lot #">
                <ItemTemplate>
                    <asp:Label ID="lblLotNumber" runat="server" Text='<%# Eval("LotNumber") %>' Visible="true" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Bidder #">
                <ItemTemplate>
                    <asp:Label ID="lblBidderNumber" runat="server" Text='<%# Eval("BuyerID") %>' Visible="false" />
                    <asp:DropDownList ID="DDLBidderNumbers" runat="server"  OnSelectedIndexChanged="DDLBidderNumbers_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>                   
            <asp:TemplateField  HeaderText="Sale Status">
                <ItemTemplate>
                    <asp:Label ID="lblSaleStatus" runat="server" Text='<%# Eval("ConditionID") %>' Visible="false" />
                    <asp:DropDownList ID="DDLSaleStatuses" runat="server" OnSelectedIndexChanged="DDLSaleStatuses_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>   
            <asp:BoundField HeaderText="Selling Price" DataField="SellingPrice" DataFormatString="{0:c}" />
            <asp:BoundField HeaderText="AuctionSaleID" DataField="AuctionSaleID" Visible="false"/>
            <asp:BoundField HeaderText="Buyer's Fee" DataField="BuyersFee" DataFormatString="{0:c}" />
            <%--<asp:BoundField HeaderText="GST" DataField="GST" DataFormatString="{0:c}" />--%><%--Auto-calculated and stored field--%>
            <asp:TemplateField  HeaderText="GST">
                <ItemTemplate>
                    <asp:Label ID="lblGST" runat="server" Text='<%# Eval("GST", "{0:c}") %>' DataFormatString="{0:c}" Visible="true" />
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:BoundField HeaderText="Total" DataField="Total" DataFormatString="{0:c}" />--%><%--Auto-calculated and stored field--%>
            <asp:TemplateField  HeaderText="Total">
                <ItemTemplate>
                    <asp:Label ID="lblTotal" runat="server" Text='<%# Eval("Total", "{0:c}") %>' DataFormatString="{0:c}" Visible="true" />
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:BoundField HeaderText="Deposit" DataField="Deposit" DataFormatString="{0:c}" />--%>
            <asp:TemplateField  HeaderText="Deposit">
                <ItemTemplate>
                    <asp:Label ID="lblDeposit" runat="server" Text='<%# Eval("Deposit", "{0:c}") %>' DataFormatString="{0:c}" Visible="true" />
                    <button type="button" class="btn btn-primary btn-xs" data-toggle="modal" title="Add Deposit" data-target="#depositModal">Add Deposit</button>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:BoundField HeaderText="Payments" DataField="PaymentsTotal" DataFormatString="{0:c}" />--%><%--Payments will show a total with the link to the popup that would add a new payment--%>
            <asp:TemplateField  HeaderText="Payments">
                <ItemTemplate>
                    <asp:Label ID="lblPayments" runat="server" Text='<%# Eval("Payments", "{0:c}") %>' DataFormatString="{0:c}" Visible="true" />
                    <button type="button" class="btn btn-primary btn-xs" data-toggle="modal" title="Add Payment" data-target="#paymentModal">Add Payment</button>
                    <%--<asp:Button ID="btnAddPayment" runat="server" Text="Add" data-target="#paymentModal" OnClick="btnAddPayment_Click"/>--%>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:BoundField HeaderText="Surcharges" DataField="SurchargesTotal" DataFormatString="{0:c}" />--%><%--Auto-calculated and stored field--%>
            <asp:TemplateField  HeaderText="Surcharges">
                <ItemTemplate>
                    <asp:Label ID="lblSurcharges" runat="server" Text='<%# Eval("Surcharges", "{0:c}") %>' DataFormatString="{0:c}" Visible="true" />
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:BoundField HeaderText="Net Total" DataField="NetTotal" DataFormatString="{0:c}" />--%><%--Auto-calculated and stored field--%>
            <asp:TemplateField  HeaderText="Net Total">
                <ItemTemplate>
                    <asp:Label ID="lblNetTotal" runat="server" Text='<%# Eval("NetTotal", "{0:c}") %>' DataFormatString="{0:c}" Visible="true" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" visible="false"/>
        </Columns>
    </asp:GridView>
    <script type="text/javascript">
        $(document).ready(function(){
            $('[data-toggle="tooltip"]').tooltip(); 
        });
        
        function openPaymentModal() {
            $('#paymentModal').modal('show');
        }
        function openDepositModal() {
            $('#depositModal').modal('show');
        }
    </script>
    <!-- Modals -->
    <div id="paymentModal" class="modal fade" role="dialog">
        <div class="modal-dialog <%--modal-sm--%>">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Add Payment Form</h4>
                </div>
                <div class="modal-body">
                    <p>Some text in the modal.</p>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnAddPayment" runat="server" CssClass="btn btn-primary" Text="Add Payment" OnClick="btnAddPayment_Click" />
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <!-- End of Modals -->

    <div class=" col-xs-12"></div>
   <%-- <div class="control-group">
        <label class="control-label col-xs-1" for="TXTNotes">Notes:</label>
        <div class="col-xs-5 row-xs-3">
            <asp:TextBox ID="TXTNotes" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="Notes"/>
        </div>
    </div>--%>
    <div class="btn-group col-xs-12">
        <asp:Button ID="BTNTotals" runat="server" CssClass="btn btn-primary pull-right" Text="Calculate Auction Totals" OnClick="BTNTotals_Click" />
    </div>
</asp:Content>
