using System;
using System.Collections.Generic;
using System.Text;

namespace AspireWebHR.Models
{
    public class IncentiveModel
    {
        public int IncentiveID { get; set; }
        public string EmployeeID { get; set; }
        public DateTime IncentiveDate { get; set; }
        public int Percentage { get; set; }
        public bool StatusClient { get; set; } //Paid by Client
        public bool StatusAspire { get; set; } //Paid by AspireWeb
        public float Incentives { get; set; }


        public IncentiveModel(int IncentiveID, string EmployeeID, DateTime IncentiveDate, int Percentage, bool StatusClient, bool StatusAspire)
        {
            this.IncentiveID = IncentiveID;
            this.EmployeeID = EmployeeID;
            this.IncentiveDate = IncentiveDate;
            this.Percentage = Percentage;
            this.StatusClient = StatusClient;
            this.StatusAspire = StatusAspire;
        }
        
        public IncentiveModel(string EmployeeID, DateTime IncentiveDate, int Percentage, bool StatusClient, bool StatusAspire)
        {
            this.EmployeeID = EmployeeID;
            this.IncentiveDate = IncentiveDate;
            this.Percentage = Percentage;
            this.StatusClient = StatusClient;
            this.StatusAspire = StatusAspire;
        }

        public IncentiveModel() { }

        public string QueryizeInsert()
        {
            return $"INSERT INTO Incentives (EMPLOYEE_ID, IncentiveDate, Percentage, StatusClient, StatusAspire) VALUES ('{this.EmployeeID}', '{this.IncentiveDate.Year}-{this.IncentiveDate.Month}-{this.IncentiveDate.Day}', '{this.Percentage}', false, false)";
        }

        public string QueryizeDelete()
        {
            return $"DELETE FROM Incentives WHERE IncentiveID = {this.IncentiveID};";
        }

        public string QueryizeStatusUpdate(int flag)
        {
            if (flag == 1) //means update client
            {
                return $"UPDATE Incentives SET StatusClient = {!this.StatusClient} WHERE IncentiveID = {this.IncentiveID}";
            }
            else
            {
                return $"UPDATE Incentives SET StatusAspire = {!this.StatusAspire} WHERE IncentiveID = {this.IncentiveID}";

            }

        }
    }
}