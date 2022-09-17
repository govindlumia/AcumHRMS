using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QueryStringEncryption;
using System.Data;
using System.IO;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System.Text;

public partial class Recruitment_User_ViewCanAdvanceDetail : System.Web.UI.Page
{

    static DataSet ds = new DataSet();
    DataTable _dtEmpty = new DataTable();
    DataTable dt = new DataTable();
    DataView dtView = new DataView();
    int RoundCount = 1;

    string Ebackground_color = "#0287bf";
    string Ecolor = "white";
    string Dbackground_color = "white";
    string Dcolor = "black";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CheckSession();

            if (Request.QueryString["ID"] != null)
            {
                Cryptography objDec = new Cryptography();
                ViewState["ID"] = objDec.Decrypt(Request.QueryString["ID"].Replace(" ", "+").ToString());
            }
            if (Request.QueryString["E"] != null)
            {
                ViewState["Edit"] = Request.QueryString["E"].ToString();
            }

            _PageInitialise();
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

    protected void _PageInitialise()
    {
        CommonBusiness _ObjCommonBAL = new CommonBusiness();

        if (Request.QueryString["ID"] != null)
        {
            _ShowCanDetails(ViewState["ID"].ToString());
            btnSelect.Visible = false;
            BindPanel();
        }
        else
        {
            BindDropDowns(ddlVacancy, _ObjCommonBAL.BindDropDowns_Recruitment(Session["EmpCode"].ToString(), "OpenVaccancyEmp"), "Vac_ID", "Name");
            BindDropDowns(ddlCandidate, _dtEmpty, "", "");
            DivCanInfo.Visible = false;
        }

        BindDropDowns(ddlRound, _ObjCommonBAL.BindDropDowns_Recruitment(Session["EmpCode"].ToString(), "Roundmaster"), "id", "dsca");
        BindDropDowns(ddlEmployee, _ObjCommonBAL.BindDropDowns_Recruitment(Session["EmpCode"].ToString(), "Employees"), "EmpCode", "EmpName");
        BindDropDowns(ddlEmployeeAdd, _ObjCommonBAL.BindDropDowns_Recruitment(Session["EmpCode"].ToString(), "Employees"), "EmpCode", "EmpName");

        if (Convert.ToBoolean(ViewState["Edit"]) == false)
        {
            RoundCount = 1;
            ViewState["RoundCount"] = RoundCount;
            btnAddEmp.Visible = false;
        }

        _BindDDLTime(ddlHour, ddlMinute);

        EnableDisableButtons(ds);
    }
    protected void EnableDisableButtons(DataSet _ds)
    {
        btnClear.Visible = false;
        btnFinal.Visible = false;
        DivRounds.Visible = false;

        DivRP.Style["display"] = "block";
        DivRPR.Style["display"] = "none";

        lnkRP.Style["background-color"] = Ebackground_color;
        lnkRP.Style["color"] = Ecolor;
        lnkRPR.Style["background-color"] = Dbackground_color;
        lnkRPR.Style["color"] = Dcolor;

        if (Convert.ToBoolean(ViewState["Edit"]) == true)
        {
            if (string.Compare(ds.Tables[0].Rows[0]["IsRound"].ToString(), "True") == 0)
            {
                DivRounds.Visible = true;
            }
        }
    }

    protected void lnkRP_Click(object sender, EventArgs e)
    {
        DivRP.Style["display"] = "block";
        DivRPR.Style["display"] = "none";

        lnkRP.Style["background-color"] = Ebackground_color;
        lnkRP.Style["color"] = Ecolor;
        lnkRPR.Style["background-color"] = Dbackground_color;
        lnkRPR.Style["color"] = Dcolor;
    }
    protected void lnkRPR_Click(object sender, EventArgs e)
    {
        DivRP.Style["display"] = "none";
        DivRPR.Style["display"] = "block";

        lnkRP.Style["background-color"] = Dbackground_color;
        lnkRP.Style["color"] = Dcolor;
        lnkRPR.Style["background-color"] = Ebackground_color;
        lnkRPR.Style["color"] = Ecolor;
    }

    public void _BindDDLTime(DropDownList ddlHour, DropDownList ddlMinute)
    {
        List<string> Hours = new List<string>();
        for (int i = 1; i <= 12; i++)
        {
            if (i.ToString().Length < 2)
                Hours.Add("0" + i.ToString());
            else
                Hours.Add(i.ToString());
        }
        
        ddlHour.DataSource = Hours;
        ddlHour.DataBind();

        List<string> Minutes = new List<string>();
        for (int i = 0; i < 60; i++)
        {
            if (i.ToString().Length < 2)
                Minutes.Add("0" + i.ToString());
            else
                Minutes.Add(i.ToString());
        }
        ddlMinute.DataSource = Minutes;
        ddlMinute.DataBind();
    }
    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
    }
    protected void _ShowCanDetails(string CanID)
    {
        CanENT ObjCanENT = new CanENT();
        CanBusiness ObjCanBusiness = new CanBusiness();

        ObjCanENT.Can_ID = CanID;
        ObjCanENT.EmpCode = Session["EmpCode"].ToString();

        ViewState["ID"] = CanID;

        ds = ObjCanBusiness.Select_CanDetails(ObjCanENT);

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable _dt = ds.Tables[0];

            lblvacID.Text = _dt.Rows[0]["VAC_ID"].ToString();
            lblvacName.Text = _dt.Rows[0]["DESIGNATIONNAME"].ToString();
            lblCanId.Text = _dt.Rows[0]["Can_ID"].ToString();
            lblName.Text = _dt.Rows[0]["CandidateName"].ToString();
            lblEmail.Text = _dt.Rows[0]["Email_Id"].ToString();
            lblContactno.Text = _dt.Rows[0]["Contact_No"].ToString();
            lblapplicationdate.Text = Convert.ToDateTime(_dt.Rows[0]["ApplicationDate"].ToString()).ToString(General.DateFormatRecruitment());
            lblCCreatedDate.Text = Convert.ToDateTime(_dt.Rows[0]["CCREATEDDATE"].ToString()).ToString(General.DateFormatRecruitment());
            lblRemarks.Text = _dt.Rows[0]["Remarks"].ToString();

            if (Request.QueryString["ID"] != null)
            {
                ddlVacancy.Items.Insert(0, new ListItem(_dt.Rows[0]["VAC_ID"].ToString() + "-" + _dt.Rows[0]["DESIGNATIONNAME"].ToString(), _dt.Rows[0]["VAC_ID"].ToString()));
                ddlCandidate.Items.Insert(0, new ListItem(_dt.Rows[0]["Can_ID"].ToString() + "-" + _dt.Rows[0]["CandidateName"].ToString(), _dt.Rows[0]["Can_ID"].ToString()));
            }
        }

        if (string.Compare(ds.Tables[0].Rows[0]["IsRound"].ToString(), "True") == 0)
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                InsertPanelFinalDbase(ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                InsertRoundPriorityDbase(ds.Tables[2]);
            }
        }
        else
        {
            RoundCount = 1;
            ViewState["RoundCount"] = RoundCount;
        }
    }
     
    protected void ddlVacancy_DataBound(object sender, EventArgs e)
    {
        ddlVacancy.Items.Insert(0, new ListItem("---Select Vacancy---", "0"));
    }
    protected void ddlCandidate_DataBound(object sender, EventArgs e)
    {
        ddlCandidate.Items.Insert(0, new ListItem("--Select Candidate--", "0"));
    }
    protected void ddlVacancy_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlVacancy.SelectedIndex != 0)
        {
            CanENT ObjCanENT = new CanENT();
            CanBusiness ObjCanBusiness = new CanBusiness();

            ObjCanENT.Vac_ID = ddlVacancy.SelectedValue.ToString();
            ObjCanENT.Can_ID = "";
            ObjCanENT.ReqType = "HREXECUTIVE";
            ObjCanENT.CanStatusID = 2;
            ObjCanENT.FromDate = "";
            ObjCanENT.ToDate = "";
            ObjCanENT.Pageindex = 0;
            ObjCanENT.PageSize = 1000;
            ObjCanENT.SortBy = "";
            ObjCanENT.EmpCode = Session["EmpCode"].ToString();

            ds = ObjCanBusiness.Select_CanMaster(ObjCanENT);

            if (ds.Tables[0].Rows.Count > 0)
            {
                BindDropDowns(ddlCandidate, ds.Tables[0], "CAN_ID", "CANIDCANNAME");
            }
        }
    }
    protected void ddlRound_DataBound(object sender, EventArgs e)
    {
        ddlRound.Items.Insert(0, new ListItem("---Select Round---", "0"));
    }
    protected void ddlEmployee_DataBound(object sender, EventArgs e)
    {
        ddlEmployee.Items.Insert(0, new ListItem("--Select Employee--", "0"));
    }
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        if (ddlCandidate.SelectedIndex != 0)
        {
            _ShowCanDetails(ddlCandidate.SelectedValue.ToString());

            DivCanInfo.Visible = true;
        }
    }

    #region // Round Panel 
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (!ValidateEmployee())
        {
            InsertPanelUI();
            ddlEmployee.SelectedIndex = 0;
        }
        else
        {
            General.Alert("Employee Already Exist", this);
            return;
        }
        
    }
    private bool ValidateEmployee()
    {
        bool _flag = false;
        foreach (GridViewRow _Gr in GvPanel.Rows)
        {
            Label lblEmpCode = (Label)_Gr.FindControl("lblEmpCode");
            if (string.Compare(lblEmpCode.Text, ddlEmployee.SelectedValue) == 0)
            {
                _flag = true;
                break;
            }
            else
            {
                continue;
            }
        }
        return _flag;
    }
    protected void btnClearR_Click(object sender, EventArgs e)
    {
        Clear();
    }
    private void Clear()
    {
        ddlRound.Enabled = true;
        ddlRound.SelectedIndex = 0;
        ddlEmployee.SelectedIndex = 0;
        txtSchDate.Text = "";
        ViewState["NewPanel"] = null;
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearPanel();
    }
    private void ClearPanel()
    {
        ddlRound.Enabled = true;
        ddlRound.SelectedIndex = 0;
        ddlEmployee.SelectedIndex = 0;
        btnClear.Visible = false;
        btnFinal.Visible = false;

        ViewState["NewPanel"] = null;
        
        BindPanel();
    }
    private void DeleteFromPanel(int index)
    {
        if (ViewState["NewPanel"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["NewPanel"];
            if (dtCurrentTable.Rows.Count > 0)
            {
                dtCurrentTable.Rows[index - 1].Delete();
                ViewState["NewPanel"] = dtCurrentTable;
                GvPanel.DataSource = dtCurrentTable;
                GvPanel.DataBind();
            }
        }
    }
    protected void GvPanel_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BindPanel();
    }
    protected void GvPanel_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
            Label index = (Label)row.FindControl("lblSno");
            if (e.CommandName == "Delete")
            {
                DeleteFromPanel(Convert.ToInt32(index.Text));
            }
        }
    }
    protected void GvPanel_DataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color: #ccd0d2; border-bottom-style: solid; border-bottom-width: 1px; border-left-width: 1px; border-left-style: solid;  border-right-width: 1px; border-right-style: solid;";
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblFeedback = (Label)e.Row.FindControl("lblFeedback");
            Label lblFeedbackN = (Label)e.Row.FindControl("lblFeedbackN");

            if (string.Compare(lblFeedback.Text, "True") == 0)
                lblFeedbackN.Text = "Mandatory";
            else
                lblFeedbackN.Text = "Optional";
           
        }

    }
    protected void BindPanel()
    {
        if (ViewState["NewPanel"] != null)
        {
            dt = (DataTable)ViewState["NewPanel"];
            dtView = new DataView(dt);
            dtView.Sort = "Order";
            try
            {
                if (dt.Rows.Count > 0)
                {
                    GvPanel.DataSource = dtView;
                    GvPanel.DataBind();

                    btnClear.Visible = true;
                    btnFinal.Visible = true;
                }
                else
                {
                    GvPanel.DataSource = _dtEmpty;
                    GvPanel.DataBind();

                    btnClear.Visible = false;
                    btnFinal.Visible = false;
                }
            }
            catch (Exception ex)
            {
            }
        }
        else
        {
            GvPanel.DataSource = _dtEmpty;
            GvPanel.DataBind();

            btnClear.Visible = false;
            btnFinal.Visible = false;
        }
    }
    protected void Create_Panel_table()
    {
        dt = new DataTable();
        dt.Columns.Add(new DataColumn("ID", typeof(string)));
        dt.Columns.Add(new DataColumn("RoundCount", typeof(int)));
        dt.Columns.Add(new DataColumn("RoundID", typeof(string)));
        dt.Columns.Add(new DataColumn("RoundName", typeof(string)));
        dt.Columns.Add(new DataColumn("EmpCode", typeof(string)));
        dt.Columns.Add(new DataColumn("EmpName", typeof(string)));
        dt.Columns.Add(new DataColumn("Feedback", typeof(string)));
        dt.Columns.Add(new DataColumn("SchDate", typeof(string)));
        dt.Columns.Add(new DataColumn("Order", typeof(DateTime)));

        ViewState["NewPanel"] = dt;
    }
    protected void InsertPanelUI()
    {
        DataRow dr;
        if (ViewState["NewPanel"] == null)
            Create_Panel_table();
        dt = (DataTable)ViewState["NewPanel"];
        
        RoundCount = Convert.ToInt32(ViewState["RoundCount"].ToString());

        dr = dt.NewRow();
        dr["ID"] = Guid.NewGuid().ToString();
        dr["RoundCount"] = RoundCount;
        dr["RoundID"] = ddlRound.SelectedValue.ToString();
        dr["RoundName"] = ddlRound.SelectedItem.ToString();
        dr["EmpCode"] = ddlEmployee.SelectedValue.ToString();
        dr["EmpName"] = ddlEmployee.SelectedItem.ToString();
        dr["Feedback"] = ChkFeedback.Checked;

        TimeSpan time = new TimeSpan(int.Parse(ddlHour.SelectedValue), int.Parse(ddlMinute.SelectedValue), 0);

        DateTime _SchDateTime = new DateTime();

        if (ddlTime.SelectedIndex == 0) //// AM
            _SchDateTime = Convert.ToDateTime(txtSchDate.Text.ToString()).Add(time);
        if (ddlTime.SelectedIndex == 1) //// PM
            _SchDateTime = Convert.ToDateTime(txtSchDate.Text.ToString()).Add(time).AddHours(12);

        dr["SchDate"] = _SchDateTime;
        dr["Order"] = DateTime.Now;

        try
        {
            dt.Rows.Add(dr);
        }
        catch (Exception ex)
        {

        }
        ViewState["NewPanel"] = dt;
        BindPanel();
    }
    protected void ddlRound_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRound.SelectedIndex != 0)
        {
            ddlRound.Enabled = false;

            btnClear.Visible = false;
            btnFinal.Visible = false;
        }
    }
    protected void btnFinal_Click(object sender, EventArgs e)
    {
        InsertPanelFinalUI();

        ViewState["RoundCount"] = Convert.ToInt32(ViewState["RoundCount"].ToString()) + 1;

        InsertRoundPriorityUI();
    }
    #endregion

    #region // Round Panel Final 

    private void DeleteFromPanelFinal(int index)
    {
        if (ViewState["NewPanelFinal"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["NewPanelFinal"];
            if (dtCurrentTable.Rows.Count > 0)
            {
                dtCurrentTable.Rows[index - 1].Delete();
                ViewState["NewPanelFinal"] = dtCurrentTable;
                GvPanelFinal.DataSource = dtCurrentTable;
                GvPanelFinal.DataBind();
            }
        }
    }
    protected void GvPanelFinal_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BindPanelFinal();
    }
    protected void GvPanelFinal_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Update")
        {
            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
            Label lblRoundCode = (Label)row.FindControl("lblRoundCode");
            Label lblEmpCode = (Label)row.FindControl("lblEmpCode");
            DropDownList ddlFeedback = (DropDownList)row.FindControl("ddlFeedback");

            if (ValidateFeedbackCount(lblRoundCode.Text, ddlFeedback.SelectedIndex.ToString()))
            {
                RoundENT ObjRoundENT = new RoundENT();
                RoundBusiness ObjRoundBusiness = new RoundBusiness();

                ObjRoundENT.RoundCode = lblRoundCode.Text;

                if (string.Compare(ddlFeedback.SelectedIndex.ToString(), "0") == 0)
                    ObjRoundENT.IsFeedback = "1"; // Mandatory
                else
                    ObjRoundENT.IsFeedback = "0"; // Optional

                ObjRoundENT.EmpCode = lblEmpCode.Text;
                ObjRoundENT.Feedback = "0";
                ObjRoundENT.CanStatus = "1";
                ObjRoundENT.ModifiedBy = Session["EmpCode"].ToString();

                string _Result = ObjRoundBusiness.Update_CanRoundEmpMapping(ObjRoundENT);

                CanENT ObjCanENT = new CanENT();
                CanBusiness ObjCanBusiness = new CanBusiness();

                ObjCanENT.Can_ID = lblCanId.Text.ToString();
                ObjCanENT.EmpCode = Session["EmpCode"].ToString();

                ds = ObjCanBusiness.Select_CanDetails(ObjCanENT);

                ViewState["NewPanelFinal"] = null;

                InsertPanelFinalDbase(ds.Tables[1]);
            }
            else
            {
                General.Alert("Minimum one feedback is mandatory ", this);
                return;
            }
        }
    }
    private bool ValidateFeedbackCount(string _RoundCode, string Feedback)
    {
        bool _flag = false;

        dt = (DataTable)ViewState["NewPanelFinal"];

        DataTable _dtPanel = (DataTable)ViewState["NewPanelFinal"];

        DataRow[] results = _dtPanel.Select(" RoundCode = '" + _RoundCode + "' AND Feedback = 'True' ");

        if (results.Length == 1 && Feedback == "1")
            _flag = false;
        else
            _flag = true;

        return _flag;
    }
    protected void GvPanelFinal_DataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color: #ccd0d2; border-bottom-style: solid; border-bottom-width: 1px; border-left-width: 1px; border-left-style: solid;  border-right-width: 1px; border-right-style: solid;";
        }

        if (Convert.ToBoolean(ViewState["Edit"]) == false)
        {
            GvPanelFinal.Columns[1].Visible = false; // Round Code
            GvPanelFinal.Columns[5].Visible = false; // Edit
        }

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState != DataControlRowState.Edit && e.Row.RowState != (DataControlRowState.Edit | DataControlRowState.Alternate))
        {
            Label lblFeedback = (Label)e.Row.FindControl("lblFeedback");
            Label lblFeedbackN = (Label)e.Row.FindControl("lblFeedbackN");
            LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
            Label lblRoundCode = (Label)e.Row.FindControl("lblRoundCode");
            Label lblRStatus = (Label)e.Row.FindControl("lblRStatus");
            
            if (string.Compare(lblFeedback.Text, "True") == 0)
                lblFeedbackN.Text = "Mandatory";
            else
                lblFeedbackN.Text = "Optional";

            if (string.Compare(lblRoundCode.Text, "") == 0 || string.Compare(lblRStatus.Text, "4") == 0)
            {
                lnkEdit.Visible = false;
            }
        }

    }
    protected void GvPanelFinal_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GvPanelFinal.EditIndex = e.NewEditIndex;
        BindPanelFinal();
    }
    protected void GvPanelFinal_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GvPanelFinal.EditIndex = -1;
        BindPanelFinal();
    }
    protected void GvPanelFinal_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GvPanelFinal.EditIndex = -1;
        BindPanelFinal();
    }
    protected void BindPanelFinal()
    {
        if (ViewState["NewPanelFinal"] != null)
        {
            dt = (DataTable)ViewState["NewPanelFinal"];
            dtView = new DataView(dt);
            dtView.Sort = "Order";
            try
            {
                if (dt.Rows.Count > 0)
                {
                    GvPanelFinal.DataSource = dtView;
                    GvPanelFinal.DataBind();

                    DivRounds.Visible = true;
                }
                else
                {
                    GvPanelFinal.DataSource = _dtEmpty;
                    GvPanelFinal.DataBind();

                    DivRounds.Visible = false;
                }
            }
            catch (Exception ex)
            {
            }
        }
        else
        {
            GvPanelFinal.DataSource = _dtEmpty;
            GvPanelFinal.DataBind();

            DivRounds.Visible = false;
        }
    }
    protected void Create_Panel_Final_table()
    {
        dt = new DataTable();
        dt.Columns.Add(new DataColumn("ID", typeof(string)));
        dt.Columns.Add(new DataColumn("RoundCode", typeof(string)));
        dt.Columns.Add(new DataColumn("RoundCount", typeof(int)));
        dt.Columns.Add(new DataColumn("RoundID", typeof(string)));
        dt.Columns.Add(new DataColumn("RoundName", typeof(string)));
        dt.Columns.Add(new DataColumn("EmpCode", typeof(string)));
        dt.Columns.Add(new DataColumn("EmpName", typeof(string)));
        dt.Columns.Add(new DataColumn("Feedback", typeof(string)));
        dt.Columns.Add(new DataColumn("SchDate", typeof(string)));
        dt.Columns.Add(new DataColumn("RSTATUS", typeof(string)));
        dt.Columns.Add(new DataColumn("Order", typeof(DateTime)));

        ViewState["NewPanelFinal"] = dt;
    }
    protected void InsertPanelFinalUI()
    {
        DataRow dr;
        if (ViewState["NewPanelFinal"] == null)
            Create_Panel_Final_table();
        dt = (DataTable)ViewState["NewPanelFinal"];

        foreach (GridViewRow _Gr in GvPanel.Rows)
        {
            dr = dt.NewRow();

            dr["ID"] = Guid.NewGuid().ToString();

            Label lblRoundCount = (Label)_Gr.FindControl("lblRoundCount");
            Label lblRoundID = (Label)_Gr.FindControl("lblRoundID");
            Label lblRoundName = (Label)_Gr.FindControl("lblRoundName");
            Label lblEmpCode = (Label)_Gr.FindControl("lblEmpCode");
            Label lblEmpName = (Label)_Gr.FindControl("lblEmpName");
            Label lblFeedback = (Label)_Gr.FindControl("lblFeedback");
            Label lblSchDate = (Label)_Gr.FindControl("lblSchDate");

            dr["RoundCode"] = "";
            dr["RoundCount"] = lblRoundCount.Text;
            dr["RoundID"] = lblRoundID.Text;
            dr["RoundName"] = lblRoundName.Text;
            dr["EmpCode"] = lblEmpCode.Text;
            dr["EmpName"] = lblEmpName.Text;
            dr["SchDate"] = lblSchDate.Text;
            dr["Feedback"] = lblFeedback.Text;
            dr["RSTATUS"] = "";
            dr["Order"] = DateTime.Now;

            try
            {
                dt.Rows.Add(dr);
            }
            catch (Exception ex)
            {

            }
        }
        ViewState["NewPanelFinal"] = dt;

        ClearPanel();

        BindPanelFinal();
    }
    protected void InsertPanelFinalDbase(DataTable _dt)
    {
        DataRow dr;
        if (ViewState["NewPanelFinal"] == null)
            Create_Panel_Final_table();
        dt = (DataTable)ViewState["NewPanelFinal"];

        ViewState["RoundCount"] = 1;

        for (int i = 0; i < _dt.Rows.Count; i++)
        {
            if (i > 0)
            {
                // Compare with previous row using index
                if (_dt.Rows[i]["RoundCode"].ToString() != _dt.Rows[i - 1]["RoundCode"].ToString())
                {
                    ViewState["RoundCount"] = Convert.ToInt32(ViewState["RoundCount"].ToString()) + 1;
                }
            }

            dr = dt.NewRow();
            dr["ID"] = Guid.NewGuid().ToString();
            dr["RoundCode"] = _dt.Rows[i]["RoundCode"].ToString();
            dr["RoundCount"] = Convert.ToInt32(ViewState["RoundCount"].ToString());
            dr["RoundID"] = _dt.Rows[i]["RoundID"].ToString();
            dr["RoundName"] = _dt.Rows[i]["ROUNDNAME"].ToString();
            dr["EmpCode"] = _dt.Rows[i]["EMPCODE"].ToString();
            dr["EmpName"] = _dt.Rows[i]["EMPNAME"].ToString();
            dr["Feedback"] = _dt.Rows[i]["ISFEEDBACK"].ToString();
            dr["RSTATUS"] = _dt.Rows[i]["RSTATUS"].ToString();
            dr["Order"] = DateTime.Now;

            try
            {
                dt.Rows.Add(dr);
            }
            catch (Exception ex)
            {

            }
        }

        ViewState["RoundCount"] = Convert.ToInt32(ViewState["RoundCount"].ToString()) + 1;

        ViewState["NewPanelFinal"] = dt;

        BindPanelFinal();
    }

    #endregion  

    #region // Round Priority

    protected void Create_Round_Priority_table()
    {
        dt = new DataTable();
        dt.Columns.Add(new DataColumn("ID", typeof(string)));
        dt.Columns.Add(new DataColumn("RoundCode", typeof(string)));
        dt.Columns.Add(new DataColumn("RoundID", typeof(string)));
        dt.Columns.Add(new DataColumn("RoundName", typeof(string)));
        dt.Columns.Add(new DataColumn("SchDate", typeof(string)));
        dt.Columns.Add(new DataColumn("Priority", typeof(int)));
        dt.Columns.Add(new DataColumn("CStatus", typeof(string)));
        dt.Columns.Add(new DataColumn("RStatus", typeof(string)));
        dt.Columns.Add(new DataColumn("CURROUND", typeof(string)));
        dt.Columns.Add(new DataColumn("Order", typeof(DateTime)));

        ViewState["NewRoundSch"] = dt;
    }
    protected void InsertRoundPriorityUI()
    {
        DataRow dr;

        if (Convert.ToBoolean(ViewState["Edit"]) == false)
            ViewState["NewRoundSch"] = null;

        if (ViewState["NewRoundSch"] == null)
            Create_Round_Priority_table();
        dt = (DataTable)ViewState["NewRoundSch"];

        DataTable _dtPanelNew = (DataTable)ViewState["NewPanelFinal"];

        DataRow[] results = _dtPanelNew.Select(" RoundCode = '' ");

        _dtPanelNew = results.CopyToDataTable();

        DataView view = new DataView(_dtPanelNew);
        DataTable distinctValues = view.ToTable(true, "RoundCount", "RoundID", "RoundName","SchDate");

        foreach (DataRow _dr in distinctValues.Rows)
        {
            dr = dt.NewRow();
            dr["ID"] = Guid.NewGuid().ToString();
            dr["Priority"] = Convert.ToInt32(_dr["RoundCount"].ToString());
            dr["RoundCode"] = "";
            dr["RoundID"] = _dr["RoundID"].ToString();
            dr["RoundName"] = _dr["RoundName"].ToString();
            dr["SchDate"] = _dr["SchDate"].ToString();
            dr["CStatus"] = "";
            dr["RStatus"] = "";
            dr["CURROUND"] = "";
            dr["Order"] = DateTime.Now;

            try
            {
                dt.Rows.Add(dr);
            }
            catch (Exception ex)
            {

            }
        }
        ViewState["NewRoundSch"] = dt;

        BindRoundPriority();
    }
    protected void BindRoundPriority()
    {
        if (ViewState["NewRoundSch"] != null)
        {
            dt = (DataTable)ViewState["NewRoundSch"];
            dtView = new DataView(dt);
            dtView.Sort = "Order";
            try
            {
                if (dt.Rows.Count > 0)
                {
                    GvRoundSch.DataSource = dtView;
                    GvRoundSch.DataBind();

                    BindRoundDll();
                }
                else
                {
                    GvRoundSch.DataSource = _dtEmpty;
                    GvRoundSch.DataBind();
                }
            }
            catch (Exception ex)
            {
            }
        }
        else
        {
            GvRoundSch.DataSource = _dtEmpty;
            GvRoundSch.DataBind();
        }
    }
    protected void InsertRoundPriorityDbase(DataTable _dt)
    {
        DataRow dr;

        ViewState["NewRoundSch"] = null;

        if (ViewState["NewRoundSch"] == null)
            Create_Round_Priority_table();
        dt = (DataTable)ViewState["NewRoundSch"];

        int RoundCount = 1;

        foreach (DataRow _dr in _dt.Rows)
        {
            dr = dt.NewRow();

            dr["ID"] = Guid.NewGuid().ToString();
            dr["Priority"] = RoundCount++;
            dr["RoundCode"] = _dr["RoundCode"].ToString();
            dr["RoundID"] = _dr["RoundID"].ToString();
            dr["RoundName"] = _dr["RoundName"].ToString();
            dr["SchDate"] = _dr["SCHDATE"].ToString();
            dr["CStatus"] = _dr["CANSTATUS"].ToString();
            dr["RStatus"] = _dr["ROUNDSTATUS"].ToString();
            dr["CURROUND"] = _dr["CURROUND"].ToString();
            dr["Order"] = DateTime.Now;

            try
            {
                dt.Rows.Add(dr);
            }
            catch (Exception ex)
            {

            }
        }

        ViewState["NewRoundSch"] = dt;

        BindRoundPriority();
    }
    protected void GvRoundSch_DataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color: #ccd0d2; border-bottom-style: solid; border-bottom-width: 1px; border-left-width: 1px; border-left-style: solid;  border-right-width: 1px; border-right-style: solid;";
        }

        if (Convert.ToBoolean(ViewState["Edit"]) == false)
        {
            GvRoundSch.Columns[1].Visible = false; // Round Code
            GvRoundSch.Columns[4].Visible = false; // Can Status
            GvRoundSch.Columns[6].Visible = false; // Action
        }

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState != DataControlRowState.Edit && e.Row.RowState != (DataControlRowState.Edit | DataControlRowState.Alternate))
        {
            Label lblRoundCode = (Label)e.Row.FindControl("lblRoundCode");
            LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
            LinkButton lnkMTN = (LinkButton)e.Row.FindControl("lnkMTN");
            Label lblSchDateDisplay = (Label)e.Row.FindControl("lblSchDateDisplay");
            Label lblTimeDisplay = (Label)e.Row.FindControl("lblTimeDisplay");
            Label lblCURROUND = (Label)e.Row.FindControl("lblCURROUND");
            Label lblRStatus = (Label)e.Row.FindControl("lblRStatus");

            if (string.Compare(lblRoundCode.Text, "") == 0 || string.Compare(lblRStatus.Text, "Completed") == 0)
            {
                lnkEdit.Visible = false;
            }

            lblTimeDisplay.Text = Convert.ToDateTime(lblSchDateDisplay.Text).ToString("t");
            lblSchDateDisplay.Text = Convert.ToDateTime(lblSchDateDisplay.Text).ToString(General.DateFormatRecruitment());

            if (string.Compare(lblCURROUND.Text, "True") == 0)
                lnkMTN.Visible = true;
            else
                lnkMTN.Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DropDownList ddlHour = (DropDownList)e.Row.FindControl("ddlHour");
                DropDownList ddlMinute = (DropDownList)e.Row.FindControl("ddlMinute");

                _BindDDLTime(ddlHour, ddlMinute);
            }
        }
    }
    protected void GvRoundSch_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GvRoundSch.EditIndex = e.NewEditIndex;
        BindRoundPriority();
    }
    protected void GvRoundSch_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GvRoundSch.EditIndex = -1;
        BindRoundPriority();
    }
    protected void GvRoundSch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Update")
        {
            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);

            Label lblRoundCode = (Label)row.FindControl("lblRoundCode");
            TextBox txtSchDate = (TextBox)row.FindControl("txtSchDate");
            DropDownList ddlHour = (DropDownList)row.FindControl("ddlHour");
            DropDownList ddlMinute = (DropDownList)row.FindControl("ddlMinute");

            RoundENT ObjRoundENT = new RoundENT();
            RoundBusiness ObjRoundBusiness = new RoundBusiness();

            TimeSpan time = new TimeSpan(int.Parse(ddlHour.SelectedValue), int.Parse(ddlMinute.SelectedValue), 0);

            DateTime _SchDateTime = new DateTime();

            if (ddlTime.SelectedIndex == 0) //// AM
                _SchDateTime = Convert.ToDateTime(txtSchDate.Text.ToString()).Add(time);
            if (ddlTime.SelectedIndex == 1) //// PM
                _SchDateTime = Convert.ToDateTime(txtSchDate.Text.ToString()).Add(time).AddHours(12);

            ObjRoundENT.RoundCode = lblRoundCode.Text;
            ObjRoundENT.SchDate = _SchDateTime;
            ObjRoundENT.Type = "SchDate";
            ObjRoundENT.EmpCode = Session["EmpCode"].ToString();

            string _Result = ObjRoundBusiness.Update_CanRoundSchDetails(ObjRoundENT);

            General.Alert("Record(s) has been updated", this);

            CanENT ObjCanENT = new CanENT();
            CanBusiness ObjCanBusiness = new CanBusiness();

            ObjCanENT.Can_ID = lblCanId.Text.ToString();
            ObjCanENT.EmpCode = Session["EmpCode"].ToString();

            ds = ObjCanBusiness.Select_CanDetails(ObjCanENT);

            if (ds.Tables[2].Rows.Count > 0)
            {
                InsertRoundPriorityDbase(ds.Tables[2]);
            }
        }
        if (e.CommandName == "MTN")
        {
            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);

            Label lblRoundCode = (Label)row.FindControl("lblRoundCode");

            RoundENT ObjRoundENT = new RoundENT();
            RoundBusiness ObjRoundBusiness = new RoundBusiness();

            ObjRoundENT.RoundCode = lblRoundCode.Text;
            ObjRoundENT.SchDate = DateTime.Now;
            ObjRoundENT.Type = "MTN";
            ObjRoundENT.EmpCode = Session["EmpCode"].ToString();

            string _Result = ObjRoundBusiness.Update_CanRoundSchDetails(ObjRoundENT);

            General.Alert("Record(s) has been updated", this);

            CanENT ObjCanENT = new CanENT();
            CanBusiness ObjCanBusiness = new CanBusiness();

            ObjCanENT.Can_ID = lblCanId.Text.ToString();
            ObjCanENT.EmpCode = Session["EmpCode"].ToString();

            ds = ObjCanBusiness.Select_CanDetails(ObjCanENT);

            if (ds.Tables[1].Rows.Count > 0)
            {
                InsertPanelFinalDbase(ds.Tables[1]);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                InsertRoundPriorityDbase(ds.Tables[2]);
            }
        }
    }
    protected void GvRoundSch_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GvRoundSch.EditIndex = -1;
        BindRoundPriority();
        BindRoundDll();
    }
   
    #endregion

    protected void BindRoundDll()
    {
        if (ViewState["NewRoundSch"] != null)
        {
            DataTable _dt = (DataTable)ViewState["NewRoundSch"];

            DataRow[] results = _dt.Select(" RStatus <> 'Completed' ");

            _dt = results.CopyToDataTable();

            if (_dt.Rows.Count > 0)
            {
                try
                {
                    ddlRoundsAdd.DataSource = _dt;
                    ddlRoundsAdd.DataValueField = "RoundCode";
                    ddlRoundsAdd.DataTextField = "RoundCode";
                    ddlRoundsAdd.DataBind();
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                btnAddEmp.Visible = false;
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string _RoundCode = "";
        foreach (GridViewRow _GrSch in GvRoundSch.Rows)
        {
            Label lblRoundCode = (Label)_GrSch.FindControl("lblRoundCode");
            Label lblRoundID = (Label)_GrSch.FindControl("lblRoundID");
            Label lblSchDate = (Label)_GrSch.FindControl("lblSchDate");

            if (lblRoundCode.Text == "")
            {
                RoundENT ObjRoundENT = new RoundENT();
                RoundBusiness ObjRoundBusiness = new RoundBusiness();

                ObjRoundENT.Can_ID = lblCanId.Text.ToString();
                ObjRoundENT.Round_ID = lblRoundID.Text.ToString();
                ObjRoundENT.SchDate = Convert.ToDateTime(lblSchDate.Text.ToString());
                ObjRoundENT.EmpCode = Session["EmpCode"].ToString();

                _RoundCode = ObjRoundBusiness.Create_CanRoundSchDetails(ObjRoundENT);

                SendMail("Initiator", _RoundCode, "");

                DataTable _dt = (DataTable)ViewState["NewPanelFinal"];
                DataRow[] result = _dt.Select("RoundID = '" + lblRoundID.Text + "'");

                foreach (DataRow _dr in result)
                {
                    RoundENT ObjRoundENT2 = new RoundENT();
                    RoundBusiness ObjRoundBusiness2 = new RoundBusiness();

                    ObjRoundENT2.RoundCode = _RoundCode.ToString();
                    ObjRoundENT2.Can_ID = lblCanId.Text.ToString();
                    ObjRoundENT2.EmpCode = _dr["EmpCode"].ToString();
                    ObjRoundENT2.IsFeedback = _dr["Feedback"].ToString();
                    ObjRoundENT2.CreatedBy = Session["EmpCode"].ToString();

                    string _StrResult = ObjRoundBusiness2.Create_CanRoundEmpMapping(ObjRoundENT2);

                    CommonBusiness _ObjCommonBAL = new CommonBusiness();

                    DataTable _DtEmail = _ObjCommonBAL.BindDropDowns_Recruitment(_dr["EmpCode"].ToString(), "GetEmail");

                    if (_DtEmail.Rows.Count > 0)
                    {
                        SendMail("Employee", _RoundCode, _DtEmail.Rows[0]["Email_ID"].ToString());
                    }
                }
            }
        }

        RoundENT ObjRoundENT3 = new RoundENT();
        RoundBusiness ObjRoundBusiness3 = new RoundBusiness();

        ObjRoundENT3.RoundCode = lblCanId.Text.ToString();
        ObjRoundENT3.SchDate = DateTime.Now;
        ObjRoundENT3.Type = "Rounds";
        ObjRoundENT3.EmpCode = Session["EmpCode"].ToString();

        string _StrResult1 = ObjRoundBusiness3.Update_CanRoundSchDetails(ObjRoundENT3);

        Cryptography objEnc = new Cryptography();
        string key = objEnc.Encrypt(lblCanId.Text.ToString());
        StringWriter writer = new StringWriter();
        HttpContext.Current.Server.UrlEncode(key, writer);

        string url = "CanViewDetails.aspx?ID=" + writer.ToString() + "&Type=HRE";

        General.Alert("Rounds has been created successfully", btnSubmit, url);
    }

    protected void btnAddEmp_Click(object sender, EventArgs e)
    {
        DivAdd.Style["display"] = "block";
    }
    protected void imgButAdd_Click(object sender, EventArgs e)
    {
        DivAdd.Style["display"] = "none";
    }

    protected void btnAddEmpSubmit_Click(object sender, EventArgs e)
    {
        if (ValidateEmployeeAddEmp())
        {
            RoundENT ObjRoundENT = new RoundENT();
            RoundBusiness ObjRoundBusiness = new RoundBusiness();

            ObjRoundENT.RoundCode = ddlRoundsAdd.SelectedValue.ToString();
            ObjRoundENT.Can_ID = lblCanId.Text.ToString();
            ObjRoundENT.EmpCode = ddlEmployeeAdd.SelectedValue.ToString();
            ObjRoundENT.IsFeedback = ChkFeedbackAdd.Checked.ToString();
            ObjRoundENT.CreatedBy = Session["EmpCode"].ToString();

            string _result = ObjRoundBusiness.Create_CanRoundEmpMapping(ObjRoundENT);

            General.Alert("Employee has been added successfully", this);

            CanENT ObjCanENT = new CanENT();
            CanBusiness ObjCanBusiness = new CanBusiness();

            ObjCanENT.Can_ID = lblCanId.Text.ToString();
            ObjCanENT.EmpCode = Session["EmpCode"].ToString();

            ds = ObjCanBusiness.Select_CanDetails(ObjCanENT);

            ViewState["NewPanelFinal"] = null;

            InsertPanelFinalDbase(ds.Tables[1]);

            DivAdd.Style["display"] = "none";
        }
        else
        {
            General.Alert("Employee already exists in this round", this);
            return;
        }
    }

    private bool ValidateEmployeeAddEmp()
    {
        bool _flag = false;

        dt = (DataTable)ViewState["NewPanelFinal"];

        DataTable _dtPanel = (DataTable)ViewState["NewPanelFinal"];

        DataRow[] results = _dtPanel.Select(" RoundCode = '" + ddlRoundsAdd.SelectedValue.ToString() + "' AND EmpCode = '" + ddlEmployeeAdd.SelectedValue.ToString() + "' ");

        if (results.Length > 0)
            _flag = false;
        else
            _flag = true;

        return _flag;
    }

    protected void SendMail(string StrAction, string _RoundCode, string Email_ID)
    {
        CanENT ObjCanENT = new CanENT();
        CanBusiness ObjCanBusiness = new CanBusiness();

        ObjCanENT.Can_ID = ViewState["ID"].ToString();
        ObjCanENT.EmpCode = Session["EmpCode"].ToString();

        ds = ObjCanBusiness.Select_CanDetails(ObjCanENT);

        DataTable _dt = ds.Tables[2];
        DataRow[] result = _dt.Select("RoundCode = '" + _RoundCode + "'");

        if (result.Length > 0)
        {
            string subInitator = string.Empty;
            string subInterviewer = string.Empty;
            string subRM = string.Empty;
            string subHC = string.Empty;
            string subCOO = string.Empty;

            StringBuilder builder = new StringBuilder();
            MailScript mail = new MailScript();

            string table = "<br/><br/><table width='100%'><tr><td width='20%'>Vacancy Code</td><td  width='80%'>" + ds.Tables[0].Rows[0]["VAC_ID"].ToString() + "</td></tr><tr><td>Job Title</td><td>" + ds.Tables[0].Rows[0]["DESIGNATIONNAME"].ToString() + "</td></tr>" +
                        "<tr><td>Candidate Name</td><td>" + ds.Tables[0].Rows[0]["CANDIDATENAME"].ToString() + "</td></tr><tr><td>Interview Date</td><td>" + Convert.ToDateTime(result[0]["SCHDATE"]).ToString(General.DateFormatRecruitment()) + "</td></tr>" +
                        "<tr><td>Interview Time</td><td>" + Convert.ToDateTime(result[0]["SCHDATE"]).ToString("t")+ "</td></tr>" +
                        "<tr><td>Round Name</td><td>" + result[0]["RoundName"].ToString() + "</td></tr><tr><td><br /><br /><br /></td></tr></table>" +
                        "Thanks And Regards,<br />Acuminous Software<br /><br /></div>";

            if (StrAction == "Initiator")
            {
                #region MailtoInitator
                subInitator = "Round Notification – Round Scheduled( Reference Code : " + _RoundCode + " ) ";

                builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                "Dear User,<br /><br />Interview has been scheduled with following details : ");
                builder.Append(table);
                mail.sendMailWithFormat(ds.Tables[3].Rows[0]["email_id"].ToString(), subInitator, builder.ToString(), null, null);
                #endregion

                #region MailtoHR
                subRM = "Round Notification – Round Scheduled ( Reference Code : " + _RoundCode + " ) ";
                builder.Clear();
                builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                "Dear Approver,<br /><br />Interview has been scheduled with following details :  ");
                builder.Append(table);
                foreach (DataRow _drow in ds.Tables[4].Rows)
                {
                    mail.sendMailWithFormat(_drow["email_id"].ToString(), subRM, builder.ToString(), null, null);
                }
                #endregion
            }
            if (StrAction == "Employee")
            {
                #region Mailtointerviewer
                subInterviewer = "Round Notification – Round Scheduled ( Reference Code : " + _RoundCode + " ) ";

                builder.Append("<div runat='server' id='dv_head' style='background-color: 	#E8E8E8 ;width:500px;height:300px;font:  bold 12px verdana, Helvetica, sans-serif;'>" +
                "Dear User,<br /><br /> Employee Interview has been scheduled with following details : ");
                builder.Append(table);
                mail.sendMailWithFormat(Email_ID, subInterviewer, builder.ToString(), null, null);
                #endregion
            }
        }
    }
}