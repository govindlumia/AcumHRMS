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
using QueryStringEncryption;
using System.IO;
using System.Collections.Generic;

public partial class Leave_admin_editshift : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds=new DataSet();
    
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
        }
        sqlstr = "select shiftid,shiftname,right(convert(varchar(50),starttime),7)starttime,right(convert(varchar(50),endtime),7)endtime,shift_description from tbl_leave_shift where status != 0 and shiftid not in (0,1,2) ";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        shiftgrid.DataSource = ds;
        shiftgrid.DataBind();

        message.InnerHtml = "";

        if (Request.QueryString["updated"] != null)
            message.InnerHtml = "Shift updated successfully.";
    }        

    

   

    public void bindshift()
    {
       
            sqlstr = "SELECT shiftid,shiftname,right(convert(varchar(50),starttime),7)starttime,right(convert(varchar(50),endtime),7)endtime,shift_description from tbl_leave_shift where status != 0 and shiftid not in (0,1,2)";
        
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        shiftgrid.DataSource = ds;
        shiftgrid.DataBind();
    }

    public void BindDDLTime(DropDownList ddlSH, DropDownList ddlEH, DropDownList ddlSM, DropDownList ddlEM)
    {
        List<string> Hours = new List<string>();
        for (int i = 0; i <= 23; i++)
        {
            //if (i.ToString().Length < 2)
            //    Hours.Add("0" + i.ToString());
            //else
            Hours.Add(i.ToString());
        }
        ddlSH.DataSource = Hours;
        ddlSH.DataBind();

        ddlEH.DataSource = Hours;
        ddlEH.DataBind();

        //ddlSH.Items.Insert(0, new ListItem("-Select-", "0"));
        //ddlEH.Items.Insert(0, new ListItem("-Select-", "0"));

        List<string> Minutes = new List<string>();
        for (int i = 0; i < 60; i++)
        {
            //if (i.ToString().Length < 2)
            //    Minutes.Add("0" + i.ToString());
            //else
            Minutes.Add(i.ToString());
        }
        ddlSM.DataSource = Minutes;
        ddlSM.DataBind();

        ddlEM.DataSource = Minutes;
        ddlEM.DataBind();

        //ddlSM.Items.Insert(0, new ListItem("-Select-", "0"));
        //ddlEM.Items.Insert(0, new ListItem("-Select-", "0"));

    }
    protected void shiftgrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int code;
        code = (int)shiftgrid.DataKeys[e.NewEditIndex].Value;
        Response.Redirect("updateshift.aspx?shiftid=" + Convert.ToInt32(Request.QueryString["shiftid"]) + "");
    }

    protected void shiftgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        shiftgrid.PageIndex = e.NewPageIndex;
        shiftgrid.DataSource = ds;
        shiftgrid.DataBind();        
    }

    protected void shiftgrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int a;
        a = (int)shiftgrid.DataKeys[e.RowIndex].Value;
       
        sqlstr = "UPDATE tbl_leave_shift SET status='0' where shiftid=" + a + "";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        bindshift();
    }
}
