using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;
using System.IO;
using System;
using System.Web.UI.HtmlControls; 
namespace Export
{
/// <summary>
/// Summary description for ExportToExcel
/// </summary>
public class ExportToExcel
{
	public ExportToExcel()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //add by yadvendra 06-November-2008
    /// <summary>
    /// This Will Generate the Excel Sheet Of Grid View Data.
    /// </summary>
    /// <param name="grdExp"></param>
    public static void ExportGridView(GridView grdExp)
    {
        //HandleGrid(grdExp);
        //PrepareGridViewForExport(grdExp);
        HttpContext.Current.Response.Clear(); 

        string attachment = "attachment; filename=LMS-Report.xls";

        HttpContext.Current.Response.ClearContent();

        HttpContext.Current.Response.AddHeader("content-disposition", attachment);
        HttpContext.Current.Response.Charset = "";

        HttpContext.Current.Response.ContentType = "application/vnd.xls";

        StringWriter sw = new StringWriter();

        HtmlTextWriter htw = new HtmlTextWriter(sw);
       
        // Create a form to contain the grid

        HtmlForm frm = new HtmlForm();

        grdExp.Parent.Controls.Add(frm);

        frm.Attributes["runat"] = "server";

        frm.Controls.Add(grdExp);
        HandleGrid(grdExp);

        frm.RenderControl(htw);

        HttpContext.Current.Response.Write(sw.ToString());

        HttpContext.Current.Response.End();

        

    }

    /// <summary>
    /// AB:This method will replace the controls with the text.
    /// </summary>
    /// <param name="gv"></param>
    private static void PrepareGridViewForExport(Control gv)
    {
        LinkButton lb = new LinkButton();

        Literal l = new Literal();

        string name = String.Empty;

        for (int i = 0;  i < gv.Controls.Count; i++)
        {

            if (gv.Controls[i].GetType() == typeof(LinkButton))
            {

                l.Text = (gv.Controls[i] as LinkButton).Text;

                gv.Controls.Remove(gv.Controls[i]);

                gv.Controls.AddAt(i, l);

            }

            else if (gv.Controls[i].GetType() == typeof(HyperLink))
            {

                l.Text = (gv.Controls[i] as HyperLink).Text;

                gv.Controls.Remove(gv.Controls[i]);

                gv.Controls.AddAt(i, l);

            }

            else if (gv.Controls[i].GetType() == typeof(CheckBox))
            {
                gv.Controls.Remove(gv.Controls[i]);
            }
            else if (gv.Controls[i].GetType() == typeof(Button))
            {
                gv.Controls.Remove(gv.Controls[i]);
            }
            else if (gv.Controls[i].GetType() == typeof(ImageButton))
            {
                gv.Controls.Remove(gv.Controls[i]);
            }

            if (gv.Controls[i].HasControls())
            {
                PrepareGridViewForExport(gv.Controls[i]);
            }


        }

    }
    /// <summary>
    /// AB:This method will remove the controls from the header of the gridview
    /// </summary>
    /// <param name="gv"></param>
    public static void HandleGrid(GridView gv)
    {
        Literal l = new Literal();

        for (int ct = 0; ct < gv.HeaderRow.Cells.Count; ct++)
        {
            // Save initial text if found
            string headerText = gv.HeaderRow.Cells[ct].Text;

            // Check for controls in header
            if (gv.HeaderRow.Cells[ct].HasControls())
            {

                // Check for link button
                if (gv.HeaderRow.Cells[ct].Controls[0].GetType().ToString() == "System.Web.UI.WebControls.DataControlLinkButton")
                {
                    // link button found, get text
                    headerText = ((LinkButton)gv.HeaderRow.Cells[ct].Controls[0]).Text;
                }

                // Remove controls from header
                gv.HeaderRow.Cells[ct].Controls.Clear();
            }
            // Reassign header text
            gv.HeaderRow.Cells[ct].Text = headerText;

        }
    }
}
}