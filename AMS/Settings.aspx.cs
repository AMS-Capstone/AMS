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
                    DDLConditionStatus.DataSource = dt;
                    DDLConditionStatus.DataValueField = dt.Columns["ConditionID"].ToString();
                    DDLConditionStatus.DataTextField = dt.Columns["Description"].ToString();
                    DDLConditionStatus.DataBind();
                    DDLConditionStatus.Items.Insert(0, new ListItem(String.Empty, String.Empty));

                    //Load All Fee Types
                
                    dt = dataAction.GetFeeType();
                    DDLFeeTypes.DataSource = dt;
                    DDLFeeTypes.DataValueField = dt.Columns["FeeId"].ToString();
                    DDLFeeTypes.DataTextField = dt.Columns["description"].ToString();
                    DDLFeeTypes.DataBind();
                    DDLFeeTypes.Items.Insert(0, new ListItem(String.Empty, String.Empty));

                    //Load All Payment Types
                    dt = dataAction.GetPaymentType();
                    DDLPaymentTypes.DataSource = dt;
                    DDLPaymentTypes.DataValueField = dt.Columns["PaymentTypeID"].ToString();
                    DDLPaymentTypes.DataTextField = dt.Columns["PaymentDescription"].ToString();
                    DDLPaymentTypes.DataBind();
                    DDLPaymentTypes.Items.Insert(0, new ListItem(String.Empty, String.Empty));

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
            DataAction dataAction = new DataAction();
            try
            {
                if(DDLConditionStatus.SelectedValue == "")
                {
                    dataAction.CreateConditionStatus(TXTConditionCode.Text.Trim(), TXTConditionDescription.Text.Trim());
                }
                else
                {
                    dataAction.UpdateConditionStatus(int.Parse(DDLConditionStatus.SelectedValue.ToString().Trim()), TXTConditionDescription.Text.Trim(), TXTConditionCode.Text.Trim());
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

        protected void BTNSaveFeeType_Click(object sender, EventArgs e)
        {
            DataAction dataAction = new DataAction();
            try
            {
                if(DDLFeeTypes.SelectedValue == "")
                {
                    dataAction.CreateFeeType(double.Parse(TXTFeeCost.Text.ToString().Trim()), TXTFeeType.Text.Trim());
                }
                else
                {
                    dataAction.UpdateFeeType(int.Parse(DDLFeeTypes.SelectedValue.ToString().Trim()), double.Parse((TXTFeeCost.Text.ToString().Trim())), TXTFeeType.Text.Trim());
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

        protected void BTNSavePaymentType_Click(object sender, EventArgs e)
        {
            DataAction dataAction = new DataAction();
            try
            {
                if(DDLPaymentTypes.SelectedValue == "")
                {
                    dataAction.CreatePaymentType(TXTPaymentTypes.Text.ToString().Trim());
                }
                else
                {
                    dataAction.UpdatePaymentType(int.Parse(DDLPaymentTypes.SelectedValue.ToString().Trim()), TXTPaymentTypes.Text.Trim());
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

        protected void DDLConditionStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DDLConditionStatus.SelectedValue == "")
            {
                TXTConditionCode.Text = "";
                TXTConditionDescription.Text = "";
            }
            else
            {
                DataAction dataAction = new DataAction();
                try{
                    DataTable dt = dataAction.GetConditionStatusByID(int.Parse(DDLConditionStatus.SelectedValue.ToString().Trim()));
                    foreach (DataRow aRow in dt.Rows)
                    {
                        TXTConditionDescription.Text = aRow["ConditionDescription"].ToString();
                        TXTConditionCode.Text = aRow["ConditionCode"].ToString();
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

        protected void DDLFeeTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DDLFeeTypes.SelectedValue == "")
            {
                TXTFeeCost.Text = "";
                TXTFeeType.Text = "";
            }
            else
            {
                DataAction dataAction = new DataAction();
                try
                {
                    DataTable dt = dataAction.GetFeeTypeByID(int.Parse(DDLFeeTypes.SelectedValue.ToString()));
                    foreach (DataRow aRow in dt.Rows)
                    {
                        TXTFeeCost.Text = aRow["FeeCost"].ToString();
                        TXTFeeType.Text = aRow["FeeType"].ToString();
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

        protected void DDLPaymentTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DDLPaymentTypes.SelectedValue == "")
            {
                TXTPaymentTypes.Text = "";
            }
            else
            {
                DataAction dataAction = new DataAction();
                try
                {
                    DataTable dt = dataAction.GetPaymentTypeByID(int.Parse(DDLPaymentTypes.SelectedValue.ToString()));
                    foreach (DataRow aRow in dt.Rows)
                    {
                        TXTPaymentTypes.Text = aRow["PaymentDescription"].ToString();
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
    }
}