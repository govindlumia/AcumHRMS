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
using System.Data.SqlClient;
using DataAccessLayer;

public partial class leave_admin_updatepolicy : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    string policy_file_name = "1.pdf";
    string policy_file_type = ".pdf";
    
    
    protected void Page_Load(object sender, EventArgs e)
    {        
        
        message.InnerHtml = "";

        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");

            fillcssdata();
        }
    }

    //protected void ddlvtype_DataBound(object sender, EventArgs e)
    //{
    //    ddlvtype.Items.Insert(0, new ListItem("----Select Leave----", "0"));
    //}

    protected void fillcssdata()
    {
        sqlstr = "select policyid,policyname,policydescription,policy_file_name,policy_file_type,date from tbl_leave_createleavepolicy where policyid=" + Request.QueryString["policyid"].ToString() + "";

        SqlParameter sqlparm = new SqlParameter("@policyid", SqlDbType.Int);
        sqlparm.Value = Request.QueryString["policyid"].ToString();

        try
        {
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);         
            txt_policy.Text = ds.Tables[0].Rows[0]["policyname"].ToString(); 
            txt_policy_desc.Text = ds.Tables[0].Rows[0]["policydescription"].ToString();
            lbl_file.Text = (ds.Tables[0].Rows[0]["policy_file_type"].ToString() != "") ? "<a href='../../upload/policydockit/" + ds.Tables[0].Rows[0]["policy_file_name"].ToString() +
                "'>" + ds.Tables[0].Rows[0]["policy_file_name"].ToString() + "</a>" : "No exisitng file found";
            prvimg.Value = ds.Tables[0].Rows[0]["policy_file_name"].ToString();

        }
        catch (Exception ex)
        {
            //message.InnerHtml = "";
            //Utilities.LogError(ex);
        }
    }
    //public void bindpolicy()
    //{
    //    string sqlstr = "select distinct * from tbl_leave_createleavepolicy where policyid=" + Request.QueryString["policyid"].ToString() + "";
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);


    //}
 
    protected void uploadfile()
    {
        string filename;

        filename = System.IO.Path.GetFileName(fupload.PostedFile.FileName.ToString());
        if (filename != "")
        {
            fupload.PostedFile.SaveAs(Server.MapPath("../../") + "/upload/policydockit/" + filename);
            if (prvimg.Value != "")
                System.IO.File.Delete(Server.MapPath("../../") + "/upload/" + prvimg.Value);
        }
        else
        {
            filename = prvimg.Value;
        }

        sqlstr = "update tbl_leave_createleavepolicy set policyname=@policyname,policydescription=@policydescription,policy_file_name=@policy_file_name,date=@date where policyid=@policyid";
        SqlParameter[] sqlparm = new SqlParameter[5];

        sqlparm[0] = new SqlParameter("@policyname", SqlDbType.VarChar, 100);
        sqlparm[0].Value = txt_policy.Text.ToString();

        sqlparm[1] = new SqlParameter("@policy_file_name", SqlDbType.VarChar, 200);
        sqlparm[1].Value = filename;

        sqlparm[2] = new SqlParameter("@date", SqlDbType.DateTime);
        sqlparm[2].Value = System.DateTime.Now;

        sqlparm[3] = new SqlParameter("@policyid", SqlDbType.Int);
        sqlparm[3].Value = Request.QueryString["policyid"].ToString();

        sqlparm[4]=new SqlParameter("@policydescription",SqlDbType.VarChar,2000);
        sqlparm[4].Value = txt_policy_desc.Text.ToString();

        try
        {
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr, sqlparm);
        }
        catch (Exception ex)
        {
            //Utilities.LogError(ex);
            //Response.Redirect("viewcss.aspx?updated=0");
        }
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        uploadfile();
        Response.Redirect("editleavepolicy.aspx?updated=true");
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("editleavepolicy.aspx");
    }    
}


