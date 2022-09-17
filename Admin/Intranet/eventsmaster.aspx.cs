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
using Utilities;

public partial class intranet_eventsmaster : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;
    //========================================================================================================================================
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {   
            //if (Session["role"] != null)
            //{
            //    if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
            //        Response.Redirect("~/Authenticate.aspx");
            //}
            //else
            //    Response.Redirect("~/notlogged.aspx");
            ViewState["updateData"] = "0";
            txt_edate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            txt_edate.Attributes.Add("ReadOnly", "ReadOnly");

            bindgrid();
        }
        message.InnerHtml = "";
    }


    #region HideShowButtons
    private void checkButtons()
    {
        if (ViewState["updateData"].ToString() != "0")
        {
            btnupdate.Visible = true;
            btnSave.Visible = false;
            btnclear.Visible = false;
        }

        else
        {
            btnSave.Visible = true;
            btnclear.Visible = true;
            btnupdate.Visible = false;
        }
    }
    #endregion

    //========================================================================================================================================
    protected void bindgrid()
    {
        //sqlstr = "SELECT id,heading,description,(CASE WHEN run_status=0 THEN 'Running' ELSE 'Stopped' END)run_status,run_status
       // run_status1,category,(CASE WHEN priority=0 THEN 'Low' WHEN priority=1 THEN 'Medium' ELSE 'High' END)priority,
        //priority priority1,(CASE WHEN posteddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(15), posteddate, 106) END) posteddate, EventDate FROM COMPANY_EVENTS ORDER BY posteddate desc,category";
        sqlstr = "SELECT id,heading,description, run_status, EventDate as EventDate  FROM COMPANY_EVENTS ORDER BY EventDate desc ";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        eventsdetails.DataSource = ds;
        eventsdetails.DataBind();
    }
    //========================================================================================================================================
    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool s = saverecords();
        if (s)
        {
            message.InnerHtml = "Record has been saved successfully!";
        }
        bindgrid();
        reset();
    }

    //========================SAVING RECORDS===============================================================
    protected bool saverecords()
    {
        try
        {
            SqlParameter[] newparameter = new SqlParameter[9];

            newparameter[0] = new SqlParameter("@category", SqlDbType.VarChar, 50);
            newparameter[0].Value = "Employee";

            newparameter[1] = new SqlParameter("@heading", SqlDbType.VarChar, 50);
            newparameter[1].Value = txtheading.Text.Trim().ToString();

            newparameter[2] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            newparameter[2].Value = txtdescription.Text.Trim().ToString();

            newparameter[3] = new SqlParameter("@run_status", SqlDbType.Int);
            newparameter[3].Value = 0;

            newparameter[4] = new SqlParameter("@priority", SqlDbType.Int);
            newparameter[4].Value = 0;

            newparameter[5] = new SqlParameter("@eventdate", SqlDbType.DateTime);
            newparameter[5].Value = Utility.DateTimeForat(txt_edate.Text);

            newparameter[6] = new SqlParameter("@empcode", SqlDbType.VarChar, 150);
            newparameter[6].Value = Session["EmpName"].ToString();

            newparameter[7] = new SqlParameter("@desc_rich", SqlDbType.NVarChar);
            newparameter[7].Value = HttpUtility.HtmlEncode(RichTextDesc.Text);
            newparameter[8] = new SqlParameter("@ID", SqlDbType.Int);
            newparameter[8].Value = Convert.ToInt32(ViewState["updateData"]);


            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "intranet_insert_events_sp", newparameter);
            return true;
        }
        catch (SqlException sql)
        {
            message.InnerHtml = "Cannot insert duplicate values or some database error has been occured!";
            return false;
        }
        catch (Exception ex)
        {
            message.InnerHtml = ex.Message;
            return false;
        }
        finally
        {

        }
    }

    //========================================================================================================================================
    protected void btnclear_Click(object sender, EventArgs e)
    {
        reset();
    }
    //========================================================================================================================================
    protected void reset()
    {
        txtheading.Text = "";
        txtdescription.Text = "";
        txt_edate.Text = "";
        RichTextDesc.Text = "";
    }
    //========================================================================================================================================
    protected void eventsdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        eventsdetails.PageIndex = e.NewPageIndex;
        bindgrid();
    }
    //========================================================================================================================================
    protected void eventsdetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        eventsdetails.EditIndex = -1;
        bindgrid();
    }
    //========================================================================================================================================
    protected void eventsdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.className='hover-clr'");
            e.Row.Attributes.Add("onmouseout", "this.className='out-clr'");
        }
    }
    //========================================================================================================================================
    protected void eventsdetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int code;
        code = (int)eventsdetails.DataKeys[e.RowIndex].Value;
        sqlstr = "DELETE FROM COMPANY_EVENTS WHERE id=" + code;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        bindgrid();
    }

    //========================================================================================================================================
    protected void eventsdetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //eventsdetails.EditIndex = e.NewEditIndex;
        //bindgrid();
        int key = Convert.ToInt32(eventsdetails.DataKeys[e.NewEditIndex].Value);
        sqlstr = "select heading,description,richdesc,eventdate from company_events where id=" + key + "";
        DataTable dtresult = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr).Tables[0];
        if (dtresult.Rows.Count > 0)
        {
            ViewState["updateData"] = key.ToString();
            checkButtons();
            txtheading.Text = dtresult.Rows[0]["heading"].ToString();
            txtdescription.Text = dtresult.Rows[0]["description"].ToString();
            txt_edate.Text = Convert.ToDateTime(dtresult.Rows[0]["eventdate"]).ToString("dd-MMM-yyyy");
            RichTextDesc.Text = HttpUtility.HtmlDecode(dtresult.Rows[0]["richdesc"].ToString());
        }
    }
    //========================================================================================================================================
    protected void eventsdetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strheading = ((TextBox)eventsdetails.Rows[e.RowIndex].Cells[0].Controls[1]).Text;
        string strdescription = ((TextBox)eventsdetails.Rows[e.RowIndex].Cells[1].Controls[1]).Text;
        int code = (int)eventsdetails.DataKeys[e.RowIndex].Value;

        sqlstr = "UPDATE COMPANY_EVENTS SET heading='" + strheading.Replace("'", "''") + "',description='" + strdescription.Replace("'", "''") + "',run_status=1, priority=1 WHERE id=" + code + "";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        eventsdetails.EditIndex = -1;
        bindgrid();
    }
    //========================================================================================================================================   
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        saverecords();
        ViewState["updateData"] = "0";
        checkButtons();
        reset();
    }
    protected void eventsdetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Link_Update")
        {
            int key = Convert.ToInt32(e.CommandArgument);
            //int key = Convert.ToInt32(eventsdetails.DataKeys[e.NewEditIndex].Value);
            sqlstr = "select heading,description,richdesc,eventdate from company_events where id=" + key + "";
            DataTable dtresult = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr).Tables[0];
            if (dtresult.Rows.Count > 0)
            {
                ViewState["updateData"] = key.ToString();
                checkButtons();
                txtheading.Text = dtresult.Rows[0]["heading"].ToString();
                txtdescription.Text = dtresult.Rows[0]["description"].ToString();
                txt_edate.Text = Convert.ToDateTime(dtresult.Rows[0]["eventdate"]).ToString("dd-MMM-yyyy");
                RichTextDesc.Text = HttpUtility.HtmlDecode(dtresult.Rows[0]["richdesc"].ToString());
            }
        
        }
    }
}
//========================================================================================================================================

