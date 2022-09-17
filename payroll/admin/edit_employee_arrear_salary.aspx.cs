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

public partial class payroll_admin_edit_employee_arrear_salary : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    DataTable dtable = new DataTable();
    Double ad;
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
            
            Session.Remove("arrear");
            bind_old_detail();
          
            bind_month();
            bind_year();
        }
    }

    //--------------------------------------- Bind old data --------------------------------------------//

    protected void bind_old_detail()
    {
        SqlParameter[] sqlparam = new SqlParameter[1];

        sqlparam[0] = new SqlParameter("@id", SqlDbType.Int);
        sqlparam[0].Value = Request.QueryString["id"].ToString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_viewarreardetail", sqlparam);
                
        lbl_empcode.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
        lbl_empname.Text = ds.Tables[0].Rows[0]["empname"].ToString();
        txt_arrear_ref.Text = ds.Tables[0].Rows[0]["arrear_ref_no"].ToString();
        txt_arrear_amount.Text = ds.Tables[0].Rows[0]["amount"].ToString();
        txt_detail.Text = ds.Tables[0].Rows[0]["detail"].ToString();

        HiddenField1.Value = ds.Tables[0].Rows[0]["arrear_ref_no"].ToString();

        if (ds.Tables[0].Rows.Count < 1)
            return;
        if (Session["arrear"] == null)
            createatable();

        DataRow dr;
        DataTable dtable;
        dtable = (DataTable)Session["arrear"];
        for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
        {
            dr = dtable.NewRow();
            dr["month"] = (ds.Tables[0].Rows[i]["month"] != null) ? ds.Tables[0].Rows[i]["month"].ToString() : "";
            dr["year"] = (ds.Tables[0].Rows[i]["year"] != null) ? ds.Tables[0].Rows[i]["year"].ToString() : "";
            dr["amount"] = (ds.Tables[0].Rows[i]["pamount"] != null) ? ds.Tables[0].Rows[i]["pamount"].ToString() : "";
            dtable.Rows.Add(dr);
        }
        Session["arrear"] = dtable;
        bindadjustarrear();
    }

    
    //***************************** Code to insert month in drop down **************************************//

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

    //***************************** Code to insert year in drop down **************************************//

    protected void bind_year()
    {
        dd_year.Items.Insert(0, new ListItem("Select Year", "0"));
        for (int i = 2009; i <= 2015; i++)
        {
            ListItem item = new ListItem();
            item.Text = new DateTime(i, 1, 1).ToString("yyyy");
            item.Value = i.ToString();
            dd_year.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
        }
        DateTime a = new DateTime(System.DateTime.Now.Year, 1, 1);
        dd_year.SelectedValue = a.Year.ToString();
    }


    //***************************** Code to create a data table **************************************//

    protected void createatable()
    {
        dtable = new DataTable();
        dtable.Columns.Add("month", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["month"] };
        dtable.Columns.Add("amount", typeof(string));
        dtable.Columns.Add("year", typeof(string));
        Session["arrear"] = dtable;
    }

    //***************************** Code to insert data in table **************************************//

    protected void adjustarrear()
    {
        DataRow dr;
        if (Session["arrear"] == null)
        {
            createatable();

        }
        dtable = (DataTable)Session["arrear"];

        DataRow drfind = dtable.Rows.Find(dd_month.SelectedItem.Text.ToString());
        if (drfind != null)
        {
            message.InnerHtml = "Same month can not be added again";
        }
        else
        {
            dr = dtable.NewRow();
            dr["month"] = dd_month.SelectedItem.Text.ToString();
            dr["year"] = dd_year.SelectedValue.ToString();
            dr["amount"] = txt_dispers.Text.ToString();
            dtable.Rows.Add(dr);
        }
        Session["arrear"] = dtable;
        bindadjustarrear();
    }

    //***************************** Code to bind data table data in grid **************************************//

    protected void bindadjustarrear()
    {
        dtable = (DataTable)Session["arrear"];
        grid_arrear.DataSource = dtable;
        grid_arrear.DataBind();
    }

    protected void btm_add_Click(object sender, EventArgs e)
    {
        if (validate_recover())
        {
            adjustarrear();
        }
    }

    protected void submit()
    {
        //if (validate_recover())
        //{
        if (Session["arrear"] == null)
        {
            message.InnerHtml = "Please add dispersement details";
            return;
        }
        else
        {
            bool s = validate_sum();
            if (!s)
            {
                message.InnerHtml = "Dispersement amount is not equal to total amount";
                return;
            }
            else
            {
                SqlParameter[] sqlparam = new SqlParameter[6];

                sqlparam[0] = new SqlParameter("@arrear_ref_no", SqlDbType.VarChar, 50);
                sqlparam[0].Value = txt_arrear_ref.Text.Trim().ToString();

                sqlparam[1] = new SqlParameter("@amount", SqlDbType.Decimal);
                sqlparam[1].Value = txt_arrear_amount.Text.ToString();
                //HiddenField1.Value = txt_arrear_amount.Text.ToString();

                sqlparam[2] = new SqlParameter("@detail", SqlDbType.VarChar, 500);
                sqlparam[2].Value = txt_detail.Text.ToString().Trim();

                sqlparam[3] = new SqlParameter("@modifieddate", SqlDbType.DateTime);
                sqlparam[3].Value = System.DateTime.Now;

                sqlparam[4] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
                sqlparam[4].Value = Session["name"].ToString();

                sqlparam[5] = new SqlParameter("@id", SqlDbType.Int);
                sqlparam[5].Value = Request.QueryString["id"];

                DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_editarrear", sqlparam);

                insert_disperse_amount();

            }
        }
        //}        

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (txt_arrear_ref.Text == HiddenField1.Value)
            submit();
        else
        {
            if (validate_name())
                submit();
        }    
    }

    //***************************** Code to insert data into table from data table  **************************************//


    protected void insert_disperse_amount()
    {
        try
        {
            string strsql1 = "DELETE FROM tbl_payroll_employee_arrear_salary_detail WHERE arrear_id=" + Request.QueryString["id"].ToString();
            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, strsql1);
  
            dtable = (DataTable)Session["arrear"];
            if (dtable.Rows.Count > 0)
            {               

                SqlParameter[] sqlparm;

                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    sqlstr = "insert into tbl_payroll_employee_arrear_salary_detail(arrear_id,month,year,amount,empcode) values (@arrear_id,@month,@year,@amount,@empcode)";
                    sqlparm = new SqlParameter[5];

                    sqlparm[0] = new SqlParameter("@arrear_id", SqlDbType.Int);
                    sqlparm[0].Value = Request.QueryString["id"];

                    sqlparm[1] = new SqlParameter("@month", SqlDbType.VarChar, 50);
                    sqlparm[1].Value = dtable.Rows[i]["month"].ToString();

                    sqlparm[2] = new SqlParameter("@year", SqlDbType.VarChar, 50);
                    sqlparm[2].Value = dtable.Rows[i]["year"].ToString();

                    sqlparm[3] = new SqlParameter("@amount", SqlDbType.Decimal);
                    sqlparm[3].Value = Convert.ToDecimal(dtable.Rows[i]["amount"].ToString());

                    sqlparm[4] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                    sqlparm[4].Value = lbl_empcode.Text.ToString();

                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparm);
                }

                Response.Redirect("view_employee_arrear_salary.aspx?message=Arrear updated successfully");                                
            }
        }
        catch (Exception ex)
        {
        }
    }

    //***************************** Code to match amount in main table and in disperse table  **************************************//

    protected bool validate_sum()
    {
        dtable = (DataTable)Session["arrear"];

        for (int d = 0; d < dtable.Rows.Count; d++)
        {
            ad = ad + Convert.ToDouble(dtable.Rows[d]["amount"].ToString());
        }
        if (ad != Convert.ToDouble(txt_arrear_amount.Text.ToString()))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    protected void btnreset_Click(object sender, EventArgs e)
    {
        Session.Remove("arrear");
        bind_old_detail();
        //clear();
    }

    //protected void clear()
    //{       
    //    txt_arrear_ref.Text = "";
    //    txt_arrear_amount.Text = "";
    //    txt_detail.Text = "";
    //    grid_arrear.DataSource = null;
    //    grid_arrear.DataBind();
    //    Session.Remove("arrear");
    //}
    protected void grid_arrear_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["arrear"];
        DataRow drfind = dtable.Rows.Find(Convert.ToString(grid_arrear.DataKeys[e.RowIndex].Value));
        if (drfind != null)
        {
            drfind.Delete();
            Session["arrear"] = dtable;
            bindadjustarrear();
        }
    }

    //------------------------------------- Validation for Recover From  -----------------------------------
    protected Boolean validate_recover()
    {
       // DateTime sd = Convert.ToDateTime(txt_arrear_amount.Text);
        DateTime rd = Convert.ToDateTime(dd_month.SelectedValue + "/1/" + dd_year.SelectedValue);
        if (findcycle(DateTime.Now) > rd)
        {
            message2 = "You can not apply for this arrear.Please change your selected month/year.";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message2.ToString() + "')</script>", false);
            return false;
        }
        return true;
    }

    protected DateTime findcycle(DateTime dt)
    {
        if (Convert.ToInt16(dt.Day) >= 26)
            dt = dt.AddMonths(1);
        dt = Convert.ToDateTime(dt.Month.ToString() + "/1/" + dt.Year.ToString());
        return dt;
    }

    //------------------------------------------- Check for Arrear Reference No. ---------------------------------------------//

    protected Boolean validate_name()
    {
        sqlstr = @"SELECT count(arrear_ref_no) FROM tbl_payroll_employee_arrear_salary WHERE arrear_ref_no='" + txt_arrear_ref.Text.Trim().ToString() + "'";
        int i = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);

        if (i > 0)
        {
            string message1 = "This Reference No. already exists.Please enter some other Reference No.";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            txt_arrear_ref.Text = "";
            return false;
        }
        return true;
    }
}
