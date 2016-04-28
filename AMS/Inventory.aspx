<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="AMS.Inventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Inventory</h1>
        <div class="row" id="AlertDiv" runat="server"></div>
        <div class="form-group row">
            <div class="col-xs-12 col-sm-7 col-md-7">
                <asp:ListBox ID="LBCarList" CssClass="form-control"  runat="server" Rows="10" OnSelectedIndexChanged="LBCarList_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
            </div>
        </div>
        <div class="form-group row" id="ConcealAddDiv" runat="server">
            <div class="col-xs-12">
                <asp:Button ID="BTNAddVehicles" runat="server" CssClass="btn btn-primary" Text="Add Vehicles to the Auction" OnClick="BTNAddVehicles_Click" />
            </div>
        </div>
        <div id="ConcealDiv" runat="server">
            <div class="form-group row">
                <div class="col-xs-12">
                    <asp:Button ID="BTNEditCarDetails" runat="server" CssClass="btn btn-primary" Text="Edit Car Details" OnClick="BTNEditCarDetails_Click" />
                </div>
            </div>
            <div class="row"><hr /></div> 
                
            <div class="form-group row">        
                <div class="col-xs-12 col-sm-3 col-sm-offset-2">
                    <div class="checkbox">
                        <label><asp:CheckBox runat="server" id="CHKForSale" Text="For Sale"></asp:CheckBox></label>
                    </div>
                </div>
            </div>

            <div class="control-group row">
                <label class="control-label col-xs-12 col-sm-3 col-md-3 col-lg-2" for="TXTDate">Date In:</label>
                    <div class="container">
                        <div class="form-group">
                            <div class='input-group date col-xs-12 col-sm-7 col-md-7 col-lg-5' id='datetimepicker1'>
                                <input type='text' class="form-control dp" id="TXTDate" runat="server" />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>
                        </div>
                    </div>
                    <script type="text/javascript">
                        $(function () {
                            $('#datetimepicker1').datetimepicker({
                                format: "DD/MMMM/YYYY",
                                minDate: moment(),
                                ignoreReadonly: true
                            });
                        });

                        $(document).ready(function () {
                            $("#datetimepicker1").attr('readonly', 'readonly');
                        });

                        $('.dp').on('change', function () {
                            $('.datepicker').hide();
                        });

                        //window.setTimeout(function () { $(".alert").alert('close'); }, 10000);
                    </script>
                <div class="col-xs-6"></div>
            </div>

            <div class="form-group row">
                <label class="control-label col-xs-12 col-sm-2" for="TXTReserve">Reserve:</label>
                <div class="col-xs-12 col-sm-5">
                    <asp:TextBox ID="TXTReserve" runat="server" CssClass="form-control numbersOnly" placeholder="$0.00"/>
                </div>
            </div>

            <div class="form-group row">
                <label class="control-label col-xs-12 col-sm-2" for="TXTEstValue">Estimated:</label>
                <div class="col-xs-12 col-sm-5">
                    <asp:TextBox ID="TXTEstValue" runat="server" CssClass="form-control numbersOnly" placeholder="$0.00"/>
                </div>
            </div>
                
            <div class="form-group row">        
                <div class="col-xs-12 col-sm-3 col-sm-offset-2">
                    <div class="checkbox">
                        <label><asp:CheckBox runat="server" id="CHKRecord" Text="Record"></asp:CheckBox></label>
                    </div>
                </div>
            </div>
                
            <div class="form-group row">        
                <div class="col-xs-12 col-sm-3 col-sm-offset-2">
                    <div class="checkbox">
                        <label><asp:CheckBox runat="server" id="CHKCallOnHigh" Text="Call On High"></asp:CheckBox></label>
                    </div>
                </div>
            </div>
            
            <div class="form-group row">
                <label class="control-label col-xs-12 col-sm-2" for="TXTComments">Comments</label>
                <div class="col-xs-12 col-sm-5">
                    <asp:TextBox ID="TXTComments" runat="server" CssClass="form-control" TextMode="MultiLine" ></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <label class="control-label col-xs-12 col-sm-2" for="LBFees">Fees:</label>
                <div class="col-xs-12 col-sm-5">
                    <asp:ListBox ID="LBFees" CssClass="form-control"  runat="server" Rows="10"></asp:ListBox>
                </div>
            </div>
            
            <div class="form-group row">
                <div class="col-xs-12 col-sm-offset-2 col-sm-5">
                    <button type="button" class="btn btn-primary" data-toggle="modal" title="Add Fee" data-target="#addFeeModal" id="BTNAddModal" visible="false" runat="server">Add</button>
                </div>         
            </div>

            <div class="form-group row">
                <div class="col-xs-12 col-sm-10 col-sm-offset-2">
                    
                </div>
            </div>

            

            <div id="addFeeModal" class="modal fade" role="dialog">
                <div class="modal-dialog">
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Add Fee Form</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row"></div>
                            <%-- TODO: Implement Fee Dropdown control
                            TODO: implement Cost TextBox--%>
                            <div class="form-group row">
                                <label class="control-label col-xs-12 col-sm-2" for="DDLFeeType">Fee Type:</label>
                                <div class="col-xs-12 col-sm-5">
                                    <asp:DropDownList class="form-control" ID="DDLFeeType" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            
                            <div class="form-group row">
                                <label class="control-label col-xs-12 col-sm-2" for="TXTCost">Cost:</label>
                                <div class="col-xs-12 col-sm-5">
                                    <asp:TextBox ID="TXTCost" runat="server" CssClass="form-control numbersOnly"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="BTNAdd" runat="server" CssClass="btn btn-primary"  Text="Add Fees" OnClick="BTNAdd_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="row"><hr /></div>
            <div class="form-group row">
                <div class="col-xs-12">
                    <asp:Button ID="BTNUpdate" runat="server" CssClass="btn btn-primary"  Text="Update Conditions and Requirements" OnClick="BTNUpdate_Click" />
                </div>
            </div>
        </div>
    </div>    
    <script type="text/javascript">
        jQuery('.numbersOnly').keyup(function () {
            this.value = this.value.replace(/[^0-9\.]/g, '');
        });
    </script>
</asp:Content>
