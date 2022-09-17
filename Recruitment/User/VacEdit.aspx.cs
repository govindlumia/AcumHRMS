using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System.Text;
using System.IO;
using QueryStringEncryption;
using InfoSoftGlobal;
using Utilities;
using System.Transactions;


public partial class Recruitment_User_VacAdvanceDetail : System.Web.UI.Page
{
    static DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CheckSession();
            if (Request.QueryString["ID"] != null)
            {
                Cryptography objDec = new Cryptography();

                ViewState["ID"] = objDec.Decrypt(Request.QueryString["ID"].Replace(" ", "+").ToString());
            }
            _FillControls();
        }
    }

    private void CheckSession()
    {
        try
        {
            if (string.IsNullOrEmpty(Session["EmpCode"].ToString()))
            {
                Response.Redirect("../../Login.aspx", false);
                return;
            }
        }
        catch (Exception ex)
        {
            if (ex.Message == "Object reference not set to an instance of an object.")
            {
                Response.Redirect("../../Login.aspx");
            }
            else
            {
                throw new ApplicationException(ex.Message.ToString());
            }
        }
    }

    protected void _FillControls()
    {
        CommonBusiness _ObjCommonBAL = new CommonBusiness();

        BindDropDowns(ddl_jobtitle, _ObjCommonBAL.BindDropDowns_Recruitment(Session["EmpCode"].ToString(), "Designation"), "id", "designationname");
        BindDropDowns(ddl_joblocation, _ObjCommonBAL.BindDropDowns_Recruitment(Session["EmpCode"].ToString(), "Branch"), "branch_id", "branch_name");

        txt_reqdate.Attributes.Add("readonly", "readonly");
        txt_position.Attributes.Add("onkeypress", "return numberonly(event);");

        FillRecordDetail();
    }

    private void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        ddl.DataSource = dataSource;
        ddl.DataValueField = valueField;
        ddl.DataTextField = textField;
        ddl.DataBind();
    }

    protected void FillRecordDetail()
    {
        VacENT ObjVacENT = new VacENT();
        VacBusiness ObjVacBusiness = new VacBusiness();

        ObjVacENT.Vac_ID = ViewState["ID"].ToString();
        ObjVacENT.EmpCode = Session["EmpCode"].ToString();

        ds = ObjVacBusiness.SelectVaccancyDetails(ObjVacENT);

        // Vaccancy Details
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable _dt = ds.Tables[0];

            lblVacID.Text = _dt.Rows[0]["VAC_ID"].ToString();
            ddl_jobtitle.Items.FindByValue(_dt.Rows[0]["Title_ID"].ToString()).Selected = true;
            ddl_joblocation.Items.FindByValue(_dt.Rows[0]["Location_ID"].ToString()).Selected = true;
            txt_jobname.Text = _dt.Rows[0]["Name"].ToString();
            txt_reqdate.Text = Convert.ToDateTime(_dt.Rows[0]["Req_Date"].ToString()).ToString(General.DateFormatRecruitment());
            txt_position.Text = _dt.Rows[0]["COUNT"].ToString();
            lblCreatedDate.Text = Convert.ToDateTime(_dt.Rows[0]["CREATEDDATE"].ToString()).ToString(General.DateFormatRecruitment());
            lblCreatedBy.Text = _dt.Rows[0]["CREATEDBYNAME"].ToString();
            lblDesca.Text = _dt.Rows[0]["Remarks"].ToString();
        }
    }

    protected void ddljobtitle_DataBound(object sender, EventArgs e)
    {
        ddl_jobtitle.Items.Insert(0, new ListItem("---Select Job Title---", "0"));
    }

    protected void ddljoblocation_DataBound(object sender, EventArgs e)
    {
        ddl_joblocation.Items.Insert(0, new ListItem("---Select Job Location---", "0"));
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string _Result = string.Empty;
        using (TransactionScope scope = new TransactionScope())
        {
            try
            {
                VacENT ObjVacENT = new VacENT();
                VacBusiness objbll = new VacBusiness();

                ObjVacENT.Vac_ID = ViewState["ID"].ToString();
                ObjVacENT.Title_ID = Convert.ToInt32(ddl_jobtitle.SelectedItem.Value);
                ObjVacENT.Name = txt_jobname.Text;
                ObjVacENT.Location_ID = Convert.ToInt32(ddl_joblocation.SelectedItem.Value);
                ObjVacENT.Count = Convert.ToInt32(txt_position.Text);
                ObjVacENT.EmpCode = Session["EmpCode"].ToString();
                ObjVacENT.RequiredDate = Utility.DateTimeForat(txt_reqdate.Text.ToString()).ToString("yyyy.MM.dd");
                ObjVacENT.Remarks = txt_comment.Text;

                _Result = objbll.Update_VacMaster(ObjVacENT);
                scope.Complete();
            }
            catch
            {
                scope.Dispose();
                General.Alert("Record(s) not submitted.", btnUpdate);
            }
        }

        if (_Result == "1")
        {
            Cryptography objEnc = new Cryptography();
            string key = objEnc.Encrypt(ViewState["ID"].ToString());
            StringWriter writer = new StringWriter();
            HttpContext.Current.Server.UrlEncode(key, writer);

            string url = "VacViewDetails.aspx?ID=" + writer.ToString() + "";

            General.Alert("Record(s) update successfully.", btnUpdate, url);
        }
        else
        {
            General.Alert("Record(s) not submitted.", btnUpdate);
        }
    }

   
}