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


public partial class payroll_admin_Add_Discrepancy : System.Web.UI.Page
{
    DataTable dtable = new DataTable();
    string strsql;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        txt_employee.Attributes.Add("readonly", "readonly");
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            ViewState["edit"] = "0";
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3" && Session["role"].ToString() != "4")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else Response.Redirect("~/notlogged.aspx");
            dd_branch.DataBind();
            dd_designation.DataBind();
            bindgrid();
            bind_month();
            

        }

    }
   protected void clear()
    {
        txt_employee.Text = "";
        txtamount.Text = "0.00";
        CheckBox1.Checked = false;
        btnsubmit.Text = "Submit";
        ViewState["edit"] = "0";
    }

    protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    protected void bindgrid()
    {
        SqlParameter[] sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 150);
        sqlparam[0].Value = txtempcode.Text.Trim().ToString();

        sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
        sqlparam[1].Value = dd_designation.SelectedValue;

        sqlparam[2] = new SqlParameter("@department", SqlDbType.Int);
        sqlparam[2].Value = dd_branch.SelectedValue;

        sqlparam[3] = new SqlParameter("@status", SqlDbType.VarChar, 50);
        sqlparam[3].Value = "All";

        sqlparam[4] = new SqlParameter("@branch", SqlDbType.Int);
        sqlparam[4].Value = 1;
        
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_Payroll_select_Discrepancy]", sqlparam);

        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                grid.DataSource = ds;
                grid.DataBind();
            }
            else
            {
                //grid.DataSource = null;
                //grid.DataBind();
            }
        }
        else
        {
            //grid.DataSource = null;
            //grid.DataBind();
        }
        }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam1;
        sqlparam1 = new SqlParameter[6];

        sqlparam1[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam1[0].Value = txt_employee.Text.Trim().ToString();

        sqlparam1[1] = new SqlParameter("@status", SqlDbType.Bit);
        sqlparam1[1].Value = CheckBox1.Checked;

        sqlparam1[2] = new SqlParameter("@Amount", SqlDbType.Decimal);
        sqlparam1[2].Value = Convert.ToDecimal(txtamount.Text);

        sqlparam1[3] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlparam1[3].Value = Session["name"].ToString();

        sqlparam1[4] = new SqlParameter("@month", SqlDbType.VarChar, 10);
        sqlparam1[4].Value = ddlmonth.SelectedItem.Text.Trim();

        sqlparam1[5] = new SqlParameter("@fyear", SqlDbType.VarChar, 10);
        sqlparam1[5].Value = dd_year.SelectedItem.Text.Trim();
        try
        {
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_employee_discrepancy_amount_Paid", sqlparam1);
            message.InnerHtml = "Records submited  successfully";
        }
        catch (Exception ex)
        {
            message.InnerHtml = "Problem occured,Try Latter";
        }
        finally
        {
            bindgrid();
            clear();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        clear();
    }

    protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        ViewState["edit"] = 1;
        txt_employee.Text = ((Label)grid.Rows[e.RowIndex].Cells[0].Controls[1]).Text;
       // txtamount.Text = ((Label)grid.Rows[e.RowIndex].Cells[3].Controls[1]).Text;
        if (((Label)grid.Rows[e.RowIndex].Cells[2].Controls[1]).Text == "Yes")
            CheckBox1.Checked = true;
        else
            CheckBox1.Checked = false;
      
        btnsubmit.Text = "Modify";
    }

    protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        strsql = "delete from tbl_leave_employee_OT_Mapping where empcode=" + grid.DataKeys[e.RowIndex].Value;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, strsql);
        bindgrid();
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
        bindgrid();
    }

    protected void update()
    {
        for (int i = 0; i < grid.Rows.Count; i++)
        {
            CheckBox chkstatusg = (CheckBox)grid.Rows[i].Cells[0].FindControl("chkstatusg");
            Label lblmonth =(Label)grid.Rows[i].Cells[0].FindControl("lblmonth");
            Label lblyear = (Label)grid.Rows[i].Cells[0].FindControl("lblfyear");

            if (chkstatusg != null)
            {
                Label lblempcodeg = (Label)grid.Rows[i].Cells[0].FindControl("lblempcodeg");
                TextBox txtamountg = (TextBox)grid.Rows[i].Cells[0].FindControl("txtamountg");


                SqlParameter[] sqlparam1;
                sqlparam1 = new SqlParameter[6];

                sqlparam1[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                sqlparam1[0].Value = lblempcodeg.Text.Trim().ToString();

                sqlparam1[1] = new SqlParameter("@status", SqlDbType.Bit);
                sqlparam1[1].Value = chkstatusg.Checked;

                sqlparam1[2] = new SqlParameter("@Amount", SqlDbType.Decimal);
                sqlparam1[2].Value = Convert.ToDecimal(txtamountg.Text);

                sqlparam1[3] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
                sqlparam1[3].Value = Session["name"].ToString();

                sqlparam1[4] = new SqlParameter("@month", SqlDbType.VarChar, 10);
                sqlparam1[4].Value = lblmonth.Text.Trim();

                sqlparam1[5] = new SqlParameter("@fyear", SqlDbType.VarChar, 10);
                sqlparam1[5].Value = lblyear.Text.Trim();

               
                try
                {
                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_employee_discrepancy_amount_Paid", sqlparam1);
                }
                catch (Exception ex)
                {
                    message.InnerHtml = "Problem occured,Try Latter";
                }
                finally
                {

                }
            }
        }
        bindgrid();
        clear();
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        update();
    }

    protected void btnupdate1_Click(object sender, EventArgs e)
    {
        update();
        message.InnerHtml = "Record updated sucessfully";
    }
    protected void bind_month()
    {
        ddlmonth.Items.Insert(0, new ListItem("Select Month", "0"));
        for (int i = 1; i <= 12; i++)
        {
            ListItem item = new ListItem();
            item.Text = new DateTime(1900, i, 1).ToString("MMM");
            item.Value = i.ToString();
            ddlmonth.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
        }
        DateTime a = new DateTime(1900, System.DateTime.Now.Month, 1);
        ddlmonth.SelectedValue = a.Month.ToString();
    }

    protected void dd_year_DataBound(object sender, EventArgs e)
    {
        dd_year.Items.Insert(0, new ListItem("---Select Financial Year---", "0"));
        //btnOK.Visible = false;
    }

    //protected void dd_branch_DataBound(object sender, EventArgs e)
    //{
    //    dd_branch.Items.Insert(0, new ListItem("---Select Location---", "0"));
    //   // btnOK.Visible = false;
    //}
}