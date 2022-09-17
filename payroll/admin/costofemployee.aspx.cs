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
using querystring;
using System.IO;

public partial class payroll_admin_paystructureempview : System.Web.UI.Page
{
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else Response.Redirect("~/notlogged.aspx");
           
        }
    }



    protected void dd_designation_DataBound(object sender, EventArgs e)
    {
        dd_designation.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        dd_branch.Items.Insert(0, new ListItem("All", "0"));
    }


    protected void btn_search_Click(object sender, EventArgs e)
    {
        string month=(ddl_month.SelectedValue.ToString()=="None")?"":ddl_month.SelectedValue.ToString();
        string report = (rdo_D.Checked) ? "1" : "0";
        string strPop = "<script language='javascript'>window.open('reports/CostEmployee.aspx?q=" + encode(dd_designation.SelectedValue.ToString(),dd_branch.SelectedValue.ToString(),month,ddl_year.SelectedValue.ToString()) + "&detail=" + report + "')</script>";

        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", strPop, false);

    }
    protected string encode(string branch, string dept, string month, string year)
    {
        query q = new query();
        string pairs = String.Format("branch={0}&dept={1}&month={2}&year={3}", branch, dept, month, year);
        string encoded;
        encoded = q.EncodePairs(pairs);
        return encoded;
    }
}
