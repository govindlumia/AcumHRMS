using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Globalization;
using System.Threading;

namespace CustomServerControls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:TextArea runat=server></{0}:TextArea>")]
    public class TextArea : TextBox
    {
        public override TextBoxMode TextMode
        {
            get
            {
                return TextBoxMode.MultiLine;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (MaxLength > 0)
            {
                if (!Page.ClientScript.IsClientScriptIncludeRegistered("TextArea"))
                {
                    Page.ClientScript.RegisterClientScriptInclude("TextArea", ResolveClientUrl("~/js/textarea.js"));
                }
                this.Attributes.Add("onkeypress", "LimitInput(this)");
                this.Attributes.Add("onbeforepaste", "doBeforePaste(this)");
                this.Attributes.Add("onpaste", "doPaste(this)");
                this.Attributes.Add("onmousemove", "LimitInput(this)");
                this.Attributes.Add("maxLength", this.MaxLength.ToString());
            }
                base.OnPreRender(e);
        }
    }
}
