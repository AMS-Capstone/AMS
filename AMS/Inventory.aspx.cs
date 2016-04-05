using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AMS.App_Code;

namespace AMS
{
    public partial class Inventory : System.Web.UI.Page
    {
        DataSet vehiclesForSale = new DataSet();
        InventoryDAL inventoryService = new InventoryDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    vehiclesForSale = inventoryService.vewInventoryVehicles();

                    LBCarList.DataTextField = "DisplayInfo";
                    LBCarList.DataValueField = "VehicleID";
                    LBCarList.DataSource = vehiclesForSale;
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
    }
}