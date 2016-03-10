using AMS.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMS
{
    public partial class NewAuction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet vehiclesForSale = new DataSet();
                AuctionDAL auctionService = new AuctionDAL();
                vehiclesForSale = auctionService.viewVehiclesForSale();

                LBAuctionCars.DataTextField = "DisplayInfo";
                LBAuctionCars.DataValueField = "VehicleID";
                LBAuctionCars.DataSource = vehiclesForSale;
                LBAuctionCars.DataBind();
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