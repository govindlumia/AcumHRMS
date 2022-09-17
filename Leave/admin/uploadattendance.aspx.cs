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
using Utilities;
using System.Data.SqlClient;
using System.Text;

public partial class leave_admin_uploadattendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_from.Attributes.Add("readonly", "readonly");
        txt_to.Attributes.Add("readonly", "readonly");
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
        message.InnerHtml = "";
    }

    protected void worddocument()
    {
     
        string fn = System.IO.Path.GetFileName(fupload.PostedFile.FileName);
        if (fupload.PostedFile.FileName != "")
        {
            try
            {
                string ftype = System.IO.Path.GetExtension(fn);
                switch (ftype)
                {
                    case ".CSV":
                        {
                            fupload.PostedFile.SaveAs(Server.MapPath("~") + "\\upload\\" + fn);
                            System.IO.StreamReader StreamReader1 = new System.IO.StreamReader(Server.MapPath("~") + "\\upload\\" + fn);

                            txtcode.Text = StreamReader1.ReadToEnd();
                            StreamReader1.Close();
                            int count = splitstring();
                            System.IO.File.Delete(Server.MapPath(".") + "/upload/" + fn);
                            message.InnerHtml = "Attendance file is uploaded successfully!";
                            break;
                        }
                              case ".csv":
                        {
                            fupload.PostedFile.SaveAs(Server.MapPath("~") + "\\upload\\" + fn);
                            System.IO.StreamReader StreamReader1 = new System.IO.StreamReader(Server.MapPath("~") + "\\upload\\" + fn);

                            txtcode.Text = StreamReader1.ReadToEnd();
                            StreamReader1.Close();
                         int count=   splitstring();
                            System.IO.File.Delete(Server.MapPath(".") + "/upload/" + fn);
                            message.InnerHtml = "Attendance file is uploaded successfully!";
                            break;
                        }
                    default:
                        {
                            message.InnerHtml = "";
                            message.InnerHtml = "Only .CSV format files supported.";
                            break;
                        }
                }
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    protected int splitstring()      //Issue while uploading Manual File
    {
        int count = 0;
        string s = txtcode.Text.ToString();
        string day, month, year, inhrtime=string.Empty, inmintime=string.Empty, empcode;
        //
        // Split string on spaces.
        // This will separate all the words.
        //
      //  string[] words = s.Split(new char[] { ' ', ',', '\n', '\r' });
     string[] words=s.Split('\n');
        foreach (string word in words)
        {
            string[] wordSplit = word.Split(',');
            if (wordSplit.Length == 6 || wordSplit.Length==7)
            {
                //day = word.Substring(0, 2);
                //month = word.Substring(2, 2);
                //inhrtime = word.Substring(4, 2);
                //inmintime = word.Substring(6, 2);
                //empcode = word.Substring(8, 5);
                //year = DateTime.Today.Year.ToString();
                year = wordSplit[0].Substring(0, 4);
                month = wordSplit[0].Substring(4, 2);
                day = wordSplit[0].Substring(6, 2);
                if (wordSplit[1].Length == 5)
                {
                    inhrtime = wordSplit[1].Substring(0,1).Trim();
                    inmintime = wordSplit[1].Substring(1,2).Trim();
                }
                else if (wordSplit[1].Length == 6)
                {
                    inhrtime = wordSplit[1].Substring(0, 2).Trim();
                    inmintime = wordSplit[1].Substring(2, 2).Trim();
                }
                    empcode = wordSplit[3].Trim();

                SqlParameter[] sqlparam = new SqlParameter[6];

                sqlparam[0] = new SqlParameter("@day", SqlDbType.VarChar, 10);
                sqlparam[0].Value = day.Trim();

                sqlparam[1] = new SqlParameter("@month", SqlDbType.VarChar, 10);
                sqlparam[1].Value = month.Trim();

                sqlparam[2] = new SqlParameter("@inhrtime", SqlDbType.VarChar, 10);
                sqlparam[2].Value = inhrtime.Trim();

                sqlparam[3] = new SqlParameter("@inmintime", SqlDbType.VarChar, 10);
                sqlparam[3].Value = inmintime.Trim();

                sqlparam[4] = new SqlParameter("@empcode", SqlDbType.VarChar, 10);
                sqlparam[4].Value = empcode.Trim();

                sqlparam[5] = new SqlParameter("@year", SqlDbType.VarChar, 10);
                sqlparam[5].Value = year.Trim();

                int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_insert_attendance_detail", sqlparam);
                count += i;
            }
        }
        return count;
    }
    protected void btn_sbmit_Click(object sender, EventArgs e)
    {
        if ((string.IsNullOrEmpty(txt_to.Text.Trim()) && !string.IsNullOrEmpty(txt_from.Text.Trim())) || (!string.IsNullOrEmpty(txt_to.Text.Trim()) && string.IsNullOrEmpty(txt_from.Text.Trim())))
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "fillboth", "alert('Either fill both dates or clear dates');", true);
            return;
        }
            worddocument();
        callprocessattendance();
    
        }
    protected void callprocessattendance()
    {
        if (!string.IsNullOrEmpty(txt_to.Text.Trim()) && !string.IsNullOrEmpty(txt_from.Text.Trim()))
        {
            SqlParameter[] param=new SqlParameter[2];
            param[0] = new SqlParameter("@startdateback", Convert.ToDateTime(txt_from.Text.Trim()));
            param[1] = new SqlParameter("@enddateback", Convert.ToDateTime(txt_to.Text.Trim()));
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_job_process_employee_attendance_ondailybasis_backmonth",param);
        }
        else
        {
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_job_process_employee_attendance_ondailybasis");
        }
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_JOB_PAYROLL_ATTENDANCEHFDAY1");
    }
    protected void btn_clear_Click(object sender, EventArgs e)
    {
        txt_to.Text = "";
        txt_from.Text = "";
    }
}
