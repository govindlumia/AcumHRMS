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

public partial class intranet_achievements : System.Web.UI.Page
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
        sqlstr = "SELECT id,heading,description,(CASE WHEN run_status=0 THEN 'Running' ELSE 'Stopped' END)run_status,run_status run_status1,category,(CASE WHEN priority=0 THEN 'Low' WHEN priority=1 THEN 'Medium' ELSE 'High' END)priority,priority priority1,(CASE WHEN posteddate='01/01/1900' THEN '' ELSE  posteddate END) posteddate FROM ACHIEVEMENTS ORDER BY posteddate desc,category";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        achievementsdetails.DataSource = ds;
        achievementsdetails.DataBind();
    }
    //========================================================================================================================================
    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool s = saverecords();
        if (s)
        {
            message.InnerHtml = "Record has been saved successfully!";
            reset();
        }
        bindgrid();        
    }

    //========================SAVING RECORDS===============================================================
    protected bool saverecords()
    {
        try
        {
            SqlParameter[] newparameter = new SqlParameter[8];

            newparameter[0] = new SqlParameter("@category", SqlDbType.VarChar, 50);
            newparameter[0].Value = "Employee";

            newparameter[1] = new SqlParameter("@heading", SqlDbType.VarChar, 50);
            newparameter[1].Value = txtheading.Text.Trim().ToString();

            newparameter[2] = new SqlParameter("@description", SqlDbType.VarChar, 8000);
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
            

            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "intranet_insert_achievements_sp", newparameter);
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
        RichTextDesc.Text = "";

    }
    //========================================================================================================================================
    protected void achievementsdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        achievementsdetails.PageIndex = e.NewPageIndex;
        bindgrid();
    }
    //========================================================================================================================================
    protected void achievementsdetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        achievementsdetails.EditIndex = -1;
        bindgrid();
    }
    //========================================================================================================================================
    protected void achievementsdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Attributes.Add("onmouseover", "this.className='hover-clr'");
        //    e.Row.Attributes.Add("onmouseout", "this.className='out-clr'");
        //}
    }
    //========================================================================================================================================
    protected void achievementsdetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int code;
        code = (int)achievementsdetails.DataKeys[e.RowIndex].Value;
        sqlstr = "DELETE FROM ACHIEVEMENTS WHERE id=" + code;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        bindgrid();
    }

    //========================================================================================================================================
    protected void achievementsdetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        achievementsdetails.EditIndex = e.NewEditIndex;
        bindgrid();
    }
    //========================================================================================================================================
    protected void achievementsdetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strcategory = ((DropDownList)achievementsdetails.Rows[e.RowIndex].Cells[0].Controls[1]).Text;
        string strheading = ((TextBox)achievementsdetails.Rows[e.RowIndex].Cells[1].Controls[1]).Text;
        string strdescription = ((TextBox)achievementsdetails.Rows[e.RowIndex].Cells[2].Controls[1]).Text;
        string strrunstatus = ((DropDownList)achievementsdetails.Rows[e.RowIndex].Cells[3].Controls[1]).SelectedValue;
        string strpriority = ((DropDownList)achievementsdetails.Rows[e.RowIndex].Cells[4].Controls[1]).SelectedValue;
        int code = (int)achievementsdetails.DataKeys[e.RowIndex].Value;

        sqlstr = "UPDATE ACHIEVEMENTS SET heading='" + strheading.Replace("'", "''") + "',description='" + strdescription.Replace("'", "''") + "',run_status=" + strrunstatus + ", priority=" + strpriority + " WHERE id=" + code + "";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        achievementsdetails.EditIndex = -1;
        bindgrid();
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        saverecords();
        ViewState["updateData"] = "0";
        checkButtons();
        reset();
    }
    protected void achievementsdetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Link_Update")
        {
            int key = Convert.ToInt32(e.CommandArgument);
            sqlstr = "select heading,description,RichDesc from ACHIEVEMENTS where id=" + key + "";
            DataTable dtresult = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr).Tables[0];
            if (dtresult.Rows.Count > 0)
            {
                ViewState["updateData"] = key.ToString();
                checkButtons();
                txtheading.Text = dtresult.Rows[0]["heading"].ToString();
                txtdescription.Text = dtresult.Rows[0]["description"].ToString();
                RichTextDesc.Text = HttpUtility.HtmlDecode(dtresult.Rows[0]["RichDesc"].ToString());
            }
        }
    }



    //========================================================================================================================================   
}
//========================================================================================================================================
