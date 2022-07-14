using System;
using System.Collections.Generic;
using System.Text;

namespace AspireWebHR.Models
{
    class CandidateModel
    {
        public int CandidateID { get; set; }
        public DateTime EntryDate { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string MobileNumber { get; set; }
        public string EmailID { get; set; }
        public string MaritalStatus { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string ReferenceName { get; set; }
        public List<ExperienceModel> CandidateExperience { get; set; }

        public CandidateModel(DateTime EntryDate, string FirstName, string MiddleName, string LastName, int Age, string MobileNumber, string EmailID, string MaritalStatus,
            string Nationality, string Address, DateTime Birthdate, string Gender, string ReferenceName, List<ExperienceModel> CandidateExperience)

        {
            this.EntryDate = EntryDate;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.LastName = LastName;
            this.Age = Age;
            this.MobileNumber = MobileNumber;
            this.EmailID = EmailID;
            this.MaritalStatus = MaritalStatus;
            this.Nationality = Nationality;
            this.Address = Address;
            this.Birthdate = Birthdate;
            this.Gender = Gender;
            this.ReferenceName = ReferenceName;
            this.CandidateExperience = CandidateExperience;
        }
    }
}
