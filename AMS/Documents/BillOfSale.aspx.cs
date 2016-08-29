using AMS.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMS.Documents
{
    public partial class BillOfSale : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int saleID = getSaleIDfromParameters();
                //AuctionDAL auctionService = new AuctionDAL();
                DataSet auctionData = (DataSet)Session["AuctionData"];
                DataRow sale = null;
                foreach (DataRow row in auctionData.Tables[0].Rows)
                {
                    if (row["AuctionSaleID"].ToString().Contains(saleID.ToString()))
                    {
                        sale = row;
                    }
                }

                //Buyer info
                buyerName.InnerHtml = sale["BuyerName"].ToString();
                buyerAddress.InnerHtml = sale["BuyerAddress"].ToString();
                buyerCity.InnerHtml = sale["BuyerCity"].ToString();
                buyerProvince.InnerHtml = sale["BuyerProvince"].ToString();
                buyerPostal.InnerHtml = sale["BuyerPostalCode"].ToString();
                bidNum.InnerHtml = sale["BidderNumber"].ToString();
                buyerPhone.InnerHtml = sale["BuyerPhone"].ToString();

                //Vehicle info
                lot.InnerHtml = sale["LotNumber"].ToString();
                year.InnerHtml = sale["Year"].ToString();
                make.InnerHtml = sale["Make"].ToString();
                model.InnerHtml = sale["Model"].ToString();
                vin.InnerHtml = sale["VIN"].ToString();
                status.InnerHtml = sale["Province"].ToString(); //TODO: Implement proper handling of vahicle status
                color.InnerHtml = sale["Color"].ToString();
                mileage.InnerHtml = sale["Mileage"].ToString();// +" " + sale[""]; TODO:Implement proper handling of units
                hours.InnerHtml = ""; //sale["Hours"].ToString();
                options.InnerHtml = sale["VehicleOptions"].ToString();

                //Sale info
                saleDate.InnerHtml = Convert.ToDateTime(sale["Saledate"]).ToString("MMMM dd, yyyy");
                sellingPrice.InnerHtml = Convert.ToDouble(sale["SellingPrice"]).ToString("C2");
                buyersFee.InnerHtml = Convert.ToDouble(sale["BuyersFee"]).ToString("C2");
                gst.InnerHtml = Convert.ToDouble(sale["GST"]).ToString("C2");
                total.InnerHtml = Convert.ToDouble(sale["Total"]).ToString("C2");
                deposit.InnerHtml = Convert.ToDouble(sale["Deposit"]).ToString("C2");
                payment.InnerHtml = Convert.ToDouble(sale["Payments"]).ToString("C2");
                balance.InnerHtml = Convert.ToDouble(sale["NetTotal"]).ToString("C2");
            }
            catch (Exception ex)
            {
                AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
                "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + ex.Message +
                "</label></div>";
            }
        }

        protected int getSaleIDfromParameters()
        {
            String saleIDString = "";
            int saleID = 0;
            saleIDString = Request["SaleID"];
            if (saleIDString != null)
            {
                saleID = int.Parse(saleIDString);
            }

            return saleID;
        }
    }
}