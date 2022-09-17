using System;
using System.Collections.Generic;
using System.Text;

namespace AspireWebHR.Models
{
    public class RecruiterModel
    {
        public string EmployeeID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string MobileNumber { get; set; }
        public string EmailID { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime HireDate { get; set; }
        public string SupervisorName { get; set; }
        public string Department { get; set; } //To be replaced when departments are integrated into the system
        public int Salary { get; set; }
        public int Medical_Leaves { get; set; }
        public int Non_Medical_Leaves { get; set; }
        public bool On_Leave { get; set; }
        public string Notes { get; set; }
        public string user_password { get; set; }
        public int user_level { get; set; }
        public string attachment { get; set; }

        public RecruiterModel() { }

        //public RecruiterModel(string EmployeeID, string FirstName, string MiddleName, string LastName, int Age, string MobileNumber, string EmailID, string Nationality,
        //     string Address, DateTime BirthDate, string Gender, string MaritalStatus, DateTime HireDate, string SupervisorName, string Department, int Salary, int Medical_Leaves,
        //     int Non_Medical_Leaves, string Notes, bool On_Leave, string user_password, int user_level)
        //{
        //    this.EmployeeID = EmployeeID;
        //    this.FirstName = FirstName;
        //    this.MiddleName = MiddleName;
        //    this.LastName = LastName;
        //    this.Age = Age;
        //    this.MobileNumber = MobileNumber;
        //    this.EmailID = EmailID;
        //    this.Nationality = Nationality;
        //    this.Address = Address;
        //    this.BirthDate = BirthDate;
        //    this.Gender = Gender;
        //    this.MaritalStatus = MaritalStatus;
        //    this.HireDate = HireDate;
        //    this.SupervisorName = SupervisorName;
        //    this.Department = Department;
        //    this.Salary = Salary;
        //    this.Medical_Leaves = Medical_Leaves;
        //    this.Non_Medical_Leaves = Non_Medical_Leaves;
        //    this.Notes = Notes;
        //    this.On_Leave = On_Leave;
        //    this.user_password = user_password;
        //    this.user_level = user_level;
        //}

        public RecruiterModel(string EmployeeID, string Title, string FirstName, string MiddleName, string LastName, int Age, string MobileNumber, string EmailID, string Nationality,
             string Address, DateTime BirthDate, string Gender, string MaritalStatus, DateTime HireDate, string SupervisorName, string Department, int Salary, int Medical_Leaves,
             int Non_Medical_Leaves, string Notes, bool On_Leave, string user_password, int user_level, string attachment)
        {
            this.EmployeeID = EmployeeID;
            this.Title = Title;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.LastName = LastName;
            this.Age = Age;
            this.MobileNumber = MobileNumber;
            this.EmailID = EmailID;
            this.Nationality = Nationality;
            this.Address = Address;
            this.BirthDate = BirthDate;
            this.Gender = Gender;
            this.MaritalStatus = MaritalStatus;
            this.HireDate = HireDate;
            this.SupervisorName = SupervisorName;
            this.Department = Department;
            this.Salary = Salary;
            this.Medical_Leaves = Medical_Leaves;
            this.Non_Medical_Leaves = Non_Medical_Leaves;
            this.Notes = Notes;
            this.On_Leave = On_Leave;
            this.user_password = user_password;
            this.user_level = user_level;
            this.attachment = attachment;
        }

        public string QueryizeInsert()
        {
            string query = $"INSERT INTO Employees_Table (EMPLOYEE_ID, Title, FirstName, MiddleName, LastName, Age, MobileNumber, EmailID, Nationality, Address, Birthdate, Gender, MaritalStatus, Hiredate, SupervisorName, Department, Salary, MedicalLeaves, NonMedicalLeaves, On_Leave, Notes, user_password, user_level, attachment)" +
                $"VALUES ('{this.EmployeeID}', '{this.Title}', '{this.FirstName}', '{this.MiddleName}', '{this.LastName}', '{this.Age}', '{this.MobileNumber}', '{this.EmailID}', '{this.Nationality}', '{this.Address}', '{this.BirthDate.Year}-{this.BirthDate.Month}-{this.BirthDate.Day}', '{this.Gender}', '{this.MaritalStatus}', '{this.HireDate.Year}-{this.HireDate.Month}-{this.HireDate.Day}', '{this.SupervisorName}', '{this.Department}', '{this.Salary}', '{this.Medical_Leaves}', '{this.Non_Medical_Leaves}', '{this.On_Leave}', '{this.Notes}', '{this.user_password}', '{this.user_level}', '{this.attachment}')";
            return query;
        }

        public string QueryizeModify()
        {
            string query = $"UPDATE Employees_Table SET Title = '{this.Title}', FirstName = '{this.FirstName}', MiddleName = '{this.MiddleName}', " +
                $"LastName = '{this.LastName}', Age = '{this.Age}', MobileNumber = '{this.MobileNumber}'," +
                $"EmailID = '{this.EmailID}', Nationality = '{this.Nationality}', Address = '{this.Address}', Birthdate = '{this.BirthDate.Year}-{this.BirthDate.Month}-{this.BirthDate.Day}', " +
                $"Gender = '{this.Gender}', MaritalStatus = '{this.MaritalStatus}', Hiredate = '{this.HireDate.Year}-{this.HireDate.Month}-{this.HireDate.Day}', SupervisorName = '{this.SupervisorName}', " +
                $"Department = '{this.Department}', Salary = '{this.Salary}', MedicalLeaves = '{this.Medical_Leaves}', NonMedicalLeaves = '{this.Non_Medical_Leaves}', " +
                $"On_Leave = '{this.On_Leave}', Notes = '{this.Notes}', user_password = '{this.user_password}', user_level = '{this.user_level}', attachment = '{attachment}'" +
                $"WHERE EMPLOYEE_ID = '{this.EmployeeID}'";

            return query;
        }

        public string QueryizePromotion()
        {
            return $"UPDATE Employees_Table SET user_level = 2 WHERE EMPLOYEE_ID = '{this.EmployeeID}'";
        }

        public string QueryizeDeletion()
        {
            return $"DELETE FROM Employees_Table WHERE Employee_ID = '{this.EmployeeID}'";
        }
    }
}
