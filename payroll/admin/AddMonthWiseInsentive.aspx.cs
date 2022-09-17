using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;

public partial class payroll_admin_AddMonthWiseInsentive : System.Web.UI.Page
{
    DataSet dsIns = new DataSet();
    string empcode = string.Empty;
    string fyear = string.Empty;
    decimal amt = 0;

    SqlDataAdapter da = new SqlDataAdapter();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindInsentiveDetails();
        }
    }

    protected void BindInsentiveDetails()
    {

        if (Request.QueryString.HasKeys())
        {
            lblEmpcode.Text = Request.QueryString["empcode"].ToString();
            lblFyear.Text = Request.QueryString["fyear"].ToString();
            lblAmount.Text = Request.QueryString["amount"].ToString();
            string incid = Request.QueryString["incid"].ToString();
            string pid = Request.QueryString["pid"].ToString();

            empcode = Request.QueryString["empcode"].ToString();
            fyear = Request.QueryString["fyear"].ToString();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("usp_select_per_incentive_details", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                cmd.Parameters.AddWithValue("@fyear", fyear);
                cmd.Parameters.AddWithValue("@empcode", empcode);
                cmd.Parameters.AddWithValue("@insid", incid);
                cmd.Parameters.AddWithValue("@payheadid", pid);



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

    }
    protected void row(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox amount = (TextBox)e.Row.FindControl("txtAmount");
            Label status = (Label)e.Row.FindControl("lblstatus");
            CheckBox chk = (CheckBox)e.Row.FindControl("rowCheck");
            Label mon = (Label)e.Row.FindControl("lblMonth");
            Label payHeadId = (Label)e.Row.FindControl("lblPayheadId");
            Label id = (Label)e.Row.FindControl("id");//
            Image imgStatus = (Image)e.Row.FindControl("imgStatus");

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("usp_update_amount_by_sal_details", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id.Text.Trim());
                cmd.Parameters.AddWithValue("@empcode", Request.QueryString["empcode"].ToString());
                cmd.Parameters.AddWithValue("@fyear", Request.QueryString["fyear"].ToString());
                cmd.Parameters.AddWithValue("@month", mon.Text.Trim());
                cmd.Parameters.AddWithValue("@payheadid", payHeadId.Text.Trim());

                try
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        cmd.ExecuteNonQuery();


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

            if (status.Text.Equals("0"))
            {
                chk.Enabled = true;
                amount.Enabled = true;
                mon.Style["color"] = "#df5151";
                mon.Style["font-weight"] = "bold";
                imgStatus.ImageUrl = "~/images/action_delete.gif";

            }
            else
            {
                chk.Enabled = false;
                amount.Enabled = false;
                mon.Style["color"] = "#85bb19";
                mon.Style["font-weight"] = "bold";
                imgStatus.ImageUrl = "~/images/action_check.gif";
            }
        }
    }
    protected void btnsbmit_Click(object sender, EventArgs e)
    {

        for (int j = 0; j <= grdDetails.Rows.Count - 1; j++)
        {
            TextBox amountA = (TextBox)grdDetails.Rows[j].FindControl("txtAmount");
            //amt=Convert.ToDecimal(amountA.Text.Trim());
            amt = amt + Convert.ToDecimal(amountA.Text.Trim());
        }

        if (amt > Convert.ToDecimal(Request.QueryString["amount"].ToString()))
        {
            lblMessage.Text = "Sorry ! Entered amount not more then the incentive amount";
            lblMessage.Style["color"] = "red";
        }
        else
        {

            for (int i = 0; i <= grdDetails.Rows.Count - 1; i++)
            {
                CheckBox chk = (CheckBox)grdDetails.Rows[i].FindControl("rowCheck");

                Label id = (Label)grdDetails.Rows[i].FindControl("id");
                TextBox amount = (TextBox)grdDetails.Rows[i].FindControl("txtAmount");
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString()))
                {
                    SqlCommand cmd = new SqlCommand("usp_update_amount", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id.Text.Trim()));
                    cmd.Parameters.AddWithValue("@amount", Convert.ToDecimal(amount.Text.Trim()));
                    cmd.Parameters.AddWithValue("@chkStstus", chk.Checked.ToString());

                    try
                    {
                        conn.Open();
                        if (conn.State == ConnectionState.Open)
                        {
                            lblMessage.Text = cmd.ExecuteScalar().ToString();
                            lblMessage.Style["color"] = "green";


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
            BindInsentiveDetails();
        }


    }
    protected void Refresh(object sender, EventArgs e)
    {
        BindInsentiveDetails();
        // Response.Redirect("AddMonthWiseInsentive.aspx",false);
    }
}
