using System;
using System.Collections.Generic;
using System.Text;

namespace AspireWebHR.Models
{
    public class DepartmentModel
    {
        public string DepartmentName { get; set; }
        public int DepartmentID { get; set; }

        public DepartmentModel(string DepartmentName)
        {
            this.DepartmentName = DepartmentName;
        }

        public DepartmentModel(int DepartmentID, string DepartmentName)
        {
            this.DepartmentName = DepartmentName;
            this.DepartmentID = DepartmentID;
        }

        public string QueryizeInsert()
        {
            return $"INSERT INTO Departments (DepartmentName) VALUES ('{this.DepartmentName}');";
        }

        public string QueryizeDelete()
        {
            return $"DELETE FROM Departments WHERE DepartmentID = {DepartmentID}";
        }
    }
}
