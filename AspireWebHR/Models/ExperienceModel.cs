using System;
using System.Collections.Generic;
using System.Text;

namespace AspireWebHR.Models
{
    class ExperienceModel
    {
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }
        public int Duration { get; set; }
        public string LeavingReason { get; set; }

        public ExperienceModel(string CompanyName, string JobTitle, int Salary, int Duration, string LeavingReason)
        {

            if (CompanyName.Equals(""))
            {
                return; //Ensuring that an empty object is not made!
            }

            this.CompanyName = CompanyName;
            this.JobTitle = JobTitle;
            this.Salary = Salary;
            this.Duration = Duration;
            this.LeavingReason = LeavingReason;
        }
    }
}
