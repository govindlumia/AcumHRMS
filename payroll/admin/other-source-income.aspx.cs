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
public partial class payroll_admin_other_source_income : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3" && Session["role"].ToString() != "4")
                Response.Redirect("~/Authenticate.aspx");
        }
        else Response.Redirect("~/notlogged.aspx");
        message.InnerHtml = "";
    }
    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam = new SqlParameter[1];

        sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txtothrsrcinc.Text.Trim().ToString();

        sqlstr = "INSERT INTO tbl_payroll_income_source_master(incomesource) values(@name)";
        int ins = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparam);

        //ddlperquistename.DataBind();
        othrsrcincgird.DataBind();
        txtothrsrcinc.Text = "";
        message.InnerHtml = "Other Source Income has been added successfully !";
    }

    protected void othrsrcincgird_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strname = ((TextBox)othrsrcincgird.Rows[e.RowIndex].Cells[0].FindControl("txtothrsrcincg")).Text;
        SqlDataSource1.UpdateParameters["name"].DefaultValue = strname;
        SqlDataSource1.Update();
    }
}