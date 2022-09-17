using System;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data;
using DataAccessLayer;
using querystring;

public partial class Leave_AttendanceSummary : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string Date=string.Empty;
        string empcode=string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["date"].ToString()!=null)
        {
           Date= Request.QueryString["date"].ToString();
        }
        if (Request.QueryString["empcode"].ToString() != null)
        {
            empcode = Request.QueryString["empcode"].ToString();
        }
        if (!IsPostBack)
           {
               bind_attendance();
        }
        
    }
    protected void bind_attendance()
    {
        try
        {

            string sqlstr = @"select p.empcode,CONVERT(varchar(50), p.date,106) as adate,CONVERT(varchar(25), p.Time,113) as Intime, p.Mode, p.doordescription from tbl_leave_attendance_Rawdata p where empcode='" + empcode + "' and Convert(datetime,p.date, 103) ='" + Date + "'  order by Intime"; 
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.Text, sqlstr);

            if (ds.Tables[0].Rows.Count > 0)
            {
                update.Visible = true;
                empgrid.DataSource = ds;
                empgrid.DataBind();
               
            }
            else
            {
                update.Visible = false;
                message.InnerHtml = "No data found";
                
            }
        }
        catch (Exception ex)
        {
            message.InnerHtml = "";
        }
    }

   
    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bind_attendance();
    }
    
}