using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Task1
/// </summary>
/// 
namespace DAL
{
    public class Task1
    {
        public Task1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable getTaskByTaskId(int TaskId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_internate_Task1 where TaskId = '" + TaskId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getTaskByAssignTo(string AssignTo)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_internate_Task1 where AssignTo = '" + AssignTo + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable SearchTask(string strSortField, string strSortDir, int pageSize, int pageNum, string TaskName, string DueDate, string StartDate, string DueBy, string StartBy, string AssignTo, int Category, string Status, string CreatedBy, string UpdatedBy, string keyWord)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SearchTask1";
                objCmd.Parameters.AddWithValue("@strSortField", strSortField);
                objCmd.Parameters.AddWithValue("@strSortDir", strSortDir);
                objCmd.Parameters.AddWithValue("@intPageSize", pageSize.ToString());
                objCmd.Parameters.AddWithValue("@intPageNumber", pageNum.ToString());
                objCmd.Parameters.AddWithValue("@TaskName", TaskName);
                objCmd.Parameters.AddWithValue("@DueDate", DueDate);
                objCmd.Parameters.AddWithValue("@StartDate", StartDate);
                objCmd.Parameters.AddWithValue("@DueBy", DueBy);
                objCmd.Parameters.AddWithValue("@StartBy", StartBy);
                objCmd.Parameters.AddWithValue("@AssignTo", AssignTo);
                objCmd.Parameters.AddWithValue("@Category", Category);
                objCmd.Parameters.AddWithValue("@Status", Status);
                objCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@keyWord", keyWord);

                DataSet oDS = new DataSet();
                oDS = SFA.DataConnect.GetDataSet(objCmd);
                if (oDS != null)
                {
                    oData = oDS.Tables[0];
                    DataColumn RecordCount = new DataColumn("RecordCount");
                    oData.Columns.Add(RecordCount);
                    if (oData.Rows.Count > 0)
                    {
                        oData.Rows[0]["RecordCount"] = oDS.Tables[1].Rows[0][0].ToString();
                    }
                }
            }
            catch
            {

            }
            return oData;
        }

        public static int savetask(int TaskId, string TaskName, string TaskDescription, DateTime DueDate, DateTime StartDate, string DueBy, string StartBy, string AssignTo, int Category, string Status, string CreatedBy, DateTime CreatedDate, string UpdatedBy, DateTime UpdatedDate)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveTask1";
                objCmd.Parameters.AddWithValue("@TaskIdout", TaskId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@TaskId", TaskId);
                objCmd.Parameters.AddWithValue("@TaskName", TaskName);
                objCmd.Parameters.AddWithValue("@TaskDescription", TaskDescription);

                if (DueDate == null || DueDate == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                {
                    objCmd.Parameters.AddWithValue("@DueDate", DBNull.Value);
                }
                else
                {
                    objCmd.Parameters.AddWithValue("@DueDate", DueDate);
                }

                if (StartDate == null || StartDate == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                {
                    objCmd.Parameters.AddWithValue("@Startdate", DBNull.Value);
                }
                else
                {
                    objCmd.Parameters.AddWithValue("@Startdate", StartDate);
                }
                objCmd.Parameters.AddWithValue("@DueBy", DueBy);

                objCmd.Parameters.AddWithValue("@StartBy", StartBy);
                objCmd.Parameters.AddWithValue("@AssignTo", AssignTo);
                objCmd.Parameters.AddWithValue("@Category", Category);
                objCmd.Parameters.AddWithValue("@Status", Status);
                objCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                objCmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);

                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@TaskIdout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public static int deleteDeleteTask(string TaskId, string TaskIdList)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_DeleteTask1";
                objCmd.Parameters.AddWithValue("@TaskId", TaskId);
                objCmd.Parameters.AddWithValue("@TaskIdList", TaskIdList);
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        //Update_Task_New(TaskId, comments, status, empcode, Today)
        public static int Update_Task_New(int TaskId, string comments, string UpdatedBy, DateTime UpdatedDate, Boolean Status)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_UpdateTaskNew";
                objCmd.Parameters.AddWithValue("@TaskIdout", TaskId).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@TaskId", TaskId);
                objCmd.Parameters.AddWithValue("@comments", comments);                
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
                objCmd.Parameters.AddWithValue("@Status", Status);

                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@TaskIdout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        //savetask_Call(EnqId, CallDate, Convert.ToDateTime(TxtCallTime.Text), txtContactPerson.Text, txtContactNumber.Text, txtCallNotes.Text, empcode, Today, empcode, Today, flag)
        public static int savetask_New(int EnqId, int taskId, string Task, DateTime Date, DateTime Time, string ContactPerson, string ContactNumber, string Notes, string CreatedBy, DateTime CreatedDate, string UpdatedBy, DateTime UpdatedDate, Boolean Status, Boolean flag)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveTaskNew";
                objCmd.Parameters.AddWithValue("@TaskIdout", 0).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@EnquiryId", EnqId);
                objCmd.Parameters.AddWithValue("@taskId", taskId);
                objCmd.Parameters.AddWithValue("@Task", Task);
                //objCmd.Parameters.AddWithValue("@Date", Date);
                //objCmd.Parameters.AddWithValue("@Time", Time);

                if (Date == null)
                {
                    objCmd.Parameters.AddWithValue("@Date", DBNull.Value);
                }
                else
                {
                    objCmd.Parameters.AddWithValue("@Date", Date);
                }
                if (Time == null)
                {
                    objCmd.Parameters.AddWithValue("@Time", DBNull.Value);
                }
                else
                {
                    objCmd.Parameters.AddWithValue("@Time", Time);
                }

                objCmd.Parameters.AddWithValue("@ContactPerson", ContactPerson);
                objCmd.Parameters.AddWithValue("@ContactNumber", ContactNumber);
                objCmd.Parameters.AddWithValue("@Notes", Notes);
                objCmd.Parameters.AddWithValue("@samplename", "");
                objCmd.Parameters.AddWithValue("@quantity", 0);
                objCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                objCmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
                objCmd.Parameters.AddWithValue("@Status", Status);
                objCmd.Parameters.AddWithValue("@flag", flag);

                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@TaskIdout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public static int savetask_NewMeeting(int EnqId, int taskId, string Task, DateTime Date, DateTime Time, DateTime ReturnTime, string ContactPerson, string ContactNumber, string Venue, string Notes, string imageName, string CreatedBy, DateTime CreatedDate, string UpdatedBy, DateTime UpdatedDate, Boolean Status, Boolean flag)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveTaskNewMeeting";
                objCmd.Parameters.AddWithValue("@TaskIdout", 0).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@EnquiryId", EnqId);
                objCmd.Parameters.AddWithValue("@taskId", taskId);
                objCmd.Parameters.AddWithValue("@Task", Task);
                //objCmd.Parameters.AddWithValue("@Date", Date);
                //objCmd.Parameters.AddWithValue("@Time", Time);

                if (Date == null)
                {
                    objCmd.Parameters.AddWithValue("@Date", DBNull.Value);
                }
                else
                {
                    objCmd.Parameters.AddWithValue("@Date", Date);
                }
                if (Time == null)
                {
                    objCmd.Parameters.AddWithValue("@Time", DBNull.Value);
                }
                else
                {
                    objCmd.Parameters.AddWithValue("@Time", Time);
                }
                if (ReturnTime == null)
                {
                    objCmd.Parameters.AddWithValue("@ReturnTime", DBNull.Value);
                }
                else
                {
                    objCmd.Parameters.AddWithValue("@ReturnTime", ReturnTime);
                }


                objCmd.Parameters.AddWithValue("@ContactPerson", ContactPerson);
                objCmd.Parameters.AddWithValue("@ContactNumber", ContactNumber);
                objCmd.Parameters.AddWithValue("@Venue", Venue);
                objCmd.Parameters.AddWithValue("@Notes", Notes);
                objCmd.Parameters.AddWithValue("@samplename", "");
                objCmd.Parameters.AddWithValue("@quantity", 0);
                objCmd.Parameters.AddWithValue("@upload", imageName);
                objCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                objCmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
                objCmd.Parameters.AddWithValue("@Status", Status);
                objCmd.Parameters.AddWithValue("@flag", flag);

                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@TaskIdout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public static int updatetask_New(int taskId, string comments, string UpdatedBy, DateTime UpdatedDate, Boolean Status)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_UpdateTaskNew";
                objCmd.Parameters.AddWithValue("@TaskIdout", 0).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@taskId", taskId);
                objCmd.Parameters.AddWithValue("@comments", comments);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
                objCmd.Parameters.AddWithValue("@Status", Status);

                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@TaskIdout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public static string updategeneralActivity(string Id, string comments, DateTime UpdatedDate, Boolean Status)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_UpdateGeneralActivity";
                objCmd.Parameters.AddWithValue("@Idout", "0").Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@Id", Id);
                objCmd.Parameters.AddWithValue("@comments", comments);
                //objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@ActivityDate", UpdatedDate);
                objCmd.Parameters.AddWithValue("@Status", Status);

                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToString(objCmd.Parameters["@Idout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return "0";
        }
        public static DataTable FillTask_New(string strSortField, string strSortDir, int pageSize, int pageNum, int day,string name, int protype)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {   
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SearchTaskAllUser";
                objCmd.Parameters.AddWithValue("@strSortField", strSortField);
                objCmd.Parameters.AddWithValue("@strSortDir", strSortDir);
                objCmd.Parameters.AddWithValue("@intPageSize", pageSize);
                objCmd.Parameters.AddWithValue("@intPageNumber", pageNum);
                objCmd.Parameters.AddWithValue("@day", day);
                objCmd.Parameters.AddWithValue("@name", name);
                objCmd.Parameters.AddWithValue("@proc_t", protype);

                 DataSet oDS = new DataSet();
                oDS = SFA.DataConnect.GetDataSet(objCmd);
                if (oDS != null)
                {
                    oData = oDS.Tables[0];
                    DataColumn RecordCount = new DataColumn("RecordCount");
                    oData.Columns.Add(RecordCount);
                    if (oData.Rows.Count > 0)
                    {
                        oData.Rows[0]["RecordCount"] = oDS.Tables[1].Rows[0][0].ToString();
                    }
                }
            }
            catch
            {

            }
            return oData;
        }

        // For View All Task 
        public static DataTable FillTaskAll_New(string strSortField, string strSortDir, int pageSize, int pageNum, int day, string name, int protype )
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SearchTaskAllUser";
                objCmd.Parameters.AddWithValue("@strSortField", strSortField);
                objCmd.Parameters.AddWithValue("@strSortDir", strSortDir);
                objCmd.Parameters.AddWithValue("@intPageSize", pageSize);
                objCmd.Parameters.AddWithValue("@intPageNumber", pageNum);
                objCmd.Parameters.AddWithValue("@day", day);
                objCmd.Parameters.AddWithValue("@name", name);
                objCmd.Parameters.AddWithValue("@proc_t", protype);

                DataSet oDS = new DataSet();
                oDS = SFA.DataConnect.GetDataSet(objCmd);
                if (oDS != null)
                {
                    oData = oDS.Tables[0];
                    DataColumn RecordCount = new DataColumn("RecordCount");
                    oData.Columns.Add(RecordCount);
                    if (oData.Rows.Count > 0)
                    {
                        oData.Rows[0]["RecordCount"] = oDS.Tables[1].Rows[0][0].ToString();
                    }
                }
            }
            catch
            {

            }
            return oData;
        }
        public static int GetEnquiryId(int taskId)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "SELECT EnquiryId FROM tbl_internate_TaskNew WHERE Taskid = '" + taskId + "'";
                return SFA.DataConnect.ExecuteSQLQuery2(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        // opportunity edit in opportunity task view change status 
        public static int GetOpportunityId(int taskId)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            { 
            objCmd.CommandText = "SELECT OppId FROM tbl_internate_Opportunity_TaskNew where TaskId ='" + taskId + "'";
            return SFA.DataConnect.ExecuteSQLQuery2(objCmd);
            }
            catch
            {}
            return 0;
        }

        public static int updatetaskopportunity_New(int taskId, string comments, string UpdatedBy, DateTime UpdatedDate, Boolean Status)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "[SFA_usp_UpdateTaskOpportunity]";
                objCmd.Parameters.AddWithValue("@TaskIdout", 0).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@taskId", taskId);
                objCmd.Parameters.AddWithValue("@comments", comments);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
                objCmd.Parameters.AddWithValue("@Status", Status);

                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@TaskIdout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public static DataTable FillTask_Opportunity(string strSortField, string strSortDir, int pageSize, int pageNum, int day, string name, int protype)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SearchTaskOpportunity";
                objCmd.Parameters.AddWithValue("@strSortField", strSortField);
                objCmd.Parameters.AddWithValue("@strSortDir", strSortDir);
                objCmd.Parameters.AddWithValue("@intPageSize", pageSize);
                objCmd.Parameters.AddWithValue("@intPageNumber", pageNum);
                objCmd.Parameters.AddWithValue("@day", day);
                objCmd.Parameters.AddWithValue("@name", name);
                objCmd.Parameters.AddWithValue("@proc_t", protype);


                DataSet oDS = new DataSet();
                oDS = SFA.DataConnect.GetDataSet(objCmd);
                if (oDS != null)
                {
                    oData = oDS.Tables[0];
                    DataColumn RecordCount = new DataColumn("RecordCount");
                    oData.Columns.Add(RecordCount);
                    if (oData.Rows.Count > 0)
                    {
                        oData.Rows[0]["RecordCount"] = oDS.Tables[1].Rows[0][0].ToString();
                    }
                }
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable FillTaskAll_Opportunity(string strSortField, string strSortDir, int pageSize, int pageNum, int day, string name, int protype)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SearchTaskOpportunity";
                objCmd.Parameters.AddWithValue("@strSortField", strSortField);
                objCmd.Parameters.AddWithValue("@strSortDir", strSortDir);
                objCmd.Parameters.AddWithValue("@intPageSize", pageSize);
                objCmd.Parameters.AddWithValue("@intPageNumber", pageNum);
                objCmd.Parameters.AddWithValue("@day", day);
                objCmd.Parameters.AddWithValue("@name", name);
                objCmd.Parameters.AddWithValue("@proc_t", protype);


                DataSet oDS = new DataSet();
                oDS = SFA.DataConnect.GetDataSet(objCmd);
                if (oDS != null)
                {
                    oData = oDS.Tables[0];
                    DataColumn RecordCount = new DataColumn("RecordCount");
                    oData.Columns.Add(RecordCount);
                    if (oData.Rows.Count > 0)
                    {
                        oData.Rows[0]["RecordCount"] = oDS.Tables[1].Rows[0][0].ToString();
                    }
                }
            }
            catch
            {

            }
            return oData;
        }




        // Save Group Task

        public static int saveGroupTask(int Id, string GroupCode, DateTime StartDate, DateTime EndDate, string Activity, string AssignedTo, string AssignedBy, string Customer, DateTime CreatedDate, string UpdatedBy, DateTime UpdatedDate, Boolean Status, Boolean flag)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveGroupTask";
                objCmd.Parameters.AddWithValue("@IdOut", Id).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@Id", Id);
                objCmd.Parameters.AddWithValue("@GroupCode", GroupCode);
                
                if (StartDate == null || StartDate == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                {
                    objCmd.Parameters.AddWithValue("@StartDate", DBNull.Value);
                }
                else
                {
                    objCmd.Parameters.AddWithValue("@StartDate", StartDate);
                }

                if (EndDate == null || EndDate == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                {
                    objCmd.Parameters.AddWithValue("EndDate", DBNull.Value);
                }
                else
                {
                    objCmd.Parameters.AddWithValue("EndDate", EndDate);
                }
                objCmd.Parameters.AddWithValue("@Activity", Activity);

                objCmd.Parameters.AddWithValue("@AssignedTo", AssignedTo);
                objCmd.Parameters.AddWithValue("@AssignedBy", AssignedBy);
                objCmd.Parameters.AddWithValue("@Customer", Customer);
                objCmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
                objCmd.Parameters.AddWithValue("@Status", Status);
                objCmd.Parameters.AddWithValue("@Flag", flag);

                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@Idout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public static DataTable SearchAllTasks()
        {

            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SelectAllTask";
               
                DataSet oDS = new DataSet();
                oDS = SFA.DataConnect.GetDataSet(objCmd);
                //if (oDS != null)
                //{
                    oData = oDS.Tables[0];
                //    DataColumn RecordCount = new DataColumn("RecordCount");
                //    oData.Columns.Add(RecordCount);
                //    if (oData.Rows.Count > 0)
                //    {
                //        oData.Rows[0]["RecordCount"] = oDS.Tables[1].Rows[0][0].ToString();
                //    }
                //}
            }
            catch
            {

            }
            return oData;
        }


        public static DataTable SearchGrouTask(string strSortField, string strSortDir, int pageSize, int pageNum, int Id, string empcode, int mode, string role)//, string GroupCode, DateTime StartDate, DateTime EndDate, string Activity, string AssignedTo, string AssignedBy, string Customer, DateTime CreatedDate, string UpdatedBy, DateTime UpdatedDate, Boolean status)
        {

            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SearchGroupTask";
                objCmd.Parameters.AddWithValue("@strSortField", strSortField);
                objCmd.Parameters.AddWithValue("@strSortDir", strSortDir);
                objCmd.Parameters.AddWithValue("@intPageSize", pageSize.ToString());
                objCmd.Parameters.AddWithValue("@intPageNumber", pageNum.ToString());
                objCmd.Parameters.AddWithValue("@Id", Id);
                objCmd.Parameters.AddWithValue("@empcode", empcode);
                objCmd.Parameters.AddWithValue("@mode", mode);
                objCmd.Parameters.AddWithValue("@role", role);
                //objCmd.Parameters.AddWithValue("@GroupCode", GroupCode);
                //objCmd.Parameters.AddWithValue("@StartDate", StartDate);
                //objCmd.Parameters.AddWithValue("@EndDate", EndDate);
                
                //objCmd.Parameters.AddWithValue("@Activity", Activity);
                //objCmd.Parameters.AddWithValue("@AssignedTo", AssignedTo);
                //objCmd.Parameters.AddWithValue("@AssignedBy", AssignedBy);
                //objCmd.Parameters.AddWithValue("@Customer", Customer);
                //objCmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                
                //objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                //objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
                //objCmd.Parameters.AddWithValue("@Status", status);

                DataSet oDS = new DataSet();
                oDS = SFA.DataConnect.GetDataSet(objCmd);
                if (oDS != null)
                {
                    oData = oDS.Tables[0];
                    DataColumn RecordCount = new DataColumn("RecordCount");
                    oData.Columns.Add(RecordCount);
                    if (oData.Rows.Count > 0)
                    {
                        oData.Rows[0]["RecordCount"] = oDS.Tables[1].Rows[0][0].ToString();
                    }
                }
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable SearchGrouTaskContact(string strSortField, string strSortDir, int pageSize, int pageNum, int Id,string empcode,int mode,string role)//, string GroupCode, DateTime StartDate, DateTime EndDate, string Activity, string AssignedTo, string AssignedBy, string Customer, DateTime CreatedDate, string UpdatedBy, DateTime UpdatedDate, Boolean status)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "[SFA_usp_SearchGroupTaskContact]";
                objCmd.Parameters.AddWithValue("@strSortField", strSortField);
                objCmd.Parameters.AddWithValue("@strSortDir", strSortDir);
                objCmd.Parameters.AddWithValue("@intPageSize", pageSize.ToString());
                objCmd.Parameters.AddWithValue("@intPageNumber", pageNum.ToString());
                objCmd.Parameters.AddWithValue("@Id", Id);
                objCmd.Parameters.AddWithValue("@empcode", empcode);
                objCmd.Parameters.AddWithValue("@mode", mode);
                objCmd.Parameters.AddWithValue("@role", role);

                DataSet oDS = new DataSet();
                oDS = SFA.DataConnect.GetDataSet(objCmd);
                if (oDS != null)
                {
                    oData = oDS.Tables[0];
                    DataColumn RecordCount = new DataColumn("RecordCount");
                    oData.Columns.Add(RecordCount);
                    if (oData.Rows.Count > 0)
                    {
                        oData.Rows[0]["RecordCount"] = oDS.Tables[1].Rows[0][0].ToString();
                    }
                }
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable SearchGrouTaskGeneral(string strSortField, string strSortDir, int pageSize, int pageNum, int Id, string empcode, int mode,string role)//, string GroupCode, DateTime StartDate, DateTime EndDate, string Activity, string AssignedTo, string AssignedBy, string Customer, DateTime CreatedDate, string UpdatedBy, DateTime UpdatedDate, Boolean status)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "[SFA_usp_SearchGroupTaskGeneral]";
                objCmd.Parameters.AddWithValue("@strSortField", strSortField);
                objCmd.Parameters.AddWithValue("@strSortDir", strSortDir);
                objCmd.Parameters.AddWithValue("@intPageSize", pageSize.ToString());
                objCmd.Parameters.AddWithValue("@intPageNumber", pageNum.ToString());
                objCmd.Parameters.AddWithValue("@Id", Id);
                objCmd.Parameters.AddWithValue("@empcode", empcode);
                objCmd.Parameters.AddWithValue("@mode", mode);
                objCmd.Parameters.AddWithValue("@role", role);


                DataSet oDS = new DataSet();
                oDS = SFA.DataConnect.GetDataSet(objCmd);
                if (oDS != null)
                {
                    oData = oDS.Tables[0];
                    DataColumn RecordCount = new DataColumn("RecordCount");
                    oData.Columns.Add(RecordCount);
                    if (oData.Rows.Count > 0)
                    {
                        oData.Rows[0]["RecordCount"] = oDS.Tables[1].Rows[0][0].ToString();
                    }
                }
            }
            catch
            {

            }
            return oData;
        }
        //Update GroupTask

        public static int UpdateGroupTask(int Id, string Activity, string UpdatedBy, DateTime UpdatedDate, Boolean Status)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "[SFA_usp_UpdateGroupTask]";
                objCmd.Parameters.AddWithValue("@Idout", 0).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@Id", Id);
                objCmd.Parameters.AddWithValue("@Activity", Activity);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
                objCmd.Parameters.AddWithValue("@Status", Status);

                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@Idout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public static DataTable SearchAllTasks(string TaskType, string KeyWord, string startdate, string enddate,string orderby,string empcode)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SelectAllTask";
                objCmd.Parameters.AddWithValue("@TaskType", TaskType);
                objCmd.Parameters.AddWithValue("@KeyWord", KeyWord);
                objCmd.Parameters.AddWithValue("@StartDate", startdate);
                objCmd.Parameters.AddWithValue("@enddate", enddate);
                objCmd.Parameters.AddWithValue("@orderby", orderby);
                objCmd.Parameters.AddWithValue("@empcode", empcode);


                DataSet oDS = new DataSet();
                oDS = SFA.DataConnect.GetDataSet(objCmd);
                //if (oDS != null)
                //{
                oData = oDS.Tables[0];
                //    DataColumn RecordCount = new DataColumn("RecordCount");
                //    oData.Columns.Add(RecordCount);
                //    if (oData.Rows.Count > 0)
                //    {
                //        oData.Rows[0]["RecordCount"] = oDS.Tables[1].Rows[0][0].ToString();
                //    }
                //}
            }
            catch(Exception ex)
            {

            }
            return oData;
        }

        public static int SetReturned(string tasktype, int taskid, bool returnstatus,string empcode,string samplecomments)
        {//SFA_usp_SetSampleReturnStatus

            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SetSampleReturnStatus";
                objCmd.Parameters.AddWithValue("@retval", 0).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@status", returnstatus);
                objCmd.Parameters.AddWithValue("@tasktype", tasktype);
                objCmd.Parameters.AddWithValue("@taskid", taskid);
                objCmd.Parameters.AddWithValue("@empcode", empcode);
                objCmd.Parameters.AddWithValue("@samplestatuscomments", samplecomments);

                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@retval"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public static DataTable SampleReturnList()
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_selectsamplestatus";



                DataSet oDS = new DataSet();
                oDS = SFA.DataConnect.GetDataSet(objCmd);
            
                oData = oDS.Tables[0];
                return oData;
            }
            catch (Exception ex)
            {
                return null;
            }
          
        }

    } 
}

