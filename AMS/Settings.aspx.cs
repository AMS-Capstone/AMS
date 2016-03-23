using System;
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
            if(!IsPostBack)
            {
                try 
                { 
                    //Load All GST
                    DataAction dataAction = new DataAction();
                    DataTable dt =  dataAction.GetGST();

                    DDLGST.DataSource = dt;
            
                    DDLGST.DataValueField = dt.Columns["GSTID"].ToString();
                        DDLGST.DataTextField = dt.Columns["GSTPercent"].ToString();
                    DDLGST.DataBind();
                    DDLGST.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    //Load All Condition Statuses

                    dt = dataAction.GetConditionStatus();
                    GRDConditionStatus.DataSource = dt;
                    GRDConditionStatus.DataBind();

                    //Load All Fee Types
                
                    dt = dataAction.GetFeeTypes();
                    GRDFeeTypes.DataSource = dt;
                    GRDFeeTypes.DataBind();
                    //DDLFeeTypes.DataSource = dt;
                    //DDLFeeTypes.DataValueField = dt.Columns["FeeId"].ToString();
                    //DDLFeeTypes.DataTextField = dt.Columns["description"].ToString();
                    //DDLFeeTypes.DataBind();
                    //DDLFeeTypes.Items.Insert(0, new ListItem(String.Empty, String.Empty));

                    //Load All Payment Types
                    dt = dataAction.GetPaymentType();
                    GRDPaymentTypes.DataSource = dt;
                    GRDPaymentTypes.DataBind();
                    //DDLPaymentTypes.DataSource = dt;
                    //DDLPaymentTypes.DataValueField = dt.Columns["PaymentTypeID"].ToString();
                    //DDLPaymentTypes.DataTextField = dt.Columns["PaymentDescription"].ToString();
                    //DDLPaymentTypes.DataBind();
                    //DDLPaymentTypes.Items.Insert(0, new ListItem(String.Empty, String.Empty));

                }
                catch (Exception ex)
                {
                    AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
                    "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
                    "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + ex.Message +
                    "</label></div>";
                }
            }
        }

        protected void BTNAddNewGST_Click(object sender, EventArgs e)
        {
            DataAction dataAction = new DataAction();
            //Add New GST
            try
            {
                if (TXTNewGST.Text.Trim() == "")
                {
              
                    dataAction.CreateGSTEntry(double.Parse(TXTNewGST.Text.Trim()), true);
                }
                else
                {
                    dataAction.UpdateGSTEntry(int.Parse(DDLGST.SelectedValue.ToString()), double.Parse(TXTNewGST.Text.Trim()), true);
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

   
        protected void BTNSave_Click(object sender, EventArgs e)
        {
            DataAction dataAction = new DataAction();
            try
            {
                if (DDLGST.SelectedItem.ToString() == "")
                {
                    //Create new one
                    dataAction.CreateGSTEntry(double.Parse(TXTNewGST.Text.ToString()), CHKActive.Checked);
              
                }
                else
                {
                    //Update it
                    dataAction.UpdateGSTEntry(int.Parse(DDLGST.SelectedValue.ToString()), double.Parse(TXTNewGST.Text),CHKActive.Checked);
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
        protected void txtConditionCode_TextChanged(object sender, EventArgs e)
        {
            //Get the ID update the value
            string id = ((Label)((Control)sender).Parent.Parent.FindControl("lblCondtionID")).Text;
            string value = ((TextBox)sender).Text;
            DataAction dataAction = new DataAction();
            dataAction.UpdateConditionStatus(int.Parse(id), value, "");
          
        }
        protected void txtPaymentType_TextChanged(object sender, EventArgs e)
        {
            //Get the ID update the value
            string id = ((Label)((Control)sender).Parent.Parent.FindControl("lblPaymentTypeID")).Text;
            string surcharge = ((TextBox)((Control)sender).Parent.Parent.FindControl("txtSurcharge")).Text;
            string description = ((TextBox)((Control)sender).Parent.Parent.FindControl("txtPaymentType")).Text;
            DataAction dataAction = new DataAction();
            dataAction.UpdatePaymentType(int.Parse(id), description, double.Parse(surcharge));

        }
        protected void txtSurcharge_TextChanged(object sender, EventArgs e)
        {
            //Get the ID update the value
            string id = ((Label)((Control)sender).Parent.Parent.FindControl("lblPaymentTypeID")).Text;
            string surcharge =  ((TextBox)((Control)sender).Parent.Parent.FindControl("txtSurcharge")).Text;
            string description = ((TextBox)((Control)sender).Parent.Parent.FindControl("txtPaymentType")).Text;
            DataAction dataAction = new DataAction();
            dataAction.UpdatePaymentType(int.Parse(id), description, double.Parse(surcharge));

        }
        protected void txtFeeCost_TextChanged(object sender, EventArgs e)
        {
            //Get the ID update the value
            string id = ((Label)((Control)sender).Parent.Parent.FindControl("lblFeeID")).Text;

            string cost = ((TextBox)((Control)sender).Parent.Parent.FindControl("txtFeeCost")).Text;
            string type = ((TextBox)((Control)sender).Parent.Parent.FindControl("txtFeeDescription")).Text;
        
            DataAction dataAction = new DataAction();
            dataAction.UpdateFeeType(int.Parse(id), double.Parse(cost), type);

        }

        protected void txtFeeType_TextChanged(object sender, EventArgs e)
        {
            //Get the ID update the value
            string id = ((Label)((Control)sender).Parent.Parent.FindControl("lblFeeID")).Text;

            string cost = ((Label)((Control)sender).Parent.Parent.FindControl("txtFeeCost")).Text;
            string type = ((Label)((Control)sender).Parent.Parent.FindControl("txtFeeDescription")).Text;

            DataAction dataAction = new DataAction();
            dataAction.UpdateFeeType(int.Parse(id), double.Parse(cost), type);

        }

        protected void DDLGST_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //Update Active GST
            if (DDLGST.SelectedValue == "")
            {
                CHKActive.Checked = false;
                TXTNewGST.Text = "";
            }
            else
            {
                try
                {
                    DataAction dataAction = new DataAction();
                    DataTable dt = dataAction.GetGSTbyID(int.Parse(DDLGST.SelectedValue.ToString()));
                
                    foreach(DataRow aRow in dt.Rows)
                    {

                        //DDLGST.DataBind();
                        TXTNewGST.Text = aRow["GSTPercent"].ToString();
      

                        if (bool.Parse(aRow["GSTStatus"].ToString()) == true)
                        {

                            CHKActive.Checked = true;
                        }
                        else
                        {
                            CHKActive.Checked = false;
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
        }

        protected void BTNSaveConditionStatus_Click(object sender, EventArgs e)
        {
            //DataAction dataAction = new DataAction();
            //try
            //{
            //    if(DDLConditionStatus.SelectedValue == "")
            //    {
            //        dataAction.CreateConditionStatus(TXTConditionCode.Text.Trim(), TXTConditionDescription.Text.Trim());
            //    }
            //    else
            //    {
            //        dataAction.UpdateConditionStatus(int.Parse(DDLConditionStatus.SelectedValue.ToString().Trim()), TXTConditionDescription.Text.Trim(), TXTConditionCode.Text.Trim());
            //    }
            //}
            //catch (Exception ex)
            //{
            //    AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
            //    "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
            //    "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + ex.Message +
            //    "</label></div>";
            //}
        }

        //protected void BTNSaveFeeType_Click(object sender, EventArgs e)
        //{
        //    DataAction dataAction = new DataAction();
        //    try
        //    {
        //        if(DDLFeeTypes.SelectedValue == "")
        //        {
        //            dataAction.CreateFeeType(double.Parse(TXTFeeCost.Text.ToString().Trim()), TXTFeeType.Text.Trim());
        //        }
        //        else
        //        {
        //            dataAction.UpdateFeeType(int.Parse(DDLFeeTypes.SelectedValue.ToString().Trim()), double.Parse((TXTFeeCost.Text.ToString().Trim())), TXTFeeType.Text.Trim());
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
        //        "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
        //        "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + ex.Message +
        //        "</label></div>";
        //    }
        //}

        //protected void BTNSavePaymentType_Click(object sender, EventArgs e)
        //{
        //    DataAction dataAction = new DataAction();
        //    try
        //    {
        //        if(DDLPaymentTypes.SelectedValue == "")
        //        {
        //            dataAction.CreatePaymentType(TXTPaymentTypes.Text.ToString().Trim());
        //        }
        //        else
        //        {
        //            dataAction.UpdatePaymentType(int.Parse(DDLPaymentTypes.SelectedValue.ToString().Trim()), TXTPaymentTypes.Text.Trim());
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
        //        "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
        //        "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + ex.Message +
        //        "</label></div>";
        //    }
        //}

        //protected void DDLConditionStatus_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if(DDLConditionStatus.SelectedValue == "")
        //    {
        //        TXTConditionCode.Text = "";
        //        TXTConditionDescription.Text = "";
        //    }
        //    else
        //    {
        //        DataAction dataAction = new DataAction();
        //        try{
        //            DataTable dt = dataAction.GetConditionStatusByID(int.Parse(DDLConditionStatus.SelectedValue.ToString().Trim()));
        //            foreach (DataRow aRow in dt.Rows)
        //            {
        //                TXTConditionDescription.Text = aRow["ConditionDescription"].ToString();
        //                TXTConditionCode.Text = aRow["ConditionCode"].ToString();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
        //            "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
        //            "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + ex.Message +
        //            "</label></div>";
        //        }
        //    }
        //}

        //protected void DDLFeeTypes_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if(DDLFeeTypes.SelectedValue == "")
        //    {
        //        TXTFeeCost.Text = "";
        //        TXTFeeType.Text = "";
        //    }
        //    else
        //    {
        //        DataAction dataAction = new DataAction();
        //        try
        //        {
        //            DataTable dt = dataAction.GetFeeTypeByID(int.Parse(DDLFeeTypes.SelectedValue.ToString()));
        //            foreach (DataRow aRow in dt.Rows)
        //            {
        //                TXTFeeCost.Text = aRow["FeeCost"].ToString();
        //                TXTFeeType.Text = aRow["FeeType"].ToString();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
        //            "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
        //            "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + ex.Message +
        //            "</label></div>";
        //        }
        //    }
        //}

        //protected void DDLPaymentTypes_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if(DDLPaymentTypes.SelectedValue == "")
        //    {
        //        TXTPaymentTypes.Text = "";
        //    }
        //    else
        //    {
        //        DataAction dataAction = new DataAction();
        //        try
        //        {
        //            DataTable dt = dataAction.GetPaymentTypeByID(int.Parse(DDLPaymentTypes.SelectedValue.ToString()));
        //            foreach (DataRow aRow in dt.Rows)
        //            {
        //                TXTPaymentTypes.Text = aRow["PaymentDescription"].ToString();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            AlertDiv.InnerHtml = "<div class=\"alert alert-danger fade in\">" +
        //            "<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>" +
        //            "<strong>Error!&nbsp;</strong><label id=\"Alert\" runat=\"server\">" + ex.Message +
        //            "</label></div>";
        //        }
        //    }

        //}
    }
}