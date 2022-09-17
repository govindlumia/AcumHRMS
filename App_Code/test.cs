using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


namespace test1
{
    public class testa
    {
        public string a;

        public testa()
        {
            a = "A";
        }

        public string display(string a)
        {
            a = a + "a";
            return a;
        }
    }

    public class testb : testa
    {
        public string b;
        public testb()
        {
            b = "B";
        }

        public string display(string b)
        {
            b = b + "b";
            return b;
        }
    }
}
