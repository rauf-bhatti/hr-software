using System;
using System.Collections.Generic;
using System.Text;

namespace AspireWebHR.Models
{
    public class LeaveModel
    {
        public int LeaveID { get; set; }
        public string EmployeeID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Reason { get; set; }
        public string Category { get; set; }
        public string ApprovedStatus { get; set; }


        public LeaveModel(string EmployeeID, DateTime FromDate, DateTime ToDate, string Reason, string Category, string ApprovedStatus)
        {
            this.EmployeeID = EmployeeID;
            this.FromDate = FromDate;
            this.ToDate = ToDate;
            this.Reason = Reason;
            this.Category = Category;
            this.ApprovedStatus = ApprovedStatus;
        }

        public LeaveModel(int LeaveID, string EmployeeID, DateTime FromDate, DateTime ToDate, string Reason, string Category, string ApprovedStatus)
        {
            this.LeaveID = LeaveID;
            this.EmployeeID = EmployeeID;
            this.FromDate = FromDate;
            this.ToDate = ToDate;
            this.Reason = Reason;
            this.Category = Category;
            this.ApprovedStatus = ApprovedStatus;
        }

        public string QueryizeInsert()
        {
            return $"INSERT INTO Leaves (EMPLOYEE_ID, FromDate, ToDate, Reason, Category, Approved_Status)" +
                $" VALUES ('{this.EmployeeID}', '{this.FromDate.Year}-{this.FromDate.Month}-{this.FromDate.Day}', '{this.ToDate.Year}-{this.ToDate.Month}-{this.ToDate.Day}', '{this.Reason}', '{this.Category}', '{this.ApprovedStatus}');";
        }

        public string QueryizeApprove()
        {
            this.ApprovedStatus = "Approved";
            return $"UPDATE Leaves SET Approved_Status = '{this.ApprovedStatus}' WHERE Leave_ID = '{this.LeaveID}'";
        }

        public string QueryizeDecline()
        {
            this.ApprovedStatus = "Declined";
            return $"UPDATE Leaves SET Approved_Status = '{this.ApprovedStatus}' WHERE Leave_ID = '{this.LeaveID}'";
        }
    }
}
