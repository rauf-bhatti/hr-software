using System;
using System.Collections.Generic;
using System.Text;
using AspireWebHR.Models;

namespace AspireWebHR.Validators
{
    class RecruiterValidator : IValidator
    {
        public bool ValidateDataLength(string dataString, int lowerbound, int upperbound)
        {
            if (dataString.Length <= 0 || dataString.Length < lowerbound) //Empty check is common to all login data that needs to be validated.
                return false;

            if (dataString.Length > upperbound)
                return false;

            return true;
        }

        public int Validate(RecruiterModel recruiterInstance)
        {
            if (ValidateDataLength(recruiterInstance.EmployeeID, 1, 6) && ValidateDataLength(recruiterInstance.Title, 2, 100) && ValidateDataLength(recruiterInstance.FirstName, 2, 100)
                && ValidateDataLength(recruiterInstance.MiddleName, 2, 100) && ValidateDataLength(recruiterInstance.LastName, 2, 100) && ValidateDataLength(recruiterInstance.MobileNumber, 2, 20)
                && ValidateDataLength(recruiterInstance.EmailID, 2, 100) && ValidateDataLength(recruiterInstance.Nationality, 2, 20) && ValidateDataLength(recruiterInstance.Address, 2, 300)
                && ValidateDataLength(recruiterInstance.SupervisorName, 2, 100) && ValidateDataLength(recruiterInstance.Notes, 2, 1000))
            {
                if (recruiterInstance.Salary < 0 || recruiterInstance.Age < 10 || recruiterInstance.Medical_Leaves < 0 || recruiterInstance.Non_Medical_Leaves < 0)
                {
                    return -1; //Indicating that some error including negative values has occured.
                }

                return 1;
            }
            else
            {
                return 2; //Error Indicating that data lengths were not followed.
            }

        }
    }
}
