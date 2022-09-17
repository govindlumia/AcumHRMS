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

public partial class Leave_admin_View_Attendance_Rule : System.Web.UI.Page
{
    DataTable dtable = new DataTable();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (Request.QueryString["empprofile"] != null)
        {
            message.InnerHtml = " There is no adjustment rule defined for this leave ";
        }
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

        PopulateadAttendanceRule();

    }
    protected void PopulateadAttendanceRule()
    {
        DataSet ds;
        SqlParameter[] sqlparm;
        sqlparm = new SqlParameter[1];

        sqlparm[0] = new SqlParameter("@policyid", SqlDbType.Int, 4);
        sqlparm[0].Value = Request.QueryString["policyid"].ToString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_leave_attendance_rule", sqlparm);
        
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl_policy.Text = ds.Tables[0].Rows[0]["policyname"].ToString();
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

            //dr = dtable.NewRow();
            dr["id"] = Convert.ToInt32(ds.Tables[1].Rows[i]["id"].ToString());
            dr["Policyid"] = (ds.Tables[1].Rows[i]["PolicyId"] != null) ? Convert.ToInt32(ds.Tables[1].Rows[i]["PolicyId"].ToString()) : 0;
            dr["Policyname"] = (ds.Tables[1].Rows[i]["Policyname"] != null) ? ds.Tables[1].Rows[i]["Policyname"].ToString() : "";
            dr["ComingType"] = ds.Tables[1].Rows[i]["ComingName"].ToString();
            dr["TimeInt"] =Convert.ToInt32(ds.Tables[1].Rows[i]["TimeInt"].ToString());
            dr["Repeat"] =Convert.ToInt32(ds.Tables[1].Rows[i]["Repeat"].ToString());
            dr["RepeatFrequency"] = Convert.ToInt32(ds.Tables[1].Rows[i]["RepeatFrequency"].ToString());
            dr["ActionId"] = Convert.ToInt32(ds.Tables[1].Rows[i]["ActionId"].ToString());
            dr["ActionType"] = ds.Tables[1].Rows[i]["ActionType"].ToString();
            sdata.Rows.Add(dr);
           
        }
        Session["attendance"] = sdata;
        bindadjustleave();
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

    protected void bindadjustleave()
    {
        dtable = (DataTable)Session["attendance"];
        grid_aleave.DataSource = dtable;
        grid_aleave.DataBind();

    }
}