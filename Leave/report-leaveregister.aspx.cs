using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using System.Globalization;
using Utilities;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;

public partial class leave_report_leaveregister : System.Web.UI.Page
{
    string strsql = "";
    string sqlstr;

    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        // p3.Visible = false;
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            bind_fyear();
            FillControl();
            rdnCalType.SelectedValue = "0";
            ViewState["dataforGrid"] = null;
            divleavesummary.Visible = false;
        }
    }
    protected void dd_month_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_fyear();
        //validate_attendance();
    }
    protected void bind_fyear()
    {
        sqlstr = "SELECT financial_year year FROM tbl_payroll_tax_master  order by id desc";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_year.DataTextField = "year";
        dd_year.DataValueField = "year";
        dd_year.DataSource = ds;
        dd_year.DataBind();
    }

    protected void FillControl()
    {
        CommonBusiness commonBusiness = new CommonBusiness();
        BindDropDowns(dd_company, commonBusiness.BindDropDowns("", "Company"), "companyid", "companyname");
        BindDropDowns(ddlcompany, commonBusiness.BindDropDowns("", "Company"), "companyid", "companyname");

    }

    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("---Select---", "0"));
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        bindgrid();
        p3.Visible = true;
    }

    protected void adjustgrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.className='hover-clr'");
            e.Row.Attributes.Add("onmouseout", "this.className='out-clr-1'");
        }
    }

    protected void adjustgrid_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
        {
            CheckBox chkBxSelect = (CheckBox)e.Row.Cells[0].FindControl("chkselect");
            CheckBox chkBxHeader = (CheckBox)this.adjustgrid.HeaderRow.FindControl("chkBxHeader");
            chkBxSelect.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chkBxHeader.ClientID);
        }
    }

    protected void btn_ok_Click(object sender, EventArgs e)
    {
        string empcode = "";
        DataRow dr;
        //(TextBox)ShopCartGrid.Rows[e.RowIndex].Cells[4].Controls[1]).Text;
        CheckBox Tmark1;
        for (int j = 0; j <= adjustgrid.Rows.Count - 1; j++)
        {
            Tmark1 = (CheckBox)adjustgrid.Rows[j].Cells[0].FindControl("chkselect");
            if (Tmark1.Checked == true)
            {
                empcode = empcode + ((Label)adjustgrid.Rows[j].Cells[0].FindControl("l2")).Text.Trim() + ",";
            }
        }
        p3.Visible = false;
        if (empcode != "")
            txt_employee.Text = empcode.Substring(0, empcode.Length - 1);
    }

    //protected void dd_dept_DataBound(object sender, EventArgs e)
    //{
    //    dd_dept.Items.Insert(0, new ListItem("All", "0"));
    //}

    protected void ddl_leaveType_DataBound(object sender, EventArgs e)
    {
        ddlLeaveType.Items.Insert(0, new ListItem("All", "0"));
    }



    protected void bindgrid()
    {
        SqlParameter[] arrParam = new SqlParameter[1];
        arrParam[0] = new SqlParameter("@Company", Convert.ToInt32(dd_company.SelectedValue));

        strsql = @"select tbl_intranet_employee_jobDetails.empcode,coalesce(emp_fname,'') + ' ' + coalesce(emp_l_name,'') as ename 
                     from  tbl_intranet_employee_jobDetails
                     tbl_intranet_employee_jobDetails 
                     inner join tbl_login on 
                     tbl_intranet_employee_jobDetails.empcode=tbl_login.empcode 
                     inner join tbl_intranet_companydetails on
                     tbl_login.companyid=tbl_intranet_companydetails.companyid
                     where tbl_intranet_companydetails.companyid=@Company
                     order by (coalesce(emp_fname,'') + ' ' + coalesce(emp_l_name,'')) asc ";



        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, strsql, arrParam);
        adjustgrid.DataSource = ds;
        adjustgrid.DataBind();
    }

    protected void img_close_Click(object sender, ImageClickEventArgs e)
    {
        p3.Visible = false;
    }

    protected void btn_close_Click(object sender, EventArgs e)
    {
        p3.Visible = false;
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindempleave();
    }

    protected void empleavegrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empleavegrid.PageIndex = e.NewPageIndex;
        bindempleave();
    }

    protected void bindempleave()
    {
        DateTime dt = DateTime.Now;
        DateTime sdate = new DateTime();
        DateTime edate = new DateTime();
        if (chk_temp.Checked)
        {
            //current week
            if (drp_template.SelectedValue == "0")
            {
                //dt = DateTime.Today;
                while (dt.DayOfWeek.ToString() != "Monday")
                    dt = dt.AddDays(-1);
                sdate = dt;
                edate = sdate.AddDays(6);
            }

            //previous week
            if (drp_template.SelectedValue == "1")
            {
                while (dt.DayOfWeek.ToString() != "Monday")
                    dt = dt.AddDays(-1);
                sdate = dt.AddDays(-7);
                edate = sdate.AddDays(6);
            }

            //next week
            if (drp_template.SelectedValue == "2")
            {
                while (dt.DayOfWeek.ToString() != "Monday")
                    dt = dt.AddDays(-1);
                sdate = dt.AddDays(7);
                edate = sdate.AddDays(6);
            }

            if (drp_template.SelectedValue == "3")
            {
                int currentmonth;
                DateTime firstday, lastday;
                currentmonth = dt.Month;
                firstday = Convert.ToDateTime(currentmonth + "/1/" + DateTime.Today.Year);
                lastday = firstday.AddMonths(1).AddDays(-1);

                sdate = Convert.ToDateTime(DateTime.Today.Month.ToString() + "/1/" + DateTime.Today.Year.ToString());
                edate = lastday;
            }

            if (drp_template.SelectedValue == "4")
            {
                int currentmonth;
                DateTime firstday, lastday;
                currentmonth = dt.Month;
                firstday = Convert.ToDateTime(currentmonth + "/1/" + DateTime.Today.Year);
                lastday = firstday.AddDays(-1);

                if (DateTime.Today.Month == 1)
                {
                    sdate = Convert.ToDateTime("12/1/" + (DateTime.Today.Year - 1));
                    edate = lastday;
                }
                else
                {
                    sdate = Convert.ToDateTime((DateTime.Today.Month - 1) + "/1/" + DateTime.Today.Year.ToString());
                    edate = lastday;
                }
            }

            if (drp_template.SelectedValue == "5")
            {
                int currentmonth;
                DateTime firstday, lastday;
                currentmonth = dt.Month;
                firstday = Convert.ToDateTime(currentmonth + "/1/" + DateTime.Today.Year);
                lastday = firstday.AddMonths(2).AddDays(-1);

                if (DateTime.Today.Month == 12)
                {
                    sdate = Convert.ToDateTime("1/1/" + (DateTime.Today.Year + 1));
                    edate = lastday;
                }
                else
                {
                    sdate = Convert.ToDateTime((DateTime.Today.Month + 1) + "/1/" + DateTime.Today.Year.ToString());
                    edate = lastday;
                }
            }

            txt_sdate.Text = sdate.ToShortDateString();
            txt_edate.Text = edate.ToShortDateString();
        }
        else
        {
            sdate = Utility.DateTimeForat(txt_sdate.Text);
            edate = Utility.DateTimeForat(txt_edate.Text);
        }

        SqlParameter[] param = new SqlParameter[8];
        param[0] = new SqlParameter("@fromdate", SqlDbType.DateTime);
        param[0].Value = sdate;
        param[1] = new SqlParameter("@todate", SqlDbType.DateTime);
        param[1].Value = edate;
        param[2] = new SqlParameter("@company", SqlDbType.Int);
        param[2].Value = (dd_company.SelectedValue);
        param[3] = new SqlParameter("@empcode", SqlDbType.VarChar);
        param[3].Value = (txt_employee.Text);
        param[4] = new SqlParameter("@leavetype", SqlDbType.Int);
        param[4].Value = (ddlLeaveType.SelectedValue);

        string wherecond = string.Empty;
        string wherecondforComp = string.Empty;
        bool toexit = false;
        int count = 0;
        foreach (ListItem item in chk_leave_status.Items)
        {
            if (toexit)
                break;
            if (item.Selected)
            {
                switch (item.Value)
                {

                    case "0": wherecond = " 1=1";
                        wherecondforComp = " 1=1 ";

                        toexit = true;
                        break;
                    case "1":
                        if (count == 0)
                        {
                            wherecond += " ( leave_status=0 and approvel_status=0 ) ";
                            wherecondforComp += " ( leave_status=0 and approval_status=0 ) ";
                            count++;
                        }
                        else
                        {
                            wherecond += " or ( leave_status=0 and approvel_status=0 ) ";
                            wherecondforComp += " or ( leave_status=0 and approval_status=0 ) ";

                        }
                        break;
                    case "2":
                        if (count == 0)
                        {
                            wherecond += "  ( leave_status=2  ) or ( leave_status=2  )  ";
                            wherecondforComp += "  ( leave_status=2  ) or ( leave_status=2  )  ";
                            count++;
                        }
                        else
                        {
                            wherecond += " or ( leave_status=2 ) or ( leave_status=2  ) ";
                            wherecondforComp += " or ( leave_status=2  ) or ( leave_status=2 ) ";
                        }
                        break;
                    case "3":
                        if (count == 0)
                        {
                            wherecond += " ( leave_status=3  ) ";
                            wherecondforComp += " ( leave_status=3  ) ";
                            count++;
                        }
                        else
                        {

                            wherecond += " or ( leave_status=3  ) ";
                            wherecondforComp += " or ( leave_status=3  ) ";
                        }
                        break;
                    case "4":
                        if (count == 0)
                        {
                            wherecond += " ( ( leave_status=6  and isnull(todate,hdate)>=getdate() ) )";
                            wherecondforComp += "  ( leave_status=6  and todate>=getdate() ) ";
                            count++;
                        }
                        else
                        {
                            wherecond += " or ( leave_status=6 and isnull(todate,hdate)>=getdate() ) ";
                            wherecondforComp += " or ( leave_status=6  and todate>=getdate() ) ";
                        }
                        break;
                    case "6":
                        if (count == 0)
                        {
                            wherecond += "  ( leave_status=6 and isnull(todate,hdate)<getdate() ) ";
                            wherecondforComp += "  ( leave_status=6 and todate<getdate() ) ";
                            count++;
                        }
                        else
                        {
                            wherecond += " or ( leave_status=6  ) ";
                            wherecondforComp += " or ( leave_status=6 ) ";

                        }
                        break;


                }
            }
        }
        param[5] = new SqlParameter("@wherecond", SqlDbType.VarChar);
        param[5].Value = wherecond;
        param[6] = new SqlParameter("@wherecondforComp", SqlDbType.VarChar);
        param[6].Value = wherecondforComp;
        param[7] = new SqlParameter("@emp_status", SqlDbType.Bit);
        param[7].Value = chk_emp_status.Checked;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_leaveregister", param);

        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                empleavegrid.DataSource = ds.Tables[0];
                empleavegrid.DataBind();
                ViewState["dataforGrid"] = ds.Tables[0];
            }
            else
            {
                empleavegrid.DataSource = null;
                empleavegrid.DataBind();
            }
        }
        else
        {
            empleavegrid.DataSource = null;
            empleavegrid.DataBind();
        }
        //        strsql = @"select emp.empcode,coalesce(emp.emp_fname,'') + ' ' + coalesce(emp.emp_l_name,'') as ename,
        //        deg.designationname designation,cat.CategoryName category,
        //        sum(leave.no_of_days) nod
        //        from 
        //        tbl_intranet_employee_jobDetails emp  
        //        inner join 
        //        tbl_leave_apply_leave leave on emp.empcode=leave.empcode
        //        left outer join 
        //        tbl_login tl on emp.empcode=tl.empcode
        //        left outer join
        //        tbl_DesignationMaster deg on emp.degination_id=deg.id 
        //        left outer join 
        //        dbo.tbl_category_master cat on emp.category=cat.ID
        //        where ((leave.fromdate>='" + sdate + "' and leave.todate<='" + edate + "') or (leave.hdate>='" + sdate + "' and leave.hdate<='" + edate + "')) and leave.leave_status=" + drp_leavestatus.SelectedValue;

        //        if (dd_company.SelectedValue != "0")
        //            strsql = strsql + "and tl.companyid=" + dd_company.SelectedValue;

        //        if (txt_employee.Text != "")
        //            strsql = strsql + " and leave.empcode in ('" + txt_employee.Text.Trim() + "')";
        //        if (ddlLeaveType.SelectedValue.ToString() != "0")
        //            strsql = strsql + " and leave.leaveid in (" + ddlLeaveType.SelectedValue.ToString() + ")";

        //        strsql = strsql + @"group by emp.empcode,emp.empcode,coalesce(emp.emp_fname,'') + ' '  + coalesce(emp.emp_l_name,'')
        //        ,deg.designationname,cat.CategoryName";
        //        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, strsql);
        //        empleavegrid.DataSource = ds;
        //        empleavegrid.DataBind();
    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        reset();
    }

    protected void reset()
    {
        txt_edate.Text = "";
        txt_sdate.Text = "";
        //  drp_leavestatus.SelectedIndex = -1;
        dd_company.SelectedIndex = -1;
        //dd_dept.SelectedIndex = -1;
        txt_employee.Text = "";
    }

    //13-June-2018 done by Keerti Dwivedi
    protected void btn_view_Click(object sender, EventArgs e)
    {
        if (Calendar1.Visible)
        {
            Calendar1.Visible = false;
        }
        else
        {
            Calendar1.Visible = true;
        }
    }

    //protected void view()
    //{
       
    //}
    protected void lnkbtnlogout_Click(object sender, EventArgs e)
    {
        Session.Remove("empcode");
        Session.Remove("role");
        Session.Remove("login");
        Response.Redirect("../default.aspx");
    }
    protected void chk_temp_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_temp.Checked == true)
        {
            date.Visible = false;
            template.Visible = true;
            RequiredFieldValidator3.Enabled = false;
            RequiredFieldValidator11.Enabled = false;
        }
        else
        {
            date.Visible = true;
            template.Visible = false;
            RequiredFieldValidator3.Enabled = true;
            RequiredFieldValidator11.Enabled = true;
        }
    }
    protected void chk_leave_status_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (chk_leave_status.Items.FindByValue("0").Selected)
        {
            foreach (ListItem item in chk_leave_status.Items)
            {
                if (!item.Value.Equals("0"))
                {
                    item.Selected = false;
                }
            }
        }
    }
    protected void btn_toexcel_Click(object sender, EventArgs e)
    {

        if (ViewState["dataforGrid"] != null)
        {
            DataTable dt_result = (DataTable)ViewState["dataforGrid"];
            if (dt_result.Rows.Count > 0)
            {
                MailScript scriptObj = new MailScript();
                scriptObj.exportToExcelInCustomized(dt_result, empleavegrid.HeaderRow, "Leave register", Page.Form , "leaveregister");
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "nodata", "alert('No data to export');", true);
            return;
        }
    }
    protected void empleavegrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
            Label lbl_fromdate = (Label)e.Row.FindControl("fromdate");
            Label lbl_todate = (Label)e.Row.FindControl("todate");

            if (lbl_fromdate != null && lbl_todate != null)
            {
                lbl_fromdate.Text = Convert.ToDateTime(lbl_fromdate.Text).ToString("dd-MMM-yyyy");
                lbl_todate.Text = Convert.ToDateTime(lbl_todate.Text).ToString("dd-MMM-yyyy");
            }
            }
                catch(Exception ex)
            {
               throw new Exception(ex.Message);
                }
            }
    }
    protected void empleavegrid_RowDataBound1(object sender, GridViewRowEventArgs e)
    {

    }
    protected void rdnCalType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdnCalType.SelectedValue == "0")
        {
            leavedetails.Visible = true;
            empleavegrid.Visible = true;
            divleavesummary.Visible = false;
        }
        if (rdnCalType.SelectedValue == "1")
        {
            divleavesummary.Visible = true;
            leavedetails.Visible = false;
            empleavegrid.Visible = false;
        }
    }
    protected void btnsearchsummary_Click(object sender, EventArgs e)
    {

    }
    protected void btnexporttoexcel_Click(object sender, EventArgs e)
    {

    }
    protected void Gridleavedetailssummary_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void Gridleavedetailssummary_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
}
