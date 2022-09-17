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
using System.Data.SqlClient;
using DataAccessLayer;
public partial class payroll_admin_provident_esi_fund : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3" && Session["role"].ToString() != "4")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else Response.Redirect("~/notlogged.aspx");

            DropDownList1.DataBind();
            ddlcostcenter.DataBind();
            bindfy(DropDownList1.SelectedValue.ToString(),Convert.ToInt32(ddlcostcenter.SelectedValue));
        }
    }

    protected void  btnsbmit_Click(object sender, EventArgs e)
    {                        
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[8];


        sqlparam[0] = new SqlParameter("@modifieddate", SqlDbType.DateTime);
        sqlparam[0].Value = DateTime.Now;

        sqlparam[1] = new SqlParameter("@year", SqlDbType.VarChar);
        sqlparam[1].Value = DropDownList1.SelectedValue.ToString();

        sqlparam[2] = new SqlParameter("@quater1", SqlDbType.VarChar);
        sqlparam[2].Value = txt_no1.Text.ToString().Trim();

        sqlparam[3] = new SqlParameter("@quater2", SqlDbType.VarChar);
        sqlparam[3].Value = txt_no2.Text.ToString().Trim();

        sqlparam[4] = new SqlParameter("@quater3", SqlDbType.VarChar);
        sqlparam[4].Value = txt_no3.Text.ToString().Trim();

        sqlparam[5] = new SqlParameter("@quater4", SqlDbType.VarChar);
        sqlparam[5].Value = txt_no4.Text.ToString().Trim();

        sqlparam[6] = new SqlParameter("@modifiedby", SqlDbType.VarChar);
        sqlparam[6].Value = Session["name"].ToString();

        sqlparam[7] = new SqlParameter("@cost_center", SqlDbType.Int);
        sqlparam[7].Value = ddlcostcenter.SelectedValue;

        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_updateacknowlegement_no", sqlparam);
        message.InnerHtml = "Acknowlegement No. updated sucessfully";
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindfy(DropDownList1.SelectedValue.ToString(), Convert.ToInt32(ddlcostcenter.SelectedValue));
    }

    protected void bindfy(string fy,int cost_center)
    {
        SqlParameter[] sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@year", fy);
        sqlparm[1] = new SqlParameter("@cost_center", cost_center);
        string strsql = "Select quater1,quater2,quater3,quater4 from tbl_payroll_acknolegement where year=@year AND cost_center=@cost_center";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, strsql, sqlparm);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txt_no1.Text = Convert.ToString(ds.Tables[0].Rows[0]["quater1"]);
            txt_no2.Text = Convert.ToString(ds.Tables[0].Rows[0]["quater2"]);
            txt_no3.Text = Convert.ToString(ds.Tables[0].Rows[0]["quater3"]);
            txt_no4.Text = Convert.ToString(ds.Tables[0].Rows[0]["quater4"]);
        }
        else
        {
            txt_no1.Text = "";
            txt_no2.Text = "";
            txt_no3.Text = "";
            txt_no4.Text = "";
        }
    }

    protected void ddlcostcenter_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindfy(DropDownList1.SelectedValue.ToString(), Convert.ToInt32(ddlcostcenter.SelectedValue));
    }
}