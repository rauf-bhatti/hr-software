using System;
using System.Collections.Generic;
using System.Text;

namespace AspireWebHR.Controllers
{
    class LoginController : Controller
    {
        public int CheckLogin(string username, string password)
        {
            try
            {
                dynamic dataReader = dbInstance.RunReceiveQuery($"SELECT * FROM Employees_Table WHERE EMPLOYEE_ID = '{username}' AND user_password = '{password}'", 1);

                if (dataReader.HasRows == false)
                {
                    return 0;
                }

                while (dataReader.Read())
                {
                    RuntimeController.RecruiterFullName = $"{dataReader["FirstName"]} {dataReader["MiddleName"]} {dataReader["LastName"]} ";
                    RuntimeController.RecruiterID = dataReader["EMPLOYEE_ID"];
                    RuntimeController.RecruiterLevel = dataReader["user_level"];
                }
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
