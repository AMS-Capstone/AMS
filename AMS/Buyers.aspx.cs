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

        protected void Page_Load(object sender, EventArgs e)
        {
            
            DataSet buyers = buyerService.GetBuyers();
            if (buyers.Tables[0].Rows.Count > 0)
            {
                //TXTAddress.Text = buyers.Tables["Buyers"].Rows[0]["BuyerName"].ToString();
                DDLBuyerName.DataTextField = "BuyerName";
                DDLBuyerName.DataValueField = "BuyerID";
                DDLBuyerName.DataSource = buyers;
                DDLBuyerName.DataBind();
            }
            else
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
            DDLProvince.Text = "";
            TXTPostal.Text = "";
            TXTPhone.Text = "";
            TXTDLicense.Text = "";
            CHKBanned.Checked = false;
            CHKPermanent.Checked = false;
            TXTNotes.Text = "";
        }
    }
}