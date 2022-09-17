using System;
using System.Collections.Generic;
using System.Text;
using AspireWebHR.Models;

namespace AspireWebHR.Controllers
{
    class DepartmentController : Controller
    {
        public int AddDepartment(string DepartmentName)
        {
            try
            {
                DepartmentModel newDept = new DepartmentModel(DepartmentName);
                return dbInstance.RunInsertionQuery(newDept.QueryizeInsert());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return -1;
            }

        }

        public int DeleteDepartment(DepartmentModel department)
        {
            try
            {
                return dbInstance.RunDeletionQuery(department.QueryizeDelete());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return -1;
            }
        }

        public List<DepartmentModel> GetDepartments()
        {
            try
            {
                List<DepartmentModel> departments = new List<DepartmentModel>();
                dynamic dataReader = dbInstance.RunReceiveQuery("SELECT * FROM Departments", 1);

                while (dataReader.Read())
                {
                    departments.Add(new DepartmentModel(dataReader["DepartmentID"], dataReader["DepartmentName"]));
                }

                return departments;

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }
    }
}
