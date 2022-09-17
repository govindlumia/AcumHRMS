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
            bindgrid();
        }
        message.InnerHtml = "";
    }

    //========================================================================================================================================
    protected void bindgrid()
    {
        sqlstr = "SELECT TOP 10 ID,LINKTITLE,URL,CATEGORY,(CASE WHEN run_status=1 THEN 'Running' ELSE 'Stopped' END)run_status,run_status run_status1,(CASE WHEN priority=0 THEN 'Low' WHEN priority=1 THEN 'Medium' ELSE 'High' END)priority,priority priority1 FROM LINKS WHERE CATEGORY='Helpful Link' ";
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
            SqlParameter[] newparameter = new SqlParameter[2];

            newparameter[0] = new SqlParameter("@LinkTitle", SqlDbType.VarChar, 50);
            newparameter[0].Value = txtheading.Text.Trim().ToString();

            newparameter[1] = new SqlParameter("@Url", SqlDbType.VarChar, 100);
            newparameter[1].Value = "https://" + txtdescription.Text.Trim().ToString();

          

            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "intranet_insert_helpful_sp", newparameter);
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
        sqlstr = "DELETE FROM links WHERE id=" + code;
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
        string txtheadingg = ((TextBox)newsdetails.Rows[e.RowIndex].Cells[0].Controls[1]).Text;
        string txtdescriptiong = ((TextBox)newsdetails.Rows[e.RowIndex].Cells[1].Controls[1]).Text;
        string strrunstatus = ((DropDownList)newsdetails.Rows[e.RowIndex].Cells[2].Controls[1]).SelectedValue;
        string strpriority = ((DropDownList)newsdetails.Rows[e.RowIndex].Cells[3].Controls[1]).SelectedValue;
        int code = (int)newsdetails.DataKeys[e.RowIndex].Value;

        sqlstr = "UPDATE links SET category='Helpful Link', linktitle='" + txtheadingg.Replace("'", "''") + "',url='" + txtdescriptiong.Replace("'", "''") + "',run_status='" + strrunstatus + "' , priority='" + strpriority + "' WHERE id=" + code + "";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        newsdetails.EditIndex = -1;
        bindgrid();
    }
    //========================================================================================================================================   
}
//========================================================================================================================================
