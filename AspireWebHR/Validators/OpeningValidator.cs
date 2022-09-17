using System;
using System.Collections.Generic;
using System.Text;
using AspireWebHR.Models;

namespace AspireWebHR.Validators
{
    class OpeningValidator : IValidator
    {
        public bool ValidateDataLength(string data, int upperbound, int lowerbound)
        {
            if (data.Length <= 0 || data.Length < lowerbound) //Empty check is common to all login data that needs to be validated.
                return false;

            if (data.Length > upperbound)
                return false;

            return true;
        }

        public int Validate(JobOpeningModel openingInstance)
        {

            if (ValidateDataLength(openingInstance.CompanyName, 100, 1) && ValidateDataLength(openingInstance.ClientName, 100, 1) && ValidateDataLength(openingInstance.JobLocation, 100, 0) && ValidateDataLength(openingInstance.InterviewLocation, 100, 0)
                && ValidateDataLength(openingInstance.ClientContact, 100, 0) && openingInstance.Vacancy > 0 && ValidateDataLength(openingInstance.Role, 100, 0)
                && openingInstance.SalaryRange > 0 && ValidateDataLength(openingInstance.Experience, 100, 0) && openingInstance.WorkingDays > 0 && openingInstance.WorkingHours > 0 && openingInstance.WeeklyOff >= 0
                && ValidateDataLength(openingInstance.Nationality, 100, 0)) //Some of the values are not included as they are drop downs and do not need to be validated.
            {
                return 1; //Means everything is OK.
            }
            else
            {
                return 2; //The validations from the above IF statement fail.
            }

        }
    }
}
