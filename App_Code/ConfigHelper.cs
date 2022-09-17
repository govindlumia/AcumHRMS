using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ConfigHelper
/// </summary>
public static class ConfigHelper
{
    //public ConfigHelper()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //

        
    //}
    public static string TextUpdate
    {
        get
        {
            return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["ButtonUpdate"]);
        }
    }
    public static string TextSave
    {
        get
        {
            return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["ButtonSave"]);
        }
    }
    public static string MessageSuccess
    {
        get
        {
            return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["Save"]);
        }
    }
    public static string MessageUpdate
    {
        get
        {
            return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["Update"]);
        }
    }
    public static string MessageError
    {
        get
        {
            return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["Error"]);
        }
    }
    public static string MessageDelete
    {
        get
        {
            return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["Delete"]);
        }
    }
    public static string MessageAlreadyExist
    {
        get
        {
            return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["MsgAlreadyExist"]);
        }
    }
}