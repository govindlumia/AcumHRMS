using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Appraisal_User_TrainingUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpCode"] == null)
        {
            Session.RemoveAll();
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {
            txtSDate.Attributes.Add("readonly", "readonly");
            txtEDate.Attributes.Add("readonly", "readonly");
            txtSDate.Text = System.DateTime.Today.Date.AddDays(-7).ToString("dd-MMM-yyyy");
            txtEDate.Text = System.DateTime.Today.Date.ToString("dd-MMM-yyyy");
            txtFrom.Attributes.Add("readonly", "readonly");
            txtTo.Attributes.Add("readonly", "readonly");
            txtTrainingDate.Attributes.Add("readonly", "readonly");
            txtValid.Attributes.Add("readonly", "readonly");
            BinData();
        }
    }

    protected void BinData()
    {
        DataTable dtResult = GetAllByUser();
        if (dtResult.Rows.Count > 0)
        {
            grdResult.DataSource = dtResult;
            grdResult.DataBind();
        }
        else
        {
            grdResult.DataSource = null;
            grdResult.DataBind();
        }
    }

    protected DataTable GetAllByUser()
    {
        TrainingEntity objEntity = new TrainingEntity();
        TrainingBAL objBAL = new TrainingBAL();
        objEntity.TrainingName = txtSName.Text;
        objEntity.FromDate = Convert.ToDateTime(txtSDate.Text);
        objEntity.ToDate = Convert.ToDateTime(txtEDate.Text);
        objEntity.CreatedBy = Session["EmpCode"].ToString();
        DataTable dt = objBAL.GetByUser(objEntity);

        return dt;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (!Validate())
            return;

        TrainingEntity objEntity = new TrainingEntity();
        TrainingBAL objBAL = new TrainingBAL();
        objEntity.Id = btnAdd.Text == "Update" ? Convert.ToInt32(txtTrainingName.ToolTip) : 0;
        objEntity.TrainingName = txtTrainingName.Text;
        objEntity.TrainingType = rdnType.SelectedItem.Text;
        objEntity.Date = System.DateTime.Now;
        objEntity.Venue = txtVenue.Text;
        objEntity.ConductedBy = txtConducted.Text;
        objEntity.FromDate = Convert.ToDateTime(txtFrom.Text);
        objEntity.ToDate = Convert.ToDateTime(txtTo.Text);
        objEntity.Hours = String.IsNullOrEmpty(txtHours.Text) ? 0 : Convert.ToInt32(txtHours.Text);
        objEntity.CertificationReceived = chkCertification.SelectedItem.Value == "1" ? true : false;
        if (objEntity.CertificationReceived)
        {
            objEntity.CertificationValidDate = Convert.ToDateTime(txtValid.Text);
            if (flp.HasFile)
            {
                Random nxt = new Random();
                string fileName = nxt.Next().ToString() + flp.PostedFile.FileName.Replace(" ", "_").ToString();
                objEntity.FileName = fileName;
                fileName = Server.MapPath("~\\Appraisal\\UploadFile\\") + fileName;
                flp.SaveAs(fileName);
            }
        }
        else
        {
            objEntity.CertificationValidDate = System.DateTime.Today.Date.AddYears(-10);
            objEntity.FileName = "";
        }
        objEntity.Comments = txtComments.Text;
        objEntity.CreatedBy = Session["EmpCode"].ToString();
        objEntity.Status = "0";
        objBAL.Create(objEntity);
        General.Alert("Record Added Successfully", btnAdd);
        BinData();
        Reset();
    }

    private Boolean Validate()
    {
        var isValid = true;

        if (String.IsNullOrEmpty(txtTrainingName.Text))
        {
            isValid = false;
            General.Alert("Enter Training Name.", btnAdd);
        }
        DateTime d;
        if (String.IsNullOrEmpty(txtVenue.Text))
        {
            isValid = false;
            General.Alert("Enter Venue.", btnAdd);
        }

        if (String.IsNullOrEmpty(txtConducted.Text))
        {
            isValid = false;
            General.Alert("Enter Conducted by.", btnAdd);
        }

        if (!DateTime.TryParse(txtFrom.Text, out d))
        {
            isValid = false;
            General.Alert("Enter Valid From Date.", btnAdd);
        }
        if (!DateTime.TryParse(txtTo.Text, out d))
        {
            isValid = false;
            General.Alert("Enter Valid To Date.", btnAdd);
        }

        if (Convert.ToDateTime(txtFrom.Text) > Convert.ToDateTime(txtTo.Text))
        {
            isValid = false;
            General.Alert("From date can not be greater than To date.", btnAdd);
        }

        if (Convert.ToDateTime(txtFrom.Text) > System.DateTime.Now)
        {
            isValid = false;
            General.Alert("From date can not be future date.", btnAdd);
        }

        if (Convert.ToDateTime(txtTo.Text) > System.DateTime.Now)
        {
            isValid = false;
            General.Alert("To date can not be future date.", btnAdd);
        }

        if (!String.IsNullOrEmpty(txtHours.Text))
        {
            int n;
            if (!int.TryParse(txtHours.Text, out n))
            {
                isValid = false;
                General.Alert("Enter Valid No of Hours.", btnAdd);
            }
        }

        if (chkCertification.SelectedItem.Value == "1")
        {
            if (!DateTime.TryParse(txtValid.Text, out d))
            {
                isValid = false;
                General.Alert("Enter Valid Date.", btnAdd);
            }

            if (Convert.ToDateTime(txtValid.Text) <= Convert.ToDateTime(txtTo.Text))
            {
                isValid = false;
                General.Alert("Certification valid date must be greater than Training duration date.", btnAdd);
            }

            if (!flp.HasFile)
            {
                isValid = false;
                General.Alert("Upload certification.", btnAdd);
            }
        }

        if (String.IsNullOrEmpty(txtComments.Text))
        {
            isValid = false;
            General.Alert("Enter Comments", btnAdd);
        }

        return isValid;
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Reset();
    }
    protected void Reset()
    {
        btnAdd.Text = "Add";
        txtTrainingName.Text = string.Empty;
        rdnType.SelectedIndex = 0;
        txtTrainingDate.Text = string.Empty;
        txtVenue.Text = string.Empty;
        txtConducted.Text = string.Empty;
        txtFrom.Text = string.Empty;
        txtTo.Text = string.Empty;
        txtHours.Text = string.Empty;
        chkCertification.Items.FindByValue("0").Selected = true;
        flp.Dispose();
        txtValid.Text = string.Empty;
        txtComments.Text = string.Empty;
        trView.Visible = true;
        trCreate.Visible = false;

        btnCreate.Visible = true;
        btnView.Visible = false;
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        Reset();
        trView.Visible = true;
        trCreate.Visible = false;
        btnCreate.Visible = true;
        btnView.Visible = false;
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        Reset();
        trView.Visible = false;
        trCreate.Visible = true;
        btnCreate.Visible = false;
        btnView.Visible = true;
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        BinData();
    }
    protected void grdResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument);
        TrainingEntity objEntity = new TrainingEntity();
        objEntity.Id = id;

        TrainingBAL objBAL = new TrainingBAL();

        DataTable dt = new DataTable();

        switch (e.CommandName)
        {
            case "E":
                dt = objBAL.GetById(objEntity);
                trView.Visible = false;
                trCreate.Visible = true;
                btnView.Visible = true;
                btnCreate.Visible = false;
                BindDataForEdit(dt);
                break;
            case "D":
                objBAL.DeleteById(objEntity);
                BinData();
                break;
        }
    }
    private void BindDataForEdit(DataTable dt)
    {
        txtTrainingName.Text = dt.Rows[0]["TrainingName"].ToString();
        txtTrainingName.ToolTip = dt.Rows[0]["Id"].ToString();
        if (!String.IsNullOrEmpty(dt.Rows[0]["TrainingType"].ToString()))
            rdnType.Items.FindByText(dt.Rows[0]["TrainingType"].ToString()).Selected = true;

        txtTrainingDate.Text = dt.Rows[0]["Date"].ToString();
        txtVenue.Text = dt.Rows[0]["Venue"].ToString();
        txtConducted.Text = dt.Rows[0]["ConductedBy"].ToString();
        txtFrom.Text = dt.Rows[0]["FromDate"].ToString();
        txtTo.Text = dt.Rows[0]["ToDate"].ToString();
        txtHours.Text = dt.Rows[0]["Hours"].ToString();
        if (dt.Rows[0]["CertificationReceived"].ToString() == "Yes")
        {
            divValidDate.Visible = true;
            chkCertification.Items.FindByValue("1").Selected = true;
            txtValid.Text = dt.Rows[0]["ValidDate"].ToString();
            if (!String.IsNullOrEmpty(dt.Rows[0]["FileName"].ToString()))
            {
                lnkFile.Visible = true;
                lnkFile.HRef = dt.Rows[0]["FileName"].ToString();
            }
        }
        txtComments.Text = dt.Rows[0]["Comments"].ToString();
        btnAdd.Text = "Update";
    }
    protected void grdResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hdn = (HiddenField)e.Row.FindControl("hdnValue");
            HtmlAnchor lnkV = (HtmlAnchor)e.Row.FindControl("lnkView");
            LinkButton lnkE = (LinkButton)e.Row.FindControl("lnkEdit");
            LinkButton lnkD = (LinkButton)e.Row.FindControl("lnlDelete");
            Label lblS = (Label)e.Row.FindControl("Status");

            if (lblS.Text.Contains("Approved"))
            {
                lnkE.Visible = false;
                lnkD.Visible = false;
            }

            lnkV.HRef = "JavaScript:newPopup1('TrainingDetail.aspx?Id=" + Convert.ToInt32(hdn.Value) + "')";
        }
    }
    protected void grdResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdResult.PageIndex = e.NewPageIndex;
        BinData();
    }
    protected void chkCertification_SelectedIndexChanged(object sender, EventArgs e)
    {
        divValidDate.Visible = false;
        if (chkCertification.SelectedItem.Value.ToString() == "1")
        {
            divValidDate.Visible = true;
        }
        else
        {
            txtValid.Text = "";
            flp.Dispose();
        }
    }
}