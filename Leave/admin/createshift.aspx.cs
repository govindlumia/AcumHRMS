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

public partial class Leave_admin_createshift : System.Web.UI.Page
{
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    DataSet ds = new DataSet();
    public int i, ptr1, ptr2;
    string sqlstr, sqlstr1, str_contry_name, str_contry_name1;

    protected void Page_Load(object sender, EventArgs e)
    {
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

        this.Image1.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txtstime'))");
        this.Image2.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txtetime'))");
    }
        
    protected void imgtime_Click(object sender, ImageClickEventArgs e)
    {
        this.Image1.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txtstime').toString())");
        this.Image2.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txtetime').toString())");
    }

    protected void imgtime_Click1(object sender, ImageClickEventArgs e)
    {
        
    }
 
    protected void ddbranch_DataBound(object sender, EventArgs e)
    {
        ddbranch_id.Items.Insert(0, new ListItem("-----Select Branch-----", "0"));        
    }

    public void clearfield()
    {
        txtetime.Text = "";
        txtstime.Text = "";
        txtshift.Text = "";
        txtshiftDesc.Text = "";
        chknightallowance.Checked = true;
    }
        
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        bl_navigation.create_shift_master(txtshift.Text,0, txtstime.Text, txtetime.Text, txtshiftDesc.Text, Session["name"].ToString(), System.DateTime.Now, Session["name"].ToString(),Convert.ToBoolean(chknightallowance.Checked), ref i);

        if (i <= 0)
        {
            message.InnerHtml = "Shift already exists, try again.";
        }
        else
        {
            message.InnerHtml = "New shift has been created successfully.";
            clearfield();
        }
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        clearfield();
    }
}
   

