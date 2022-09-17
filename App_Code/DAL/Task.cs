using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Task
/// </summary>
/// 
namespace DAL
{
    public class Task
    {
        public Task()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable getTaskListByOppId(string OrgId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_internate_Task where OrgId = '" + OrgId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static DataTable getTaskByTaskId(int TaskId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Select * from tbl_internate_Task where TaskId = '" + TaskId + "'";
                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }


        public static DataTable SearchTask(string strSortField, string strSortDir, int pageSize, int pageNum, string TaskName, string DueDate, string StartDate, string AssignTo, string TaskTo, int Category, string NotifyMe, string Status, string CreatedBy, string UpdatedBy)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SearchTask";
                objCmd.Parameters.AddWithValue("@strSortField", strSortField);
                objCmd.Parameters.AddWithValue("@strSortDir", strSortDir);
                objCmd.Parameters.AddWithValue("@intPageSize", pageSize.ToString());
                objCmd.Parameters.AddWithValue("@intPageNumber", pageNum.ToString());
                objCmd.Parameters.AddWithValue("@TaskName", TaskName);
                objCmd.Parameters.AddWithValue("@DueDate", DueDate);
                objCmd.Parameters.AddWithValue("@StartDate", TaskName);
                objCmd.Parameters.AddWithValue("@AssignTo", AssignTo);
                objCmd.Parameters.AddWithValue("@TaskTo", TaskTo);
                objCmd.Parameters.AddWithValue("@Category", Category);
                objCmd.Parameters.AddWithValue("@NotifyMe", NotifyMe);
                objCmd.Parameters.AddWithValue("@Status", Status);
                objCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);

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
        
        public static int savetask(int taskid, string taskname, DateTime startdate, string assignto, int category, string taskdescription, string notifyme, DateTime duedate, string taskto, string status, string OrgId, string CreatedBy, DateTime CreatedDate, string upatedBy, DateTime updatedDate, int ContactPerson, int OppId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveTask";
                objCmd.Parameters.AddWithValue("@TaskIdout", taskid).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@TaskId", taskid);
                objCmd.Parameters.AddWithValue("@TaskName", taskname);
                objCmd.Parameters.AddWithValue("@TaskDescription", taskdescription);

                if (duedate == null || duedate == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                {
                    objCmd.Parameters.AddWithValue("@DueDate", DBNull.Value);
                }
                else
                {
                    objCmd.Parameters.AddWithValue("@DueDate", duedate);
                }

                if (startdate == null || startdate == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                {
                    objCmd.Parameters.AddWithValue("@Startdate", DBNull.Value);
                }
                else
                {
                    objCmd.Parameters.AddWithValue("@Startdate", startdate);
                }

                objCmd.Parameters.AddWithValue("@AssignTo", assignto);
                objCmd.Parameters.AddWithValue("@TaskTo", taskto);
                objCmd.Parameters.AddWithValue("@Category", category);
                objCmd.Parameters.AddWithValue("@NotifyMe", notifyme);
                objCmd.Parameters.AddWithValue("@Status", status);
                objCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                objCmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                objCmd.Parameters.AddWithValue("@UpdatedBy", upatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", updatedDate);
                objCmd.Parameters.AddWithValue("@OrgId", OrgId);
                objCmd.Parameters.AddWithValue("@ContactPerson", ContactPerson);
                objCmd.Parameters.AddWithValue("@OppId", OppId);


                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@TaskIdout"].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        //Save General Task for Oppurtuntiy

        public static int savegeneraltask(int activityid, string activitydescription, DateTime activitydate, string OppId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SaveGeneralTask";
                objCmd.Parameters.AddWithValue("@GenActivityIdout", activityid).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@GenActivityId", activityid);
                objCmd.Parameters.AddWithValue("@OppId", OppId);   //organisation code and not opportunity id
                objCmd.Parameters.AddWithValue("@ActivityDescription", activitydescription);

                if (activitydate == null || activitydate == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                {
                    objCmd.Parameters.AddWithValue("@ActivityDate", DBNull.Value);
                }
                else
                {
                    objCmd.Parameters.AddWithValue("@ActivityDate", activitydate);
                }

                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@GenActivityIdout"].Value.ToString());
            }
            catch (Exception ex)
            {
                 return -1;
            }
           
        }

        //Get General Task for Oppurtunity
        public static DataTable SearchGeneralTask(string strSortField, string strSortDir, int pageSize, int pageNum,int generalTaskId,string oppurtunityid)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            DataSet oDS;
            try
            {
              
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_SearchGeneralTask";
                objCmd.Parameters.AddWithValue("@strSortField", strSortField);
                objCmd.Parameters.AddWithValue("@strSortDir", strSortDir);
                objCmd.Parameters.AddWithValue("@intPageSize", pageSize.ToString());
                objCmd.Parameters.AddWithValue("@intPageNumber", pageNum.ToString());
                objCmd.Parameters.AddWithValue("@GeneralTaskId", generalTaskId);
                objCmd.Parameters.AddWithValue("@OppurtunityId", oppurtunityid);


                oDS = new DataSet();
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
        
                return oDS.Tables[0];
            }
            catch
            {
                return null;
            }
        
        }


        //Save Recurrence Activity Details

        public static int saverecurrencetask(int recurrenceid, string recurrenceactivity, DateTime startdate,DateTime enddate,string recurrenceweekdays,string recurrencetype, string OppId)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_opportunity_Saverecurrenceactivity";
                objCmd.Parameters.AddWithValue("@RecurrenceIdOut", recurrenceid).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@RecurrenceId", recurrenceid);
                objCmd.Parameters.AddWithValue("@OpportunityId", OppId);
                objCmd.Parameters.AddWithValue("@recurrenceactivity", recurrenceactivity);
                objCmd.Parameters.AddWithValue("@recurrenceweekdays", recurrenceweekdays);
                objCmd.Parameters.AddWithValue("@recurrenceintervaltype", recurrencetype);

                if (startdate == null || startdate == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                {
                    objCmd.Parameters.AddWithValue("@startdate", DBNull.Value);
                }
                else
                {
                    objCmd.Parameters.AddWithValue("@startdate", startdate);
                }
                if (enddate == null || enddate == Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                {
                    objCmd.Parameters.AddWithValue("@enddate", DBNull.Value);
                }
                else
                {
                    objCmd.Parameters.AddWithValue("@enddate", enddate);
                }

                SFA.DataConnect.ExecuteSQLQuery(objCmd);
                return Convert.ToInt32(objCmd.Parameters["@RecurrenceIdOut"].Value.ToString());
            }
            catch (Exception ex)
            {
                return -1;
            }

        }
        //Get Recurrence Task for Oppurtunity
        public static DataTable SearchRecurrenceTask(string strSortField, string strSortDir, int pageSize, int pageNum, int recurrenceTaskId, int oppurtunityid)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            DataSet oDS;
            try
            {

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_searchrecurrenceTask";
                objCmd.Parameters.AddWithValue("@strSortField", strSortField);
                objCmd.Parameters.AddWithValue("@strSortDir", strSortDir);
                objCmd.Parameters.AddWithValue("@intPageSize", pageSize.ToString());
                objCmd.Parameters.AddWithValue("@intPageNumber", pageNum.ToString());
                objCmd.Parameters.AddWithValue("@recurrenceTaskId", recurrenceTaskId);
                objCmd.Parameters.AddWithValue("@OppurtunityId", oppurtunityid);


                oDS = new DataSet();
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

                return oDS.Tables[0];
            }
            catch
            {
                return null;
            }

        }

        public static int deleteTaskById(string Taskid)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Delete from tbl_internate_Task where Taskid = '" + Taskid + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }

        public static DataTable getTaskListByDate(string assignTo, string taskType)
        {
            string today = DateTime.Today.Date.ToShortDateString();
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                if (taskType == "Today")
                {
                    objCmd.CommandText = "Select * from View_TaskDetail where AssignTo = '" + assignTo + "' AND StartDate = convert(varchar(11),cast('" + today + "' as datetime))";
                }
                else if (taskType == "Past")
                {
                    objCmd.CommandText = "Select * from View_TaskDetail where AssignTo = '" + assignTo + "' AND StartDate < convert(varchar(11),cast('" + today + "' as datetime))";
                }
                else if (taskType == "Future")
                {
                    objCmd.CommandText = "Select * from View_TaskDetail where AssignTo = '" + assignTo + "' AND StartDate > convert(varchar(11),cast('" + today + "' as datetime))";
                }

                oData = SFA.DataConnect.GetDataTable(objCmd);
            }
            catch
            {

            }
            return oData;
        }

        public static int UpdateTask(int taskid, string Comments, string Status)
        {
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandText = "Update tbl_internate_Task set Comments= '" + Comments + "', Status = '" + Status + "' where Taskid = '" + taskid + "'";
                return SFA.DataConnect.ExecuteSQLQuery(objCmd);
            }
            catch
            {

            }
            return 0;
        }
        //Saving Call details for an opportunity
        public static int savetask_New(int OppId, int taskId, string Task, DateTime Date, DateTime Time, string ContactPerson, string ContactNumber, string Venue, string Notes, string CreatedBy, DateTime CreatedDate, string UpdatedBy, DateTime UpdatedDate, Boolean Status, Boolean flag)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_opportunity_SaveTaskNewMeeting";
                objCmd.Parameters.AddWithValue("@TaskIdout", 0).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@OppId", OppId);
                objCmd.Parameters.AddWithValue("@taskId", taskId);
                objCmd.Parameters.AddWithValue("@Task", Task);
                //objCmd.Parameters.AddWithValue("@Date", Date);
                objCmd.Parameters.AddWithValue("@ReturnTime", Convert.ToDateTime("01/01/1900"));

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
                objCmd.Parameters.AddWithValue("@Venue", "");
                objCmd.Parameters.AddWithValue("@Notes", Notes);
                objCmd.Parameters.AddWithValue("@samplename", "");
                objCmd.Parameters.AddWithValue("@quantity", 0);
                objCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                objCmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                objCmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                objCmd.Parameters.AddWithValue("@UpdatedDate", UpdatedDate);
                objCmd.Parameters.AddWithValue("@upload", "");
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
        // Saving Meeting details for an opportunity
        public static int savetask_NewMeeting(int OppId, int taskId, string Task, DateTime Date, DateTime Time, string ContactPerson, string ContactNumber, string Venue, string Notes, string imageName, string CreatedBy, DateTime CreatedDate, string UpdatedBy, DateTime UpdatedDate, Boolean Status, Boolean flag,DateTime ReturnTime)
        {
            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            try
            {
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_opportunity_SaveTaskNewMeeting";
                objCmd.Parameters.AddWithValue("@TaskIdout", 0).Direction = ParameterDirection.InputOutput;
                objCmd.Parameters.AddWithValue("@OppId", OppId);
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



        public static DataTable GetAllTask(string empcode)
        {
           //SFA_usp_AllTasksCalendarView

            DataTable oData = new DataTable();
            SqlCommand objCmd = new SqlCommand();
            DataSet oDS;
            try
            {

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "SFA_usp_AllTasksCalendarView";
                objCmd.Parameters.AddWithValue("@empcode", empcode);


                oDS = new DataSet();
                oDS = SFA.DataConnect.GetDataSet(objCmd);
               

                return oDS.Tables[0];
            }
            catch
            {
                return null;
            }
        }
    }
}
