<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="AMS.Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>GST</h1>
    <div class=" col-xs-12"></div>
    <div class="control group">          
        <label class="control-label col-xs-2" for="DDLGST" >GST:</label>
        <div class="col-xs-10">
            <asp:DropDownList class="form-control" ID="DDLGST" runat="server" OnSelectedIndexChanged="DDLGST_SelectedIndexChanged1" AutoPostBack="true"></asp:DropDownList>
        </div>
    </div>
    
    <div class=" col-xs-12"></div>
    <div class="control-group" style="height: 29px">
        <label class="control-label col-xs-2" for="TXTNewGST">Selected GST:</label> 
        <div class="col-xs-10">
            <asp:TextBox ID="TXTNewGST" runat="server" Width="127px" ></asp:TextBox>
        </div>
    </div>

    <div class=" col-xs-12"></div>
    <div class="control-group">
        <div class="col-xs-2"></div>      
        <div class="col-xs-10">            
            <div class="checkbox">
                <label><asp:CheckBox runat="server" id="CHKActive" Text="Active"></asp:CheckBox></label>
            </div>
        </div>
    <div class="btn-group col-xs-12">
        <asp:Button ID="BTNSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="BTNSave_Click" />
    </div>
    </div>
    
    <div class=" col-xs-12"></div>
 
    <div class=" col-xs-12"><hr /></div>
    
    <div class=" col-xs-12"></div>
    <h1>Condition status</h1>
    <div class=" col-xs-12"></div>
    <div class="control group">
    <label class="control-label col-xs-2" for="DDLConditionStatus" >Condition Status:</label>
        <div class="col-xs-10">
            <asp:DropDownList class="form-control" ID="DDLConditionStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLConditionStatus_SelectedIndexChanged"></asp:DropDownList>
        </div>
    </div>
    
    <div class=" col-xs-12"></div> 
    

    <div class=" col-xs-12"></div>
    <div class="control group">  
        <label class="control-label col-xs-2" for="TXTConditionCode" >Condition Code:</label>
        <div class="col-xs-10">
            <asp:TextBox ID="TXTConditionCode" runat="server" Width="127px" ></asp:TextBox>
        </div>
    </div>

    <div class=" col-xs-12">
        
    </div> 

    <div class=" col-xs-12"></div>
    <div class="control group">
        <label class="control-label col-xs-2" for="TXTConditionDescription" >Condition Description:</label>
        <div class="col-xs-10">
            <asp:TextBox ID="TXTConditionDescription" runat="server" Width="127px" ></asp:TextBox>
        </div>
    </div>

    <div class="btn-group col-xs-12">
        <asp:Button ID="BTNSaveConditionStatus" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="BTNSaveConditionStatus_Click" />
    </div>
  





    <div class=" col-xs-12"><hr /></div>
    <h1>Fee Types:</h1>
    <div class=" col-xs-12"></div>
    <div class="control group">
        <label class="control-label col-xs-2" for="DDLFeeTypes" >Fee Types:</label>
        <div class="col-xs-10">
            <asp:DropDownList class="form-control" ID="DDLFeeTypes" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLFeeTypes_SelectedIndexChanged" ></asp:DropDownList>
        </div>
    </div>

    <div class=" col-xs-12">
    
    </div> 

    <div class=" col-xs-12">
    </div>
    <div class="control group">
          
    <label class="control-label col-xs-2" for="TXTFeeType" >Type:</label>
        <div class="col-xs-10">
            <asp:TextBox ID="TXTFeeType" runat="server" Width="127px" ></asp:TextBox>
                </div>
    </div>
    <div class=" col-xs-12">
    
    </div> 
    <div class=" col-xs-12">
    </div>
    <div class="control group">
          
    <label class="control-label col-xs-2" for="TXTConditionDescription" >Fee Cost:</label>
        <div class="col-xs-10">
    <asp:TextBox ID="TXTFeeCost" runat="server" Width="127px" ></asp:TextBox>
                </div>
    </div>
    <div class="btn-group col-xs-12">
    <asp:Button ID="BTNSaveFeeType" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="BTNSaveFeeType_Click" />
    </div>


    <div class=" col-xs-12"><hr /></div>
    <h1>Payment Types</h1>
    <div class=" col-xs-12">
    </div>
    <div class="control group">
          
    <label class="control-label col-xs-2" for="DDLPaymentTypes" >Payment Types:</label>
        <div class="col-xs-10">
    <asp:DropDownList class="form-control" ID="DDLPaymentTypes" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLPaymentTypes_SelectedIndexChanged"  ></asp:DropDownList>
            </div>
    </div>
    <div class=" col-xs-12">
    
    </div> 
    <div class=" col-xs-12">
    </div>
    <div class="control group">
          
    <label class="control-label col-xs-2" for="TXTPaymentTypes" >Type:</label>
        <div class="col-xs-10">
    <asp:TextBox ID="TXTPaymentTypes" runat="server" Width="127px" ></asp:TextBox>
                </div>
    </div>
    <div class=" col-xs-12">
    
    </div> 
      
    <div class="btn-group col-xs-12">
    <asp:Button ID="BTNSavePaymentType" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="BTNSavePaymentType_Click"  />
    </div>
</asp:Content>
