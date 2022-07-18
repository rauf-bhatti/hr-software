using System;
using System.Collections.Generic;
using System.Text;
using AspireWebHR.Models;

namespace AspireWebHR.Controllers
{
    class RuntimeController : Controller
    {
        private static List<CandidateModel> candidates = new List<CandidateModel>();

        private void SetCandidatesList(List<CandidateModel> candidatesList)
        {
            candidates = candidatesList;
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

            try
            {
                dynamic dataReader = dbInstance.RunReceiveQuery("SELECT * FROM Candidate_Table", 1);

                while (dataReader.Read())
                {
                    candidates.Add(new CandidateModel(Convert.ToInt32(dataReader["CANDIDATE_ID"].ToString()), Convert.ToInt32(dataReader["RecruiterID"].ToString()), dataReader["EntryDate"], dataReader["FirstName"].ToString(), dataReader["MiddleName"].ToString(), dataReader["LastName"].ToString(), Convert.ToInt32(dataReader["Age"].ToString()), dataReader["MobileNumber"].ToString(), dataReader["EmailID"].ToString(), dataReader["MaritalStatus"].ToString(), dataReader["Nationality"].ToString(), 
                        dataReader["Address"].ToString(), dataReader["Birthdate"], dataReader["Gender"].ToString(), dataReader["ReferenceName"].ToString()));
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
            }

            SetCandidatesList(candidates);
            return candidates;
        }


    }
}
