using System;
using System.Collections.Generic;
using System.Text;

namespace AspireWebHR.Validators
{
    class RecruiterValidator : IValidator
    {
        public bool ValidateDataLength(string dataString, int upperbound, int lowerbound)
        {
            if (dataString.Length <= 0 || dataString.Length < lowerbound) //Empty check is common to all login data that needs to be validated.
                return false;

            if (dataString.Length >= upperbound)
                return false;

            return true;
        }
    }
}
