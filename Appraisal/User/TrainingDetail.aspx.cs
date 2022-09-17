using DataAccessLayer;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_User_TrainingDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.HasKeys())
        {
            int Id = Convert.ToInt32(Request.QueryString["Id"].ToString());
            BindData(Id);
        }
    }

    private void BindData(int id)
    {
        TrainingEntity objEntity = new TrainingEntity();
        TrainingBAL objBAL = new TrainingBAL();
        objEntity.Id = id;

        DataTable dtResult = objBAL.GetById(objEntity);

        if (dtResult.Rows.Count > 0)
        {
            lblName.Text = dtResult.Rows[0][1].ToString();
            lblType.Text = dtResult.Rows[0][2].ToString();
            lblDate.Text = dtResult.Rows[0][3].ToString();
            lblVenue.Text = dtResult.Rows[0][4].ToString();
            lblConducted.Text = dtResult.Rows[0][5].ToString();
            lblDuration.Text = dtResult.Rows[0][6].ToString() + " - " + dtResult.Rows[0][8].ToString();
            lblHours.Text = dtResult.Rows[0][7].ToString();
            lblCertification.Text = dtResult.Rows[0][9].ToString() + "" + dtResult.Rows[0][10].ToString();
            lblComments.Text = dtResult.Rows[0][12].ToString();
            lnkFile.Visible = false;
            if (!String.IsNullOrEmpty(dtResult.Rows[0][11].ToString()))
            {
                lnkFile.Visible = true;
                lnkFile.HRef = "http://103.16.140.21:9001/Appraisal/UploadFile/" + dtResult.Rows[0][11].ToString();
            }
        }
    }
}