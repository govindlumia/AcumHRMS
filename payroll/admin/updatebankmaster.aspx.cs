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
public partial class payroll_admin_updatebankmaster : System.Web.UI.Page
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
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else Response.Redirect("~/notlogged.aspx");

            binddata();
        }
    }

    protected void binddata()
    {
        sqlstr = "SELECT * FROM tbl_payroll_bank WHERE branchcode='" + Request.QueryString["branchcode"].ToString() + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        txt_accno.Text = ds.Tables[0].Rows[0]["accountnumber"].ToString();
        txt_bankaddr.Text = ds.Tables[0].Rows[0]["address"].ToString();
        txt_bankcode.Text = ds.Tables[0].Rows[0]["branchcode"].ToString();
        txt_bankname.Text = ds.Tables[0].Rows[0]["bankname"].ToString();
        txtbsrcode.Text = ds.Tables[0].Rows[0]["bsrcode"].ToString();
        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["tds"].ToString()))
        {
            chktds.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["tds"]);
        }
        
        }


    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[7];

        sqlparam[0] = new SqlParameter("@accountnumber", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txt_accno.Text.Trim().ToString();

        sqlparam[1] = new SqlParameter("@address", SqlDbType.VarChar, 1000);
        sqlparam[1].Value = txt_bankaddr.Text.Trim().ToString();

        sqlparam[2] = new SqlParameter("@branchcode", SqlDbType.VarChar, 50);
        sqlparam[2].Value = txt_bankcode.Text.Trim().ToString();

        sqlparam[3] = new SqlParameter("@bankname", SqlDbType.VarChar, 100);
        sqlparam[3].Value = txt_bankname.Text.Trim().ToString();

        sqlparam[4] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
        sqlparam[4].Value = Session["name"].ToString().Trim();

        sqlparam[5] = new SqlParameter("@tds", SqlDbType.TinyInt);
        if (chktds.Checked)
        {
            sqlparam[5].Value = 1;
        }
        else
        { 
            sqlparam[5].Value = 0;
        }

        sqlparam[6] = new SqlParameter("@bsrcode", SqlDbType.VarChar, 25);
        sqlparam[6].Value = txtbsrcode.Text.Trim().ToString();

        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure,"sp_payroll_updatbankmaster",sqlparam);
       
        Response.Redirect("viewbankmaster.aspx?message=Bank record updated successfully");
    }

    protected void clear()
    {
        txt_bankname.Text = "";
        txt_bankcode.Text = "";
        txt_bankaddr.Text = "";
        txt_accno.Text = "";
        txtbsrcode.Text = "";
        chktds.Checked = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewbankmaster.aspx");
    }
    
}
