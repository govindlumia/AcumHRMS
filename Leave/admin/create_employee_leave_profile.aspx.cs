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
    int c;
    DataTable dtable = new DataTable();
    DataView dview;
    Boolean add;
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        txt_employee.Attributes.Add("readonly", "readonly");
        txt_hr.Attributes.Add("readonly", "readonly");
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
        }
     
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
    

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        //if ((grid_customizerule.Rows.Count > 0) && (approvalgrid.Rows.Count > 0))
        if ((grid_customizerule.Rows.Count > 0))
        {
            employeehierarchy();
            employeeleaverule();
            reset();
        }
        else
        {
            message.InnerHtml = "Please click on SET POLICY to configure leave rule successfully or Check Approver!";
        }
    }

    protected void employeehierarchy()
    {
        SqlParameter sqlparam1 = new SqlParameter("@employeecode",txt_employee.Text);
        sqlstr = "select count(employeecode) from tbl_Employee_Hierarchy where employeecode='" + txt_employee.Text.Trim().ToString() + "' and hr='" + 1 + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparam1);

        if (ds.Tables[0].Rows.Count < 0)
        {
            message.InnerHtml = "Approval hierachy already created for " + txt_employee.Text;
        }
        
        else

            ////if (Session["hiearchy"] == null)
            ////    return;

            //dtable = (DataTable)Session["hiearchy"];
            //if (dtable.Rows.Count > 0)
            {
                SqlParameter[] sqlparm;
                sqlstr = "insert into tbl_Employee_Hierarchy(employeecode,approverid,approverpriority,hr,CreatedDate,CreatedBy,ModifiedBy) values (@employeecode,@approverid,@approverpriority,@hr,@createddate,@createdby,@modifiedby)";
                try
                {
                    sqlparm = new SqlParameter[7];

                    sqlparm[0] = new SqlParameter("@employeecode ", SqlDbType.VarChar, 100);
                    sqlparm[0].Value = txt_employee.Text.Trim();

                    sqlparm[1] = new SqlParameter("@approverid ", SqlDbType.VarChar, 100);
                    sqlparm[1].Value = txt_hr.Text.Trim();

                    sqlparm[2] = new SqlParameter("@approverpriority ", SqlDbType.Int, 4);
                    sqlparm[2].Value = Convert.ToInt32(hiddenlevel.Value) + 2;

                    sqlparm[3] = new SqlParameter("@hr", SqlDbType.Bit, 1);
                    sqlparm[3].Value = true;

                    sqlparm[4] = new SqlParameter("@createddate ", SqlDbType.DateTime, 8);
                    sqlparm[4].Value = DateTime.Now;

                    sqlparm[5] = new SqlParameter("@createdby ", SqlDbType.VarChar, 100);
                    sqlparm[5].Value = Session["name"].ToString();

                    sqlparm[6] = new SqlParameter("@modifiedby ", SqlDbType.VarChar, 100);
                    sqlparm[6].Value = Session["name"].ToString();

                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparm);
                    //for (int i = 0; i < dtable.Rows.Count; i++)
                    //{
                    //    sqlparm = new SqlParameter[8];

                    //    sqlparm[0] = new SqlParameter("@employeecode ", SqlDbType.VarChar, 100);
                    //    sqlparm[0].Value = txt_employee.Text.Trim();

                    //    sqlparm[1] = new SqlParameter("@approverid ", SqlDbType.VarChar, 100);
                    //    sqlparm[1].Value = dtable.Rows[i]["empcode"].ToString();

                    //    sqlparm[2] = new SqlParameter("@approvername ", SqlDbType.VarChar, 100);
                    //    sqlparm[2].Value = dtable.Rows[i]["name"].ToString();

                    //    sqlparm[3] = new SqlParameter("@approverpriority ", SqlDbType.Int, 4);
                    //    sqlparm[3].Value = dtable.Rows[i]["level"].ToString();

                    //    sqlparm[4] = new SqlParameter("@hr", SqlDbType.Bit, 1);
                    //    sqlparm[4].Value = false;

                    //    sqlparm[5] = new SqlParameter("@createddate ", SqlDbType.DateTime, 8);
                    //    sqlparm[5].Value = DateTime.Now;

                    //    sqlparm[6] = new SqlParameter("@createdby ", SqlDbType.VarChar, 100);
                    //    sqlparm[6].Value = Session["name"].ToString();

                    //    sqlparm[7] = new SqlParameter("@modifiedby ", SqlDbType.VarChar, 100);
                    //    sqlparm[7].Value = Session["name"].ToString();

                    //    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparm);
                    //}
                    message.InnerHtml = "Approval hierachy created for " + txt_employee.Text;
                }
                catch (Exception ex)
                {
                    message.InnerHtml = "Approval hierachy already created for " + txt_employee.Text;
                }
        }
    }
    protected void employeeleaverule()
    {
        SqlParameter sqlparm;
        SqlParameter[] sqlgridparm;
        try
        {
            for (int i = 0; i < grid_customizerule.Rows.Count; i++)
            {
                sqlparm = new SqlParameter();
                sqlgridparm = new SqlParameter[7];

                sqlgridparm[0] = new SqlParameter("policyid", SqlDbType.Int, 4);
                sqlgridparm[0].Value = ((Label)grid_customizerule.Rows[i].Cells[0].FindControl("l1")).Text;

                sqlgridparm[1] = new SqlParameter("leaveid", SqlDbType.Int, 4);
                sqlgridparm[1].Value = ((Label)grid_customizerule.Rows[i].Cells[1].FindControl("l2")).Text;

                sqlgridparm[2] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
                sqlgridparm[2].Value = txt_employee.Text.Trim();

                sqlgridparm[3] = new SqlParameter("@Entitled_days", SqlDbType.Decimal);
                sqlgridparm[3].Value = ((TextBox)grid_customizerule.Rows[i].Cells[4].FindControl("txt_entdays")).Text;

                sqlgridparm[4] = new SqlParameter("@createddate", SqlDbType.DateTime, 4);
                sqlgridparm[4].Value = DateTime.Now;

                sqlgridparm[5] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
                sqlgridparm[5].Value = Session["name"].ToString();

                sqlgridparm[6] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
                sqlgridparm[6].Value = Session["name"].ToString();

            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_leave_create_customizerule", sqlgridparm);
            }

            sqlgridparm = new SqlParameter[7];

            sqlgridparm[0] = new SqlParameter("policyid", SqlDbType.Int, 4);
            sqlgridparm[0].Value = ((Label)grid_customizerule.Rows[0].Cells[0].FindControl("l1")).Text;

            sqlgridparm[1] = new SqlParameter("leaveid", SqlDbType.Int, 4);
            sqlgridparm[1].Value = 0;

            sqlgridparm[2] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
            sqlgridparm[2].Value = txt_employee.Text.Trim();

            sqlgridparm[3] = new SqlParameter("@Entitled_days", SqlDbType.Decimal);
            sqlgridparm[3].Value = 200.0;

            sqlgridparm[4] = new SqlParameter("@createddate", SqlDbType.DateTime, 4);
            sqlgridparm[4].Value = DateTime.Now;

            sqlgridparm[5] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
            sqlgridparm[5].Value = Session["name"].ToString();

            sqlgridparm[6] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
            sqlgridparm[6].Value = Session["name"].ToString();

            c = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_leave_create_customizerule", sqlgridparm);
            if (c > 0)
            {
                message.InnerHtml = " Leave rule configured sucessfully";
            }
            else
                message.InnerHtml = " Leave rule already configured for " + txt_employee.Text;
        }
        catch (Exception ex)
        {
            message.InnerHtml = " Leave rule already configured for " + txt_employee.Text;
        }
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        reset();
    }
    protected void reset()
    {
        txt_employee.Text = "";
        txt_hr.Text = "";
        //txt_approver.Text = "";
         Session.Remove("hiearchy");
        //approvalgrid.DataSource = null;
        drp_policy.SelectedIndex = -1;
        //approvalgrid.DataBind();
        grid_customizerule.DataSource = null;
        grid_customizerule.DataBind();
        hiddenlevel.Value = "1";
    }
    protected void btn_greset_Click(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        Session.Remove("hiearchy");
        //approvalgrid.DataSource = null;
        //approvalgrid.DataBind();
        hiddenlevel.Value = "1";
    }
    protected void btn_policy_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparm = new SqlParameter[3];
        sqlparm[0] = new SqlParameter("@policyid", SqlDbType.Int, 4);
        sqlparm[0].Value = drp_policy.SelectedValue;

        sqlparm[1] = new SqlParameter("empcode", SqlDbType.VarChar, 100);
        sqlparm[1].Value = txt_employee.Text;

        if(opt_prorata_yes.Checked)
        {
            sqlparm[2] = new SqlParameter("@isprorata", SqlDbType.Int, 4);
            sqlparm[2].Value = 1;
        }
        else
        {
            sqlparm[2] = new SqlParameter("@isprorata", SqlDbType.Int, 4);
            sqlparm[2].Value = 0;
        }

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_leave_prorata_leave", sqlparm);

        grid_customizerule.DataSource = ds;
        grid_customizerule.DataBind();
    }
    protected void drp_policy_DataBound(object sender, EventArgs e)
    {
        drp_policy.Items.Insert(0, new ListItem("Select Policy", "0"));
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        //if (txt_employee.Text != txt_approver.Text)
        //{
        //    insert_approver();
        //}
        //else
        //{
        //    sqlstr = "SELECT role from tbl_login where empcode='" + txt_approver.Text.Trim().ToString() + "'";
        //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text,sqlstr);
        //    if (ds.Tables[0].Rows[0]["role"].ToString() == "3")
        //    {
              //  insert_approver();
        //    }
        //    else
        //    {
        //        message.InnerHtml = "Employee himself cannot be added to approval hierarchy.";
        //    }
        //}
    }
}










