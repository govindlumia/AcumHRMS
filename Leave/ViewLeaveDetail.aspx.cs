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
using querystring;
using Utilities;

public partial class Leave_ViewLeaveDetail : System.Web.UI.Page
{
    string sqlstr;
    string message1;
    DataSet ds = new DataSet();
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    public int i, ptr1, ptr2;
    protected void Page_Load(object sender, EventArgs e)
    {
        message1 = "";
        message.InnerHtml = "";
        //dd_typeleave.Attributes.Add("onchange", "disablesubmit();");
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            query q = new query();
            hidd_leaveapplyid.Value = (q["leaveapplyid"] != null) ? q["leaveapplyid"] : "0";
            hidd_empcode.Value = (q["empcode"] != null) ? q["empcode"] : "0";
            bindemployee_detail();
            fetchleavedata();
        }
    }
    protected void fetchleavedata()
    {
        if (hidd_leaveapplyid.Value == "0")
        {
            message.InnerHtml = "Problem fetching leave data,try latter";
            return;
        }
        SqlParameter[] sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@applyleaveid", SqlDbType.Int, 4);
        sqlparm[0].Value = hidd_leaveapplyid.Value;

        sqlparm[1] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[1].Value = hidd_empcode.Value;
      
        //("@applyleaveid", Request.QueryString["leaveapplyid"].ToString());
        //@empcode

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_viewleaveapply", sqlparm);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl_leave.Text = ds.Tables[0].Rows[0]["leavetype"].ToString();
            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["leavemode"]))
            {
                divfull.Visible = true;
                if (ds.Tables[0].Rows[0]["director"].ToString() != "")
                {
                    divDirector.Visible = true;
                    txt_employee.Text = ds.Tables[0].Rows[0]["resPerson"].ToString();
                    lblDirector.Text = ds.Tables[0].Rows[0]["directorName"].ToString();
                }
                else
                {
                    divDirector.Visible = false;
                    txt_employee.Text = ds.Tables[0].Rows[0]["resPerson"].ToString();
                    lblDirector.Text = ds.Tables[0].Rows[0]["directorName"].ToString();
                }
                divhalf.Visible = false;
                divshort.Visible = false;
                DateTime lblsdate, lbledate;
                lbl_sdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"].ToString()).ToString("dd-MMM-yyyy");
                lbl_edate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"].ToString()).ToString("dd-MMM-yyyy");
            }
            else if ((ds.Tables[0].Rows[0]["half"]).ToString() != string.Empty)
            {
                divfull.Visible = false;
                divshort.Visible = false;
                divhalf.Visible = true;
                //commented
                //DateTime lblselect = Utility.dataformat(ds.Tables[0].Rows[0]["hdate"].ToString());

                lbl_select.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["hdate"].ToString()).ToString("dd-MMM-yyyy");
                lbl_half.Text = (Convert.ToBoolean(ds.Tables[0].Rows[0]["half"])) ? "First half" : "Second half";
            }
            else
            {
                divfull.Visible = false;
                divhalf.Visible = false;
                divshort.Visible = true;
                //commented
                //DateTime lblselect = Utility.dataformat(ds.Tables[0].Rows[0]["hdate"].ToString());

                lbl_selectSh.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["hdate"].ToString()).ToString("dd-MMM-yyyy");
                lbl_short.Text = (Convert.ToBoolean(ds.Tables[0].Rows[0]["short"])) ? "In First half" : "In Second half";
            }

           
            lbl_nod.Text = ds.Tables[0].Rows[0]["no_of_days"].ToString();
            lbl_reason.Text = ds.Tables[0].Rows[0]["reason"].ToString();
            lbl_comments.Text = ds.Tables[0].Rows[0]["comments"].ToString();
            lbl_address.Text = ds.Tables[0].Rows[0]["address"].ToString();
            lbl_mobileno.Text = ds.Tables[0].Rows[0]["mobileno"].ToString();
            lbl_dated.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["createddate"].ToString()).ToString("dd-MMM-yyyy");
            lbl_file.Text = (ds.Tables[0].Rows[0]["file_path"].ToString() != "") ? "<a href='upload/leavedata/" + ds.Tables[0].Rows[0]["file_path"].ToString() +
              "'>" + ds.Tables[0].Rows[0]["file_path"].ToString() + "</a>" : "No exisitng file found";
        }
        else
        {
            message.InnerHtml = "No data available";
            return;
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            adjustgrid.DataSource = ds.Tables[1];
            adjustgrid.DataBind();
        }
        if (ds.Tables[2].Rows.Count > 0)
        {
            approvergrid.DataSource = ds.Tables[2];
            approvergrid.DataBind();
        }
    }

    protected void bindemployee_detail()
    {
        SqlParameter sqlparm = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm.Value = hidd_empcode.Value;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm);


        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl_emp_name.Text = ds.Tables[0].Rows[0]["name"].ToString();
            lbl_emp_code.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            lbl_gender.Text = ds.Tables[0].Rows[0]["emp_gender"].ToString();
            lbl_emp_status.Text = ds.Tables[0].Rows[0]["status"].ToString();
            lbl_department.Text = ds.Tables[0].Rows[0]["CategoryName"].ToString();
            //lbl_branch.Text = ds.Tables[0].Rows[0]["BussinessUnitName"].ToString();
            lbl_designation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
            if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["emp_doj"].ToString()))
            {
                DateTime doj = Utility.dataformat(ds.Tables[0].Rows[0]["emp_doj"].ToString());//.ToString("dd - MMM - yyyy")
                lbl_doj.Text = doj.ToString("dd-MMM-yyyy");
            }

            adjustgrid.DataSource = null;
            adjustgrid.DataBind();
        }

        if (ds.Tables[1].Rows.Count > 0)
        {
            grdMyBalance.DataSource = ds.Tables[1];
            grdMyBalance.DataBind();
        }
        else
        {
            grdMyBalance.DataSource = null;
            grdMyBalance.DataBind();
        }
    }
}