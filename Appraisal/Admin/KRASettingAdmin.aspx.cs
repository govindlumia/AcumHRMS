using DataAccessLayer;
using HRMS.BusinessEntity;
using HRMS.BusinessEntity.Appraisal;
using HRMS.BusinessLogic;
using HRMS.BusinessLogic.Appraisal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_Admin_KRASettingAdmin : System.Web.UI.Page
{
    KRAMasterBAL _objBAL;
    public static int Int_PageIndex = 1;
    public static int Int_Page_Size = 2;
    public static int int_Total = 0;
    public static int int_TotalRecords = 0;

    public Appraisal_Admin_KRASettingAdmin()
    {
        _objBAL = new KRAMasterBAL();
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
            Int_PageIndex = 1;
            int_TotalRecords = 0;
            BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
            BindDropDowns(drp_comp_name, binddrop.BindDropDowns("", "Company"), "companyid", "companyname");
            BindListBox(drpdegination, binddrop.BindDropDowns(drp_comp_name.SelectedValue, "Designation"), "id", "designationname");
            BindDropDowns(drpCDesignation, binddrop.BindDropDowns(drp_comp_name.SelectedValue, "CopyFromDesignation"), "id", "designationname");
            BindKRAHead();
        }
    }
    protected void drp_comp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
        BindListBox(drpdegination, binddrop.BindDropDowns(drp_comp_name.SelectedValue, "Designation"), "id", "designationname");
        BindDropDowns(drpCDesignation, binddrop.BindDropDowns(drp_comp_name.SelectedValue, "CopyFromDesignation"), "id", "designationname");

        if (divView.Visible == true)
        {
            BindListBox(drpdegination, binddrop.BindDropDowns(drp_comp_name.SelectedValue, "CopyFromDesignation"), "id", "designationname");
            BindSettingData();
        }
        else
        {
            if (drpdegination.SelectedIndex > 0)
                BindKRAHead();
        }
    }
    private void BindSettingData()
    {
        KRASettingMasterEntity objEntity = new KRASettingMasterEntity();
        KRAMasterBAL objBAL = new KRAMasterBAL();
        objEntity.CompanyId = Convert.ToInt32(drp_comp_name.SelectedValue);
        objEntity.DesignationId = Convert.ToInt32(drpdegination.SelectedValue);

        DataSet dsResult = objBAL.KTASettingMasterData(objEntity, Int_PageIndex);
        if (dsResult.Tables[2].Rows.Count > 0)
        {
            ViewState["dsResult"] = dsResult.Tables[2];
            ViewState["dsResultDetail"] = dsResult.Tables[3];
            grdView.DataSource = dsResult.Tables[2];
            grdView.DataBind();

            if (dsResult.Tables[4].Rows[0][0] != null)
                int_TotalRecords = Convert.ToInt32(dsResult.Tables[4].Rows[0][0]);
            else
                int_TotalRecords = 0;
        }
        else
        {
            grdView.DataSource = null;
            grdView.DataBind();
        }

        CustomPaging(lblTotalPages, lblCurrentPage, Int_PageIndex, int_TotalRecords, lnkPre, lnkNext);

    }
    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("---------Select---------", "0"));
    }

    private void BindListBox(ListBox ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("---------Select---------", "0"));
        ddl.SelectedIndex = 0;
    }

    void BindKRAHead()
    {                
        KRASettingMasterEntity objEntity = new KRASettingMasterEntity();
        KRAMasterBAL objBAL = new KRAMasterBAL();
        objEntity.CompanyId = Convert.ToInt32(drp_comp_name.SelectedValue);
        objEntity.DesignationId = drpCDesignation.SelectedIndex > 0 ? Convert.ToInt32(drpCDesignation.SelectedValue) : Convert.ToInt32(drpdegination.SelectedValue);

        DataSet dsResult = objBAL.KTASettingMasterData(objEntity, Int_PageIndex);
        if (dsResult.Tables[0].Rows.Count > 0)
        {
            //Record Exists
            ViewState["KRASettingData"] = dsResult.Tables[1];
        }
        else
        {
            ViewState["KRASettingData"] = null;
        }

        CustomPaging(lblTotalPages, lblCurrentPage, Int_PageIndex, int_TotalRecords, lnkPre, lnkNext);

        var _objKRAHeadBAL = new AppraisalKRAHeadBAL();
        grdKRAHead.DataSource = _objKRAHeadBAL.GetAll();
        grdKRAHead.DataBind();

    }

    List<KRAMasterEntity> ListKRAMaster { get; set; }
    void BindValues(GridView grd, int idToDelete = 0, string command = "")
    {
        if (grd != null)
        {
            foreach (GridViewRow row in grd.Rows)
            {
                TextBox txtKRA = (TextBox)row.FindControl("txtKRA");
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
                    KRAComment = "",
                    WeightAge = Convert.ToDecimal(txtWeightage.Text),
                    ID = Convert.ToInt32(lnkDelete.CommandArgument),
                    CreatedBy = Convert.ToString(Session["EmpCode"]),
                    EmpCode = ""
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
        if (!Validate())
            return;

        DeleteKRASettings();
        try
        {
            #region Insert KRA Detail

            foreach (ListItem item in drpdegination.Items)
            {
                if (item.Selected == true && item.Value != "0")
                {
                    foreach (GridViewRow row in grdKRAHead.Rows)
                    {
                        var lblKRAHeadID = (Label)row.FindControl("lblKRAHeadID");
                        var grdPK = (GridView)row.FindControl("grdPrimaryKRA");

                        foreach (GridViewRow innerRow in grdPK.Rows)
                        {
                            var lblKRA = (TextBox)innerRow.FindControl("txtKRA");
                            var lblWeightage = (TextBox)innerRow.FindControl("txtWeightage");

                            var kraSetting = new KRASettingMasterEntity()
                            {
                                CompanyId = Convert.ToInt32(drp_comp_name.SelectedValue),
                                DesignationId = Convert.ToInt32(item.Value),
                                KRAHeadId = Convert.ToInt32(lblKRAHeadID.Text),
                                KRA = lblKRA.Text,
                                WeightAge = Convert.ToDecimal(lblWeightage.Text),
                                CreatedBy = Convert.ToString(Session["EmpCode"]),
                            };

                            _objBAL.KRASettingInsert(kraSetting);
                        }
                    }
                }
            }            
            General.Alert("Record submitted successfully.", btn);
            ViewLink();
            #endregion
        }

        catch (Exception ex)
        {
            General.Alert(ConfigHelper.MessageError, btn);
        }
    }

    private Boolean Validate()
    {
        var isValid = true;
        foreach (GridViewRow row in grdKRAHead.Rows)
        {
            var lblweightAge = (Label)row.FindControl("lblweightage");
            var lblKRAHead = (Label)row.FindControl("lblKRA");
            var grdPK = (GridView)row.FindControl("grdPrimaryKRA");

            decimal totalValue = 0;

            foreach (GridViewRow innerRow in grdPK.Rows)
            {
                var lblWeight = (TextBox)innerRow.FindControl("txtWeightage");
                totalValue += Convert.ToDecimal(lblWeight.Text);
            }

            if (totalValue < Convert.ToDecimal(100))
            {
                General.Alert("KRA sum must be equal to 100.", btnSubmit);
                isValid = false;
                break;
            }

            if (totalValue > Convert.ToDecimal(100))
            {
                General.Alert("KRA sum should not exceeds 100.", btnSubmit);
                isValid = false;
                break;
            }
        }
        return isValid;
    }

    private void DeleteKRASettings()
    {
        string CompanyId = drp_comp_name.SelectedValue;
        foreach (ListItem item in drpdegination.Items)
        {
            if (item.Selected == true)
            {
                string DesignationId = item.Value;
                String deleteKRASettings = "Delete from KRASettingMaster Where CompanyId=" + CompanyId + " and DesignationId=" + DesignationId;
                DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, deleteKRASettings);
            }
        }
       
    }

    protected void grdKRAHead_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView grdPK = (GridView)e.Row.FindControl("grdPrimaryKRA");

            Label lblweightage = (Label)e.Row.FindControl("lblweightage");
            lblweightage.Text = Math.Round(Convert.ToDecimal(lblweightage.Text), 0).ToString();

            if (ViewState["KRASettingData"] != null)
            {
                DataTable dtData = (DataTable)ViewState["KRASettingData"];

                Label lblID = (Label)e.Row.FindControl("lblKRAHeadID");
                var intId = Convert.ToInt32(lblID.Text);
                if (grdPK != null)
                {
                    var lst = dtData.Select("KRAHeadId=" + intId + " and DesignationId=" + (drpCDesignation.SelectedIndex > 0 ? drpCDesignation.SelectedValue : drpdegination.SelectedValue));
                    List<KRASettingMasterEntity> detail = new List<KRASettingMasterEntity>();
                    KRASettingMasterEntity objEnt;
                    foreach (var item in lst)
                    {
                        objEnt = new KRASettingMasterEntity();
                        objEnt.KRA = item[7].ToString();
                        objEnt.WeightAge = Convert.ToDecimal(item[8].ToString());
                        objEnt.ID = Convert.ToInt32(item[0].ToString());
                        detail.Add(objEnt);
                    }
                    if (detail != null)
                        grdPK.DataSource = detail;
                    else
                        grdPK.DataSource = null;

                    grdPK.DataBind();
                }
            }
            else
            {
                if (grdPK != null)
                {
                    ListKRAMaster = null;
                    AddDefaultRow();
                    BindKRA(grdPK);
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
    protected void grdPrimaryKRA_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
            if (e.Row.RowIndex == 0)
                lnkDelete.Visible = false;
        }
    }
    protected void drpdegination_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (divView.Visible == false)
        {
            grdResult.DataSource = null;
            grdResult.DataBind();

            BindKRAHead();
        }
        else
        {
            BindSettingData();
        }

    }
    protected void lnkView_Click(object sender, EventArgs e)
    {
        ViewLink();
        drpdegination.SelectionMode = ListSelectionMode.Single;
    }

    protected void ViewLink()
    {
        ViewState["KRASettingData"] = null;
        drp_comp_name.SelectedIndex = 0;

        drpdegination.Items.Clear();
        drpCDesignation.Items.Clear();

        BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
        BindListBox(drpdegination, binddrop.BindDropDowns(drp_comp_name.SelectedValue, "Designation"), "id", "designationname");
        BindDropDowns(drpCDesignation, binddrop.BindDropDowns(drp_comp_name.SelectedValue, "CopyFromDesignation"), "id", "designationname");

        Int_PageIndex = 1;
        int_TotalRecords = 0;

        grdView.DataSource = null;
        grdView.DataBind();

        divCreate.Visible = false;
        divView.Visible = true;
        trCreate.Visible = false;
        lnkCreate.Visible = true;
        lnkView.Visible = false;
        BindKRAHead();
    }

    protected void lnkCreate_Click(object sender, EventArgs e)
    {
        drp_comp_name.SelectedIndex = 0;
        drpdegination.Items.Clear();
        drpCDesignation.Items.Clear();

        BindDropDownEmployeeBusiness binddrop = new BindDropDownEmployeeBusiness();
        BindListBox(drpdegination, binddrop.BindDropDowns(drp_comp_name.SelectedValue, "Designation"), "id", "designationname");
        BindDropDowns(drpCDesignation, binddrop.BindDropDowns(drp_comp_name.SelectedValue, "CopyFromDesignation"), "id", "designationname");

        drpdegination.SelectionMode = ListSelectionMode.Multiple;

        divCreate.Visible = true;
        divView.Visible = false;
        trCreate.Visible = true;

        lnkCreate.Visible = false;
        lnkView.Visible = true;
    }
    protected void drpCDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (divView.Visible == false)
        {
            grdResult.DataSource = null;
            grdResult.DataBind();

            BindKRAHead();
        }
        else
        {
            BindSettingData();
        }
    }
    protected void grdView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView grdLevel1 = (GridView)e.Row.FindControl("grdLeve1");
            Label dName = (Label)e.Row.FindControl("lblDName");
            DataTable dt = (DataTable)ViewState["dsResultDetail"];
            ViewState["DId"] = dName.ToolTip.ToString();

            DataTable dtKRA = new DataTable();
            dtKRA.Columns.Add("KRAHeadId", typeof(string));
            dtKRA.Columns.Add("KRAHead", typeof(string));

            string kraHeadId = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!kraHeadId.Contains(dt.Rows[i]["KRAHeadId"].ToString()))
                {
                    DataRow dr = dtKRA.NewRow();
                    dr["KRAHeadId"] = dt.Rows[i]["KRAHeadId"].ToString();
                    dr["KRAHead"] = dt.Rows[i]["KRAHead"].ToString();
                    dtKRA.Rows.Add(dr);
                }
                kraHeadId += dt.Rows[i]["KRAHeadId"].ToString() + ",";
            }

            grdLevel1.DataSource = dtKRA;
            grdLevel1.DataBind();
        }
    }

    protected void grdLeve1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView grdLeve2 = (GridView)e.Row.FindControl("grdLeve2");
            Label kraHeadId = (Label)e.Row.FindControl("lblKHead");
            DataTable dt = (DataTable)ViewState["dsResultDetail"];

            DataRow[] drRows = dt.Select("KRAHeadId=" + kraHeadId.ToolTip.ToString() + " and DesignationId=" + ViewState["DId"].ToString());

            DataTable dtKRADetail = new DataTable();
            dtKRADetail.Columns.Add("KRA", typeof(string));
            dtKRADetail.Columns.Add("WeightAge", typeof(string));

            for (int i = 0; i < drRows.Count(); i++)
            {
                DataRow dr = dtKRADetail.NewRow();
                dr["KRA"] = drRows[i][3].ToString();
                dr["WeightAge"] = drRows[i][4].ToString();
                dtKRADetail.Rows.Add(dr);
            }

            grdLeve2.DataSource = dtKRADetail;
            grdLeve2.DataBind();
        }
    }
    public void CustomPaging(Label lblTotalPages, Label lblCurrentPage, int cp, double totalRows, LinkButton Btn_Previous, LinkButton Btn_Next)
    {
        lblTotalPages.Text = CalculateTotalPages(totalRows).ToString();
        lblCurrentPage.Text = cp.ToString();

        if (cp == 1)
        {
            Btn_Previous.Enabled = false;
            Btn_Next.Enabled = false;
            if (Int32.Parse(lblTotalPages.Text) > 0)
            {
                Btn_Previous.Enabled = false;
                Btn_Next.Enabled = true;
            }
            else
            {
                Btn_Previous.Enabled = true;
                Btn_Next.Enabled = true;
            }

            if ((Int32.Parse(lblTotalPages.Text) == 1) && (Int32.Parse(lblCurrentPage.Text) == 1))
            {
                Btn_Previous.Enabled = false;
                Btn_Next.Enabled = false;
            }
        }
        else
        {
            Btn_Previous.Enabled = true;

            if (cp == Int32.Parse(lblTotalPages.Text))
            {
                Btn_Next.Enabled = false;
            }

            else
            {
                Btn_Next.Enabled = true;
            }
        }
    }
    private int CalculateTotalPages(double totalRecords)
    {
        int totalPages = (int)Math.Ceiling(totalRecords / Int_Page_Size);
        return totalPages;
    }
    public void ButtonEvent(int pageNo)
    {
        Int_PageIndex = pageNo;
    }
    protected void ChangePage(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "First":
                Int_PageIndex = 1;
                break;

            case "Previous":
                Int_PageIndex = Int32.Parse(lblCurrentPage.Text) - 1;

                break;

            case "Next":
                Int_PageIndex = Int32.Parse(lblCurrentPage.Text) + 1;
                break;

            case "Last":
                Int_PageIndex = Int32.Parse(lblTotalPages.Text);
                break;
        }
        BindSettingData();
    }
}