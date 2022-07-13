using System;
using System.Collections.Generic;
using System.Text;

namespace AspireWebHR.Validators
{
    public interface IValidator
    {
        public bool ValidateDataLength(string data, int upperbound, int lowerbound);
    }
}
