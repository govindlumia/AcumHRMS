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

public partial class Leave_admin_createemployeeprofile : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    public int i;
    DataTable dtable = new DataTable();
    DataView dview;
    Boolean add;
  
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            txt_hr.Attributes.Add("readonly", "readonly");
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");

            Session.Remove("hiearchy");
            fetchemphierarchy();
            bind_employeedata();
        }
        //if (opt_pro_no.Checked)
        //{
        //    txt_enforcement.Enabled = false;
        //    RequiredFieldValidator8.Enabled = false;
        //    RangeValidator2.Enabled = false;
        //    a1.Visible = false;
        //    a2.Visible = false;
        //    RequiredFieldValidator5.Enabled = false;

        //}
        //else
        //{
        //    txt_enforcement.Enabled = true;
        //    RequiredFieldValidator8.Enabled = true;
        //    RangeValidator2.Enabled = true;
        //    a1.Visible = true;
        //    a2.Visible = true;
        //    RequiredFieldValidator5.Enabled = true;
        //}       
    }

    protected void fetchemphierarchy()
    {
        string level;
        level = hiddenlevel.Value;

        lbl_empcode.Text = Request.QueryString["empcode"].ToString();
        SqlParameter sqlparm = new SqlParameter("@empid", Request.QueryString["empcode"].ToString());
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_leave_fetchrule", sqlparm);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txt_hr.Text = ds.Tables[0].Rows[0]["approverid"].ToString();
            hidden_hr.Value = ds.Tables[0].Rows[0]["name"].ToString();
        }
        if (ds.Tables[1].Rows.Count > 0)
        {


            approvalgrid.DataSource = ds.Tables[1];
            approvalgrid.DataBind();
            
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            create_approver_table();
            DataRow dr;
            DataTable dt;
            dt = (DataTable)Session["hiearchy"];
            for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
            {
                dr = dt.NewRow();
                dr["empcode"] = (ds.Tables[0].Rows[i]["approverid"] != null) ? ds.Tables[0].Rows[i]["approverid"].ToString() : "";
                dr["name"] = (ds.Tables[0].Rows[i]["name"] != null) ? ds.Tables[0].Rows[i]["name"].ToString() : "";
                dr["level"] = (ds.Tables[0].Rows[i]["approverpriority"] != null) ? Convert.ToInt32(ds.Tables[0].Rows[i]["approverpriority"].ToString()) : 0;
                dt.Rows.Add(dr);

            }
            Session["hiearchy"] = dt;
            bindapprovallist();
        }

    }

    protected void Grid_hr_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["hiearchy"];
        string approverid = Convert.ToString(Grid_hr.DataKeys[e.RowIndex].Value);
        DataRow drfind = dtable.Rows.Find(Convert.ToString(Grid_hr.DataKeys[e.RowIndex].Value));
        if (drfind != null)
        {
            drfind.Delete();
            string strsql = "Delete from tbl_Employee_Hierarchy where approverid=" + approverid + " and employeecode=" + lbl_empcode.Text + " and hr=1";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, strsql);
            Session["hiearchy"] = dtable;
            bindapprovallist();
        }
    }
    protected void create_approver_table()
    {
        dtable = new DataTable();
        dtable.Columns.Add("empcode", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["empcode"] };
        dtable.Columns.Add(new DataColumn("name", typeof(string)));
        dtable.Columns.Add(new DataColumn("level", typeof(int)));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["empcode"]};
        Session["hiearchy"] = dtable;
    }

    protected void createhiearchy()
    {
        if (Session["hiearchy"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["hiearchy"];
            dview = new DataView(dtable);
            dview.Sort = "level";
        }
    }

    protected void bindapprovallist()
    {
        dtable = (DataTable)Session["hiearchy"];
        dview = new DataView(dtable);
        dview.Sort = "level";
        Grid_hr.DataSource = dview;
        Grid_hr.DataBind();      
    }

    protected void insert_approver()
    {
        DataRow dr;
        string level;
        level = hiddenlevel.Value;
       
        if (Session["hiearchy"] == null)
        {
            create_approver_table();
            hiddenlevel.Value = "1";
        }
        //dtable = (DataTable)Session["hiearchy"];
        //object[] keyArrary = new object[2];
        //keyArrary[0] = txt_approver.Text;
        //keyArrary[1] = 0;
        dtable = (DataTable)Session["hiearchy"];
        DataRow drfind = dtable.Rows.Find(txt_hr.Text);
        if (drfind != null)
        {
            message.InnerHtml = "Approver already added";
        }
        else
        {
            dr = dtable.NewRow();

            if (dtable.Rows.Count > 0)
            {
                hiddenlevel.Value = Convert.ToString(Convert.ToInt32(level) + 2);
            }
            string strsql = @"Select coalesce(e.emp_fname,'') + ' ' + coalesce(e.emp_l_name,'') as name from tbl_intranet_employee_jobDetails e where e.empcode=" + txt_hr.Text + "";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, strsql);
            DataTable dt1 = (DataTable)ds.Tables[0];
            string Name = dt1.Rows[0]["name"].ToString();
            dr["name"] = Name;
            dr["empcode"] = txt_hr.Text;
      
            dr["level"] = hiddenlevel.Value;
            dtable.Rows.Add(dr);
        }
       // txt_approver.Text = "";
        Session["hiearchy"] = dtable;
        txt_hr.Text = "";
        bindapprovallist();
    }

    protected void btn_add_Click(object sender, EventArgs e)
    {
        //if (lbl_empcode.Text != txt_approver.Text)
        //{
        //    insert_approver();
        //}
        //else
        //{
        //    sqlstr = "SELECT role from tbl_login where empcode='" + txt_approver.Text.Trim().ToString() + "'";
        //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        //    if (ds.Tables[0].Rows[0]["role"].ToString() == "3")
        //    {
                insert_approver();
        //    }
        //    else
        //    {
        //        message.InnerHtml = "Employee himself cannot be added to approval hierarchy.";
        //    }
        //}
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
       // if ((approvalgrid.Rows.Count > 0) && (grid_customizerule.Rows.Count > 0))
         if (grid_customizerule.Rows.Count > 0)
        {
          // employeehierarchy();
            employeeleaverule();
            bindapproverhr();
            Response.Redirect("viewemployeeprofile.aspx?updated=true");
        }
        else
        {
            message.InnerHtml = "Please click on SET POLICY to configure leave rule successfully or Check Approver!";
        }
        //reset();
    }

    protected void employeehierarchy()
    {
        SqlParameter[] sqlparm;
        SqlParameter sqlparm1 = new SqlParameter("@employeecode", lbl_empcode.Text);
        sqlstr = "delete from tbl_leave_employee_hierarchy where employeecode=@employeecode";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparm1);


        //dtable=(DataTable)Session["hiearchy"];
        //if (dtable.Rows.Count>0)
        {
            sqlstr = @"INSERT INTO tbl_leave_employee_hierarchy (employeecode,approverid,approvername,approverpriority,hr,createddate,createdby,modifiedby)
                        VALUES(@employeecode,@approverid,@approvername,@approverpriority,@hr,@createddate,@createdby,@modifiedby)";
            try
            {
                sqlparm = new SqlParameter[8];

                sqlparm[0] = new SqlParameter("@employeecode", SqlDbType.VarChar, 100);
                sqlparm[0].Value = lbl_empcode.Text.Trim();

                sqlparm[1] = new SqlParameter("@approverid", SqlDbType.VarChar, 100);
                sqlparm[1].Value = txt_hr.Text.Trim();

                sqlparm[2] = new SqlParameter("@approvername", SqlDbType.VarChar, 100);
                sqlparm[2].Value = hidden_hr.Value;

                sqlparm[3] = new SqlParameter("@approverpriority", SqlDbType.Int, 4);
                sqlparm[3].Value = Convert.ToInt32(hiddenlevel.Value);

                sqlparm[4] = new SqlParameter("@hr", SqlDbType.Bit, 1);
                sqlparm[4].Value = true;

                sqlparm[5] = new SqlParameter("@createddate", SqlDbType.DateTime, 8);
                sqlparm[5].Value = DateTime.Now;

                sqlparm[6] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
                sqlparm[6].Value = Session["name"].ToString();

                sqlparm[7] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
                sqlparm[7].Value = Session["name"].ToString();

                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparm);


                //for (int i = 0; i < dtable.Rows.Count; i++)
                //{
                    
                    //sqlparm = new SqlParameter[8];

                    //sqlparm[0] = new SqlParameter("@employeecode ", SqlDbType.VarChar,100);
                    //sqlparm[0].Value = lbl_empcode.Text.Trim();

                    //sqlparm[1] = new SqlParameter("@approverid ", SqlDbType.VarChar,100);
                    //sqlparm[1].Value = dtable.Rows[i]["empcode"].ToString();

                    //sqlparm[2] = new SqlParameter("@approvername ", SqlDbType.VarChar,100);
                    //sqlparm[2].Value = dtable.Rows[i]["name"].ToString();

                    //sqlparm[3] = new SqlParameter("@approverpriority ", SqlDbType.Int,4);
                    //sqlparm[3].Value = dtable.Rows[i]["level"].ToString();

                    //sqlparm[4] = new SqlParameter("@hr", SqlDbType.Bit,1);
                    //sqlparm[4].Value = false;

                    //sqlparm[5] = new SqlParameter("@createddate ", SqlDbType.DateTime, 8);
                    //sqlparm[5].Value = DateTime.Now;

                    //sqlparm[6] = new SqlParameter("@createdby ", SqlDbType.VarChar, 100);
                    //sqlparm[6].Value = Session["name"].ToString();

                    //sqlparm[7] = new SqlParameter("@modifiedby ", SqlDbType.VarChar, 100);
                    //sqlparm[7].Value = Session["name"].ToString();

                    //DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparm);
                //}
                message.InnerHtml = "Employee hierarchy updated sucessfully";
                
            }
            catch(Exception ex)
            {
                message.InnerHtml = "Problem updating employee hierarchy" ;
            }
        }
    }

    protected void bind_employeedata()
    {
       SqlParameter sqlparam1 = new SqlParameter("@empcode", lbl_empcode.Text);
       sqlstr = @"select tbl_leave_employee_leave_master.leaveid,tbl_leave_createleave.leavetype,tbl_leave_employee_leave_master.policyid,tbl_leave_employee_leave_master.entitled_days,tbl_leave_employee_leave_master.empcode,tbl_leave_createleavepolicy.policyname
              from tbl_leave_employee_leave_master
              INNER JOIN tbl_leave_createleavepolicy ON tbl_leave_employee_leave_master.policyid=tbl_leave_createleavepolicy.policyid
              INNER JOIN tbl_leave_createleave ON tbl_leave_employee_leave_master.leaveid=tbl_leave_createleave.leaveid
              where empcode='" + Request.QueryString["empcode"].ToString() + "' and tbl_leave_employee_leave_master.leaveid !='" + 0 + "'";
       DataSet ds;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparam1);
       if (ds.Tables[0].Rows.Count > 0)
       {
           grid_customizerule.DataSource = ds;
           grid_customizerule.DataBind();
           drp_policy.SelectedValue = ds.Tables[0].Rows[0]["policyid"].ToString();
       }
       else
       {
           Response.Redirect("viewemployeeprofile.aspx?updated1=true");
       }       
    }

    protected void employeeleaverule()
    {
        SqlParameter[] sqlgridparm;

        //sqlgridparm = new SqlParameter[2];

        //sqlgridparm[0] = new SqlParameter("@empcode",SqlDbType.VarChar,100);
        //sqlgridparm[0].Value = lbl_empcode.Text.ToString();

        //sqlgridparm[1] = new SqlParameter("@leaveid", SqlDbType.Int, 4);
        //sqlgridparm[1].Value = 0;
        //sqlstr = "delete from tbl_leave_employee_leave_master where empcode=@empcode and leaveid !=@leaveid";
        //DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr,sqlgridparm);

        try
        {
            for (int i = 0; i < grid_customizerule.Rows.Count; i++)
            {               
                sqlgridparm = new SqlParameter[7];

                sqlgridparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
                sqlgridparm[0].Value = lbl_empcode.Text.Trim();

                sqlgridparm[1] = new SqlParameter("@leaveid", SqlDbType.Int, 4);
                sqlgridparm[1].Value = Convert.ToInt32(((Label)grid_customizerule.Rows[i].Cells[1].FindControl("l2")).Text);

                sqlgridparm[2] = new SqlParameter("@policyid", SqlDbType.Int, 4);
                sqlgridparm[2].Value = drp_policy.SelectedValue;

                sqlgridparm[3] = new SqlParameter("@Entitled_days", SqlDbType.Decimal);
                sqlgridparm[3].Value =Convert.ToDecimal(((TextBox)grid_customizerule.Rows[i].Cells[4].FindControl("txt_entdays")).Text);
                                        
                sqlgridparm[4] = new SqlParameter("@createddate", SqlDbType.DateTime, 4);
                sqlgridparm[4].Value = DateTime.Now;

                sqlgridparm[5] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
                sqlgridparm[5].Value = Session["name"].ToString();

                sqlgridparm[6] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
                sqlgridparm[6].Value = Session["name"].ToString();

                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_leave_update_customizerule", sqlgridparm);
            }
            message.InnerHtml = " Leave rule configured sucessfully for" +lbl_empcode.Text;
        }
        catch (Exception ex)
        {
            message.InnerHtml =" Leave rule already configured for " + lbl_empcode.Text;
        }
    }

    protected void bindapproverhr()
    {
        SqlParameter[] sqlgridparm;
        if (Session["hiearchy"] != null)
        {
            dtable = (DataTable)Session["hiearchy"];
            if (dtable.Rows.Count > 0)
            {
                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    sqlgridparm = new SqlParameter[5];

                    sqlgridparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
                    sqlgridparm[0].Value = lbl_empcode.Text.Trim();

                    sqlgridparm[1] = new SqlParameter("@approverid", SqlDbType.VarChar, 100);
                    sqlgridparm[1].Value = dtable.Rows[i]["empcode"].ToString();

                    sqlgridparm[2] = new SqlParameter("@approverpriority", SqlDbType.Int, 4);
                    sqlgridparm[2].Value = 3;

                    sqlgridparm[3] = new SqlParameter("@hr", SqlDbType.Int, 4);
                    sqlgridparm[3].Value = 1;

                    sqlgridparm[4] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
                    sqlgridparm[4].Value = Session["name"].ToString();

                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "InsertHrDetail", sqlgridparm);
                    
                }
            }
        }
    }
    
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        fetchemphierarchy();
        bind_employeedata();
        //reset();
    }
  
    protected void btn_greset_Click(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        Session.Remove("hiearchy");
        approvalgrid.DataSource = null;
        approvalgrid.DataBind();
    }

    //protected void btn_policy_Click(object sender, EventArgs e)
    //{
    //    SqlParameter[] sqlparm = new SqlParameter[3];
    //    sqlparm[0] = new SqlParameter("@policyid", SqlDbType.Int, 4);
    //    sqlparm[0].Value = drp_policy.SelectedValue;

    //    sqlparm[1] = new SqlParameter("empcode", SqlDbType.VarChar, 100);
    //    sqlparm[1].Value = lbl_empcode.Text;

    //    if (opt_prorata_yes.Checked)
    //    {
    //        sqlparm[2] = new SqlParameter("@isprorata", SqlDbType.Int, 4);
    //        sqlparm[2].Value = 1;
    //    }
    //    else
    //    {
    //        sqlparm[2] = new SqlParameter("@isprorata", SqlDbType.Int, 4);
    //        sqlparm[2].Value = 0;
    //    }
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_leave_prorata_leave", sqlparm);
    //    grid_customizerule.DataSource = ds;
    //    grid_customizerule.DataBind();
    //    drp_policy.SelectedItem.Text = ((Label)grid_customizerule.Rows[0].Cells[2].FindControl("l3")).Text;
    //}

    protected void drp_policy_DataBound(object sender, EventArgs e)
    {
        //drp_policy.Items.Insert(0, new ListItem("Select Policy", "0"));
    }
}










