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

public partial class payroll_viewdeclarationdetail : System.Web.UI.Page
{
    //string sqlstr;
    DataSet ds = new DataSet();
    DataTable dtable = new DataTable();
    DataView dview;
    DataSet ds1 = new DataSet();
    public static DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        _BindGridCheckList();
        bind_fyear();
        //bind_6A_detail();
        if (Request.QueryString["message"] != null)
        {
            message.InnerHtml = Request.QueryString["message"].ToString();
        }
        else
        {           
            message.InnerText = "";
        }
        //bind_nsc_detail();
    }
    private void bind_fyear()
    {
        if (System.DateTime.Now.Month >= 4)
            lbl_fyear.Text = System.DateTime.Now.Year + "-" + System.DateTime.Now.AddYears(1).Year;
        else
            lbl_fyear.Text = System.DateTime.Now.AddYears(-1).Year + "-" + System.DateTime.Now.Year;
        lbl_empcode.Text= Session["EmpCode"].ToString();
        lbl_empname.Text=Session["EmpName"].ToString();
        ViewState["empcode"] = Session["EmpCode"].ToString();
        string getrefno = @"SELECT ref_no,status from tbl_payroll_employee_declaration where empcode='" + Session["EmpCode"].ToString() + "' and financialyr='" + lbl_fyear.Text + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, getrefno);
        if (ds.Tables[0].Rows.Count != 0)
        {
            ViewState["Ref_No"] = ds.Tables[0].Rows[0]["ref_no"].ToString();
           // btnsubmit.Visible = false;
            if ( ds.Tables[0].Rows[0]["status"].ToString()== "True")
            {
                message.InnerText = "";
                string url = "../payroll/admin/viewdeclarationdetail.aspx?ref_no=" + ViewState["Ref_No"].ToString() + "&NameView=ViewSelf";
                Response.Redirect(url);
            }
            //else
            //{
            //    message.InnerText = "";
            //    string url = "../payroll/admin/editdeclarationdetail.aspx?ref_no=" + ViewState["Ref_No"].ToString() + "&NameEdit=EditSelf";
            //    Response.Redirect(url);
            //}
           
        }        
        else
        {
            BtnEdit.Visible = false;
            BtnView.Visible = false;
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

    protected void bind_personalinfo(string empcode)
    {

        EmployeeViewBusiness objSelectALL = new EmployeeViewBusiness();
        EmpJobDetailENT userentity = new EmpJobDetailENT();

        userentity.Empcode = empcode;
        ds = objSelectALL.SelectPersonalDetails(userentity);
        dt = ds.Tables[0];
        if (ds.Tables[0].Rows.Count < 1)

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
   
    //protected void dd_smaster_DataBound(object sender, EventArgs e)
    //{
    //    dd_smaster.Items.Insert(0, new ListItem("Select Section", "0"));
    //}

    protected void dd_sdetail_DataBound(object sender, EventArgs e)
    {
        dd_sdetail.Items.Insert(0, new ListItem("Select Section Detail", "0"));
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

    //=================================== Insert Declaration Details ===========================================//

    protected void insert_declaration_detail(Decimal ramnt, Decimal aamnt, Decimal namnt, int nchild, Decimal a80c, Decimal a80ccc, Decimal a80ccd, Decimal a80d, Decimal a80e, Decimal a80dd, Decimal a80g, Decimal a80cf, string otherCity)
    {
        SqlParameter[] sqlparam = new SqlParameter[22];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = Session["EmpCode"].ToString();

        sqlparam[1] = new SqlParameter("@financialyr", SqlDbType.VarChar, 50);
        sqlparam[1].Value = lbl_fyear.Text.Trim();

        sqlparam[2] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
        sqlparam[2].Value = Session["name"].ToString();

        sqlparam[3] = new SqlParameter("@createddate", SqlDbType.DateTime);
        sqlparam[3].Value = DateTime.Now;

        sqlparam[4] = new SqlParameter("@rent", SqlDbType.Decimal);
        sqlparam[4].Value = ramnt;

        sqlparam[5] = new SqlParameter("@chapter6A", SqlDbType.Decimal);
        sqlparam[5].Value = aamnt;

        sqlparam[6] = new SqlParameter("@nsc", SqlDbType.Decimal);
        sqlparam[6].Value = namnt;

        sqlparam[7] = new SqlParameter("@children", SqlDbType.Int);
        sqlparam[7].Value = nchild;

        sqlparam[8] = new SqlParameter("@metro", SqlDbType.Int);
        sqlparam[8].Value = dd_metro.SelectedValue;

        sqlparam[9] = new SqlParameter("@hself_occupied", SqlDbType.Bit);
        sqlparam[9].Value = Convert.ToInt32(rbHouse.SelectedValue) == 1 ? 1 : 0;

        //------------EOC Anuj--------------------------------

        sqlparam[10] = new SqlParameter("@hloan_borrowed", SqlDbType.Bit);
        if (opt_loan_yes.Checked == true)
            sqlparam[10].Value = 1;
        else
            sqlparam[10].Value = 0;

        sqlparam[11] = new SqlParameter("@80C", SqlDbType.Decimal);
        sqlparam[11].Value = a80c;

        sqlparam[12] = new SqlParameter("@80CCC", SqlDbType.Decimal);
        sqlparam[12].Value = a80ccc;

        sqlparam[13] = new SqlParameter("@80CCD", SqlDbType.Decimal);
        sqlparam[13].Value = a80ccd;

        sqlparam[14] = new SqlParameter("@80D", SqlDbType.Decimal);
        sqlparam[14].Value = a80d;

        sqlparam[15] = new SqlParameter("@80E", SqlDbType.Decimal);
        sqlparam[15].Value = a80e;

        sqlparam[16] = new SqlParameter("@80DD", SqlDbType.Decimal);
        sqlparam[16].Value = a80dd;

        sqlparam[17] = new SqlParameter("@80G", SqlDbType.Decimal);
        sqlparam[17].Value = a80g;

        sqlparam[18] = new SqlParameter("@interest_house", SqlDbType.Decimal);
        if (txt_houseint.Text == "")
            sqlparam[18].Value = 0;
        else
            sqlparam[18].Value = txt_houseint.Text.Trim();

        sqlparam[19] = new SqlParameter("@status", SqlDbType.TinyInt);
        sqlparam[19].Value = 0;

        sqlparam[20] = new SqlParameter("@80CF", SqlDbType.Decimal);
        sqlparam[20].Value = a80cf;

        sqlparam[21] = new SqlParameter("@otherCity", SqlDbType.VarChar);
        sqlparam[21].Value = otherCity;

        int a = (Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_create_employee_declaration", sqlparam)));

        if (a > 0)
        {
            insert_rent_detail(a);
            insert_children_detail(a);
            insert_6A_detail(a);
            //UploadRentAggrement(a);
            //insert_nsc_detail(a);

            //message.InnerHtml = " Declaration made successfully ";
            General.Alert("Declaration made successfully", btnsubmit);
        }
        else
        {
            // message.InnerHtml = " Declaration for financial year " + lbl_fyear.Text + " has been already done ";
            General.Alert("Declaration for financial year " + lbl_fyear.Text + " has been already done", btnsubmit);
            message.InnerText = "";
        }
    }

    //=================================== Insert Rent Paid Details ===========================================//

    protected void insert_rent_detail(int ref_no)
    {
        SqlParameter[] sqlparam = new SqlParameter[14];

        sqlparam[0] = new SqlParameter("@ref_no", SqlDbType.Int);
        sqlparam[0].Value = ref_no;

        sqlparam[1] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
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

        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_create_employee_rent_detail", sqlparam);

    }

    //=================================== Insert Children Studying Details ===========================================//

    protected void insert_children_detail(int ref_no)
    {
        SqlParameter[] sqlparam = new SqlParameter[14];

        sqlparam[0] = new SqlParameter("@ref_no", SqlDbType.Int);
        sqlparam[0].Value = ref_no;

        sqlparam[1] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
        sqlparam[1].Value = Session["name"].ToString();

        sqlparam[2] = new SqlParameter("@apr_no", SqlDbType.Int);
        sqlparam[2].Value = convert_nochild(txt_child.Text);

        sqlparam[3] = new SqlParameter("@may_no", SqlDbType.Int);
        sqlparam[3].Value = convert_nochild(txt_child.Text);

        sqlparam[4] = new SqlParameter("@jun_no", SqlDbType.Int);
        sqlparam[4].Value = convert_nochild(txt_child.Text);

        sqlparam[5] = new SqlParameter("@jul_no", SqlDbType.Int);
        sqlparam[5].Value = convert_nochild(txt_child.Text);

        sqlparam[6] = new SqlParameter("@aug_no", SqlDbType.Int);
        sqlparam[6].Value = convert_nochild(txt_child.Text);

        sqlparam[7] = new SqlParameter("@sep_no", SqlDbType.Int);
        sqlparam[7].Value = convert_nochild(txt_child.Text);

        sqlparam[8] = new SqlParameter("@oct_no", SqlDbType.Int);
        sqlparam[8].Value = convert_nochild(txt_child.Text);

        sqlparam[9] = new SqlParameter("@nov_no", SqlDbType.Int);
        sqlparam[9].Value = convert_nochild(txt_child.Text);

        sqlparam[10] = new SqlParameter("@dec_no", SqlDbType.Int);
        sqlparam[10].Value = convert_nochild(txt_child.Text);

        sqlparam[11] = new SqlParameter("@jan_no", SqlDbType.Int);
        sqlparam[11].Value = convert_nochild(txt_child.Text);

        sqlparam[12] = new SqlParameter("@feb_no", SqlDbType.Int);
        sqlparam[12].Value = convert_nochild(txt_child.Text);

        sqlparam[13] = new SqlParameter("@mar_no", SqlDbType.Int);
        sqlparam[13].Value = convert_nochild(txt_child.Text);

        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_create_employee_children_detail", sqlparam);

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
            dview.Sort = "section_name";
        }
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

    protected void insert_6A_detail(int ref_no)
    {
        if (Session["deduction"] != null)
        {
            dtable = (DataTable)Session["deduction"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                CheckBox chkstatus = (CheckBox)grid_6A.Rows[i].Cells[0].FindControl("chkstatus");
                if (chkstatus != null)
                {
                    SqlParameter[] sqlParam = new SqlParameter[6];

                    sqlParam[0] = new SqlParameter("@ref_no", SqlDbType.Int);
                    sqlParam[0].Value = ref_no;

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

    //=================================== Insert NSC Detail into Database ===========================================//  

    protected void insert_nsc_detail(int ref_no)
    {
        if (Session["certificate"] != null)
        {
            dtable = (DataTable)Session["certificate"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {

                SqlParameter[] sqlParam = new SqlParameter[5];

                sqlParam[0] = new SqlParameter("@ref_no", SqlDbType.Int);
                sqlParam[0].Value = ref_no;

                sqlParam[1] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
                sqlParam[1].Value = Session["name"].ToString();

                sqlParam[2] = new SqlParameter("@certi_no", SqlDbType.VarChar, 50);
                sqlParam[2].Value = dtable.Rows[i]["certi_no"].ToString();

                sqlParam[3] = new SqlParameter("@inv_date", SqlDbType.DateTime);
                sqlParam[3].Value = dtable.Rows[i]["inv_date"].ToString();

                sqlParam[4] = new SqlParameter("@nsc_amount", SqlDbType.Decimal);
                sqlParam[4].Value = dtable.Rows[i]["nsc_amount"].ToString();

                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_create_employee_nsc_detail", sqlParam);
            }
        }
    }

    //=================================== Delete item from NSC Detail Grid===========================================//  

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
        if (rdoyearly.Checked)
        {
            if (!ValidatePemonth())
            {
                Decimal ramnt = 0, aamnt = 0, namnt = 0;
                int nchild = 0;
                Decimal a80c = 0, a80ccc = 0, a80ccd = 0, a80d = 0, a80e = 0, a80dd = 0, a80g = 0, a80cf = 0;

                if (rdoyearly.Checked)
                {
                    txt_apr.Text = txt_mth.Text; txt_may.Text = txt_mth.Text; txt_june.Text = txt_mth.Text; txt_jul.Text = txt_mth.Text; txt_aug.Text = txt_mth.Text; txt_sep.Text = txt_mth.Text;
                    txt_oct.Text = txt_mth.Text; txt_nov.Text = txt_mth.Text; txt_dec.Text = txt_mth.Text; txt_jan.Text = txt_mth.Text; txt_feb.Text = txt_mth.Text; txt_mar.Text = txt_mth.Text;
                }
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

                                if (dtable.Rows[i]["section_name"].ToString() == "80G")
                                    a80cf = a80cf + Convert.ToDecimal(dtable.Rows[i]["a_amount"].ToString());
                            }
                        }
                    }
                }

                //if (Session["certificate"] != null)
                //{
                //    dtable = (DataTable)Session["certificate"];
                //    for (int i = 0; i < dtable.Rows.Count; i++)
                //    {
                //        namnt = namnt + Convert.ToDecimal(dtable.Rows[i]["nsc_amount"].ToString());
                //    }
                //}
                message.InnerText = "Declaration made successfullly.";
                string otherCity = txtOtherCity.Text;
                nchild = convert_nochild(txt_child.Text) * 12;
                insert_declaration_detail(ramnt, aamnt, namnt, nchild, a80c, a80ccc, a80ccd, a80d, a80e, a80dd, a80g, a80cf, otherCity);
                insertLandLorddetail();
                reset_detail();           
                BtnEdit.Visible = true;
                BtnView.Visible = true;
            }
            else
                General.Alert("Please enter land lord pan card no.", btnsubmit);
        }
        else
        {
            if (!validate())
            {
                Decimal ramnt = 0, aamnt = 0, namnt = 0;
                int nchild = 0;
                Decimal a80c = 0, a80ccc = 0, a80ccd = 0, a80d = 0, a80e = 0, a80dd = 0, a80g = 0, a80cf = 0;

                if (rdoyearly.Checked)
                {
                    txt_apr.Text = txt_mth.Text; txt_may.Text = txt_mth.Text; txt_june.Text = txt_mth.Text; txt_jul.Text = txt_mth.Text; txt_aug.Text = txt_mth.Text; txt_sep.Text = txt_mth.Text;
                    txt_oct.Text = txt_mth.Text; txt_nov.Text = txt_mth.Text; txt_dec.Text = txt_mth.Text; txt_jan.Text = txt_mth.Text; txt_feb.Text = txt_mth.Text; txt_mar.Text = txt_mth.Text;
                }
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

                                if (dtable.Rows[i]["section_name"].ToString() == "80G")
                                    a80cf = a80cf + Convert.ToDecimal(dtable.Rows[i]["a_amount"].ToString());
                            }
                        }
                    }
                }

                //if (Session["certificate"] != null)
                //{
                //    dtable = (DataTable)Session["certificate"];
                //    for (int i = 0; i < dtable.Rows.Count; i++)
                //    {
                //        namnt = namnt + Convert.ToDecimal(dtable.Rows[i]["nsc_amount"].ToString());
                //    }
                //}
                message.InnerText = "Declaration made successfullly.";
                nchild = convert_nochild(txt_child.Text) * 12;
                insert_declaration_detail(ramnt, aamnt, namnt, nchild, a80c, a80ccc, a80ccd, a80d, a80e, a80dd, a80g, a80cf, txtOtherCity.Text);
                insertLandLorddetail();
                BtnEdit.Visible = true;
                BtnView.Visible = true;
                reset_detail();
            }
            else
                General.Alert("Please enter land lord Pan card no.", btnsubmit);
        }
    }

    //=================================== Reset All Detail ===========================================//

    protected void btnreset_Click(object sender, EventArgs e)
    {
        reset_detail();
    }

    protected void reset_detail()
    {
        //txt_employee.Text = "";
        txt_houseint.Text = "";
        //opt_self_yes.Checked = true;
        //opt_self_no.Checked = false;
        opt_loan_yes.Checked = true;
        opt_loan_no.Checked = false;
        txt_houseint.Enabled = true;
        reset_rentdetail();
        reset_childrendetail();
        reset_6Adetail();
        message.InnerText = "";
        // reset_nscdetail();
    }

    protected void reset_rentdetail()
    {
        dd_metro.SelectedValue = "1";
        rdoyearly.Checked = true;
        txt_mth.Text = "";
        txt_apr.Text = "";
        txt_may.Text = "";
        txt_june.Text = "";
        txt_jul.Text = "";
        txt_aug.Text = "";
        txt_sep.Text = "";
        txt_oct.Text = "";
        txt_nov.Text = "";
        txt_dec.Text = "";
        txt_jan.Text = "";
        txt_feb.Text = "";
        txt_mar.Text = "";
    }

    protected void reset_childrendetail()
    {
        txt_child.Text = "";
    }

    protected void reset_6Adetail()
    {
        dd_smaster.SelectedIndex = -1;
        dd_sdetail.SelectedIndex = -1;
        txt_samnt.Text = "";
        Session.Remove("deduction");
        grid_6A.DataSource = "";
        grid_6A.DataBind();
    }

    //protected void reset_nscdetail()
    //{
    //    txt_certi.Text = "";
    //    txt_invdate.Text = "";
    //    txt_nscamnt.Text = "";
    //    Session.Remove("certificate");
    //    grid_nsc.DataSource = "";
    //    grid_nsc.DataBind();
    //}

    //=============================== Check for House Interest Applicable ================================//

    protected void insertLandLorddetail()
    {
        SqlParameter[] sqlprm1 = new SqlParameter[4];

        sqlprm1[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlprm1[0].Value = Session["EmpCode"].ToString();

        sqlprm1[1] = new SqlParameter("@LName", SqlDbType.VarChar, 50);
        sqlprm1[1].Value = TxtLandLord.Text;

        sqlprm1[2] = new SqlParameter("@panNo", SqlDbType.VarChar, 15);
        sqlprm1[2].Value = TxtPanNo.Text;

        sqlprm1[3] = new SqlParameter("@Address", SqlDbType.VarChar, 200);
        sqlprm1[3].Value = TxtAddress.Text;

        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_insert_LandLord_detail", sqlprm1);

    }

    private Boolean validate()
    {
        bool flag = false;
        string value1 = !string.IsNullOrEmpty(txt_apr.Text) ? txt_apr.Text : "0";
        string value2 = !string.IsNullOrEmpty(txt_may.Text) ? txt_may.Text : "0";
        string value3 = !string.IsNullOrEmpty(txt_june.Text) ? txt_june.Text : "0";
        string value4 = !string.IsNullOrEmpty(txt_jul.Text) ? txt_jul.Text : "0";
        string value5 = !string.IsNullOrEmpty(txt_aug.Text) ? txt_aug.Text : "0";
        string value6 = !string.IsNullOrEmpty(txt_sep.Text) ? txt_sep.Text : "0";
        string value7 = !string.IsNullOrEmpty(txt_oct.Text) ? txt_oct.Text : "0";
        string value8 = !string.IsNullOrEmpty(txt_nov.Text) ? txt_nov.Text : "0";
        string value9 = !string.IsNullOrEmpty(txt_dec.Text) ? txt_dec.Text : "0";
        string value10 = !string.IsNullOrEmpty(txt_jan.Text) ? txt_jan.Text : "0";
        string value11 = !string.IsNullOrEmpty(txt_feb.Text) ? txt_feb.Text : "0";
        string value12 = !string.IsNullOrEmpty(txt_mar.Text) ? txt_mar.Text : "0";

        if (Convert.ToInt32(value1.Trim()) >= 8333)
        {
            if (TxtPanNo.Text == string.Empty)
            {
                PanRangevalidator.Enabled = true;
                flag = true;
            }
            else
                flag = false;
            return flag;
        }
        else if (Convert.ToInt32(value2.Trim()) >= 8333)
        {
            if (TxtPanNo.Text == string.Empty)
            {
                PanRangevalidator.Enabled = true;
                flag = true;
            }
            else
                flag = false;
            return flag;

        }
        else if (Convert.ToInt32(value3.Trim()) >= 8333)
        {
            flag = TxtPanNo.Text == string.Empty ? true : false;
            return flag;
        }
        else if (Convert.ToInt32(value4.Trim()) >= 8333)
        {
            flag = TxtPanNo.Text == string.Empty ? true : false;
            return flag;
        }
        else if (Convert.ToInt32(value5.Trim()) >= 8333)
        {
            flag = TxtPanNo.Text == string.Empty ? true : false;
            return flag;
        }
        else if (Convert.ToInt32(value6.Trim()) >= 8333)
        {
            flag = TxtPanNo.Text == string.Empty ? true : false;
            return flag;
        }
        else if (Convert.ToInt32(value7.Trim()) >= 8333)
        {
            flag = TxtPanNo.Text == string.Empty ? true : false;
            return flag;
        }
        else if (Convert.ToInt32(value8.Trim()) >= 8333)
        {
            flag = TxtPanNo.Text == string.Empty ? true : false;
            return flag;
        }
        else if (Convert.ToInt32(value9.Trim()) >= 8333)
        {
            flag = TxtPanNo.Text == string.Empty ? true : false;
            return flag;
        }
        else if (Convert.ToInt32(value10.Trim()) >= 8333)
        {
            flag = TxtPanNo.Text == string.Empty ? true : false;
            return flag;
        }
        else if (Convert.ToInt32(value11.Trim()) >= 8333)
        {
            flag = TxtPanNo.Text == string.Empty ? true : false;
            return flag;
        }
        else if (Convert.ToInt32(value12.Trim()) >= 8333)
        {
            flag = TxtPanNo.Text == string.Empty ? true : false;
            return flag;
        }

        else
            return flag = false;


    }

    private Boolean ValidatePemonth()
    {
        bool flag1 = false;
        string value1 = !string.IsNullOrEmpty(txt_mth.Text) ? txt_mth.Text : "0";

        if (Convert.ToInt32(value1.Trim()) >= 8333)
        {
            flag1 = TxtPanNo.Text == string.Empty ? true : false;
            return flag1;
        }
        else
            return flag1 = false;

    }


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
    protected void rdoyearly_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoyearly.Checked)
        {
            yearly.Visible = true;
            monthly.Visible = false;
        }
        else
        {
            yearly.Visible = false;
            monthly.Visible = true;
        }

    }
    protected void rdomonthly_CheckedChanged(object sender, EventArgs e)
    {
        if (rdomonthly.Checked)
        {
            yearly.Visible = false;
            monthly.Visible = true;
        }
        else
        {
            yearly.Visible = true;
            monthly.Visible = false;
        }
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
        if (rbHouse.SelectedValue == "0")
            PanRangevalidator.Enabled = true;
        else
            PanRangevalidator.Enabled = false;
    }
    protected void txt_employee_TextChanged(object sender, EventArgs e)
    {
        bind_personalinfo(Session["EmpCode"].ToString());
        bind_child(Session["EmpCode"].ToString());
    }
    protected void BtnView_Click(object sender, EventArgs e)
    {
        message.InnerText = "";
        string url = "../payroll/admin/viewdeclarationdetail.aspx?ref_no=" + ViewState["Ref_No"].ToString() + "&NameView=ViewSelf";
        Response.Redirect(url);
      
    }
    protected void BtnEdit_Click(object sender, EventArgs e)
    {
        message.InnerText = "";
        string url = "../payroll/admin/editdeclarationdetail.aspx?ref_no=" + ViewState["Ref_No"].ToString()+"&NameEdit=EditSelf";
        Response.Redirect(url);
    }
}