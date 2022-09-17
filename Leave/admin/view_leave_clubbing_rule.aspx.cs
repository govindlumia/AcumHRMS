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
        {
            message.InnerHtml = "";
            if (Request.QueryString["view_adjust"] != null)
            {
                message.InnerHtml = " There is no clubbing rule defined for this leave ";
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

                Session.Remove("aleave");
                 populateclubbingrule();
            }
        }
    }

    protected void populateclubbingrule()
    {
        DataSet ds;

        SqlParameter[] sqlparm;
        sqlparm = new SqlParameter[2];
    

        sqlparm[0] = new SqlParameter("@leaveid ", SqlDbType.Int, 4);
        sqlparm[0].Value = Request.QueryString["leaveid"].ToString();
       

        sqlparm[1] = new SqlParameter("@policyid ", SqlDbType.Int, 4);
        sqlparm[1].Value = Request.QueryString["policyid"].ToString();
       

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_leave_update_clubbing_rule", sqlparm);

            

        if (ds.Tables[0].Rows.Count>0)

            lbl_leave.Text = ds.Tables[0].Rows[0][0].ToString();


        if (ds.Tables[1].Rows.Count > 0)

            lbl_policy.Text = ds.Tables[1].Rows[0][0].ToString();

       
        
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
            dr["aleaveid"] = (ds.Tables[2].Rows[i]["cleaveid"] != null) ? Convert.ToInt32(ds.Tables[2].Rows[i]["cleaveid"].ToString()) : 0;
            dr["aleavename"] = (ds.Tables[2].Rows[i]["leavetype"] != null) ? ds.Tables[2].Rows[i]["leavetype"].ToString() : "";
            sdata.Rows.Add(dr);
        }
        Session["aleave"] = sdata;
        bindaleave();

    }  
   
    protected void createatable()
    {
        dtable = new DataTable();
        dtable.Columns.Add("aleaveid", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["aleaveid"] };
        dtable.Columns.Add("aleavename", typeof(string));
        Session["aleave"] = dtable;
    }
 
    protected void bindaleave()
    {
        dtable = (DataTable)Session["aleave"];
        grid_aleave.DataSource = dtable;
        grid_aleave.DataBind();
    }  
}
