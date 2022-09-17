using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using DataAccessLayer;
using System.Web;
using System.Web.Mail;
using Utilities;

public partial class leave_admin_leave_not_approved : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else Response.Redirect("~/notlogged.aspx");
        }
    }


    protected void bindempdetail()
    {
        SqlParameter[] sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 150);
        sqlparam[0].Value = txt_employee.Text.Trim().ToString();

        sqlparam[1] = new SqlParameter("@desig", SqlDbType.Int);
        sqlparam[1].Value = dd_designation.SelectedValue;

        sqlparam[2] = new SqlParameter("@dept", SqlDbType.Int);
        sqlparam[2].Value = dd_branch.SelectedValue;

        sqlparam[3] = new SqlParameter("@fromdate", SqlDbType.DateTime);
        sqlparam[3].Value = Utility.dataformat(txt_sdate.Text.ToString());

        sqlparam[4] = new SqlParameter("@todate", SqlDbType.DateTime);
        sqlparam[4].Value = Utility.dataformat(txt_edate.Text.ToString());

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_fetch_employee_leavenotapproved]", sqlparam);
        empgrid.DataSource = ds;
        empgrid.DataBind();
    }

    protected void dd_designation_DataBound(object sender, EventArgs e)
    {
        dd_designation.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        dd_branch.Items.Insert(0, new ListItem("All", "0"));
        //bindempdetail();
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindempdetail();
    }

    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bindempdetail();
    }

    protected void lnkcheckall_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < empgrid.Rows.Count; i++)
        {
            CheckBox checkg = (CheckBox)empgrid.Rows[i].Cells[0].FindControl("checkg");
            if (checkg != null)
            {
                checkg.Checked = true;
            }
        }
    }

    protected void lnkuncheckall_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < empgrid.Rows.Count; i++)
        {
            CheckBox checkg = (CheckBox)empgrid.Rows[i].Cells[0].FindControl("checkg");
            if (checkg != null)
            {
                checkg.Checked = false;
            }
        }
    }

    protected void sendmail()
    {
        try
        {
            int counter = 0;
            foreach (GridViewRow GridView in empgrid.Rows)
            {
                CheckBox checkg = (CheckBox)GridView.FindControl("checkg");

                if (checkg.Checked)
                {
                    string strempcode, mailto, mailbody;
                    strempcode = ((Label)empgrid.Rows[counter].FindControl("lblempcodeg")).Text;

                    sqlstr = @"select email_id from tbl_intranet_employee_personalDetails p
                                INNER JOIN tbl_leave_employee_hierarchy h ON p.empcode=h.approverid 
                                WHERE employeecode='" + strempcode.Trim().ToString() + "' AND email_id IS NOT NULL AND hr=0 ORDER BY approverpriority DESC";
                    //sqlstr = "SELECT email_id FROM tbl_intranet_employee_personalDetails WHERE empcode='" + strempcode.Trim().ToString() + "' and email_id is not null";
                    DataSet ds5 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

                    if (ds5.Tables[0].Rows.Count > 0)
                    {
                        mailto = ds5.Tables[0].Rows[0]["email_id"].ToString().Trim();
                        if (mailto.Trim() != "")
                        {
                            SqlParameter[] sqlparam;
                            sqlparam = new SqlParameter[3];
                            sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                            sqlparam[0].Value = strempcode;

                            MailMessage mail = new MailMessage();
                            mailbody = "";
                            mail.From = "hrms@ykkindia.com";
                            mail.To = mailto;
                            mail.Subject = "Please Approve Leave";
                            mail.BodyFormat = MailFormat.Text;
                            mail.Body = "Dear Sir/Madam";

                            mail.Body = mail.Body + "<br />Please login in HRMS and approve leave pending from your side.";
                            mail.Body = mail.Body + "<br /> <br /><br />Thanks & Regards ";
                            mail.Body = mail.Body + "<br /> Arun Agrawal(GA & HR)";
                            //System.IO.StreamWriter sw = new System.IO.StreamWriter(Server.MapPath(".") + "/upload/salaryslip.html");

                            //sw.WriteLine(mailbody);

                            //sw.Close();
                            //MailAttachment attachMail = new MailAttachment(Server.MapPath(".") + "/upload/salaryslip.html");
                            //mail.Attachments.Add(attachMail);
                            //SmtpMail.SmtpServer = "localhost";
                            SmtpMail.SmtpServer = "10.247.2.2";
                            SmtpMail.Send(mail);
                        }
                    }
                }
                counter = counter + 1;
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnsend_Click(object sender, EventArgs e)
    {
        sendmail();
    }

}