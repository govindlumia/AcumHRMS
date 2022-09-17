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

public partial class Leave_admin_create_leave_adjustment_rule : System.Web.UI.Page
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
            Session.Remove("aleave");
            populateadjustmentleave();
        }
    }
    protected void populateadjustmentleave()
    {
        DataSet ds;

        SqlParameter[] sqlparm;
        sqlparm = new SqlParameter[2];

        sqlparm[0] = new SqlParameter("@leaveid ", SqlDbType.Int, 4);
        sqlparm[0].Value = Request.QueryString["leaveid"];
        hiddenvalue.Value = Request.QueryString["leaveid"].ToString();

        sqlparm[1] = new SqlParameter("@policyid", SqlDbType.Int, 4);
        sqlparm[1].Value = Request.QueryString["policyid"];
        hidden_policy.Value = Request.QueryString["policyid"].ToString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_leave_update_adjustment_rule", sqlparm);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl_leave.Text = ds.Tables[0].Rows[0][0].ToString();
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            lbl_policy.Text = ds.Tables[1].Rows[0][0].ToString();
        }

            if (Session["aleave"] == null)
        {
            createatable();
        }
        DataRow dr;
        DataTable sdata;

        sdata = (DataTable)Session["aleave"];

       for (int i = 0; ds.Tables[2].Rows.Count > i; i++)
        {
            dr = sdata.NewRow();
            dr["aleaveid"] = (ds.Tables[2].Rows[i]["adjust_leave"] != null) ? Convert.ToInt32(ds.Tables[2].Rows[i]["adjust_leave"].ToString()) : 0;
            dr["aleavename"] = (ds.Tables[2].Rows[i]["leavetype"] != null) ? ds.Tables[2].Rows[i]["leavetype"].ToString() : "";
            sdata.Rows.Add(dr);
        }
        Session["aleave"] = sdata;
        bindadjustleave();
    }
    

    protected void drp_aleave_DataBound(object sender, EventArgs e)
    {
        drp_aleave.Items.Insert(0, new ListItem("Select leave", "100"));
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            dtable = (DataTable)Session["aleave"];
            if (dtable.Rows.Count > 0)
            {
                strsql = "delete from tbl_leave_adjust_rule where leaveid=" + hiddenvalue.Value + " and policyid=" + hidden_policy.Value;
                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, strsql);
                SqlParameter[] sqlparm;
                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    strsql = "insert into tbl_leave_adjust_rule(leaveid,policyid,adjust_leave,priority,createddate,createdby,modifiedby) values (@leaveid,@policyid,@adjust_leave,@priority,@createddate,@createdby,@modifiedby)";
         
                    sqlparm = new SqlParameter[7];
                    
                    sqlparm[0] = new SqlParameter("@leaveid ",SqlDbType.Int, 4);
                    sqlparm[0].Value = hiddenvalue.Value;

                    sqlparm[1] = new SqlParameter("@adjust_leave ", SqlDbType.Int, 4);
                    sqlparm[1].Value = dtable.Rows[i]["aleaveid"].ToString();

                    sqlparm[2] = new SqlParameter("@priority ", SqlDbType.Int, 4);
                    sqlparm[2].Value = i;

                    sqlparm[3] = new SqlParameter("@createddate ", SqlDbType.DateTime, 8);
                    sqlparm[3].Value = DateTime.Now;

                    sqlparm[4] = new SqlParameter("@createdby ", SqlDbType.VarChar, 100);
                    sqlparm[4].Value = Session["name"].ToString();

                    sqlparm[5] = new SqlParameter("@modifiedby ", SqlDbType.VarChar, 100);
                    sqlparm[5].Value = Session["name"].ToString();

                    sqlparm[6] = new SqlParameter("@policyid", SqlDbType.Int, 4);
                    sqlparm[6].Value = hidden_policy.Value;

                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, strsql, sqlparm);


                }
            }

            Response.Redirect("overviewrule.aspx?edit_adjust=true");  


            //message.InnerHtml = "Adjustment Rule Updated Successfully";
            //reset();
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Problem updating adjustment rule, try later";
        }

    }

    protected void createatable()
    {
        dtable = new DataTable();
        dtable.Columns.Add("aleaveid", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["aleaveid"] };
        dtable.Columns.Add("aleavename", typeof(string));
        Session["aleave"] = dtable;
    }

    protected void btm_add_Click(object sender, EventArgs e)
    {
        if (drp_aleave.SelectedValue.ToString() != lbl_leave.Text)
        {
         
            adjustleave();
        }
        else
            message.InnerHtml = "Adjusting leave cannot be added to adjusting leave queue";
    }

    protected void adjustleave()
    {
        DataRow dr;
        if (Session["aleave"] == null)
        {
            createatable();
        }
        dtable = (DataTable)Session["aleave"];

        DataRow drfind = dtable.Rows.Find(drp_aleave.SelectedValue.ToString());

        if (drp_aleave.SelectedItem.Text!=lbl_leave.Text)
        {
            if (drfind != null)
            {
                message.InnerHtml = "Leave already in adjustment queue";
            }
            else
            {
                dr = dtable.NewRow();
                dr["aleaveid"] = drp_aleave.SelectedValue.ToString();
                dr["aleavename"] = drp_aleave.SelectedItem.Text.ToString();
                dtable.Rows.Add(dr);
            }
        }
        else
        {
            message.InnerHtml = "Leave can not be adjusted to itself";
        }


        Session["aleave"] = dtable;

        bindadjustleave();
    }


    protected void bindadjustleave()
    {
        dtable = (DataTable)Session["aleave"];
        grid_aleave.DataSource = dtable;
        grid_aleave.DataBind();

    }
    protected void grid_aleave_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["aleave"];
        DataRow drfind = dtable.Rows.Find(Convert.ToString(grid_aleave.DataKeys[e.RowIndex].Value));
        if (drfind != null)
        {
            drfind.Delete();
            Session["aleave"] = dtable;
            bindadjustleave();
        }
    }
   
    protected void reset()
    {
        drp_aleave.SelectedIndex = -1;
        grid_aleave.DataSource = null;
        grid_aleave.DataBind();
    }

    protected void btnrst_Click(object sender, EventArgs e)
    {
        Response.Redirect("overviewrule.aspx");
        //reset();
    }
}
