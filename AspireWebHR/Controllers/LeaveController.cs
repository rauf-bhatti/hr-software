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
                LeaveModel leaveInstance = new LeaveModel(RuntimeController.RecruiterID, FromDate, ToDate, Reason, Category, false);
                this.dbInstance.RunInsertionQuery(leaveInstance.QueryizeInsert());

                return 1;
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
                        dataReader["Category"], Convert.ToBoolean(dataReader["Approved_Status"])));
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
