using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using System.IO;
public partial class payroll_admin_viewbankmaster : System.Web.UI.Page
{
    string sqlstr;
    SqlParameter[] sqlparm;
    DataSet ds=new DataSet();
    DataView dv = new DataView();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
        //    if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
        //        Response.Redirect("~/Authenticate.aspx");
        }
        else Response.Redirect("~/notlogged.aspx");
        message.InnerHtml="";
        if (!IsPostBack)
        {
            bind_PayheadName();
            //current_month();//22Sep2010
            bind_fyear();
        }
    }
    protected void bind_fyear()
    {
        sqlstr = "SELECT financial_year year FROM tbl_payroll_tax_master  order by id desc";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_year.DataTextField = "year";
        dd_year.DataValueField = "year";
        dd_year.DataSource = ds;
        dd_year.DataBind();
    }
    protected void current_month()
    {
        DateTime dt = DateTime.Now;
        DateTime da = new DateTime(dt.Year, dt.Month, 1);

        if (Convert.ToInt16(dt.Day) > da.AddMonths(1).AddDays(-1).Day)
            dt = dt.AddMonths(1);
        //if (Convert.ToInt16(dt.Day) >= 30)
        //    dt = dt.AddMonths(1);

        dd_month.Items.Add(new ListItem(dt.ToString("MMM"), dt.Month.ToString()));
        dd_month.SelectedValue = dt.Month.ToString();
    }
    //protected void bind_fyear()
    //{
    //    DateTime dt = DateTime.Now;

    //    if (Convert.ToInt16(dt.Day) >= 30)
    //        dt = dt.AddMonths(1);

    //    if (Convert.ToInt32(dd_month.SelectedValue) >= 4)
    //        lbl_fyear.Text = dt.Year + "-" + dt.AddYears(1).Year;
    //    else
    //        lbl_fyear.Text = dt.AddYears(-1).Year + "-" + dt.Year;
    //}
    protected void bind_PayheadName()
    {
        sqlstr = @"SELECT [id], [payhead_name] FROM [tbl_payroll_payhead] where type=3 and status=1";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        drpPayHead.DataTextField = "payhead_name";
        drpPayHead.DataValueField = "id";
        drpPayHead.DataSource = ds;
        drpPayHead.DataBind();
    }
    //protected void bind_year()
    //{
    //    sqlstr = "select distinct year from tbl_payroll_employee_salary";
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);
    //    dd_year.DataTextField = "year";
    //    dd_year.DataValueField = "year";
    //    dd_year.DataSource = ds;
    //    dd_year.DataBind();
    //}
    protected void btnsv_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (uploaddocument())
            {
                if (fupload.PostedFile.FileName.ToString() != "")
                {                    
                    try
                    {
                        string file = Server.MapPath(".") + "/upload/allowances.xls";
                        String strConn = @"Provider=Microsoft.ACE.Oledb.12.0;Data Source='" + Server.MapPath(".") + "\\upload\\allowances.xls';Extended Properties='Excel 12.0;HDR=YES;IMEX=1';";
                        OleDbConnection objconn = new OleDbConnection(strConn);
                        objconn.Open();
                        OleDbCommand objcmdselect = new OleDbCommand("SELECT * FROM [sheet1$]", objconn);
                        OleDbDataAdapter objadapter1 = new OleDbDataAdapter();
                        objadapter1.SelectCommand = objcmdselect;
                        DataSet dds = new DataSet();
                        objadapter1.Fill(dds, "Allowances");
                        objconn.Close();

                        for (int i = 0; i < dds.Tables[0].Rows.Count; i++)
                        {
                            sqlparm = new SqlParameter[7];
                            sqlparm[0] = new SqlParameter("@empcode", dds.Tables[0].Rows[i]["empcode"].ToString().Trim());
                            sqlparm[1] = new SqlParameter("@allowanceid", drpPayHead.SelectedValue);
                            sqlparm[2] = new SqlParameter("@allowancename", drpPayHead.SelectedItem.Text);
                            sqlparm[3] = new SqlParameter("@amount", dds.Tables[0].Rows[i]["amount"].ToString().Trim());
                            sqlparm[4] = new SqlParameter("@month", dd_month.SelectedItem.Text);
                            sqlparm[5] = new SqlParameter("@year", dd_year.SelectedItem.Text.Trim().ToString());
                            sqlparm[6] = new SqlParameter("@modifiedby", "Arun Agrawal");
                            //try
                            //{
                            if (sqlparm[0].Value.ToString().Trim() != "")
                            {
                                if (sqlparm[3].Value == "") sqlparm[3].Value = "0.00";
                                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_employee_importallowance", sqlparm);
                            }
                            else
                            {
                                SqlParameter[] sqlparm1 = new SqlParameter[3];
                                sqlparm1[0] = new SqlParameter("@allowanceid", drpPayHead.SelectedValue);
                                sqlparm1[1] = new SqlParameter("@month", dd_month.SelectedItem.Text);
                                sqlparm1[2] = new SqlParameter("@year", dd_year.SelectedItem.Text.Trim().ToString());
                                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, "delete from tbl_payroll_allowance_detail where year=@year and allowanceid=@allowanceid and month=@month", sqlparm1);
                                //Response.Write("<script>alert('Please check format of empcode in excel');</script>");
                                message.InnerHtml = "Please check format of empcode in excel";
                                return;
                            }
                        }
                        message.InnerHtml = drpPayHead.SelectedItem.Text + " data  uploaded successfully!";
                        
                        bindadjustment();
                    }
                    catch (Exception ex)
                    {
                        message.InnerHtml = "Please check excel name should be allowances.xls and sheet name be sheet1";
                    }
                }
            }
        }
    }
    protected void bindadjustment()
    {
        sqlparm = new SqlParameter[3];
        sqlparm[0] = new SqlParameter("@allowanceid", drpPayHead.SelectedValue);
        sqlparm[1] = new SqlParameter("@month", dd_month.SelectedItem.Text);
        sqlparm[2] = new SqlParameter("@year", dd_year.SelectedItem.Text.Trim().ToString());

        ds= DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_uploaded_detail", sqlparm);

        
        if (ViewState["sortExpr"] != null)
        {
            dv = new DataView(ds.Tables[0]);
            dv.Sort = (string)ViewState["sortExpr"];
        }
        else
            dv = ds.Tables[0].DefaultView;

        adjustgrid.DataSource = dv;
        adjustgrid.DataBind();
    }
    protected void adjustgrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        adjustgrid.EditIndex = -1;
        bindadjustment();
    }
    protected void adjustgrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        sqlparm =new SqlParameter[4];
        sqlparm[0]=new SqlParameter("@empcode",adjustgrid.DataKeys[e.RowIndex][0]);
        sqlparm[1]=new SqlParameter("@allowanceid",adjustgrid.DataKeys[e.RowIndex][1]);
        sqlparm[2]=new SqlParameter("@month",adjustgrid.DataKeys[e.RowIndex][2]);
        sqlparm[3]=new SqlParameter("@year",adjustgrid.DataKeys[e.RowIndex][3]);
        sqlstr = "delete from tbl_payroll_allowance_detail where empcode=@empcode and allowanceid=@allowanceid and month=@month and @year=@year";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text,sqlstr, sqlparm);
        bindadjustment();
    }
    protected void adjustgrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        adjustgrid.EditIndex = e.NewEditIndex;
        bindadjustment();
    }
    protected void adjustgrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        sqlparm = new SqlParameter[5];
        sqlparm[0] = new SqlParameter("@empcode", adjustgrid.DataKeys[e.RowIndex][0]);
        sqlparm[1] = new SqlParameter("@allowanceid", adjustgrid.DataKeys[e.RowIndex][1]);
        sqlparm[2] = new SqlParameter("@month", adjustgrid.DataKeys[e.RowIndex][2]);
        sqlparm[3] = new SqlParameter("@year", adjustgrid.DataKeys[e.RowIndex][3]);
        sqlparm[4] = new SqlParameter("@amount",((TextBox)adjustgrid.Rows[e.RowIndex].Cells[3].Controls[1]).Text);
        sqlstr = "update tbl_payroll_allowance_detail set amount=@amount where empcode=@empcode and allowanceid=@allowanceid and month=@month and @year=@year";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparm);
        adjustgrid.EditIndex = -1;
        bindadjustment();

    }
    protected void btn_view_Click(object sender, EventArgs e)
    {
        bindadjustment();
    }
    protected void adjustgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        adjustgrid.PageIndex = e.NewPageIndex;
        bindadjustment();
    }
    protected void adjustgrid_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["sortExpr"] = e.SortExpression;
        bindadjustment();
    }

    //protected void dd_year_DataBound(object sender, EventArgs e)
    //{
    //    dd_year.Items.Insert(0, new ListItem("---Select Financial Years---", "0"));
    //}

    protected void drpPayHead_DataBound(object sender, EventArgs e)
    {
        drpPayHead.Items.Insert(0,new ListItem("---Select Allowance---","0"));
    }

    protected bool uploaddocument()
    {
        string file_name, fn, ftype;
        if (fupload.PostedFile.FileName.ToString() != "")
        {
            fn = System.IO.Path.GetFileName(fupload.PostedFile.FileName.ToString());
            ftype = System.IO.Path.GetExtension(fn);
            switch (ftype)
            {
                case ".xls":
                    {
                        System.IO.File.Delete(fn);
                        file_name = Server.MapPath(".") + "\\upload\\allowances.xls";
                        fupload.PostedFile.SaveAs(file_name);
                        ViewState.Add("file_name", fn.ToString());
                        message.InnerHtml = "";
                        message.InnerHtml = "";
                        return true;
                        break;
                    }
                default:
                    {
                        message.InnerHtml = "";
                        message.InnerHtml = "Only Excel File can be uploaded";
                        return false;
                        break;
                    }
            }
            return true;
        }
        return true;
    }

    protected void dd_month_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_fyear();
    }
}



