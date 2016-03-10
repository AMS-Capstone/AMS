<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewAuction.aspx.cs" Inherits="AMS.NewAuction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class=" col-xs-12" id="AlertDiv" runat="server"></div>
    <div class="container">
        <div class="row">
            <div class='col-sm-6'>
                <div class="form-group">
                    <div class='input-group date' id='datetimepicker1'>
                        <input type='text' class="form-control" />
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </div>
            </div>
            <script type="text/javascript">
                $(function () {
                    $('#datetimepicker1').datetimepicker();
                });
            </script>
        </div>
    </div>

</asp:Content>
