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
        bool addingVehicles = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Checking if the vehicles are to be added to the auction
            String addingVehiclesString = "";
            try
            {
                addingVehiclesString = Request["AddingVehicles"];
            }
            catch (Exception ex) 
            {
                AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
                "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + ex.Message +
                "</label></div>";
            }

            if (addingVehiclesString != null)
            {
                addingVehicles = Convert.ToBoolean(addingVehiclesString);
            }
            if (addingVehicles == true)
            {
                LBCarList.SelectionMode = ListSelectionMode.Multiple;

                //Retrieving inventory vehicles
                try
                {

                    if (!IsPostBack)
                    {
                        inventory = inventoryService.viewInventoryVehicles();

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
                //Retrieving inventory vehicles
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

            if (inventory.Tables[0].Rows.Count < 1)
            {
                //Alert about no cars to display
                AlertDiv.InnerHtml = "<div class=\"alert alert-warning fade in\">" +
                "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                "<strong>Warning!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "No cars to display!" +
                "</label></div>";
            }
        }
    }
}