using System;
using System.Collections.Generic;
using System.Text;

namespace AspireWebHR.Models
{
    class JobOpeningModel
    {
        public int JobID { get; set; }
        public string OpeningTitle { get; set; }
        public DateTime OpeningDate { get; set; }

        public JobOpeningModel(string OpeningTitle, DateTime OpeningDate)
        {
            this.OpeningTitle = OpeningTitle;
            this.OpeningDate = OpeningDate;
        }

        public JobOpeningModel(int JobID, string OpeningTitle, DateTime OpeningDate)
        {
            this.JobID = JobID;
            this.OpeningTitle = OpeningTitle;
            this.OpeningDate = OpeningDate;
        }

        public string QueryizeInsert()
        {
            return $"INSERT INTO Job_Openings (OpeningTitle, OpeningDate) VALUES ('{this.OpeningTitle}', '{this.OpeningDate}');";
        }
    }
}
