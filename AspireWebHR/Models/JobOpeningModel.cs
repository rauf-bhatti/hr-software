using System;
using System.Collections.Generic;
using System.Text;

namespace AspireWebHR.Models
{
    public class JobOpeningModel
    {
        public int OpeningID { get; set; }
        public DateTime DatePosted { get; set; }
        public string CompanyName { get; set; }
        public string ClientName { get; set; }
        public string JobLocation { get; set; }
        public string InterviewLocation { get; set; }
        public string RecruiterID { get; set; }
        public string ClientContact { get; set; }
        public int Vacancy { get; set; }
        public string Role { get; set; }
        public int SalaryRange { get; set; }
        public string Experience { get; set; }
        public int WorkingHours { get; set; }
        public int WorkingDays { get; set; }
        public int WeeklyOff { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Language { get; set; }
        public bool Accomodation { get; set; }
        public bool Transport { get; set; }
        public bool Meals { get; set; }
        public string INOUT { get; set; }
        public string Status { get; set; }
        public int AmountPaid { get; set; }
        public string Remarks { get; set; }
        public JobOpeningModel() { }

        public JobOpeningModel(DateTime DatePosted, string CompanyName, string ClientName, string JobLocation, string InterviewLocation, string RecruiterID, string ClientContact,
            int Vacancy, string Role, int SalaryRange, string Experience, int WorkingHours, int WorkingDays, int WeeklyOff, string Gender, string Nationality, string Language, bool Accomodation,
            bool Transport, bool Meals, string INOUT, string Status, int AmountPaid, string Remarks)
        {
            this.DatePosted = DatePosted;
            this.CompanyName = CompanyName;
            this.ClientName = ClientName;
            this.JobLocation = JobLocation;
            this.InterviewLocation = InterviewLocation;
            this.RecruiterID = RecruiterID;
            this.ClientContact = ClientContact;
            this.Vacancy = Vacancy;
            this.Role = Role;
            this.SalaryRange = SalaryRange;
            this.Experience = Experience;
            this.WorkingHours = WorkingHours;
            this.WorkingDays = WorkingDays;
            this.WeeklyOff = WeeklyOff;
            this.Gender = Gender;
            this.Nationality = Nationality;
            this.Language = Language;
            this.Accomodation = Accomodation;
            this.Transport = Transport;
            this.Meals = Meals;
            this.INOUT = INOUT;
            this.Status = Status;
            this.AmountPaid = AmountPaid;
            this.Remarks = Remarks;
        }

        public JobOpeningModel(DateTime DatePosted, int OpeningID, string CompanyName, string ClientName, string JobLocation, string InterviewLocation, string RecruiterID, string ClientContact,
            int Vacancy, string Role, int SalaryRange, string Experience, int WorkingHours, int WorkingDays, int WeeklyOff, string Gender, string Nationality, string Language, bool Accomodation,
            bool Transport, bool Meals, string INOUT, string Status, int AmountPaid, string Remarks)
        {
            this.OpeningID = OpeningID;
            this.DatePosted = DatePosted;
            this.CompanyName = CompanyName;
            this.ClientName = ClientName;
            this.JobLocation = JobLocation;
            this.InterviewLocation = InterviewLocation;
            this.RecruiterID = RecruiterID;
            this.ClientContact = ClientContact;
            this.Vacancy = Vacancy;
            this.Role = Role;
            this.SalaryRange = SalaryRange;
            this.Experience = Experience;
            this.WorkingHours = WorkingHours;
            this.WorkingDays = WorkingDays;
            this.WeeklyOff = WeeklyOff;
            this.Gender = Gender;
            this.Nationality = Nationality;
            this.Language = Language;
            this.Accomodation = Accomodation;
            this.Transport = Transport;
            this.Meals = Meals;
            this.INOUT = INOUT;
            this.Status = Status;
            this.AmountPaid = AmountPaid;
            this.Remarks = Remarks;
        }

        public string QueryizeInsert()
        {
            return $"INSERT INTO Job_Openings(DatePosted, CompanyName, ClientName, JobLocation, InterviewLocation, employee_id, ClientContact, Vacancy, Role, SalaryRange, Experience, WorkingHours, WorkingDays, WeeklyOff, Gender, Nationality, Language, Accomodation, Transport, Meals, INOUT, Status, AmountPaid, Remarks) " +
                $"VALUES ('{this.DatePosted.Year}-{this.DatePosted.Month}-{this.DatePosted.Day}', '{this.CompanyName}', '{this.ClientName}', '{this.JobLocation}', '{this.InterviewLocation}', '{this.RecruiterID}', '{this.ClientContact}', '{this.Vacancy}', '{this.Role}', '{this.SalaryRange}', '{this.Experience}', '{this.WorkingHours}', '{this.WorkingDays}', '{this.WeeklyOff}', '{this.Gender}', '{this.Nationality}', '{this.Language}', '{this.Accomodation}', '{this.Transport}', " +
                $"'{this.Meals}', '{this.INOUT}', 'Active', 0, '{this.Remarks}');";
        }

        public string QueryizeGeneralUpdate()
        {
            return $"UPDATE Job_Openings SET DatePosted = '{this.DatePosted.Year}-{this.DatePosted.Month}-{this.DatePosted.Day}', CompanyName = '{this.CompanyName}', ClientName = '{this.ClientName}', JobLocation = '{this.JobLocation}', InterviewLocation = '{this.InterviewLocation}', employee_id = '{this.RecruiterID}', ClientContact = '{this.ClientContact}', Vacancy = '{this.Vacancy}'," +
                $"Role = '{this.Role}', SalaryRange = '{this.SalaryRange}', Experience = '{this.Experience}', WorkingHours = '{this.WorkingHours}', WorkingDays = '{this.WorkingDays}', WeeklyOff = '{this.WeeklyOff}', Gender = '{this.Gender}', Nationality = '{this.Nationality}', Language = '{this.Language}', Accomodation = '{this.Accomodation}', Transport = '{this.Transport}', Meals = '{this.Meals}', INOUT = '{this.INOUT}', Remarks = '{this.Remarks}' " +
                $"WHERE opening_id = {this.OpeningID}";
        }

        public string QueryizeStatusUpdate(int AmountPaid, string NewStatus)
        {
            return $"UPDATE Job_Openings SET AmountPaid = {AmountPaid}, Status = '{NewStatus}' WHERE opening_id = {this.OpeningID}";
        }

        public string QueryizeDelete()
        {
            return $"DELETE FROM Job_Openings WHERE opening_id = {this.OpeningID}";
        }
    }
}
