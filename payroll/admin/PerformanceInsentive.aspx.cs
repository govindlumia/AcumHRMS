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
using querystring;

public partial class payroll_admin_PerformanceInsentive : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
    string strPop;
    string empcode = string.Empty;
    string fyear = string.Empty;
    decimal amount = 0;
    int payheadid;
    DataSet dsIns = new DataSet();
    SqlDataAdapter da = new SqlDataAdapter();

    protected void Page_Load(object sender, EventArgs e)
    {
        txt_employee.Attributes.Add("readonly", "readonly");
        //btnsbmit.Attributes.Add("onClick", "return OpenCTC('" + txt_employee.ClientID + "','" + dd_year.ClientID + "');");

        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");

            bind_year();
            BindPayhead();
           // BindPerformanceInsentive();
           

        }

    }

    protected void BindPayhead()
    {
        sqlstr = "select id,name_inpayslip from tbl_payroll_payhead where id in(16,30,38)";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        ddlPayhead.DataTextField = "name_inpayslip";
        ddlPayhead.DataValueField = "id";
        ddlPayhead.DataSource = ds;
        ddlPayhead.DataBind();
    }

    

   

    

    protected void bind_year()
    {
        sqlstr = "SELECT financial_year year FROM tbl_payroll_tax_master  order by id desc";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_year.DataTextField = "year";
        dd_year.DataValueField = "year";
        dd_year.DataSource = ds;
        dd_year.DataBind();
    }

    

    protected string encodepayslip(string empcode, string month, string year)
    {
        //payslip.aspx?empcode=" + txt_employee.Text.ToString() + "&month=" + dd_month.SelectedItem.Text.ToString() + "&year=" + dd_year.SelectedItem.Text.ToString() + "
        query q = new query();
        string pairs = String.Format("empcode={0}&month={1}&year={2}", empcode.ToString(), month.ToString(), year.ToString());
        string encoded;
        encoded = q.EncodePairs(pairs);
        return "<script language='javascript'>window.open('payslip.aspx?q=" + encoded + "')</script>";
    }


    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        SaveInsentiveAmount();
    }

    protected void SaveInsentiveAmount()
    {
        empcode = txt_employee.Text.Trim();
        fyear = dd_year.SelectedItem.ToString();
        amount =Convert.ToDecimal(txtAmount.Text.Trim());
        payheadid = Convert.ToInt32(ddlPayhead.SelectedValue.ToString());

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString()))
        {
            SqlCommand cmd = new SqlCommand("usp_insert_emp_insentive_amount", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empcode", empcode);
            cmd.Parameters.AddWithValue("@payheadid", payheadid);
            cmd.Parameters.AddWithValue("@fyear", fyear);
            cmd.Parameters.AddWithValue("@amount",amount);

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    lblMessage.Text = cmd.ExecuteScalar().ToString();
                    if (lblMessage.Text.Trim().Equals("Insentive amount posted sucessfully"))
                    {
                        lblMessage.Style["color"] = "Green";
                        txt_employee.Text = string.Empty;
                        txtAmount.Text = string.Empty;
                    }
                    else
                    {
                        lblMessage.Style["color"] = "Red";
                    }

                }
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    throw new Exception(ex.Message);
                }
            }

        }
    }

    protected void BindPerformanceInsentive()
    {
        empcode = txt_employee.Text.Trim();
        fyear = dd_year.SelectedItem.ToString();
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString()))
        {
            SqlCommand cmd = new SqlCommand("usp_search_insentive_for_month", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            cmd.Parameters.AddWithValue("@fyear", fyear);
            cmd.Parameters.AddWithValue("@empcode", empcode);


            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                da.Fill(dsIns);
                if (dsIns.Tables[0].Rows.Count > 0)
                {
                    grdDetails.DataSource = dsIns;
                    grdDetails.DataBind();
                }
                else
                {
                    grdDetails.DataSource = dsIns;
                    grdDetails.DataBind();

                }
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindPerformanceInsentive();
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton addMonyhly = (LinkButton)e.Row.FindControl("lnkAddMonthly");

            Label emocd = (Label)e.Row.FindControl("lblEmpCode");
            Label insId = (Label)e.Row.FindControl("lblInsId");
            Label fyear = (Label)e.Row.FindControl("lblFyear");
            Label amount = (Label)e.Row.FindControl("lblAmount");
            Label payheadId = (Label)e.Row.FindControl("lblPayHeadId");
            if (grdDetails.EditIndex != e.Row.RowIndex)
            {
                addMonyhly.Attributes.Add("onClick", "return OpenPerformanceIns('" + emocd.Text.Trim() + "','" + fyear.Text.Trim() + "','" + amount.Text.Trim() + "','" + insId.Text.Trim() + "','" + payheadId.Text.Trim() + "');");
            }
        }
    }
    protected void grdDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdDetails.EditIndex = e.NewEditIndex;
        BindPerformanceInsentive();
    }
    protected void grdDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdDetails.EditIndex = -1;
        BindPerformanceInsentive();
    }
    protected void grdDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataKey KeyID = grdDetails.DataKeys[e.RowIndex];
        
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString()))
        {
            SqlCommand cmd = new SqlCommand("usp_delete_incentive_detatl", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(KeyID.Value));

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    lblMessage.Text = cmd.ExecuteScalar().ToString();
                    BindPerformanceInsentive();
                }
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    throw new Exception(ex.Message);
                }
            }

        }

    }
    protected void grdDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
         
        Label empcode = (Label)grdDetails.Rows[e.RowIndex].FindControl("lblEmpCode");
        Label insId = (Label)grdDetails.Rows[e.RowIndex].FindControl("lblInsId");
        Label fyear = (Label)grdDetails.Rows[e.RowIndex].FindControl("lblFyear");
        TextBox amount = (TextBox)grdDetails.Rows[e.RowIndex].FindControl("txtAmount");

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString()))
        {
            SqlCommand cmd = new SqlCommand("usp_update_emp_insentive_amount", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empcode", empcode.Text.Trim());
            cmd.Parameters.AddWithValue("@fyear", fyear.Text.Trim());
            cmd.Parameters.AddWithValue("@amount", Convert.ToDecimal(amount.Text.Trim()));
            cmd.Parameters.AddWithValue("@insentive_id", Convert.ToInt32(insId.Text.Trim()));
            

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    lblMessage.Text = cmd.ExecuteScalar().ToString();
                    if (lblMessage.Text.Trim().Equals("Incentive Updated Sucessfully"))
                    {
                        grdDetails.EditIndex = -1;
                        BindPerformanceInsentive();
                        lblMessage.Style["color"] = "Green";
                        txt_employee.Text = string.Empty;
                        txtAmount.Text = string.Empty;
                    }
                    else
                    {
                        lblMessage.Style["color"] = "Red";
                    }

                }
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    throw new Exception(ex.Message);
                }
            }

        }

    }
}
