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

public partial class admin_view_tmt_dutyroster : System.Web.UI.Page
{
    String sqlstr;
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    DataSet dsgetdate = new DataSet();
    DateTime Min_date, Max_date;
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";        

        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["manager"].ToString() == "0")
                //{
                    //if (Session["role"].ToString() != "1" && Session["role"].ToString() != "3")
                    //    Response.Redirect("~/Authenticate.aspx");
                //}
            }
            else
                Response.Redirect("~/notlogged.aspx");

            lnkrefresh.Visible = true;
            
            validate_emp();
        }
    }

    //-------------------------------------- Bind Employees under Admin-----------------------------------

    protected void bindempdetail()
    {
        SqlParameter[] sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 150);
        sqlparam[0].Value = Session["empcode"].ToString();


        sqlparam[1] = new SqlParameter("@name", SqlDbType.VarChar, 150);
        sqlparam[1].Value = txt_employee.Text;

        sqlparam[2] = new SqlParameter("@desg", SqlDbType.Int);
        if (dd_designation.SelectedValue == "")
            sqlparam[2].Value = 0;
        else
            sqlparam[2].Value = dd_designation.SelectedValue;

        sqlparam[3] = new SqlParameter("@CATEGORY", SqlDbType.Int);
        if (dd_dpt.SelectedValue == "")
            sqlparam[3].Value = 0;
        else
            sqlparam[3].Value = dd_dpt.SelectedValue;

        sqlparam[4] = new SqlParameter("@status", SqlDbType.VarChar, 50);
        sqlparam[4].Value = "All";

        //sqlparam[5] = new SqlParameter("@BU", SqlDbType.Int);
        //sqlparam[5].Value = 0;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_fetch_emp_detail", sqlparam);
        Grid_Emp.DataSource = ds;
        Grid_Emp.DataBind();
    }

    //-------------------------------------- Bind Employees under Manager -----------------------------------
    public void bindemployee_mgr()
    {
        //sqlstr = @"select distinct h.employeecode as empcode,
        //           coalesce(m.emp_fname,'') + ' ' + coalesce(m.emp_l_name,'') as name,
        //            m.degination_id,
        //            tbl_DesignationMaster.designationname,
        //            m.category,tbl_category_master.CategoryName
        //            from tbl_Employee_Hierarchy h
        //            INNER JOIN tbl_intranet_employee_jobDetails m on m.empcode=h.employeecode
        //            INNER JOIN tbl_DesignationMaster ON m.degination_id=tbl_DesignationMaster.id
        //            INNER JOIN tbl_category_master ON m.category=tbl_category_master.ID
        //            where h.approverid='" + Session["empcode"].ToString() + "' and m.emp_status != '3'";
        sqlstr = @"select distinct h.employeecode as empcode,
                   coalesce(m.emp_fname,'') + ' ' + coalesce(m.emp_l_name,'') as name,
                    m.degination_id,
                    tbl_DesignationMaster.designationname,
                    m.category,tbl_category_master.CategoryName
                    from tbl_Employee_Hierarchy h
                    INNER JOIN tbl_intranet_employee_jobDetails m on m.empcode=h.employeecode
                    INNER JOIN tbl_DesignationMaster ON m.degination_id=tbl_DesignationMaster.id
                    INNER JOIN tbl_category_master ON m.category=tbl_category_master.ID
                    where h.approverid='" + Session["empcode"].ToString() + "'"; //and m.emp_status != '3'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        Grid_Emp.DataSource = ds;
        Grid_Emp.DataBind();
    }

    //------------------------------------- Check Admin/Manager ---------------------------------------------
    protected void validate_emp()
    {
        if ((Session["role"].ToString() == "1") || (Session["role"].ToString() == "3"))
        {
            bindempdetail();
            divempsearch.Visible = true;
        }
        else
        {
            bindemployee_mgr();
            divempsearch.Visible = false;
        }
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        validate_emp();
    }

    protected void dd_designation_DataBound(object sender, EventArgs e)
    {
        dd_designation.Items.Insert(0, new ListItem("------ All ------", "0"));
    }
    protected void dd_dpt_DataBound(object sender, EventArgs e)
    {
        dd_dpt.Items.Insert(0, new ListItem("----- All -----", "0"));
        validate_emp();
    } 

    protected void lnkrefresh_Click(object sender, EventArgs e)
    {
        Response.Redirect("view_dutyroster.aspx");
    }

    protected void Grid_Emp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Grid_Emp.PageIndex = e.NewPageIndex;
        validate_emp();
    }
   
    protected void lnkViewEmpDetails_Click(object sender, EventArgs e)
    {
        Min_date = Convert.ToDateTime(txt_start_date.Text);
        Max_date = Convert.ToDateTime(txt_end_date.Text);
        HiddenField1.Value = txt_start_date.Text;
        HiddenField2.Value = txt_end_date.Text;
        if (chk_date())
            Response.Redirect("emp_dutyroster.aspx?empCode=" + ViewState["empcode"].ToString() + "&Min_date=" + Min_date.ToString() + "&Max_date=" + Max_date.ToString() + " ");
        else
            message.InnerHtml = "To date must not be less than From date";
    }
   
    protected void btn_search_Click(object sender, EventArgs e)
    {
        validate_emp();
    }
    //protected void img_close_Click(object sender, ImageClickEventArgs e)
    //{
    //    divdetail.Visible = false;
    //}
  
    protected void Grid_Emp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            divdetail.Visible = true;

            ViewState["empcode"] = Convert.ToString(e.CommandArgument);
        }
    }
    //protected void txt_end_date_TextChanged(object sender, EventArgs e)
    //{
    //    if(!chk_date())
    //        return;
    //}
    //protected void txt_start_date_TextChanged(object sender, EventArgs e)
    //{
    //    if (!chk_date())
    //        return;
    //}
    protected Boolean chk_date()
    {
        DateTime sdate = Convert.ToDateTime(txt_start_date.Text);
       
        DateTime edate = Convert.ToDateTime(txt_end_date.Text);

        TimeSpan ts = edate - sdate;

        if (Convert.ToInt32(ts.TotalDays) < 0)
            return false;

        return true;
    }

    //protected void btn_back_Click(object sender, EventArgs e)
    //{
    //    if (Session["role"].ToString() == "2")
    //        Response.Redirect("leaveadmin.aspx");
    //    else
    //        Response.Redirect("../leave-user.aspx");
    //}
}

