using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using Utilities;
using System.Collections.Generic;


//using System.Runtime.InteropServices;
//using Microsoft.Office.Core;
using System.Text;
public partial class leave_admin_attendance : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_employee.Attributes.Add("readonly", "readonly");

        if (!IsPostBack)
        {


            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            message.InnerHtml = "";
            this.imgf.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txt_time'))");
            this.imgouttime.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txtouttime'))");
            fillDDLForTime();
        }
    }

    private void fillDDLForTime()
    {
        List<Int32> listHour = new List<int>();
        List<Int32> listMinute = new List<int>();
        for (int i = 0; i <= 12; i++)
        {
            listHour.Add(i);
        }
        for (int i = 0; i <= 60; i++)
        {
            listMinute.Add(i);
        }
        ddl_in_hour.DataSource = listHour;
        ddl_in_hour.DataBind();
        ddl_out_hour.DataSource = listHour;
        ddl_out_hour.DataBind();
        ddl_in_minute.DataSource = listMinute;
        ddl_in_minute.DataBind();
        ddl_out_minute.DataSource = listMinute;
        ddl_out_minute.DataBind();
    }


    protected void validateattendance()
    {
    }
    protected void btn_sbmit_Click(object sender, EventArgs e)
    {
        if (Session["name"] != null)
        {
            sqlstr = "select count(empcode) as rows from tbl_leave_attendance where empcode='" + txt_employee.Text.ToString() + "' and date='" + Utility.DateTimeForat(txt_date.Text.ToString()) + "'";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);


            string str1 = "SELECT empcode FROM tbl_intranet_employee_jobDetails WHERE empcode='" + txt_employee.Text.ToString() + "'";
            DataSet dstemp = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, str1);

            string cardno = "0";
            if (dstemp.Tables[0].Rows.Count > 0)
            {
                cardno = dstemp.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                message.InnerHtml = "No card is issued to this employee!";
            }

            if ((int)ds.Tables[0].Rows[0]["rows"] > 0)
            {              
                string StrInTime = txt_time.Text.ToString();
                string StrOutTime = txtouttime.Text.ToString();

                DateTime dtime = Convert.ToDateTime(txt_date.Text);
                String[] timein = { "", "" };
                string[] timeinnew = { "", "" };
                String[] timeout = { "", "" };
                string[] timeoutnew = { "", "" };
                if (chk_intime_manual.Checked)
                {
                    timein[0] = ddl_in_hour.SelectedValue;
                    timeinnew[0] = ddl_in_minute.SelectedValue;
                    timeinnew[1] = rbtn_in_ampm.SelectedValue == "0" ? "am" : "pm";
                }
                else
                {
                    timein = txt_time.Text.Split(':');
                    timeinnew = timein[1].Split(' ');
                }
                if (chk_out_manual.Checked)
                {
                    timeout[0] = ddl_out_hour.SelectedValue;
                    timeoutnew[0] = ddl_out_minute.SelectedValue;
                    timeoutnew[1] = rbtn_out_ampm.SelectedValue == "0" ? "am" : "pm";
                }
                else
                {
                    timeout = txtouttime.Text.Split(':');
                    timeoutnew = timeout[1].Split(' ');
                }
                DateTime ObjInTime = new DateTime();
                DateTime ObjOutTime = new DateTime();

                if (timeinnew[1] == "am")
                {
                    ObjInTime = new DateTime(dtime.Year, dtime.Month, dtime.Day, Convert.ToInt32(timein[0]), Convert.ToInt32(timeinnew[0]), 0);
                }
                else if (timeinnew[1] == "pm")
                {
                    ObjInTime = new DateTime(dtime.Year, dtime.Month, dtime.Day, Convert.ToInt32(timein[0]) + 12, Convert.ToInt32(timeinnew[0]), 0);
                }
                if (timeoutnew[1] == "am")
                {
                    ObjOutTime = new DateTime(dtime.Year, dtime.Month, dtime.Day, Convert.ToInt32(timeout[0]), Convert.ToInt32(timeoutnew[0]), 0);
                }
                else if (timeoutnew[1] == "pm")
                {
                    ObjOutTime = new DateTime(dtime.Year, dtime.Month, dtime.Day, Convert.ToInt32(timeout[0]) + 12, Convert.ToInt32(timeoutnew[0]), 0);
                }
                // DateTime ObjOutTime = GetDateTime(StrOutTime);
                SqlParameter[] sqlparm = new SqlParameter[6];
                sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
                sqlparm[0].Value = txt_employee.Text.ToString();
                sqlparm[1] = new SqlParameter("@date", SqlDbType.DateTime, 100);
                // sqlparm[1].Value = Utility.DateTimeForat(txt_date.Text.ToString());
                sqlparm[1].Value = Convert.ToDateTime(txt_date.Text.ToString());
                sqlparm[2] = new SqlParameter("@InTime", SqlDbType.DateTime, 100);
                sqlparm[2].Value = ObjInTime;
                sqlparm[3] = new SqlParameter("@OutTime", SqlDbType.DateTime, 100);
                sqlparm[3].Value = ObjOutTime;
                sqlparm[4] = new SqlParameter("@isOD", SqlDbType.Bit);
                sqlparm[4].Value = chk_isOD.Checked ? true : false;
                sqlparm[5] = new SqlParameter("@byUser", SqlDbType.VarChar);
                sqlparm[5].Value = Session["empcode"].ToString();
                int a = 0;

                a = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "Sp_Insert_Attendance_Manually", sqlparm);

                if (a > 0)
                {
                    message.InnerHtml = "Attendance for selected employee updated successfully";
                    clear();
                }
                else
                    message.InnerHtml = "There is some problem, please marke attendance again";               
            }
            else
            {
                string StrInTime = txt_time.Text.ToString();
                string StrOutTime = txtouttime.Text.ToString();

                DateTime dtime = Convert.ToDateTime(txt_date.Text);
                String[] timein = { "", "" };
                string[] timeinnew = { "", "" };
                String[] timeout = { "", "" };
                string[] timeoutnew = { "", "" };
                if (chk_intime_manual.Checked)
                {
                    timein[0] = ddl_in_hour.SelectedValue;
                    timeinnew[0] = ddl_in_minute.SelectedValue;
                    timeinnew[1] = rbtn_in_ampm.SelectedValue == "0" ? "am" : "pm";
                }
                else
                {
                    timein = txt_time.Text.Split(':');
                    timeinnew = timein[1].Split(' ');
                }
                if (chk_out_manual.Checked)
                {
                    timeout[0] = ddl_out_hour.SelectedValue;
                    timeoutnew[0] = ddl_out_minute.SelectedValue;
                    timeoutnew[1] = rbtn_out_ampm.SelectedValue == "0" ? "am" : "pm";
                }
                else
                {
                    timeout = txtouttime.Text.Split(':');
                    timeoutnew = timeout[1].Split(' ');
                }
                DateTime ObjInTime = new DateTime();
                DateTime ObjOutTime = new DateTime();


                if (timeinnew[1] == "am")
                {
                    ObjInTime = new DateTime(dtime.Year, dtime.Month, dtime.Day, Convert.ToInt32(timein[0]), Convert.ToInt32(timeinnew[0]), 0);
                }
                else if (timeinnew[1] == "pm")
                {
                    ObjInTime = new DateTime(dtime.Year, dtime.Month, dtime.Day, Convert.ToInt32(timein[0]) + 12, Convert.ToInt32(timeinnew[0]), 0);
                }
                if (timeoutnew[1] == "am")
                {
                    ObjOutTime = new DateTime(dtime.Year, dtime.Month, dtime.Day, Convert.ToInt32(timeout[0]), Convert.ToInt32(timeoutnew[0]), 0);
                }
                else if (timeoutnew[1] == "pm")
                {
                    ObjOutTime = new DateTime(dtime.Year, dtime.Month, dtime.Day, Convert.ToInt32(timeout[0]) + 12, Convert.ToInt32(timeoutnew[0]), 0);
                }
                // DateTime ObjOutTime = GetDateTime(StrOutTime);
                SqlParameter[] sqlparm = new SqlParameter[6];
                sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
                sqlparm[0].Value = cardno.Trim().ToString().Replace("'", "''");
                sqlparm[1] = new SqlParameter("@date", SqlDbType.DateTime, 100);
                sqlparm[1].Value = Convert.ToDateTime(txt_date.Text.ToString());
                sqlparm[2] = new SqlParameter("@InTime", SqlDbType.DateTime, 100);
                sqlparm[2].Value = ObjInTime;
                sqlparm[3] = new SqlParameter("@OutTime", SqlDbType.DateTime, 100);
                sqlparm[3].Value = ObjOutTime;
                sqlparm[4] = new SqlParameter("@isOD", SqlDbType.Bit);
                sqlparm[4].Value = chk_isOD.Checked ? true : false;
                sqlparm[5] = new SqlParameter("@byUser", SqlDbType.VarChar);
                sqlparm[5].Value = Session["empcode"].ToString();                
                int a = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "Sp_Insert_Attendance_Manually", sqlparm);

                if (a > 0)
                {
                    message.InnerHtml = "Attendance for selected employee marked successfully";
                    clear();
                }
                else
                    message.InnerHtml = "There is some problem, please marke attendance again";
            }
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }
    }
    protected void clear()
    {
        //txt_date.Text = "";
        //txt_employee.Text = "";
        //txt_time.Text = "";
        //txtouttime.Text = "";
        dv_in_manual.Visible = false;
        dv_out_manual.Visible = false;
        if (chk_intime_manual.Checked)
            chk_intime_manual.Checked = false;
        if (chk_out_manual.Checked)
            chk_out_manual.Checked = false;
    }
    protected void btn_rst_Click(object sender, EventArgs e)
    {
        clear();
        message.InnerHtml = "";
    }
    protected void chk_intime_manual_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_intime_manual.Checked)
        {
            dv_in_manual.Visible = true;
            RequiredFieldValidator2.Enabled = false;

        }
        else
        {
            dv_in_manual.Visible = false;
            ddl_in_hour.SelectedValue = "0";
            ddl_in_minute.SelectedValue = "0";
            RequiredFieldValidator2.Enabled = true;
        }
    }
    protected void chk_out_manual_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_out_manual.Checked)
        {
            dv_out_manual.Visible = true;
            RequiredFieldValidator4.Enabled = false;
        }
        else
        {
            dv_out_manual.Visible = false;
            ddl_out_hour.SelectedValue = "0";
            ddl_out_minute.SelectedValue = "0";
            RequiredFieldValidator4.Enabled = true;
        }
    }
}
