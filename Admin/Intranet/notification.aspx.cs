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

public partial class intranet_newsmaster : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;
    //========================================================================================================================================
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["updateData"] = "0";
            checkButtons();
            bindgrid();
        }
        message.InnerHtml = "";
    }

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

    //========================================================================================================================================
    protected void bindgrid()
    {
        sqlstr = "SELECT id,heading,description,(CASE WHEN run_status=0 THEN 'Running' ELSE 'Stopped' END)run_status,run_status run_status1,category,(CASE WHEN priority=0 THEN 'Low' WHEN priority=1 THEN 'Medium' ELSE 'High' END)priority,priority priority1,(CASE WHEN posteddate='01/01/1900' THEN '' ELSE  posteddate  END) posteddate,posteddate posteddate1 FROM notification ORDER BY posteddate1 desc,category";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        newsdetails.DataSource = ds;
        newsdetails.DataBind();
    }

    //========================================================================================================================================
    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool s = saverecords();
        if (s)
        {
            message.InnerHtml = "Record has been saved successfully!";
            RichTextDesc.Text = "";
        }
        bindgrid();
        reset();
    }

    //========================SAVING RECORDS===============================================================
    protected bool saverecords()
    {
        try
        {
            SqlParameter[] newparameter = new SqlParameter[8];

            newparameter[0] = new SqlParameter("@category", SqlDbType.VarChar, 50);
            //newparameter[0].Value = ddlcategory.SelectedItem.Text;
            newparameter[0].Value = "General";

            newparameter[1] = new SqlParameter("@heading", SqlDbType.VarChar, 100);
            newparameter[1].Value = txtheading.Text.Trim().ToString();

            newparameter[2] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            newparameter[2].Value = txtdescription.Text.Trim().ToString();

            newparameter[3] = new SqlParameter("@run_status", SqlDbType.Int);
            newparameter[3].Value = 0;

            newparameter[4] = new SqlParameter("@priority", SqlDbType.Int);
            newparameter[4].Value = 0;

            newparameter[5] = new SqlParameter("@empcode", SqlDbType.VarChar, 150);
            newparameter[5].Value = Session["EmpName"].ToString();

            newparameter[6] = new SqlParameter("@desc_rich", SqlDbType.NVarChar);
            newparameter[6].Value = HttpUtility.HtmlEncode(RichTextDesc.Text);
            newparameter[7] = new SqlParameter("@ID", SqlDbType.Int);
            newparameter[7].Value = Convert.ToInt32(ViewState["updateData"]);

            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "intranet_insert_notification_sp", newparameter);
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
        //ddlcategory.SelectedIndex = 0;
        txtheading.Text = "";
        txtdescription.Text = "";
        RichTextDesc.Text = "";
    }

    //========================================================================================================================================
    protected void newsdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        newsdetails.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    //========================================================================================================================================
    protected void newsdetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        newsdetails.EditIndex = -1;
        bindgrid();
    }

    //========================================================================================================================================
    protected void newsdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Attributes.Add("onmouseover", "this.className='hover-clr'");
        //    e.Row.Attributes.Add("onmouseout", "this.className='out-clr'");
        //}
    }

    //========================================================================================================================================
    protected void newsdetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int code;
        code = (int)newsdetails.DataKeys[e.RowIndex].Value;
        sqlstr = "DELETE FROM notification WHERE id=" + code;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        bindgrid();
    }

    //========================================================================================================================================
    protected void newsdetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //newsdetails.EditIndex = e.NewEditIndex;
        //bindgrid();
        int key = Convert.ToInt32(newsdetails.DataKeys[e.NewEditIndex].Value);
        sqlstr = "select heading,description,RichDescription from notification where id=" + key + "";
        DataTable dtresult = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr).Tables[0];
        if (dtresult.Rows.Count > 0)
        {
            ViewState["updateData"] = key.ToString();
            checkButtons();
            txtheading.Text = dtresult.Rows[0]["heading"].ToString();
            txtdescription.Text = dtresult.Rows[0]["description"].ToString();
            RichTextDesc.Text = HttpUtility.HtmlDecode(dtresult.Rows[0]["RichDescription"].ToString());
        }
    }

    //========================================================================================================================================
    protected void newsdetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strheading = ((TextBox)newsdetails.Rows[e.RowIndex].Cells[0].Controls[1]).Text;
        string strdescription = ((TextBox)newsdetails.Rows[e.RowIndex].Cells[1].Controls[1]).Text;
        string strrunstatus = ((DropDownList)newsdetails.Rows[e.RowIndex].Cells[2].Controls[1]).SelectedValue;
        string strpriority = ((DropDownList)newsdetails.Rows[e.RowIndex].Cells[3].Controls[1]).SelectedValue;
        int code = (int)newsdetails.DataKeys[e.RowIndex].Value;
        // sqlstr = "UPDATE notification SET category='" + strcategory.Replace("'", "''") + "', heading='" + strheading.Replace("'", "''") + "',description='" + strdescription.Replace("'", "''") + "',run_status=" + strrunstatus + ", priority=" + strpriority + " WHERE id=" + code + "";
        sqlstr = "UPDATE notification SET category='General', heading='" + strheading.Replace("'", "''") + "',description='" + strdescription.Replace("'", "''") + "',run_status=" + strrunstatus + ", priority=" + strpriority + " WHERE id=" + code + "";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        newsdetails.EditIndex = -1;
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
    protected void newsdetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Link_Update")
        {
            int key = Convert.ToInt32(e.CommandArgument);
            sqlstr = "select heading,description,RichDescription from notification where id=" + key + "";
            DataTable dtresult = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr).Tables[0];
            if (dtresult.Rows.Count > 0)
            {
                ViewState["updateData"] = key.ToString();
                checkButtons();
                txtheading.Text = dtresult.Rows[0]["heading"].ToString();
                txtdescription.Text = dtresult.Rows[0]["description"].ToString();
                RichTextDesc.Text = HttpUtility.HtmlDecode(dtresult.Rows[0]["RichDescription"].ToString());
            }
        }
    }
}
//========================================================================================================================================
