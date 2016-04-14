using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AMS.App_Code;
using AMS.App_Code.DAL;

namespace AMS
{
    public partial class Inventory : System.Web.UI.Page
    {
        DataSet inventory = new DataSet();
        InventoryDAL inventoryService = new InventoryDAL();
        AuctionDAL auctionService = new AuctionDAL();
        Boolean addingVehicles = false;
        GST activeGST = new AuctionMainDAL().GetActiveGST();
        int auctionID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Checking if the vehicles are to be added to the auction
            try
            {
                addingVehicles = CheckIfAddingVehicles();
                auctionID = getAuctionIDfromParameters();
            }
            catch (Exception ex) 
            {
                AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
                "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + ex.Message +
                "</label></div>";
            }

            if (addingVehicles == true)
            {
                ConcealDiv.InnerHtml = "";
                LBCarList.SelectionMode = ListSelectionMode.Multiple;
                //Retrieving inventory vehicles
                try
                {

                    if (!IsPostBack)
                    {
                        inventory = inventoryService.viewAvailableInventoryVehicles(auctionID);

                        LBCarList.DataTextField = "DisplayInfo";
                        LBCarList.DataValueField = "VehicleID";
                        LBCarList.DataSource = inventory;
                        LBCarList.DataBind();
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
            else
            {
                ConcealAddDiv.InnerHtml = "";
                //Retrieving vehicles for sale
                try
                {

                    if (!IsPostBack)
                    {
                        inventory = auctionService.viewVehiclesForSale();

                        LBCarList.DataTextField = "DisplayInfo";
                        LBCarList.DataValueField = "VehicleID";
                        LBCarList.DataSource = inventory;
                        LBCarList.DataBind();
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

            if (inventory.Tables.Count > 0 && inventory.Tables[0].Rows.Count < 1)
            {
                //Alert about no cars to display
                AlertDiv.InnerHtml = "<div class=\"alert alert-warning fade in\">" +
                "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                "<strong>Warning!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "No cars to display!" +
                "</label></div>";
            }
        }

        protected void LBCarList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //This code pulls up a list of fees accrued by the car and the conditions and requirements object from the database
            try
            {
                //TODO: Implement
            }
            catch (Exception ex)
            {
                AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
                "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + ex.Message +
                "</label></div>";
            }
        }

        protected void BTNEditCarDetails_Click(object sender, EventArgs e)
        {
            if (LBCarList.SelectedValue == null || LBCarList.SelectedValue == "")
            {
                LBCarList.SelectedIndex = 0;
            }
            Response.Redirect("~/Vehicles?VehicleID=" + LBCarList.SelectedValue);
        }

        protected void BTNUpdate_Click(object sender, EventArgs e)
        {
            //TODO: Implement
        }


        private Boolean CheckIfAddingVehicles()
        {
            String addingVehiclesString = "";
            bool addingVehicles = false;
            addingVehiclesString = Request["AddingVehicles"];
            if (addingVehiclesString != null)
            {
                addingVehicles = Convert.ToBoolean(addingVehiclesString);
            }
            return addingVehicles;
        }

        protected int getAuctionIDfromParameters()
        {
            String AuctionIDString = "";
            int auctionID = 0;
            AuctionIDString = Request["AuctionID"];
            if (AuctionIDString != null)
            {
                auctionID = Convert.ToInt32(AuctionIDString);
            }

            return auctionID;
        }

        protected String getAuctionDatefromParameters()
        {
            String AuctionIDString = "";
            AuctionIDString = Request["AuctionDate"];
            return AuctionIDString;
        }

        protected void BTNAddVehicles_Click(object sender, EventArgs e)
        {
            int id = 0;
            foreach (ListItem listItem in LBCarList.Items)
            {
                if (listItem.Selected)
                {
                    //Assembling AuctionSale object
                    AuctionSale auctionSale = new AuctionSale();
                    auctionSale.AuctionID = auctionID;
                    auctionSale.SaleDate = Convert.ToDateTime(getAuctionDatefromParameters());

                    //Not Sold Sale Status
                    auctionSale.ConditionID = 1;
                    auctionSale.VehicleID = Convert.ToInt32(listItem.Value);
                    //Assigning an empty Buyer
                    auctionSale.BuyerID = 1;
                    auctionSale.SellingPrice = 0.00;
                    auctionSale.BidderNumber = 0;
                    //default buyer's fee for vehicles
                    auctionSale.BuyersFee = 250.00;
                    auctionSale.Deposit = 0.00;
                    auctionSale.GstID = activeGST.GSTID;
                    auctionSale.Notes = "";

                    //Saving object to the database
                    id = auctionService.createAuctionSale(auctionSale);
                }
            }

            inventory = inventoryService.viewAvailableInventoryVehicles(auctionID);
            LBCarList.DataTextField = "DisplayInfo";
            LBCarList.DataValueField = "VehicleID";
            LBCarList.DataSource = inventory;
            LBCarList.DataBind();

            //Success message
            AlertDiv.InnerHtml = "<div class=\"alert alert-success fade in\">" +
            "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
            "<strong>Success!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "Vehicles successfully added! " +
            "</label></div>";

            //This code will refresh the Car Listbox
            //Response.Redirect("~/Inventory?AuctionID=" + auctionID.ToString() + "&AddingVehicles=true" + "&AuctionDate=" + getAuctionDatefromParameters());
        }
    }
}