<%@ Page Title="Settings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="AMS.Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="col-xs-12" id="AlertDiv" runat="server"></div>
    <h1>GST</h1>
    
    <div class="form-group row">          
        <label class="control-label col-xs-12 col-sm-2" for="DDLGST" >GST:</label>
        <div class="col-xs-12 col-sm-10">
            <asp:DropDownList class="form-control" ID="DDLGST" runat="server" OnSelectedIndexChanged="DDLGST_SelectedIndexChanged1" AutoPostBack="true"></asp:DropDownList>
        </div>
    </div>
    
    
    <div class="form-group row" style="height: 29px">
        <label class="control-label col-xs-12 col-sm-2" for="TXTNewGST">Selected GST:</label> 
        <div class="col-xs-12 col-sm-10">
            <asp:TextBox ID="TXTNewGST" runat="server" Width="127px" ></asp:TextBox>
        </div>
    </div>

    
    <div class="form-group row">    
        <div class="col-xs-12 col-sm-10 col-sm-offset-2">            
            <div class="checkbox">
                <label><asp:CheckBox runat="server" id="CHKActive" Text="Active"></asp:CheckBox></label>
            </div>
        </div>
    </div>
    <div class="btn-group">
        <div class="col-xs-12">
            <asp:Button ID="BTNSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="BTNSave_Click" />
        </div>
    </div>
 
    <div class="col-xs-12"><hr/></div>
    <h1>Condition status</h1>    
    <div class="form-group row">        
        <div class="col-xs-12 col-sm-4">
            <asp:GridView ID="GRDConditionStatus" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" OnRowEditing="gv_RowEditing" OnRowUpdating="GRDConditionStatus_Updating" OnRowCancelingEdit="gv_RowCancelingEdit">
                <Columns>
                    <asp:CommandField ShowEditButton="true"/>
                    <asp:TemplateField HeaderText="ConditionID" visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblCondtionID" runat="server" Text='<%# Eval("ConditionID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                            <asp:Label ID="lblConditionCode" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtConditionCode" runat="server" CssClass="form-control col-xs-6"
                                Text='<%# Eval("Description") %>'>
                            </asp:TextBox>                               
                        </EditItemTemplate>
                    </asp:TemplateField>
                   <%--    <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCondtionDescription"   AutoPostBack="true" runat="server"
                                        Text='<%# Eval("Status") %>' ></asp:TextBox>
                               
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
        </div>
   <%-- <label class="control-label col-xs-2" for="DDLConditionStatus" >Condition Status:</label>
        <div class="col-xs-10">
            <asp:DropDownList class="form-control" ID="DDLConditionStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLConditionStatus_SelectedIndexChanged"></asp:DropDownList>
        </div>--%>
    </div>
    
 <%--   <div class=" col-xs-12"></div> 
    

    <div class=" col-xs-12"></div>
    <div class="form-group row">  
        <label class="control-label col-xs-2" for="TXTConditionCode" >Condition Code:</label>
        <div class="col-xs-10">
            <asp:TextBox ID="TXTConditionCode" runat="server" Width="127px" ></asp:TextBox>
        </div>
    </div>

    <div class=" col-xs-12">
        
    </div> 

    <div class=" col-xs-12"></div>
    <div class="form-group row">
        <label class="control-label col-xs-2" for="TXTConditionDescription" >Condition Description:</label>
        <div class="col-xs-10">
            <asp:TextBox ID="TXTConditionDescription" runat="server" Width="127px" ></asp:TextBox>
        </div>
    </div>

    <div class="btn-group col-xs-12">
        <asp:Button ID="BTNSaveConditionStatus" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="BTNSaveConditionStatus_Click" />
    </div>
  --%>





    <div class="col-xs-12"><hr /></div>
    <h1>Fee Types:</h1>
    
    <div class="form-group row">        
        <div class="col-xs-12 col-sm-4">
            <asp:GridView ID="GRDFeeTypes" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" OnRowEditing="gv_RowEditing" OnRowUpdating="GRDFeeTypes_Updating" OnRowCancelingEdit="gv_RowCancelingEdit">
                <Columns>
                    <asp:CommandField ShowEditButton="true"/>
                    <asp:TemplateField HeaderText="FeeID" visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblFeeID" runat="server" Text='<%# Eval("FeeID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cost">
                        <ItemTemplate>
                            <asp:Label ID="lblFeeCost" runat="server" Text='<%# Eval("FeeCost") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFeeCost" runat="server" CssClass="form-control col-xs-6 numbersOnly"
                                Text='<%# Eval("FeeCost") %>' ></asp:TextBox>                               
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                            <asp:Label ID="lblFeeDescription" runat="server" Text='<%# Eval("FeeType") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFeeDescription" runat="server" CssClass="form-control col-xs-6"
                                Text='<%# Eval("FeeType") %>' ></asp:TextBox>                               
                        </EditItemTemplate>
                    </asp:TemplateField>
                   <%--    <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCondtionDescription"   AutoPostBack="true" runat="server"
                                        Text='<%# Eval("Status") %>' ></asp:TextBox>
                               
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
        </div>
      <%--  <label class="control-label col-xs-2" for="DDLFeeTypes" >Fee Types:</label>
        <div class="col-xs-10">
            <asp:DropDownList class="form-control" ID="DDLFeeTypes" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLFeeTypes_SelectedIndexChanged" ></asp:DropDownList>
        </div>--%>
    </div>

   <%-- <div class=" col-xs-12">
    
    </div> 

    <div class=" col-xs-12">
    </div>
    <div class="form-group row">
          
    <label class="control-label col-xs-2" for="TXTFeeType" >Type:</label>
        <div class="col-xs-10">
            <asp:TextBox ID="TXTFeeType" runat="server" Width="127px" ></asp:TextBox>
                </div>
    </div>
    <div class=" col-xs-12">
    
    </div> 
    <div class=" col-xs-12">
    </div>
    <div class="form-group row">
          
    <label class="control-label col-xs-2" for="TXTConditionDescription" >Fee Cost:</label>
        <div class="col-xs-10">
    <asp:TextBox ID="TXTFeeCost" runat="server" Width="127px" ></asp:TextBox>
                </div>
    </div>
    <div class="btn-group col-xs-12">
    <asp:Button ID="BTNSaveFeeType" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="BTNSaveFeeType_Click" />
    </div>--%>


    <div class="col-xs-12"><hr /></div>
    <h1>Payment Types</h1>
    <div class="col-xs-12">
    </div>
    <div class="form-group row">
        <div class="col-xs-12 col-sm-4">
            <asp:GridView ID="GRDPaymentTypes" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" OnRowEditing="gv_RowEditing" OnRowUpdating="GRDPaymentTypes_Updating" OnRowCancelingEdit="gv_RowCancelingEdit">
                <Columns>
                    <asp:CommandField ShowEditButton="true"/>
                    <asp:TemplateField HeaderText="PaymentTypeID" visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblPaymentTypeID" runat="server" Text='<%# Eval("PaymentTypeId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Type">
                        <ItemTemplate>
                            <asp:Label ID="lblPaymentType" runat="server" Text='<%# Eval("PaymentDescription") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPaymentType" runat="server" CssClass="form-control col-xs-6"
                                Text='<%# Eval("PaymentDescription") %>'></asp:TextBox>                             
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Surcharge">
                        <ItemTemplate>
                            <asp:Label ID="lblSurcharge" runat="server" Text='<%# Eval("SurchargeInPercent") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtSurcharge" runat="server" CssClass="form-control col-xs-6 numbersOnly"
                                Text='<%# Eval("SurchargeInPercent") %>'></asp:TextBox>                               
                        </EditItemTemplate>
                    </asp:TemplateField>

                    
                    <%--    <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCondtionDescription"   AutoPostBack="true" runat="server"
                                        Text='<%# Eval("Status") %>' ></asp:TextBox>
                               
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
        </div>
    </div>    
    <script type="text/javascript">
        jQuery('.numbersOnly').keyup(function () {
            this.value = this.value.replace(/[^0-9\.]/g, '');
        });
    </script>
</asp:Content>