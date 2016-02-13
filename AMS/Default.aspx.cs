﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AMS.App_Code;


namespace AMS
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LBAuctionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox messageBox = new MessageBox("Text", "Title", MessageBox.MessageBoxIcons.Question, MessageBox.MessageBoxButtons.YesOrNo, MessageBox.MessageBoxStyle.StyleA);
            messageBox.SuccessEvent.Add("YesModClick");
            PopupBox.Text = messageBox.Show(this);
        }

        protected void DDLAuctionYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}