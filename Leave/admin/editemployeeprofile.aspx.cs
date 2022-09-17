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
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            Session.Remove("hiearchy");
            fetchemphierarchy();
        }
    }

    protected void fetchemphierarchy()
    {
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
            create_approver_table();
            DataRow dr;
            DataTable sdata;

            sdata = (DataTable)Session["hiearchy"];
            for (int i = 0; ds.Tables[1].Rows.Count > i; i++)
            {
                dr = sdata.NewRow();
                dr["empcode"] = (ds.Tables[1].Rows[i]["approverid"] != null) ? ds.Tables[1].Rows[i]["approverid"].ToString() : "";
                dr["name"] = (ds.Tables[1].Rows[i]["name"] != null) ? ds.Tables[1].Rows[i]["name"].ToString() : "";
                dr["level"] = (ds.Tables[1].Rows[i]["approverpriority"] != null) ? Convert.ToInt32(ds.Tables[1].Rows[i]["approverpriority"].ToString()) : 0;
                
                sdata.Rows.Add(dr);
            }
            Session["hiearchy"] = sdata;
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
        approvalgrid.DataSource = dview;
        approvalgrid.DataBind();  
    }

    protected void insert_approver()
    {
        DataRow dr;
        string level;
        level = hiddenlevel.Value;
       
        if (Session["hiearchy"] == null)
        {
            create_approver_table();
        }
        dtable = (DataTable)Session["hiearchy"];

        DataRow drfind = dtable.Rows.Find(txt_approver.Text);
        if (drfind != null)
        {
            message.InnerHtml = "Approver already added";
        }
        else
        {
            dr = dtable.NewRow();

            if (dtable.Rows.Count > 0)
            {
                hiddenlevel.Value = Convert.ToString(Convert.ToInt32(level) + 1);
            }
            
            dr["name"] = hidd_name.Value;
            dr["empcode"] = txt_approver.Text;
      
            dr["level"] = hiddenlevel.Value;
            dtable.Rows.Add(dr);
        }
        txt_approver.Text = "";
        Session["hiearchy"] = dtable;

        bindapprovallist();
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
            insert_approver();
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        employeehierarchy();
        employeeleaverule();
        reset();
    }

    protected void employeehierarchy()
    {
        SqlParameter[] sqlparm;
        SqlParameter sqlparm1 = new SqlParameter("@employeecode", lbl_empcode.Text);
        sqlstr = "delete from tbl_leave_employee_hierarchy where employeecode=@employeecode";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparm1);
        
        dtable=(DataTable)Session["hiearchy"];
        if (dtable.Rows.Count>0)
        {            
            sqlstr = "insert into tbl_leave_employee_hierarchy(employeecode,approverid,approvername,approverpriority,hr,createddate,createdby,modifiedby) values (@employeecode,@approverid,@approvername,@approverpriority,@hr,@createddate,@createdby,@modifiedby)";
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
                sqlparm[3].Value = Convert.ToInt32(hiddenlevel.Value) + 1;

                sqlparm[4] = new SqlParameter("@hr", SqlDbType.Bit, 1);
                sqlparm[4].Value = true;

                sqlparm[5] = new SqlParameter("@createddate", SqlDbType.DateTime, 8);
                sqlparm[5].Value = DateTime.Now;

                sqlparm[6] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
                sqlparm[6].Value = Session["name"].ToString();

                sqlparm[7] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
                sqlparm[7].Value = Session["name"].ToString();

                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparm);


                for (int i = 0; i < dtable.Rows.Count; i++)
                {                    
                    sqlparm = new SqlParameter[8];

                    sqlparm[0] = new SqlParameter("@employeecode ", SqlDbType.VarChar,100);
                    sqlparm[0].Value = lbl_empcode.Text.Trim();

                    sqlparm[1] = new SqlParameter("@approverid ", SqlDbType.VarChar,100);
                    sqlparm[1].Value = dtable.Rows[i]["empcode"].ToString();

                    sqlparm[2] = new SqlParameter("@approvername ", SqlDbType.VarChar,100);
                    sqlparm[2].Value = dtable.Rows[i]["name"].ToString();

                    sqlparm[3] = new SqlParameter("@approverpriority ", SqlDbType.Int,4);
                    sqlparm[3].Value = dtable.Rows[i]["level"].ToString();

                    sqlparm[4] = new SqlParameter("@hr", SqlDbType.Bit,1);
                    sqlparm[4].Value = false;

                    sqlparm[5] = new SqlParameter("@createddate ", SqlDbType.DateTime, 8);
                    sqlparm[5].Value = DateTime.Now;

                    sqlparm[6] = new SqlParameter("@createdby ", SqlDbType.VarChar, 100);
                    sqlparm[6].Value = Session["name"].ToString();

                    sqlparm[7] = new SqlParameter("@modifiedby ", SqlDbType.VarChar, 100);
                    sqlparm[7].Value = Session["name"].ToString();

                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparm);
                }
                message.InnerHtml = "Employee hierarchy updated successfully.";                
            }
            catch(Exception ex)
            {
                message.InnerHtml = "Problem updating employee hierarchy." ;
            }
        }
    }

    protected void employeeleaverule()
    {
        DataSet ds;
        SqlParameter[] sqlgridparm;

        SqlParameter sqlparm = new SqlParameter("@employeeid", lbl_empcode.Text);
        sqlstr = "delete from tbl_leave_employee_customizerule where employeeid=@employeeid";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparm);

        try
        {
            for (int i = 0; i < grid_customizerule.Rows.Count; i++)
            {
                sqlparm = new SqlParameter("@leaveid", grid_customizerule.DataKeys[i].Value);
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_leave_copy_defaultrule]", sqlparm);
                sqlgridparm = new SqlParameter[23];

                sqlgridparm[0] = new SqlParameter("@employeeid", SqlDbType.VarChar, 100);
                sqlgridparm[0].Value = lbl_empcode.Text.Trim();

                sqlgridparm[1] = new SqlParameter("@leaveid", SqlDbType.Int, 4);
                sqlgridparm[1].Value = grid_customizerule.DataKeys[i].Value;

                sqlgridparm[2] = new SqlParameter("@leavename", SqlDbType.VarChar, 100);
                sqlgridparm[2].Value = ((Label)grid_customizerule.Rows[i].Cells[0].FindControl("l2")).Text;

                sqlgridparm[3] = new SqlParameter("@entitled_days", SqlDbType.Int, 4);
                sqlgridparm[3].Value = ((DropDownList)grid_customizerule.Rows[i].Cells[1].FindControl("ddentitled")).SelectedValue;

                sqlgridparm[4] = new SqlParameter("@days_before_leaveapply", SqlDbType.Int, 4);
                sqlgridparm[4].Value = ((DropDownList)grid_customizerule.Rows[i].Cells[2].FindControl("ddbfrdays")).SelectedValue;

                sqlgridparm[5] = new SqlParameter("@minimum_no_days", SqlDbType.Int, 4);
                sqlgridparm[5].Value = ((DropDownList)grid_customizerule.Rows[i].Cells[3].FindControl("ddminimumdays")).SelectedValue;

                sqlgridparm[6] = new SqlParameter("@maximum_no_days", SqlDbType.Int, 4);
                sqlgridparm[6].Value = ((DropDownList)grid_customizerule.Rows[i].Cells[4].FindControl("ddmaximumdays")).SelectedValue;

                sqlgridparm[7] = new SqlParameter("@calculation_type", SqlDbType.VarChar, 20);
                sqlgridparm[7].Value = ds.Tables[0].Rows[0]["calculation_type"].ToString();

                sqlgridparm[8] = new SqlParameter("@document_required", SqlDbType.Bit, 1);
                sqlgridparm[8].Value = Convert.ToBoolean(ds.Tables[0].Rows[0]["document_required"]);

                sqlgridparm[9] = new SqlParameter("@backdate_leave_applicable", SqlDbType.Bit, 1);
                sqlgridparm[9].Value = (((DropDownList)grid_customizerule.Rows[i].Cells[5].FindControl("DropDownList1")).SelectedValue) == "0" ? false : true;

                sqlgridparm[10] = new SqlParameter("@backdate_howmany_days", SqlDbType.Int, 4);
                sqlgridparm[10].Value = ds.Tables[0].Rows[0]["backdate_howmany_days"].ToString();

                sqlgridparm[11] = new SqlParameter("@holidays_counted_asleave", SqlDbType.Bit, 1);
                sqlgridparm[11].Value = (bool)ds.Tables[0].Rows[0]["holidays_counted_asleave"];

                sqlgridparm[12] = new SqlParameter("@carryforward_applicable", SqlDbType.Bit, 1);
                sqlgridparm[12].Value = (bool)ds.Tables[0].Rows[0]["carryforward_applicable"];

                sqlgridparm[13] = new SqlParameter("@carryforward_maximum_days", SqlDbType.Int, 4);
                sqlgridparm[13].Value = ds.Tables[0].Rows[0]["carryforward_maximum_days"].ToString();

                sqlgridparm[14] = new SqlParameter("@encashment_applicable", SqlDbType.Bit, 1);
                sqlgridparm[14].Value = (bool)ds.Tables[0].Rows[0]["encashment_applicable"];

                sqlgridparm[15] = new SqlParameter("@encashment_percentage", SqlDbType.Decimal, 8);
                sqlgridparm[15].Value = ((TextBox)grid_customizerule.Rows[i].Cells[6].FindControl("txtper")).Text;

                sqlgridparm[16] = new SqlParameter("@extension_leave", SqlDbType.Bit, 1);
                sqlgridparm[16].Value = (bool)ds.Tables[0].Rows[0]["extension_leave"];

                sqlgridparm[17] = new SqlParameter("@ext_max_days", SqlDbType.Int, 4);
                sqlgridparm[17].Value = ((DropDownList)grid_customizerule.Rows[i].Cells[7].FindControl("ddmax")).SelectedValue;

                sqlgridparm[18] = new SqlParameter("@shortened_leave", SqlDbType.Bit, 1);
                sqlgridparm[18].Value = (bool)ds.Tables[0].Rows[0]["shortened_leave"];

                sqlgridparm[19] = new SqlParameter("@halfday_leave_applicable", SqlDbType.Bit, 1);
                sqlgridparm[19].Value = (bool)ds.Tables[0].Rows[0]["halfday_leave_applicable"];

                sqlgridparm[20] = new SqlParameter("@createddate", SqlDbType.DateTime, 4);
                sqlgridparm[20].Value = DateTime.Now;

                sqlgridparm[21] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
                sqlgridparm[21].Value = Session["name"].ToString();

                sqlgridparm[22] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
                sqlgridparm[22].Value = Session["name"].ToString();

                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_leave_create_customizerule", sqlgridparm);
            }
            message.InnerHtml = message.InnerHtml + "\n Leave Rule configured successfully.";
        }
        catch (Exception ex)
        {
            message.InnerHtml = message.InnerHtml + "\n Leave Rule already configured for " + lbl_empcode.Text;
        }        
    }
        
       //    cm.CommandText = "sp_leave_createdefaultrule";
       //    cm.Parameters.Add("@leaveid", SqlDbType.Int).Value = leaveid;
       //    cm.Parameters.Add("@", SqlDbType.VarChar, 100).Value = leavename;
       //    cm.Parameters.Add("@", SqlDbType.Int).Value = entitled_days;
       //    cm.Parameters.Add("@", SqlDbType.Int).Value = days_before_leaveapply;
       //    cm.Parameters.Add("@", SqlDbType.Int).Value = minimum_no_days;
       //    cm.Parameters.Add("@", SqlDbType.Int).Value = maximum_no_days;
       //    cm.Parameters.Add("@", SqlDbType.VarChar, 20).Value = calculation_type;
       //    cm.Parameters.Add("@", SqlDbType.Bit).Value = document_required;
       //    cm.Parameters.Add("@", SqlDbType.Bit).Value = backdate_leave_applicable;
       //    cm.Parameters.Add("@", SqlDbType.Int).Value = backdate_howmany_days;
       //    cm.Parameters.Add("@", SqlDbType.Bit).Value = holidays_counted_asleave;
       //    cm.Parameters.Add("@", SqlDbType.Bit).Value = carryforward_applicable;
       //    cm.Parameters.Add("@", SqlDbType.Int).Value = carryforward_maximum_days;
       //    cm.Parameters.Add("@", SqlDbType.Bit).Value = encashment_applicable;
       //    cm.Parameters.Add("@", SqlDbType.Decimal).Value = encashment_percentage;
       //    cm.Parameters.Add("@", SqlDbType.Bit).Value = extension_leave;
       //    cm.Parameters.Add("@", SqlDbType.Int).Value = ext_max_days;
       //    cm.Parameters.Add("@", SqlDbType.Bit).Value = shortened_leave;
       //    cm.Parameters.Add("@", SqlDbType.VarChar, 100).Value = createdby;
       //    cm.Parameters.Add("@", SqlDbType.VarChar, 100).Value = modifiedby;
       //    cm.Parameters.Add("@", SqlDbType.Bit).Value = halfday_leave_applicable;
       //    j = cm.ExecuteNonQuery();
    
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        reset();
    }

    protected void reset()
    {
        txt_hr.Text="";
        txt_approver.Text="";
        Session.Remove("hiearchy");
    }

    protected void btn_greset_Click(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        Session.Remove("hiearchy");
        approvalgrid.DataSource = null;
        approvalgrid.DataBind();
        //grid_customizerule.DataSource = SqlDataSource1;
        //grid_customizerule.DataBind();
    }
}










