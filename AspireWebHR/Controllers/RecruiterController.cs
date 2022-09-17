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

        public int AddRecruiter(string EmployeeID, string Title, string FirstName, string MiddleName, string LastName, int Age, string MobileNumber, string EmailID, string Nationality,
             string Address, DateTime BirthDate, string Gender, string MaritalStatus, DateTime HireDate, string SupervisorName, string Department, int Salary, int Medical_Leaves,
             int Non_Medical_Leaves, string Notes, string attachment)
        {
            RecruiterModel _recruiterInstance = new RecruiterModel(EmployeeID, Title, FirstName, MiddleName, LastName, Age, MobileNumber, EmailID, Nationality,
             Address, BirthDate, Gender, MaritalStatus, HireDate, SupervisorName, Department, Salary, Medical_Leaves,
             Non_Medical_Leaves, Notes, true, "123", 1, attachment);

            int returnCode = recruiterValidator.Validate(_recruiterInstance);

            if (returnCode == 1)
            {
                int result = dbInstance.RunInsertionQuery(_recruiterInstance.QueryizeInsert());

                if (result < 1)
                {
                    return -3; //Employee ID already exists.
                }
            }

            return returnCode;
        }

        public int ModifyRecruiter (string EmployeeID, string Title, string FirstName, string MiddleName, string LastName, int Age, string MobileNumber, string EmailID, string Nationality,
             string Address, DateTime BirthDate, string Gender, string MaritalStatus, DateTime HireDate, string SupervisorName, string Department, int Salary, int Medical_Leaves,
             int Non_Medical_Leaves, string Notes, string pwd, int userlevel, string attachment)
        {
            RecruiterModel _recruiterInstance = new RecruiterModel(EmployeeID, Title, FirstName, MiddleName, LastName, Age, MobileNumber, EmailID, Nationality,
             Address, BirthDate, Gender, MaritalStatus, HireDate, SupervisorName, Department, Salary, Medical_Leaves,
             Non_Medical_Leaves, Notes, true, pwd, userlevel, attachment);

            int returnCode = recruiterValidator.Validate(_recruiterInstance);

            if (returnCode == 1)
            {
                int result = dbInstance.RunModificationQuery(_recruiterInstance.QueryizeModify());

                if (result < 1)
                {
                    return -3; //Employee ID already exists.
                }
            }

            return returnCode;
        }

        public int PromoteRecruiter(string query)
        {
            try
            {
                return dbInstance.RunModificationQuery(query);
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
                return -1;
            }
        }

        public int DeleteRecruiter(string query)
        {
            try
            {
                return dbInstance.RunDeletionQuery(query);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return -1;
            }
        }

        public int UpdateUserPassword(string password)
        {
            try
            {
                return dbInstance.RunModificationQuery($"UPDATE Employees_Table SET user_password = '{password}' WHERE EMPLOYEE_ID = '{RuntimeController.RecruiterID}'");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return -1;
            }
        }

        public int ResetPassword(RecruiterModel recruiterInstance)
        {
            try
            {
                return dbInstance.RunModificationQuery($"UPDATE Employees_Table SET user_password = '123' WHERE EMPLOYEE_ID = '{recruiterInstance.EmployeeID}'");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return -1;
            }
        }

    }
}
