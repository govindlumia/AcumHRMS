//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
using HRMS.BusinessLogic.Leave;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Leave_report_calendarview : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        BuildSocialEventTable();
        Calendar1.TodaysDate = System.DateTime.Now;

        //if (!IsPostBack)
        //{           

        //}
        GridView1.Visible = false;
    }



    private void BuildSocialEventTable()
    {
        // to simulate a database query
        socialEvents = new DataTable();
        socialEvents.Columns.Add(new DataColumn("Date", typeof(DateTime)));
        socialEvents.Columns.Add(new DataColumn("Description", typeof(string)));


        DataRow row;
        row = socialEvents.NewRow();
        row["Date"] = DateTime.Now.AddDays(-5);
        row["Description"] = "Bithday party at Rajeev house";

        socialEvents.Rows.Add(row);

        row = socialEvents.NewRow();
        row["Date"] = DateTime.Now.AddDays(3);
        row["Description"] = "farewell party";

        socialEvents.Rows.Add(row);

        row = socialEvents.NewRow();
        row["Date"] = DateTime.Now.AddDays(7);
        row["Description"] = "C# corner meet ";

        socialEvents.Rows.Add(row);

        row = socialEvents.NewRow();
        row["Date"] = DateTime.Now.AddDays(7);
        row["Description"] = "Brazil Vs. France";

        socialEvents.Rows.Add(row);
        row = socialEvents.NewRow();
        row["Date"] = DateTime.Now.AddDays(7);
        row["Description"] = "Indian cricket team in london starts practice match";

        socialEvents.Rows.Add(row);
    }

    private void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {

        CommonBAL balObj = new CommonBAL();
        Literal l = new Literal(); //Creating a literal  
        l.Visible = true;
        l.Text = "<br/>"; //for breaking the line in cell  
        e.Cell.Controls.Add(l); //adding in all cell  

        //da = new SqlDataAdapter("select * from Events", con);
        DataTable dt_result = new DataTable();
        dt_result = balObj.getCurrentEventDetails();

        if (e.Day.IsOtherMonth)
        {
            e.Cell.Controls.Clear();
            e.Cell.Text = string.Empty;
        }
        foreach (DataRow dr in dt_result.Rows)
        {
            string x = dr[1].ToString();

            if ((dr[1].ToString() == e.Day.Date.ToString() ) || (dr[2].ToString() == e.Day.Date.ToString() ) ) //comparision  
            {
               
                Label lb = new Label();
                lb.Visible = true;
                lb.Text = dr[0].ToString() + "<br/>";

                Label lb2 = new Label();
                lb2.Visible = true;
                //lb2.Text = dr[3].ToString();

                //Label lb3 = new Label();
                //lb3.Visible = true;

                string a = lb.Text;
              
                string ax = lb2.Text;
              
                if (e.Day.IsOtherMonth)
                {
                    e.Cell.Controls.Clear();
                    e.Cell.Text = string.Empty;
                }
                else
                {
                    e.Cell.Controls.Add(lb);
                    e.Cell.Controls.Add(lb2);
                    e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#ead9d9");
                }
                
            }
        }
    }

    private void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        CommonBAL balObj = new CommonBAL();
        DataTable dt_result = new DataTable();
        dt_result = balObj.getCurrentEventDetails();

        System.Data.DataView view = dt_result.DefaultView;
        string startDate = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
        string endDate = Calendar1.SelectedDate.AddDays(1).ToString("yyyy/MM/dd");
        DataView dataView = dt_result.DefaultView;

        // Changed here by keerti dwivedi for from and to date reason.... on 07 july 2018
        dataView.RowFilter = "fromdate >= #" + startDate + "# AND fromdate <= #" + endDate + "#"  + "OR " + "todate >= #" + startDate + "# AND todate <= #" + endDate + "#";
                                                 

        if (dataView.Count > 0)
        {
            GridView1.Visible = true;
            GridView1.DataSource = dataView;
            GridView1.DataBind();
        }
        else
        {
            GridView1.Visible = false;
        }

    }

    private DataTable socialEvents;

    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.Calendar1.DayRender += new System.Web.UI.WebControls.DayRenderEventHandler(this.Calendar1_DayRender);
        this.Calendar1.SelectionChanged += new System.EventHandler(this.Calendar1_SelectionChanged);
        this.Load += new System.EventHandler(this.Page_Load);

    }

    #endregion
}


