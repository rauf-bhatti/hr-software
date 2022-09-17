using System;
using System.Collections.Generic;
using System.Text;
using AspireWebHR.Models;
using AspireWebHR.Models.FormModels;

namespace AspireWebHR.Controllers
{
    class RuntimeController : Controller
    {
        private static List<CandidateModel> candidates = new List<CandidateModel>();
        private static List<RecruiterModel> recruiters = new List<RecruiterModel>();
        private static List<JobOpeningModel> jobOpenings = new List<JobOpeningModel>();
        private static List<DepartmentModel> departments = new List<DepartmentModel>();
        private List<FormModel> forms = new List<FormModel>();
        private List<ClientModel> clients = new List<ClientModel>();

        private List<EmployeeForms> employeeForms = new List<EmployeeForms>();
        private List<OtherForms> otherForms = new List<OtherForms>();
        private List<GovernmentForms> govForms = new List<GovernmentForms>();
        private List<ClientForms> clientForms = new List<ClientForms>();
        private List<CandidateForms> candidateForms = new List<CandidateForms>();

        private IncentivesController incentivesController = new IncentivesController();
        private DepartmentController deptController = new DepartmentController();
        private HRFileController fileController = new HRFileController();
        private ClientController clientController = new ClientController();


        public static string RecruiterID = "Default";
        public static string RecruiterFullName = "Default";
        public static int RecruiterLevel = 1;


        public List<EmployeeForms> GetEmployeeForms(string employeeID)
        {
            employeeForms = fileController.GetHRForms(employeeID);
            return employeeForms;
        }

        public List<CandidateForms> GetCandidateForms(int CandidateID)
        {
            candidateForms = fileController.GetCandidateForms(CandidateID);
            return candidateForms;
        }

        public List<EmployeeForms> GetEmployeeForms()
        {
            employeeForms = fileController.GetHRForms();
            return employeeForms;
        }

        public List<OtherForms> GetOtherForms()
        {
            otherForms = fileController.GetOtherForms();
            return otherForms;
        }

        public List<GovernmentForms> GetGovernmentForms()
        {
            govForms = fileController.GetGovernmentForms();
            return govForms;
        }

        public List<ClientForms> GetClientForms(int clientID)
        {
            clientForms = fileController.GetClientForms(clientID);
            return clientForms;
        }

        public EmployeeForms GetEmployeeFormFromIndex(int index)
        {
            try
            {
                return employeeForms[index];
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }

        public CandidateForms GetCandidateFormFromIndex(int index)
        {
            try
            {
                return candidateForms[index];
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }


        public GovernmentForms GetGovernmentFormFromIndex(int index)
        {
            try
            {
                return govForms[index];
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }

        public OtherForms GetOtherFormFromIndex(int index)
        {
            try
            {
                return otherForms[index];
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }

        public ClientForms GetClientFormFromIndex(int index)
        {
            try
            {
                return clientForms[index];
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }


        public List<EmployeeForms> GetEmployeeForms(string employeeID, string keyText)
        {
            List<EmployeeForms> forms = GetEmployeeForms(employeeID);
            List<EmployeeForms> toSend = new List<EmployeeForms>();

            foreach (EmployeeForms form in forms)
            {
                if (form.FileName.Contains(keyText))
                    toSend.Add(form);
            }

            this.employeeForms = toSend;
            return toSend;
        }

        public List<ClientForms> GetClientForms(int clientID, string keyText)
        {
            List<ClientForms> forms = GetClientForms(clientID);
            List<ClientForms> toSend = new List<ClientForms>();

            foreach (ClientForms form in forms)
            {
                if (form.FileName.Contains(keyText))
                    toSend.Add(form);
            }

            this.clientForms = toSend;
            return toSend;
        }


        public List<GovernmentForms> GetGovernmentForms(string keyText)
        {
            List<GovernmentForms> forms = GetGovernmentForms();
            List<GovernmentForms> toSend = new List<GovernmentForms>();

            foreach (GovernmentForms form in forms)
            {
                if (form.FileName.Contains(keyText))
                    toSend.Add(form);
            }

            this.govForms = toSend;
            return toSend;
        }

        public List<OtherForms> GetOtherForms(string keyText)
        {
            List<OtherForms> forms = GetOtherForms();
            List<OtherForms> toSend = new List<OtherForms>();

            foreach (OtherForms form in forms)
            {
                if (form.FileName.Contains(keyText))
                    toSend.Add(form);
            }

            this.otherForms = toSend;
            return toSend;
        }

        public List<CandidateForms> GetCandidateForms(int CandidateID, string keyText)
        {
            List<CandidateForms> forms = GetCandidateForms(CandidateID);
            List<CandidateForms> toSend = new List<CandidateForms>();
            foreach (CandidateForms form in forms)
            {
                if (form.FileName.Contains(keyText))
                    toSend.Add(form);
            }

            this.candidateForms = toSend;
            return toSend;
        }



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

        public IncentiveModel GetSelectedIncentive(string EmployeeID, int selectedIndex) //Index on the listview
        {
            try
            {
                return incentivesController.GetIncentives(EmployeeID)[selectedIndex];
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }

        public List<CandidateModel> GetAllCandidatesByKey(string key)
        {
            if (RuntimeController.candidates == null)
                return null;

            List<CandidateModel> toReturn = new List<CandidateModel>();
            
            for (int i = 0; i < RuntimeController.candidates.Count; i++)
            {
                if (RuntimeController.candidates[i].FirstName.Contains(key) || RuntimeController.candidates[i].MiddleName.Contains(key) || RuntimeController.candidates[i].LastName.Contains(key) || RuntimeController.candidates[i].JobTitle.Contains(key))
                {
                    toReturn.Add(candidates[i]);
                }
            }
            this.SetCandidatesList(toReturn);

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
                    candidates.Add(new CandidateModel(dataReader["CANDIDATE_ID"], dataReader["RecruiterID"], dataReader["EntryDate"], dataReader["FirstName"], dataReader["MiddleName"], dataReader["LastName"], dataReader["Age"], dataReader["MobileNumber"], dataReader["EmailID"], dataReader["MaritalStatus"], dataReader["Nationality"], 
                        dataReader["Address"], dataReader["Birthdate"], dataReader["Gender"], dataReader["ReferenceName"], dataReader["JobTitle"], dataReader["Skills"], dataReader["ReferenceNumber"], dataReader["Notes"], dataReader["Attachment"], dataReader["ExpectedSalary"], dataReader["VisaStatus"], dataReader["JobApplied"]));
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


            while (dataReader.Read())
            {
                List<dynamic> paramlist = new List<dynamic>();

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
                paramlist.Add(dataReader["attachment"]);

                recruiters.Add(new RecruiterModel(paramlist[0], paramlist[1], paramlist[2], paramlist[3], paramlist[4], paramlist[5], paramlist[6], paramlist[7], paramlist[8], paramlist[9], paramlist[10],
                    paramlist[11], paramlist[12], paramlist[13], paramlist[14], paramlist[15], paramlist[16], paramlist[17], paramlist[18], paramlist[19], paramlist[20], paramlist[21], paramlist[22], paramlist[23]));
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
                    dataReader["WeeklyOff"], dataReader["Gender"], dataReader["Nationality"], dataReader["Language"], dataReader["Accomodation"], dataReader["Transport"], dataReader["Meals"],
                    dataReader["INOUT"], dataReader["Status"], 0, (string)dataReader["Remarks"]));
                }
                else
                {
                    jobOpenings.Add(new JobOpeningModel(dataReader["DatePosted"], dataReader["OPENING_ID"], dataReader["CompanyName"], dataReader["ClientName"], dataReader["JobLocation"], dataReader["InterviewLocation"],
                    dataReader["EMPLOYEE_ID"], dataReader["ClientContact"], dataReader["Vacancy"], dataReader["Role"], dataReader["SalaryRange"], dataReader["Experience"], dataReader["WorkingHours"], dataReader["WorkingDays"],
                    dataReader["WeeklyOff"], dataReader["Gender"], dataReader["Nationality"], dataReader["Language"], dataReader["Accomodation"], dataReader["Transport"], dataReader["Meals"],
                    dataReader["INOUT"], dataReader["Status"], dataReader["AmountPaid"], (string)dataReader["Remarks"]));
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
                    dataReader["WeeklyOff"], dataReader["Gender"], dataReader["Nationality"], dataReader["Language"], dataReader["Accomodation"], dataReader["Transport"], dataReader["Meals"],
                    dataReader["INOUT"], dataReader["Status"], 0, dataReader["Remarks"]));
                }
                else
                {
                    jobOpenings.Add(new JobOpeningModel(dataReader["DatePosted"], dataReader["OPENING_ID"], dataReader["CompanyName"], dataReader["ClientName"], dataReader["JobLocation"], dataReader["InterviewLocation"],
                    dataReader["EMPLOYEE_ID"], dataReader["ClientContact"], dataReader["Vacancy"], dataReader["Role"], dataReader["SalaryRange"], dataReader["Experience"], dataReader["WorkingHours"], dataReader["WorkingDays"],
                    dataReader["WeeklyOff"], dataReader["Gender"], dataReader["Nationality"], dataReader["Language"], dataReader["Accomodation"], dataReader["Transport"], dataReader["Meals"],
                    dataReader["INOUT"], dataReader["Status"], dataReader["AmountPaid"], dataReader["Remarks"]));
                }
            }
            SetJobOpeningList(jobOpenings);
            return jobOpenings;
        }

        public List<FormModel> GetAllForms()
        {
            this.forms = fileController.GetForms();
            return this.forms;
        }

        public List<ClientModel> GetClients()
        {
            this.clients = clientController.GetClients();
            return clients;
        }

        public List<ClientModel> GetClients(string key)
        {
            this.clients = clientController.GetClients();
            List<ClientModel> toReturn = new List<ClientModel>();

            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].ClientName.ToLower().Contains(key.ToLower()))
                {
                    toReturn.Add(clients[i]);
                }
            }

            this.clients = toReturn;

            return toReturn;
        }

        public List<FormModel> GetAllForms(string Key)
        {
            this.forms = fileController.GetForms();


            List<FormModel> targetForms = new List<FormModel>();


            for (int i = 0; i < this.forms.Count; i++)
            {
                if (this.forms[i].FileName.Contains(Key))
                {
                    targetForms.Add(forms[i]);
                }
            }

            return targetForms;

        }

        public List<RecruiterModel> GetAllRecruitersByKey(string key)
        {
            if (RuntimeController.recruiters == null)
                return null;

            List<RecruiterModel> toReturn = new List<RecruiterModel>();

            for (int i = 0; i < RuntimeController.recruiters.Count; i++)
            {
                if (RuntimeController.recruiters[i].FirstName.Contains(key) || RuntimeController.recruiters[i].MiddleName.Contains(key) || RuntimeController.recruiters[i].LastName.Contains(key) || RuntimeController.recruiters[i].Title.Contains(key))
                {
                    toReturn.Add(recruiters[i]);
                }

            }

            this.SetRecruitersList(toReturn);

            return toReturn;
        }

        public List<DepartmentModel> GetDepartments()
        {
            departments = deptController.GetDepartments();
            return departments;
        }

        public DepartmentModel GetDepartmentFromIndex(int index)
        {
            try
            {
                return departments[index];
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }


        public static RecruiterModel GetRecruiterFromIndex(int index)
        {
            try
            {
                return recruiters[index];
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }

        public static CandidateModel GetCandidateFromIndex(int index)
        {
            try
            {
                return candidates[index];
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }

        public ClientModel GetClientFromIndex(int index)
        {
            try
            {
                return clients[index];
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }

        public RecruiterModel GetRecruiterFromID(string ID)
        {
            List<RecruiterModel> l_recruiters = GetAllRecruiters();

            for (int i = 0; i < l_recruiters.Count; i++)
            {
                if (l_recruiters[i].EmployeeID.Equals(ID))
                {
                    return l_recruiters[i];
                }
            }

            return null;
        }

        public static JobOpeningModel GetOpeningFromIndex(int index)
        {
            return jobOpenings[index];
        }
    }
}
