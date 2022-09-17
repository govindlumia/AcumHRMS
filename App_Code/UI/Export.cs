using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.IO;

/// <summary>
/// Summary description for Export
/// </summary>
/// 
namespace UI
{

    public class Export
    {
        public Export()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static int ExportEnquiry(DataTable dEnquiry, string Path)
        {
            int noLine = 0;
            try
            {
                // Create the CSV file to which grid data will be exported.
                StreamWriter sw = new StreamWriter(Path, false);

                // First we will write the headers.
                // DataTable dt = dEnquiry.Tables[0];
                int iColCount = dEnquiry.Columns.Count;
                for (int i = 0; i < iColCount; i++)
                {
                    sw.Write(dEnquiry.Columns[i]);
                    if (i < iColCount - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
                // Now write all the rows.
                foreach (DataRow dr in dEnquiry.Rows)
                {
                    for (int i = 0; i < iColCount; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                        {
                            sw.Write(dr[i].ToString());
                        }
                        if (i < iColCount - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.Write(sw.NewLine);
                    noLine++;
                }
                sw.Close();
                return noLine;
            }
            catch
            {

            }
            return noLine;
        }

        public static int ExportOpportunity(DataTable dOpportunity, string Path)
        {
            int noLine = 0;
            try
            {
                // Create the CSV file to which grid data will be exported.
                StreamWriter sw = new StreamWriter(Path, false);

                // First we will write the headers.
                // DataTable dt = dEnquiry.Tables[0];
                int iColCount = dOpportunity.Columns.Count;
                for (int i = 0; i < iColCount; i++)
                {
                    sw.Write(dOpportunity.Columns[i]);
                    if (i < iColCount - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
                // Now write all the rows.
                foreach (DataRow dr in dOpportunity.Rows)
                {
                    for (int i = 0; i < iColCount; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                        {
                            sw.Write(dr[i].ToString());
                        }
                        if (i < iColCount - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.Write(sw.NewLine);
                    noLine++;
                }
                sw.Close();
                return noLine;
            }
            catch
            {

            }
            return noLine;
        }

    }
}
