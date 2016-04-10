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
                    //Check the Condition Status table for any blank rows, if there isn't one add one. If there is do nothing
                    DataTable dt;

                    dt = dataAction.CheckConditionStatus();
                    if (dt.Rows.Count == 0)
                    {
                        //Create a new blank row entry
                        dataAction.CreateConditionStatus(null, null);


                    }
                    //Check the fee types to for any blank rows, if there isnt one add one. If there is do nothing




                    dt =  dataAction.CheckFeeTypes();
                    if (dt.Rows.Count == 0)
                    {
                        dataAction.CreateFeeType(double.Parse(""), null);
                    }

                    dt = dataAction.CheckPaymentTypes();
                    if (dt.Rows.Count == 0)
                    {
                        dataAction.CreatePaymentType(null, 0);
                    }

                    dt = dataAction.GetGST();
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
      

                    //Load All Payment Types
                    dt = dataAction.GetPaymentType();
                    GRDPaymentTypes.DataSource = dt;
                    GRDPaymentTypes.DataBind();

                    
                  

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

        protected void gv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView gridView = (GridView)sender;
            gridView.EditIndex = e.NewEditIndex;
            try
            {
                //Load All GST
                DataAction dataAction = new DataAction();
                DataTable dt = dataAction.GetGST();

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

        protected void gv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView gridView = (GridView)sender;
            gridView.EditIndex = -1;
            try
            {
                //Load All GST
                DataAction dataAction = new DataAction();
                DataTable dt = dataAction.GetGST();

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

        protected void GRDConditionStatus_Updating(object sender, EventArgs e)
        {

          Label alabel = (Label)GRDConditionStatus.Rows[GRDConditionStatus.EditIndex].FindControl("lblCondtionID"); 
            TextBox atextbox = (TextBox)GRDConditionStatus.Rows[GRDConditionStatus.EditIndex].FindControl("txtConditionCode");
            CheckBox acb = (CheckBox)GRDConditionStatus.Rows[GRDConditionStatus.EditIndex].FindControl("cbStatus");
            //Get the ID update the value
            string id = alabel.Text;
            string value = atextbox.Text;
            bool cbValue = acb.Checked;
            DataAction dataAction = new DataAction();
            dataAction.UpdateConditionStatus(int.Parse(id), value, "", cbValue);
          
        }

        protected void GRDFeeTypes_Updating(object sender, EventArgs e)
        {
            //Get the ID update the value
            Label alabel = (Label)GRDFeeTypes.Rows[GRDFeeTypes.EditIndex].FindControl("lblFeeID");
            string id = alabel.Text;
            TextBox atextbox = (TextBox)GRDFeeTypes.Rows[GRDFeeTypes.EditIndex].FindControl("txtFeeCost");
            string cost = atextbox.Text;
            atextbox = (TextBox)GRDFeeTypes.Rows[GRDFeeTypes.EditIndex].FindControl("txtFeeDescription");
            string type = atextbox.Text;
            CheckBox acb = (CheckBox)GRDFeeTypes.Rows[GRDFeeTypes.EditIndex].FindControl("cbStatus");
            bool status = acb.Checked;

            DataAction dataAction = new DataAction();
            dataAction.UpdateFeeType(int.Parse(id), double.Parse(cost), type, status);

        }

        protected void GRDPaymentTypes_Updating(object sender, EventArgs e)
        {
            //Get the ID update the value
            string id = ((Label)((Control)sender).Parent.Parent.FindControl("lblPaymentTypeID")).Text;
            string surcharge = ((TextBox)((Control)sender).Parent.Parent.FindControl("txtSurcharge")).Text;
            string description = ((TextBox)((Control)sender).Parent.Parent.FindControl("txtPaymentType")).Text;
            DataAction dataAction = new DataAction();
            dataAction.UpdatePaymentType(int.Parse(id), description, double.Parse(surcharge));

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

       

     
    }
}