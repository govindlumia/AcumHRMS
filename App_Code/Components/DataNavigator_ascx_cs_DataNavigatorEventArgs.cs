//====================================================================
// This file is generated as part of Web project conversion.
// The extra class 'DataNavigatorEventArgs' in the code behind file in 'DataNavigator.ascx.cs' is moved to this file.
//====================================================================




namespace Datanavigation
{

    using System;
    using System.Data;
    using System.Drawing;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;

    public class DataNavigatorEventArgs : EventArgs
    {
        private int m_iCurrentPage;
        private int m_iTotalPages;
        private int m_iPageSize;
        private int m_iTotalRecords;
        public DataNavigatorEventArgs()
        {
        }

        public int CurrentPage
        {
            get { return m_iCurrentPage; }
            set { m_iCurrentPage = value; }
        }

        public int TotalPages
        {
            get { return m_iTotalPages; }
            set { m_iTotalPages = value; }
        }

        public int PageSize
        {
            get { return m_iPageSize; }
            set { m_iPageSize = value; }
        }
        public int TotalRecords
        {
            get { return m_iTotalRecords; }
            set { m_iTotalRecords = value; }
        }
    }

}