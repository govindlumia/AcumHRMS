using HRMS.BusinessEntity.Common;
using HRMS.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePageUC<Entity> : System.Web.UI.UserControl
{
    public BasePageUC()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string SessionEmpCode
    {
        get
        {
            return Convert.ToString(Session["empcode"]);
        }
    }
    GridView _grd { get; set; }
   public List<Entity> _DataSet { get; set; }
    public void Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        _grd.PageIndex = e.NewPageIndex;
        BindDataGridView(_DataSet, _grd);

    }    
    public virtual void BindDropDowns(DropDownList ddl, object dataSource, string valueField, string textField)
    {
        if (ddl != null && dataSource != null)
        {
            ddl.DataSource = dataSource;
            ddl.DataValueField = valueField;
            ddl.DataTextField = textField;
            ddl.DataBind();
        }
        ddl.Items.Insert(0, new ListItem("---------Select---------", "0"));
    }
    public virtual void BindDataGridView(List<Entity> ds, GridView grd)
    {
        try
        {
            _DataSet = ds;
            _grd = grd;
            if (grd != null && ds != null && ds.Count() > 0)
            {
                grd.DataSource = ds;
                grd.DataBind();
                _grd.PageIndexChanging += Grid_PageIndexChanging;
            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();
            }
        }
        catch (Exception ex)
        {
            CommonBusiness cb = new CommonBusiness();
            cb.SaveExceptionLogDetail(new ExceptionTrackEntity() { MethodName = "BindDataGridView", PageName = "", StackTrace = ex.StackTrace });
        }
    }

    #region Common Functions
    public virtual void ClearDropDownSelection(DropDownList ddl, int selIndex = -1)
    {
        ddl.ClearSelection();
        ddl.SelectedIndex = selIndex;
    }
    public virtual void SetSelectedValue(DropDownList ddl, string selectedValue)
    {
        if (ddl.Items.FindByValue(selectedValue) != null)
        {
            ddl.ClearSelection();
            ddl.Items.FindByValue(selectedValue).Selected = true;
        }
    }
    #endregion
}