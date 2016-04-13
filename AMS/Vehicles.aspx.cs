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
using System.Collections;

namespace AMS
{
    public partial class Vehicles : System.Web.UI.Page
    {
        //private int vehicleID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            BTNClear.PostBackUrl = "~/Vehicles.aspx";//?vehicleID=" + vehicleID.ToString();
            DataAction dataAction = new DataAction();

            if(!IsPostBack)
            { 
                try
                {
                    //Load the sellers
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


                    int vehicleID = getVehicleIDfromParameters();

                    if (vehicleID != 0)
                    {
                        Session["vehicleID"] = vehicleID.ToString();
                        Vehicle vehicle = new Vehicle();
                        vehicle = dataAction.GetVehicleByID(vehicleID);
                        populateVehicle(vehicle);
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

        protected int getVehicleIDfromParameters()
        {
            String vehicleIDString = "";
            int vehicleID = 0;
            vehicleIDString = Request["vehicleID"];
            if (vehicleIDString != null)
            {
                vehicleID = Convert.ToInt32(vehicleIDString);
            }

            return vehicleID;
        }

        protected int getVehicleIDfromSession()
        {
            String vehicleIDString = "";
            int vehicleID = 0;
            vehicleIDString = Session["vehicleID"].ToString();
            if (vehicleIDString != null)
            {
                vehicleID = Convert.ToInt32(vehicleIDString);
            }

            return vehicleID;
        }

        protected void populateVehicle(Vehicle vehicle)
        {
            TXTLotNumber.Text = vehicle.LotNumber;
            TXTYear.Text = vehicle.Year;
            TXTMake.Text = vehicle.Make;
            TXTModel.Text = vehicle.Model;
            TXTVin.Text = vehicle.Vin;
            TXTColor.Text = vehicle.Color;
            TXTMileage.Text = vehicle.Mileage.ToString();
            DDLUnits.SelectedValue = vehicle.Units;
            TXTTransmission.Text = vehicle.Transmission;
            DDLSeller.SelectedValue = vehicle.SellerID.ToString();
            TXTOptions.Text = vehicle.Options;

            DataAction dataAction = new DataAction();
            DataSet ds = dataAction.GetVehiclePicturesByVehicleID(vehicle.VehicleID);
            //ArrayList byteArray = new ArrayList();

            if (ds.Tables[0].Rows.Count > 0)
            {
                int rowCounter = 0;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    //byteArray.Add(row["Image"]);

                    //Session["ImageBytes"] = row["Image"];
                    //Image tempImage = new Image();
                    //ImageDiv.Controls.Add(tempImage);
                    //tempImage.ImageUrl = "~/DocumentHandler.ashx";
                    String imageString = Convert.ToBase64String((byte[])row["Image"]);
                    if (rowCounter == 0)
                    {
                        imageCarousel.InnerHtml =
                        "<div class=\"item active\">" +
                        "<img src=\"data:image/jpeg;base64," + imageString + "\" alt=\"ImageName\" width=\"400\" height=\"300\">" +
                        "<div class=\"carousel-caption\">" +
                        "<p>Image Description</p>" +
                        "</div>" +
                        "</div>";
                    }
                    else
                    {
                        imageCarousel.InnerHtml +=
                        "<div class=\"item\">" +
                        "<img src=\"data:image/jpeg;base64," + imageString + "\" alt=\"ImageName\" width=\"400\" height=\"300\">" +
                        "<div class=\"carousel-caption\">" +
                        "<p>Image Description</p>" +
                        "</div>" +
                        "</div>";
                    }
                    rowCounter += 1;
                    
                }

                //byte[][] byteImages = (byte[][])byteArray.ToArray(typeof(byte[]));

            }
            else
            {
                imageCarousel.InnerHtml =
                        "<div class=\"item active`\">" +
                        "<img src=\"" + "no_picture.jpg" + "\" alt=\"ImageName\" width=\"400\" height=\"300\">" +
                        "<div class=\"carousel-caption\">" +
                        "<p>Image Description</p>" +
                        "</div>" +
                        "</div>";
            }


            {
                BTNSubmit.Enabled = false;
                BTNSubmit.CssClass = "btn btn-primary hidden";
                BTNUpdate.Enabled = true;
                BTNUpdate.CssClass = "btn btn-primary";
            }
        }

        protected void BTNClear_Click(object sender, EventArgs e)
        {
            //if (DDLSeller.Items != null && DDLSeller.Items.Count > 0)
            //{
            //    DDLSeller.SelectedIndex = 0;
            //}

            //TXTLotNumber.Text = "";
            //TXTYear.Text = "";
            //TXTMake.Text = "";
            //TXTModel.Text = "";
            //TXTVin.Text = "";
            //TXTColor.Text = "";
            //TXTMileage.Text = "";
            //DDLUnits.SelectedIndex = 0;
            //TXTTransmission.Text = "";
            //TXTOptions.Text = "";
            //{
            //    BTNSubmit.Enabled = true;
            //    BTNSubmit.CssClass = "btn btn-primary";
            //    BTNUpdate.Enabled = false;
            //    BTNUpdate.CssClass = "btn btn-primary hidden";
            //}
        }

        protected void BTNSubmit_Click(object sender, EventArgs e)
        {
            //Save the inputed information 
            try
            {
                DataAction dataAction = new DataAction();
                Vehicle vehicle = new Vehicle(TXTLotNumber.Text.ToString(), TXTYear.Text.Trim(), TXTMake.Text.Trim(), TXTModel.Text.Trim(), TXTVin.Text.Trim(), TXTColor.Text.Trim(), int.Parse(TXTMileage.Text.ToString()), DDLUnits.SelectedValue, TXTTransmission.Text.Trim(), int.Parse(DDLSeller.SelectedValue), TXTOptions.Text.ToString());
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

        protected void BTNUpdate_Click(object sender, EventArgs e)
        {
            DataAction dataAction = new DataAction();
            Vehicle vehicle = new Vehicle(TXTLotNumber.Text.ToString(), TXTYear.Text.Trim(), TXTMake.Text.Trim(), TXTModel.Text.Trim(), TXTVin.Text.Trim(), TXTColor.Text.Trim(), int.Parse(TXTMileage.Text.ToString()), DDLUnits.SelectedValue, TXTTransmission.Text.Trim(), int.Parse(DDLSeller.SelectedValue), TXTOptions.Text.ToString());

            int vehicleID = getVehicleIDfromSession();
            vehicle.VehicleID = vehicleID;


        }

        protected void BTNDelete_Click(object sender, EventArgs e)
        {

        }

        protected void BTNUpload_Click(object sender, EventArgs e)
        {
            if (FUVehicle.HasFile)
            {
                try
                {
                    DataAction dataAction = new DataAction();
                    //FUVehicle.FileName.ToString();
                    dataAction.CreateImage(FUVehicle.FileBytes, int.Parse(Session["vehicleID"].ToString()));//int.Parse(Request["vehicleID"])

                    //Success message
                    AlertDiv.InnerHtml = "<div class=\"alert alert-success fade in\">" +
                    "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                    "<strong>Success!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "New Picture was created!" +
                    "</label></div>";

                    //Session["ImageBytes"] = FUVehicle.FileBytes;
                    //ImagePreview.ImageUrl = "~/DocumentHandler.ashx";
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