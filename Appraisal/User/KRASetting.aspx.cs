using HRMS.BusinessEntity.Appraisal;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using HRMS.BusinessLogic.Appraisal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;

public partial class Appraisal_User_KRASetting : System.Web.UI.Page
{
    KRAMasterBAL _objBAL;
    public Appraisal_User_KRASetting()
    {
        _objBAL = new KRAMasterBAL();
    }
    void BindKRAHead()
    {
        int currentKRASettingID = Convert.ToInt32(HttpContext.Current.Items["CurrentKRAID"]);
        KRASettingMasterEntity objEntity = new KRASettingMasterEntity();
        KRAMasterBAL objBAL = new KRAMasterBAL();
        objEntity.CompanyId = Convert.ToInt32(Session["CompanyId"].ToString());
        objEntity.DesignationId = Convert.ToInt32(drp_designation_name.SelectedValue);

        DataSet dsResult = objBAL.KTASettingMasterData(objEntity, 1);
        if (currentKRASettingID == 0)
        {
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                trCreate.Visible = true;
                ViewState["KRASettingData"] = dsResult.Tables[1];
            }
            else
            {
                trCreate.Visible = false;
                General.Alert("KRA has not been set for selected designation, kindly contact administrator.", btnSubmit);
            }
        }

        var _objKRAHeadBAL = new AppraisalKRAHeadBAL();
        grdKRAHead.DataSource = _objKRAHeadBAL.GetAll();
        grdKRAHead.DataBind();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpCode"] == null)
        {
            Session.RemoveAll();
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {
            //int currentKRASettingID = Convert.ToInt32(HttpContext.Current.Items["CurrentKRAID"]);
            //if (currentKRASettingID != 0)
            //{
            //    var lst = _objBAL.SelectKRASettingByKRASettingID(currentKRASettingID);
            //    txtComment.Text = lst.First().Comment;
            //    ViewState["lst"] = lst;
            //    ViewState["KRASettingId"] = lst.First().ID;

            //    DropDownList drpReview = ((DropDownList)userControlEmployee.FindControl("drpReviewPeriod"));
            //    Label lblReview = ((Label)userControlEmployee.FindControl("lblPeriod"));

            //    drpReview.Visible = false;
            //    lblReview.Text = lst.FirstOrDefault().KRADuration;
            //}
            //else
            //{
            //    PeriodCheck();
            //}
            DropDownList drpReview = ((DropDownList)userControlEmployee.FindControl("drpReviewPeriod"));
            Label lblReview = ((Label)userControlEmployee.FindControl("lblPeriod"));

            drpReview.Visible = false;
            lblReview.Text = "N/A";
            BindDesignation();
            grdKRAHead.DataSource = null;
            grdKRAHead.DataBind();
            //BindKRAHead();
        }
    }

    private void PeriodCheck()
    {
        AppraisalPeriodBAL objPeriodBAL = new AppraisalPeriodBAL();
        DataTable dt = objPeriodBAL.AppraisalPeriodCompanyEmployee(Session["CompanyId"].ToString(), Session["EmpCode"].ToString(), 0);

        if (dt.Rows.Count > 0)
        {
            if (dt.Columns.Contains("Error"))
            {
                General.Alert("KRA already exists.", btnSubmit, "welcome.aspx");
            }
            else
            {
                DropDownList drpReview = ((DropDownList)userControlEmployee.FindControl("drpReviewPeriod"));
                Label lblReview = ((Label)userControlEmployee.FindControl("lblPeriod"));

                drpReview.Visible = false;
                lblReview.Text = "N/A";

                //drpReview.DataSource = dt;
                //drpReview.DataValueField = "Year";
                //drpReview.DataTextField = "Duration";
                //drpReview.DataBind();

                //if (dt.Rows.Count == 1)
                //{
                //    drpReview.Enabled = false;
                //}

                //lblReview.Text = drpReview.SelectedItem.Text + "(" + drpReview.SelectedValue + ")";
            }
        }
        else
        {
            General.Alert("KRA does not exists please contact Admin.", btnSubmit, "welcome.aspx");
        }
    }

    List<KRAMasterEntity> ListKRAMaster { get; set; }
    void BindValues(GridView grd, int idToDelete = 0, string command = "", string empcode = "")
    {
        if (grd != null)
        {
            foreach (GridViewRow row in grd.Rows)
            {
                TextBox txtKRA = (TextBox)row.FindControl("txtKRA");
                TextBox txtComments = (TextBox)row.FindControl("txtComments");
                TextBox txtWeightage = (TextBox)row.FindControl("txtWeightage");

                LinkButton lnkDelete = (LinkButton)row.FindControl("lnkDelete");

                if (command == "Delete" && idToDelete > 0 && grd.Rows.Count > 1)
                {
                    if (idToDelete == Convert.ToInt32(lnkDelete.CommandArgument))
                        continue;
                }
                KRAMasterEntity master = new KRAMasterEntity()
                {
                    KRA = txtKRA.Text,
                    KRAComment = txtComments.Text,
                    WeightAge = Convert.ToDecimal(txtWeightage.Text),
                    ID = Convert.ToInt32(lnkDelete.CommandArgument),
                    CreatedBy = Convert.ToString(Session["EmpCode"]),
                    EmpCode = empcode
                };

                if (ListKRAMaster == null)
                {
                    ListKRAMaster = new List<KRAMasterEntity>();
                    master.ID = 1;
                }

                ListKRAMaster.Add(master);
            }

        }

    }
    void AddDefaultRow()
    {
        KRAMasterEntity master = new KRAMasterEntity();
        master.KRAComment = "";
        master.WeightAge = 0;
        master.KRA = "";

        if (ListKRAMaster == null)
        {
            ListKRAMaster = new List<KRAMasterEntity>();
            master.ID = 1;
        }
        else
            master.ID = ListKRAMaster.Max(m => m.ID) + 1;

        ListKRAMaster.Add(master);

    }
    public void BindKRA(GridView grdPrimaryKRA)
    {
        grdPrimaryKRA.DataSource = ListKRAMaster;
        grdPrimaryKRA.DataBind();
    }
    protected void btnAddMorePrimaryKRA_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
    }
    protected void grdPrimaryKRA_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView grd = (GridView)sender;

        if (e.CommandName == "DeleteRecord")
        {
            BindValues(grd, Convert.ToInt32(e.CommandArgument), "Delete");
            BindKRA(grd);
        }
    }
    protected void SaveData(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        DataSet ds = new DataSet();

        var count = 0;
        foreach (ListItem item in lstEmployee.Items)
        {
            if (item.Selected == true)
            {
                count++;
                break;
            }
        }

        if (count == 0)
        {
            General.Alert("Select Subordinates.", btnSubmit);
            lstEmployee.Focus();
            return;
        }

        if (string.IsNullOrEmpty(txtComment.Text))
        {
            General.Alert("Comments are mandatory", btnSubmit);
            btnSubmit.Focus();
            return;
        }

        try
        {
            string error = "";
            string name = "";
            foreach (ListItem item in lstEmployee.Items)
            {
                if (item.Selected == true)
                {
                    name += item.Text.ToString() + ",";
                    var kraSetting = new KRAMasterEntity()
                    {
                        ID = 0,
                        EmpCode = item.Value, //((Label)userControlEmployee.FindControl("lbl_emp_code")).Text,
                        CreatedBy = Convert.ToString(Session["EmpCode"]),
                        KRAComment = txtComment.Text,
                        IsDraft = btn.ID == btnSubmit.ID ? false : true,
                    };

                    if (ViewState["KRASettingId"] != null)
                    {
                        kraSetting.ID = Convert.ToInt32(ViewState["KRASettingId"]);
                        kraSetting.Duration = "";
                        kraSetting.Year = 0;
                    }
                    kraSetting.Duration = "";
                    kraSetting.Year = 0;

                    ds = _objBAL.Create(kraSetting);

                    #region Insert KRA Detail
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(ds.Tables[0].Rows[0][0]).Contains("Success"))
                        {
                            var kraSettingID = Convert.ToInt64(ds.Tables[0].Rows[0][1]);
                            foreach (GridViewRow row in grdKRAHead.Rows)
                            {
                                var lblKRAHeadID = (Label)row.FindControl("lblKRAHeadID");
                                var grdPK = (GridView)row.FindControl("grdPrimaryKRA");
                                if (grdPK != null)
                                {
                                    ListKRAMaster = null;
                                    BindValues(grdPK, 0, "", item.Value);
                                }
                                foreach (KRAMasterEntity kra in ListKRAMaster)
                                {
                                    if (lblKRAHeadID != null)
                                        kra.KRAHeadID = Convert.ToInt32(lblKRAHeadID.Text);
                                    kra.KRASettingID = kraSettingID;

                                    _objBAL.CreateSettingDetail(kra);
                                }
                            }
                            //General.Alert("Record saved successfully.", btn, "ViewStatusKRA.aspx");
                        }
                        else
                        {
                            error += item.Text + " : " + ds.Tables[0].Rows[0][0].ToString();
                            //General.Alert(ds.Tables[0].Rows[0][0].ToString(), btnSubmit);
                        }
                    }
                    #endregion
                }
            }

            string message = "Record submitted successfully.";
            if (!string.IsNullOrEmpty(error))
            {
                message = "Record submitted with following errors: " + error;
            }

            SendMail(name);
            General.Alert(message, btn, "Welcome.aspx");
        }

        catch (Exception ex)
        {
            General.Alert(ConfigHelper.MessageError, btn);
        }
    }

    protected void SendMail(string empName)
    {
        try
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            SqlParameter[] sqlparm = new SqlParameter[2];
            sqlparm[0] = new SqlParameter("@kraFormId", "");

            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "GetAMSMails", sqlparm);

            if (ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[1].Rows)
                {

                    string ToEmail = ds.Tables[1].Rows[0]["EmailId"].ToString();
                    string userName = ConfigurationManager.AppSettings["UserName"].ToString();
                    string password = ConfigurationManager.AppSettings["Password"].ToString();
                    NetworkCredential basicCredential = new NetworkCredential(userName, password);

                    MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["FromAddress"].ToString());
                    smtpClient.Host = ConfigurationManager.AppSettings["SmtpHost"].ToString();
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Port = 25;
                    smtpClient.Credentials = basicCredential;
                    message.From = fromAddress;
                    smtpClient.EnableSsl = true;
                    message.To.Add(ToEmail.ToString());

                    message.Subject = "Appraisal Notification – KRA Submitted for Approval by " + Session["EmpName"].ToString();
                    message.IsBodyHtml = true;
                    message.Body = "Hi " + ds.Tables[1].Rows[0]["EmpName"].ToString() + " <br> " + Session["EmpName"].ToString() + " has submitted the KRA for " + empName + ". Login to HCMS portal to initiate the appraisal process.<br><br><br>Thanks<br>Acuminous Software<br><br><br><br>This is an automated notification.<br>";
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
                System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                System.Security.Cryptography.X509Certificates.X509Chain chain,
                System.Net.Security.SslPolicyErrors sslPolicyErrors)
                    {
                        return true;
                    };
                    smtpClient.Send(message);
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void grdKRAHead_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView grdPK = (GridView)e.Row.FindControl("grdPrimaryKRA");
            var KRASetting = (List<KRASetting>)ViewState["lst"];
            Label lblID = (Label)e.Row.FindControl("lblKRAHeadID");
            Label weightAge = (Label)e.Row.FindControl("lblweightage");

            weightAge.Text = Math.Round(Convert.ToDecimal(weightAge.Text), 0).ToString();

            var intId = Convert.ToInt32(lblID.Text);
            if (Convert.ToInt32(HttpContext.Current.Items["CurrentKRAID"]) != 0 && ViewState["KRASettingData"] == null)
            {
                if (grdPK != null)
                {
                    var lst = KRASetting.Where(m => m.KRAHeadID == intId);
                    List<KRASettingDetail> detail = lst.SelectMany(m => m.KRASettingDetails).ToList();
                    if (detail != null)
                        grdPK.DataSource = detail;
                    else
                        grdPK.DataSource = null;

                    grdPK.DataBind();
                }
            }
            else
            {
                if (grdPK != null && ViewState["KRASettingData"] == null)
                {
                    ListKRAMaster = null;
                    AddDefaultRow();
                    BindKRA(grdPK);
                }
                else
                {
                    DataTable dtData = (DataTable)ViewState["KRASettingData"];
                    var lst = dtData.Select("KRAHeadId=" + intId + " and DesignationId=" + drp_designation_name.SelectedValue);
                    List<KRASettingMasterEntity> detail = new List<KRASettingMasterEntity>();
                    KRASettingMasterEntity objEnt;
                    foreach (var item in lst)
                    {
                        objEnt = new KRASettingMasterEntity();
                        objEnt.KRA = item[7].ToString();
                        objEnt.WeightAge = Convert.ToDecimal(item[8].ToString());
                        objEnt.ID = Convert.ToInt32(item[0].ToString());
                        objEnt.KRAComment = "";
                        detail.Add(objEnt);
                    }
                    if (detail != null)
                        grdPK.DataSource = detail;
                    else
                        grdPK.DataSource = null;

                    grdPK.DataBind();
                }
            }

        }
    }
    protected void grdKRAHead_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "AddMore")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            GridView grd = (GridView)gvr.FindControl("grdPrimaryKRA");

            BindValues(grd);
            AddDefaultRow();
            BindKRA(grd);
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("welcome.aspx");
    }

    private void BindDesignation()
    {
        DesignationQuery = String.Format(DesignationQuery, Session["EmpCode"].ToString());
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, DesignationQuery);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            drp_designation_name.DataSource = ds.Tables[0];
            drp_designation_name.DataTextField = "designationname";
            drp_designation_name.DataValueField = "id";
            drp_designation_name.DataBind();
            drp_designation_name.Items.Insert(0, new ListItem("--Select--", "0"));

            lstEmployee.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }

    protected void drp_designation_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        lstEmployee.Items.Clear();

        grdKRAHead.DataSource = null;
        grdKRAHead.DataBind();

        if (drp_designation_name.SelectedIndex > 0)
        {
            EmployeeQuery = String.Format(EmployeeQuery, Session["EmpCode"].ToString(), drp_designation_name.SelectedValue);
            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, EmployeeQuery);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                lstEmployee.DataSource = ds.Tables[0];
                lstEmployee.DataTextField = "empname";
                lstEmployee.DataValueField = "empcode";
                lstEmployee.DataBind();
            }

            BindKRAHead();
        }
        else
        {
            lstEmployee.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }

    private string DesignationQuery = @" Select designationname,id from tbl_DesignationMaster where id in(
                    Select distinct degination_id from tbl_intranet_employee_jobDetails where empcode in(
                    select employeecode from tbl_Employee_Hierarchy where approverid={0} and approverpriority=1)
                    and emp_status not in (10,12)) order by designationname asc";

    private string EmployeeQuery = @"Select distinct dbo.GetEmpName(empcode) as empname,empcode from tbl_intranet_employee_jobDetails where empcode in(
                    select employeecode from tbl_Employee_Hierarchy where approverid={0} and approverpriority=1)
                    and emp_status not in (10,12) and degination_id={1}";

}