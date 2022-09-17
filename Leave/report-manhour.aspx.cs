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
public partial class leave_report_manhour : System.Web.UI.Page
{
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {

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
                firstday = Convert.ToDateTime(currentmonth + "/1/" + DateTime.Today.Year);
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
            sdate = Utility.dataformat(txt_sdate.Text.ToString());
            edate = Utility.dataformat(txt_edate.Text.ToString());
        }

        SqlParameter[] sqlparm = new SqlParameter[3];

        sqlparm[0] = new SqlParameter("@fromdate", SqlDbType.DateTime,8);
        sqlparm[0].Value = sdate;

        sqlparm[1] = new SqlParameter("@todate", SqlDbType.DateTime, 8);
        sqlparm[1].Value = edate;

        sqlparm[2] = new SqlParameter("@branch", SqlDbType.Int);
        sqlparm[2].Value = drp_comp_name.SelectedValue;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_leave_dep_manhour", sqlparm);
        manhourgrid.DataSource = ds;
        manhourgrid.DataBind();

        //Generate the graph element
        string categories = "";
        string strsql = "<graph caption='" + drp_comp_name.SelectedItem.Text + "' numberSuffix='%' yAxisMaxValue='100' formatNumberScale='0' decimalPrecision='2'><categories>";
        string strWork = "";
        string strCasual = "";
        string strOT = "";
        for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
        {
            categories = categories + "<category name='" + ds.Tables[0].Rows[i]["department_name"].ToString() + "' />";
            strWork = strWork + "<set value='" + ds.Tables[0].Rows[i]["workP"].ToString() + "' />";
            strCasual = strCasual + "<set value='" + ds.Tables[0].Rows[i]["casualP"].ToString() + "' />";
            strOT = strOT + "<set value='" + ds.Tables[0].Rows[i]["otP"].ToString() + "' />";
        }
        //return strsql;
        strsql = strsql + categories + "</categories>";
        strsql = strsql + "<dataset seriesName='Employee' color='F6BD0F'>" + strWork + "</dataset>";
        strsql = strsql + "<dataset seriesName='Casual' color='AFD8F8'>" + strCasual + "</dataset>";
        strsql = strsql + "<dataset seriesName='OT' color='00BD35'>" + strOT + "</dataset>";
        strsql = strsql + "</graph>";
        int width = 100 + Convert.ToInt32(ds.Tables[0].Rows.Count) * 100;
        //strsql="<graph caption='Bawal' numberSuffix='%' yAxisMaxValue='100' formatNumberScale='0' decimalPrecision='0'><categories><category name='Accounts' /><category name='GA & HR' /><category name='MVF Assembly' /><category name='Dyeing' /><category name='Ehs' /><category name='Purchase' /><category name='MVF Chain' /><category name='P.F.Assembly' /><category name='P.F.Chain' /><category name='Planning & Statistics' /><category name='PPL' /><category name='PPL-IT' /><category name='PPL-Despatch' /><category name='Production Technology' /><category name='Quality Control' /><category name='PPL-RMC' /><category name='Slider' /><category name='Utilities' /><category name='Weaving' /><category name='Utility' /></categories><dataset seriesName='Employee' color='AFD8F8'><set value='100' /><set value='100' /><set value='100' /><set value='100' /><set value='100' /><set value='100' /><set value='100' /><set value='100' /><set value='100' /><set value='100' /><set value='100' /><set value='100' /><set value='100' /><set value='100' /><set value='100' /><set value='100' /><set value='100' /><set value='0' /><set value='100' /><set value='100' /></dataset><dataset seriesName='Casual' color='F6BD0F'><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /></dataset><dataset seriesName='OT' color='00BD35'><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /><set value='0' /></dataset></graph>";
        //return FusionCharts.RenderChart("../FusionChat/FCF_Column3D.swf", "", strsql, "NEGI", "1500", "450", false, false);
        //return FusionCharts.RenderChart("../FusionChat/FCF_StackedColumn3D.swf", "", strsql, "NEGI", width.ToString(), "450", false, false);
        return FusionCharts.RenderChart("../FusionChat/FCF_MSColumn3DLineDY.swf", "", strsql, "NEGI", width.ToString(), "450", false, false);

    }
    protected void manhourgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        manhourgrid.PageIndex = e.NewPageIndex;
        bindmanpower();
    }
    protected void manhourgrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.className='hover-clr'");
            e.Row.Attributes.Add("onmouseout", "this.className='out-clr-1'");
        }
    }
    protected void btn_search_OnClick(object sender, EventArgs e)
    {
      
        CLiteral.Text = bindmanpower();
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {

    }
    protected void drp_comp_name_DataBound(object sender, EventArgs e)
    {
        drp_comp_name.Items.Insert(0, new ListItem("--Select branch--", "0"));
    }
}
