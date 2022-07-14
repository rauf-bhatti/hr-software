using System;
using System.Collections.Generic;
using System.Text;

namespace AspireWebHR.Models
{
    class RecruiterModel
    {
        public string EmployeeID { get; set; }
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

        public RecruiterModel(string EmployeeID, string FirstName, string MiddleName, string LastName, int Age, string MobileNumber, string EmailID, string Nationality,
             string Address, DateTime BirthDate, string Gender, string MaritalStatus, DateTime HireDate, string SupervisorName, string Department, int Salary, int Medical_Leaves,
             int Non_Medical_Leaves, string Notes, bool On_Leave, string user_password, int user_level)
        {
            this.EmployeeID = EmployeeID;
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
        }

        public string QueryizeInsert()
        {
            string query = $"INSERT INTO Employees_Table (EMPLOYEE_ID, FirstName, MiddleName, LastName, Age, MobileNumber, EmailID, Nationality, Address, Birthdate, Gender, MaritalStatus, Hiredate, SupervisorName, Department, Salary, MedicalLeaves, NonMedicalLeaves, On_Leave, Notes, user_password, user_level)" +
                $"VALUES ('{this.EmployeeID}', '{this.FirstName}', '{this.MiddleName}', '{this.LastName}', '{this.Age}', '{this.MobileNumber}', '{this.EmailID}', '{this.Nationality}', '{this.Address}', '{this.BirthDate}', '{this.Gender}', '{this.MaritalStatus}', '{this.HireDate}', '{this.SupervisorName}', '{this.Department}', '{this.Salary}', '{this.Medical_Leaves}', '{this.Non_Medical_Leaves}', '{this.On_Leave}', '{this.Notes}', '{this.user_password}', '{this.user_level}')";

            return query;
        }
    }
}
