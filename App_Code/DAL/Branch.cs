using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Branch
/// </summary>
/// 
namespace DAL
{
    public class Branch
    {
        public Branch()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable getBranchList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_branch_detail";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getBranchDetail()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_BranchDetail";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getBranchDetailListByOrg(string orgCode)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from View_BranchDetail where company_id = '" + orgCode + "'"; ;
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getBranchListByBranchId(int branch_id)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = " Select * from tbl_intranet_branch_detail where branch_id=" + branch_id.ToString();
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;

        }

        public static DataTable getBranchListByOrgCode(string orgCode)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_branch_detail where company_id = '" + orgCode + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;

        }


        public static int deleteBranchId(string branch_id)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_intranet_branch_detail where branch_id = '" + branch_id + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        public static DataTable getBranchByBranchId(int branch_id)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_intranet_branch_detail where branch_id = '" + branch_id + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static int saveBranch(int branch_id, string company_id, string branch_name, string branch_code, System.Data.SqlTypes.SqlDateTime esstt_date, string region, string add1, string city, string state, string country, string zipcode, string Telephone, string mobile_no, string fax_no, string email_id, string website, int pf_group, int pt_group, int esi_group, string UpdatedBy, DateTime UpdatedDate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveBranch";
                objCmd.Parameters.AddWithValue("@branch_idout", branch_id).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@branch_id", branch_id);
                objCmd.Parameters.AddWithValue("@company_id", company_id);
                objCmd.Parameters.AddWithValue("@branch_name", branch_name);
                objCmd.Parameters.AddWithValue("@branch_code", branch_code);
                objCmd.Parameters.AddWithValue("@esstt_date", esstt_date);
                objCmd.Parameters.AddWithValue("@region", region);
                objCmd.Parameters.AddWithValue("@add1", add1);
                objCmd.Parameters.AddWithValue("@city", city);
                objCmd.Parameters.AddWithValue("@state", state);
                objCmd.Parameters.AddWithValue("@country", country);
                objCmd.Parameters.AddWithValue("@zipcode", zipcode);
                objCmd.Parameters.AddWithValue("@Telephone", Telephone);
                objCmd.Parameters.AddWithValue("@mobile_no", mobile_no);
                objCmd.Parameters.AddWithValue("@fax_no", fax_no);
                objCmd.Parameters.AddWithValue("@email_id", email_id);
                objCmd.Parameters.AddWithValue("@website", website);
                objCmd.Parameters.AddWithValue("@pf_group", pf_group);
                objCmd.Parameters.AddWithValue("@pt_group", pt_group);
                objCmd.Parameters.AddWithValue("@esi_group", esi_group);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);


                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@branch_idout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

    }
}
