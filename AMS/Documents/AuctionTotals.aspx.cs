﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMS
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String report = Session["AuctionTotals"].ToString();
                body.InnerHtml = report;
            }
            catch(Exception ex)
            {

            }
        }
    }
}