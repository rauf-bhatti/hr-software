using System;
using System.Collections.Generic;
using System.Text;
using AspireWebHR.Validators;
using AspireWebHR.Models;

namespace AspireWebHR.Controllers
{
    class RecruiterController : Controller
    {
        private RecruiterValidator recruiterValidator = new RecruiterValidator();



        public bool AddRecruiter(string EmployeeID, string FirstName, string MiddleName, string LastName, int Age, string MobileNumber, string EmailID, string Nationality,
             string Address, DateTime BirthDate, string Gender, string MaritalStatus, DateTime HireDate, string SupervisorName, string Department, int Salary, int Medical_Leaves,
             int Non_Medical_Leaves, string Notes)
        {
            RecruiterModel _recruiterInstance = new RecruiterModel(EmployeeID, FirstName, MiddleName, LastName, Age, MobileNumber, EmailID, Nationality,
             Address, BirthDate, Gender, MaritalStatus, HireDate, SupervisorName, Department, Salary, Medical_Leaves,
             Non_Medical_Leaves, Notes, true, "123", 1);

            dbInstance.RunInsertionQuery(_recruiterInstance.QueryizeInsert());

            return true;
        }

    }
}
