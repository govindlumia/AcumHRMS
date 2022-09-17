using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for FutureTask
/// </summary>
/// 
namespace DAL
{ 


        public class FutureTask
        {
            public static DataTable getFutureTaskListByOppId(int OppId)
            {
                DataTable oData = new DataTable();
                SqlCommand objCmd = new SqlCommand();
                try
                {
                    objCmd.CommandText = "Select * From tbl_internate_FutureTask where OppId = '" + OppId + "'";
                    oData = SFA.DataConnect.GetDataTable(objCmd);
                
            }
                catch 
                {
               
                }
                return oData;
        }
            public static DataTable getFutureTaskByFutureTaskId(int FutureTaskId)
            {
                DataTable oData = new DataTable();
                SqlCommand objCmd = new SqlCommand();
                try
                {
                    objCmd.CommandText = "Select * from tbl_internate_FutureTask where FutureTaskId = '" + FutureTaskId + "'";
                    oData = SFA.DataConnect.GetDataTable(objCmd);
                }
                catch
                { 
                
                }
                return oData;
            
            }
            public static int savefuturetask(int FutureTaskId, string FutureTaskName, string FutureTaskDescription, DateTime FutureDueDate, DateTime FutureStartDate, string FutureDueBy, string FutureStartBy, string FutureAssignTo, int FutureCategory, string FutureStatus, string FutureCreatedBy, DateTime FutureCreatedDate, string FutureUpdatedBy, DateTime FutureUpdatedDate, int OppId)
            {
               
                DataTable oDate = new DataTable();
                SqlCommand objCmd = new SqlCommand();
                try
                {
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "SFA_usp_SaveFutureTask";
                    objCmd.Parameters.AddWithValue("@FutureTaskIdOut", FutureTaskId).Direction = ParameterDirection.InputOutput;
                    objCmd.Parameters.AddWithValue("@FutureTaskId", FutureTaskId);
                    objCmd.Parameters.AddWithValue("@FutureTaskName", FutureTaskName);
                    objCmd.Parameters.AddWithValue("@FutureTaskDescription", FutureTaskDescription);
                    if (FutureDueDate == null || FutureDueDate == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                    {
                        objCmd.Parameters.AddWithValue("@FutureDueDate", DBNull.Value);
                    }
                    else
                    {
                        objCmd.Parameters.AddWithValue("@FutureDueDate", FutureDueDate);
                    }

                    if (FutureStartDate == null || FutureStartDate == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                    {
                        objCmd.Parameters.AddWithValue("@FutureStartdate", DBNull.Value);
                    }
                    else
                    {
                        objCmd.Parameters.AddWithValue("@FutureStartdate", FutureStartDate);
                    }
                    objCmd.Parameters.AddWithValue("@FutureDueBy", FutureDueBy);
                    objCmd.Parameters.AddWithValue("@FutureStartBy", FutureStartBy);
                    objCmd.Parameters.AddWithValue("@FutureAssignTo", FutureAssignTo);
                    objCmd.Parameters.AddWithValue("@FutureCategory", FutureCategory);
                    //objCmd.Parameters.AddWithValue("@FutureNotifyMe", FutureNotifyMe);
                    objCmd.Parameters.AddWithValue("@FutureStatus", FutureStatus);
                    objCmd.Parameters.AddWithValue("@FutureCreatedBy", FutureCreatedBy);
                    objCmd.Parameters.AddWithValue("@FutureCreatedDate", FutureCreatedDate);
                    objCmd.Parameters.AddWithValue("@FutureUpdatedBy", FutureUpdatedBy);
                    objCmd.Parameters.AddWithValue("@FutureUpdatedDate", FutureUpdatedDate);
                    objCmd.Parameters.AddWithValue("@OppId", OppId);
                    SFA.DataConnect.ExecuteSQLQuery(objCmd);
                    return int.Parse(objCmd.Parameters["@FutureTaskIdOut"].Value.ToString());
                }
                catch (Exception ex)
                { 
                
                }
                return 0;
            }
           
        }
    }