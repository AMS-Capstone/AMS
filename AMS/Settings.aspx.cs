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
                //Load All Payment Types
            }
        }

        protected void BTNAddNewGST_Click(object sender, EventArgs e)
        {
            DataAction dataAction = new DataAction();
            //Add New GST
            if (TXTNewGST.Text.Trim() == "")
            {
              
                dataAction.CreateGSTEntry(double.Parse(TXTNewGST.Text.Trim()), true);
            }
            else
            {
                dataAction.UpdateGSTEntry(int.Parse(DDLGST.SelectedValue.ToString()), double.Parse(TXTNewGST.Text.Trim()), true);
            }
   
        }

   
        protected void BTNSave_Click(object sender, EventArgs e)
        {
            DataAction dataAction = new DataAction();
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
        }

        protected void BTNSaveConditionStatus_Click(object sender, EventArgs e)
        {
            DataAction dataAction = new DataAction();
            if(DDLConditionStatus.SelectedValue == "")
            {
                dataAction.CreateConditionStatus(TXTConditionCode.Text.Trim(), TXTConditionDescription.Text.Trim());
            }
            else
            {
                dataAction.UpdateConditionStatus(int.Parse(DDLConditionStatus.SelectedValue.ToString().Trim()), TXTConditionDescription.Text.Trim(), TXTConditionCode.Text.Trim());
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

                DataTable dt = dataAction.GetConditionStatusByID(int.Parse(DDLConditionStatus.SelectedValue.ToString().Trim()));

                foreach(DataRow aRow in dt.Rows )
                {
                    TXTConditionDescription.Text = aRow["CondidtionDescription"].ToString();
                    TXTConditionCode.Text = aRow["ConditionCode"].ToString();
                }
            }
        }
    }
}