using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using InfoSoftGlobal;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CLiteral.Text = CreateChart();
    }
    public string CreateChart()
        
    {
        DateTime fromdate = new DateTime(2009, 11, 24);
        DateTime todate = new DateTime(2009, 11, 24);

        SqlParameter[] arrParam = new SqlParameter[2];
        arrParam[0] = new SqlParameter("@fromdate", SqlDbType.DateTime);
        arrParam[0].Value = fromdate;

        arrParam[1] = new SqlParameter("@todate", SqlDbType.DateTime);
        arrParam[1].Value = todate;

        //string strsql = "select l.leavetype,c.entitled_days from tbl_leave_employee_leave_master c inner join tbl_leave_createleave l on l.leaveid=c.leaveid where c.empcode='" + Request.QueryString["empcode"].ToString() + "'";
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ToString(), CommandType.StoredProcedure, "sp_leave_attendance_reprot_department", arrParam);
    
            //Generate the graph element
        string strsql = "<graph caption='Average Attendance' subCaption='Department Wise' yAxisMaxValue='100' decimalPrecision='0' showNames='1' showvalue='0' showPercentageValues='1'  numberSuffix=' %' pieSliceDepth='100' formatNumberScale='1'>";

        for(int i=0;i<=ds.Tables[0].Rows.Count -1;i++)
        {
            strsql = strsql + "<set name='" + ds.Tables[0].Rows[i]["department_name"].ToString() + "' value='" + ds.Tables[0].Rows[i]["Percentage"].ToString() + "' />";
        }
        //return strsql;
       strsql = strsql + "</graph>";
       //return FusionCharts.RenderChart("FusionChat/FCF_line.swf", "", strsql, "NEGI", "650", "1000", false, false);
       //return FusionCharts.RenderChart("../FusionChat/FCF_" + Request.QueryString["type"].ToString() + ".swf", "", strsql, "NEGI", "2000", "450", false, false);
       return FusionCharts.RenderChart("../FusionChat/FCF_Column3D.swf", "", strsql, "NEGI", "2000", "450", false, false);
       
        //'Create the chart - Pie 3D Chart with data from strXML,FCF_Column2D,FCF_Pie3D,FCF_Area2D
        //return FusionCharts.RenderChart("../FusionCharts/FCF_line.swf", "", strXML, "FactorySum", "650", "450", False, False)
    
    
    }
}
