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

        protected void Page_Load(object sender, EventArgs e)
        {
            try 
            {
                buyers = buyerService.GetBuyers();
                if (buyers.Tables.Count > 0)
                {
                    if (buyers.Tables[0].Rows.Count > 0)
                    {
                        selectedIndex = DDLBuyerName.SelectedIndex;

                        //TXTAddress.Text = buyers.Tables["Buyers"].Rows[0]["BuyerName"].ToString();
                        DDLBuyerName.DataTextField = "BuyerName";
                        DDLBuyerName.DataValueField = "BuyerID";
                        DDLBuyerName.DataSource = buyers;
                        DDLBuyerName.DataBind();
                    }
                    else
                    {
                        //Alert about inability to connect to the server
                    }
                }
            }
            catch
            {

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
            buyer.BuyerProvince = "AB";//DDLProvince.SelectedValue;
            buyer.BuyerPostalCode = TXTPostal.Text;
            buyer.BuyerPhone = TXTPhone.Text;
            //buyer.BuyerDriverLicense = TXTDLicense.Text;
            buyer.BuyerIsBanned = CHKBanned.Checked;
            buyer.BuyerIsPermanent = CHKPermanent.Checked;
            //buyer.Notes = TXTNotes.Text;

            try
            {
                //Call DAL
                int id = buyerService.CreateBuyer(buyer);
            }
            catch (Exception ex)
            {
                TXTNotes.Text = ex.Message;
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
            DDLProvince.SelectedValue = buyers.Tables["Buyers"].Rows[selectedIndex]["BuyerProvince"].ToString();
            TXTPostal.Text = buyers.Tables["Buyers"].Rows[selectedIndex]["BuyerPostalCode"].ToString();
            TXTPhone.Text = buyers.Tables["Buyers"].Rows[selectedIndex]["BuyerPhone"].ToString();
            TXTDLicense.Text = buyers.Tables["Buyers"].Rows[selectedIndex]["BuyerPhone"].ToString();
            CHKBanned.Checked = Convert.ToBoolean(buyers.Tables["Buyers"].Rows[selectedIndex]["Banned"].ToString());
            TXTNotes.Text = buyers.Tables["Buyers"].Rows[selectedIndex]["BuyerPhone"].ToString();

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

        }

        protected void BTNDelete_Click(object sender, EventArgs e)
        {

        }
    }
}