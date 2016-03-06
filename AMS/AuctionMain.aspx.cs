using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMS
{
    public partial class AuctionMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int auctionID = Convert.ToInt16(Request["AuctionID"]);
        }

        protected void BTNTotals_Click(object sender, EventArgs e)
        {

        }
    }
}