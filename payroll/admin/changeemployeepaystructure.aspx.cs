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
using System.Data.SqlTypes;
using System.Text;
using HRMS.BusinessLogic;
using DAL;

public partial class payroll_admin_editemployeepaystructure : System.Web.UI.Page
{
    int paystrucutreid;
    string sqlstr, sqlstrPayheadName, sqlstr1, sqlstr2, arrear_msg = "";
    DataSet ds = new DataSet();
    DataSet dsPayheadName = new DataSet();
    DataTable dtable = new DataTable();
    DataView dview;
    string message2;
    //Create stringbuilder to store multiple DML statements 
    StringBuilder strSql = new StringBuilder(string.Empty);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else Response.Redirect("~/notlogged.aspx");

            Session.Remove("EmployeePayStructure");
            Session.Remove("pay");
            bind_month();
            bind_year();
            bind_year1();
            string empcode = Request.QueryString["empcode"].ToString();
            int paystructureid = Convert.ToInt32(Request.QueryString["paystructureid"]);
            getemppaystructuredetails(empcode, paystructureid);
            Txtchooseemployee.Attributes.Add("readonly", "readonly");
            //bind_PayheadName();
            lblpayHeadMsg.Visible = false;
            lblCheckEmpRecords.Text = "";
            rngcheckpercentage.Enabled = false;
            drpPayCalType.Items[2].Enabled = false;
            drpPayCalType.Items[3].Enabled = false;
            valuebase.Visible = false;
            checkarrear();
            ViewState["chekpfesi"] = false;
            btnarrear.Visible = false;
        }
        lblCheckEmpRecords.Text = "";
    }
    protected void bind_year1()
    {
        sqlstr = "select distinct year from tbl_payroll_employee_salary";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        ddl_reimbursement_year.DataTextField = "year";
        ddl_reimbursement_year.DataValueField = "year";
        ddl_reimbursement_year.DataSource = ds;
        ddl_reimbursement_year.DataBind();
    }
    protected void drpPayCalType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(drpPayHead.SelectedValue) >= 1)
        {
            drpPayCalType.Items[2].Enabled = true;
            drpPayCalType.Items[0].Enabled = true;
            drpPayCalType.Items[1].Enabled = false;
            drpPayCalType.Items[3].Enabled = true;
            if (drpPayCalType.SelectedValue == "0")
            {
                valuebase.Visible = false;
                txtValueBase.Text = "";
                txtamount.Enabled = true;
            }
            else if (drpPayCalType.SelectedValue == "2")
            {
                valuebase.Visible = true;
                divbasic.Visible = true;
                txtamount.Enabled = false;
            }
            if (drpPayCalType.SelectedValue == "3")
            {
                valuebase.Visible = false;
                txtValueBase.Text = "";
                txtamount.Enabled = true;
            }
        }
    }


    protected void bind_PayheadName()
    {
        sqlstrPayheadName = @"SELECT [id], [payhead_name] FROM [tbl_payroll_payhead] where id not in (2,3,7,12) and type<>3 and status=1";

        dsPayheadName = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrPayheadName);

        drpPayHead.DataTextField = "payhead_name";
        drpPayHead.DataValueField = "id";

        drpPayHead.DataSource = dsPayheadName;
        drpPayHead.DataBind();
    }


    protected void drpPayHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        dtable = (DataTable)Session["EmployeePayStructure"];

        if (Session["EmployeePayStructure"] == null)
        {
            lblCheckEmpRecords.Text = "";
            lblCheckEmpRecords.Visible = true;
            lblCheckEmpRecords.Text = "Please Insert Basic Details first";
            drpPayHead.SelectedValue = "0";
            valuebase.Visible = false;
            rngcheckpercentage.Enabled = false;
            btn_submit.Visible = false;
            lblpercent.Visible = false;
            drpPayCalType.Items[0].Enabled = true;
            drpPayCalType.Items[1].Enabled = true;
            drpPayCalType.Items[2].Enabled = false;
            drpPayCalType.Items[3].Enabled = false;
            txtamount.Enabled = true;
            txtamount.Text = "";
            txtValueBase.Text = "";
            divbasic.Visible = true;
        }
        else
        {
            if (drpPayHead.SelectedValue == "0")
            {
                drpPayCalType.Items[0].Enabled = true;
                drpPayCalType.Items[1].Enabled = true;
                drpPayCalType.Items[2].Enabled = false;
                drpPayCalType.Items[3].Enabled = false;
                rngcheckpercentage.Enabled = false;
                lblpercent.Visible = false;
                valuebase.Visible = false;
                txtamount.Enabled = true;
                txtamount.Text = "";
                divbasic.Visible = true;
                employeePayStructure.Visible = true;
            }
            else if (drpPayHead.SelectedValue == "1")
            {
                drpPayCalType.Items[0].Enabled = false;
                drpPayCalType.Items[1].Enabled = false;
                drpPayCalType.Items[2].Enabled = true;
                drpPayCalType.Items[3].Enabled = true;
                rngcheckpercentage.Enabled = true;
                lblpercent.Visible = true;
                valuebase.Visible = true;
                txtamount.Enabled = false;
                lblCheckEmpRecords.Text = "";
                divbasic.Visible = true;

                if (drpPayCalType.SelectedValue == "2")
                {
                    valuebase.Visible = true;
                    divbasic.Visible = true;
                    txtamount.Enabled = false;
                }
                if (drpPayCalType.SelectedValue == "3")
                {
                    valuebase.Visible = false;
                    txtValueBase.Text = "";
                    txtamount.Enabled = true;
                }

            }
            else if (Convert.ToInt16(drpPayHead.SelectedValue) >= 2)
            {
                drpPayCalType.SelectedIndex = 0;
                drpPayCalType.Items[0].Enabled = true;
                drpPayCalType.Items[1].Enabled = false;
                drpPayCalType.Items[2].Enabled = true;
                drpPayCalType.Items[3].Enabled = true;
                rngcheckpercentage.Enabled = true;
                lblpercent.Visible = true;
                valuebase.Visible = true;
                txtamount.Enabled = false;
                lblCheckEmpRecords.Text = "";
                txtamount.Text = "";
                txtValueBase.Text = "";
                divbasic.Visible = true;
                drpPayCalType.Items[2].Enabled = true;
                drpPayCalType.Items[0].Enabled = true;
                drpPayCalType.Items[1].Enabled = false;
                drpPayCalType.Items[3].Enabled = true;

                if (drpPayCalType.SelectedValue == "0")
                {
                    valuebase.Visible = false;
                    txtValueBase.Text = "";
                    txtamount.Enabled = true;
                }
                else if (drpPayCalType.SelectedValue == "2")
                {
                    valuebase.Visible = true;
                    divbasic.Visible = true;
                    txtamount.Enabled = false;
                }
                if (drpPayCalType.SelectedValue == "3")
                {
                    valuebase.Visible = false;
                    txtValueBase.Text = "";
                    txtamount.Enabled = true;
                }
            }
        }
    }

    protected void txtValueBase_TextChanged(object sender, EventArgs e)
    {

        //if (drpPayHead.SelectedValue == "2" || drpPayHead.SelectedValue == "3" || drpPayHead.SelectedValue == "4" || Convert.ToInt32(drpPayHead.SelectedValue) >= 5)
        //{
        dtable = (DataTable)Session["EmployeePayStructure"];
        decimal amount = Convert.ToDecimal(dtable.Rows[0][6]);
        decimal value_base = Convert.ToDecimal(txtValueBase.Text);

        if (drpRoundValue.SelectedItem.Text == "Higher Rupees")
        {
            if (Convert.ToDecimal((value_base * amount) / 100) / Convert.ToInt32((value_base * amount) / 100) == 1)
                txtamount.Text = Convert.ToString(Convert.ToInt32((value_base * amount) / 100));
            else
                txtamount.Text = Convert.ToString(Convert.ToInt32((value_base * amount) / 100) + 1);
        }
        else if (drpRoundValue.SelectedItem.Text == "Nearest Rupees")
        {
            txtamount.Text = Convert.ToString(System.Math.Round(Convert.ToDecimal((value_base * amount) / 100), 0));
        }
        else if (drpRoundValue.SelectedItem.Text == "Normal")
        {
            txtamount.Text = Convert.ToString(Convert.ToDecimal((value_base * amount) / 100));
        }
        //}
    }

    protected void CreateDataTable()
    {
        dtable = new DataTable();

        dtable.Columns.Add("Empcode", typeof(string));

        dtable.Columns.Add("PayheadID", typeof(int));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["PayheadID"] };

        dtable.Columns.Add("PayheadName", typeof(string));

        dtable.Columns.Add("PayCalculationType", typeof(string));

        dtable.Columns.Add("PayCalculationValue", typeof(int));

        dtable.Columns.Add("ValueBase", typeof(string));

        dtable.Columns.Add("Amount", typeof(string));

        dtable.Columns.Add("Type", typeof(string));

        dtable.Columns.Add("RoundMethod", typeof(string));

        Session["EmployeePayStructure"] = dtable;
    }


    protected void emppaystructure()
    {
        DataRow dr;

        if (Session["EmployeePayStructure"] == null)
        {
            btn_submit.Visible = false;
            CreateDataTable();
        }
        dtable = (DataTable)Session["EmployeePayStructure"];

        DataRow drfind = dtable.Rows.Find(drpPayHead.SelectedValue.ToString());
        if (drfind != null)
        {
            lblCheckEmpRecords.Visible = true;
            lblCheckEmpRecords.Text = "Payhead already exists in employee pay structure queue";
        }
        else
        {
            dr = dtable.NewRow();
            dr["Empcode"] = txt_employee.Text.Trim();
            dr["PayheadID"] = drpPayHead.SelectedValue.ToString();
            dr["PayheadName"] = drpPayHead.SelectedItem.ToString();
            dr["PayCalculationType"] = drpPayCalType.SelectedItem.ToString();
            dr["PayCalculationValue"] = drpPayCalType.SelectedValue;

            if (txtValueBase.Text.Trim() == "")
            {
                dr["ValueBase"] = "N/A";

            }
            else
            {
                dr["ValueBase"] = txtValueBase.Text.Trim();
            }

            dr["Type"] = Employeedetail.Getpayheadtype(Convert.ToInt32(drpPayHead.SelectedValue.ToString()));

            if (txtamount.Text.Trim() == "")
            {
                dr["Amount"] = "N/A";
            }
            else
            {
                dr["Amount"] = txtamount.Text.ToString();
            }

            dr["RoundMethod"] = drpRoundValue.SelectedItem.ToString();

            dtable.Rows.Add(dr);
        }


        Session["EmployeePayStructure"] = dtable;

        dtable = (DataTable)Session["EmployeePayStructure"];
        employeePayStructure.DataSource = dtable;
        employeePayStructure.DataBind();

        if (drpPayHead.SelectedValue == "0")
        {
            txtamount.Text = "";
            employeePayStructure.Visible = true;
            btn_submit.Visible = true;
        }
        else if (drpPayHead.SelectedValue == "1")
        {
            txtamount.Text = "";
            txtValueBase.Text = "";
            employeePayStructure.Visible = true;
            btn_submit.Visible = true;
        }
        else if (drpPayHead.SelectedValue == "2")
        {
            txtamount.Text = "";
            txtValueBase.Text = "";
            employeePayStructure.Visible = true;
            btn_submit.Visible = true;
        }
        else if (drpPayHead.SelectedValue == "3")
        {
            txtamount.Text = "";
            txtValueBase.Text = "";
            employeePayStructure.Visible = true;
            btn_submit.Visible = true;
        }
        else if (drpPayHead.SelectedValue == "4")
        {
            txtamount.Text = "";
            txtValueBase.Text = "";
            employeePayStructure.Visible = true;
            btn_submit.Visible = true;
        }
        else if (drpPayHead.SelectedValue == "5" || drpPayHead.SelectedValue == "6")
        {
            txtamount.Text = "";
            txtValueBase.Text = "";
            employeePayStructure.Visible = true;
            btn_submit.Visible = true;
        }
        else if (Convert.ToInt16(drpPayHead.SelectedValue) >= 7)
        {
            txtamount.Text = "";
            txtValueBase.Text = "";
            employeePayStructure.Visible = true;
            btn_submit.Visible = true;
        }



        if (dtable.Rows.Count > 0)
        {
            txt_employee.Enabled = false;
            pickemp.Visible = false;
        }

    }

    protected void employeePayStructure_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["EmployeePayStructure"];

        DataRow drfind = dtable.Rows.Find(Convert.ToString(employeePayStructure.DataKeys[e.RowIndex].Value));

        if (dtable.Rows.Count > 1)
        {
            if (employeePayStructure.DataKeys[e.RowIndex].Value.ToString() == "0")
            {
                lblCheckEmpRecords.Visible = true;
                lblCheckEmpRecords.Text = "Can't delete! First delete all dependent records";
            }
            else
            {
                if (drfind != null)
                {
                    drfind.Delete();
                    Session["EmployeePayStructure"] = dtable;
                    dtable = (DataTable)Session["EmployeePayStructure"];
                    employeePayStructure.DataSource = dtable;
                    employeePayStructure.DataBind();
                    lblCheckEmpRecords.Text = "";
                }
            }

            txt_employee.Enabled = false;
            pickemp.Visible = false;
        }
        else if (dtable.Rows.Count == 1)
        {
            if (drfind != null)
            {
                drfind.Delete();
                Session["EmployeePayStructure"] = dtable;
                dtable = (DataTable)Session["EmployeePayStructure"];
                employeePayStructure.DataSource = dtable;
                employeePayStructure.DataBind();
                lblCheckEmpRecords.Text = "";
            }

            txt_employee.Enabled = false;
            pickemp.Visible = false;
        }

        if (dtable.Rows.Count < 1)
        {
            drpPayCalType.Items[0].Enabled = true;
            drpPayCalType.Items[1].Enabled = true;
            drpPayCalType.Items[2].Enabled = false;
            drpPayCalType.Items[3].Enabled = false;
            rngcheckpercentage.Enabled = false;
            lblpercent.Visible = false;
            valuebase.Visible = false;
            txtamount.Enabled = true;
            txtamount.Text = "";
            divbasic.Visible = true;
            employeePayStructure.Visible = false;
            drpPayHead.SelectedValue = "0";
            txt_employee.Enabled = true;
            pickemp.Visible = true;
            btn_submit.Visible = false;
        }
    }

    public Boolean validate()
    {
        int i;
        sqlstr1 = @"select count(payhead) from tbl_payroll_employee_paystructure_detail where empcode='" + txt_employee.Text.Trim() + "' and status = 1 and payhead=0";
        i = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr1);
        if (i > 0)
            return false;
        else
            return true;
    }

    protected void checkarrear()
    {
        //===================================Check for arrear======================================//
        DateTime oldtd = Utilities.Utility.dataformat(dd_month_f.SelectedItem.Value.ToString() + "/01/" + dd_year_f.SelectedItem.Text.ToString());

        //DateTime oldtd = Convert.ToDateTime(dd_month_f.SelectedValue + "/24/" + dd_year_f.SelectedValue);
        sqlstr2 = "Select convert(varchar,max(todate),101) as date from tbl_payroll_employee_salary where empcode='" + Request.QueryString["empcode"].ToString() + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr2);

        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0][0].ToString()))
        {
            DateTime std = Utilities.Utility.dataformat(ds.Tables[0].Rows[0]["date"].ToString());

            string strtemp = "select DateDiff(Month,'" + oldtd + "','" + std + "') monthdiff";
            DataSet dstemp = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, strtemp);
            ViewState["monthdiff"] = (Convert.ToInt32(dstemp.Tables[0].Rows[0]["monthdiff"].ToString()) + 1).ToString();

            //string strdaydiff = "SELECT DATEDIFF(DAY,'" + std + "','" + oldtd + "') daydiff";
            //DataSet dsdaydifftemp = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, strdaydiff);

            // ViewState["daydiff"] = dsdaydifftemp.Tables[0].Rows[0]["daydiff"].ToString();
            if (Convert.ToInt32(ViewState["monthdiff"]) > 0)// && Convert.ToInt32(ViewState["daydiff"]) > 0)
            {
                paydiv.Visible = true;
                //message2 = "Arrear occurs in salary,Add arrear from Salary Arrear Section.";
                //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message2.ToString() + "')</script>", false);
                //return;
            }
            else
            {
                paydiv.Visible = false;
            }

        }
        else
        {
            return;
        }
        //=========================================================================================
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        //try
        //{
        int flag = 0;
        dtable = (DataTable)Session["EmployeePayStructure"];
        if (dtable == null)
        {
            message2 = "Please insert new details for this employee.";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message2.ToString() + "')</script>", false);
            return;
        }

        //===================================Check for arrear======================================//
        DateTime oldtd = Utilities.Utility.dataformat(dd_month_f.SelectedItem.Value.ToString() + "/01/" + dd_year_f.SelectedItem.Text.ToString());

        //DateTime oldtd = Convert.ToDateTime(dd_month_f.SelectedValue + "/24/" + dd_year_f.SelectedValue);
        sqlstr2 = "Select convert(varchar,max(todate),101) as date from tbl_payroll_employee_salary where empcode='" + Request.QueryString["empcode"].ToString() + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr2);
        if (ds.Tables[0].Rows.Count != 0 && ds.Tables[0].Rows[0]["date"].ToString()!="")
        {
            DateTime std = Utilities.Utility.dataformat(ds.Tables[0].Rows[0]["date"].ToString());
            if (std >= oldtd)
            {
                arrear_msg = "Arrear occurs in salary,Add arrear from Salary Arrear Section.";
                //=========================================================================================
                DateTime otdate = (Utilities.Utility.dataformat(dd_month_f.SelectedItem.Value.ToString() + "/01/" + dd_year_f.SelectedItem.Text.ToString())).AddMonths(-1);
                // DateTime otdate = (Convert.ToDateTime(dd_month_f.SelectedValue + "/24/" + dd_year_f.SelectedValue)).AddMonths(-1);

                paystrucutreid = 0;
                sqlstr1 = @"update tbl_payroll_employee_paystructure set to_month='" + std.Month.ToString() + "',to_year='" + std.Year.ToString() + "',status=0 where id=" + Request.QueryString["paystructureid"].ToString() + ";update tbl_payroll_employee_paystructure_detail set status=0 where paystructure_id=" + Request.QueryString["paystructureid"].ToString();

                //dd_omth.SelectedValue + "',to_year='" + dd_oyr.SelectedValue + "',status=0 where id=" + Request.QueryString["paystructureid"].ToString() + ";update tbl_payroll_employee_paystructure_detail set status=0 where paystructure_id=" + Request.QueryString["paystructureid"].ToString();

                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);

                if (dtable.Rows.Count > 0)
                {
                    SqlParameter[] sqlparm;
                    sqlparm = new SqlParameter[9];

                    sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                    sqlparm[0].Value = txt_employee.Text;

                    sqlparm[1] = new SqlParameter("@from_month", SqlDbType.VarChar, 50);
                    sqlparm[1].Value = dd_month_f.SelectedItem.Text;

                    sqlparm[2] = new SqlParameter("@from_year", SqlDbType.VarChar, 50);
                    sqlparm[2].Value = dd_year_f.SelectedValue;

                    sqlparm[3] = new SqlParameter("@to_month", SqlDbType.VarChar, 50);
                    sqlparm[3].Value = 0;

                    sqlparm[4] = new SqlParameter("@to_year", SqlDbType.VarChar, 50);
                    sqlparm[4].Value = 0;

                    if (Convert.ToBoolean(ViewState["chekpfesi"]) == true)
                    {
                        sqlparm[5] = new SqlParameter("@pf", SqlDbType.Bit);
                        sqlparm[5].Value = Convert.ToBoolean(ViewState["chekpf"]);

                        sqlparm[6] = new SqlParameter("@esi", SqlDbType.Bit);
                        sqlparm[6].Value = Convert.ToBoolean(ViewState["chekesi"]);


                        sqlparm[7] = new SqlParameter("@cutesi", SqlDbType.Bit);
                        sqlparm[7].Value = Convert.ToBoolean(ViewState["chekesi"]);
                    }
                    else
                    {
                        sqlparm[5] = new SqlParameter("@pf", SqlDbType.Bit);
                        sqlparm[5].Value = chk_pf.Checked;

                        sqlparm[6] = new SqlParameter("@esi", SqlDbType.Bit);
                        sqlparm[6].Value = chk_esi.Checked;


                        sqlparm[7] = new SqlParameter("@cutesi", SqlDbType.Bit);
                        sqlparm[7].Value = chk_esi.Checked;
                    }

                    sqlparm[8] = new SqlParameter("@user", SqlDbType.VarChar, 50);
                    sqlparm[8].Value = Session["name"].ToString();

                    paystrucutreid = Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_create_employee_paystructure", sqlparm));

                    for (int i = 0; i < dtable.Rows.Count; i++)
                    {
                        sqlparm = new SqlParameter[8];

                        sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                        sqlparm[0].Value = dtable.Rows[i]["Empcode"].ToString();

                        sqlparm[1] = new SqlParameter("@payhead", SqlDbType.Int, 4);
                        sqlparm[1].Value = Convert.ToInt32(dtable.Rows[i]["PayheadID"].ToString());

                        sqlparm[2] = new SqlParameter("@calculation_type", SqlDbType.VarChar, 50);
                        sqlparm[2].Value = dtable.Rows[i]["PayCalculationValue"].ToString();

                        sqlparm[3] = new SqlParameter("@value_base", SqlDbType.Decimal);
                        sqlparm[3].Value = (dtable.Rows[i]["ValueBase"].ToString() == "N/A" || dtable.Rows[i]["ValueBase"].ToString() == "") ? System.Data.SqlTypes.SqlDecimal.Null : Convert.ToDecimal(dtable.Rows[i]["ValueBase"]);

                        sqlparm[4] = new SqlParameter("@amount", SqlDbType.Decimal);
                        sqlparm[4].Value = (dtable.Rows[i]["Amount"].ToString() == "N/A" || dtable.Rows[i]["Amount"].ToString() == "") ? System.Data.SqlTypes.SqlDecimal.Null : Convert.ToDecimal(dtable.Rows[i]["Amount"]);

                        //if (dtable.Rows[i]["Amount"].ToString() != "N/A")
                        //{
                        //    ViewState["Amount"] = Convert.ToDecimal(ViewState["Amount"]) + Convert.ToDecimal(dtable.Rows[i]["Amount"]);
                        //}

                        sqlparm[5] = new SqlParameter("@round_method", SqlDbType.VarChar, 50);
                        sqlparm[5].Value = dtable.Rows[i]["RoundMethod"].ToString();

                        sqlparm[6] = new SqlParameter("@user", SqlDbType.VarChar, 50);
                        sqlparm[6].Value = Session["name"].ToString();

                        sqlparm[7] = new SqlParameter("@paystructure_id", SqlDbType.Int, 4);
                        sqlparm[7].Value = paystrucutreid;

                        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_create_employee_paystructure_detail", sqlparm);
                    }
                }
                arrearcal();
                flag = 1;
            }
        }
        if (flag == 1)
        {
            Session.Remove("EmployeePayStructure");
            Updatedconfirmationdiv.Visible = true;
            Divallhide.Visible = false;
            backid.Visible = true;
            Response.Redirect("employeepaystructuredetails.aspx?message=" + arrear_msg + " &empcode=" + txt_employee.Text + "&paystructureid=" + paystrucutreid);
        }
        else
        {
            lblCheckEmpRecords.Text = "Invalid Data! Please check your either month/year Or Employee Name.";
            dd_month_f.Focus();
        }
        //    }

        //catch (Exception ex)
        //{
        //    lblCheckEmpRecords.Visible = true;
        //    lblCheckEmpRecords.Text = "Problem in adding Pay Structure records, try later";
        //}
    }

    protected void getemppaystructuredetails(string empcode, int paystructureid)
    {
        DataRow dr;
        SqlParameter[] sqlparam = new SqlParameter[2];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = empcode;

        sqlparam[1] = new SqlParameter("@paystructure_id", SqlDbType.Int);
        sqlparam[1].Value = paystructureid;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_paystructuredetails", sqlparam);

        txt_employee.Text = empcode;
        txt_employee.Enabled = false;
        lbl_mth_yr.Text = ds.Tables[0].Rows[0]["from_month"].ToString() + " " + ds.Tables[0].Rows[0]["FROM_YEAR"].ToString();
        pickemp.Visible = false;
        chk_pf.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["pf"]);
        chk_esi.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["esi"]);
        lbl_esi.Text = (Convert.ToBoolean(ds.Tables[0].Rows[0]["esi"])) ? "Yes" : "No";
        lbl_pf.Text = (Convert.ToBoolean(ds.Tables[0].Rows[0]["pf"])) ? "Yes" : "No";
        grid_oldstructure.DataSource = ds.Tables[1];
        grid_oldstructure.DataBind();
    }

    protected void btnviewok_Click(object sender, EventArgs e)
    {
        Response.Redirect("employeepaystructuredetails.aspx?empcode=" + txt_employee.Text + "&paystructureid=" + Convert.ToInt32(Request.QueryString["paystructureid"]));
    }
    //protected void employeePayStructure_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    employeePayStructure.PageIndex = e.NewPageIndex;
    //    dtable = (DataTable)Session["EmployeePayStructure"];
    //    employeePayStructure.DataSource = dtable;
    //    employeePayStructure.DataBind();
    //}
    protected void bind_month()
    {
        dd_month_f.Items.Insert(0, new ListItem("Select Month", "0"));
        ddl_reimbursement_month.Items.Insert(0, new ListItem("Select Month", "0"));
        for (int i = 1; i <= 12; i++)
        {
            ListItem item = new ListItem();
            item.Text = new DateTime(1900, i, 1).ToString("MMM");
            item.Value = i.ToString();
            dd_month_f.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
            ddl_reimbursement_month.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
        }
        DateTime a = new DateTime(1900, System.DateTime.Now.Month, 1);
        dd_month_f.SelectedValue = a.Month.ToString();
        ddl_reimbursement_month.SelectedValue = a.Month.ToString();
    }

    protected void bind_year()
    {
        dd_year_f.Items.Insert(0, new ListItem("Select Year", "0"));
        //ddl_reimbursement_year.Items.Insert(0, new ListItem("Select Year", "0"));
        for (int i = 1997; i <= DateTime.Now.Year + 1; i++)
        {
            ListItem item = new ListItem();
            item.Text = new DateTime(i, 1, 1).ToString("yyyy");
            item.Value = i.ToString();
            dd_year_f.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
            //ddl_reimbursement_year.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
        }
        DateTime a = new DateTime(System.DateTime.Now.Year, 1, 1);
        dd_year_f.SelectedValue = a.Year.ToString();
        //ddl_reimbursement_year.SelectedValue = a.Year.ToString();
    }
    protected void btnarrear_Click(object sender, EventArgs e)
    {
        lblCheckEmpRecords.Text = "";
        if (employeePayStructure.Rows.Count > 0)
        {
            DateTime appliedfromdate = CommonBusiness.StringcastDatetime(day: DateTime.Now.Date.ToString("dd"), month: dd_month_f.SelectedItem.Text, year: dd_year_f.SelectedItem.Text);
            int result = DateTime.Compare(appliedfromdate.Date, DateTime.Now.Date);
            if (result < 0)
            {
                calculate_arrear();
            }
            else
            {
                lblCheckEmpRecords.Text = "Please Choose earlier month from current month.";
                dd_month_f.Focus();
            }

        }
    }

    protected void calculate_arrear()
    {
        DataTable dtold = new DataTable();
        DataTable dtnew = new DataTable();
        DataTable dttemp = new DataTable();
        DataRow dr;
        DataRow drfind;
        string temp, strtemp;
        decimal amount = 0.00M, totamount = 0.00M;

        string empcode = Request.QueryString["empcode"].ToString();
        int paystructureid = Convert.ToInt32(Request.QueryString["paystructureid"]);

        checkarrear();

        SqlParameter[] sqlparam = new SqlParameter[2];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = empcode;

        sqlparam[1] = new SqlParameter("@paystructure_id", SqlDbType.Int);
        sqlparam[1].Value = paystructureid;

        DataSet dsold = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_paystructuredetails", sqlparam);

        dtold = (DataTable)dsold.Tables[1];
        dtnew = (DataTable)Session["EmployeePayStructure"];

        if (Session["ot"] == null)
        {
            create_pay_table();
        }

        dttemp = (DataTable)Session["pay"];
        for (int j = 0; j < dtold.Rows.Count; j++)
        {

            temp = dtold.Rows[j]["payhead"].ToString();
            drfind = dtnew.Select("PayheadId=" + temp)[0];

            if (drfind != null)
            {
                ///////FINDING ROWS NUMBER FOR WHICH FIND PAYHEADID
                int krowindex = 0;
                for (int k = 0; k < dtnew.Rows.Count; k++)
                {
                    if (dtnew.Rows[k].Equals(drfind))
                    {
                        krowindex = k;
                        break;
                    }
                }
                ///////AS ON 16 APRIL 2010

                dr = dttemp.NewRow();
                dr["payheadid"] = dtold.Rows[j]["payhead"];
                dr["payheadname"] = dtold.Rows[j]["Head_Name"] + "(A)";
                amount = ((dtnew.Rows[krowindex]["amount"] == "") ? 0 : Convert.ToDecimal(dtnew.Rows[krowindex]["amount"])) - ((dtold.Rows[j]["Amount"] == "") ? 0 : Convert.ToDecimal(dtold.Rows[j]["Amount"]));
                amount = amount < 0 ? 0 : amount;
                dr["amount"] = amount;
                dr["Type"] = Employeedetail.Getpayheadtype(Convert.ToInt32(dtold.Rows[j]["payhead"].ToString()));
                totamount = amount * (Convert.ToInt32(ViewState["monthdiff"]));
                ViewState["Amount"] = Convert.ToDecimal(ViewState["Amount"]) + totamount;
                dr["totamount"] = Math.Round(totamount, 2);
                dttemp.Rows.Add(dr);
            }
            else
            {
                dr = dttemp.NewRow();
                dr["payheadid"] = dtold.Rows[j]["payhead"];
                dr["payheadname"] = dtold.Rows[j]["Head_Name"] + "(A)";
                // amount = ((dtold.Rows[j]["Amount"] == "") ? 0 : Convert.ToDecimal(dtold.Rows[j]["Amount"]));
                dr["amount"] = 0; //Here amount (-)ve because it is in old pay structure
                // totamount = amount * (Convert.ToInt32(ViewState["monthdiff"]) + 1);
                ViewState["Amount"] = 0;//Convert.ToDecimal(ViewState["Amount"]) - totamount; //Here totamount (-)ve because it is in old pay structure
                dr["Type"] = Employeedetail.Getpayheadtype(Convert.ToInt32(dtold.Rows[j]["payhead"].ToString()));
                dr["totamount"] = 0;
                dttemp.Rows.Add(dr);
            }
        }

        for (int j = 0; j < dtnew.Rows.Count; j++)
        {
            Boolean check = false;
            temp = dtnew.Rows[j]["Payheadid"].ToString();

            for (int i = 0; i < dtold.Rows.Count; i++)
            {
                if (dtold.Rows[i]["payhead"].ToString() == temp)
                {
                    check = true;
                }
            }
            if (check == false)
            {
                dr = dttemp.NewRow();
                dr["payheadid"] = dtnew.Rows[j]["Payheadid"];
                dr["payheadname"] = dtnew.Rows[j]["payheadname"] + "(A)";
                amount = ((dtnew.Rows[j]["amount"] == "") ? 0 : Convert.ToDecimal(dtnew.Rows[j]["amount"]));
                amount = amount < 0 ? 0 : amount;
                dr["amount"] = amount;
                totamount = amount * (Convert.ToInt32(ViewState["monthdiff"]));
                ViewState["Amount"] = Convert.ToDecimal(ViewState["Amount"]) + totamount;
                dr["Type"] = Employeedetail.Getpayheadtype(Convert.ToInt32(dtnew.Rows[j]["Payheadid"].ToString()));
                dr["totamount"] = Math.Round(totamount, 2);
                dttemp.Rows.Add(dr);
            }
        }
        Session["pay"] = dttemp;
        bindotdetails();
        paygrid.Visible = true;
        paydiv.Visible = true;
    }

    //----------------------------------------creating table-----------------------------------------
    protected void create_pay_table()
    {
        dtable = new DataTable();
        dtable.Columns.Add("payheadid", typeof(string));
        dtable.Columns.Add("payheadname", typeof(string));
        dtable.Columns.Add("amount", typeof(string));
        dtable.Columns.Add("Type", typeof(string));
        dtable.Columns.Add("totamount", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["payheadid"] };
        Session["pay"] = dtable;
    }

    protected void bindotdetails()
    {
        if (Session["pay"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["pay"];
            dview = new DataView(dtable);
            dview.Sort = "payheadid";
        }
        paygrid.DataSource = dview;
        paygrid.DataBind();
    }

    protected void arrearcal()
    {
        sqlstr2 = "Select convert(varchar,max(todate),101) as date from tbl_payroll_employee_salary where empcode='" + Request.QueryString["empcode"].ToString() + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr2);
        DateTime std = Utilities.Utility.dataformat(ds.Tables[0].Rows[0]["date"].ToString());
        //--------------------------------------------Salary Arrear Calculation-------------------------------------------------------
        if (dtable.Rows.Count > 0)
        {
            string tomonth, toyear;
            DataSet ds1 = new DataSet();
            tomonth = std.Month.ToString("MMM");
            toyear = std.Year.ToString("yyyy");

            dtable = (DataTable)Session["pay"];

            SqlParameter[] sqlparm1;
            sqlparm1 = new SqlParameter[10];

            sqlparm1[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            sqlparm1[0].Value = txt_employee.Text.Trim().ToString();

            sqlparm1[1] = new SqlParameter("@frommonth", SqlDbType.VarChar, 25);
            sqlparm1[1].Value = dd_month_f.SelectedItem.Text;

            sqlparm1[2] = new SqlParameter("@fromyear", SqlDbType.VarChar, 25);
            sqlparm1[2].Value = dd_year_f.SelectedValue;

            sqlparm1[3] = new SqlParameter("@tomonth", SqlDbType.VarChar, 25);
            sqlparm1[3].Value = tomonth.Trim().ToString();

            sqlparm1[4] = new SqlParameter("@toyear", SqlDbType.VarChar, 25);
            sqlparm1[4].Value = toyear.Trim().ToString();

            sqlparm1[5] = new SqlParameter("@remmonth", SqlDbType.VarChar, 25);
            sqlparm1[5].Value = ddl_reimbursement_month.SelectedItem.Text.ToString();

            sqlparm1[6] = new SqlParameter("@remyear", SqlDbType.VarChar, 25);
            sqlparm1[6].Value = ddl_reimbursement_year.SelectedItem.Text.ToString();

            sqlparm1[7] = new SqlParameter("@totalarrear", SqlDbType.Decimal);
            sqlparm1[7].Value = Convert.ToDecimal(ViewState["Amount"]);

            sqlparm1[8] = new SqlParameter("@status", SqlDbType.TinyInt);
            sqlparm1[8].Value = 1;

            sqlparm1[9] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
            sqlparm1[9].Value = Session["name"].ToString();

            ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_create_salary_arrear", sqlparm1);

            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                SqlParameter[] sqlparm2;
                sqlparm2 = new SqlParameter[4];

                sqlparm2[0] = new SqlParameter("@arrearid", SqlDbType.Int);
                sqlparm2[0].Value = Convert.ToInt32(ds1.Tables[0].Rows[0][0]);

                sqlparm2[1] = new SqlParameter("@payheadid", SqlDbType.Int);
                sqlparm2[1].Value = dtable.Rows[i]["PayheadID"].ToString();

                sqlparm2[2] = new SqlParameter("@PayheadName", SqlDbType.VarChar, 25);
                sqlparm2[2].Value = dtable.Rows[i]["payheadname"].ToString();

                sqlparm2[3] = new SqlParameter("@amount", SqlDbType.Decimal);
                sqlparm2[3].Value = (dtable.Rows[i]["totamount"].ToString() == "N/A") ? System.Data.SqlTypes.SqlDecimal.Null : Convert.ToDecimal(dtable.Rows[i]["totamount"]);

                string strInsert = @"INSERT INTO tbl_payroll_salary_arrear_detail(arrearid,payheadid,payheadname,amount) VALUES(@arrearid,@payheadid,@PayheadName,@amount);";
                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, strInsert, sqlparm2);
            }
        }
        //ViewState["Amount"] = 0;
    }
    private void ResetPayStructureGridWithDatasource()
    {
        //################# Reset pay structure new grid data ####################################
        Session["EmployeePayStructure"] = null;
        employeePayStructure.DataSource = null;
        employeePayStructure.DataBind();
        //########################################################################################
        //################# Reset Calculate Arear grid data ######################################
        Session["pay"] = null;
        paygrid.DataSource = null;
        paygrid.DataBind();
        //########################################################################################
        paydiv.Visible = true;
    }
    protected void dd_month_f_SelectedIndexChanged(object sender, EventArgs e)
    {
        ResetPayStructureGridWithDatasource();
        checkarrear();
    }
    protected void dd_year_f_SelectedIndexChanged(object sender, EventArgs e)
    {
        ResetPayStructureGridWithDatasource();
        checkarrear();
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        emppaystructure();
        txtamount.Text = "";
    }
    protected void rdnCalType_SelectedIndexChanged(object sender, EventArgs e)
    {
        divAutomate.Visible = false;
        divManual.Visible = false;
        divexistingemployee.Visible = false;
        ResetPayStructureGridWithDatasource();
        ViewState["chekpfesi"] = false;
        employeePayStructure.DataSource = null;
        employeePayStructure.DataBind();

        if (rdnCalType.SelectedValue == "0")
        {
            ViewState["chekpfesi"] = false;
            divAutomate.Visible = true;
        }

        if (rdnCalType.SelectedValue == "1")
        {
            ViewState["chekpfesi"] = false;
            divManual.Visible = true;
        }

        if (rdnCalType.SelectedValue == "2")
        {
            ViewState["chekpfesi"] = true;
            divexistingemployee.Visible = true;
        }
        btnarrear.Visible = true;
    }
    protected void btn_calculateCTC_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txt_employee.Text))
        {
            lbl_chk_autocal.Text = "Enter employee code";
            lbl_chk_autocal.Visible = true;
            return;
        }

        if (string.IsNullOrEmpty(txt_CTC.Text))
        {
            lbl_chk_autocal.Text = "Enter monthly CTC";
            lbl_chk_autocal.Visible = true;
            return;
        }
        if (dd_month_f.SelectedIndex == 0 || dd_year_f.SelectedIndex == 0)
        {
            lbl_chk_autocal.Text = "Select year/month for pay structure apply";
            lbl_chk_autocal.Visible = true;
            return;
        }
        if (!string.IsNullOrEmpty(txt_employee.Text) && !string.IsNullOrEmpty(txt_CTC.Text))
        {
            lbl_chk_autocal.Text = "";
            lbl_chk_autocal.Visible = false;
        }
        CreateDataTable();
        DataTable dt_paystructure = (DataTable)Session["EmployeePayStructure"];
        decimal basicAmount = Math.Round((Convert.ToDecimal(txt_CTC.Text) * 40) / 100, 0);

        if (basicAmount < PayrollUtility.BasicLimit)
            basicAmount = PayrollUtility.BasicLimit;

        decimal HRAAmount = 0;
        decimal Transport = PayrollUtility.ConveyanceLimit;
        decimal PF = Math.Round((basicAmount * 12) / 100, 0);
        decimal MedicalAllownace = PayrollUtility.MedicelReimLimit;
        decimal SpecialAllowance = 0;
        decimal ESI = 0;

        string query = "select mode from tbl_intranet_employee_contactlist where empcode='" + txt_employee.Text + "'";
        int modeOfTransport = Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, query));

        if (modeOfTransport == 0)
        {
            Transport = PayrollUtility.ConveyanceLimit;
        }
        else
        {
            SpecialAllowance = PayrollUtility.ConveyanceLimit;
            Transport = PayrollUtility.ConveyanceLimit;
        }
        DataRow _dr;

        #region Basic
        _dr = dt_paystructure.NewRow();
        _dr["Empcode"] = txt_employee.Text.Trim();
        _dr["PayheadID"] = "0";
        _dr["PayheadName"] = "Basic";
        _dr["PayCalculationType"] = "Attendance";
        _dr["PayCalculationValue"] = "1";
        _dr["ValueBase"] = "N/A";
        _dr["Amount"] = basicAmount.ToString();
        _dr["Type"] = Employeedetail.Getpayheadtype(0);
        _dr["RoundMethod"] = "Higher Rupees";
        dt_paystructure.Rows.Add(_dr);
        #endregion

        #region HRA
        HRAAmount = basicAmount < PayrollUtility.HRALimit ? 0 : Math.Round((basicAmount * 40 / 100), 0);

        _dr = dt_paystructure.NewRow();
        _dr["Empcode"] = txt_employee.Text.Trim();
        _dr["PayheadID"] = "8";
        _dr["PayheadName"] = "HRA";
        _dr["PayCalculationType"] = "Computed on Basic%";
        _dr["PayCalculationValue"] = "2";
        _dr["ValueBase"] = "40";
        _dr["Amount"] = HRAAmount;
        _dr["Type"] = Employeedetail.Getpayheadtype(8);
        _dr["RoundMethod"] = "Higher Rupees";
        dt_paystructure.Rows.Add(_dr);
        #endregion

        #region Transport
        //if not avail company allowance add Transport Allowance
        if (modeOfTransport == 0)
        {
            _dr = dt_paystructure.NewRow();
            _dr["Empcode"] = txt_employee.Text.Trim();
            _dr["PayheadID"] = "11";
            _dr["PayheadName"] = "Conveyance";
            _dr["PayCalculationType"] = "Computed on Basic";
            _dr["PayCalculationValue"] = "3";
            _dr["ValueBase"] = "N/A";
            _dr["Amount"] = Transport;
            _dr["Type"] = Employeedetail.Getpayheadtype(11);
            _dr["RoundMethod"] = "Higher Rupees";
            dt_paystructure.Rows.Add(_dr);
        }

        //if avail company allowance
        if (modeOfTransport == 1)
        {
            _dr = dt_paystructure.NewRow();
            _dr["Empcode"] = txt_employee.Text.Trim();
            _dr["PayheadID"] = "47";
            _dr["PayheadName"] = "Transport facility";
            _dr["PayCalculationType"] = "Computed on Basic";
            _dr["PayCalculationValue"] = "3";
            _dr["ValueBase"] = "N/A";
            _dr["Amount"] = Transport;
            _dr["Type"] = Employeedetail.Getpayheadtype(47);
            _dr["RoundMethod"] = "Higher Rupees";
            dt_paystructure.Rows.Add(_dr);
        }
        #endregion

        #region PF
        if (chk_pf.Checked)
        {
            _dr = dt_paystructure.NewRow();
            _dr["Empcode"] = txt_employee.Text.Trim();
            _dr["PayheadID"] = "2";
            _dr["PayheadName"] = "Provident Fund";
            _dr["PayCalculationType"] = "Computed on Basic%";
            _dr["PayCalculationValue"] = "2";
            _dr["ValueBase"] = "N/A";
            _dr["Amount"] = PF;
            _dr["Type"] = Employeedetail.Getpayheadtype(2);
            _dr["RoundMethod"] = "Higher Rupees";
            dt_paystructure.Rows.Add(_dr);
        }
        #endregion

        #region MedicalAllownace
        decimal finalMedicalAllownace = MedicalAllownace;
        if (Convert.ToDecimal(txt_CTC.Text) < PayrollUtility.HRALimit)
        {
            finalMedicalAllownace = 0;
        }
        _dr = dt_paystructure.NewRow();
        _dr["Empcode"] = txt_employee.Text.Trim();
        _dr["PayheadID"] = "10";
        _dr["PayheadName"] = "Medical Reimbursement";
        _dr["PayCalculationType"] = "Monthly Flat Rate";
        _dr["PayCalculationValue"] = "0";
        _dr["ValueBase"] = "N/A";
        _dr["Amount"] = MedicalAllownace;
        _dr["Type"] = Employeedetail.Getpayheadtype(10);
        _dr["RoundMethod"] = "Higher Rupees";
        dt_paystructure.Rows.Add(_dr);
        #endregion

        #region ESI
        if (chk_esi.Checked)
        {
            decimal grossCal = Convert.ToDecimal(txt_CTC.Text) - (PF + MedicalAllownace);
            ESI = Math.Round(((grossCal * Convert.ToDecimal(4.75)) / 100), 0);
            _dr = dt_paystructure.NewRow();
            _dr["Empcode"] = txt_employee.Text.Trim();
            _dr["PayheadID"] = "3";
            _dr["PayheadName"] = "ESI";
            _dr["PayCalculationType"] = "Monthly Flat Rate";
            _dr["PayCalculationValue"] = "0";
            _dr["ValueBase"] = "N/A";
            _dr["Amount"] = ESI;
            _dr["Type"] = Employeedetail.Getpayheadtype(3);
            _dr["RoundMethod"] = "Higher Rupees";
            dt_paystructure.Rows.Add(_dr);
        }
        #endregion

        #region SpecialAllowance
        SpecialAllowance += Convert.ToDecimal(txt_CTC.Text) - (basicAmount + HRAAmount + Transport + PF + finalMedicalAllownace + ESI);
        _dr = dt_paystructure.NewRow();
        _dr["Empcode"] = txt_employee.Text.Trim();
        _dr["PayheadID"] = "13";
        _dr["PayheadName"] = "Special Allowance";
        _dr["PayCalculationType"] = "Monthly Flat Rate";
        _dr["PayCalculationValue"] = "0";
        _dr["ValueBase"] = "N/A";
        _dr["Amount"] = SpecialAllowance;
        _dr["Type"] = Employeedetail.Getpayheadtype(13);
        _dr["RoundMethod"] = "Higher Rupees";
        dt_paystructure.Rows.Add(_dr);
        #endregion

        Session["EmployeePayStructure"] = dt_paystructure;
        employeePayStructure.DataSource = dt_paystructure;
        employeePayStructure.DataBind();
        employeePayStructure.Visible = true;
        paydiv.Visible = true;
        btn_submit.Visible = true;
        txt_employee.Enabled = false;
    }
    protected void chk_pf_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_pf.Checked)
        {
            ViewState["chekpf"] = true;
        }
        else
        {
            ViewState["chekpf"] = false;
        }
    }
    protected void chk_esi_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_esi.Checked)
        {
            ViewState["chekesi"] = true;
        }
        else
        {
            ViewState["chekesi"] = false;
        }

    }
    protected void btncalexistingemployeectc_Click(object sender, EventArgs e)
    {
        if (Txtchooseemployee.Text != null && Txtchooseemployee.Text != "" && txt_employee.Text != "")
        {
            string getrefno = @"select  empcode,payhead as PayheadID,(select  CASE WHEN payhead_type =  0 THEN 'Earnings' ELSE 'Deductions' END as Type from tbl_payroll_payhead 
                                     where id=payhead) as type ,(select payhead_name as PayheadName from tbl_payroll_payhead 
                                     where id=payhead) as PayheadName ,calculation_type as PayCalculationType,calculation_type as PayCalculationValue,value_base as ValueBase,amount,round_method as RoundMethod from tbl_payroll_employee_paystructure_detail 
                                     where paystructure_id in 
                                     (select id from tbl_payroll_employee_paystructure where empcode='" + Txtchooseemployee.Text + "' and status=1)";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, getrefno);
            employeePayStructure.DataSource = ds;
            employeePayStructure.DataBind();
            Session["EmployeePayStructure"] = ds.Tables[0];
            employeePayStructure.Visible = true;
            btn_submit.Visible = true;
            txt_employee.Enabled = false;
            string getpfinfo = @"select PF,ESI,CUTESI from tbl_payroll_employee_paystructure where empcode='" + Txtchooseemployee.Text + "' and status = 1";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, getpfinfo);
            ViewState["chekpf"] = Convert.ToBoolean(ds.Tables[0].Rows[0]["PF"]);
            ViewState["chekesi"] = Convert.ToBoolean(ds.Tables[0].Rows[0]["ESI"]);
        }
    }
}
