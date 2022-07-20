using System;
using System.Collections.Generic;
using System.Text;
using AspireWebHR.Models;

namespace AspireWebHR.Controllers
{
    class JobOpeningController : Controller
    {
        public List<JobOpeningModel> GetAllJobOpenings()
        {
            dynamic dataReader = dbInstance.RunReceiveQuery("SELECT * FROM Job_Openings", 1);
            List<JobOpeningModel> toReturn = new List<JobOpeningModel>();


            while (dataReader.Read())
            {
                toReturn.Add(new JobOpeningModel(dataReader["OPENING_ID"], dataReader["OpeningTitle"], dataReader["OpeningDate"]));
            }

            return toReturn;
        }

        public int AddJobOpening(string JobTitle, DateTime ActiveDate)
        {
            JobOpeningModel openingInstance = new JobOpeningModel(JobTitle, ActiveDate);

            try
            {
                dbInstance.RunInsertionQuery(openingInstance.QueryizeInsert());
                return 1;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
                return -1;
            }

        }
    }
}
