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
using System.Globalization;
using Utilities;
using System.Data.SqlClient;
using InfoSoftGlobal;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;

public partial class leave_report_dept_attendance : System.Web.UI.Page
{
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_sdate.Attributes.Add("readonly", "readonly");
        txt_edate.Attributes.Add("readonly", "readonly");
        if (!IsPostBack)
        {
            FillControl();
            //CLiteral.Text = bindmanpower();
        }
    }

    protected void chk_temp_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_temp.Checked == true)
        {
            date.Visible = false;
            template.Visible = true;
            RequiredFieldValidator3.Enabled = false;
            RequiredFieldValidator11.Enabled = false;
        }
        else
        {
            date.Visible = true;
            template.Visible = false;
            RequiredFieldValidator3.Enabled = true;
            RequiredFieldValidator11.Enabled = true;
        }
    }

    protected void FillControl()
    {
        CommonBusiness commonBusiness = new CommonBusiness();
        BindDropDowns(drp_comp_name, commonBusiness.BindDropDowns("", "Company"), "companyid", "companyname");
    }
    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected string bindmanpower()
    {
        DateTime dt = DateTime.Now;
        DateTime sdate = new DateTime();
        DateTime edate = new DateTime();
        if (chk_temp.Checked)
        {
            //current week
            if (drp_template.SelectedValue == "0")
            {
                //dt = DateTime.Today;
                while (dt.DayOfWeek.ToString() != "Monday")
                    dt = dt.AddDays(-1);
                sdate = dt;
                edate = sdate.AddDays(6);

            }
            //previous week
            if (drp_template.SelectedValue == "1")
            {
                while (dt.DayOfWeek.ToString() != "Monday")
                    dt = dt.AddDays(-1);
                sdate = dt.AddDays(-7);
                edate = sdate.AddDays(6);
            }
            //next week
            //if (drp_template.SelectedValue == "2")
            //{
            //    while (dt.DayOfWeek.ToString() != "Monday")
            //        dt = dt.AddDays(-1);
            //    sdate = dt.AddDays(7);
            //    edate = sdate.AddDays(6);
            //}

            if (drp_template.SelectedValue == "2")
            {
                int currentmonth;
                DateTime firstday, lastday;
                currentmonth = dt.Month;
                firstday = Convert.ToDateTime(currentmonth + "/1/" + DateTime.Today.Year);
                lastday = firstday.AddMonths(1).AddDays(-1);

                sdate = Convert.ToDateTime(DateTime.Today.Month.ToString() + "/1/" + DateTime.Today.Year.ToString());
                edate = lastday;
            }

            if (drp_template.SelectedValue == "3")
            {
                int currentmonth;
                DateTime firstday, lastday;
                currentmonth = dt.Month;
                firstday =Convert.ToDateTime(currentmonth + "/1/" + DateTime.Today.Year);
                lastday = firstday.AddDays(-1);
                
                if (DateTime.Today.Month == 1)
                {
                    sdate = Convert.ToDateTime("12/1/" + (DateTime.Today.Year - 1));
                    edate = lastday;
                }
                else
                {
                    sdate = Convert.ToDateTime((DateTime.Today.Month - 1) + "/1/" + DateTime.Today.Year.ToString());
                    edate = lastday;
                }
            }
            //if (drp_template.SelectedValue == "5")
            //{
            //    sdate = Convert.ToDateTime((DateTime.Today.Month + 1) + "/1/" + DateTime.Today.Year.ToString());
            //    edate = Convert.ToDateTime((DateTime.Today.Month + 1) + "/30/" + DateTime.Today.Year.ToString());
            //}
            txt_sdate.Text = sdate.ToShortDateString();
            sdate = Utility.dataformat(txt_sdate.Text.ToString());
            txt_edate.Text = edate.ToShortDateString();
            edate = Utility.dataformat(txt_edate.Text.ToString());
        }
        else
        {
            sdate = Utility.DateTimeForat(txt_sdate.Text.ToString());
            edate = Utility.DateTimeForat(txt_edate.Text.ToString());
        }

        //DateTime fromdate = new DateTime(2009, 11, 24);
        //DateTime todate = new DateTime(2009, 11, 24);

        SqlParameter[] arrParam = new SqlParameter[4];
        arrParam[0] = new SqlParameter("@fromdate", SqlDbType.DateTime);
        arrParam[0].Value = sdate;

        arrParam[1] = new SqlParameter("@todate", SqlDbType.DateTime);
        arrParam[1].Value = edate;

        arrParam[2] = new SqlParameter("@companyid", SqlDbType.Int);
        arrParam[2].Value = drp_comp_name.SelectedValue;

        arrParam[3] = new SqlParameter("@emp_status_check", SqlDbType.Bit);
        arrParam[3].Value = chk_empstatus.Checked;

        //string strsql = "select l.leavetype,c.entitled_days from tbl_leave_employee_leave_master c inner join tbl_leave_createleave l on l.leaveid=c.leaveid where c.empcode='" + Request.QueryString["empcode"].ToString() + "'";
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_leave_attendance_reprot_department", arrParam);
        manhourgrid.DataSource = ds;
        manhourgrid.DataBind();
        //Generate the graph element
        string categories = "";
        string strsql = "<graph caption='" + drp_comp_name.SelectedItem.Text + "' numberSuffix='%' yAxisMaxValue='100' formatNumberScale='0' decimalPrecision='0'><categories>";
        string strPresent = "";
        string strAbsent = "";
        //.Replace(" ", "&lt;BR&gt;")
        for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
        {
            categories = categories + "<category name='" + ds.Tables[0].Rows[i]["Category_name"].ToString() + "' />";
            strPresent = strPresent + "<set value='" + ds.Tables[0].Rows[i]["Percentage"].ToString() + "' />";
            strAbsent = strAbsent + "<set value='" + ds.Tables[0].Rows[i]["AbsentP"].ToString() + "' />";
        }
        //return strsql;
        int width = 100 + Convert.ToInt32(ds.Tables[0].Rows.Count) * 100;
        strsql = strsql + categories + "</categories>";
        strsql = strsql + "<dataset seriesName='Present' color='AFD8F8'>" + strPresent + "</dataset>";
        strsql = strsql + "<dataset seriesName='Absent' color='F6BD0F'>" + strAbsent + "</dataset>";
        strsql = strsql + "</graph>";
        //return FusionCharts.RenderChart("../FusionChat/FCF_Column3D.swf", "", strsql, "NEGI", "1500", "450", false, false);
        return FusionCharts.RenderChart("../FusionChat/FCF_StackedColumn3D.swf", "", strsql, "NEGI", width.ToString(), "450", false, false);




        //string strsql = "<graph caption='" + drp_comp_name.SelectedItem.Text + "' subCaption='Department Wise' yAxisMaxValue='100' decimalPrecision='0' showNames='1' showvalue='0' showPercentageValues='1'  numberSuffix=' %' pieSliceDepth='100' formatNumberScale='1'>";
        //for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
        //{
        //    strsql = strsql + "<set name='" + ds.Tables[0].Rows[i]["department_name"].ToString() + "' value='" + ds.Tables[0].Rows[i]["Percentage"].ToString() + "' />";
        //}
        ////return strsql;
        //strsql = strsql + "</graph>";
        ////return FusionCharts.RenderChart("FusionChat/FCF_line.swf", "", strsql, "NEGI", "650", "1000", false, false);
        ////return FusionCharts.RenderChart("../FusionChat/FCF_" + Request.QueryString["type"].ToString() + ".swf", "", strsql, "NEGI", "2000", "450", false, false);
        //return FusionCharts.RenderChart("../FusionChat/FCF_Column3D.swf", "", strsql, "NEGI", "1500", "450", false, false);

    }
    
    protected void btn_search_OnClick(object sender, EventArgs e)
    {
        CLiteral.Text = bindmanpower();
    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {

    }
    
    protected void manhourgrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }

   
}
