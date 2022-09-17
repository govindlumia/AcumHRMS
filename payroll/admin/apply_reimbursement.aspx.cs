using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Data.SqlTypes;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
public partial class payroll_admin_apply_reimbursement : System.Web.UI.Page
{
    string filename;
    DataSet ds = new DataSet();
    string message2;
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
            txt_employee.Attributes.Add("readonly", "readonly");
            txt_sanct.Attributes.Add("readonly", "readonly");
            bind_month();
            bind_year();
            dd_reimburse.DataBind();
        }  
    }
    
    
    protected void bind_month()
    {
        dd_month.Items.Insert(0, new ListItem("Select Month", "0"));
        for (int i = 1; i <= 12; i++)
        {
            ListItem item = new ListItem();
            item.Text = new DateTime(1900, i, 1).ToString("MMM");
            item.Value = i.ToString();
            dd_month.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
        }
        DateTime a = new DateTime(1900, System.DateTime.Now.Month, 1);
        dd_month.SelectedValue = a.Month.ToString();
    }

    protected void bind_year()
    {
        dd_year.Items.Insert(0, new ListItem("Select Year", "0"));
        for (int i = 2016; i <= DateTime.Now.Year; i++)
        {
            ListItem item = new ListItem();
            item.Text = new DateTime(i, 1, 1).ToString("yyyy");
            item.Value = i.ToString();
            dd_year.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
        }     
        dd_year.SelectedValue = DateTime.Now.Year.ToString();
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
       
        
    }
    protected void btnsubmit_Click1(object sender, EventArgs e)
    {
        if (validate_recover() && validate_reimbursement())
        if (validate_reimbursement())
        {
            Response.Write(upload_attach.PostedFile.FileName);
            SqlParameter[] sqlparam = new SqlParameter[11];

            sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            sqlparam[0].Value = txt_employee.Text.Trim().ToString();

            sqlparam[1] = new SqlParameter("@reimbursement_id", SqlDbType.Int);
            sqlparam[1].Value = dd_reimburse.SelectedValue;

            sqlparam[2] = new SqlParameter("@reimbursement_ref", SqlDbType.VarChar, 50);
            sqlparam[2].Value = txt_remb_ref.Text.ToString();

            sqlparam[3] = new SqlParameter("@remb_amount", SqlDbType.Decimal);
            sqlparam[3].Value = txt_remb_amount.Text.ToString();

            sqlparam[4] = new SqlParameter("@sanc_date", SqlDbType.DateTime);
            sqlparam[4].Value = Convert.ToDateTime(txt_sanct.Text.ToString());

            sqlparam[5] = new SqlParameter("@remb_month", SqlDbType.VarChar, 50);
            sqlparam[5].Value = dd_month.SelectedItem.Text.ToString();

            sqlparam[6] = new SqlParameter("@remb_year", SqlDbType.VarChar, 50);
            sqlparam[6].Value = dd_year.SelectedValue;

            sqlparam[7] = new SqlParameter("@month_year", SqlDbType.VarChar, 50);
            sqlparam[7].Value = dd_month.SelectedItem.Text.ToString() + "/" + dd_year.SelectedItem.Text.ToString();

            sqlparam[8] = new SqlParameter("@file", SqlDbType.VarChar, 500);

            if (upload_attach.HasFile)
            {
                if (upload_attach.PostedFile.FileName != "")
                {                   
                    filename = System.IO.Path.GetFileName(upload_attach.PostedFile.FileName.ToString());
                    upload_attach.PostedFile.SaveAs(Server.MapPath(".") + "../../../upload/reimbursement/" + filename);
                }
            }
            else
                filename = "";
            sqlparam[8].Value = filename;



            sqlparam[9] = new SqlParameter("@created_date", SqlDbType.DateTime);
            sqlparam[9].Value = System.DateTime.Now;

            sqlparam[10] = new SqlParameter("@created_by", SqlDbType.VarChar, 100);
            sqlparam[10].Value = Session["name"].ToString();

           string result= DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_apply_reimburesment", sqlparam).ToString();
            message.InnerHtml = "Reimbursment applied successfully, reference number is "+result;
            clear();
        }
    }
    protected Boolean validate_reimbursement()
    {
        SqlParameter[] sqlparam = new SqlParameter[4];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txt_employee.Text.Trim().ToString();

        sqlparam[1] = new SqlParameter("@reimbursementid", SqlDbType.Int);
        sqlparam[1].Value = dd_reimburse.SelectedValue;

        sqlparam[2] = new SqlParameter("@amount", SqlDbType.Decimal);
        sqlparam[2].Value = Convert.ToDecimal(txt_remb_amount.Text.Trim());

        sqlparam[3] = new SqlParameter("@sanction_date", SqlDbType.DateTime);
        sqlparam[3].Value = Convert.ToDateTime(txt_sanct.Text.ToString());

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_validate_reimbursement", sqlparam);

        if (ds.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["flag"]) == 0)
            {
                return true;
            }
            else
            {
                message.InnerHtml = "You can not apply more reimbursement than assigned reimbursement";
                return false;
            }
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
          return true;
        }
        else
        {
          message.InnerHtml = "This employee does not belongs to grade applicable for this reimbursement";
          return false;
        }        
        return true;
    }

    protected void dd_reimburse_DataBound(object sender, EventArgs e)
    {
        dd_reimburse.Items.Insert(0, new ListItem("Select one", "0"));
    }

    protected void clear()
    {
     
        dd_reimburse.SelectedIndex = -1;
        dd_month.SelectedIndex = -1;
        dd_year.SelectedIndex = -1;
        txt_employee.Text = "";
     txt_remb_amount.Text = "";
   
        txt_remb_ref.Text = "Auto";
        txt_remb_ref.Enabled = false;
        txt_sanct.Text = "";
    }

    //------------------------------------- Validation for Recover From  -----------------------------------
    protected Boolean validate_recover()
    {
        DateTime sd = Convert.ToDateTime(txt_sanct.Text);
      //  DateTime rd = Convert.ToDateTime(dd_month.SelectedValue + "/1/" + dd_year.SelectedValue);
        DateTime rd = new DateTime(Convert.ToInt32(dd_year.SelectedValue), Convert.ToInt32(dd_month.SelectedValue), 1);
        
        if ((findcycle(sd) > rd) || (findcycle(DateTime.Now) > rd))
        {
            message2 = "You can not apply for this reimbursement. Either change your sanction date or reimburse month/year.";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message2.ToString() + "')</script>", false);
            return false;
        }
        return true;
    }

    protected DateTime findcycle(DateTime dt)
    {
        if (Convert.ToInt16(dt.Day) >= 26)
            dt = dt.AddMonths(1);
    //    dt = Convert.ToDateTime(dt.Month.ToString() + "/1/" + dt.Year.ToString());
        dt = new DateTime(dt.Year, dt.Month, 1);
        return dt;
    }        
    protected void btnreset_Click(object sender, EventArgs e)
    {
        clear();
        message.InnerHtml = "";
    }
}
