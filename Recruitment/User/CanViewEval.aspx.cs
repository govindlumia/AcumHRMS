using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using QueryStringEncryption;
using System.Web.UI.HtmlControls;
using System.Configuration;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
public partial class Recruitment_CanViewEval : System.Web.UI.Page
{
    int Result = 0;
    DataSet ds = new DataSet();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["EmpCode"])))
            {
                Response.Redirect("~/Login.aspx");
            }

            if (Request.QueryString["ID"] != null)
            {
                Cryptography objDec = new Cryptography();
                ViewState["ID"] = objDec.Decrypt(Request.QueryString["ID"].Replace(" ", "+").ToString());
            }
            if (Request.QueryString["EMP"] != null)
            {
                Cryptography objDec = new Cryptography();
                ViewState["EMP"] = objDec.Decrypt(Request.QueryString["EMP"].Replace(" ", "+").ToString());
            }
            if (Request.QueryString["RID"] != null)
            {
                Cryptography objDec = new Cryptography();
                ViewState["RID"] = objDec.Decrypt(Request.QueryString["RID"].Replace(" ", "+").ToString());
            }

            _PageInitialise();
        }
    }
    protected void _PageInitialise()
    {
        _ShowCanDetails();
        BindEvalParaMaster();
        BindEvalDetails();
    }

    protected void _ShowCanDetails()
    {
        CanENT ObjCanENT = new CanENT();
        CanBusiness ObjCanBusiness = new CanBusiness();

        ObjCanENT.Can_ID = ViewState["ID"].ToString();
        ObjCanENT.EmpCode = Session["EmpCode"].ToString();

        ds = ObjCanBusiness.Select_CanDetails(ObjCanENT);

        DataTable _dt = ds.Tables[0];

        lblvacID.Text = _dt.Rows[0]["VAC_ID"].ToString();
        lblvacName.Text = _dt.Rows[0]["DESIGNATIONNAME"].ToString();
        lblCanId.Text = _dt.Rows[0]["Can_ID"].ToString();
        lblName.Text = _dt.Rows[0]["CandidateName"].ToString();
        lblEmail.Text = _dt.Rows[0]["Email_Id"].ToString();
        lblContactno.Text = _dt.Rows[0]["Contact_No"].ToString();
        lblapplicationdate.Text = Convert.ToDateTime(_dt.Rows[0]["ApplicationDate"].ToString()).ToString(General.DateFormatRecruitment());
        lblCCreatedDate.Text = Convert.ToDateTime(_dt.Rows[0]["CCREATEDDATE"].ToString()).ToString(General.DateFormatRecruitment());
        lblRemarks.Text = _dt.Rows[0]["Remarks"].ToString();

        lblStatus.Text = ds.Tables[1].Rows[0]["EMPSTATUS"].ToString();
        lblRoundCode.Text = ds.Tables[1].Rows[0]["ROUNDCODE"].ToString();

    }

    private void BindEvalParaMaster()
    {
        EvalParaENT ObjEvalParaENT = new EvalParaENT();
        RoundBusiness ObjRoundBusiness = new RoundBusiness();

        ObjEvalParaENT.ID = "";
        ObjEvalParaENT.Dsca = "";
        ObjEvalParaENT.EmpCode = Session["EmpCode"].ToString();

        ViewState["EvalPara"] = ObjRoundBusiness.Select_EvalParaMaster(ObjEvalParaENT);
    }

    private void BindEvalDetails()
    {
        CanEvalDetailsENT ObjCanEvalDetailsENT = new CanEvalDetailsENT();
        RoundBusiness ObjRoundBusiness = new RoundBusiness();

        ObjCanEvalDetailsENT.RoundCode = ViewState["RID"].ToString();
        ObjCanEvalDetailsENT.EmpCode = ViewState["EMP"].ToString();

        DataSet ds = ObjRoundBusiness.Select_CanEvalDetails(ObjCanEvalDetailsENT);
        GvCanEvalSkills.DataSource = ds;
        GvCanEvalSkills.DataBind();

        lblEmployee.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
        lblRoundName.Text = ds.Tables[0].Rows[0]["Dsca"].ToString();
    }

    protected void GvCanEvalSkills_DataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblEvalPara = (Label)e.Row.FindControl("lblEvalPara");
            Label lblParaSel = (Label)e.Row.FindControl("lblParaSel");
            RadioButtonList rdList = (RadioButtonList)e.Row.FindControl("rdList");

            rdList.DataSource = (DataSet)ViewState["EvalPara"];
            rdList.DataValueField = "ID";
            rdList.DataTextField = "Dsca";
            rdList.DataBind();

            rdList.SelectedValue = lblEvalPara.Text;

            rdList.Enabled = false;

            string strAnswer = String.Empty;
            foreach (ListItem item in rdList.Items)
            {
                if (item.Selected)
                {
                    lblParaSel.Text = item.Text;
                    rdList.Visible = false;
                    break;
                }
                else
                {
                    continue;
                }
            }

        }
    }
}