using System;
using System.Collections.Generic;
using System.Text;
using AspireWebHR.Models;

namespace AspireWebHR.Controllers
{
    class RuntimeController : Controller
    {
        private static List<CandidateModel> candidates = new List<CandidateModel>();
        private static List<RecruiterModel> recruiters = new List<RecruiterModel>();
        private static List<JobOpeningModel> jobOpenings = new List<JobOpeningModel>();

        public static string RecruiterID = "1";
        public static string RecruiterFullName = "Rauf";
        public static int RecruiterLevel = 1;

        private void SetCandidatesList(List<CandidateModel> candidatesList)
        {
            candidates = candidatesList;
        }

        private void SetRecruitersList(List<RecruiterModel> recruitersList)
        {
            recruiters = recruitersList;
        }

        private void SetJobOpeningList(List<JobOpeningModel> jobOpeningList)
        {
            jobOpenings = jobOpeningList;
        }

        public List<CandidateModel> GetAllCandidatesByKey(string key)
        {
            if (RuntimeController.candidates == null)
                return null;

            List<CandidateModel> toReturn = new List<CandidateModel>();
            
            for (int i = 0; i < RuntimeController.candidates.Count; i++)
            {
                if (RuntimeController.candidates[i].FirstName.Contains(key) || RuntimeController.candidates[i].MiddleName.Contains(key) || RuntimeController.candidates[i].LastName.Contains(key))
                {
                    toReturn.Add(candidates[i]);
                }
            }

            return toReturn;
        }

        public List<CandidateModel> GetAllCandidates()
        {
            List<CandidateModel> candidates = new List<CandidateModel>();
            int count = 0;
            CandidateController candidateController = new CandidateController();
            try
            {
                dynamic dataReader = dbInstance.RunReceiveQuery("SELECT * FROM Candidate_Table", 1);

                while (dataReader.Read())
                {
                    candidates.Add(new CandidateModel(Convert.ToInt32(dataReader["CANDIDATE_ID"].ToString()), Convert.ToInt32(dataReader["RecruiterID"].ToString()), dataReader["EntryDate"], dataReader["FirstName"].ToString(), dataReader["MiddleName"].ToString(), dataReader["LastName"].ToString(), Convert.ToInt32(dataReader["Age"].ToString()), dataReader["MobileNumber"].ToString(), dataReader["EmailID"].ToString(), dataReader["MaritalStatus"].ToString(), dataReader["Nationality"].ToString(), 
                        dataReader["Address"].ToString(), dataReader["Birthdate"], dataReader["Gender"].ToString(), dataReader["ReferenceName"].ToString()));
                    candidates[count].CandidateExperience = candidateController.GetCandidateJobHistory(candidates[count].CandidateID);
                    count++;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
            }


            SetCandidatesList(candidates);
            return candidates;
        }

        public List<RecruiterModel> GetAllRecruiters()
        {
            List<RecruiterModel> recruiters = new List<RecruiterModel>();

            dynamic dataReader = dbInstance.RunReceiveQuery("SELECT * FROM Employees_Table", 1);

            List<dynamic> paramlist = new List<dynamic>();

            while (dataReader.Read())
            {
                paramlist.Add(dataReader["EMPLOYEE_ID"].ToString());
                paramlist.Add(dataReader["Title"]);
                paramlist.Add(dataReader["FirstName"].ToString());
                paramlist.Add(dataReader["MiddleName"].ToString());
                paramlist.Add(dataReader["LastName"].ToString());
                paramlist.Add(Convert.ToInt32(dataReader["Age"].ToString()));
                paramlist.Add(dataReader["MobileNumber"].ToString());
                paramlist.Add(dataReader["EmailID"].ToString());
                paramlist.Add(dataReader["Nationality"].ToString());
                paramlist.Add(dataReader["Address"].ToString());
                paramlist.Add(dataReader["Birthdate"]);
                paramlist.Add(dataReader["Gender"].ToString());
                paramlist.Add(dataReader["MaritalStatus"].ToString());
                paramlist.Add(dataReader["Hiredate"]);
                paramlist.Add(dataReader["SupervisorName"].ToString());
                paramlist.Add(dataReader["Department"].ToString());
                paramlist.Add(Convert.ToInt32(dataReader["Salary"].ToString()));
                paramlist.Add(Convert.ToInt32(dataReader["MedicalLeaves"].ToString()));
                paramlist.Add(Convert.ToInt32(dataReader["NonMedicalLeaves"].ToString()));
                paramlist.Add(dataReader["Notes"].ToString());
                paramlist.Add(dataReader["On_Leave"]);
                paramlist.Add(dataReader["user_password"].ToString());
                paramlist.Add(Convert.ToInt32(dataReader["user_level"].ToString()));

                recruiters.Add(new RecruiterModel(paramlist[0], paramlist[1], paramlist[2], paramlist[3], paramlist[4], paramlist[5], paramlist[6], paramlist[7], paramlist[8], paramlist[9], paramlist[10],
                    paramlist[11], paramlist[12], paramlist[13], paramlist[14], paramlist[15], paramlist[16], paramlist[17], paramlist[18], paramlist[19], paramlist[20], paramlist[21], paramlist[22]));
            }


            SetRecruitersList(recruiters);
            return recruiters;
        }

        public List<JobOpeningModel> GetAllJobOpenings()
        {
            dynamic dataReader = dbInstance.RunReceiveQuery("SELECT * FROM Job_Openings", 1);
            List<JobOpeningModel> jobOpenings = new List<JobOpeningModel>();


            while (dataReader.Read())
            {
                if (dataReader["AmountPaid"] <= 0)
                {
                    jobOpenings.Add(new JobOpeningModel(dataReader["DatePosted"], dataReader["OPENING_ID"], dataReader["CompanyName"], dataReader["ClientName"], dataReader["JobLocation"], dataReader["InterviewLocation"],
                    dataReader["EMPLOYEE_ID"], dataReader["ClientContact"], dataReader["Vacancy"], dataReader["Role"], dataReader["SalaryRange"], dataReader["Experience"], dataReader["WorkingHours"], dataReader["WorkingDays"],
                    dataReader["WeeklyOff"], dataReader["Gender"], dataReader["Nationality"], dataReader["ArabicSpeaker"], dataReader["Accomodation"], dataReader["Transport"], dataReader["Meals"],
                    dataReader["INOUT"], dataReader["Status"], 0));
                }
                else
                {
                    jobOpenings.Add(new JobOpeningModel(dataReader["DatePosted"], dataReader["OPENING_ID"], dataReader["CompanyName"], dataReader["ClientName"], dataReader["JobLocation"], dataReader["InterviewLocation"],
                    dataReader["EMPLOYEE_ID"], dataReader["ClientContact"], dataReader["Vacancy"], dataReader["Role"], dataReader["SalaryRange"], dataReader["Experience"], dataReader["WorkingHours"], dataReader["WorkingDays"],
                    dataReader["WeeklyOff"], dataReader["Gender"], dataReader["Nationality"], dataReader["ArabicSpeaker"], dataReader["Accomodation"], dataReader["Transport"], dataReader["Meals"],
                    dataReader["INOUT"], dataReader["Status"], dataReader["AmountPaid"]));
                }
            }
            SetJobOpeningList(jobOpenings);
            return jobOpenings;
        }

        public List<JobOpeningModel> GetAllJobOpenings(string Status)
        {
            dynamic dataReader = dbInstance.RunReceiveQuery($"SELECT * FROM Job_Openings WHERE Status = '{Status}'", 1);
            List<JobOpeningModel> jobOpenings = new List<JobOpeningModel>();


            while (dataReader.Read())
            {
                if (dataReader["AmountPaid"] <= 0)
                {
                    jobOpenings.Add(new JobOpeningModel(dataReader["DatePosted"], dataReader["OPENING_ID"], dataReader["CompanyName"], dataReader["ClientName"], dataReader["JobLocation"], dataReader["InterviewLocation"],
                    dataReader["EMPLOYEE_ID"], dataReader["ClientContact"], dataReader["Vacancy"], dataReader["Role"], dataReader["SalaryRange"], dataReader["Experience"], dataReader["WorkingHours"], dataReader["WorkingDays"],
                    dataReader["WeeklyOff"], dataReader["Gender"], dataReader["Nationality"], dataReader["ArabicSpeaker"], dataReader["Accomodation"], dataReader["Transport"], dataReader["Meals"],
                    dataReader["INOUT"], dataReader["Status"], 0));
                }
                else
                {
                    jobOpenings.Add(new JobOpeningModel(dataReader["DatePosted"], dataReader["OPENING_ID"], dataReader["CompanyName"], dataReader["ClientName"], dataReader["JobLocation"], dataReader["InterviewLocation"],
                    dataReader["EMPLOYEE_ID"], dataReader["ClientContact"], dataReader["Vacancy"], dataReader["Role"], dataReader["SalaryRange"], dataReader["Experience"], dataReader["WorkingHours"], dataReader["WorkingDays"],
                    dataReader["WeeklyOff"], dataReader["Gender"], dataReader["Nationality"], dataReader["ArabicSpeaker"], dataReader["Accomodation"], dataReader["Transport"], dataReader["Meals"],
                    dataReader["INOUT"], dataReader["Status"], dataReader["AmountPaid"]));
                }
            }
            SetJobOpeningList(jobOpenings);
            return jobOpenings;
        }



        public List<RecruiterModel> GetAllRecruitersByKey(string key)
        {
            if (RuntimeController.recruiters == null)
                return null;

            List<RecruiterModel> toReturn = new List<RecruiterModel>();

            for (int i = 0; i < RuntimeController.recruiters.Count; i++)
            {
                if (RuntimeController.recruiters[i].FirstName.Contains(key) || RuntimeController.recruiters[i].MiddleName.Contains(key) || RuntimeController.recruiters[i].LastName.Contains(key))
                {
                    toReturn.Add(recruiters[i]);
                }

            }

            return toReturn;
        }

        public static RecruiterModel GetRecruiterFromIndex(int index)
        {
            return recruiters[index];
        }

        public static CandidateModel GetCandidateFromIndex(int index)
        {
            return candidates[index];
        }

        public static JobOpeningModel GetOpeningFromIndex(int index)
        {
            return jobOpenings[index];
        }
    }
}
