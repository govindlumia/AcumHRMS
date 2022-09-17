using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System.Text;
using System.IO;
using QueryStringEncryption;
using InfoSoftGlobal;
using Utilities;

public partial class Recruitment_User_VacHistory : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    DataView dtView = new DataView();
    DataTable _dtEmpty = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CheckSession();
            _FillControls();
        }
    }

    private void CheckSession()
    {
        try
        {
            if (string.IsNullOrEmpty(Session["EmpCode"].ToString()))
            {
                Response.Redirect("../../Login.aspx", false);
                return;
            }
        }
        catch (Exception ex)
        {
            if (ex.Message == "Object reference not set to an instance of an object.")
            {
                Response.Redirect("../../Login.aspx");
            }
            else
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }
    }

    protected void _FillControls()
    {
        CommonBusiness _ObjCommonBAL = new CommonBusiness();
        BindDropDowns(ddlHREmp, _ObjCommonBAL.BindDropDowns_Recruitment(Session["EmpCode"].ToString(), "HREmployees"), "EmpCode", "EmpName");
        BindDropDowns(ddlOpenVac, _ObjCommonBAL.BindDropDowns_Recruitment("Open", "OpenVaccancy"), "Vac_ID", "Name");

        BindDropDowns(ddlHREmpSel, _ObjCommonBAL.BindDropDowns_Recruitment(Session["EmpCode"].ToString(), "HREmployees"), "EmpCode", "EmpName");
        BindDropDowns(ddlOpenVacSel, _ObjCommonBAL.BindDropDowns_Recruitment("Open", "OpenVaccancy"), "Vac_ID", "Name");
    }

    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
    }

    protected void GvHRExecutive_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblDate = (Label)e.Row.FindControl("lblDate");

            lblDate.Text = Convert.ToDateTime(lblDate.Text).ToString(General.DateFormatRecruitment());

        }
    }

    #region // ddl rowdatabound
    protected void ddlHREmp_DataBound(object sender, EventArgs e)
    {
        ddlHREmp.Items.Insert(0, new ListItem("---Select Employee---", "0"));
    }
    protected void ddlHREmpSel_DataBound(object sender, EventArgs e)
    {
        ddlHREmpSel.Items.Insert(0, new ListItem("---Select Employee---", "0"));
    }
    protected void ddlOpenVac_DataBound(object sender, EventArgs e)
    {
        ddlOpenVac.Items.Insert(0, new ListItem("---Select Vacancy---", "0"));
    }
    protected void ddlOpenVacSel_DataBound(object sender, EventArgs e)
    {
        ddlOpenVacSel.Items.Insert(0, new ListItem("---Select Vacancy---", "0"));
    }
    #endregion

    protected void BindHR(bool _FlgAdd)
    {
        VacENT ObjVacENT = new VacENT();
        VacBusiness ObjVacBusiness = new VacBusiness();

        if (_FlgAdd == true)
        {
            ObjVacENT.Vac_ID = ddlOpenVac.SelectedValue.ToString();
            ObjVacENT.EmpCode = "0";
        }
        else
        {
            ObjVacENT.Vac_ID = ddlOpenVacSel.SelectedValue.ToString();
            ObjVacENT.EmpCode = ddlHREmpSel.SelectedValue.ToString();
        }

        ds = ObjVacBusiness.Select_VacHRMapping(ObjVacENT);

        GvHRExecutive.DataSource = ds;
        GvHRExecutive.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        VacENT ObjVacENT = new VacENT();
        VacBusiness ObjVacBusiness = new VacBusiness();

        ObjVacENT.Vac_ID = ddlOpenVac.SelectedValue.ToString();
        ObjVacENT.EmpCode = ddlHREmp.SelectedValue.ToString();
        ObjVacENT.CreatedBy = Session["EmpCode"].ToString();

        string _Result = ObjVacBusiness.Create_VacHRMapping(ObjVacENT);

        if (string.Compare(_Result, "1") == 0)
        {
            SendMail(ddlOpenVac.SelectedValue.ToString(), ddlHREmp.SelectedValue.ToString());

            General.Alert("Record(s) Submitted Successfully", this);
            BindHR(true);
        }
        else
        {
            General.Alert("Record(s) Already Exists", this);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlOpenVacSel.SelectedIndex == 0 && ddlHREmpSel.SelectedIndex == 0)
        {
            General.Alert("Please Select Vacancy or Employee", this);
        }
        else
        {
            BindHR(false);
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlHREmpSel.SelectedIndex = 0;
        ddlOpenVacSel.SelectedIndex = 0;

        GvHRExecutive.DataSource = _dtEmpty;
        GvHRExecutive.DataBind();
    }

    protected void chkClosed_CheckedChanged(object sender, EventArgs e)
    {
        CommonBusiness _ObjCommonBAL = new CommonBusiness();
        if (chkClosed.Checked == true)
        {
            BindDropDowns(ddlOpenVacSel, _ObjCommonBAL.BindDropDowns_Recruitment("Closed", "OpenVaccancy"), "Vac_ID", "Name");
        }
        else
        {
            BindDropDowns(ddlOpenVacSel, _ObjCommonBAL.BindDropDowns_Recruitment("Open", "OpenVaccancy"), "Vac_ID", "Name");
        }

        GvHRExecutive.DataSource = _dtEmpty;
        GvHRExecutive.DataBind();
    }

    protected void SendMail(string VacCode, string EmpCode)
    {
        VacENT ObjVacENT = new VacENT();
        VacBusiness ObjVacBusiness = new VacBusiness();

        ObjVacENT.Vac_ID = VacCode;
        ObjVacENT.EmpCode = Session["EmpCode"].ToString();

        DataSet ds = ObjVacBusiness.SelectVaccancyDetails(ObjVacENT);

        if (ds.Tables[0].Rows.Count > 0)
        {
            string subInitator = string.Empty;
            string subInterviewer = string.Empty;
            string subRM = string.Empty;
            string subHC = string.Empty;
            string subCOO = string.Empty;

            StringBuilder builder = new StringBuilder();
            MailScript mail = new MailScript();

            string table = "<br/><br/><table width='100%'><tr><td width='20%'>Vacancy Code</td><td  width='80%'>" + ds.Tables[0].Rows[0]["VAC_ID"].ToString() + "</td></tr><tr><td>Job Title</td><td>" + ds.Tables[0].Rows[0]["DESIGNATIONNAME"].ToString() + "</td></tr>" +
                    "<tr><td>Location</td><td>" + ds.Tables[0].Rows[0]["BRANCH_NAME"].ToString() + "</td></tr><tr><td>No Of Positions</td><td>" + ds.Tables[0].Rows[0]["Count"].ToString() + "</td></tr>" +
                    "<tr><td>Required Date</td><td>" + Convert.ToDateTime(ds.Tables[0].Rows[0]["Req_Date"]).ToString(General.DateFormatRecruitment()) + "</td></tr><tr><td>Remarks</td><td>" + ds.Tables[0].Rows[0]["Remarks"].ToString() + "<br /><br /><br /></td></tr></table>" +
                    "Thanks And Regards,<br />Acuminous Software<br /><br /></div>";

            #region MailtoInitator
            subInitator = "Vacancy Notification – Vacancy Assigned( Reference Code : " + VacCode + " ) ";
            builder.Clear();
            builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
            "Dear User,<br /><br />Vacancy has been assigned with following details : ");
            builder.Append(table);
            mail.sendMailWithFormat(ds.Tables[3].Rows[0]["email_id"].ToString(), subInitator, builder.ToString(), null, null);
            #endregion

            #region MailtoHRHead
            subHC = "Vacancy Notification – Vacancy Assigned( Reference Code : " + VacCode + " ) ";
            builder.Clear();
            builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
            "Dear User,<br /><br />Vacancy has been assigned with following details : ");
            builder.Append(table);
            mail.sendMailWithFormat(ds.Tables[6].Rows[0]["email_id"].ToString(), subHC, builder.ToString(), null, null);
            #endregion

            #region MailtoHR
            subRM = "Interview Notification – Vacancy Assigned( Reference Code : " + VacCode + " ) ";
            builder.Clear();
            builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
            "Dear Approver,<br /><br />Interview evaluation  has been filled with following details : ");
            builder.Append(table);
            foreach (DataRow _drow in ds.Tables[4].Rows)
            {
                mail.sendMailWithFormat(_drow["email_id"].ToString(), subRM, builder.ToString(), null, null);
            }
            #endregion
        }
    }
}