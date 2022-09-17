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

public partial class Leave_admin_Edit_Attendance_Rule : System.Web.UI.Page
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
            PopulateadAttendanceRule();
        }

    }

    protected void PopulateadAttendanceRule()
    {
        DataSet ds;

        SqlParameter[] sqlparm;
        sqlparm = new SqlParameter[1];

        sqlparm[0] = new SqlParameter("@policyid", SqlDbType.Int, 4);
        sqlparm[0].Value = Request.QueryString["policyid"];
        hidden_policy.Value = Request.QueryString["policyid"].ToString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_leave_attendance_rule", sqlparm);

        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl_policy.Text = ds.Tables[0].Rows[0][0].ToString();
        }

        if (Session["attendance"] == null)
        {
            createatable();
        }
        DataRow dr;
        DataTable sdata;

        sdata = (DataTable)Session["attendance"];

        for (int i = 0; ds.Tables[1].Rows.Count > i; i++)
        {
            dr = sdata.NewRow();
            dr["id"] = Convert.ToInt32(ds.Tables[1].Rows[i]["id"].ToString());
            dr["Policyid"] = (ds.Tables[1].Rows[i]["PolicyId"] != null) ? Convert.ToInt32(ds.Tables[1].Rows[i]["PolicyId"].ToString()) : 0;
            dr["Policyname"] = (ds.Tables[1].Rows[i]["Policyname"] != null) ? ds.Tables[1].Rows[i]["Policyname"].ToString() : "";
            dr["ComingType"] = ds.Tables[1].Rows[i]["ComingName"].ToString();
            dr["TimeInt"] = Convert.ToInt32(ds.Tables[1].Rows[i]["TimeInt"].ToString());
            dr["Repeat"] = Convert.ToInt32(ds.Tables[1].Rows[i]["Repeat"].ToString());
            dr["RepeatFrequency"] = Convert.ToInt32(ds.Tables[1].Rows[i]["RepeatFrequency"].ToString());
            dr["ActionId"] = Convert.ToInt32(ds.Tables[1].Rows[i]["ActionId"].ToString());
            dr["ActionType"] = ds.Tables[1].Rows[i]["ActionType"].ToString();
            sdata.Rows.Add(dr);

        }
        Session["attendance"] = sdata;
        BindAttendanceRule();
    }


    protected void drp_aleave_DataBound(object sender, EventArgs e)
    {
        ddl_ActionType.Items.Insert(0, new ListItem("Select Action", "100"));
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            dtable = (DataTable)Session["attendance"];
            if (dtable.Rows.Count > 0)
            {
                strsql = "delete from tbl_Leave_Attendance_Master where policyid=" + hidden_policy.Value;
                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, strsql);
                SqlParameter[] sqlparm;
                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    strsql = "insert into tbl_Leave_Attendance_Master(policyid,ComingType,Time,Repeat,RepeatFrequency,ActionId,CreatedBy,ModifiedBy) values (@policyid,@ComingType,@Time,@Repeat,@RepeatFrequency,@ActionId,@createdby,@modifiedby)";
                    sqlparm = new SqlParameter[8];

                    sqlparm[0] = new SqlParameter("@policyid", SqlDbType.Int, 4);
                    sqlparm[0].Value = hidden_policy.Value;

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
            else
            {
                strsql = "delete from tbl_Leave_Attendance_Master where policyid=" + hidden_policy.Value;
                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, strsql);
            }

            Response.Redirect("OverViewAttendanceRule.aspx?edit_adjust=true");


            //message.InnerHtml = "Adjustment Rule Updated Successfully";
            //reset();
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Problem updating Attendance rule, try later";
        }

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
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["id"] };
        Session["attendance"] = dtable;
    }

    protected void btm_add_Click(object sender, EventArgs e)
    {
        if (lbl_policy.Text == lbl_policy.Text)
        {
            AttendanceRule();
        }
        else
            message.InnerHtml = "Rule cannot be added to grid view";
    }

    //protected void adjustleave()
    //{
    //    DataRow dr;
    //    if (Session["attendance"] == null)
    //    {
    //        createatable();
    //    }
    //    dtable = (DataTable)Session["attendance"];

    //    DataRow drfind = dtable.Rows.Find(drp_aleave.SelectedValue.ToString());

    //    if (drp_aleave.SelectedItem.Text!=lbl_leave.Text)
    //    {
    //        if (drfind != null)
    //        {
    //            message.InnerHtml = "Leave already in adjustment queue";
    //        }
    //        else
    //        {
    //            dr = dtable.NewRow();
    //            dr["aleaveid"] = drp_aleave.SelectedValue.ToString();
    //            dr["aleavename"] = drp_aleave.SelectedItem.Text.ToString();
    //            dtable.Rows.Add(dr);
    //        }
    //    }
    //    else
    //    {
    //        message.InnerHtml = "Leave can not be adjusted to itself";
    //    }


    //    Session["attendance"] = dtable;

    //    bindadjustleave();
    //}

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
                dr["Policyid"] = Request.QueryString["policyid"].ToString();
                dr["Policyname"] = lbl_policy.Text;
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
        dv.RowFilter = "Policyname='" + lbl_policy.Text + "' and TimeInt='" + txt_Timeint.Text + "'";
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
    protected void grid_aleave_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["attendance"];
        DataRow drfind = dtable.Select("id=" + grid_aleave.DataKeys[e.RowIndex].Value + "")[0];
        if (drfind != null)
        {
            drfind.Delete();
            Session["attendance"] = dtable;
            BindAttendanceRule();
        }
    }

    protected void reset()
    {
        ddl_ActionType.SelectedIndex = -1;
        grid_aleave.DataSource = null;
        grid_aleave.DataBind();
    }

    protected void btnrst_Click(object sender, EventArgs e)
    {
        Response.Redirect("OverViewAttendanceRule.aspx");
        //reset();
    }
}

