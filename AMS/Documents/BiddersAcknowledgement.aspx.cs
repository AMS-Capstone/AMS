using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMS.Documents
{
    public partial class BiddersAcknowledgement : System.Web.UI.Page
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
                bidNum.InnerHtml = "";

                //Vehicle info
                lot.InnerHtml = sale["LotNumber"].ToString();
                year.InnerHtml = sale["Year"].ToString();
                make.InnerHtml = sale["Make"].ToString();
                model.InnerHtml = sale["Model"].ToString();
                vin.InnerHtml = sale["VIN"].ToString();
                status.InnerHtml = sale["Province"].ToString(); //TODO: Implement proper handling of vahicle status

                //saleStatus.InnerHtml = sale[""].ToString(); //Sale status is circled manually by the clerk

                //Sale info
                saleDate.InnerHtml = Convert.ToDateTime(sale["Saledate"]).ToString("MMMM dd, yyyy");
                total.InnerHtml = "";
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