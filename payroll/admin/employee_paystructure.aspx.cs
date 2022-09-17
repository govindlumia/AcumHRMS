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
using DAL;

public partial class payroll_admin_employee_paystructure : System.Web.UI.Page
{
    string sqlstr, sqlstrPayheadName, sqlstr1;
    DataSet ds = new DataSet();
    DataSet dsPayheadName = new DataSet();
    DataTable dtable = new DataTable();

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
            txt_employee.Attributes.Add("readonly", "readonly");
            Txtchooseemployee.Attributes.Add("readonly", "readonly");
            bind_month();
            bind_year();
            //bind_PayheadName();
            lblpayHeadMsg.Visible = false;
            lblCheckEmpRecords.Text = "";
            rngcheckpercentage.Enabled = false;
            drpPayCalType.Items[2].Enabled = false;
            drpPayCalType.Items[3].Enabled = false;
            valuebase.Visible = false;
            btn_submit.Visible = false;
            Session.Remove("EmployeePayStructure");
            ViewState["chekpfesi"] = false;
        }
        lblCheckEmpRecords.Text = "";
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


    //protected void bind_PayheadName()
    //{
    //    sqlstrPayheadName = @"SELECT [id], [payhead_name] FROM [tbl_payroll_payhead] where id not in (2,3,7,12) and type<>3 and status=1";
    //    dsPayheadName = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrPayheadName);
    //    drpPayHead.DataTextField = "payhead_name";
    //    drpPayHead.DataValueField = "id";
    //    drpPayHead.DataSource = dsPayheadName;
    //    drpPayHead.DataBind();
    //}

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

        //if (drpPayHead.SelectedValue == "2" || drpPayHead.SelectedValue == "3" || drpPayHead.SelectedValue == "4")
        //{
        dtable = (DataTable)Session["EmployeePayStructure"];
        DataRow drfind = dtable.Rows.Find(0);
        decimal amount = Convert.ToDecimal(drfind["Amount"]);
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

    protected void Add_Click(object sender, EventArgs e)
    {

        if (!validate())
        {
            lblCheckEmpRecords.Visible = true;
            lblCheckEmpRecords.Text = "Pay Structure already exists for employee " + txt_employee.Text.ToString();
            drpPayCalType.Items[0].Enabled = true;
            drpPayCalType.Items[1].Enabled = true;
            drpPayCalType.Items[2].Enabled = false;
            //drpPayCalType.Items[3].Enabled = false;
            drpPayCalType.Items[3].Enabled = false;
            rngcheckpercentage.Enabled = false;
            lblpercent.Visible = false;
            valuebase.Visible = false;
            txtamount.Enabled = true;
            txtamount.Text = "";
            divbasic.Visible = true;
            employeePayStructure.Visible = true;
            employeePayStructure.Visible = false;
            return;
        }
        else
        {
            emppaystructure();
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
            //drpPayCalType.Items[3].Enabled = false;
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

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        int paystrucutreid;        
        if (!validate())
        {
            lblCheckEmpRecords.Visible = true;
            lblCheckEmpRecords.Text = "Pay Structure already exists for employee " + txt_employee.Text.ToString();
            drpPayCalType.Items[0].Enabled = true;
            drpPayCalType.Items[1].Enabled = true;
            drpPayCalType.Items[2].Enabled = false;
            //drpPayCalType.Items[3].Enabled = false;
            drpPayCalType.Items[3].Enabled = false;
            rngcheckpercentage.Enabled = false;
            lblpercent.Visible = false;
            valuebase.Visible = false;
            txtamount.Enabled = true;
            txtamount.Text = "";
            divbasic.Visible = true;
            employeePayStructure.Visible = true;
            return;
        }

        try
        {
            dtable = (DataTable)Session["EmployeePayStructure"];
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
                    sqlparm[0].Value = txt_employee.Text;

                    sqlparm[1] = new SqlParameter("@payhead", SqlDbType.Int, 4);
                    sqlparm[1].Value = Convert.ToInt32(dtable.Rows[i]["PayheadID"].ToString());

                    sqlparm[2] = new SqlParameter("@calculation_type", SqlDbType.VarChar, 50);
                    sqlparm[2].Value = dtable.Rows[i]["PayCalculationValue"].ToString();

                    sqlparm[3] = new SqlParameter("@value_base", SqlDbType.Decimal);
                    sqlparm[3].Value = (dtable.Rows[i]["ValueBase"].ToString() == "N/A" || dtable.Rows[i]["ValueBase"].ToString() == "") ? System.Data.SqlTypes.SqlDecimal.Null : Convert.ToDecimal(dtable.Rows[i]["ValueBase"]);

                    sqlparm[4] = new SqlParameter("@amount", SqlDbType.Decimal);
                    sqlparm[4].Value = (dtable.Rows[i]["Amount"].ToString() == "N/A" || dtable.Rows[i]["Amount"].ToString() == "") ? System.Data.SqlTypes.SqlDecimal.Null : Convert.ToDecimal(dtable.Rows[i]["Amount"]);

                    sqlparm[5] = new SqlParameter("@round_method", SqlDbType.VarChar, 50);
                    sqlparm[5].Value = dtable.Rows[i]["RoundMethod"].ToString();

                    sqlparm[6] = new SqlParameter("@user", SqlDbType.VarChar, 50);
                    sqlparm[6].Value = Session["name"].ToString();

                    sqlparm[7] = new SqlParameter("@paystructure_id", SqlDbType.VarChar, 50);
                    sqlparm[7].Value = paystrucutreid;

                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_create_employee_paystructure_detail", sqlparm);

                }
            }
            lblCheckEmpRecords.Visible = true;
            lblCheckEmpRecords.Text = "Records added successfully";
            drpPayCalType.Items[0].Enabled = true;
            drpPayCalType.Items[1].Enabled = true;
            drpPayCalType.Items[2].Enabled = false;
            //drpPayCalType.Items[3].Enabled = false;
            drpPayCalType.Items[3].Enabled = false;
            rngcheckpercentage.Enabled = false;
            lblpercent.Visible = false;
            valuebase.Visible = false;
            txtamount.Enabled = true;
            txtamount.Text = "";
            divbasic.Visible = true;
            employeePayStructure.Visible = false;
            drpPayHead.SelectedValue = "0";
            Session.Remove("EmployeePayStructure");
            txt_employee.Text = "";
            txt_employee.Enabled = true;
            pickemp.Visible = true;
            btn_submit.Visible = false;
            txt_CTC.Text = "";
            ddl_citytype.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblCheckEmpRecords.Visible = true;
            lblCheckEmpRecords.Text = "Problem in adding Pay Structure records, try later";
        }
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
        for (int i = 1; i <= 12; i++)
        {
            ListItem item = new ListItem();
            item.Text = new DateTime(1900, i, 1).ToString("MMM");
            item.Value = i.ToString();
            dd_month_f.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
        }
        DateTime a = new DateTime(1900, System.DateTime.Now.Month, 1);
        dd_month_f.SelectedValue = a.Month.ToString();
    }

    protected void bind_year()
    {

        sqlstr = "SELECT financial_year year FROM tbl_payroll_tax_master where id not in (1,2,3,4,5,6) order by id desc";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_year_f.DataTextField = "year";
        dd_year_f.DataValueField = "year";
        dd_year_f.DataSource = ds;
        dd_year_f.DataBind();
        dd_year_f.Items.Insert(0, new ListItem("Select Year", "0"));

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
        if (!validate())
        {
            lblCheckEmpRecords.Visible = true;
            lblCheckEmpRecords.Text = "Pay Structure already exists for employee " + txt_employee.Text.ToString();
            drpPayCalType.Items[0].Enabled = true;
            drpPayCalType.Items[1].Enabled = true;
            drpPayCalType.Items[2].Enabled = false;
            //drpPayCalType.Items[3].Enabled = false;
            drpPayCalType.Items[3].Enabled = false;
            rngcheckpercentage.Enabled = false;
            lblpercent.Visible = false;
            valuebase.Visible = false;
            txtamount.Enabled = true;
            txtamount.Text = "";
            divbasic.Visible = true;
            employeePayStructure.Visible = true;
            employeePayStructure.Visible = false;
            return;
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
        decimal FInalMedicalAllownace = MedicalAllownace;
        if ((Convert.ToDecimal(txt_CTC.Text) < PayrollUtility.SpecialAmountCTClimit))
        {
            FInalMedicalAllownace = 0;
        }
        _dr = dt_paystructure.NewRow();
        _dr["Empcode"] = txt_employee.Text.Trim();
        _dr["PayheadID"] = "10";
        _dr["PayheadName"] = "Medical Reimbursement";
        _dr["PayCalculationType"] = "Monthly Flat Rate";
        _dr["PayCalculationValue"] = "0";
        _dr["ValueBase"] = "N/A";
        _dr["Amount"] = FInalMedicalAllownace;
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
        SpecialAllowance += Convert.ToDecimal(txt_CTC.Text) - (basicAmount + HRAAmount + Transport + PF + FInalMedicalAllownace + ESI);
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
        btn_submit.Visible = true;
        txt_employee.Enabled = false;
    }
    protected void rdnCalType_SelectedIndexChanged(object sender, EventArgs e)
    {
        divAutomate.Visible = false;
        divManual.Visible = false;
        divexistingemployee.Visible = false;
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
         
    }
    protected void btncalexistingemployeectc_Click(object sender, EventArgs e)
    {
        if(Txtchooseemployee.Text!=null && Txtchooseemployee.Text!="" && txt_employee.Text!="")
        {
            if (!validate())
            {
                lblCheckEmpRecords.Text = "";
                lblCheckEmpRecords.Visible = true;
                lblCheckEmpRecords.Text = "Pay Structure already exists for employee " + txt_employee.Text.ToString();
            }
            else
            {
                string getrefno = @"select  empcode,payhead as PayheadID,(select  CASE WHEN payhead_type =  0 THEN 'Earnings' ELSE 'Deductions' END as Type from tbl_payroll_payhead 
                                     where id=payhead) as type ,(select payhead_name as PayheadName from tbl_payroll_payhead 
                                     where id=payhead) as PayheadName ,calculation_type as PayCalculationType,calculation_type as PayCalculationValue,value_base as ValueBase,amount,round_method as RoundMethod from tbl_payroll_employee_paystructure_detail 
                                     where paystructure_id in 
                                     (select id from tbl_payroll_employee_paystructure where empcode='" + Txtchooseemployee.Text+"' and status=1)";
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, getrefno);
                employeePayStructure.DataSource = ds;
                employeePayStructure.DataBind();
                Session["EmployeePayStructure"] = ds.Tables[0];
                employeePayStructure.Visible = true;
                btn_submit.Visible = true;
                txt_employee.Enabled = false;
                string getpfinfo = @"select PF,ESI,CUTESI from tbl_payroll_employee_paystructure where empcode='"+Txtchooseemployee.Text+"' and status = 1";
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, getpfinfo);
                ViewState["chekpf"] =Convert.ToBoolean(ds.Tables[0].Rows[0]["PF"]);
                ViewState["chekesi"] = Convert.ToBoolean(ds.Tables[0].Rows[0]["ESI"]);
            }
            
        }
    }
    protected void chk_pf_CheckedChanged(object sender, EventArgs e)
    {
        if(chk_pf.Checked)
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
}
