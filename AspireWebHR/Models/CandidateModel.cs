using System;
using System.Collections.Generic;
using System.Text;

namespace AspireWebHR.Models
{
    public class CandidateModel
    {
        public int CandidateID { get; set; }
        public string RecruiterID { get; set; }
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

        public string JobTitle { get; set; }
        public string Skills { get; set; }
        public string ReferenceNumber { get; set; }
        public string Notes { get; set; }
        public string Attachments { get; set; }
        
        public int ExpectedSalary { get; set; }
        public string VisaStatus { get; set; }
        public string JobApplied { get; set; }


        public List<ExperienceModel> CandidateExperience { get; set; }

        public CandidateModel(string RecruiterID, DateTime EntryDate, string FirstName, string MiddleName, string LastName, int Age, string MobileNumber, string EmailID, string MaritalStatus,
            string Nationality, string Address, DateTime Birthdate, string Gender, string ReferenceName, List<ExperienceModel> CandidateExperience, string JobTitle, string Skills, string ReferenceNumber,
            string Notes, string Attachments, int ExpectedSalary, string VisaStatus, string JobApplied)

        {
            this.RecruiterID = RecruiterID;
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
            this.JobTitle = JobTitle;
            this.Skills = Skills;
            this.ReferenceNumber = ReferenceNumber;
            this.Notes = Notes;
            this.Attachments = Attachments;
            this.ExpectedSalary = ExpectedSalary;
            this.VisaStatus = VisaStatus;
            this.JobApplied = JobApplied;
        }

        public CandidateModel(int CandidateID, string RecruiterID, DateTime EntryDate, string FirstName, string MiddleName, string LastName, int Age, string MobileNumber, string EmailID, string MaritalStatus,
            string Nationality, string Address, DateTime Birthdate, string Gender, string ReferenceName, List<ExperienceModel> CandidateExperience, string JobTitle, string Skills, string ReferenceNumber,
            string Notes, string Attachments, int ExpectedSalary, string VisaStatus, string JobApplied)

        {
            this.CandidateID = CandidateID;
            this.RecruiterID = RecruiterID;
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
            this.JobTitle = JobTitle;
            this.Skills = Skills;
            this.ReferenceNumber = ReferenceNumber;
            this.Notes = Notes;
            this.Attachments = Attachments;
            this.CandidateExperience = CandidateExperience;
            this.ExpectedSalary = ExpectedSalary;
            this.VisaStatus = VisaStatus;
            this.JobApplied = JobApplied;
        }

        public CandidateModel(int CandidateID, string RecruiterID, DateTime EntryDate, string FirstName, string MiddleName, string LastName, int Age, string MobileNumber, string EmailID, string MaritalStatus,
            string Nationality, string Address, DateTime Birthdate, string Gender, string ReferenceName, string JobTitle, string Skills, string ReferenceNumber,
            string Notes, string Attachments, int ExpectedSalary, string VisaStatus, string JobApplied)

        {
            this.CandidateID = CandidateID;
            this.RecruiterID = RecruiterID;
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
            this.JobTitle = JobTitle;
            this.Skills = Skills;
            this.ReferenceNumber = ReferenceNumber;
            this.Notes = Notes;
            this.Attachments = Attachments;
            this.CandidateExperience = CandidateExperience;
            this.ExpectedSalary = ExpectedSalary;
            this.VisaStatus = VisaStatus;
            this.JobApplied = JobApplied;
        }

        public CandidateModel() { }

        public string QueryizeCandidate()
        {
            return $"INSERT INTO Candidate_Table (RecruiterID, EntryDate, FirstName, MiddleName, LastName, Age, MobileNumber, EmailID, MaritalStatus, Nationality, Address, Birthdate, Gender, ReferenceName, JobTitle, ReferenceNumber, Skills, Notes, Attachment)" +
                $" VALUES ('{this.RecruiterID}', '{this.EntryDate.Year}-{this.EntryDate.Month}-{this.EntryDate.Day}', '{this.FirstName}', '{this.MiddleName}', '{this.LastName}', '{this.Age}', '{this.MobileNumber}', '{this.EmailID}', '{this.MaritalStatus}', '{this.Nationality}', '{this.Address}', '{this.Birthdate.Year}-{this.Birthdate.Month}={this.Birthdate.Day}', '{this.Gender}', '{this.ReferenceName}', '{this.JobTitle}', '{this.ReferenceNumber}', '{this.Skills}', '{this.Notes}', '{this.Attachments}') RETURNING CANDIDATE_ID;";
        }

        public int GetExperienceLength()
        { 
            if (this.CandidateExperience == null)
            {
                return 0;
            }
            return this.CandidateExperience.Count; 
        }

        public string QueryizeModify()
        {
            return $"UPDATE Candidate_Table SET EntryDate = '{this.EntryDate.Year}-{this.EntryDate.Month}-{this.EntryDate.Day}', FirstName = '{this.FirstName}', MiddleName = '{this.MiddleName}', LastName = '{this.LastName}', Age = {this.Age}, MobileNumber = '{this.MobileNumber}', EmailID = '{this.EmailID}', MaritalStatus = '{this.MaritalStatus}', " +
                $"Nationality = '{this.Nationality}', Address = '{this.Address}', Birthdate = '{this.Birthdate.Year}-{this.Birthdate.Month}-{this.Birthdate.Day}', Gender = '{this.Gender}', ReferenceName = '{this.ReferenceName}', JobTitle = '{this.JobTitle}', ReferenceNumber = '{this.ReferenceNumber}', Skills = '{this.Skills}', Notes  = '{this.Notes}', Attachment  = '{this.Attachments}' WHERE CANDIDATE_ID = {this.CandidateID}";
        }

    }
}
