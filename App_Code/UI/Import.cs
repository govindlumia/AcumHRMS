using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Import
/// </summary>
/// 

namespace UI
{
    public class Import
    {
        public Import()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static int ProductUploadFile(string filepath)
        {
            int res = 0;
            string result = "";
            try
            {
                string conStr = "";

                conStr = SFA.DataConnect.strConn;
                //string filepath = "D:\\test.csv";
                StreamReader sr = new StreamReader(filepath);
                int NrLines = 0;
                string[,] mline;
                mline = new string[NrLines, 50];
                int cntra = 0;
                int counter = 0;

                using (StreamReader cr = new StreamReader(filepath))
                {
                    while ((cr.ReadLine()) != null)
                    {
                        NrLines++;
                    }
                    cr.Close();
                }

                mline = new string[NrLines, 25];

                for (int lcounter = 1; (lcounter <= NrLines); lcounter++)
                {

                    string[] sline = sr.ReadLine().Split(',');
                    //strElem = strElem.Append("");
                    if (sline != null)
                    {
                        for (int c = 0; c < sline.Length; c++)
                            mline[cntra, c] = sline[c];
                        cntra++;
                    }
                }
                sr.Close();


                for (counter = 0; counter < NrLines; counter++)
                {
                    string itemcode = mline[counter, 0].ToString();
                    string itemname = mline[counter, 1].ToString();
                    string barcode = mline[counter, 2].ToString();
                    string itemdescription = mline[counter, 3].ToString();
                    string openingstock = mline[counter, 4].ToString();
                    string closingstock = mline[counter, 5].ToString();
                    string minimumstock = mline[counter, 6].ToString();
                    double costprice = Convert.ToDouble(mline[counter, 7].ToString());
                    double mrp = Convert.ToDouble(mline[counter, 8].ToString());
                    double dealerprice = Convert.ToDouble(mline[counter, 9].ToString());
                    string updated_by = mline[counter, 10].ToString();
                    DateTime updated_date = Convert.ToDateTime(mline[counter, 11].ToString());
                    string itemsize = mline[counter, 12].ToString();
                    string measurementid = mline[counter, 13].ToString();
                    string itemcategoryid = mline[counter, 14].ToString();
                    string itemgroupid = mline[counter, 15].ToString();
                    string itemtypeid = mline[counter, 16].ToString();
                    string brandid = mline[counter, 17].ToString();
                    string modelid = mline[counter, 18].ToString();
                    //string manufacturerid = mline[counter, 19].ToString();
                    string vendorid = mline[counter, 19].ToString();
                    string imagename = mline[counter, 20].ToString();
                    string packing = mline[counter, 21].ToString();
                    string productcategory = mline[counter, 22].ToString();
                    string additionalvender = mline[counter, 23].ToString();
                    
                    result = DAL.Product.saveProduct("C", itemcode, itemname, barcode, itemdescription, openingstock, closingstock, minimumstock, updated_by, updated_date, itemsize, measurementid, itemcategoryid, itemgroupid, itemtypeid, brandid, modelid, vendorid, imagename, packing, productcategory, additionalvender,"0","0"); //costprice, mrp, dealerprice,

                    if (result != "")
                    {
                        res++;
                    }


                }

                if (res > 0)
                {
                    return res;
                }
            }
            catch
            {

            }
            return res;

        }


        public static int OrgnizationUplodeFile(string filepath)
        {
            int res = 0;
            string result = "";
            try
            {
                string conStr = "";

                conStr = SFA.DataConnect.strConn;
                //string filepath = "D:\\test.csv";
                StreamReader sr = new StreamReader(filepath);
                int NrLines = 0;
                string[,] mline;
                mline = new string[NrLines, 50];
                int cntra = 0;
                int counter = 0;

                using (StreamReader cr = new StreamReader(filepath))
                {
                    while ((cr.ReadLine()) != null)
                    {
                        NrLines++;
                    }
                    cr.Close();
                }

                mline = new string[NrLines, 49];

                for (int lcounter = 1; (lcounter <= NrLines); lcounter++)
                {

                    string[] sline = sr.ReadLine().Split(',');
                    //strElem = strElem.Append("");
                    if (sline != null)
                    {
                        for (int c = 0; c < sline.Length; c++)
                            mline[cntra, c] = sline[c];
                        cntra++;
                    }
                }
                sr.Close();


                for (counter = 0; counter < NrLines; counter++)
                {
                    //string operation = mline[counter, 0].ToString();
                    string OrganizationCode = mline[counter, 0].ToString();
                    string OrganizationName = mline[counter, 1].ToString();
                    string AccountType = mline[counter, 2].ToString();
                    string NatureofBusiness = mline[counter, 3].ToString();
                    int IndustryId = Convert.ToInt32(mline[counter, 4].ToString());
                    int CompanyType = Convert.ToInt32(mline[counter, 5].ToString());
                    int NumberOfLocations = Convert.ToInt32(mline[counter, 6].ToString());

                    string Status = mline[counter, 7].ToString();
                    DateTime CreationDate = Convert.ToDateTime(mline[counter, 8].ToString());
                    string Tan_No = mline[counter, 9].ToString();
                    string Pan_No = mline[counter, 10].ToString();
                    string Vat_No = mline[counter, 11].ToString();
                    string ServiceTax_No = mline[counter, 12].ToString();
                    int NumberOfEmployee = Convert.ToInt32(mline[counter, 13].ToString());
                    double AnnualTurnOver = Convert.ToInt32(mline[counter, 14].ToString());
                    string URL = mline[counter, 15].ToString();
                    string PhoneNo = mline[counter, 16].ToString();
                    string FaxNo = mline[counter, 17].ToString();
                    string CorporateEmailId = mline[counter, 18].ToString();
                    string Cors_Add1 = mline[counter, 19].ToString();
                    string Cors_Add2 = mline[counter, 20].ToString();
                    string Cors_City = mline[counter, 21].ToString();
                    string Cors_State = mline[counter, 22].ToString();
                    string Cors_Country = mline[counter, 23].ToString();
                    string Cors_Pin = mline[counter, 24].ToString();
                    string Bill_Add1 = mline[counter, 25].ToString();
                    string Bill_Add2 = mline[counter, 26].ToString();
                    string Bill_City = mline[counter, 27].ToString();
                    string Bill_State = mline[counter, 28].ToString();
                    string Bill_Country = mline[counter, 29].ToString();
                    string Bill_Pin = mline[counter, 30].ToString();
                    string Ship_Add1 = mline[counter, 31].ToString();
                    string Ship_Add2 = mline[counter, 32].ToString();
                    string Ship_City = mline[counter, 33].ToString();
                    string Ship_State = mline[counter, 34].ToString();
                    string Ship_Country = mline[counter, 35].ToString();
                    string Ship_Pin = mline[counter, 36].ToString();
                    string Reg_Add1 = mline[counter, 37].ToString();
                    string Reg_Add2 = mline[counter, 38].ToString();
                    string Reg_City = mline[counter, 39].ToString();
                    string Reg_State = mline[counter, 40].ToString();
                    string Reg_Country = mline[counter, 41].ToString();
                    string Reg_Pin = mline[counter, 42].ToString();
                    string Reporting_To = mline[counter, 43].ToString();
                    string Updated_By = mline[counter, 44].ToString();
                    DateTime Updated_Date = Convert.ToDateTime(mline[counter, 45].ToString());
                    string Created_By = mline[counter, 46].ToString();
                    DateTime Created_Date = Convert.ToDateTime(mline[counter, 47].ToString());
                    string CoustomerReference = mline[counter, 48].ToString();
                    string assignTo = mline[counter, 49].ToString();

                    //string Branch_Add1 = "";
                    //string Branch_Add2 = "";
                    //string Branch_City = "";
                    //string Branch_State = "";
                    //string Branch_Country = "";
                    //string Branch_Pin = "";

                    //string Group_Comp_Add1 = "";
                    //string Group_Comp_Add2 = "";
                    //string Group_Comp_City = "";
                    //string Group_Comp_State = "";
                    //string Group_Comp_Country = "";
                    //string Group_Comp_Pin = "";
                  



                    result = DAL.Organization.saveOrganization("C", OrganizationCode, OrganizationName, AccountType, NatureofBusiness, IndustryId, CompanyType, NumberOfLocations, Status, CreationDate, Tan_No, Pan_No, Vat_No, ServiceTax_No, NumberOfEmployee, AnnualTurnOver, URL, PhoneNo, FaxNo, CorporateEmailId, Cors_Add1, Cors_Add2, Cors_City, Cors_State, Cors_Country, Cors_Pin, Bill_Add1, Bill_Add2, Bill_City, Bill_State, Bill_Country, Bill_Pin, Ship_Add1, Ship_Add2, Ship_City, Ship_State, Ship_Country, Ship_Pin, Reg_Add1, Reg_Add2, Reg_City, Reg_State, Reg_Country, Reg_Pin, Reporting_To, Updated_By, Updated_Date, Created_By, Created_Date, CoustomerReference, assignTo);

                    if (result != "")
                    {
                        res++;
                    }


                }

                if (res > 0)
                {
                    return res;
                }
            }
            catch
            {

            }
            return res;

        }

        public static int ContactUploadFile(string filepath)
        {
            int res = 0;
            int result = 0;
            try
            {
                string conStr = "", SQL = "";

                conStr = SFA.DataConnect.strConn;
                //string filepath = "D:\\test.csv";
                StreamReader sr = new StreamReader(filepath);
                int NrLines = 0;
                string[,] mline;
                mline = new string[NrLines, 50];
                int cntra = 0;
                int counter = 0;

                using (StreamReader cr = new StreamReader(filepath))
                {
                    while ((cr.ReadLine()) != null)
                    {
                        NrLines++;
                    }
                    cr.Close();
                }

                mline = new string[NrLines, 35];

                for (int lcounter = 1; (lcounter <= NrLines); lcounter++)
                {

                    string[] sline = sr.ReadLine().Split(',');
                    //strElem = strElem.Append("");
                    if (sline != null)
                    {
                        for (int c = 0; c < sline.Length; c++)
                            mline[cntra, c] = sline[c];
                        cntra++;
                    }
                }
                sr.Close();


                for (counter = 0; counter < NrLines; counter++)
                {
                    int ContactId = 0;
                    string OrganizationCode = mline[counter, 0].ToString();
                    string Basic_Title = mline[counter, 1].ToString();
                    string Basic_FName = mline[counter, 2].ToString();
                    string Basic_MName = mline[counter, 3].ToString();
                    string Basic_LName = mline[counter, 4].ToString();

                    int Basic_JobTitle = Convert.ToInt32(mline[counter, 5].ToString());
                    int DepartmentId = Convert.ToInt32(mline[counter, 6].ToString());
                    int Basic_BranchId = Convert.ToInt32(mline[counter, 7].ToString());

                    string Basic_Type = mline[counter, 8].ToString();
                    string Basic_EMail = mline[counter, 9].ToString();

                    string Buis_Phone_Country = mline[counter, 10].ToString();
                    string Buis_Phone_CityCode = mline[counter, 11].ToString();
                    string Buis_Phone_Number = mline[counter, 12].ToString();

                    string Buis_Phone_Extension = mline[counter, 13].ToString();

                    string Buis_Fax_Country = mline[counter, 14].ToString();
                    string Buis_Fax_CityCode = mline[counter, 15].ToString();
                    string Buis_Fax_Number = mline[counter, 16].ToString();
                    string Buis_Fax_Extension = mline[counter, 17].ToString();
                    string Moblie_Country = mline[counter, 18].ToString();
                    string Moblie_CityCode = mline[counter, 19].ToString();
                    string Moblie_Number = mline[counter, 20].ToString();
                    string Moblie_Extension = mline[counter, 21].ToString();

                    string Perso_Street = mline[counter, 22].ToString();
                    string Perso_City = mline[counter, 23].ToString();
                    string Perso_State = mline[counter, 24].ToString();
                    string Perso_Country = mline[counter, 25].ToString();

                    string Perso_PinNo = mline[counter, 26].ToString();
                    DateTime BirthDay = Convert.ToDateTime(mline[counter, 27].ToString());
                    DateTime Anniversary = Convert.ToDateTime(mline[counter, 28].ToString());

                    string Spouse_Name = mline[counter, 29].ToString();
                    string Children = mline[counter, 30].ToString();
                    string Updated_By = mline[counter, 31].ToString();
                    DateTime Updated_Date = Convert.ToDateTime(mline[counter, 32].ToString());
                    string Created_By = mline[counter, 33].ToString();
                    DateTime Created_Date = Convert.ToDateTime(mline[counter, 34].ToString());
                    string assignTo = mline[counter, 35].ToString();

                    result = DAL.Contact.SaveContact("C", ContactId, OrganizationCode, Basic_Title, Basic_FName, Basic_MName, Basic_LName, Basic_JobTitle, DepartmentId, Basic_BranchId, Basic_Type, Basic_EMail, Buis_Phone_Country, Buis_Phone_CityCode, Buis_Phone_Number, Buis_Phone_Extension, Buis_Fax_Country, Buis_Fax_CityCode, Buis_Fax_Number, Buis_Fax_Extension, Moblie_Country, Moblie_CityCode, Moblie_Number, Moblie_Extension, Perso_Street, Perso_City, Perso_State, Perso_Country, Perso_PinNo, BirthDay, Anniversary, Spouse_Name, Children, Updated_By, Updated_Date, Created_By, Created_Date);  //, assignTo
                    if (result != 0)
                    {
                        res++;
                    }
                }

                if (res > 0)
                {
                    return res;
                }
            }
            catch
            {

            }
            return res;

        }

    }

}
