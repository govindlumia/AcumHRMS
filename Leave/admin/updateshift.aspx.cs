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

public partial class Leave_admin_updateshift : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds=new DataSet();
    public int i, ptr1, ptr2;
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();

    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        txtstime.Attributes.Add("ReadOnly", "ReadOnly");
        txtetime.Attributes.Add("ReadOnly", "ReadOnly");
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            bindshift();
           
            this.Image1.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txtstime'))");
            this.Image2.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txtetime'))");
        }              
    }

    protected void imgtime_Click(object sender, ImageClickEventArgs e)
    {
        this.Image1.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txtstime').toString())");
        this.Image2.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txtetime').toString())");
    }

    public void bindshift()
    {
       string sqlstr = "select shiftid, shiftname, branch_id, right(convert(varchar(50),starttime),7)starttime, right(convert(varchar(50),endtime),7)endtime, shift_description,night from tbl_leave_shift where shiftid=" + Request.QueryString["shiftid"].ToString() + "";
       ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["RossellConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

       ddbranch.SelectedValue = ds.Tables[0].Rows[0]["branch_id"].ToString();
       txtshift.Text = ds.Tables[0].Rows[0]["shiftname"].ToString();
       txtstime.Text=ds.Tables[0].Rows[0]["starttime"].ToString();
       txtetime.Text=ds.Tables[0].Rows[0]["endtime"].ToString();
       txtshiftDesc.Text = ds.Tables[0].Rows[0]["shift_description"].ToString();
       chknightallowance.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["night"]);
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        int id=Convert.ToInt32(Request.QueryString["shiftid"]);
        DateTime startTime = Convert.ToDateTime(txtstime.Text);
        DateTime EnDTime = Convert.ToDateTime(txtetime.Text);
        bl_navigation.update_shift_master(id, txtshift.Text, startTime, EnDTime, txtshiftDesc.Text, Session["name"].ToString(), Convert.ToBoolean(chknightallowance.Checked), ref i);

        if (i <= 0)
        {
            message.InnerHtml = "Shift Type already exists, try again";           
        }
        else
        {
            Response.Redirect("editshift.aspx?updated=true");     
        }  
    }
  
    public void clear()
    {
        txtshift.Text = "";
        txtetime.Text = "";
        txtstime.Text = "";
        txtshiftDesc.Text = "";
    }
    protected void btncncl_Click(object sender, EventArgs e)
    {
        Server.Transfer("editshift.aspx");
        //Response.Redirect("editshift.aspx");
    }
   
}

