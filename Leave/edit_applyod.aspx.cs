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
public partial class leave_edit_applyod : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
    string comment;

    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    public int i, ptr1, ptr2;
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
         if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            bind_empdetail();
            bind_od_detail();
        }
        
        
    }

    protected void bind_empdetail()
    {
        SqlParameter sqlparm = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm.Value = Request.QueryString["empcode"].ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm);
       
        lbl_branch.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
        lbl_emp_name.Text = ds.Tables[0].Rows[0]["name"].ToString();
        lbl_emp_code.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
        lbl_gender.Text = ds.Tables[0].Rows[0]["emp_gender"].ToString();
        lbl_status.Text = ds.Tables[0].Rows[0]["status"].ToString();
        lbl_dept.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
        lbl_designation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
        lbl_doj.Text = ds.Tables[0].Rows[0]["emp_doj"].ToString();
    }
        protected void bind_od_detail()
    {

//        sqlstr = @"select coalesce(tbl_intranet_employee_jobDetails.emp_fname,'') + ' ' + coalesce(tbl_intranet_employee_jobDetails.emp_m_name,'') + ' ' + coalesce(tbl_intranet_employee_jobDetails.emp_l_name,'') as name ,tbl_intranet_employee_jobDetails.empcode,tbl_intranet_employee_jobDetails.degination_id,tbl_intranet_designation.designationname,tbl_intranet_employee_jobDetails.Status,
//        tbl_intranet_employee_jobDetails.branch_id,tbl_intranet_branch_detail.branch_name,tbl_intranet_employee_jobDetails.dept_id,tbl_internate_departmentdetails.department_name,tbl_intranet_employee_jobDetails.emp_gender,convert(varchar(10),tbl_intranet_employee_jobDetails.emp_doj,101)emp_doj              
//        from tbl_intranet_employee_jobDetails 
//        INNER JOIN tbl_internate_departmentdetails on tbl_intranet_employee_jobDetails.dept_id=tbl_internate_departmentdetails.departmentid
//        INNER JOIN tbl_intranet_designation on tbl_intranet_employee_jobDetails.degination_id=tbl_intranet_designation.id
//        INNER JOIN tbl_intranet_branch_detail on tbl_intranet_employee_jobDetails.branch_id=tbl_intranet_branch_detail.Branch_id";







        string str = "select id,empcode,comment,convert(varchar,date,101) date,convert(varchar,fromtime,101)fromtime,reason,working_hour from tbl_leave_apply_od where id=" + Request.QueryString["id"] + ""; 
        //string str = "select * from tbl_leave_apply_od where id=" + Request.QueryString["id"]+ "";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text,str);
        int id =Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
        ViewState["id"] = id;
            txt_date.Text = ds.Tables[0].Rows[0]["date"].ToString();
        txt_ftime.Text = ds.Tables[0].Rows[0]["fromtime"].ToString();
        txt_reason.Text = ds.Tables[0].Rows[0]["reason"].ToString();
        lbl_comment.Text = ds.Tables[0].Rows[0]["comment"].ToString();
    }
    protected void btn_sbmit_Click(object sender, EventArgs e)
    {
        if (txt_comment.Text != "")
            comment = comment + "<h6><b>Comments added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "</h6>";
        else
            comment = "";
       // bl_navigation.update_od(Convert.ToInt32(ViewState["id"]),  Session["empcode"].ToString(), Convert.ToDateTime(txt_date.Text), Convert.ToDateTime(txt_ftime.Text), txt_reason.Text, 0, 0, Convert.ToString(dd_shift.SelectedValue), true, true, "anshul",comment.ToString(), ref i);
        bl_navigation.update_od(Convert.ToInt32(ViewState["id"]), Session["empcode"].ToString(), Convert.ToDateTime(txt_date.Text), Convert.ToDateTime(txt_ftime.Text), Convert.ToDecimal(HiddenField1.Value), txt_reason.Text, 0, 0, true, true, System.DateTime.Now, Session["name"].ToString(), comment.ToString(), ref i);
           
        
        if (i <= 0)
        {
            message.InnerHtml = "Problem updating OD, try again";            
        }
        else
        {
            message.InnerHtml = "OD updated successfully";            
        }
        Response.Redirect("view_applyod.aspx?id=" + ViewState["id"] + "&empcode=" + Session["empcode"].ToString() + "");
    }


    protected void btn_reset_Click(object sender, EventArgs e)
    {
        Response.Redirect("edit_applyod.aspx");
    }
    protected void txt_date_TextChanged(object sender, EventArgs e)
    {
        try
        {
            TimeSpan t = Convert.ToDateTime(txt_ftime.Text) - Convert.ToDateTime(txt_date.Text);
            HiddenField1.Value = Convert.ToString(t.Days + 1);
        }
        catch
        {
            HiddenField1.Value = Convert.ToString("1");
        }
    }
    protected void txt_ftime_TextChanged(object sender, EventArgs e)
    {
        try
        {
            TimeSpan t = Convert.ToDateTime(txt_ftime.Text) - Convert.ToDateTime(txt_date.Text);
            HiddenField1.Value = Convert.ToString(t.Days + 1);
        }
        catch
        {
            HiddenField1.Value = Convert.ToString("1");
        }
    }
}
