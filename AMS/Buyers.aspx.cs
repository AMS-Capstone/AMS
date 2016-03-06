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
    public partial class Buyers : System.Web.UI.Page
    {
        BuyerDAL buyerService = new AMS.App_Code.BuyerDAL();
        DataSet buyers = new DataSet();
        int selectedIndex;
        private List<String> provinces = new List<String>();

        protected void Page_Load(object sender, EventArgs e)
        {

            provinces.Add("AB");
            provinces.Add("BC");
            provinces.Add("MB");
            provinces.Add("NB");
            provinces.Add("NL");
            provinces.Add("NS");
            provinces.Add("NT");
            provinces.Add("NU");
            provinces.Add("ON");
            provinces.Add("PE");
            provinces.Add("QC");
            provinces.Add("SK");
            provinces.Add("YT");

            DDLProvince.DataSource = provinces;
            DDLProvince.DataBind();

            try 
            {
                buyers = buyerService.GetBuyers();
                if (buyers.Tables.Count > 0)
                {
                    if (buyers.Tables[0].Rows.Count > 0)
                    {
                        selectedIndex = DDLBuyerName.SelectedIndex;
                        
                        DDLBuyerName.DataTextField = "BuyerName";
                        DDLBuyerName.DataValueField = "BuyerID";
                        DDLBuyerName.DataSource = buyers;
                        DDLBuyerName.DataBind();
                    }
                    else
                    {
                        //Alert about inability to connect to the server
                        AlertDiv.InnerHtml = "<div class=\"alert alert-warning fade in\">" +
                        "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                        "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "Could not retrieve any buyers from the server." +
                        "</label></div>";
                    }
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

        protected void BTNSubmit_Click(object sender, EventArgs e)
        {
            Buyer buyer = new Buyer();
            if (TXTBidNum.Text.ToString() != null)
            {
                buyer.BidderNum = Convert.ToInt32(TXTBidNum.Text.ToString());
            }
            else
            {
                buyer.BidderNum = 0;
            }

            buyer.BuyerFirstName = TXTFirstName.Text;
            buyer.BuyerLastName = TXTLastName.Text;
            buyer.BuyerAddress = TXTAddress.Text;
            buyer.BuyerCity = TXTCIty.Text;
            buyer.BuyerProvince = DDLProvince.SelectedValue;
            buyer.BuyerPostalCode = TXTPostal.Text;
            buyer.BuyerPhone = TXTPhone.Text;
            buyer.BuyerDriverLicense = TXTDLicense.Text;
            buyer.IsBanned = CHKBanned.Checked;
            buyer.BuyerIsPermanent = CHKPermanent.Checked;
            buyer.Notes = TXTNotes.Text;

            try
            {
                //Call DAL
                int id = buyerService.CreateBuyer(buyer);

                //Success message
                AlertDiv.InnerHtml = "<div class=\"alert alert-success fade in\">" +
                "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                "<strong>Success!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "New Sellerr was created with internal ID: " + id.ToString() +
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

        protected void BTNClear_Click(object sender, EventArgs e)
        {
            DDLBuyerName.SelectedIndex = 0;
            TXTBidNum.Text = "";
            TXTFirstName.Text = "";
            TXTLastName.Text = "";
            TXTAddress.Text = "";
            TXTCIty.Text = "";
            DDLProvince.SelectedIndex = 0;
            TXTPostal.Text = "";
            TXTPhone.Text = "";
            TXTDLicense.Text = "";
            CHKBanned.Checked = false;
            CHKPermanent.Checked = false;
            TXTNotes.Text = "";
        }

        protected void DDLBuyerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDLBuyerName.SelectedIndex = selectedIndex;

            TXTFirstName.Text = buyers.Tables["Buyers"].Rows[selectedIndex]["BuyerFirstName"].ToString();
            TXTLastName.Text = buyers.Tables["Buyers"].Rows[selectedIndex]["BuyerLastName"].ToString();
            TXTAddress.Text = buyers.Tables["Buyers"].Rows[selectedIndex]["BuyerAddress"].ToString();
            TXTCIty.Text = buyers.Tables["Buyers"].Rows[selectedIndex]["BuyerCity"].ToString();
            DDLProvince.SelectedValue = buyers.Tables["Buyers"].Rows[selectedIndex]["BuyerProvince"].ToString();//
            TXTPostal.Text = buyers.Tables["Buyers"].Rows[selectedIndex]["BuyerPostalCode"].ToString();
            TXTPhone.Text = buyers.Tables["Buyers"].Rows[selectedIndex]["BuyerPhone"].ToString();
            TXTDLicense.Text = buyers.Tables["Buyers"].Rows[selectedIndex]["BuyerPhone"].ToString();
            CHKBanned.Checked = Convert.ToBoolean(buyers.Tables["Buyers"].Rows[selectedIndex]["Banned"].ToString());
            TXTNotes.Text = buyers.Tables["Buyers"].Rows[selectedIndex]["Notes"].ToString();

            if (selectedIndex > 0)
            {
                TXTBidNum.Text = buyers.Tables["Buyers"].Rows[selectedIndex]["BidderNumber"].ToString();
                CHKPermanent.Checked = Convert.ToBoolean(buyers.Tables["Buyers"].Rows[selectedIndex]["Permanent"].ToString());
                BTNSubmit.Enabled = false;
                BTNSubmit.CssClass = "btn btn-primary hidden";
                BTNUpdate.Enabled = true;
                BTNUpdate.CssClass = "btn btn-primary";
                BTNDelete.Enabled = true;
                BTNDelete.CssClass = "btn btn-primary";
            }
            else
            {
                TXTBidNum.Text = "";
                CHKPermanent.Checked = false;
                BTNSubmit.Enabled = true;
                BTNSubmit.CssClass = "btn btn-primary";
                BTNUpdate.Enabled = false;
                BTNUpdate.CssClass = "btn btn-primary hidden";
                BTNDelete.Enabled = false;
                BTNDelete.CssClass = "btn btn-primary hidden";
            }
        }

        protected void BTNUpdate_Click(object sender, EventArgs e)
        {
            Buyer buyer = new Buyer();
            if (TXTBidNum.Text.ToString() != null)
            {
                buyer.BidderNum = Convert.ToInt32(TXTBidNum.Text.ToString());
            }
            else
            {
                buyer.BidderNum = 0;
            }
            buyer.BuyerID = Convert.ToInt32(DDLBuyerName.SelectedValue);
            buyer.BuyerFirstName = TXTFirstName.Text;
            buyer.BuyerLastName = TXTLastName.Text;
            buyer.BuyerAddress = TXTAddress.Text;
            buyer.BuyerCity = TXTCIty.Text;
            buyer.BuyerProvince = DDLProvince.SelectedValue;
            buyer.BuyerPostalCode = TXTPostal.Text;
            buyer.BuyerPhone = TXTPhone.Text;
            buyer.BuyerDriverLicense = TXTDLicense.Text;
            buyer.IsBanned = CHKBanned.Checked;
            buyer.BuyerIsPermanent = CHKPermanent.Checked;
            buyer.Notes = TXTNotes.Text;

            try
            {
                //Call DAL
                int id = buyerService.UpdateBuyer(buyer);
            }
            catch (Exception ex)
            {
                AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
                "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + ex.Message +
                "</label></div>";
            }
        }

        protected void BTNDelete_Click(object sender, EventArgs e)
        {

        }
    }
}