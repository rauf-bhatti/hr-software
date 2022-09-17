using System;
using System.Collections.Generic;
using System.Text;
using AspireWebHR.Models;
using AspireWebHR.Models.FormModels;

namespace AspireWebHR.Controllers
{
    class HRFileController : Controller
    {
        public int InsertFile(string FilePath, string FileName)
        {
            try
            {
                FormModel formInstance = new FormModel(FilePath, FileName);
                return dbInstance.RunInsertionQuery(formInstance.QueryizeInsert());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return 1;
        }

        public int InsertEmployeeFile(string EmployeeID, string FilePath, string FileName)
        {
            try
            {
                EmployeeForms formInstance = new EmployeeForms(EmployeeID, FilePath, FileName);
                return dbInstance.RunInsertionQuery(formInstance.QueryizeInsert());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return 1;
        }

        public int InsertCandidateFile(int CandidateID, string FilePath, string FileName)
        {
            try
            {
                CandidateForms formInstance = new CandidateForms(CandidateID, FilePath, FileName);
                return dbInstance.RunInsertionQuery(formInstance.QueryizeInsert());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return 1;
        }

        public int InsertGovernmentFile(string FilePath, string FileName)
        {
            try
            {
                GovernmentForms formInstance = new GovernmentForms(FilePath, FileName);
                return dbInstance.RunInsertionQuery(formInstance.QueryizeInsert());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return 1;
        }

        public int InsertOtherFiles(string FilePath, string FileName)
        {
            try
            {
                OtherForms formInstance = new OtherForms(FilePath, FileName);
                return dbInstance.RunInsertionQuery(formInstance.QueryizeInsert());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return 1;
        }

        public int InsertClientFiles(int ClientID, string FilePath, string FileName)
        {
            try
            {
                ClientForms formInstance = new ClientForms(ClientID, FilePath, FileName);
                return dbInstance.RunInsertionQuery(formInstance.QueryizeInsert());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<FormModel> GetForms()
        {
            try
            {
                dynamic dataReader = dbInstance.RunReceiveQuery("SELECT * FROM HRForms", 1);
                List<FormModel> forms = new List<FormModel>();

                while (dataReader.Read())
                {
                    forms.Add(new FormModel(dataReader["FormID"], dataReader["PathToFile"], dataReader["FileName"]));
                }
                return forms;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }

        public List<GovernmentForms> GetGovernmentForms()
        {
            try
            {
                dynamic dataReader = dbInstance.RunReceiveQuery("SELECT * FROM GovernmentForms", 1);
                List<GovernmentForms> forms = new List<GovernmentForms>();

                while (dataReader.Read())
                {
                    forms.Add(new GovernmentForms(dataReader["FormID"], dataReader["PathToFile"], dataReader["FileName"]));
                }
                return forms;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }


        public List<OtherForms> GetOtherForms()
        {
            try
            {
                dynamic dataReader = dbInstance.RunReceiveQuery("SELECT * FROM OtherForms", 1);
                List<OtherForms> forms = new List<OtherForms>();

                while (dataReader.Read())
                {
                    forms.Add(new OtherForms(dataReader["FormID"], dataReader["PathToFile"], dataReader["FileName"]));
                }
                return forms;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }


        public List<EmployeeForms> GetHRForms(string EmployeeID)
        {
            try
            {
                dynamic dataReader = dbInstance.RunReceiveQuery($"SELECT * FROM EmployeeForms WHERE Employee_ID = '{EmployeeID}'", 1);
                List<EmployeeForms> forms = new List<EmployeeForms>();

                while (dataReader.Read())
                {
                    forms.Add(new EmployeeForms(dataReader["Employee_ID"], dataReader["FormID"], dataReader["PathToFile"], dataReader["FileName"]));
                }
                return forms;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }

        public List<CandidateForms> GetCandidateForms(int CandidateID)
        {
            try
            {
                dynamic dataReader = dbInstance.RunReceiveQuery($"SELECT * FROM CandidateForms WHERE CandidateID = {CandidateID}", 1);
                List<CandidateForms> forms = new List<CandidateForms>();

                while (dataReader.Read())
                {
                    forms.Add(new CandidateForms(dataReader["CandidateID"], dataReader["FormID"], dataReader["PathToFile"], dataReader["FileName"]));
                }
                return forms;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }

        public List<EmployeeForms> GetHRForms()
        {
            try
            {
                dynamic dataReader = dbInstance.RunReceiveQuery($"SELECT * FROM EmployeeForms", 1);
                List<EmployeeForms> forms = new List<EmployeeForms>();

                while (dataReader.Read())
                {
                    forms.Add(new EmployeeForms(dataReader["Employee_ID"], dataReader["FormID"], dataReader["PathToFile"], dataReader["FileName"]));
                }
                return forms;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }

        public List<ClientForms> GetClientForms(int ClientID)
        {
            try
            {
                dynamic dataReader = dbInstance.RunReceiveQuery($"SELECT * FROM ClientForms WHERE ClientID = {ClientID}", 1);
                List<ClientForms> forms = new List<ClientForms>();

                while (dataReader.Read())
                {
                    forms.Add(new ClientForms(dataReader["ClientID"], dataReader["FormID"], dataReader["PathToFile"], dataReader["FileName"]));
                }
                return forms;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }

        public int DeleteForm(string query)
        {
            try
            {
                return dbInstance.RunDeletionQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
