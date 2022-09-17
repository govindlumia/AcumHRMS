using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using DTUtility;
using System.IO;
using QueryStringEncryption;

public partial class Recruitment_User_InterviewReschedule : System.Web.UI.Page
{
    int Result=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["EmpCode"])))
            {

                Response.Redirect("~/Login.aspx");
            }

            if (Request.QueryString["ID"] != null)
            {
                Cryptography objDec = new Cryptography();

                ViewState["ID"] = objDec.Decrypt(Request.QueryString["ID"].Replace(" ", "+").ToString());
                lblCanId.Text = ViewState["ID"].ToString();
               
            }
            TimeList();
            if (string.IsNullOrEmpty(ApplicationStartupSetting._connectionString))
            {

                ApplicationStartupSetting.RecounsructMe();
            }
            SelectInterViewer();
            GetOldInterViewSchedule();
            txt_reqdate.Attributes.Add("readonly", "readonly");
        }
    }

    protected void GetOldInterViewSchedule()
    {
        DataSet ds = SqlHelper.ExecuteDataset(ApplicationStartupSetting._connectionString, "usp_GetInterviewSchedule", ViewState["ID"]);
        txt_reqdate.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        string[] HTime = ds.Tables[0].Rows[0].ItemArray[1].ToString().Split(':');
        string[] MTime = HTime[1].Split(' ');
        ddlHtime.Text = HTime[0].ToString();
        ddlMtime.Text = MTime[0].ToString(); 
        ddlInterviewer.Items.FindByValue(ds.Tables[0].Rows[0].ItemArray[2].ToString()).Selected = true;
    
    }
     protected void TimeList()
    {
        List<int> Hlist = new List<int>();
        List<int> Slist = new List<int>();
        for (int i = 0; i <= 12; i++)
			{
                Hlist.Add(i);
			}

        for (int i = 0; i <= 60; i++)
        {
            Slist.Add(i);
        }
        ddlHtime.DataSource = Hlist;
        ddlHtime.DataBind();

        ddlMtime.DataSource = Slist;
        ddlMtime.DataBind();
        
    }
     protected void SelectInterViewer()
    {
        DataSet ds = SqlHelper.ExecuteDataset(ApplicationStartupSetting._connectionString, "usp_SelectInterviewer", ViewState["ID"].ToString());
        ddlInterviewer.DataSource = ds;
        ddlInterviewer.DataValueField = "CreatedBy";
        ddlInterviewer.DataTextField = "EmpName";
        ddlInterviewer.DataBind();
    
    
    }
     protected void ddlHtime_BoundHour(object sender, EventArgs e)
     {
         ddlHtime.Items.Insert(0, new ListItem("-1", "-1"));
     }
     protected void ddlMtime_BoundHour(object sender, EventArgs e)
     {
         ddlMtime.Items.Insert(0, new ListItem("-1", "-1"));
     }
     protected void RadioButton_ChackedChange(object sender, EventArgs e)
     {
         if (rdo1.Checked == true)
         {
             lblrdo.Text = "AM";
         }
         else
         {
             lblrdo.Text = "PM";

         }
     
     }
     protected void ddlInterviewer_databound(object sender, EventArgs e)
     {
         ddlInterviewer.Items.Insert(0, new ListItem("--Select Interviewer--", "0"));
     }
     protected void txt_reqdate_dateChanged(object sender, EventArgs e)
     {

         lbldate.Text = txt_reqdate.Text;
     
     }
     protected void btnSelect_Click(object sender, EventArgs e)
     {
         if (ddlHtime.SelectedItem.Text != "0" || ddlMtime.SelectedItem.Text != "0")
         {
             if (string.IsNullOrEmpty(lblrdo.Text))
             {
                 lblrdo.Text = "PM";

             }
             DateTime ScheduleDate = Convert.ToDateTime(txt_reqdate.Text);
             string ScheduleTime = ddlHtime.SelectedItem.Value + ":" + ddlMtime.SelectedItem.Value + ' ' + lblrdo.Text;
             Result = SqlHelper.ExecuteNonQuery(ApplicationStartupSetting._connectionString, "usp_UpdateInterviewSchedule", ViewState["ID"].ToString(), ScheduleDate, ScheduleTime, Session["EmpCode"].ToString(), ddlInterviewer.SelectedItem.Value);
             ContentPlaceHolder mpContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder2");
             Label lblmsg = (Label)mpContentPlaceHolder.FindControl("lblmsg");
             if (Result == 1)
             {


                 if (mpContentPlaceHolder != null)
                 {

                     if (lblmsg != null)
                     {


                         lblmsg.Text = "Schedule update successfully!";
                         lblmsg.Visible = true;
                         Clear();
                     }
                 }
             }

             else
             {

                 lblmsg.Text = "Operation could not successfully!";
                 lblmsg.Visible = true;

             }
         }
         else
         {
             ScriptManager.RegisterStartupScript(this, GetType(), "Message", "alert('Hour and minute should not be equal.');", true);
         }
     }

     protected void Clear()
     {
         txt_reqdate.Text = "";
         ddlHtime.SelectedIndex = -1;
         ddlMtime.SelectedIndex = -1;
         ddlInterviewer.SelectedIndex = 0;
     
     
     }

}