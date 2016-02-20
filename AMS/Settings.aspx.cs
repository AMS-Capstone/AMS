﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AMS.App_Code;
using System.Data;
namespace AMS
{
    public partial class Settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Load All GST
            DataAction dataAction = new DataAction();
            DataTable dt =  dataAction.GetGST();

            DDLGST.DataSource = dt;
            DDLGST.DataValueField = dt.Columns["GSTPercent"].ToString();
            DDLGST.DataBind();
            //Load All Condition Statuses
            //Load All Fee Types
            //Load All Payment Types
        }

        protected void BTNAddNewGST_Click(object sender, EventArgs e)
        {
            //Add New GST
            DataAction dataAction = new DataAction();
            dataAction.CreateGSTEntry(double.Parse(TXTNewGST.Text.Trim()), true);
        }

        protected void DDLGST_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Update Active GST
        }
    }
}