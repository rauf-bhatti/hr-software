using System;
using System.Collections.Generic;
using System.Text;
using AspireWebHR.Models;

namespace AspireWebHR.Controllers
{
    class IncentivesController : Controller
    {
        public int AddIncentiveEntry(IncentiveModel newIncentive)
        {
            try
            {
                return dbInstance.RunInsertionQuery(newIncentive.QueryizeInsert());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return -1;
            }
        }


        public int DeleteIncentiveEntry(IncentiveModel selectedIncentive)
        {
            try
            {
                return dbInstance.RunDeletionQuery(selectedIncentive.QueryizeDelete());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return -1;
            }
        }

        public int UpdatePaymentStatus(IncentiveModel selectedIncentive, int flag)
        {
            try
            {
                return dbInstance.RunModificationQuery(selectedIncentive.QueryizeStatusUpdate(flag));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return -1;
            }
        }


        public List<IncentiveModel> GetIncentives(string EmployeeID)
        {

            List<IncentiveModel> incentives = new List<IncentiveModel>();
            try
            {
                dynamic dataReader = dbInstance.RunReceiveQuery($"SELECT * FROM Incentives WHERE EMPLOYEE_ID = '{EmployeeID}'", 1);

                while (dataReader.Read())
                {
                    incentives.Add(new IncentiveModel(dataReader["IncentiveID"], dataReader["EMPLOYEE_ID"], dataReader["IncentiveDate"], dataReader["Percentage"], 
                        dataReader["StatusClient"], dataReader["StatusAspire"]));
                }

                return incentives;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }
    }
}
