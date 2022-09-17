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

public partial class Leave_admin_create_leave_clubbing_rule : System.Web.UI.Page
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
        }
    }
    protected void drp_leave_DataBound(object sender, EventArgs e)
    {
        drp_leave.Items.Insert(0, new ListItem("Select leave", "0"));
    }
    protected void drp_aleave_DataBound(object sender, EventArgs e)
    {
        drp_aleave.Items.Insert(0, new ListItem("Select leave", "0"));
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

        if (drp_aleave.SelectedValue.ToString() != drp_leave.SelectedValue.ToString())
        {
            drp_leave.Enabled = false;
            clubaleave();
        }
        else
            message.InnerHtml = "Base leave cannot be added to clubbing leave queue";
    }
 

    protected void clubaleave()
    {
        DataRow dr;
        if (Session["aleave"] == null)
        {
            createatable();
        }
        dtable = (DataTable)Session["aleave"];

        DataRow drfind = dtable.Rows.Find(drp_aleave.SelectedValue.ToString());
        if (drfind != null)
        {
            message.InnerHtml = "Leave already exists in clubbing queue";
        }
        else
        {
            dr = dtable.NewRow();
            dr["aleaveid"] = drp_aleave.SelectedValue.ToString();
            dr["aleavename"] = drp_aleave.SelectedItem.Text.ToString();
            dtable.Rows.Add(dr);
        }


        Session["aleave"] = dtable;

        bindaleave();
    }


    protected void bindaleave()
    {
        dtable = (DataTable)Session["aleave"];
        grid_aleave.DataSource = dtable;
        grid_aleave.DataBind();

    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (!validate())
        {
            message.InnerHtml = "Leave clubbing rule already defined for " + drp_leave.SelectedItem.Text;
            reset();
            return;
        }

        try
        {
            dtable = (DataTable)Session["aleave"];
            if (dtable.Rows.Count > 0)
            {
                SqlParameter[] sqlparm;
                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    strsql = "insert into tbl_leave_clubbing(leaveid,cleaveid,createddate,createdby,modifiedby,policyid) values (@leaveid,@cleaveid,@createddate,@createdby,@modifiedby,@policyid)";
                    sqlparm = new SqlParameter[6];
                    sqlparm[0] = new SqlParameter("@leaveid ", SqlDbType.Int, 4);
                    sqlparm[0].Value = drp_leave.SelectedValue;

                    sqlparm[1] = new SqlParameter("@cleaveid ", SqlDbType.Int, 4);
                    sqlparm[1].Value = dtable.Rows[i]["aleaveid"].ToString();

                    sqlparm[2] = new SqlParameter("@createddate ", SqlDbType.DateTime, 8);
                    sqlparm[2].Value = DateTime.Now;

                    sqlparm[3] = new SqlParameter("@createdby ", SqlDbType.VarChar, 100);
                    sqlparm[3].Value = Session["name"].ToString();

                    sqlparm[4] = new SqlParameter("@modifiedby ", SqlDbType.VarChar, 100);
                    sqlparm[4].Value = Session["name"].ToString();

                    sqlparm[5] = new SqlParameter("@policyid", SqlDbType.Int, 4);
                    sqlparm[5].Value = dd_policy.SelectedValue;

                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, strsql, sqlparm);

                }
            }

           
            message.InnerHtml = "Clubbing rule added Successfully";
            reset();
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Problem in adding clubbing rule, try later";
        }
    }

    public Boolean validate()
    {
        int i;
        strsql = "select count(*) from tbl_leave_clubbing where leaveid=" + drp_leave.SelectedValue + " AND policyid=" + dd_policy.SelectedValue;
        i = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, strsql);
        if (i > 0)
            return false;
        else
            return true;

    }


    protected void btn_reset_Click(object sender, EventArgs e)
    {
        reset();
    }
    protected void grid_aleave_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["aleave"];
        DataRow drfind = dtable.Rows.Find(Convert.ToString(grid_aleave.DataKeys[e.RowIndex].Value));
        if (drfind != null)
        {
            drfind.Delete();
            Session["aleave"] = dtable;
            bindaleave();
        }
    }
 
    protected void reset()
    {
        drp_leave.Enabled = true;
        drp_leave.SelectedIndex = -1;
        drp_aleave.SelectedIndex = -1;
        dd_policy.SelectedIndex = -1;
        grid_aleave.DataSource = null;
        grid_aleave.DataBind();
         Session.Remove("aleave");
      
    }
    protected void dd_policy_DataBound(object sender, EventArgs e)
    {
        dd_policy.Items.Insert(0, new ListItem("Select Policy", "0"));
    }
}
