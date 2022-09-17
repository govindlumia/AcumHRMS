using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRMS.BusinessLogic.TimeSheet;
using System.Data;

public partial class TimeSheet_User_MyEmployeeTieSheet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindGrid();
        }
    }
    private void bindGrid()
    {
        EmployeeTimeSheetBAL balObj = new EmployeeTimeSheetBAL();
        DataTable _dtresult = balObj.getPendingSheets(Session["EmpCode"].ToString());
        if (_dtresult.Rows.Count > 0)
        {
            grd_pending.DataSource = _dtresult;
        }
        else
            grd_pending.DataSource = null;
        grd_pending.DataBind();
    }
    protected void grd_pending_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string  ID=(grd_pending.DataKeys[e.Row.RowIndex].Value.ToString());
            LinkButton lnk_view = (LinkButton)e.Row.FindControl("lnk_view");
            Label lbl_empcode = (Label)e.Row.FindControl("lbl_empcode");
            Label lbl_week = (Label)e.Row.FindControl("lbl_weekID");
            if (lnk_view != null && lbl_empcode!=null && lbl_week!=null)
            {
                QueryStringEncryption.Cryptography crypt = new QueryStringEncryption.Cryptography();
                lnk_view.PostBackUrl = "ViewEmployeeTimeSheet.aspx?ID="+crypt.Encrypt(ID)+"&code="+crypt.Encrypt(lbl_empcode.Text.Trim())+"&week="+crypt.Encrypt(lbl_week.Text.Trim());
            }
        }
    }
}