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
    public partial class Sellers : System.Web.UI.Page
    {
        SellerDAL sellerService = new AMS.App_Code.SellerDAL();
        DataSet sellers = new DataSet();
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
                sellers = sellerService.GetSellers();
                if (sellers.Tables.Count > 0)
                {
                    if (sellers.Tables[0].Rows.Count > 0)
                    {
                        selectedIndex = DDLSellerName.SelectedIndex;

                        DDLSellerName.DataTextField = "SellerName";
                        DDLSellerName.DataValueField = "SellerID";
                        DDLSellerName.DataSource = sellers;
                        DDLSellerName.DataBind();
                    }
                    else
                    {
                        //Alert about inability to connect to the server
                        AlertDiv.InnerHtml = "<div class=\"alert alert-warning fade in\">" +
                        "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                        "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "Could not retrieve any sellers from the server." +
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
            Seller seller = new Seller();
            seller.SellerCode = TXTCode.Text;
            seller.SellerName = TXTName.Text;
            seller.SellerAddress = TXTAddress.Text;
            seller.SellerCity = TXTCity.Text;
            seller.SellerProvince = DDLProvince.SelectedValue;
            seller.SellerPostalCode = TXTPostal.Text;
            seller.SellerPhone = TXTPhone.Text;
            seller.SellerOtherPhone = TXTOtherPhone.Text;
            seller.SellerFax = TXTFax.Text;
            seller.ContactFirstName = TXTFirstName.Text;
            seller.ContactLastName = TXTLastName.Text;
            seller.SellerGSTNumber = TXTGSTNumber.Text;
            seller.SellerIsPrivate = CHKPrivate.Checked;

            try
            {
                //Call DAL
                int id = sellerService.CreateSeller(seller);

                //Success message
                AlertDiv.InnerHtml = "<div class=\"alert alert-success fade in\">" +
                "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                "<strong>Success!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + "New Seller was created with internal ID: " + id.ToString() +
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
            DDLSellerName.SelectedIndex = 0;//Causes exception at no sellers

            TXTCode.Text = "";
            TXTName.Text = "";
            TXTAddress.Text = "";
            TXTCity.Text = "";
            DDLProvince.SelectedIndex = 0;
            TXTPostal.Text = "";
            TXTPhone.Text = "";
            TXTOtherPhone.Text = "";
            TXTFax.Text = "";
            TXTFirstName.Text = "";
            TXTLastName.Text = "";
            TXTGSTNumber.Text = "";
            CHKPrivate.Checked = false;
            {
                BTNSubmit.Enabled = true;
                BTNSubmit.CssClass = "btn btn-primary";
                BTNUpdate.Enabled = false;
                BTNUpdate.CssClass = "btn btn-primary hidden";
                BTNDelete.Enabled = false;
                BTNDelete.CssClass = "btn btn-primary hidden";
            }
        }

        protected void DDLSellerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDLSellerName.SelectedIndex = selectedIndex;

            TXTCode.Text = sellers.Tables["Sellers"].Rows[selectedIndex]["SellerCode"].ToString();
            TXTName.Text = sellers.Tables["Sellers"].Rows[selectedIndex]["SellerName"].ToString();
            TXTAddress.Text = sellers.Tables["Sellers"].Rows[selectedIndex]["SellerAddress"].ToString();
            TXTCity.Text = sellers.Tables["Sellers"].Rows[selectedIndex]["SellerCity"].ToString();
            DDLProvince.SelectedValue = sellers.Tables["Sellers"].Rows[selectedIndex]["SellerProvince"].ToString();//
            TXTPostal.Text = sellers.Tables["Sellers"].Rows[selectedIndex]["SellerPostalCode"].ToString();
            TXTPhone.Text = sellers.Tables["Sellers"].Rows[selectedIndex]["SellerPhone"].ToString();
            TXTOtherPhone.Text = sellers.Tables["Sellers"].Rows[selectedIndex]["SellerOtherPhone"].ToString();
            TXTFax.Text = sellers.Tables["Sellers"].Rows[selectedIndex]["SellerFax"].ToString();
            TXTFirstName.Text = sellers.Tables["Sellers"].Rows[selectedIndex]["ContactFirstName"].ToString();
            TXTLastName.Text = sellers.Tables["Sellers"].Rows[selectedIndex]["ContactLastName"].ToString();
            TXTGSTNumber.Text = sellers.Tables["Sellers"].Rows[selectedIndex]["GSTNumber"].ToString();
            CHKPrivate.Checked = Convert.ToBoolean(sellers.Tables["Sellers"].Rows[selectedIndex]["SellerPrivate"].ToString());

            if (selectedIndex > 0)
            {
                BTNSubmit.Enabled = false;
                BTNSubmit.CssClass = "btn btn-primary hidden";
                BTNUpdate.Enabled = true;
                BTNUpdate.CssClass = "btn btn-primary";
                BTNDelete.Enabled = true;
                BTNDelete.CssClass = "btn btn-primary";
            }
            else
            {
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
            Seller seller = new Seller();

            seller.SellerCode = TXTCode.Text;
            seller.SellerName = TXTName.Text;
            seller.SellerAddress = TXTAddress.Text;
            seller.SellerCity = TXTCity.Text;
            seller.SellerProvince = DDLProvince.SelectedValue;
            seller.SellerPostalCode = TXTPostal.Text;
            seller.SellerPhone = TXTPhone.Text;
            seller.SellerOtherPhone = TXTOtherPhone.Text;
            seller.SellerFax = TXTFax.Text;
            seller.ContactFirstName = TXTFirstName.Text;
            seller.ContactLastName = TXTLastName.Text;
            seller.SellerGSTNumber = TXTGSTNumber.Text;
            seller.SellerIsPrivate = CHKPrivate.Checked;

            try
            {
                //Call DAL
                sellerService.UpdateSeller(seller);
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