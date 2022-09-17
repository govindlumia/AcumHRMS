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


public partial class Leave_admin_Create_leave_attendance_rule : System.Web.UI.Page
{
    DataTable dtable = new DataTable();
    string strsql;

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
            Session.Remove("attendance");
        }

    }

    protected void drp_aleave_DataBound(object sender, EventArgs e)
    {
        ddl_ActionType.Items.Insert(0, new ListItem("Select Action", "100"));
    }

    protected void createatable()
    {
        dtable = new DataTable();
        dtable.Columns.Add("id", typeof(string));
        dtable.Columns.Add("Policyid", typeof(string));
        dtable.Columns.Add("Policyname", typeof(string));
        dtable.Columns.Add("ComingType", typeof(string));
        dtable.Columns.Add("TimeInt", typeof(string));
        dtable.Columns.Add("Repeat", typeof(string));
        dtable.Columns.Add("RepeatFrequency", typeof(string));
        dtable.Columns.Add("ActionId", typeof(string));
        dtable.Columns.Add("ActionType", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["ComingType"], dtable.Columns["TimeInt"] };
        Session["attendance"] = dtable;
    }
    protected void dd_policy_DataBound(object sender, EventArgs e)
    {
        dd_policy.Items.Insert(0, new ListItem("Select Policy", "0"));
    }
    protected void AttendanceRule()
    {
        DataRow dr;
        if (Session["attendance"] == null)
        {
            createatable();
        }
        dtable = (DataTable)Session["attendance"];
        {
            if (!Check(dtable))
            {
                dr = dtable.NewRow();
                dr["id"] = Guid.NewGuid().ToString();
                dr["Policyid"] = dd_policy.SelectedValue.ToString();
                dr["Policyname"] = dd_policy.SelectedItem.Text.ToString();
                dr["ComingType"] = ddl_comingType.SelectedItem.Text.ToString();
                dr["TimeInt"] = txt_Timeint.Text;
                dr["Repeat"] = txt_repeat.Text;
                dr["RepeatFrequency"] = txt_repeatFrequency.Text;
                dr["ActionId"] = ddl_ActionType.SelectedValue.ToString();
                dr["ActionType"] = ddl_ActionType.SelectedItem.Text;
                dtable.Rows.Add(dr);
            }

        }
        Session["attendance"] = dtable;

        BindAttendanceRule();
    }

    protected bool Check(DataTable dt)
    {
        bool status = false;
        DataView dv = new DataView(dt);
        dv.RowFilter = "Policyid='" + dd_policy.SelectedValue.ToString() + "' and Policyname='" + dd_policy.SelectedItem.Text.ToString() + "' and ComingType='" + ddl_comingType.SelectedItem.Text.Trim() + "' and TimeInt="+txt_Timeint.Text+"";
        DataTable dtResult = dv.ToTable();

        if (dtResult.Rows.Count > 0)
        {
            status = true;
        }
        return status;
    }

    protected void BindAttendanceRule()
    {
        dtable = (DataTable)Session["attendance"];
        grid_aleave.DataSource = dtable;
        grid_aleave.DataBind();

    }

    protected void btm_add_Click(object sender, EventArgs e)
    {
        if (dd_policy.SelectedValue.ToString() == dd_policy.SelectedValue.ToString())
        {
            AttendanceRule();
           
        }
        else
            message.InnerHtml = "Rule cannot be added to grid view";
    }
        
    public Boolean validate()
    {
        int i;
        strsql = "select count(*) from tbl_Leave_Attendance_Master where ComingType=" + ddl_comingType.SelectedValue + " AND policyid=" + dd_policy.SelectedValue;
        i = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, strsql);
        if (i > 0)
            return false;
        else
            return true;

    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (!validate())
        {
            message.InnerHtml = "Attendance rule already defined for " + dd_policy.SelectedItem.Text;
            reset();
            return;
        }

        try
        {
            dtable = (DataTable)Session["attendance"];
            if (dtable.Rows.Count > 0)
            {
                SqlParameter[] sqlparm;

                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    strsql = "insert into tbl_Leave_Attendance_Master(policyid,ComingType,Time,Repeat,RepeatFrequency,ActionId,CreatedBy,ModifiedBy) values (@policyid,@ComingType,@Time,@Repeat,@RepeatFrequency,@ActionId,@createdby,@modifiedby)";
                    sqlparm = new SqlParameter[8];

                    sqlparm[0] = new SqlParameter("@policyid", SqlDbType.Int, 4);
                    sqlparm[0].Value = dd_policy.SelectedValue;

                    sqlparm[1] = new SqlParameter("@ComingType ", SqlDbType.Int, 4);
                    if (dtable.Rows[i]["ComingType"].ToString() == "Late Coming")
                    {
                        sqlparm[1].Value = 0;
                    }
                    else
                        sqlparm[1].Value = 1;

                    sqlparm[2] = new SqlParameter("@Time ", SqlDbType.Int, 4);
                    sqlparm[2].Value = dtable.Rows[i]["TimeInt"];

                    sqlparm[3] = new SqlParameter("@Repeat ", SqlDbType.Int, 4);
                    sqlparm[3].Value = dtable.Rows[i]["Repeat"];

                    sqlparm[4] = new SqlParameter("@RepeatFrequency ", SqlDbType.Int, 4);
                    sqlparm[4].Value = dtable.Rows[i]["RepeatFrequency"];


                    sqlparm[5] = new SqlParameter("@ActionId ", SqlDbType.Int, 4);
                    sqlparm[5].Value = dtable.Rows[i]["ActionId"];

                    sqlparm[6] = new SqlParameter("@createdby ", SqlDbType.VarChar, 100);
                    sqlparm[6].Value = Session["name"].ToString();

                    sqlparm[7] = new SqlParameter("@modifiedby ", SqlDbType.VarChar, 100);
                    sqlparm[7].Value = Session["name"].ToString();


                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, strsql, sqlparm);
                }
            }
            message.InnerHtml = "Attendance rule added successfully";
            reset();
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Problem adding Attendance rule, try later";
        }

    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        reset();

    }
    protected void reset()
    {
        ddl_comingType.Enabled = true;
        ddl_comingType.SelectedIndex = -1;
        ddl_comingType.SelectedIndex = -1;
        dd_policy.SelectedIndex = -1;
        grid_aleave.DataSource = null;
        grid_aleave.DataBind();
        Session.Remove("attendance");
    }
    protected void grid_aleave_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["attendance"];
        string[] arr = { grid_aleave.DataKeys[e.RowIndex]["ComingType"].ToString(),grid_aleave.DataKeys[e.RowIndex]["TimeInt"].ToString()};
        DataRow drfind = dtable.Rows.Find(arr);
        if (drfind != null)
        {
            drfind.Delete();
            Session["attendance"] = dtable;
            BindAttendanceRule();
        }

    }
}