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
using System.Text;
public partial class leave_admin_empdutyroster : System.Web.UI.Page
{

    string sqlstr, sqlstrBindDutyRoster, sqldeletedutyroster, empCode, sqlstrBindShift, strUpdate, sqlstrBrachCode;
    DataSet dsBindDutyRoster = new DataSet();
    DataSet ds = new DataSet();
    DataSet dssqlstrBrachCode = new DataSet();
    DataSet dsBindShift = new DataSet();
    int flag = 0, f = 0;
    int checkvalue = 0, chkcheck = 0 , BranchCode = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");

            binddutyrosteremployee();
            shiftBind();
        }
    }

    protected void binddutyrosteremployee()
    {
        sqlstrBindDutyRoster = @" select A.empcode AS EMPCODE, (CASE WHEN A.date='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), A.date, 101) END) AS DATE, A.weekdays AS DAYS, B.ShiftName AS SHIFT from tbl_leave_dutyroster as A inner join tbl_leave_shift as B on B.shiftid = A.empshiftcode where A.empcode='" + Request.QueryString["empCode"].ToString() + "' and A.date between '" + Request.QueryString["Min_date"].ToString() + "' and '" + Request.QueryString["Max_date"].ToString() + "' order by A.date";

        dsBindDutyRoster = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrBindDutyRoster);

        empdutyrosterdetails.DataSource = dsBindDutyRoster;

        empdutyrosterdetails.DataBind();

    }

    protected void lnkcheckAll_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow GridView in empdutyrosterdetails.Rows)
        {
            CheckBox Chkbox = (CheckBox)GridView.FindControl("Chkbox");

            if (!Chkbox.Checked)
            {
                Chkbox.Checked = true;
            }
        }

        if (btnedit.Text == "Update")
        {
            checkvisibility();
        }
    }

    
    protected void lnkcheckNone_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow GridView in empdutyrosterdetails.Rows)
        {
            CheckBox Chkbox = (CheckBox)GridView.FindControl("Chkbox");

            if (Chkbox.Checked)
            {
                Chkbox.Checked = false;
            }
        }

        nonCheckvisibility();

        if (chkcheck == 0)
        {

            btnedit.Text = "Edit";
            btnCancel.Visible = false;
            btnBack.Enabled = true;
            btndelete.Enabled = true;
            lnkcheckNone.Enabled = true;

        }



    }

    protected void btndelete_Click(object sender, EventArgs e)
    {
     int counter = 0;
     checkvalue = 0;

     foreach (GridViewRow GridView in empdutyrosterdetails.Rows)
        
      {
        CheckBox Chkbox = (CheckBox)GridView.FindControl("Chkbox");

         if (Chkbox.Checked)
            {
             checkvalue = 1;

             empCode = empdutyrosterdetails.Rows[counter].Cells[2].Text.ToString();

             sqldeletedutyroster = @" delete from dbo.tbl_leave_dutyroster where empcode = '" + empCode.ToString() + "' and date='" + Chkbox.Text + "' ";
        
             DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqldeletedutyroster);

             counter = counter + 1;
            }

            if (empCode != null)
            {
                checkvalue = 1;
                sqlstr = @" select * from dbo.tbl_leave_dutyroster where empcode = '" + empCode.ToString() + "'";

                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

                if (ds.Tables[0].Rows.Count < 1)
                {
                    flag = 1;
                }
                else
                {
                    flag = 0;
                }
            }
        }

        if (flag == 1)
        {
            Response.Redirect("view-duty-roster.aspx");
        }
        else
        {
            binddutyrosteremployee();
        }


        if (checkvalue == 0)

        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('Please Select any record')</script>", false);
        }

    }

    protected void empdutyrosterdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empdutyrosterdetails.PageIndex = e.NewPageIndex;
        binddutyrosteremployee();
    }

    protected void empdutyrosterdetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        empdutyrosterdetails.EditIndex = e.NewEditIndex;
        binddutyrosteremployee();
    }

    protected void btnedit_Click(object sender, EventArgs e)
    {

        foreach (GridViewRow GridView in empdutyrosterdetails.Rows)
        {
            CheckBox Chkbox = (CheckBox)GridView.FindControl("Chkbox");

            if (Chkbox.Checked)
            {
                f = 1;
                break;
            }

        }

        if (f == 0)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('Please Select any record')</script>", false);
            f = 0;
        }
        else
        {

            if (btnedit.Text == "Edit")
            {
                btnedit.Text = "Update";
                btndelete.Enabled = false;
                
                btnBack.Enabled = false;
                btnCancel.Visible = true;

                checkvisibility();

                

            }
            else
            {
                btnedit.Text = "Edit";
                btndelete.Enabled = true;
                btnBack.Enabled = true;
                btnCancel.Visible = false;
                lnkcheckNone.Enabled = true;

                shiftUpdate();

                binddutyrosteremployee();

            }
        }
     }


    protected void Chkbox_CheckedChanged(object sender, EventArgs e)
    
    {

        nonCheckvisibility();

        if (btnedit.Text == "Update")
        
        {
            checkvisibility();
        }


        if (chkcheck == 0)
        {

            btnedit.Text = "Edit";
            btnCancel.Visible = false;
            btnBack.Enabled = true;
            btndelete.Enabled = true;
            lnkcheckNone.Enabled = true;

        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        binddutyrosteremployee();

        btnedit.Text = "Edit";
        btndelete.Enabled = true;
        lnkcheckNone.Enabled = true;
        btnBack.Enabled = true;
        btnCancel.Visible = false;

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("view-duty-roster.aspx");
    }


    protected void checkvisibility()

    {
        shiftBind();
        foreach (GridViewRow GridView in empdutyrosterdetails.Rows)
        {
            CheckBox Chkbox = (CheckBox)GridView.FindControl("Chkbox");
            DropDownList drpshift = (DropDownList)GridView.FindControl("drpShift");

            if (Chkbox.Checked)
            {
                drpshift.Visible = true;
            }
            else
            {
                drpshift.Visible = false;
            }
        }
    
    }


    protected void nonCheckvisibility()

    {

        foreach (GridViewRow GridView in empdutyrosterdetails.Rows)
        {
            CheckBox Chkbox = (CheckBox)GridView.FindControl("Chkbox");
            DropDownList drpshift = (DropDownList)GridView.FindControl("drpShift");

            if (Chkbox.Checked)
            {
                chkcheck = 1;
            }
            else
            {
                drpshift.Visible = false;
            }
        }
    
    }


    protected void shiftBind()
    {
        foreach (GridViewRow GridView in empdutyrosterdetails.Rows)
        {
            CheckBox Chkbox = (CheckBox)GridView.FindControl("Chkbox");
            DropDownList drpshift = (DropDownList)GridView.FindControl("drpShift");

                sqlstrBindShift = "";
                sqlstrBrachCode = "";
                BranchCode = 0;

                sqlstrBrachCode = @"select branch_id from dbo.tbl_intranet_employee_jobDetails where dbo.tbl_intranet_employee_jobDetails.empcode='" + Request.QueryString["empCode"].ToString() + "' ";

                dssqlstrBrachCode = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrBrachCode);

                BranchCode = Convert.ToInt32(dssqlstrBrachCode.Tables[0].Rows[0][0]);
                
                sqlstrBindShift = @"SELECT dbo.tbl_leave_shift.shiftid, dbo.tbl_leave_shift.shiftname FROM dbo.tbl_leave_shift where dbo.tbl_leave_shift.branch_id in (" + BranchCode + ",0) ";

                dsBindShift = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstrBindShift);

                if (dsBindShift.Tables[0].Rows.Count > 0)
                {

                    drpshift.Items.Clear();

                    foreach (DataRow row1 in dsBindShift.Tables[0].Rows)
                    {
                        drpshift.Items.Add(new ListItem(row1["shiftname"].ToString().Trim(), row1["shiftid"].ToString().Trim()));

                    }

                }
        }
    }


    protected void shiftUpdate()
    {
        int i = 0;

        foreach (GridViewRow GridView in empdutyrosterdetails.Rows)
        {
            CheckBox Chkbox = (CheckBox)GridView.FindControl("Chkbox");

            if (Chkbox.Checked != null)
            {
                if (Chkbox.Checked)
                {

                    string strEmpCode = empdutyrosterdetails.Rows[i].Cells[2].Text;

                    DropDownList intShiftCode = (DropDownList)empdutyrosterdetails.Rows[i].FindControl("drpShift");

                    int sftcode = Convert.ToInt32(intShiftCode.SelectedValue.ToString());

                    strUpdate = @" update dbo.tbl_leave_dutyroster set empshiftcode = '" + sftcode + "' where empcode = '" + strEmpCode.ToString() + "' and date='" + Chkbox.Text + "' ";

                    DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, strUpdate);

                }
            }
            i = i + 1;
        }
    }
}
