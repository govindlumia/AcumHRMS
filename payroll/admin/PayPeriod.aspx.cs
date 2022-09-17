using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using DataAccessLayer;
using System.Data;

public partial class payroll_admin_PayPeriod : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropDownData();
            GetPayPeriod();
        }
    }

    private void BindDropDownData()
    {
        drpFrom.Items.Clear();
        drpTo.Items.Clear();
        for (int i = 1; i <= 31; i++)
        {
            drpFrom.Items.Insert(i - 1, new ListItem(i.ToString(), i.ToString()));
            drpTo.Items.Insert(i - 1, new ListItem(i.ToString(), i.ToString()));
        }
    }

    private void GetPayPeriod()
    {
        String sqlstr = "Select * from PayPeriod";
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        {
            drpFrom.Items.FindByValue(ds.Tables[0].Rows[0][0].ToString()).Selected = true;
            drpTo.Items.FindByValue(ds.Tables[0].Rows[0][1].ToString()).Selected = true;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SqlParameter[] arrParam = new SqlParameter[2];
        arrParam[0] = new SqlParameter("@from", drpFrom.SelectedValue.ToString());
        arrParam[1] = new SqlParameter("@to", drpTo.SelectedValue.ToString());
        String sqlstr = "update PayPeriod set PeriodFrom=@from,PeriodTo=@to";
        try
        {
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr, arrParam);
            message.InnerHtml = "Pay period updated successfully.";
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Problem in updating Pay period";
        }
    }
}