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
using Utilities;
public partial class leave_applyot : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;
    DataTable dtable = new DataTable();
    DataView dview;
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                //    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            Session.Remove("ot");
            bindemp_formgr();
            btn_approve.Enabled = false;
        }
    }
    protected void bindemp_formgr()
    {
        if (Session["empcode"] != null)
        {
            sqlstr = @"select distinct h.employeecode as empcode,
                        coalesce(m.emp_fname,'') + ' ' + coalesce(m.emp_m_name,'') + ' ' + coalesce(m.emp_l_name,'') as name,
                        m.degination_id,tbl_intranet_designation.designationname,
                        m.dept_id,tbl_internate_departmentdetails.department_name,
                    m.branch_id,tbl_intranet_branch_detail.branch_name   
                    from tbl_leave_employee_hierarchy h
                    INNER JOIN tbl_intranet_employee_jobDetails m on m.empcode=h.employeecode
                    INNER JOIN tbl_intranet_designation ON m.degination_id=tbl_intranet_designation.id
                    INNER JOIN tbl_internate_departmentdetails ON m.dept_id=tbl_internate_departmentdetails.departmentid
                    INNER JOIN tbl_intranet_branch_detail ON m.branch_id=tbl_intranet_branch_detail.Branch_id
                    where h.approverid='" + Session["empcode"].ToString() + "' ORDER BY name";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            ////-----Add the employee in the drop down list Box-------------------------------
            ddlempcode.Items.Add(new ListItem("---Select Employee---"));
            string empcode, empname;
            ////--------------------------------------------------------------------------
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row1 in ds.Tables[0].Rows)
                {
                    empcode = row1["empcode"].ToString().Trim();
                    empname = row1["name"].ToString().Trim();
                    ddlempcode.Items.Add(new ListItem(Convert.ToString(empcode) + '-' + Convert.ToString(empname), Convert.ToString(empcode)));
                }
            }
        }
        else
        {
            message.InnerHtml = "Your session has been expired. Please login again!";
        }
    }
    //----------------------------------------creating table-----------------------------------------
    protected void create_ot_table()
    {
        dtable = new DataTable();
        dtable.Columns.Add("oddate", typeof(string));
        dtable.Columns.Add("empcode", typeof(string));
        dtable.Columns.Add("empname", typeof(string));
        dtable.Columns.Add("noofhours", typeof(Int32));
        dtable.Columns.Add("dept_id", typeof(Int32));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["oddate"], dtable.Columns["empcode"] };
        Session["ot"] = dtable;
    }
    //----------------------------------------clicking on ADD button---------------------------------
    protected void btnadd_Click(object sender, EventArgs e)
    {
            sqlstr = "SELECT dept_id FROM tbl_intranet_employee_jobDetails WHERE empcode='" + Session["empcode"].ToString() + "'";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            int dept_id = Convert.ToInt32(ds.Tables[0].Rows[0]["dept_id"].ToString());

        DataRow dr;
        if (Session["ot"] == null)
        {
            create_ot_table();
        }
        dtable = (DataTable)Session["ot"];

        object[] keyArrary = new object[2];
        keyArrary[0] = Utilities.Utility.dataformat(txtdate.Text).ToString("MM/dd/yyyy");
        keyArrary[1] = ddlempcode.SelectedValue;
        DataRow drfind = dtable.Rows.Find(keyArrary);
        if (drfind != null)
        {
            message.InnerHtml = "You can not add same employee code and date.";
        }
        else
        {
            dr = dtable.NewRow();            
            dr["oddate"] = Utilities.Utility.dataformat(txtdate.Text.ToString()).ToString("MM/dd/yyyy");
            dr["empcode"] = ddlempcode.SelectedValue;
            dr["empname"] = ddlempcode.SelectedItem.Text;
            dr["noofhours"] = Convert.ToInt32(txtnoofhour.Text);
            dr["dept_id"] = dept_id;
            dtable.Rows.Add(dr);
        }
        reset();
        Session["ot"] = dtable;
        bindotdetails();
        btn_approve.Enabled = true;
    }
    //----------------------------------Binding------------------------------------------
    protected void bindotdetails()
    {
        if (Session["ot"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["ot"];
            dview = new DataView(dtable);
            dview.Sort = "empcode";
        }
        otgrid.DataSource = dview;
        otgrid.DataBind();
    }
    protected void reset()
    {
   
        Session.Remove("ot");
        txtdate.Text = "";
        txtnoofhour.Text = "";
        ddlempcode.SelectedIndex = -1;
        otgrid.DataSource = null;
        otgrid.DataBind();
    }
    protected void otgrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["ot"];

        object[] keyArrary = new object[2];
        keyArrary[0] = otgrid.DataKeys[e.RowIndex][0].ToString();
        keyArrary[1] = otgrid.DataKeys[e.RowIndex][1].ToString();
        
        DataRow drfind_id = dtable.Rows.Find(keyArrary);
        if (drfind_id != null)
        {
            drfind_id.Delete();
            Session["ot"] = dtable;
            bindotdetails();
        }
    }
    protected void otgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        otgrid.PageIndex = e.NewPageIndex;
        bindotdetails();
    }
    protected void otgrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        dtable = (DataTable)Session["ot"];

        object[] keyArrary = new object[2];
        keyArrary[0] = otgrid.DataKeys[e.RowIndex][0].ToString();
        keyArrary[1] = otgrid.DataKeys[e.RowIndex][1].ToString();

        DataRow drfind = dtable.Rows.Find(keyArrary);
        if (drfind != null)
        {
            drfind.BeginEdit();
            drfind["noofhours"] = ((TextBox)otgrid.Rows[e.RowIndex].Cells[2].Controls[1]).Text;
            otgrid.EditIndex = -1;
            Session["ot"] = dtable;
            bindotdetails();
        }
    }

    protected void otgrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        otgrid.EditIndex = e.NewEditIndex;
        bindotdetails();
    }

    protected void btn_approve_Click(object sender, EventArgs e)
    {
        insertdetailot();
        message.InnerHtml = "Good work reward has been successfully sent to admin for approval";
        reset();
    }


    protected void insertdetailot()
    {
        if (Session["ot"] != null)
        {
            dtable = (DataTable)Session["ot"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                ViewState["noofhours"] = Convert.ToInt32(ViewState["noofhours"]) + Convert.ToInt32(dtable.Rows[i]["noofhours"]);
            }
            SqlParameter[] newparameter1 = new SqlParameter[6];

            newparameter1[0] = new SqlParameter("@dept_id", SqlDbType.Int);
            newparameter1[0].Value = Convert.ToInt32(dtable.Rows[0]["dept_id"].ToString());

            newparameter1[1] = new SqlParameter("@date", SqlDbType.DateTime);
            newparameter1[1].Value = Convert.ToDateTime(dtable.Rows[0]["oddate"].ToString());

            newparameter1[2] = new SqlParameter("@total_hours", SqlDbType.Int);
            newparameter1[2].Value = Convert.ToInt32(ViewState["noofhours"]);

            newparameter1[3] = new SqlParameter("@createdby", SqlDbType.VarChar,50);
            newparameter1[3].Value = Session["name"].ToString();

            newparameter1[4] = new SqlParameter("@createddate", SqlDbType.DateTime);
            newparameter1[4].Value = System.DateTime.Now;

            newparameter1[5] = new SqlParameter("@empcode", SqlDbType.VarChar,50);
            newparameter1[5].Value = Session["empcode"].ToString();

            DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_insert_dep_overtime", newparameter1);

            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                SqlParameter[] newparameter = new SqlParameter[4];

                newparameter[0] = new SqlParameter("@oddate", SqlDbType.DateTime);
                newparameter[0].Value = Convert.ToDateTime(dtable.Rows[i]["oddate"].ToString());

                newparameter[1] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                newparameter[1].Value = dtable.Rows[i]["empcode"].ToString();

                newparameter[2] = new SqlParameter("@noofhours", SqlDbType.Int);
                newparameter[2].Value = dtable.Rows[i]["noofhours"].ToString();

                newparameter[3] = new SqlParameter("@dep_ot_id", SqlDbType.Int);
                newparameter[3].Value = Convert.ToInt32(ds1.Tables[0].Rows[0][0]);
                
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_insert_employee_overtime", newparameter);
            }
            ViewState["noofhours"] = 0;
        }
    }
    
    protected void otgrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        otgrid.EditIndex = -1;
        bindotdetails();
    }
}
