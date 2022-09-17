using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


    public partial class UserControls_DataControls_TextBox : System.Web.UI.UserControl
    {
        #region "Public Properties"

        #region "TextBox Properties"

        public string Text
        {
            get
            {
                return txtDataBox.Text;
            }
            set
            {
                txtDataBox.Text = value;
            }
        }

        public int MaxLength
        {
            set
            {
                txtDataBox.MaxLength = value;
            }
        }
        public bool Enable
        {
            set
            {
                txtDataBox.Enabled = value;
            }
        }

        public int Columns
        {
            set
            {
                txtDataBox.Columns = value;
            }
        }
        public string CssClass
        {
            set
            {
                txtDataBox.CssClass = value;
            }
        }
        public System.Web.UI.WebControls.TextBoxMode TextMode
        {
            set
            {
                txtDataBox.TextMode = value;
            }
        }
        #endregion

        #region "RequiredFieldValidator Properties"
        public string ErrorMessage
        {
            set
            {
                rfvDataBox.ErrorMessage = value;
            }
        }
        public bool SetFocusOnError
        {
            set
            {
                rfvDataBox.SetFocusOnError = value;
            }
        }
        public string ValidationGroup
        {
            set
            {
                rfvDataBox.ValidationGroup = value;
            }
        }
        public ValidatorDisplay Display
        {
            set
            {
                rfvDataBox.Display = value;
            }
        }
        #endregion

        #endregion

        #region "Events"

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        #endregion
    }
