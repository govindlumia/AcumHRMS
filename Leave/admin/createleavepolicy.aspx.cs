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

public partial class Leave_admin_createleavepolicy : System.Web.UI.Page
{
    string policy_file_name = "1.pdf";
    string policy_file_type = ".pdf";

    string sqlstr;
  
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
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {        
        if (Page.IsValid)
        {
            string filename;

            filename = System.IO.Path.GetFileName(fupload.PostedFile.FileName.ToString());
            if (filename != "")
            {
                policy_file_name = txt_policy.Text + System.DateTime.Now.GetHashCode().ToString();
                fupload.PostedFile.SaveAs(Server.MapPath("../../upload/policydockit/" + policy_file_name + System.IO.Path.GetExtension(fupload.PostedFile.FileName)));
                policy_file_name = policy_file_name + System.IO.Path.GetExtension(fupload.PostedFile.FileName);
                policy_file_type = System.IO.Path.GetExtension(fupload.PostedFile.FileName);
                ViewState.Add("policy_file_name", policy_file_name.ToString());
                ViewState.Add("policy_file_type", policy_file_type.ToString());
            }

          else
            {
                ViewState.Add("policy_file_name", policy_file_name.ToString());
                ViewState.Add("policy_file_type", policy_file_type.ToString());
            }
        }
        else
        {
            ViewState.Add("policy_file_name", policy_file_name.ToString());
            ViewState.Add("policy_file_type", policy_file_type.ToString());
        }

        SqlParameter[] sqlparm = new SqlParameter[8];
        sqlparm[0] = new SqlParameter("@policyname", SqlDbType.VarChar, 100);
        sqlparm[0].Value = txt_policy.Text.ToString().Trim();

        sqlparm[1] = new SqlParameter("@policydescription", SqlDbType.VarChar, 2000);
        sqlparm[1].Value = txt_policy_desc.Text.ToString().Trim();

        sqlparm[2] = new SqlParameter("@policy_file_name", SqlDbType.VarChar, 200);
        sqlparm[2].Value = ViewState["policy_file_name"].ToString();

        sqlparm[3] = new SqlParameter("@policy_file_type", SqlDbType.VarChar, 100);
        sqlparm[3].Value = ViewState["policy_file_type"].ToString();

        sqlparm[4] = new SqlParameter("@date", SqlDbType.DateTime);
        sqlparm[4].Value = DateTime.Today;

        sqlparm[5] = new SqlParameter("@createdate", SqlDbType.DateTime);
        sqlparm[5].Value = DateTime.Now;

        sqlparm[6] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
        sqlparm[6].Value = Session["name"].ToString();

        sqlparm[7] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
        sqlparm[7].Value = Session["name"].ToString();

        //sqlstr = "insert into tbl_leave_createleavepolicy(policyname,policydescription,policy_file_name,policy_file_type,date,createdby,createddate,modifiedby)values('" + txt_policy.Text + "','"+txt_policy_desc.Text.Trim().ToString().Replace("'","''")+"','" + ViewState["policy_file_name"].ToString() + "','" + ViewState["policy_file_type"].ToString() + "','" + DateTime.Today + "','" + Session["name"].ToString() + "','" + System.DateTime.Now + "','" + Session["name"].ToString() + "')";
        int a = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure,"sp_leave_createleave_policy",sqlparm);

        
        if (a > 0)
        {
            message.InnerHtml = "Leave policy created successfully";
        }
        else
        {
            message.InnerHtml = "Leave policy name already exists please try other";
        }
        reset();
    }

    public void reset()
    {
        txt_policy.Text = "";
        txt_policy_desc.Text = "";
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        reset();
    }
}

