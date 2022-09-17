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
            //if (Session["role"] != null)
            //{
            //    if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
            //        Response.Redirect("~/Authenticate.aspx");
            //}
            //else
            //    Response.Redirect("~/notlogged.aspx");
            bindcategory();
            bindgrid();
        }
        message.InnerHtml = "";
    }

    //========================================================================================================================================
    protected void bindcategory()
    {
        string categoryname;
        ////-----Add the Category in the drop down list Box-------------------------------
        ddlcategory.Items.Add(new ListItem("---Select Category---"));

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "select_category_sp");

        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row1 in ds.Tables[0].Rows)
            {
                categoryname = row1["categoryname"].ToString().Trim();

                ddlcategory.Items.Add(new ListItem(Convert.ToString(categoryname)));
            }
        }
    }

    //========================================================================================================================================
    protected void bindgrid()
    {
        sqlstr = "SELECT id,heading,description,(CASE WHEN run_status=0 THEN 'Running' ELSE 'Stopped' END)run_status,run_status run_status1,category,(CASE WHEN priority=0 THEN 'Low' WHEN priority=1 THEN 'Medium' ELSE 'High' END)priority,priority priority1,(CASE WHEN posteddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(15), posteddate, 106) END) posteddate,posteddate posteddate1 FROM NEWSROOM ORDER BY posteddate1 desc,category";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        newsdetails.DataSource = ds;
        newsdetails.DataBind();
    }

    //========================================================================================================================================
    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool s= saverecords();
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
            SqlParameter[] newparameter = new SqlParameter[5];

            newparameter[0] = new SqlParameter("@category", SqlDbType.VarChar, 50);
            newparameter[0].Value = ddlcategory.SelectedItem.Text;

            newparameter[1] = new SqlParameter("@heading", SqlDbType.VarChar, 100);
            newparameter[1].Value = txtheading.Text.Trim().ToString();

            newparameter[2] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            newparameter[2].Value = txtdescription.Text.Trim().ToString();

            newparameter[3] = new SqlParameter("@run_status", SqlDbType.Int);
            newparameter[3].Value =0;

            newparameter[4] = new SqlParameter("@priority", SqlDbType.Int);
            newparameter[4].Value = 0;

            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "intranet_insert_news_sp", newparameter);
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
        ddlcategory.SelectedIndex = 0;
        txtheading.Text = "";
        txtdescription.Text = "";
        
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
        sqlstr = "DELETE FROM NEWSROOM WHERE id=" + code;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        bindgrid();
    }

    //========================================================================================================================================
    protected void newsdetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        newsdetails.EditIndex = e.NewEditIndex;
        bindgrid(); 
    }

    //========================================================================================================================================
    protected void newsdetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strcategory = ((DropDownList)newsdetails.Rows[e.RowIndex].Cells[0].Controls[1]).Text;
        string strheading = ((TextBox)newsdetails.Rows[e.RowIndex].Cells[1].Controls[1]).Text;
        string strdescription = ((TextBox)newsdetails.Rows[e.RowIndex].Cells[2].Controls[1]).Text;
        string strrunstatus = ((DropDownList)newsdetails.Rows[e.RowIndex].Cells[3].Controls[1]).SelectedValue;
        string strpriority = ((DropDownList)newsdetails.Rows[e.RowIndex].Cells[4].Controls[1]).SelectedValue;
        int code = (int)newsdetails.DataKeys[e.RowIndex].Value;

        sqlstr = "UPDATE NEWSROOM SET category='" + strcategory.Replace("'", "''") + "', heading='" + strheading.Replace("'", "''") + "',description='" + strdescription.Replace("'", "''") + "',run_status=" + strrunstatus + ", priority=" + strpriority + " WHERE id=" + code + "";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        newsdetails.EditIndex = -1;
        bindgrid();
    }
    //========================================================================================================================================   
}
//========================================================================================================================================
