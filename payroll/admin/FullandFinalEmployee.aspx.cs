using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using DataAccessLayer;


public partial class payroll_admin_FullandFinalEmployee : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    SqlDataAdapter da = new SqlDataAdapter();
    DataTable dt=new DataTable();
    string connStr = string.Empty;
    string sqlstr;
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_employee.Attributes.Add("readonly", "readonly");
        connStr = ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString();
       
        if (!Page.IsPostBack)
        {           
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }               
            else Response.Redirect("~/notlogged.aspx");
            Session["fnfallowancegriddatatable"] = null;
            BindAllowanceddl();
            createdatatable();
            //###################################Edit Info##########################################
          if (Request.QueryString["Empcodeeditfnf"].ToString() != "insert")
            {
                txt_employee.Text = Request.QueryString["Empcodeeditfnf"].ToString();
                EmployeeBasicDetails();
                if(Request.QueryString["REIMBURSEMENT_TYPE"].ToString()=="Check")
                {
                    Ddlreimbursmenttype.SelectedIndex = 1;
                }
                if(Request.QueryString["REIMBURSEMENT_TYPE"].ToString()=="Cash")
                {
                    Ddlreimbursmenttype.SelectedIndex = 2;
                }
                if (Request.QueryString["REIMBURSEMENT_TYPE"].ToString() == "Bank")
                {
                    Ddlreimbursmenttype.SelectedIndex = 3;
                    Ddlbanknametype.SelectedItem.Text = Request.QueryString["bankname"].ToString();
                    tblrowbankinfo.Visible = true;
                }
                txt_FAF.Text =Convert.ToDateTime(Request.QueryString["DATE_OF_FNF"].ToString()).ToString("dd-MMM-yyyy");
                txtWorkingDays.Text = Request.QueryString["workingdays"].ToString();
                if(Convert.ToBoolean(Request.QueryString["onholdsalary"].ToString())==true)
                {
                   ChkExp.Checked=true;
                }
                else
                {
                    ChkExp.Checked = false;
                }
                bindallowancegridforedit();
                editmasterinfo.Visible = false;
                editmasterinfoline.Visible = false;
                Btngeneratefnd.Text = "Update Fnf Info";
                ChkExp.Enabled = false;
                ChkExp.Checked = false;

            }
          //###################################Insert Info ########################################
            else
            {               
                tblrowbankinfo.Visible = false;
            }
           
        }
    }
    public void bindallowancegridforedit()
    {
        sqlstr = @"SELECT  * FROM Tbl_FNF_ALLOWANCE WHERE EMPCODE='"+txt_employee.Text+"'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count != 0)
        {
            dt = (DataTable)Session["fnfallowancegriddatatable"];
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DataRow _dr;
                _dr = dt.NewRow();
                _dr["empcode"] = dr["empcode"];
                _dr["Allowance_id"] = dr["Allowance_id"];
                _dr["AllowanceName"] = dr["AllowanceName"];
                _dr["Amount"] = dr["Amount"];
                dt.Rows.Add(_dr);
                Session["fnfallowancegriddatatable"] = dt;
            }
        }
        addallowanceforfnf.DataSource = ds.Tables[0];
        addallowanceforfnf.DataBind();
    }
    //===================Bind Allowance DropdownList========================
    private void BindAllowanceddl()
    {
        sqlstr = @"SELECT [id], [payhead_name] FROM [tbl_payroll_payhead] where type=3 and status=1 or payhead_name='Gratuity' or payhead_name='Notic Period'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        drpPayHead.DataTextField = "payhead_name";
        drpPayHead.DataValueField = "id";
        drpPayHead.DataSource = ds;
        drpPayHead.DataBind();
        drpPayHead.Items.Insert(0, new ListItem("---Select Allowance---", "0"));

    }
    //===================Bind Allowance DropdownList========================
    public void EmployeeBasicDetails()
    {
        //=================================Calculate Any Due=====================================
        if (Getdueofemployee())
        {
            lbmsgdue.Text = "Employee have due amount!!";
            Btngeneratefnd.Visible = false;
            line.Visible = false;
            btnadddeductallowance.Visible = false;
            Btnviewloandetails.Visible = true;
        }
        else
        {
            lbmsgdue.Text = "";
            Btngeneratefnd.Visible = true;
            line.Visible = true;
            btnadddeductallowance.Visible = true;
            Btnviewloandetails.Visible = false;
        }
        //=================================Calculate Any Due=====================================
        BindGratuity();
        EmployeeDetails();   
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        EmployeeBasicDetails();
    }
    protected void BindGratuity()
    {
            SqlParameter[] sqlparam;
            sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@empcode", SqlDbType.Int, 50);
            sqlparam[0].Value = Convert.ToInt32(txt_employee.Text);
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "usp_calculate_graduity", sqlparam);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblgraduityAmount.Text = ds.Tables[0].Rows[0]["Gratuity_Amt"].ToString();
                lblLast10basic.Text = ds.Tables[0].Rows[0]["last_10_basic"].ToString();
                lblMaxExmption.Text = ds.Tables[0].Rows[0]["max_exmption"].ToString();
            }
            else
            {
                lblgraduityAmount.Text = "0.00";
                lblLast10basic.Text = "0.00";
                lblMaxExmption.Text = "0.00";
            }
    }
    //=====================================GET DUE===============================================
    protected Boolean Getdueofemployee()
    {
        Boolean checkdueamount=false;
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[1];
        sqlparam[0] = new SqlParameter("@Empcode", SqlDbType.Int, 50);
        sqlparam[0].Value = Convert.ToInt32(txt_employee.Text); //20120065;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "GET_PENDING_DUE_OF_EMPLOYEE", sqlparam);
        if (ds.Tables[0].Rows.Count != 0)
        {
            int dueamount =  Convert.ToInt32(Convert.ToDecimal(ds.Tables[0].Rows[0]["DueAmount"].ToString()));
            if (dueamount != 0)
            {
                checkdueamount = true;
                ViewState["Loanrefidofcurrentemployee"] = ds.Tables[0].Rows[0]["RefId"].ToString();
            }
            else
            {
                checkdueamount = false;
            }
        }
        return checkdueamount;
    }
    //===========================================================================================

    protected void Btnviewloandetails_Click(object sender, EventArgs e)
    {
        string url = "/payroll/admin/settleloanadvances.aspx?LoanRefid=" + ViewState["Loanrefidofcurrentemployee"].ToString();
        Response.Redirect(url);
    }
    //=====================================Get Employee Details==================================
    protected void EmployeeDetails()
    {
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[1];
        sqlparam[0] = new SqlParameter("@Empcode", SqlDbType.Int, 50);
        sqlparam[0].Value = Convert.ToInt32(txt_employee.Text); //20120065;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "GET_EMPDETAILS_FNF", sqlparam);
        if (ds.Tables[0].Rows.Count != 0 && ds.Tables[1].Rows.Count != 0)
        {
            dol.Text = ds.Tables[1].Rows[0]["dateofleaving"].ToString();
            ViewState["empfullnmefnf"] = ds.Tables[1].Rows[0]["empfullname"].ToString();
            lbllastsaldate.Text = ds.Tables[0].Rows[0]["lastsaldate"].ToString() == "" || ds.Tables[0].Rows[0]["lastsaldate"].ToString() == null ? "N.A" : ds.Tables[0].Rows[0]["lastsaldate"].ToString();
            ViewState["designationname"]=ds.Tables[0].Rows[0]["designationname"].ToString();
            ViewState["dateofjoining"]=ds.Tables[0].Rows[0]["joindate"].ToString();
            ViewState["companynameemp"] = ds.Tables[4].Rows[0]["companyname"].ToString();
        }
        else
        {
            dol.Text = "";
            lbllastsaldate.Text = "";
        }
        if (ds.Tables[2].Rows.Count != 0)
        {
            Ddlbanknametype.DataTextField = "bankname";
            Ddlbanknametype.DataValueField = "accountnumber";
            Ddlbanknametype.DataSource = ds.Tables[2];
            Ddlbanknametype.DataBind();
            Ddlbanknametype.Items.Insert(0, new ListItem("---Select Bank---", "0"));
            lblempaccountno.Text = ds.Tables[3].Rows[0]["EmpAccountNo"].ToString() == "" || ds.Tables[3].Rows[0]["EmpAccountNo"].ToString() == null ? "N.A" : ds.Tables[3].Rows[0]["EmpAccountNo"].ToString();     
        }
        
    }
    //===========================================================================================
    public void createdatatable()
    {
        dt.Columns.Add("empcode", typeof(string));
        dt.Columns.Add("Allowance_id", typeof(string));
        dt.Columns.Add("AllowanceName", typeof(string));
        dt.Columns.Add("Amount", typeof(string));
        Session["fnfallowancegriddatatable"] = dt;
    }
    protected void btnadddeductallowance_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txt_employee.Text))
        {
            dt = (DataTable)Session["fnfallowancegriddatatable"];
            DataRow[] drr = dt.Select("Allowance_id=" + drpPayHead.SelectedValue);
            if (drr.Length == 0)
            {
                DataRow _dr;
                _dr = dt.NewRow();
                _dr["empcode"] = txt_employee.Text;
                _dr["Allowance_id"] = drpPayHead.SelectedValue;
                _dr["AllowanceName"] = drpPayHead.SelectedItem.Text;
                _dr["Amount"] = txtAllowanceAmount.Text;
                dt.Rows.Add(_dr);
                Session["fnfallowancegriddatatable"] = dt;
                addallowanceforfnf.DataSource = dt;
                addallowanceforfnf.DataBind();
                txtAllowanceAmount.Text = "";
                drpPayHead.SelectedIndex = 0;
            }
            else
            {
                General.Alert("Already Added In list You Can Modify!", btnadddeductallowance);
                txtAllowanceAmount.Text = "";
                drpPayHead.SelectedIndex = 0;
            }
          //  this.addallowanceforfnf.Columns[0].Visible = false;
        }
        else
        {
            General.Alert("Please choose employee first!", btnadddeductallowance);
            txt_employee.Focus();
        }
    }
    protected void addallowanceforfnf_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        addallowanceforfnf.PageIndex = e.NewPageIndex;
        dt = (DataTable)Session["fnfallowancegriddatatable"];
        addallowanceforfnf.DataSource = dt;
        addallowanceforfnf.DataBind();
    }
    protected void addallowanceforfnf_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        addallowanceforfnf.EditIndex = -1;
        dt = (DataTable)Session["fnfallowancegriddatatable"];
        addallowanceforfnf.DataSource = dt;
        addallowanceforfnf.DataBind();
    }
    protected void addallowanceforfnf_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string  Delallowanceid= addallowanceforfnf.DataKeys[e.RowIndex][0].ToString() ;
        dt = (DataTable)Session["fnfallowancegriddatatable"];
        foreach (DataRow dr in dt.Rows)
        {
            if (dr.ItemArray[1].ToString() == Delallowanceid)
            {
                dr.Delete();
            }

        }
        dt.AcceptChanges();
        Session["fnfallowancegriddatatable"] = dt;
        addallowanceforfnf.DataSource = dt;
        addallowanceforfnf.DataBind();
    }
    protected void addallowanceforfnf_RowEditing(object sender, GridViewEditEventArgs e)
    {
        addallowanceforfnf.EditIndex = e.NewEditIndex;
        dt = (DataTable)Session["fnfallowancegriddatatable"];
        addallowanceforfnf.DataSource = dt;
        addallowanceforfnf.DataBind();
    }
    protected void addallowanceforfnf_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string updatedallowanceid = addallowanceforfnf.DataKeys[e.RowIndex][0].ToString();
        dt = (DataTable)Session["fnfallowancegriddatatable"];
        TextBox Textupdatedamount = ((TextBox)addallowanceforfnf.Rows[e.RowIndex].Cells[2].Controls[1]);
        foreach(DataRow dr in dt.Rows)
        {
            if (dr.ItemArray[1].ToString() == updatedallowanceid)
           {
               dr["Amount"] = Textupdatedamount.Text;
           }
            
        }
        dt.AcceptChanges();
        addallowanceforfnf.EditIndex = -1;
        Session["fnfallowancegriddatatable"] = dt;
        addallowanceforfnf.DataSource = dt;
        addallowanceforfnf.DataBind();
    }

    protected void Ddlreimbursmenttype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(Ddlreimbursmenttype.SelectedValue=="3")
        {
            tblrowbankinfo.Visible = true;
        }
        else
        {
            tblrowbankinfo.Visible = false;
        }
    }
    protected void Btngeneratefnd_Click(object sender, EventArgs e)
    {
        string bankname = "N.A";
        if(Ddlreimbursmenttype.SelectedIndex==3)
        {
            if(Ddlbanknametype.SelectedItem.Text!="---Select Bank---")
            {
               bankname = Ddlbanknametype.SelectedItem.Text;
            }
            else
            {
                General.Alert("Please choose bank name!", btnadddeductallowance);
                return;
            }
        }
        string fnfdate = Convert.ToDateTime(txt_FAF.Text).ToString("MM/dd/yyyy");
        if (!string.IsNullOrWhiteSpace(dol.Text))
        {
            int onhold;
            SqlParameter[] sqlparam;
            sqlparam = new SqlParameter[7];
            sqlparam[0] = new SqlParameter("@EMPCODE", SqlDbType.Int, 50);
            sqlparam[0].Value = Convert.ToInt32(txt_employee.Text); //20120065;
            sqlparam[1] = new SqlParameter("@USERID", SqlDbType.Int, 50);
            sqlparam[1].Value = Convert.ToInt32(Session["empcode"].ToString());
            if (ChkExp.Checked == true)
            {
                sqlparam[2] = new SqlParameter("@INCLUDE_ONHOLD_SALARY", SqlDbType.Bit, 50);
                sqlparam[2].Value = 1;
                onhold = 1;
            }
            else
            {
                sqlparam[2] = new SqlParameter("@INCLUDE_ONHOLD_SALARY", SqlDbType.Bit, 50);
                sqlparam[2].Value =0;
                onhold = 0;
            }
            dt = (DataTable)Session["fnfallowancegriddatatable"];
            sqlparam[3] = new SqlParameter("@TBLFNFALLOWANCE", SqlDbType.Structured, 50);
            sqlparam[3].Value = dt;
            if(!string.IsNullOrEmpty(txtWorkingDays.Text) && !string.IsNullOrWhiteSpace(txtWorkingDays.Text))
            {
                sqlparam[4] = new SqlParameter("@PAIDWORKING_DAYS", SqlDbType.Int, 50);
                sqlparam[4].Value = Convert.ToInt32(txtWorkingDays.Text);
            }
            else
            {
                sqlparam[4] = new SqlParameter("@PAIDWORKING_DAYS", SqlDbType.Int, 50);
                sqlparam[4].Value =0;
            }
            sqlparam[5] = new SqlParameter("@LASTSALARYDATE", SqlDbType.DateTime, 50);
            sqlparam[5].Value =Convert.ToDateTime(lbllastsaldate.Text).ToString("yyyy-MM-dd");
            sqlparam[6] = new SqlParameter("@FNF_TYPE", SqlDbType.Bit, 50);
            sqlparam[6].Value = 1;
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "[dbo].[TO_GENERATE_FNF]", sqlparam);
            double totalearning=0;
            double totaldeduction = 0;
            double totalgrandpay=0;
            double totalworkingdays=0;
            if (ds.Tables[1].Rows.Count != 0 && ds.Tables[2].Rows.Count != 0)
            {
                Session["Fnfgenerationdata"] = ds;
                //===========Total Earning=============
                foreach(DataRow dr in ds.Tables[1].Rows)
                {
                    totalearning = totalearning+Convert.ToDouble(dr["Amount"]);
                }
                //===========Total Deduction=============
                foreach (DataRow dr in ds.Tables[2].Rows)
                {
                    totaldeduction = totaldeduction + Convert.ToDouble(dr["Amount"]);
                }
                //===========Total working days=============
                foreach (DataRow dr in ds.Tables[3].Rows)
                {
                    totalworkingdays = Convert.ToDouble(dr["TOTALWORKINGDAYS"]);
                }
                totalgrandpay = totalearning - totaldeduction;
                string sqlstr1;
                if (Request.QueryString["Empcodeeditfnf"].ToString() != "insert")
                {
                    sqlstr1 = @"UPDATE  Tbl_FNF SET DATE_OF_FNF='" + Convert.ToDateTime(txt_FAF.Text) + "',REIMBURSEMENT_TYPE='" + Ddlreimbursmenttype.SelectedItem.Text + "',CREATED_BY='" + Convert.ToInt32(Session["empcode"].ToString()) + "',INCLUDE_ONHOLD_SALARY='" + onhold + "',TOTAL_DEDUCTIONS='" + totaldeduction + "',TOTAL_EARNINGS='" + totalearning + "',TOTAL_PAY='" + totalgrandpay + "',total_workindays='" + totalworkingdays + "',bankname='" + bankname + "' WHERE EMPCODE= '" + txt_employee.Text + "'";
                }
                else
                {
                  sqlstr1 = @"insert into Tbl_FNF values('" + txt_employee.Text + "','" + Convert.ToDateTime(txt_FAF.Text) + "','" + Ddlreimbursmenttype.SelectedItem.Text + "','" + Convert.ToInt32(Session["empcode"].ToString()) + "','" + onhold + "','" + totaldeduction + "','" + totalearning + "','" + totalgrandpay + "','" + totalworkingdays + "','" + bankname + "')";
                }
                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);
                string redirecturl = "FullAndFinal.aspx?Empcode=" + txt_employee.Text + "-" + Session["EmpName"].ToString() + "&Accountno=" + lblempaccountno.Text + "&Designation=" + ViewState["designationname"].ToString() + "&doj=" + ViewState["dateofjoining"].ToString() + "&totalworkingdays=" + totalworkingdays.ToString() + "&fnfdate=" + fnfdate + "&lastworkingdate=" + dol.Text + "&paytype=" + Ddlreimbursmenttype.SelectedItem.Text + "&bankname=" + bankname + "&totaldeduction=" + totaldeduction + "&totalearning=" + totalearning + "&netpay=" + totalgrandpay + "&companynamefnf=" + ViewState["companynameemp"].ToString() + "&empfullname=" + ViewState["empfullnmefnf"].ToString(); ;
                Refreshfnfentity();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + redirecturl + "');", true);
            }
            else
            {
                General.Alert("Incorrect information is present in database please correct them then reprocess!", btnadddeductallowance);
            }

        }
        else
        {
            General.Alert("Please update employee date of leaving!", btnadddeductallowance);
        }
    }
    private void Refreshfnfentity()
    {
        txt_employee.Text = "";
        lblempaccountno.Text = "";
        ViewState["designationname"] = "";
        ViewState["dateofjoining"] = "";
        dol.Text = "";
        txt_FAF.Text = "";
        Ddlreimbursmenttype.SelectedIndex = 0;
        Ddlbanknametype.SelectedIndex = 0;
        tblrowbankinfo.Visible = false;
        lbllastsaldate.Text = "";
        ViewState["companynameemp"] = "";
        Session["fnfallowancegriddatatable"] = null;
        txtWorkingDays.Text = "";
        addallowanceforfnf.DataSource = null;
        addallowanceforfnf.DataBind();
    }
    protected void txtWorkingDays_TextChanged(object sender, EventArgs e)
    {
       // if (Convert.ToInt32(txtWorkingDays.Text) == 0 || string.IsNullOrEmpty(txtWorkingDays.Text))
        int workDays=0;
        Int32.TryParse(txtWorkingDays.Text,out workDays);
        if (workDays==0)
        {
            ChkExp.Enabled = true;
        }
        else
        {
            ChkExp.Enabled = false;
            ChkExp.Checked = false;
        }
    }
}
