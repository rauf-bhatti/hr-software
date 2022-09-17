using System;
using System.Collections.Generic;
using System.Text;
using AspireWebHR.Models;

namespace AspireWebHR.Controllers
{
    class LeaveController : Controller
    {
        public int AddLeave(DateTime FromDate, DateTime ToDate, string Reason, string Category)
        {
            try
            {
                LeaveModel leaveInstance = new LeaveModel(RuntimeController.RecruiterID, FromDate, ToDate, Reason, Category, "Pending");
                this.dbInstance.RunInsertionQuery(leaveInstance.QueryizeInsert());

                return 1;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
                return -1;
            }
        }

        public int ModifyLeaveStatus(string query)
        {
            try
            {
                return this.dbInstance.RunModificationQuery(query);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
                return -1;
            }
        }

        public List<LeaveModel> GetAllLeaves()
        {
            List<LeaveModel> leaveList = new List<LeaveModel>();
            try
            {
                dynamic dataReader = this.dbInstance.RunReceiveQuery("SELECT * FROM Leaves", 1);

                while (dataReader.Read())
                {
                    leaveList.Add(new LeaveModel(dataReader["LEAVE_ID"], dataReader["EMPLOYEE_ID"], dataReader["FromDate"], dataReader["ToDate"], dataReader["Reason"],
                        dataReader["Category"], dataReader["Approved_Status"]));
                }

                return leaveList;

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
                return null;
            }
        }


        public List<LeaveModel> GetAllLeavesByKey(string key)
        {
            List<LeaveModel> leaveList = GetAllLeaves();
            try
            {
                List<LeaveModel> toReturn = new List<LeaveModel>();

                for (int i = 0; i < leaveList.Count; i++)
                {
                    if (leaveList[i].EmployeeID.ToLower().Contains(key.ToLower()))
                    {
                        toReturn.Add(leaveList[i]);
                    }
                }

                return toReturn;

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
                return null;
            }
        }

        public List<LeaveModel> GetAllLeaves(string EmployeeID)
        {
            List<LeaveModel> leaveList = new List<LeaveModel>();
            try
            {
                dynamic dataReader = this.dbInstance.RunReceiveQuery($"SELECT * FROM Leaves WHERE Employee_ID = '{EmployeeID}'", 1);
                 
                while (dataReader.Read())
                {
                    leaveList.Add(new LeaveModel(dataReader["LEAVE_ID"], dataReader["EMPLOYEE_ID"], dataReader["FromDate"], dataReader["ToDate"], dataReader["Reason"],
                        dataReader["Category"], dataReader["Approved_Status"]));
                }

                return leaveList;

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
                return null;
            }
        }
    }
}
