<%@ Page Title="Auction" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuctionMain.aspx.cs" Inherits="AMS.AuctionMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Auction: </h1>
    <style type="text/css" media="print">
        .NonPrintable{
            display: none;
        }
    </style>
    <div class="row" id="AlertDiv" runat="server"></div>

    <div class="row">
        <div class="form-group col-xs-12">
            <asp:GridView ID="GVAuction" runat="server" CssClass="table table-hover col-xs-12" 
                AutoGenerateColumns="False" OnRowDataBound="RowDataBound" OnRowEditing="gv_RowEditing" 
                OnRowUpdating="gv_RowUpdating" OnRowCancelingEdit="gv_RowCancelingEdit" OnRowDeleting="gv_RowDeleting">
                <Columns>
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True"/>
                    <asp:TemplateField  HeaderText="AuctionSaleID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblAuctionSaleID" runat="server" Text='<%# Eval("AuctionSaleID") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblAuctionSaleID" runat="server" Text='<%# Eval("AuctionSaleID") %>'/>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField  HeaderText="VehicleID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblVehicleID" runat="server" Text='<%# Eval("VehicleID") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblVehicleID" runat="server" Text='<%# Eval("VehicleID") %>'/>
                        </EditItemTemplate>
                    </asp:TemplateField>
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
                            <asp:Label ID="lblBidderNumber" runat="server"/>
                            <asp:Label ID="lblBuyerID" runat="server" Text='<%# Eval("BuyerID") %>' Visible="false" />
                            <asp:DropDownList ID="DDLBidderNumbers" runat="server"  OnSelectedIndexChanged="DDLBidderNumbers_SelectedIndexChanged" AutoPostBack="true" Visible="false"></asp:DropDownList>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblBidderNumber" runat="server" Visible="false" />
                            <asp:Label ID="lblBuyerID" runat="server" Text='<%# Eval("BuyerID") %>' Visible="false" />
                            <asp:DropDownList ID="DDLBidderNumbers" runat="server"  OnSelectedIndexChanged="DDLBidderNumbers_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>                   
                    <asp:TemplateField  HeaderText="Sale Status">
                        <ItemTemplate>
                            <asp:Label ID="lblSaleStatus" runat="server"/>
                            <asp:Label ID="lblConditionID" runat="server" Text='<%# Eval("ConditionID") %>' Visible="false" />
                            <asp:DropDownList ID="DDLSaleStatuses" runat="server" OnSelectedIndexChanged="DDLSaleStatuses_SelectedIndexChanged" AutoPostBack="true" Visible="false"></asp:DropDownList>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblSaleStatus" runat="server" Visible="false"/>
                            <asp:Label ID="lblConditionID" runat="server" Text='<%# Eval("ConditionID") %>' Visible="false" />
                            <asp:DropDownList ID="DDLSaleStatuses" runat="server" OnSelectedIndexChanged="DDLSaleStatuses_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>   
                    <%--<asp:BoundField HeaderText="Selling Price" DataField="SellingPrice" DataFormatString="{0:c}" />--%>
                    <asp:TemplateField  HeaderText="Selling Price">
                        <ItemTemplate>
                            <asp:Label ID="lblSellingPrice" runat="server" Text='<%# Eval("SellingPrice", "{0:c}") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtSellingPrice" runat="server" Text='<%# Eval("SellingPrice") %>'/>
                        </EditItemTemplate>
                    </asp:TemplateField> 
                    <%--<asp:BoundField HeaderText="Buyer's Fee" DataField="BuyersFee" DataFormatString="{0:c}" />--%>
                    <asp:TemplateField  HeaderText="Buyer's Fee">
                        <ItemTemplate>
                            <asp:Label ID="lblBuyersFee" runat="server" Text='<%# Eval("BuyersFee", "{0:c}") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtBuyersFee" runat="server" Text='<%# Eval("BuyersFee") %>'/>
                        </EditItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField  HeaderText="GST">
                        <ItemTemplate>
                            <asp:Label ID="lblGST" runat="server" Text='<%# Eval("GST", "{0:c}") %>' DataFormatString="{0:c}" Visible="true" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField  HeaderText="Total">
                        <ItemTemplate>
                            <asp:Label ID="lblTotal" runat="server" Text='<%# Eval("Total", "{0:c}") %>' DataFormatString="{0:c}" Visible="true" />
                        </ItemTemplate>
                    </asp:TemplateField>
            
                    <asp:BoundField HeaderText="Deposit" DataField="Deposit" DataFormatString="{0:c}" />
                    <%--<asp:TemplateField  HeaderText="Deposit">
                        <ItemTemplate>
                            <asp:Label ID="lblDeposit" runat="server" Text='<%# Eval("Deposit", "{0:c}") %>' DataFormatString="{0:c}" Visible="true" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <div class="col-sm-2">
                                <asp:TextBox ID="txtDeposit" CssClass="form-control numbersOnly" runat="server" Text='<%# Eval("Deposit", "{0:c}") %>' DataFormatString="{0:c}" Visible="true" />
                            </div>
                        </EditItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField  HeaderText="Payments">
                        <ItemTemplate>
                            <asp:Label ID="lblPayments" runat="server" Text='<%# Eval("Payments", "{0:c}") %>' DataFormatString="{0:c}" Visible="true" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblPayments" runat="server" Text='<%# Eval("Payments", "{0:c}") %>' DataFormatString="{0:c}" Visible="true" />
                            <button type="button" class="btn btn-xs" data-toggle="modal" title="Add Payment" data-target="#paymentModal">Add</button>
                            <%--<asp:Button ID="btnAddPayment" runat="server" Text="Add" OnClick="btnAddPayment_Click"/>--%>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField  HeaderText="Surcharges">
                        <ItemTemplate>
                            <asp:Label ID="lblSurcharges" runat="server" Text='<%# Eval("Surcharges", "{0:c}") %>' DataFormatString="{0:c}" Visible="true" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField  HeaderText="Net Total">
                        <ItemTemplate>
                            <asp:Label ID="lblNetTotal" runat="server" Text='<%# Eval("NetTotal", "{0:c}") %>' DataFormatString="{0:c}" Visible="true" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function(){
            $('[data-toggle="tooltip"]').tooltip(); 
        });

        function openPaymentModal() {
            $('#paymentModal').modal('show');
        }

        jQuery('.numbersOnly').keyup(function () {
            this.value = this.value.replace(/[^0-9\.]/g, '');
        });
    </script>
    <style>
        .modal-body .form-horizontal .col-sm-2,
        .modal-body .form-horizontal .col-sm-10 {
            width: 100%
        }

        .modal-body .form-horizontal .control-label {
            text-align: left;
        }
        .modal-body .form-horizontal .col-sm-offset-2 {
            margin-left: 15px;
        }
    </style>

    <!-- Modals -->

    <div id="paymentModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Add Payment Form</h4>
                </div>
                <div class="modal-body row">
                    <div id="ULContainer" runat="server"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label" for="txtPayment">Payment</label>
                        <div class="col-sm-9">
                            <asp:TextBox runat="server" CssClass="form-control numbersOnly TXTPayment" ID="TXTPayment" DataFormatString="{0:c}" placeholder="Payment"/>                        
                            <script type="text/javascript">
                                jQuery('.numbersOnly').keyup(function () {
                                    this.value = this.value.replace(/[^0-9\.]/g, '');
                                });

                                $('.TXTPayment').on('change', function () {
                                    $(".hiddenList").each(function (index) {
                                        $percent = $(this).text();
                                        if (index == $(".DDLPaymentTypes").prop('selectedIndex')) {
                                            $(".TXTSurcharge").val(format($percent * $('.TXTPayment').val()));
                                        }
                                    });
                                });

                                var format = function (num) {
                                    var str = num.toString().replace("$", ""), parts = false, output = [], i = 1, formatted = null;
                                    if (str.indexOf(".") > 0) {
                                        parts = str.split(".");
                                        str = parts[0];
                                    }
                                    str = str.split("").reverse();
                                    for (var j = 0, len = str.length; j < len; j++) {
                                        if (str[j] != ",") {
                                            output.push(str[j]);
                                            if (i % 3 == 0 && j < (len - 1)) {
                                                output.push(",");
                                            }
                                            i++;
                                        }
                                    }
                                    formatted = output.reverse().join("");
                                    return ("$" + formatted + ((parts) ? "." + parts[1].substr(0, 2) : ""));
                                };
                            </script>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label" for="DDLPaymentTypes">Payment Type</label>
                        <div class="col-sm-9">
                            <asp:DropDownList ID="DDLPaymentTypes" CssClass="form-control DDLPaymentTypes" runat="server"></asp:DropDownList>                       
                            <script type="text/javascript">
                                $('.DDLPaymentTypes').on('change', function () {
                                    $(".hiddenList").each(function (index) {
                                        $percent = $(this).text();
                                        if (index == $(".DDLPaymentTypes").prop('selectedIndex')) {
                                            $(".TXTSurcharge").val(format($percent * $('.TXTPayment').val()));
                                        }
                                    });
                                });
                            </script>
                            <asp:Label ID="LBLSurchargeInPercent" runat="server"></asp:Label>
                        </div>
                    </div>                
                    <div class="form-group">
                        <label class="col-sm-3 control-label" for="lblSurcharge">Surcharge</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="TXTSurcharge" CssClass="form-control numbersOnly TXTSurcharge" runat="server"></asp:TextBox>                
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnAddPayment" runat="server" class="btn btn-primary" Text="Add Payment" OnClick="btnAddPayment_Click" />
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <div id="carListModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Add Payment Form</h4>
                </div>
                <div class="modal-body row">
                </div>
                <div class="modal-footer">
                    <a class="btn btn-success nonPrintable" href="javascript:window.print()">PRINT</a> <%--This code will launch print preview mode for the modal--%>
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
    
    <div class="btn-group row col-xs-12">
        <a class="btn btn-success nonPrintable" href="javascript:window.print()">Calculate Auction Totals</a> <%--This code will launch current page into page preview mode--%>
        <asp:Button ID="BTNGenerateAuctionCarList" runat="server" CssClass="btn btn-default " Text="Print Auction Car List" OnClick="BTNGenerateAuctionCarList_Click" />
        <asp:Button ID="BTNTotals" runat="server" CssClass="btn btn-primary" Text="Calculate Auction Totals" OnClick="BTNTotals_Click" />
        <button type="button" class="btn btn-xs" data-toggle="modal" title="Car List Modal" data-target="#carListModal">CarListModal</button>
    </div>
    
</asp:Content>
