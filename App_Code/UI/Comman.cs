using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Comman
/// </summary>
/// 
namespace UI
{
    public class Comman
    {
        public Comman()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static void fillDDLSalesTypeList(DropDownList ddl)
        {
            DataTable oData = new DataTable();
            oData = DAL.SalesType.getSalesTypeList();
            ddl.DataSource = oData;
            ddl.DataTextField = "SalesTypeName";
            ddl.DataValueField = "SalesTypeId";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static DateTime getTodayDate()
        {
            return DateTime.Now;
        }

        public static string GenerateModifiedFileName(string strPath)
        {
            try
            {
                string strDateSeparator = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator;
                string strTimeSeparator = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator;
                string strModifiedFileName = "" + DateTime.Now.Date.ToShortDateString().Replace(strDateSeparator, "") + DateTime.Now.TimeOfDay.ToString().Replace(strTimeSeparator, "").Replace(".", "") + strPath;

                return strModifiedFileName;
            }
            catch
            {
                return "";
            }
        }

        public static void fillDDLMeasurementList(DropDownList ddl)
        {
            DataTable oData = new DataTable();
            oData = DAL.Measurement.getMeasurementList();
            ddl.DataSource = oData;
            ddl.DataTextField = "measurement_name";
            ddl.DataValueField = "measurementid";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLItemCategoryList(DropDownList ddl)
        {
            DataTable oData = new DataTable();
            oData = DAL.ItemCategory.getItemCategoryList();
            ddl.DataSource = oData;
            ddl.DataTextField = "itemcategoryname";
            ddl.DataValueField = "itemcategoryid";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLItemGroupList(DropDownList ddl)
        {
            DataTable oData = new DataTable();
            oData = DAL.ItemGroup.getItemGroupList();
            ddl.DataSource = oData;
            ddl.DataTextField = "itemgroupname";
            ddl.DataValueField = "itemgroupid";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLItemSizeList(DropDownList ddl)
        {
            DataTable oData = new DataTable();
            oData = DAL.ItemSize.getSizeList();
            ddl.DataSource = oData;
            ddl.DataTextField = "psize";
            ddl.DataValueField = "sizeid";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }


        public static void fillDDLItemTypeList(DropDownList ddl)
        {
            DataTable oData = new DataTable();
            oData = DAL.ItemType.getItemTypeList();
            ddl.DataSource = oData;
            ddl.DataTextField = "itemtypename";
            ddl.DataValueField = "itemtypeid";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLModelList(DropDownList ddl)
        {
            DataTable oData = new DataTable();
            oData = DAL.Model.getModelList();
            ddl.DataSource = oData;
            ddl.DataTextField = "modelname";
            ddl.DataValueField = "modelid";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }
        //getModelByModelId on
        public static void fillDDLModelById(DropDownList ddl, int id)
        {
            DataTable oData = new DataTable();
            oData = DAL.Model.getModelByModelId(id);
            ddl.DataSource = oData;
            ddl.DataTextField = "modelname";
            ddl.DataValueField = "modelid";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLModelGroupList(DropDownList ddl, string modelid)
        {
            DataTable oData = new DataTable();
            oData = DAL.Model.getModelByGroupModelId(modelid);
            ddl.DataSource = oData;
            ddl.DataTextField = "modelname";
            ddl.DataValueField = "modelid";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }
        // get range on selection of itemtype
        public static void fillDDLModelItemList(DropDownList ddl, string itemtypename)
        {
            DataTable oData = new DataTable();
            oData = DAL.Model.getModeItemlList(itemtypename);
            ddl.DataSource = oData;
            ddl.DataTextField = "modelname";
            ddl.DataValueField = "modelid";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLBrandList(DropDownList ddl)
        {
            DataTable oData = new DataTable();
            oData = DAL.Brand.getBrandList();
            ddl.DataSource = oData;
            ddl.DataTextField = "brandname";
            ddl.DataValueField = "brandid";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLManufacturerList(DropDownList ddl)
        {
            DataTable oData = new DataTable();
            oData = DAL.Manufacturer.getManufacturerList();
            ddl.DataSource = oData;
            ddl.DataTextField = "manufacturername";
            ddl.DataValueField = "manufacturerid";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLVendorList(DropDownList ddl)
        {
            DataTable oData = new DataTable();
            oData = DAL.Vendor.getVendorList();
            ddl.DataSource = oData;
            ddl.DataTextField = "vendorname";
            ddl.DataValueField = "vendorid";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLIndustryList(DropDownList ddl)
        {
            DataTable oData = new DataTable();
            oData = DAL.Industry.getIndustryList();
            ddl.DataSource = oData;
            ddl.DataTextField = "IndustryName";
            ddl.DataValueField = "IndustryId";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLCompanyTypeList(DropDownList ddl)
        {
            DataTable oData = new DataTable();
            oData = DAL.CompanyType.getCompanyTypeList();
            ddl.DataSource = oData;
            ddl.DataTextField = "CompanyTypeName";
            ddl.DataValueField = "CompanyTypeId";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLJobTitleList(DropDownList ddl)
        {
            DataTable oData = new DataTable();
            oData = DAL.JobTitle.getJobTitleList();
            ddl.DataSource = oData;
            ddl.DataTextField = "JobTitleName";
            ddl.DataValueField = "JobTitleId";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLDepartmentList(DropDownList ddl)
        {
            DataTable oData = new DataTable();
            oData = DAL.Department.getDepartmentList();
            ddl.DataSource = oData;
            ddl.DataTextField = "department_name";
            ddl.DataValueField = "departmentid";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLbranchList(DropDownList ddl)
        {
            DataTable oData = new DataTable();
            oData = DAL.Branch.getBranchList();
            ddl.DataSource = oData;
            ddl.DataTextField = "branch_name";
            ddl.DataValueField = "branch_id";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLDepartmentList(DropDownList ddl, int BranchId)
        {
            ddl.Items.Clear();
            DataTable oData = new DataTable();
            oData = DAL.Department.getDepartmentListByBranchId(BranchId);
            ddl.DataSource = oData;
            ddl.DataTextField = "department_name";
            ddl.DataValueField = "departmentid";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLBranchListList(DropDownList ddl, string OrgCode)
        {
            DataTable oData = new DataTable();
            oData = DAL.Branch.getBranchListByOrgCode(OrgCode);
            ddl.DataSource = oData;
            ddl.DataTextField = "branch_name";
            ddl.DataValueField = "branch_id";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLOrganizationList(DropDownList ddl,string empcode)
        {
            DataTable oData = new DataTable();
            oData = DAL.Organization.getOrganizationList(empcode);
            ddl.DataSource = oData;
            ddl.DataTextField = "OrganizationName";
            ddl.DataValueField = "OrganizationCode";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }
        public static void fillDDLVendor(DropDownList ddl)
        {
            DataTable oData = new DataTable();
            oData = DAL.Organization.getVendors();
            ddl.DataSource = oData;
            ddl.DataTextField = "OrganizationName";
            ddl.DataValueField = "OrganizationCode";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLProductsList(DropDownList ddl)
        {
            DataTable oData = new DataTable();
            oData = DAL.Product.getProductList();
            ddl.DataSource = oData;
            ddl.DataTextField = "itemname";
            ddl.DataValueField = "itemcode";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLContactListNew(DropDownList ddl, string OrgCode, TextBox SiteAddress)
        {
            ddl.Items.Clear();
            DataTable oData = new DataTable();
            oData = DAL.Contact.getContactDetailsByOrgCode(OrgCode);
            if (oData != null)
            {
                for (int x = 0; x < oData.Rows.Count; x++)
                {
                    string FullName = oData.Rows[x]["Basic_FName"].ToString() + " " + oData.Rows[x]["Basic_MName"].ToString() + " " + oData.Rows[x]["Basic_LName"].ToString();
                    ddl.Items.Add(new ListItem(FullName, oData.Rows[x]["ContactId"].ToString()));
                }
            }

            ddl.Items.Insert(0, new ListItem("Select", "0"));
            SiteAddress.Text = oData.Rows[0]["SiteAdd"].ToString();
        }

        public static void fillDDLContactList(DropDownList ddl, string OrgCode)
        {
            ddl.Items.Clear();
            DataTable oData = new DataTable();
            oData = DAL.Contact.getContactDetailsByOrgCode(OrgCode);
            if (oData != null)
            {
                for (int x = 0; x < oData.Rows.Count; x++)
                {
                    string FullName = oData.Rows[x]["Basic_FName"].ToString() + " " + oData.Rows[x]["Basic_MName"].ToString() + " " + oData.Rows[x]["Basic_LName"].ToString();
                    ddl.Items.Add(new ListItem(FullName, oData.Rows[x]["ContactId"].ToString()));
                }
            }

            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLCategoryList(DropDownList ddl)
        {
            DataTable oData = new DataTable();
            oData = DAL.Category.getCategoryList();
            ddl.DataSource = oData;
            ddl.DataTextField = "CategoryName";
            ddl.DataValueField = "CategoryId";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLEmployee(DropDownList ddl)
        {
            DataTable oData = new DataTable();
            oData = DAL.Employeedetail.getEmployeeList();
            ddl.DataSource = oData;
            if (oData != null)
            {
                for (int x = 0; x < oData.Rows.Count; x++)
                {
                    string FullName = oData.Rows[x]["emp_fname"].ToString() + " " + oData.Rows[x]["emp_m_name"].ToString() + " " + oData.Rows[x]["emp_l_name"].ToString();
                    ddl.Items.Add(new ListItem(FullName, oData.Rows[x]["empcode"].ToString()));
                }
            }
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLEmployeeByDesignation(DropDownList ddl, int desig)
        {
            DataTable oData = new DataTable();
            oData = DAL.Designation.getUserRoleDetailByDesignationid(desig);
            ddl.DataSource = oData;
            ddl.DataTextField = "EmpFullName";
            ddl.DataValueField = "empcode";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLOrganizationByType(DropDownList ddl, int type)
        {
            DataTable oData = new DataTable();
            oData = DAL.Organization.getOrganizationByAccountType(type);
            ddl.DataSource = oData;
            ddl.DataTextField = "OrganizationName";
            ddl.DataValueField = "OrganizationCode";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLAccountTypeList(DropDownList ddl)
        {
            DataTable oData = new DataTable();
            oData = DAL.AccountType.getAccountTypeList();
            ddl.DataSource = oData;
            ddl.DataTextField = "AccountTypeName";
            ddl.DataValueField = "AccountTypeId";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLContactTypeList(DropDownList ddl)
        {
            DataTable oData = new DataTable();
            oData = DAL.ContactType.getContactTypeList();
            ddl.DataSource = oData;
            ddl.DataTextField = "ContactTypeName";
            ddl.DataValueField = "ContactTypeId";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLOpportunityList(DropDownList ddl, string empcode, string CustomerCode)
        {
            DataTable oData = new DataTable();
            oData = DAL.Opportunity.getAllOpportunityList(empcode, CustomerCode);
            ddl.DataSource = oData;
            ddl.DataTextField = "OpportunityId";
            ddl.DataValueField = "OpportunityId";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLOpportunityNo(DropDownList ddl, string CustomerCode)
        {
            DataTable oData = new DataTable();
            oData = DAL.Opportunity.getAllOpportunityNo(CustomerCode);
            ddl.DataSource = oData;
            ddl.DataTextField = "OpportunityId";
            ddl.DataValueField = "OpportunityId";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLEnquiryNo(DropDownList ddl, string CustomerCode)
        {
            DataTable oData = new DataTable();
            oData = DAL.Enquiry.getAllEnquiryNo(CustomerCode);
            ddl.DataSource = oData;
            ddl.DataTextField = "EnquriesId";
            ddl.DataValueField = "EnquriesId";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }


        public static void fillDDLOpportunityContactPersonList(DropDownList ddl, string empcode, string ContactPerson)
        {
            DataTable oData = new DataTable();
            oData = DAL.Opportunity.getAllContactPersonList(empcode, ContactPerson);
            ddl.DataSource = oData;
            ddl.DataTextField = "ContactPersonName";
            ddl.DataValueField = "ContactPersonName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }
        public static void fillddlApprovalStatus(DropDownList ddl)
        {
            DataTable oData = new DataTable();
            oData = DAL.Opportunity.getQuotesStatus();
            ddl.DataSource = oData;
            ddl.DataTextField = "quotestatus";
            ddl.DataValueField = "id";
            ddl.DataBind();
            if(ddl.Items.FindByValue("1")!=null)
            ddl.SelectedValue = "1";
        }
        public static void fillDDLOpportunityCustomerList(DropDownList ddl, string empcode)
        {
            DataTable oData = new DataTable();
            oData = DAL.Opportunity.getAllCustomerList(empcode);
            ddl.DataSource = oData;
            ddl.DataTextField = "CustomerName";
            ddl.DataValueField = "CustomerId";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLSampleProductsList(DropDownList ddl)
        {
            DataTable oData = new DataTable();
            oData = DAL.Product.getSampleProductList();
            ddl.DataSource = oData;
            ddl.DataTextField = "itemname";
            ddl.DataValueField = "itemcode";
            ddl.DataBind();

            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLCustomerTypeList(DropDownList ddl)
        {
            DataTable oData = new DataTable();
            oData = DAL.CustomerType.getCustomerTypeList();
            ddl.DataSource = oData;
            ddl.DataTextField = "CustomerTypeName";
            ddl.DataValueField = "CustomerTypeId";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLMarketSchemeList(DropDownList ddl)
        {
            DataTable oData = new DataTable();
            oData = DAL.Marketing.getMarketingTypeList();
            ddl.DataSource = oData;
            ddl.DataTextField = "MarketingSchemeName";
            ddl.DataValueField = "MarketingSchemeId";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillDDLDesignationList(DropDownList ddl)
        {
            DataTable oData = new DataTable();
            oData = DAL.Designation.getDesignationList();
            ddl.DataSource = oData;
            ddl.DataTextField = "designation_name";
            ddl.DataValueField = "designationid";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        // For model on selection of type

        public static void fillDDLModelListItemType(DropDownList ddl, string itemgroupname)
        {
            DataTable oData = new DataTable();
            oData = DAL.Model.getItemtypeModelList(itemgroupname);
            ddl.DataSource = oData;
            ddl.DataTextField = "itemtypename";
            ddl.DataValueField = "itemtypeid";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));

        }

        public static void fillDDLQuotesTaxList(DropDownList ddl)  //, string TId
        {
            DataTable oData = new DataTable();
            oData = DAL.Quotes.getQuotesTax();
            ddl.DataSource = oData;
            ddl.DataTextField = "TaxType";
            ddl.DataValueField = "TaxId";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        // Fill CheckBoxList

        public static void fillChkOrganizationList(CheckBoxList chk,string empcode)
        {
            DataTable oData = new DataTable();
            oData = DAL.Organization.getOrganizationList(empcode);
            chk.DataSource = oData;
            chk.DataTextField = "OrganizationName";
            chk.DataValueField = "OrganizationCode";
            chk.DataBind();
            //ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillChkContactList(CheckBoxList chk, string Contact)
        {
            DataTable oData = new DataTable();
            oData = DAL.Contact.getContactByName(Contact);
            chk.DataSource = oData;
            if (oData != null)
            {
                for (int x = 0; x < oData.Rows.Count; x++)
                {
                    string FullName = oData.Rows[x]["Basic_FName"].ToString() + " " + oData.Rows[x]["Basic_MName"].ToString() + " " + oData.Rows[x]["Basic_LName"].ToString();
                    chk.Items.Add(new ListItem(FullName, oData.Rows[x]["ContactId"].ToString()));
                }
            }
            //chk.DataSource = oData;
            //chk.DataTextField = "OrganizationName";
            //chk.DataValueField = "OrganizationCode";
            //chk.DataBind();
            //ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillTaxType(DropDownList ddl)
        {
            
            DataTable oData = new DataTable();
            oData = DAL.Quotes.getTaxTypes(); ;
            ddl.DataSource = oData;
            ddl.DataTextField = "TaxType";
            ddl.DataValueField = "TaxId";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static DataTable GetAllTask(string empcode)
        {
            return DAL.Task.GetAllTask(empcode);

        }

        public static void fillddlAssignTo_employees(DropDownList ddl, string empcode)
        {
            DataTable oData = DAL.Designation.getEmployeeByRole(empcode);
            ddl.Items.Clear();
            ddl.DataSource = oData;
            ddl.DataTextField = "EmpFullName";
            ddl.DataValueField = "empcode";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
        }

        public static void fillddlStatusEnquiry(DropDownList ddl)
        {
            DataTable oData = DAL.Enquiry.getEnquiryStatus();
            ddl.Items.Clear();
            ddl.DataSource = oData;
            ddl.DataTextField = "EnquiryStatus";
            ddl.DataValueField = "id";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
            ddl.SelectedValue = "2"; // 2 - Pending
            
        }

        public static int getEnquiryStatus(int EnqId)
        {
            return DAL.Enquiry.getEnquiryStatus(EnqId);
            
        }
    }
}