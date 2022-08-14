using System;
using System.Collections.Generic;
using System.Text;
using AspireWebHR.Models;

namespace AspireWebHR.Controllers
{
    public class JobOpeningController : Controller
    {

        public static int interAmountPaid = -1;

        public int AddJobOpening(DateTime DatePosted, string CompanyName, string ClientName, string JobLocation, string InterviewLocation, string RecruiterID, string ClientContact,
            int Vacancy, string Role, int SalaryRange, string Experience, int WorkingHours, int WorkingDays, int WeeklyOff, string Gender, string Nationality, bool ArabicSpeaker, bool Accomodation,
            bool Transport, bool Meals, string INOUT, string Status, int AmountPaid)
        {
            JobOpeningModel openingInstance = new JobOpeningModel(DatePosted, CompanyName, ClientName, JobLocation, InterviewLocation, RecruiterID, ClientContact, Vacancy, Role, SalaryRange, Experience, WorkingHours,
                WorkingDays, WeeklyOff, Gender, Nationality, ArabicSpeaker, Accomodation, Transport, Meals, INOUT, Status, AmountPaid);

            try
            {
                return dbInstance.RunInsertionQuery(openingInstance.QueryizeInsert());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
                return -1;
            }

        }

        public int ModifyJobOpening(int openingID, DateTime DatePosted, string CompanyName, string ClientName, string JobLocation, string InterviewLocation, string RecruiterID, string ClientContact,
            int Vacancy, string Role, int SalaryRange, string Experience, int WorkingHours, int WorkingDays, int WeeklyOff, string Gender, string Nationality, bool ArabicSpeaker, bool Accomodation,
            bool Transport, bool Meals, string INOUT, string Status, int AmountPaid)
        {
            JobOpeningModel openingInstance = new JobOpeningModel(DatePosted, openingID, CompanyName, ClientName, JobLocation, InterviewLocation, RecruiterID, ClientContact, Vacancy, Role, SalaryRange, Experience, WorkingHours,
            WorkingDays, WeeklyOff, Gender, Nationality, ArabicSpeaker, Accomodation, Transport, Meals, INOUT, Status, AmountPaid);


            try
            {
                return dbInstance.RunModificationQuery(openingInstance.QueryizeGeneralUpdate());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
                return -1;
            }
        }

        public int ModifyJobOpening(string query)
        {
            try
            {
                return dbInstance.RunModificationQuery(query);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
                return -1;
            }
        }
    }
}
