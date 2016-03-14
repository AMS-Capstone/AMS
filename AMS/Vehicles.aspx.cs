using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AMS.App_Code;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using AMS.App_Code.SuppportClasses;

namespace AMS
{
    public partial class Vehicles : System.Web.UI.Page
    {
        //private int vehicleID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //BTNSaveVehicle.PostBackUrl = "Vehicles.aspx?vehicleID=" + vehicleID.ToString();

            if(!IsPostBack)
            { 
                try
                {
                    //Load the sellers
                    DataAction dataAction = new DataAction();
                    DataTable dt = new DataTable();
                    dt = dataAction.GetSellers();
                    DDLSeller.DataSource = dt;
                    DDLSeller.DataValueField = dt.Columns["SellerID"].ToString();
                    DDLSeller.DataTextField = dt.Columns["SellerName"].ToString();
                    DDLSeller.DataBind();
                    //DDLSeller.Items.Insert(0, new ListItem(String.Empty, String.Empty));

                    //Set the mileage units (NOT FROM DB)

                    DDLUnits.Items.Insert(0, new ListItem("KM", "1"));
                    DDLUnits.Items.Insert(1, new ListItem("Mi", "2"));
                    DDLUnits.Items.Insert(2, new ListItem("Hours", "3"));
                    
                    String vehicleIDString = "";
                    vehicleIDString = Request["vehicleID"];
                    if (vehicleIDString != null)
                    {
                        Session["vehicleID"] = vehicleIDString;
                    }
                }
                catch (Exception ex)
                {
                    AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
                    "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                    "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + ex.Message +
                    "</label></div>";
                }

            }
        }

        protected void BTNSaveVehicle_Click(object sender, EventArgs e)
        {
            //Save the inputed information 
            try
            {
                DataAction dataAction = new DataAction();
                Vehicle vehicle = new Vehicle(TXTLotNumber.Text.ToString(), TXTYear.Text.Trim(), TXTMake.Text.Trim(), TXTModel.Text.Trim(), TXTVin.Text.Trim(), TXTColor.Text.Trim(), int.Parse(TXTMileage.Text.ToString()), DDLUnits.SelectedItem.ToString(), TXTTransmission.Text.Trim(), int.Parse(DDLSeller.SelectedValue), TXTOptions.Text.ToString());
                int vehicleID = dataAction.CreateVehicle(vehicle);
                                
                //Success message
                AlertDiv.InnerHtml = "<div class=\"alert alert-success fade in\">" +
                "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                "<strong>Success!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "New Vehicle was created with internal ID: " + vehicleID.ToString() +
                "</label></div>";
                Session["vehicleID"] = vehicleID.ToString();

                //Response.Write("~/Vehicles?vehicleID=" + vehicleID.ToString());
            }
                catch (Exception ex)
                {
                    AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
                    "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                    "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + ex.Message +
                    "</label></div>";
                }
        }

        protected void BTNUpload_Click(object sender, EventArgs e)
        {
            if (FUVehicle.HasFile)
            {
                try
                {
                    DataAction dataAction = new DataAction();
                    dataAction.CreateImage(FUVehicle.FileBytes, int.Parse(Session["vehicleID"].ToString()));//int.Parse(Request["vehicleID"])

                    //Success message
                    AlertDiv.InnerHtml = "<div class=\"alert alert-success fade in\">" +
                    "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                    "<strong>Success!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "New Picture was created!" +
                    "</label></div>";

                    Session["ImageBytes"] = FUVehicle.FileBytes;
                    ImagePreview.ImageUrl = "~/DocumentHandler.ashx";
                }
                catch (Exception ex) 
                {
                    AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
                    "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                    "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + ex.Message +
                    "</label></div>";
                }
            }
        }
    }
}