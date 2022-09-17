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

public partial class Recruitment_User_CanHistory : System.Web.UI.Page
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
        CanENT ObjCanENT = new CanENT();
        CanBusiness ObjCanBusiness = new CanBusiness();

        ObjCanENT.Can_ID = ViewState["ID"].ToString();
        ObjCanENT.EmpCode = Session["EmpCode"].ToString();

        DataSet ds = ObjCanBusiness.Select_CanHistory(ObjCanENT);
        GvCanHistory.DataSource = ds;
        GvCanHistory.DataBind();

        lblCanId.Text = ds.Tables[0].Rows[0]["CAN_ID"].ToString();
    }

    protected void GvCanHistory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblDate = (Label)e.Row.FindControl("lblDate");

            lblDate.Text = Convert.ToDateTime(lblDate.Text).ToString(General.DateFormatRecruitment());

        }
    }
}