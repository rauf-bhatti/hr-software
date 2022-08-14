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
        public bool ArabicSpeaker { get; set; }
        public bool Accomodation { get; set; }
        public bool Transport { get; set; }
        public bool Meals { get; set; }
        public string INOUT { get; set; }
        public string Status { get; set; }
        public int AmountPaid { get; set; }


        public int JobID { get; set; }
        public string OpeningTitle { get; set; }
        public DateTime OpeningDate { get; set; }

        public JobOpeningModel() { }

        public JobOpeningModel(DateTime DatePosted, string CompanyName, string ClientName, string JobLocation, string InterviewLocation, string RecruiterID, string ClientContact,
            int Vacancy, string Role, int SalaryRange, string Experience, int WorkingHours, int WorkingDays, int WeeklyOff, string Gender, string Nationality, bool ArabicSpeaker, bool Accomodation,
            bool Transport, bool Meals, string INOUT, string Status, int AmountPaid)
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
            this.ArabicSpeaker = ArabicSpeaker;
            this.Accomodation = Accomodation;
            this.Transport = Transport;
            this.Meals = Meals;
            this.INOUT = INOUT;
            this.Status = Status;
            this.AmountPaid = AmountPaid;
        }

        public JobOpeningModel(DateTime DatePosted, int OpeningID, string CompanyName, string ClientName, string JobLocation, string InterviewLocation, string RecruiterID, string ClientContact,
            int Vacancy, string Role, int SalaryRange, string Experience, int WorkingHours, int WorkingDays, int WeeklyOff, string Gender, string Nationality, bool ArabicSpeaker, bool Accomodation,
            bool Transport, bool Meals, string INOUT, string Status, int AmountPaid)
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
            this.ArabicSpeaker = ArabicSpeaker;
            this.Accomodation = Accomodation;
            this.Transport = Transport;
            this.Meals = Meals;
            this.INOUT = INOUT;
            this.Status = Status;
            this.AmountPaid = AmountPaid;
        }

        public string QueryizeInsert()
        {
            return $"INSERT INTO Job_Openings(DatePosted, CompanyName, ClientName, JobLocation, InterviewLocation, employee_id, ClientContact, Vacancy, Role, SalaryRange, Experience, WorkingHours, WorkingDays, WeeklyOff, Gender, Nationality, ArabicSpeaker, Accomodation, Transport, Meals, INOUT, Status, AmountPaid) " +
                $"VALUES ('{this.DatePosted}', '{this.CompanyName}', '{this.ClientName}', '{this.JobLocation}', '{this.InterviewLocation}', '{this.RecruiterID}', '{this.ClientContact}', '{this.Vacancy}', '{this.Role}', '{this.SalaryRange}', '{this.Experience}', '{this.WorkingHours}', '{this.WorkingDays}', '{this.WeeklyOff}', '{this.Gender}', '{this.Nationality}', '{this.ArabicSpeaker}', '{this.Accomodation}', '{this.Transport}', " +
                $"'{this.Meals}', '{this.INOUT}', 'Active', 0);";
        }

        public string QueryizeGeneralUpdate()
        {
            return $"UPDATE Job_Openings SET DatePosted = '{this.DatePosted}', CompanyName = '{this.CompanyName}', ClientName = '{this.ClientName}', JobLocation = '{this.JobLocation}', InterviewLocation = '{this.InterviewLocation}', employee_id = '{this.RecruiterID}', ClientContact = '{this.ClientContact}', Vacancy = '{this.Vacancy}'," +
                $"Role = '{this.Role}', SalaryRange = '{this.SalaryRange}', Experience = '{this.Experience}', WorkingHours = '{this.WorkingHours}', WorkingDays = '{this.WorkingDays}', WeeklyOff = '{this.WeeklyOff}', Gender = '{this.Gender}', Nationality = '{this.Nationality}', ArabicSpeaker = '{this.ArabicSpeaker}', Accomodation = '{this.Accomodation}', Transport = '{this.Transport}', Meals = '{this.Meals}', INOUT = '{this.INOUT}' " +
                $"WHERE opening_id = {this.OpeningID}";
        }

        public string QueryizeStatusUpdate(int AmountPaid, string NewStatus)
        {
            return $"UPDATE Job_Openings SET AmountPaid = {AmountPaid}, Status = '{NewStatus}' WHERE opening_id = {this.OpeningID}";
        }
    }
}
