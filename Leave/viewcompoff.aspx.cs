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

public partial class leave_viewcompoff : System.Web.UI.Page
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
       if(!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            query q = new query();
            hidd_leaveapplyid.Value = (q["leaveapplyid"] != null) ? q["leaveapplyid"] : "0";
            bindemployee_detail();
            fetchleavedata();
        }
    }

    protected void fetchleavedata()
    {
        if (hidd_leaveapplyid.Value == "0")
        {
            message.InnerHtml = "Problem fetchin leave data,try latter";
            return;
        }
        SqlParameter[] sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@applyleaveid", SqlDbType.Int, 4);
        sqlparm[0].Value = hidd_leaveapplyid.Value;

        sqlparm[1] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[1].Value = Session["empcode"].ToString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_viewcompoffapply", sqlparm);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["half"]))
            {
                divfull.Visible = true;

                divhalf.Visible = false;
                divshort.Visible = false;
                DateTime lblsdate, lbledate;
                lbl_sdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"].ToString()).ToString("dd-MMM-yyyy");
                lbl_edate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"].ToString()).ToString("dd-MMM-yyyy");
               

            }
            else
            {
                if ((ds.Tables[0].Rows[0]["halfMode"]).ToString() != string.Empty)
                {
                    divfull.Visible = false;
                    divshort.Visible = false;
                    divhalf.Visible = true;
                    //commented
                    //DateTime lblselect = Utility.dataformat(ds.Tables[0].Rows[0]["hdate"].ToString());

                    lbl_select.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"].ToString()).ToString("dd-MMM-yyyy");
                    lbl_half.Text = (Convert.ToBoolean(ds.Tables[0].Rows[0]["halfMode"])) ? "First half" : "Second half";
                }
                else
                {
                    divfull.Visible = false;
                    divhalf.Visible = false;
                    divshort.Visible = true;
                    //commented
                    //DateTime lblselect = Utility.dataformat(ds.Tables[0].Rows[0]["hdate"].ToString());

                    lbl_selectSh.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"].ToString()).ToString("dd-MMM-yyyy");

                }
            }

            if ((ds.Tables[0].Rows[0]["leave_status"].ToString() == "3" || ds.Tables[0].Rows[0]["leave_status"].ToString() == "2") && (ds.Tables[0].Rows[0]["status"].ToString() == "1"))
            {
                txt_cancel.Visible = false;
                btn_modify.Visible = false;
                Comments.Visible = false;
            }
            lbl_leave.Text = ds.Tables[0].Rows[0]["leavetype"].ToString();
            lbl_nod.Text = ds.Tables[0].Rows[0]["no_of_days"].ToString();
            lbl_reason.Text = ds.Tables[0].Rows[0]["reason"].ToString();
            lbl_comments.Text = ds.Tables[0].Rows[0]["comment"].ToString();
            lbl_address.Text = ds.Tables[0].Rows[0]["address"].ToString();
            lbl_mobileno.Text = ds.Tables[0].Rows[0]["mobileno"].ToString();
            lbl_dated.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["createddate"].ToString()).ToString("dd-MMM-yyyy");
            lbl_file.Text = (ds.Tables[0].Rows[0]["filepath"].ToString() != "") ? "<a href='upload/" + ds.Tables[0].Rows[0]["filepath"].ToString() +
              "'>" + ds.Tables[0].Rows[0]["filepath"].ToString() + "</a>" : "No exisitng file found";
        }
        else
        {
            message.InnerHtml = "No data available";
            return;
        }
        //if (ds.Tables[1].Rows.Count > 0)
        //{
        //    adjustgrid.DataSource = ds.Tables[1];
        //    adjustgrid.DataBind();
        //}
        if (ds.Tables[1].Rows.Count > 0)
        {
            approvergrid.DataSource = ds.Tables[1];
            approvergrid.DataBind();
        }
    }



    protected void bindemployee_detail()
    {
        SqlParameter sqlparm = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm.Value = Session["empcode"].ToString();
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

            //adjustgrid.DataSource = null;
            //adjustgrid.DataBind();
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


    protected void btn_modify_Click(object sender, EventArgs e)
    {
        query q = new query();
        string pairs = String.Format("leaveapplyid={0}&modify=1", hidd_leaveapplyid.Value);
        string encoded;
        encoded = q.EncodePairs(pairs);
        Response.Redirect("edit_applied_compoff.aspx?q=" + encoded);
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {

        int status;
        SqlParameter[] sqlparm;
        sqlparm = new SqlParameter[1];

        sqlparm[0] = new SqlParameter("@id", SqlDbType.Int, 4);
        sqlparm[0].Value = hidd_leaveapplyid.Value;
        try
        {

            status = Convert.ToInt32(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_validate_confirmcompoff_hr", sqlparm));
            switch (status)
            {
                case 0: cancelleave(2, 1);
                    Response.Redirect("compoff_status.aspx?compoffstatus=10&message=Comp-off leave cancelled successfully");
                    break;
                case 1: cancelleave(1, 0);
                    Response.Redirect("compoff_status.aspx?compoffstatus=10&message=Comp-off leave applied for cancellation successfully");
                    break;
                case 2: cancelleave(2, 1);
                    Response.Redirect("compoff_status.aspx?compoffstatus=10&message=Comp-off leave already cancelled");
                    break;
                case 3: cancelleave(3, 1);
                    Response.Redirect("compoff_status.aspx?leavestatus=10&message=Comp-off leave cannot be cancelled,its already in rejected status");
                    break;
                case 4: cancelleave(2, 1);
                    Response.Redirect("compoff_status.aspx?compoffstatus=10&message=Comp-off leave cancelled Successfully");
                    break;
                case 5: cancelleave(2, 1);
                    Response.Redirect("compoff_status.aspx?compoffstatus=10&message=Comp-off leave cancelled Successfully");
                    break;
                case 6: cancelleave(6, 0);
                    Response.Redirect("compoff_status.aspx?compoffstatus=10&message=Comp-off leave applied for cancellation successfully");
                    break;
            }
        }

        catch (Exception ex)
        {
            message.InnerHtml = "Problem canceling comp-off leave,try latter";
        }   
    }

    protected void cancelleave(int leave_status, int status)
    {

        SqlParameter[] sqlparm = new SqlParameter[5];
        sqlparm[0] = new SqlParameter("@comment", SqlDbType.VarChar, 2000);
        if (txt_comment.Text != "")
            sqlparm[0].Value = "<b>Comments added by " + Session["name"].ToString() + " on " + DateTime.Now.ToString("dd-MMM-yyyy") + " :</b><br>" + txt_comment.Text + "<br>";
        else
            sqlparm[0].Value = "";

        sqlparm[1] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
        sqlparm[1].Value = Session["name"].ToString();

        sqlparm[2] = new SqlParameter("@applyleaveid", SqlDbType.Int, 4);
        sqlparm[2].Value = hidd_leaveapplyid.Value;

        sqlparm[3] = new SqlParameter("@Leave_status", SqlDbType.Int, 4);
        sqlparm[3].Value = leave_status;

        sqlparm[4] = new SqlParameter("@status", SqlDbType.Int, 4);
        sqlparm[4].Value = status;

        if (leave_status == 1 || leave_status == 6)
        {
            sqlstr = "update tbl_leave_apply_compoff set comment=comment + @comment,leave_status=@leave_status,approval_status=0,status=@status,modifiedby=@modifiedby where id=@applyleaveid";
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr, sqlparm);
        }
        else
        {
            sqlstr = "update tbl_leave_apply_compoff set comment=comment + @comment,leave_status=@leave_status,modifiedby=@modifiedby where id=@applyleaveid";
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr, sqlparm);
        }

    }
}
