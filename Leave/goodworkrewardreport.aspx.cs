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
public partial class leave_goodworkrewardreport : System.Web.UI.Page
{
    string strsql = "";
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
        }
    }
    //protected void LinkButton1_Click(object sender, EventArgs e)
    //{
    //    bindgrid();
    //}
    //protected void adjustgrid_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        e.Row.Attributes.Add("onmouseover", "this.className='hover-clr'");
    //        e.Row.Attributes.Add("onmouseout", "this.className='out-clr-1'");
    //    }
    //}
    //protected void adjustgrid_RowCreated(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
    //    {
    //        CheckBox chkBxSelect = (CheckBox)e.Row.Cells[0].FindControl("chkselect");
    //        CheckBox chkBxHeader = (CheckBox)this.adjustgrid.HeaderRow.FindControl("chkBxHeader");
    //        chkBxSelect.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chkBxHeader.ClientID);
    //    }
    //}
    //protected void btn_ok_Click(object sender, EventArgs e)
    //{

    //    string empcode = "";
    //    DataRow dr;
    //    //(TextBox)ShopCartGrid.Rows[e.RowIndex].Cells[4].Controls[1]).Text;
    //    CheckBox Tmark1;
    //    for (int j = 0; j <= adjustgrid.Rows.Count - 1; j++)
    //    {
    //        Tmark1 = (CheckBox)adjustgrid.Rows[j].Cells[0].FindControl("chkselect");
    //        if (Tmark1.Checked == true)
    //        {
    //            empcode = empcode + ((Label)adjustgrid.Rows[j].Cells[0].FindControl("l2")).Text.Trim() + ",";
    //        }
    //    }
    //    p3.Visible = false;
    //    if (empcode != "")
    //        txt_empcode.Text = empcode.Substring(0, empcode.Length - 1);
    //}

    protected void dd_dept_DataBound(object sender, EventArgs e)
    {
        dd_dept.Items.Insert(0, new ListItem("All", "0"));
    }
    //protected void dd_branch_DataBound(object sender, EventArgs e)
    //{
    //    dd_branch.Items.Insert(0, new ListItem("All", "0"));
    //}

//    protected void bindgrid()
//    {
//        strsql = @"select empcode,coalesce(emp_fname,'') + ' ' + coalesce(emp_m_name,'') + ' ' + coalesce(emp_l_name,'') as ename from  tbl_intranet_employee_jobDetails
//        where (branch_id=@branch and dept_id=@dept) or (0=@dept)";
//        SqlParameter[] sqlparm = new SqlParameter[2];
//        //sqlparm[0] = new SqlParameter("@branch", SqlDbType.Int);
//        //sqlparm[0].Value = dd_branch.SelectedValue;

//        sqlparm[1] = new SqlParameter("@dept", SqlDbType.Int);
//        sqlparm[1].Value = dd_dept.SelectedValue;
//        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_fetchempcode", sqlparm);
//        adjustgrid.DataSource = ds;
//        adjustgrid.DataBind();
//    }
    //protected void img_close_Click(object sender, ImageClickEventArgs e)
    //{
    //    p3.Visible = false;
    //}
    //protected void btn_close_Click(object sender, EventArgs e)
    //{
    //    p3.Visible = false;
    //}
    protected void btn_search_Click(object sender, EventArgs e)
    {

        //CultureInfo ciCurr = CultureInfo.CurrentCulture;
        //int weekNum = ciCurr.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        //DateTime dt = new DateTime(2009, 1, 1).AddDays((weekNum - 1) * 7);
        //while (dt.DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
        //    dt = dt.AddDays(-1);
        //while (DateTime.Today.DayOfWeek != "Monday")
        //    dt = dt.AddDays(-1);
        //fday=
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
            sdate = Utility.dataformat(txt_sdate.Text.ToString());
            edate = Utility.dataformat(txt_edate.Text.ToString());
        }


        strsql = @"select othr.empcode,othr.hours,dept.department_name department,
                    coalesce(emp_fname,'')+' '+coalesce(emp_m_name,'')+' '+coalesce(emp_l_name,'') name
                    from(select ot.empcode,sum(noofhour) hours,dot.dep_id from tbl_leave_employee_overtime ot 
                    inner join tbl_leave_dep_overtime dot on ot.dep_ot_id=dot.id 
                    where 1=1 and ot.date between '" + sdate.ToShortDateString() + "' and '" + edate.ToShortDateString() + "'";

        if (dd_dept.SelectedValue != "0")
            strsql = strsql + "and dot.dep_id=" + dd_dept.SelectedValue;

        strsql=strsql + @"group by ot.empcode,dep_id) othr
                        inner join tbl_intranet_employee_jobDetails job on othr.empcode=job.empcode
                        inner join tbl_internate_departmentdetails dept on othr.dep_id=dept.departmentid";

        if (txt_empcode.Text != "")
            strsql = strsql + " WHERE (emp_fname like '%" + txt_empcode.Text.Replace("'", "''").Trim().ToString() + "%' or emp_m_name like '%" + txt_empcode.Text.Replace("'", "''").Trim().ToString() + "%' or emp_l_name like '%" + txt_empcode.Text.Replace("'", "''").Trim().ToString() + "%' or othr.empcode like '%" + txt_empcode.Text.Replace("'", "''").Trim().ToString() + "%' or emp_fname + ' ' + emp_m_name like '%" + txt_empcode.Text.Replace("'", "''").Trim().ToString() + "%' or emp_fname + ' ' + emp_l_name like '%" + txt_empcode.Text.Replace("'", "''").Trim().ToString() + "%' or emp_m_name + ' ' + emp_l_name like '%" + txt_empcode.Text.Replace("'", "''").Trim().ToString() + "%' or emp_fname + ' ' + emp_m_name + ' ' + emp_l_name like '%" + txt_empcode.Text.Replace("'", "''").Trim().ToString() + "%')";

        
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, strsql);
        empleavegrid.DataSource = ds;
        empleavegrid.DataBind();
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        reset();
    }

    protected void reset()
    {
        txt_edate.Text = "";
        txt_sdate.Text = "";
        //drp_leavestatus.SelectedIndex = -1;
        //dd_branch.SelectedIndex = -1;
        dd_dept.SelectedIndex = -1;
        txt_empcode.Text = "";
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
}
