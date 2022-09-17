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
using System.Text;

public partial class payroll_admin_cost_center_master : System.Web.UI.Page
{
    string sqlstr, sqlstr1;
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else Response.Redirect("~/notlogged.aspx");

            bindgrade();
        }
    }
    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        int flag = 0;
        for (int i = 0; i < chkgrade.Items.Count; i++)
        {
            if (flag == 0)
            {
                if (chkgrade.Items[i].Selected == true)
                {
                    flag = 1;
                    break;
                }
            }
        }
        if (flag == 1)
        {
            SqlParameter[] sqlparam = new SqlParameter[5];

            sqlparam[0] = new SqlParameter("@cost_center_name", SqlDbType.VarChar, 50);
            sqlparam[0].Value = txt_name.Text.Trim().ToString();

            sqlparam[1] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
            sqlparam[1].Value = Session["name"].ToString();

            sqlparam[2] = new SqlParameter("@createddate", SqlDbType.DateTime);
            sqlparam[2].Value = System.DateTime.Now;

            string strBranchName = null;
            string strBrachId = null;

            for (int i = 0; i < chkgrade.Items.Count; i++)
            {
                if (chkgrade.Items[i].Selected == true)
                {
                    if (i == 0 || i != chkgrade.Items.Count - 1)
                    {
                        strBranchName = strBranchName + chkgrade.Items[i].Text + " ,";
                        strBrachId = strBrachId + chkgrade.Items[i].Value + ",";

                    }
                    else
                    {
                        strBranchName = strBranchName + chkgrade.Items[i].Text;
                        strBrachId = strBrachId + chkgrade.Items[i].Value;
                    }
                }
            }

            sqlparam[3] = new SqlParameter("@branchName", SqlDbType.VarChar, 100);
            sqlparam[3].Value = strBranchName.Trim().ToString();

            sqlparam[4] = new SqlParameter("@branchId", SqlDbType.VarChar);
            sqlparam[4].Value = (strBrachId);

            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_cost_center_insert]", sqlparam);

            message.InnerHtml = " Cost Center has been created successfully ! ";
            clear();
            ScriptManager.RegisterStartupScript(this, GetType(), "saved", "alert('Cost center created successfully');", true);
        }
        else
        {
            message.InnerHtml = " Please select Branch for creating Cost Center ";
        }
    }

    protected void clear()
    {
        txt_name.Text = "";
        foreach (ListItem item in chkgrade.Items)
        {
            item.Selected = false;
        }
    }

    protected void bindgrade()
    {
        sqlstr = "SELECT branch_id,branch_name FROM tbl_intranet_branch_detail";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);

        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row1 in ds.Tables[0].Rows)
            {
                string gradename = row1["branch_name"].ToString().Trim();
                chkgrade.Items.Add(new ListItem(Convert.ToString(gradename), row1["branch_id"].ToString(), true));
            }
        }
    }

    protected void lnkcheckall_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < chkgrade.Items.Count; i++)
        {
            chkgrade.Items[i].Selected = true;
        }
    }

    protected void lnkuncheckall_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < chkgrade.Items.Count; i++)
        {
            chkgrade.Items[i].Selected = false;
        }
    }
}
