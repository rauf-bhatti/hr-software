using System;
using System.Collections.Generic;
using System.Text;

namespace AspireWebHR.Models.FormModels
{
    public class EmployeeForms : FormModel
    {
        public string EmployeeID { get; set; }

        public EmployeeForms() : base() { }
        public EmployeeForms(string EmployeeID, string FilePath, string FormName) : base(FilePath, FormName) { this.EmployeeID = EmployeeID; }
        public EmployeeForms(string EmployeeID, int FormID, string FilePath, string FormName) : base(FormID, FilePath, FormName) { this.EmployeeID = EmployeeID; }

        public override string QueryizeInsert()
        {
            return $"INSERT INTO EmployeeForms (EMPLOYEE_ID, FileName, PathToFile) VALUES ('{EmployeeID}', '{FileName}', '{FilePath}');";
        }
        public override string QueryizeDelete()
        {
            return $"DELETE FROM EmployeeForms WHERE FormID = {base.FormID}";
        }

    }
}
