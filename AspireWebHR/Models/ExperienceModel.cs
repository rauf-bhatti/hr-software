using System;
using System.Collections.Generic;
using System.Text;

namespace AspireWebHR.Models
{
    public class ExperienceModel
    {
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }
        public int Duration { get; set; }
        public string LeavingReason { get; set; }

        public ExperienceModel(string CompanyName, string JobTitle, int Salary, int Duration, string LeavingReason)
        {

            if (CompanyName == null || JobTitle == null || Duration == 0 || Salary == 0 || LeavingReason == null)
            {
                return; //Ensuring that an empty object is not made!
            }

            this.CompanyName = CompanyName;
            this.JobTitle = JobTitle;
            this.Salary = Salary;
            this.Duration = Duration;
            this.LeavingReason = LeavingReason;
        }

        public string QueryizeExperience(int index)
        {
            return $"INSERT INTO Job_History (CANDIDATE_ID, CompanyName, JobTitle, Salary, Duration, LeavingReason)" +
                $" VALUES ('{index}', '{CompanyName}', '{JobTitle}', '{Salary}', '{Duration}', '{LeavingReason}')";
        }

        public static string QueryizeGet(int candidateKey)
        {
            return $"SELECT * FROM Job_History WHERE CANDIDATE_ID = {candidateKey}";
        }
    }
}
