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

public partial class Recruitment_User_VacHistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                Cryptography objDec = new Cryptography();
                ViewState["ID"] = objDec.Decrypt(Request.QueryString["ID"].Replace(" ", "+").ToString());
            }
            _FillControls();
        }
    }

    protected void _FillControls()
    {
        VacENT ObjVacENT = new VacENT();
        VacBusiness ObjVacBusiness = new VacBusiness();

        ObjVacENT.Vac_ID = ViewState["ID"].ToString();
        ObjVacENT.EmpCode = Session["EmpCode"].ToString();

        DataSet ds = ObjVacBusiness.SelectAppHistory(ObjVacENT);
        GvAppHistory.DataSource = ds;
        GvAppHistory.DataBind();

        lblVacId.Text = ds.Tables[0].Rows[0]["Vac_Id"].ToString();
    }

    protected void GvAppHistory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblDate = (Label)e.Row.FindControl("lblDate");

            lblDate.Text = Convert.ToDateTime(lblDate.Text).ToString(General.DateFormatRecruitment());

        }
    }
}