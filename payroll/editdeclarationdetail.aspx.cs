using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using System.Data.SqlClient;
using System.Security.Cryptography;

using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using QueryStringEncryption;

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


public partial class payroll_editdeclarationdetail : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    DataTable dtable = new DataTable();
    DataView dview;
    DataSet ds1 = new DataSet();
    public static DataTable dt = new DataTable();
 

    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";      

        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");

            Session.Remove("deduction");
            _BindGridCheckList();
            bind_declaration_detail();
            bind_6A_detail();
            //bind_nsc_detail();
            bind_personalinfo(Session["EmpCode"].ToString());
            bind_child(Session["EmpCode"].ToString());
            //DisabledControls();
        }
       
    }
    public void _BindGridCheckList()
    {
        CheckListENT ObjCheckListENT = new CheckListENT();
        CheckListBusiness ObjCheckListBusiness = new CheckListBusiness();

        ObjCheckListENT.ID = 0;
        ObjCheckListENT.Description = "";
        ObjCheckListENT.Status = true;
        ObjCheckListENT.EmployeeCode = Session["EmpCode"].ToString();

        ds = ObjCheckListBusiness.Select_DecCheckList(ObjCheckListENT);

        if (ds.Tables[0].Rows.Count > 0)
        {
            GvCheckList.DataSource = ds;
            GvCheckList.DataBind();
        }
    }

    private void DisabledControls()
    {
        rbHouse.Enabled = false;
        opt_loan_yes.Enabled = false;
        opt_loan_no.Enabled = false;
        txt_houseint.Enabled = false;
        dd_metro.Enabled = false;
        txtOtherCity.Enabled = false;
        txt_apr.Enabled = false;
        txt_apr2.Enabled = false;
        txt_may.Enabled = false;
        txt_may2.Enabled = false;
        txt_june.Enabled = false;
        txt_june2.Enabled = false;
        txt_jul.Enabled = false;
        txt_jul2.Enabled = false;
        txt_aug.Enabled = false;
        txt_aug2.Enabled = false;
        txt_sep.Enabled = false;
        txt_sep2.Enabled = false;
        txt_sep2.Enabled = false;
        txt_oct.Enabled = false;
        txt_oct2.Enabled = false;
        txt_nov.Enabled = false;
        txt_nov2.Enabled = false;
        txt_dec.Enabled = false;
        txt_dec2.Enabled = false;
        txt_jan.Enabled = false;
        txt_jan2.Enabled = false;
        txt_feb.Enabled = false;
        txt_feb2.Enabled = false;
        txt_mar.Enabled = false;
        txt_mar2.Enabled = false;
        txt_m_fname.Enabled = false;
        dd_smaster.Enabled = false;
        txt_samnt.Enabled = false;
        dd_sdetail.Enabled = false;
        btn_6A_add.Enabled = false;
    }
    //=================================== Bind Old Detail ===========================================//

    protected void bind_declaration_detail()
    {
        SqlParameter[] sqlparam = new SqlParameter[1];

        sqlparam[0] = new SqlParameter("@ref_no", SqlDbType.Int);
        sqlparam[0].Value = Request.QueryString["ref_no"].ToString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_view_declaration_detail", sqlparam);

        ViewState["Declaration"] = ds.Tables[0];

        lbl_empcode.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
        lbl_empname.Text = ds.Tables[0].Rows[0]["empname"].ToString();
        lbl_fyear.Text = ds.Tables[0].Rows[0]["financialyr"].ToString();
        dd_metro.SelectedValue = ds.Tables[0].Rows[0]["metro"].ToString();

        if (Convert.ToInt32(ds.Tables[0].Rows[0]["metro"]) == 5)
        {
            trOtherCity.Visible = Convert.ToInt32(ds.Tables[0].Rows[0]["metro"]) == 5 ? true : false;
            txtOtherCity.Text = ds.Tables[0].Rows[0]["metroname"].ToString();
        }

        //-----Commented/Added by Anuj on 23-Apr-14

        //if (Convert.ToInt32(ds.Tables[0].Rows[0]["hself_occupied"].ToString()) == 1)
        //    opt_self_yes.Checked = true;
        //else
        //    opt_self_no.Checked = true;

        //sqlparam[9].Value = Convert.ToInt32(rbHouse.SelectedValue) == 1 ? 1 : 0;

        rbHouse.SelectedValue = ds.Tables[0].Rows[0]["hself_occupied"].ToString();
        Tab_rent.Visible = rbHouse.SelectedValue == "0" ? true : false;
        Tab_children.Visible = rbHouse.SelectedValue == "0" ? true : false;
        //------------EOC Anuj--------------------------------

        if (Convert.ToInt32(ds.Tables[0].Rows[0]["hloan_borrowed"].ToString()) == 1)
            opt_loan_yes.Checked = true;
        else
            opt_loan_no.Checked = true;

        txt_houseint.Text = ds.Tables[0].Rows[0]["interest_house"].ToString();

        loan_int_enable();

        //Bind rent detail

        txt_apr.Text = ds.Tables[0].Rows[0]["apr_amnt"].ToString();
        txt_may.Text = ds.Tables[0].Rows[0]["may_amnt"].ToString();
        txt_june.Text = ds.Tables[0].Rows[0]["jun_amnt"].ToString();
        txt_jul.Text = ds.Tables[0].Rows[0]["jul_amnt"].ToString();
        txt_aug.Text = ds.Tables[0].Rows[0]["aug_amnt"].ToString();
        txt_sep.Text = ds.Tables[0].Rows[0]["sep_amnt"].ToString();
        txt_oct.Text = ds.Tables[0].Rows[0]["oct_amnt"].ToString();
        txt_nov.Text = ds.Tables[0].Rows[0]["nov_amnt"].ToString();
        txt_dec.Text = ds.Tables[0].Rows[0]["dec_amnt"].ToString();
        txt_jan.Text = ds.Tables[0].Rows[0]["jan_amnt"].ToString();
        txt_feb.Text = ds.Tables[0].Rows[0]["feb_amnt"].ToString();
        txt_mar.Text = ds.Tables[0].Rows[0]["mar_amnt"].ToString();

        //Bind children(studying) detail

        txt_apr2.Text = ds.Tables[0].Rows[0]["apr_no"].ToString();
        txt_may2.Text = ds.Tables[0].Rows[0]["may_no"].ToString();
        txt_june2.Text = ds.Tables[0].Rows[0]["jun_no"].ToString();
        txt_jul2.Text = ds.Tables[0].Rows[0]["jul_no"].ToString();
        txt_aug2.Text = ds.Tables[0].Rows[0]["aug_no"].ToString();
        txt_sep2.Text = ds.Tables[0].Rows[0]["sep_no"].ToString();
        txt_oct2.Text = ds.Tables[0].Rows[0]["oct_no"].ToString();
        txt_nov2.Text = ds.Tables[0].Rows[0]["nov_no"].ToString();
        txt_dec2.Text = ds.Tables[0].Rows[0]["dec_no"].ToString();
        txt_jan2.Text = ds.Tables[0].Rows[0]["jan_no"].ToString();
        txt_feb2.Text = ds.Tables[0].Rows[0]["feb_no"].ToString();
        txt_mar2.Text = ds.Tables[0].Rows[0]["mar_no"].ToString();

    }

    //===========================================Bind 6a detail===============================================

    protected void bind_6A_detail()
    {
        sqlstr = "Select section_name,section_detail,a_amount,status from tbl_payroll_employee_6A_detail where ref_no=" + Request.QueryString["ref_no"].ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        if (ds.Tables[0].Rows.Count < 1)
            return;

        if (Session["deduction"] == null)
        {
            create_deduction_table();
        }

        DataRow dr;
        DataTable dtable;
        dtable = (DataTable)Session["deduction"];
        ViewState["6ADetail"] = ds.Tables[0];
        for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
        {
            dr = dtable.NewRow();
            dr["section_name"] = ds.Tables[0].Rows[i]["section_name"].ToString();
            dr["section_detail"] = ds.Tables[0].Rows[i]["section_detail"].ToString();
            dr["a_amount"] = ds.Tables[0].Rows[i]["a_amount"].ToString();
            dr["status"] = ds.Tables[0].Rows[i]["status"].ToString();
            dtable.Rows.Add(dr);
        }
        Session["deduction"] = dtable;
        bindlist_deduction();
    }

    //=====================================Bind NSC detail==========================================

    //protected void bind_nsc_detail()
    //{
    //    sqlstr = "Select certi_no,convert(varchar(10),inv_date,101) inv_date,nsc_amount from tbl_payroll_employee_nsc_detail where ref_no=" + Request.QueryString["ref_no"].ToString();
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

    //    if (ds.Tables[0].Rows.Count < 1)
    //        return;

    //    if (Session["certificate"] == null)
    //    {
    //        create_certy_table();
    //    }

    //    DataRow dr;
    //    DataTable dtable;
    //    dtable = (DataTable)Session["certificate"];

    //    for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
    //    {
    //        dr = dtable.NewRow();
    //        dr["certi_no"] = ds.Tables[0].Rows[i]["certi_no"].ToString();
    //        dr["inv_date"] = ds.Tables[0].Rows[i]["inv_date"].ToString();
    //        dr["nsc_amount"] = ds.Tables[0].Rows[i]["nsc_amount"].ToString();
    //        dtable.Rows.Add(dr);
    //    }
    //    Session["certificate"] = dtable;
    //    bindlist_certy();
    //}

    //////=================================== Bind Financial year ===========================================//

    ////protected void bind_fyear()
    ////{
    ////    if (System.DateTime.Now.Month >= 4)
    ////        lbl_fyear.Text = System.DateTime.Now.Year + "-" + System.DateTime.Now.AddYears(1).Year;
    ////    else
    ////        lbl_fyear.Text = System.DateTime.Now.AddYears(-1).Year + "-" + System.DateTime.Now.Year;
    ////}

    //protected void dd_smaster_DataBound(object sender, EventArgs e)
    //{
    //    dd_smaster.Items.Insert(0, new ListItem("Select Section", "0"));
    //}

    protected void dd_sdetail_DataBound(object sender, EventArgs e)
    {
        dd_sdetail.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Section Detail", "0"));
    }

    //=================================== Function for conversion of Amount from String to decimal ===========================================//

    protected Decimal convert_decimalamnt(string str)
    {
        Decimal damnt;
        if (str == "")
            damnt = 0;
        else
            damnt = Convert.ToDecimal(str);
        return damnt;
    }

    //=================================== Function for conversion of Number from String to int ===========================================//

    protected int convert_nochild(string str2)
    {
        int n;
        if (str2 == "")
            n = 0;
        else
            n = Convert.ToInt16(str2);
        return n;
    }

    protected void bind_personalinfo(string empcode)
    {

        EmployeeViewBusiness objSelectALL = new EmployeeViewBusiness();
        EmpJobDetailENT userentity = new EmpJobDetailENT();

        userentity.Empcode = empcode;
        ds = objSelectALL.SelectPersonalDetails(userentity);
        dt = ds.Tables[0];
       // if (ds.Tables[0].Rows.Count < 1)

            txt_f_f_name.Text = dt.Rows[0]["f_fname"].ToString() + ' ' + dt.Rows[0]["f_mname"].ToString() + ' ' + dt.Rows[0]["f_lname"].ToString();

        txt_m_fname.Text = dt.Rows[0]["m_fname"].ToString() + ' ' + dt.Rows[0]["m_lname"].ToString() + ' ' + dt.Rows[0]["m_mname"].ToString();


        ddlpersonalstatus.Text = (dt.Rows[0]["maritalstatus"].ToString() == "0") ? "----" : dt.Rows[0]["maritalstatus"].ToString();


        txt_doa.Text = dt.Rows[0]["doa"].ToString();

        txt_sp_fname.Text = dt.Rows[0]["s_fname"].ToString() + ' ' + dt.Rows[0]["s_mname"].ToString() + ' ' + dt.Rows[0]["s_lname"].ToString();



    }

    //------------Bind Child Details of Employee-----------------
    protected void bind_child(string empcode)
    {
        EmployeeViewBusiness objSelectALL = new EmployeeViewBusiness();
        EmpJobDetailENT userentity = new EmpJobDetailENT();

        userentity.Empcode = empcode;
        ds = objSelectALL.SelectChildrenDetails(userentity);


        if (ds.Tables[0].Rows.Count < 1)
            return;
        grid_child.DataSource = ds;
        grid_child.DataBind();
    }

    //=================================== Insert Rent Paid Details ===========================================//

    protected void insert_rent_detail()
    {
        SqlParameter[] sqlparam = new SqlParameter[14];

        sqlparam[0] = new SqlParameter("@ref_no", SqlDbType.Int);
        sqlparam[0].Value = Request.QueryString["ref_no"].ToString();

        sqlparam[1] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
        sqlparam[1].Value = Session["name"].ToString();

        sqlparam[2] = new SqlParameter("@apr_amnt", SqlDbType.Decimal);
        sqlparam[2].Value = convert_decimalamnt(txt_apr.Text);

        sqlparam[3] = new SqlParameter("@may_amnt", SqlDbType.Decimal);
        sqlparam[3].Value = convert_decimalamnt(txt_may.Text);

        sqlparam[4] = new SqlParameter("@jun_amnt", SqlDbType.Decimal);
        sqlparam[4].Value = convert_decimalamnt(txt_june.Text);

        sqlparam[5] = new SqlParameter("@jul_amnt", SqlDbType.Decimal);
        sqlparam[5].Value = convert_decimalamnt(txt_jul.Text);

        sqlparam[6] = new SqlParameter("@aug_amnt", SqlDbType.Decimal);
        sqlparam[6].Value = convert_decimalamnt(txt_aug.Text);

        sqlparam[7] = new SqlParameter("@sep_amnt", SqlDbType.Decimal);
        sqlparam[7].Value = convert_decimalamnt(txt_sep.Text);

        sqlparam[8] = new SqlParameter("@oct_amnt", SqlDbType.Decimal);
        sqlparam[8].Value = convert_decimalamnt(txt_oct.Text);

        sqlparam[9] = new SqlParameter("@nov_amnt", SqlDbType.Decimal);
        sqlparam[9].Value = convert_decimalamnt(txt_nov.Text);

        sqlparam[10] = new SqlParameter("@dec_amnt", SqlDbType.Decimal);
        sqlparam[10].Value = convert_decimalamnt(txt_dec.Text);

        sqlparam[11] = new SqlParameter("@jan_amnt", SqlDbType.Decimal);
        sqlparam[11].Value = convert_decimalamnt(txt_jan.Text);

        sqlparam[12] = new SqlParameter("@feb_amnt", SqlDbType.Decimal);
        sqlparam[12].Value = convert_decimalamnt(txt_feb.Text);

        sqlparam[13] = new SqlParameter("@mar_amnt", SqlDbType.Decimal);
        sqlparam[13].Value = convert_decimalamnt(txt_mar.Text);

        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_edit_employee_rent_detail", sqlparam);

    }


    //=================================== Insert Children Studying Details ===========================================//

    protected void insert_children_detail()
    {
        SqlParameter[] sqlparam = new SqlParameter[14];

        sqlparam[0] = new SqlParameter("@ref_no", SqlDbType.Int);
        sqlparam[0].Value = Request.QueryString["ref_no"].ToString();

        sqlparam[1] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
        sqlparam[1].Value = Session["name"].ToString();

        sqlparam[2] = new SqlParameter("@apr_no", SqlDbType.Int);
        sqlparam[2].Value = convert_nochild(txt_apr2.Text);

        sqlparam[3] = new SqlParameter("@may_no", SqlDbType.Int);
        sqlparam[3].Value = convert_nochild(txt_may2.Text);

        sqlparam[4] = new SqlParameter("@jun_no", SqlDbType.Int);
        sqlparam[4].Value = convert_nochild(txt_june2.Text);

        sqlparam[5] = new SqlParameter("@jul_no", SqlDbType.Int);
        sqlparam[5].Value = convert_nochild(txt_jul2.Text);

        sqlparam[6] = new SqlParameter("@aug_no", SqlDbType.Int);
        sqlparam[6].Value = convert_nochild(txt_aug2.Text);

        sqlparam[7] = new SqlParameter("@sep_no", SqlDbType.Int);
        sqlparam[7].Value = convert_nochild(txt_sep2.Text);

        sqlparam[8] = new SqlParameter("@oct_no", SqlDbType.Int);
        sqlparam[8].Value = convert_nochild(txt_oct2.Text);

        sqlparam[9] = new SqlParameter("@nov_no", SqlDbType.Int);
        sqlparam[9].Value = convert_nochild(txt_nov2.Text);

        sqlparam[10] = new SqlParameter("@dec_no", SqlDbType.Int);
        sqlparam[10].Value = convert_nochild(txt_dec2.Text);

        sqlparam[11] = new SqlParameter("@jan_no", SqlDbType.Int);
        sqlparam[11].Value = convert_nochild(txt_jan2.Text);

        sqlparam[12] = new SqlParameter("@feb_no", SqlDbType.Int);
        sqlparam[12].Value = convert_nochild(txt_feb2.Text);

        sqlparam[13] = new SqlParameter("@mar_no", SqlDbType.Int);
        sqlparam[13].Value = convert_nochild(txt_mar2.Text);

        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_edit_employee_children_detail", sqlparam);

    }

    //=================================== Insert 6A Detail into 6A Grid ===========================================//  

    protected void deduction_grid()
    {
        DataRow dr;
        if (Session["deduction"] == null)
        {
            create_deduction_table();
        }

        dtable = (DataTable)Session["deduction"];

        DataRow drfind = dtable.Rows.Find(dd_sdetail.SelectedValue);

        if (drfind != null)
        {
            message.InnerHtml = "Same detail can not be added again";
        }
        else
        {
            dr = dtable.NewRow();
            dr["section_name"] = dd_smaster.SelectedValue;
            dr["section_detail"] = dd_sdetail.SelectedValue;
            dr["a_amount"] = txt_samnt.Text.Trim();
            dr["status"] = true;
            dtable.Rows.Add(dr);
        }
        Session["deduction"] = dtable;
        bindlist_deduction();
    }

    protected void bindlist_deduction()
    {
        if (Session["deduction"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["deduction"];
            dview = new DataView(dtable);
            dview.Sort = "section_detail";
        }
        //dtable = (DataTable)Session["deduction"];
        grid_6A.DataSource = dview;
        grid_6A.DataBind();
    }

    protected void create_deduction_table()
    {
        dtable = new DataTable();
        dtable.Columns.Add("section_name", typeof(string));
        dtable.Columns.Add("section_detail", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["section_detail"] };
        dtable.Columns.Add("a_amount", typeof(string));
        dtable.Columns.Add("status", typeof(string));
        Session["deduction"] = dtable;
    }

    protected void btn_6A_add_Click(object sender, EventArgs e)
    {
        deduction_grid();
        dd_smaster.SelectedIndex = -1;
        dd_sdetail.SelectedIndex = -1;
        txt_samnt.Text = "";
    }

    //=================================== Delete item from 6A Detail Grid ===========================================//  

    protected void grid_6A_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["deduction"];
        DataRow drfind_deduction = dtable.Rows.Find(Convert.ToString(grid_6A.DataKeys[e.RowIndex].Value));

        if (drfind_deduction != null)
        {
            drfind_deduction.Delete();
            Session["deduction"] = dtable;
            bindlist_deduction();
        }
    }

    //=================================== Insert 6A Detail into Database ===========================================//  

    protected void insert_6A_detail()
    {
        sqlstr = "delete from tbl_payroll_employee_6A_detail where ref_no=" + Request.QueryString["ref_no"].ToString();
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        if (Session["deduction"] != null)
        {
            dtable = (DataTable)Session["deduction"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                CheckBox chkstatus = (CheckBox)grid_6A.Rows[i].Cells[0].FindControl("chkstatus");
                if (chkstatus != null)
                {
                //    if (chkstatus.Checked)
                //    {
                        SqlParameter[] sqlParam = new SqlParameter[6];

                        sqlParam[0] = new SqlParameter("@ref_no", SqlDbType.Int);
                        sqlParam[0].Value = Request.QueryString["ref_no"].ToString();

                        sqlParam[1] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
                        sqlParam[1].Value = Session["name"].ToString();

                        sqlParam[2] = new SqlParameter("@section_name", SqlDbType.VarChar, 50);
                        sqlParam[2].Value = dtable.Rows[i]["section_name"].ToString();

                        sqlParam[3] = new SqlParameter("@section_detail", SqlDbType.VarChar, 200);
                        sqlParam[3].Value = dtable.Rows[i]["section_detail"].ToString();

                        sqlParam[4] = new SqlParameter("@a_amount", SqlDbType.Decimal);
                        sqlParam[4].Value = dtable.Rows[i]["a_amount"].ToString();

                        sqlParam[5] = new SqlParameter("@status", SqlDbType.Bit);
                        sqlParam[5].Value = chkstatus.Checked;

                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_create_employee_6A_detail", sqlParam);
                //    }
                    }
            }
        }
    }


    //=================================== Insert NSC Detail into NSC Grid ===========================================//  

    //protected void certy_grid()
    //{
    //    DataRow dr;
    //    if (Session["certificate"] == null)
    //    {
    //        create_certy_table();
    //    }

    //    dtable = (DataTable)Session["certificate"];

    //    DataRow drfind = dtable.Rows.Find(txt_certi.Text);

    //    if (drfind != null)
    //    {
    //        message.InnerHtml = "Same detail can not be added again";
    //    }
    //    else
    //    {
    //        dr = dtable.NewRow();
    //        dr["certi_no"] = txt_certi.Text;
    //        dr["inv_date"] = txt_invdate.Text;
    //        dr["nsc_amount"] = txt_nscamnt.Text.Trim();

    //        dtable.Rows.Add(dr);
    //    }
    //    Session["certificate"] = dtable;
    //    bindlist_certy();
    //}

    //protected void bindlist_certy()
    //{
    //    if (Session["certificate"] == null)
    //    {
    //        dview = new DataView(null);
    //    }
    //    else
    //    {
    //        dtable = (DataTable)Session["certificate"];
    //        dview = new DataView(dtable);
    //        dview.Sort = "certi_no";
    //    }
    //    //dtable = (DataTable)Session["certificate"];
    //    grid_nsc.DataSource = dview;
    //    grid_nsc.DataBind();
    //}

    //protected void create_certy_table()
    //{
    //    dtable = new DataTable();
    //    dtable.Columns.Add("certi_no", typeof(string));
    //    dtable.PrimaryKey = new DataColumn[] { dtable.Columns["certi_no"] };
    //    dtable.Columns.Add("inv_date", typeof(string));
    //    dtable.Columns.Add("nsc_amount", typeof(string));
    //    Session["certificate"] = dtable;
    //}

    //protected void btn_nsc_add_Click(object sender, EventArgs e)
    //{
    //    certy_grid();
    //    txt_certi.Text = "";
    //    txt_invdate.Text = "";
    //    txt_nscamnt.Text = "";
    //}

    ////=================================== Insert NSC Detail into Database ===========================================//  

    //protected void insert_nsc_detail()
    //{
    //    sqlstr = "delete from tbl_payroll_employee_nsc_detail where ref_no=" + Request.QueryString["ref_no"].ToString();
    //    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

    //    if (Session["certificate"] != null)
    //    {
    //        dtable = (DataTable)Session["certificate"];
    //        for (int i = 0; i < dtable.Rows.Count; i++)
    //        {

    //            SqlParameter[] sqlParam = new SqlParameter[5];

    //            sqlParam[0] = new SqlParameter("@ref_no", SqlDbType.Int);
    //            sqlParam[0].Value = Request.QueryString["ref_no"].ToString();

    //            sqlParam[1] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
    //            sqlParam[1].Value = Session["name"].ToString();

    //            sqlParam[2] = new SqlParameter("@certi_no", SqlDbType.VarChar, 50);
    //            sqlParam[2].Value = dtable.Rows[i]["certi_no"].ToString();

    //            sqlParam[3] = new SqlParameter("@inv_date", SqlDbType.DateTime);
    //            sqlParam[3].Value = dtable.Rows[i]["inv_date"].ToString();

    //            sqlParam[4] = new SqlParameter("@nsc_amount", SqlDbType.Decimal);
    //            sqlParam[4].Value = dtable.Rows[i]["nsc_amount"].ToString();

    //            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_create_employee_nsc_detail", sqlParam);
    //        }
    //    }
    //}

    ////=================================== Delete item from NSC Detail Grid===========================================//  

    //protected void grid_nsc_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    dtable = (DataTable)Session["certificate"];
    //    DataRow drfind_certy = dtable.Rows.Find(Convert.ToString(grid_nsc.DataKeys[e.RowIndex].Value));

    //    if (drfind_certy != null)
    //    {
    //        drfind_certy.Delete();
    //        Session["certificate"] = dtable;
    //        bindlist_certy();
    //    }
    //}

    //=================================== Submit All Detail ===========================================//

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        Decimal ramnt = 0, aamnt = 0, namnt = 0;
        int nchild = 0;
        Decimal a80c = 0, a80ccc = 0, a80ccd = 0, a80d = 0, a80e = 0, a80dd = 0, a80g = 0,a80cf=0;

        ramnt = convert_decimalamnt(txt_apr.Text) + convert_decimalamnt(txt_may.Text) + convert_decimalamnt(txt_june.Text) + convert_decimalamnt(txt_jul.Text) + convert_decimalamnt(txt_aug.Text) + convert_decimalamnt(txt_sep.Text) +
            convert_decimalamnt(txt_oct.Text) + convert_decimalamnt(txt_nov.Text) + convert_decimalamnt(txt_dec.Text) + convert_decimalamnt(txt_jan.Text) + convert_decimalamnt(txt_feb.Text) + convert_decimalamnt(txt_mar.Text);

        if (Session["deduction"] != null)
        {
            dtable = (DataTable)Session["deduction"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                CheckBox chkstatus = (CheckBox)grid_6A.Rows[i].Cells[0].FindControl("chkstatus");
                if (chkstatus != null)
                {
                    if (chkstatus.Checked)
                    {
                        aamnt = aamnt + Convert.ToDecimal(dtable.Rows[i]["a_amount"].ToString());

                        if (dtable.Rows[i]["section_name"].ToString() == "80C")
                            a80c = a80c + Convert.ToDecimal(dtable.Rows[i]["a_amount"].ToString());

                        if (dtable.Rows[i]["section_name"].ToString() == "80CCC")
                            a80ccc = a80ccc + Convert.ToDecimal(dtable.Rows[i]["a_amount"].ToString());

                        if (dtable.Rows[i]["section_name"].ToString() == "80CCD")
                            a80ccd = a80ccd + Convert.ToDecimal(dtable.Rows[i]["a_amount"].ToString());

                        if (dtable.Rows[i]["section_name"].ToString() == "80D")
                            a80d = a80d + Convert.ToDecimal(dtable.Rows[i]["a_amount"].ToString());

                        if (dtable.Rows[i]["section_name"].ToString() == "80E")
                            a80e = a80e + Convert.ToDecimal(dtable.Rows[i]["a_amount"].ToString());

                        if (dtable.Rows[i]["section_name"].ToString() == "80DD")
                            a80dd = a80dd + Convert.ToDecimal(dtable.Rows[i]["a_amount"].ToString());

                        if (dtable.Rows[i]["section_name"].ToString() == "80G")
                            a80g = a80g + Convert.ToDecimal(dtable.Rows[i]["a_amount"].ToString());

                        if (dtable.Rows[i]["section_name"].ToString() == "80CF")
                            a80cf = a80cf + Convert.ToDecimal(dtable.Rows[i]["a_amount"].ToString());
                    }
                }
            }
        }

        if (Session["certificate"] != null)
        {
            dtable = (DataTable)Session["certificate"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                namnt = namnt + Convert.ToDecimal(dtable.Rows[i]["nsc_amount"].ToString());
            }
        }

        nchild = convert_nochild(txt_apr2.Text) + convert_nochild(txt_may2.Text) + convert_nochild(txt_june2.Text) + convert_nochild(txt_jul2.Text) + convert_nochild(txt_aug2.Text) + convert_nochild(txt_sep2.Text) + convert_nochild(txt_oct2.Text) + convert_nochild(txt_nov2.Text) + convert_nochild(txt_dec2.Text) + convert_nochild(txt_jan2.Text) + convert_nochild(txt_feb2.Text) + convert_nochild(txt_mar2.Text);

        insert_declaration_detail(ramnt, aamnt, namnt, nchild, a80c, a80ccc, a80ccd, a80d, a80e, a80dd, a80g, a80cf,txtOtherCity.Text);

        insert_rent_detail();
        insert_children_detail();
        insert_6A_detail();
       // insert_nsc_detail();

        //message.InnerHtml = "Declaration has been updated";
        General.Alert("Declaration has been updated",btnsubmit);
    }

    //=================================== Insert Declaration Details ===========================================//

    protected void insert_declaration_detail(Decimal ramnt, Decimal aamnt, Decimal namnt, int nchild, Decimal a80c, Decimal a80ccc, Decimal a80ccd, Decimal a80d, Decimal a80e, Decimal a80dd, Decimal a80g,Decimal a80CF,string otherCity)
    {
        SqlParameter[] sqlparam = new SqlParameter[20];

        sqlparam[0] = new SqlParameter("@ref_no", SqlDbType.Int);
        sqlparam[0].Value = Request.QueryString["ref_no"].ToString();

        sqlparam[1] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
        sqlparam[1].Value = Session["name"].ToString();

        sqlparam[2] = new SqlParameter("@modifieddate", SqlDbType.DateTime);
        sqlparam[2].Value = DateTime.Now;

        sqlparam[3] = new SqlParameter("@rent", SqlDbType.Decimal);
        sqlparam[3].Value = ramnt;

        sqlparam[4] = new SqlParameter("@chapter6A", SqlDbType.Decimal);
        sqlparam[4].Value = aamnt;

        sqlparam[5] = new SqlParameter("@nsc", SqlDbType.Decimal);
        sqlparam[5].Value = namnt;

        sqlparam[6] = new SqlParameter("@children", SqlDbType.Int);
        sqlparam[6].Value = nchild;

        sqlparam[7] = new SqlParameter("@metro", SqlDbType.Int);
        sqlparam[7].Value = dd_metro.SelectedValue;

        sqlparam[8] = new SqlParameter("@hself_occupied", SqlDbType.Bit);
        //-----Commented/Added by Anuj on 23-Apr-14
        //if (opt_self_yes.Checked == true)
        //    sqlparam[8].Value = 1;
        //else
        //    sqlparam[8].Value = 0;

        sqlparam[8].Value = Convert.ToInt32(rbHouse.SelectedValue) == 1 ? 1 : 0;

        //------------EOC Anuj--------------------------------

        sqlparam[9] = new SqlParameter("@hloan_borrowed", SqlDbType.Bit);
        if (opt_loan_yes.Checked == true)
            sqlparam[9].Value = 1;
        else
            sqlparam[9].Value = 0;

        sqlparam[10] = new SqlParameter("@80C", SqlDbType.Decimal);
        sqlparam[10].Value = a80c;

        sqlparam[11] = new SqlParameter("@80CCC", SqlDbType.Decimal);
        sqlparam[11].Value = a80ccc;

        sqlparam[12] = new SqlParameter("@80CCD", SqlDbType.Decimal);
        sqlparam[12].Value = a80ccd;

        sqlparam[13] = new SqlParameter("@80D", SqlDbType.Decimal);
        sqlparam[13].Value = a80d;

        sqlparam[14] = new SqlParameter("@80E", SqlDbType.Decimal);
        sqlparam[14].Value = a80e;

        sqlparam[15] = new SqlParameter("@80DD", SqlDbType.Decimal);
        sqlparam[15].Value = a80dd;

        sqlparam[16] = new SqlParameter("@80G", SqlDbType.Decimal);
        sqlparam[16].Value = a80g;

        sqlparam[17] = new SqlParameter("@interest_house", SqlDbType.Decimal);
        if (txt_houseint.Text == "")
            sqlparam[17].Value = 0;
        else
            sqlparam[17].Value = txt_houseint.Text.Trim();

        sqlparam[18] = new SqlParameter("@80CF", SqlDbType.Decimal);
        sqlparam[18].Value = a80CF;

        sqlparam[19] = new SqlParameter("@otherCity", SqlDbType.VarChar);
        sqlparam[19].Value = otherCity;
        
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_edit_employee_declaration", sqlparam);
    }

    //=================================== Reset All Detail ===========================================//

    protected void btnreset_Click(object sender, EventArgs e)
    {
        bind_declaration_detail();
        Session.Remove("deduction");
        Session.Remove("certificate");
        bind_6A_detail();
       // bind_nsc_detail();
    }

    //=================================== Check for House Interest Applicable ===================================//

    protected void loan_int_enable()
    {
        if (opt_loan_no.Checked == true)
        {
            txt_houseint.Enabled = false;
            txt_houseint.Text = "";
        }
        else
            txt_houseint.Enabled = true;
    }
    protected void opt_loan_yes_CheckedChanged(object sender, EventArgs e)
    {
        loan_int_enable();
    }
    protected void opt_loan_no_CheckedChanged(object sender, EventArgs e)
    {
        loan_int_enable();
    }

    protected void dd_metro_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dd_metro.SelectedIndex > 0)
        {
            trOtherCity.Visible = dd_metro.SelectedValue == "5" ? true : false;
        }
    }

    protected void rbHouse_SelectedIndexChanged(object sender, EventArgs e)
    {
        Tab_rent.Visible = rbHouse.SelectedValue == "0" ? true : false;
    }


    protected void ProcessFile(string PathName)
    {
        string[] array1 = Directory.GetFiles(PathName, "*.pdf");

        foreach (string _Filename in array1)
        {
            FileInfo TheFile = new FileInfo(_Filename);
            if (TheFile.Exists)
            {
                if (TheFile.CreationTime.Day < DateTime.Now.Day)
                {
                    try
                    {
                        System.IO.File.Delete(_Filename);
                    }
                    catch (Exception Ex)
                    {
                    }
                }
            }
        }
    }

    protected void _GeneratePdf()
    {
        string path = Server.MapPath("~/payroll/pdf_details");

        ProcessFile(path);

        Rectangle rec = new Rectangle(PageSize.A4);
        Document doc = new Document(rec);

        Random _r = new Random();
        int _iRandom = _r.Next();

        PdfWriter.GetInstance(doc, new FileStream(path + "/" + _iRandom.ToString() + ".pdf", FileMode.Create));

        doc.Open();
        doc.AddTitle("Tax Declaration Details");
        doc.AddSubject("Tax Declaration Details");
        doc.AddKeywords("");
        doc.AddCreator("hrms@earthinfra.com");
        doc.AddAuthor("Administrator");
        doc.AddHeader("Tax Declaration", "Tax Declaration");

        #region //// Employee Info
        DataTable _DtDeclaraion = (DataTable)ViewState["Declaration"];
        PdfPTable _tblEmpInfo = new PdfPTable(2);
        _tblEmpInfo.AddCell("Employee Code");
        _tblEmpInfo.AddCell(_DtDeclaraion.Rows[0]["empcode"].ToString());
        _tblEmpInfo.AddCell("Employee Name");
        _tblEmpInfo.AddCell(_DtDeclaraion.Rows[0]["empname"].ToString());
        _tblEmpInfo.AddCell("Financial Year");
        _tblEmpInfo.AddCell(_DtDeclaraion.Rows[0]["financialyr"].ToString());
        #endregion

        #region //// Property Info
        PdfPTable _tblPropInfo = new PdfPTable(2);
        _tblPropInfo.AddCell("Own House");
        _tblPropInfo.AddCell(_DtDeclaraion.Rows[0]["hself_occupied"].ToString() == "1" ? "yes" : "No");
        _tblPropInfo.AddCell("Housing Loan");
        _tblPropInfo.AddCell(_DtDeclaraion.Rows[0]["hloan_borrowed"].ToString() == "1" ? "Yes" : "No");
        _tblPropInfo.AddCell("Interest(Rs.)");
        _tblPropInfo.AddCell(_DtDeclaraion.Rows[0]["interest_house"].ToString());
        #endregion

        #region //// Rent Info
        PdfPTable _tblRentInfo = new PdfPTable(6);

        _tblRentInfo.AddCell("City");
        _tblRentInfo.AddCell(_DtDeclaraion.Rows[0]["metroname"].ToString());
        _tblRentInfo.AddCell("");
        _tblRentInfo.AddCell("");
        _tblRentInfo.AddCell("");
        _tblRentInfo.AddCell("");
        _tblRentInfo.AddCell("April");
        _tblRentInfo.AddCell(_DtDeclaraion.Rows[0]["apr_amnt"].ToString());
        _tblRentInfo.AddCell("May");
        _tblRentInfo.AddCell(_DtDeclaraion.Rows[0]["may_amnt"].ToString());
        _tblRentInfo.AddCell("June");
        _tblRentInfo.AddCell(_DtDeclaraion.Rows[0]["jun_amnt"].ToString());
        _tblRentInfo.AddCell("July");
        _tblRentInfo.AddCell(_DtDeclaraion.Rows[0]["jul_amnt"].ToString());
        _tblRentInfo.AddCell("August");
        _tblRentInfo.AddCell(_DtDeclaraion.Rows[0]["aug_amnt"].ToString());
        _tblRentInfo.AddCell("September");
        _tblRentInfo.AddCell(_DtDeclaraion.Rows[0]["sep_amnt"].ToString());
        _tblRentInfo.AddCell("October");
        _tblRentInfo.AddCell(_DtDeclaraion.Rows[0]["oct_amnt"].ToString());
        _tblRentInfo.AddCell("November");
        _tblRentInfo.AddCell(_DtDeclaraion.Rows[0]["nov_amnt"].ToString());
        _tblRentInfo.AddCell("December");
        _tblRentInfo.AddCell(_DtDeclaraion.Rows[0]["dec_amnt"].ToString());
        _tblRentInfo.AddCell("January");
        _tblRentInfo.AddCell(_DtDeclaraion.Rows[0]["jan_amnt"].ToString());
        _tblRentInfo.AddCell("February");
        _tblRentInfo.AddCell(_DtDeclaraion.Rows[0]["feb_amnt"].ToString());
        _tblRentInfo.AddCell("March");
        _tblRentInfo.AddCell(_DtDeclaraion.Rows[0]["mar_amnt"].ToString());

        decimal _totRent = 0;

        _totRent += Convert.ToDecimal(_DtDeclaraion.Rows[0]["apr_amnt"]);
        _totRent += Convert.ToDecimal(_DtDeclaraion.Rows[0]["may_amnt"]);
        _totRent += Convert.ToDecimal(_DtDeclaraion.Rows[0]["jun_amnt"]);
        _totRent += Convert.ToDecimal(_DtDeclaraion.Rows[0]["jul_amnt"]);
        _totRent += Convert.ToDecimal(_DtDeclaraion.Rows[0]["aug_amnt"]);
        _totRent += Convert.ToDecimal(_DtDeclaraion.Rows[0]["sep_amnt"]);
        _totRent += Convert.ToDecimal(_DtDeclaraion.Rows[0]["oct_amnt"]);
        _totRent += Convert.ToDecimal(_DtDeclaraion.Rows[0]["nov_amnt"]);
        _totRent += Convert.ToDecimal(_DtDeclaraion.Rows[0]["dec_amnt"]);
        _totRent += Convert.ToDecimal(_DtDeclaraion.Rows[0]["jan_amnt"]);
        _totRent += Convert.ToDecimal(_DtDeclaraion.Rows[0]["feb_amnt"]);
        _totRent += Convert.ToDecimal(_DtDeclaraion.Rows[0]["mar_amnt"]);

        _tblRentInfo.AddCell("");
        _tblRentInfo.AddCell("");
        _tblRentInfo.AddCell("");
        _tblRentInfo.AddCell("");
        _tblRentInfo.AddCell("Total");
        _tblRentInfo.AddCell(_totRent.ToString());

        #endregion

        #region //// Children Studying Info
        PdfPTable _tblChildInfo = new PdfPTable(6);
        _tblChildInfo.AddCell("April");
        _tblChildInfo.AddCell(_DtDeclaraion.Rows[0]["apr_no"].ToString());
        _tblChildInfo.AddCell("May");
        _tblChildInfo.AddCell(_DtDeclaraion.Rows[0]["may_no"].ToString());
        _tblChildInfo.AddCell("June");
        _tblChildInfo.AddCell(_DtDeclaraion.Rows[0]["jun_no"].ToString());
        _tblChildInfo.AddCell("July");
        _tblChildInfo.AddCell(_DtDeclaraion.Rows[0]["jul_no"].ToString());
        _tblChildInfo.AddCell("August");
        _tblChildInfo.AddCell(_DtDeclaraion.Rows[0]["aug_no"].ToString());
        _tblChildInfo.AddCell("September");
        _tblChildInfo.AddCell(_DtDeclaraion.Rows[0]["sep_no"].ToString());
        _tblChildInfo.AddCell("October");
        _tblChildInfo.AddCell(_DtDeclaraion.Rows[0]["oct_no"].ToString());
        _tblChildInfo.AddCell("November");
        _tblChildInfo.AddCell(_DtDeclaraion.Rows[0]["nov_no"].ToString());
        _tblChildInfo.AddCell("December");
        _tblChildInfo.AddCell(_DtDeclaraion.Rows[0]["dec_no"].ToString());
        _tblChildInfo.AddCell("January");
        _tblChildInfo.AddCell(_DtDeclaraion.Rows[0]["jan_no"].ToString());
        _tblChildInfo.AddCell("February");
        _tblChildInfo.AddCell(_DtDeclaraion.Rows[0]["feb_no"].ToString());
        _tblChildInfo.AddCell("March");
        _tblChildInfo.AddCell(_DtDeclaraion.Rows[0]["mar_no"].ToString());
        #endregion

        #region //// VI A Deduaction Info
        DataTable _Dt6ADetail = (DataTable)ViewState["6ADetail"];

        PdfPTable _tbl_Dt6AInfo = new PdfPTable(3);
        _tbl_Dt6AInfo.AddCell("Section Name");
        _tbl_Dt6AInfo.AddCell("Section Detail");
        _tbl_Dt6AInfo.AddCell("Amount");

        decimal _toDetail = 0;

        if (_Dt6ADetail != null)
        {
            foreach (DataRow _dr in _Dt6ADetail.Rows)
            {
                _tbl_Dt6AInfo.AddCell(_dr["section_name"].ToString());
                _tbl_Dt6AInfo.AddCell(_dr["section_detail"].ToString());
                _tbl_Dt6AInfo.AddCell(_dr["a_amount"].ToString());

                _toDetail += Convert.ToDecimal(_dr["a_amount"]);
            }
        }

        _tbl_Dt6AInfo.AddCell("");
        _tbl_Dt6AInfo.AddCell("Total");
        _tbl_Dt6AInfo.AddCell(_toDetail.ToString());

        #endregion

        // Final Pdf 
        Paragraph paragraph = new Paragraph("TAX Declaration Details");
        paragraph.Alignment = 1;
        doc.Add(new Paragraph(paragraph));
        doc.Add(new Paragraph("Company Name : Earth Infrastrutures Limited"));
        doc.Add(new Paragraph("DECLARATION BY EMPLOYEE FOR SUBMISSION OF PROOF(S) TO CLAIMING EXEMPTION(S) UNDER INCOME TAX ACT 1961, FOR THE FINANCIAL YEAR " + _DtDeclaraion.Rows[0]["financialyr"].ToString() + ""));
        doc.Add(new Paragraph(" "));

        Paragraph paragraph2 = new Paragraph("Employee Information");
        doc.Add(new Paragraph(paragraph2));
        doc.Add(new Paragraph(" "));

        doc.Add(_tblEmpInfo);
        Paragraph paragraph3 = new Paragraph("House Property Information");
        doc.Add(new Paragraph(paragraph3));
        doc.Add(new Paragraph(" "));

        doc.Add(_tblPropInfo);

        Paragraph paragraph4 = new Paragraph("Rent Paid Information");
        doc.Add(new Paragraph(paragraph4));
        doc.Add(new Paragraph(" "));
        doc.Add(_tblRentInfo);

        Paragraph paragraph5 = new Paragraph("Children Studying Information");
        doc.Add(new Paragraph(paragraph5));
        doc.Add(new Paragraph(" "));
        doc.Add(_tblChildInfo);

        Paragraph paragraph6 = new Paragraph(" VI A Deduction Information");
        doc.Add(new Paragraph(paragraph6));
        doc.Add(new Paragraph(" "));
        doc.Add(_tbl_Dt6AInfo);

        doc.Close();

        string filename = _iRandom.ToString() + ".pdf";
        path = MapPath(@"~\\payroll\\pdf_details\\" + filename);
        byte[] bts = System.IO.File.ReadAllBytes(path);
        Response.Clear();
        Response.ClearHeaders();
        Response.AddHeader("Content-Type", "Application/octet-stream");
        Response.AddHeader("Content-Length", bts.Length.ToString());
        Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
        Response.BinaryWrite(bts);
        Response.Flush();
        Response.End();
    }

    protected void btnPdf_Click(object sender, EventArgs e)
    {
        _GeneratePdf();
    }
}
