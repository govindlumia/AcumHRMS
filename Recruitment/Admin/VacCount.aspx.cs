using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRMS.BusinessEntity;
using HRMS.BusinessLogic;
using System.Data;

public partial class Recruitment_Admin_VacCount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtCount.Attributes.Add("onkeypress", "return numberonly(event);");

            VacBusiness ObjVacBusiness = new VacBusiness();
            DataSet _ds = ObjVacBusiness.SelectVaccancyCount();

            txtCount.Text = _ds.Tables[0].Rows[0]["CNumber"].ToString();
            lblCount.Text = _ds.Tables[0].Rows[0]["CNumber"].ToString();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtCount.Text))
        {
            VacBusiness ObjVacBusiness = new VacBusiness();
            string _result = ObjVacBusiness.UpdateVaccancyCount(txtCount.Text.Trim());

            if (_result == "1")
            {
                General.Alert("Record(s) has been updated", this, "VacCount.aspx");
            }
        }
        else
        {
            General.Alert("Count textbox is empty, please fill the same", this);
        }
    }
}