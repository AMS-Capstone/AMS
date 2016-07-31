using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AMS.App_Code;
using AMS.App_Code.DAL;
using AMS.App_Code.SuppportClasses;

namespace AMS
{
    public partial class Inventory : System.Web.UI.Page
    {
        DataSet inventory = new DataSet();
        DataSet feeTypes = new DataSet();
        DataAction feeService = new DataAction();
        InventoryDAL inventoryService = new InventoryDAL();
        AuctionDAL auctionService = new AuctionDAL();
        Boolean addingVehicles = false;
        GST activeGST = new AuctionMainDAL().GetActiveGST();
        int auctionID = 0;
        VehicleConditionsRequirements vcr = new VehicleConditionsRequirements();

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

            //Checking if the page was called to add vehicles to an auction
            if (addingVehicles == true)
            {
                //Concealing irrelevant parts of the interface
                ConcealDiv.InnerHtml = "";
                //Enabling multiselect for the vehicle list
                LBCarList.SelectionMode = ListSelectionMode.Multiple;
                try
                {
                    if (!IsPostBack)
                    {
                        UpdateInventoryList();
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
                //Hiding the button for adding vehicles to an auction
                ConcealAddDiv.InnerHtml = "";
                try
                {
                    if (!IsPostBack)
                    {
                        UpdateInventoryList();

                        feeTypes.Tables.Add(feeService.GetFeeTypes());
                        DDLFeeType.DataTextField = "FeeType";
                        DDLFeeType.DataValueField = "FeeId";
                        DDLFeeType.DataSource = feeTypes;
                        DDLFeeType.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
                    "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                    "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + ex.Message +
                    "</label></div>";
                }

                //TODO: Generate Bidder Acknowledgements
                //TODO: Generate Bill of Sale
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

        /// <summary>
        /// Updates the inventory list
        /// </summary>
        private void UpdateInventoryList()
        {
            if (addingVehicles == true)
            {
                //Retrieving vehicles for sale, but not yet in the auction
                inventory = inventoryService.viewAvailableInventoryVehicles(auctionID);

                LBCarList.DataTextField = "DisplayInfo";
                LBCarList.DataValueField = "VehicleID";
                LBCarList.DataSource = inventory;
                LBCarList.DataBind();
            }
            else
            {
                //Retrieving all inventory vehicles
                inventory = inventoryService.viewInventoryVehicles();

                LBCarList.DataTextField = "DisplayInfo";
                LBCarList.DataValueField = "VehicleID";
                LBCarList.DataSource = inventory;
                LBCarList.DataBind();
            }
        }

        protected void LBCarList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //This code pulls up a list of fees accrued by the car and the conditions and requirements object from the database
            try
            {
                int carId = Convert.ToInt32(LBCarList.SelectedValue.ToString());
                
                vcr = inventoryService.GetVehicleConditionsRequirements(carId);

                TXTDate.Value = vcr.DateIn.ToString();
                TXTEstValue.Text = vcr.EstValue.ToString();
                TXTReserve.Text = vcr.Reserve.ToString();
                TXTComments.Text = vcr.Comments;
                CHKCallOnHigh.Checked = vcr.CallOnHigh;
                CHKForSale.Checked = vcr.ForSale;
                CHKRecord.Checked = vcr.Record;
                Session["vcrID"] = vcr.Id.ToString();
                Session["vcrVID"] = vcr.VehicleID.ToString();

                DataSet vehicleFees = inventoryService.getVehiclesFees(vcr.Id);
                LBFees.DataTextField = "FeeInfo";
                LBFees.DataValueField = "VehicleFeeID";
                LBFees.DataSource = vehicleFees;
                LBFees.DataBind();

                BTNAddModal.Visible = true;
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

        private void NullCheckEstimatedAndReserveValues()
        {
            if (TXTEstValue.Text.ToString() == "" || TXTEstValue.Text.ToString() == null)
            {
                TXTEstValue.Text = "0.00";
            }
            if (TXTReserve.Text.ToString() == "" || TXTReserve.Text.ToString() == null)
            {
                TXTReserve.Text = "0.00";
            }
        }

        protected void BTNUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                VehicleConditionsRequirements vcr = new VehicleConditionsRequirements();
                NullCheckEstimatedAndReserveValues();

                vcr.DateIn = Convert.ToDateTime(TXTDate.Value);
                vcr.EstValue = Convert.ToDouble(TXTEstValue.Text);
                vcr.Reserve = Convert.ToDouble(TXTReserve.Text);
                vcr.Comments = TXTComments.Text;
                vcr.CallOnHigh = CHKCallOnHigh.Checked;
                vcr.ForSale = CHKForSale.Checked;
                vcr.Record = CHKRecord.Checked;
                vcr.Id = Convert.ToInt32(Session["vcrID"].ToString());
                vcr.VehicleID = Convert.ToInt32(Session["vcrVID"].ToString());

                inventoryService.UpdateVehicleConditionsRequirements(vcr);

                UpdateInventoryList();

                //Success message
                AlertDiv.InnerHtml = "<div class=\"alert alert-success fade in\">" +
                "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                "<strong>Success!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "Requirements successfully updated! " +
                "</label></div>";
            }
            catch (Exception ex)
            {
                AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
                "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + ex.Message +
                "</label></div>";
            }
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

        protected void BTNAdd_Click(object sender, EventArgs e)
        {
            int vcrID = Convert.ToInt32(Session["vcrID"].ToString());
            VehicleFee fee = new VehicleFee();
            fee.VehicleFeeCost = Convert.ToDouble(TXTCost.Text.ToString());
            fee.FeeID = Convert.ToInt32(DDLFeeType.SelectedValue.ToString());
            fee.VehicleConditionRequirementID = vcrID;


            try
            {
                inventoryService.CreateVehicleFee(fee);

                DataSet vehicleFees = inventoryService.getVehiclesFees(vcrID);
                LBFees.DataTextField = "FeeInfo";
                LBFees.DataValueField = "VehicleFeeID";
                LBFees.DataSource = vehicleFees;
                LBFees.DataBind();
                
                //Success message
                AlertDiv.InnerHtml = "<div class=\"alert alert-success fade in\">" +
                "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                "<strong>Success!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "Fee successfully added!" +
                "</label></div>";
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