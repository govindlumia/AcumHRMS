using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_Admin_TrainingMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    protected void BindData()
    {

        DataSet dsTrining = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "TrainingMasterData");

        grdResult.DataSource = dsTrining.Tables[0].Rows.Count > 0 ? dsTrining.Tables[0] : null;
        grdResult.DataBind();

        if (dsTrining.Tables[1].Rows.Count > 0)
        {
            drpType.DataSource = dsTrining.Tables[1];
            drpType.DataValueField = "Id";
            drpType.DataTextField = "TrainingType";
            drpType.DataBind();

            drpType.Items.Insert(0, new ListItem("--Select--", "0"));
        }

    }

    protected void drpType_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtType.Visible = false;
        RequiredFieldValidator2.Enabled = false;
        if (drpType.SelectedIndex > 0 && drpType.SelectedItem.Text == "Other")
        {
            txtType.Visible = true;
            RequiredFieldValidator2.Enabled = true;
        }
    }
    protected void btnKRAHeadSave_Click(object sender, EventArgs e)
    {
        var id = 0;
        if (drpType.SelectedItem.Text == "Other")
        {
            id = Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, "Insert into KRATrainingTypeMaster(TrainingType) values('" + txtType.Text + "') select @@IDENTITY").ToString());
        }
        else
        {
            id = Convert.ToInt32(drpType.SelectedValue.ToString());
        }

        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, "Insert into KRATrainingMaster(TrainingTypeId,Training) values('" + id.ToString() + "','" + txtTraining.Text + "')");

        BindData();

        General.Alert("Record submitted successfully", btnKRAHeadSave);

        Reset();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Reset();
    }

    protected void Reset()
    {
        drpType.SelectedIndex = 0;
        txtType.Visible = false;
        RequiredFieldValidator2.Enabled = false;
        txtTraining.Text = string.Empty;
        txtType.Text = string.Empty;
    }

    protected void grdResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, "Update KRATrainingMaster set IsActive=0 where Id = '" + id.ToString() + "'");
            General.Alert("Record deleted successfully", btnKRAHeadSave);
            BindData();
            Reset();
        }
    }
}