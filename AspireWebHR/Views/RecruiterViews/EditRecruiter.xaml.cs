using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AspireWebHR.Models;
using AspireWebHR.Controllers;
using System.Linq;

namespace AspireWebHR.Views.RecruiterViews
{
    /// <summary>
    /// Interaction logic for EditRecruiter.xaml
    /// </summary>
    public partial class EditRecruiter : Window
    {
        private RecruiterController recruiterController = new RecruiterController();
        private RecruiterModel recruiterInstance = new RecruiterModel();
        public EditRecruiter()
        {
            InitializeComponent();
        }

        public EditRecruiter(RecruiterModel recruiterInstance)
        {
            InitializeComponent();
            InitializeValues(recruiterInstance);
        }

        private void InitializeValues(RecruiterModel recruiterInstance)
        {
            this.recruiterInstance = recruiterInstance;
            


            txtBox_EmployeeID.Text = recruiterInstance.EmployeeID;
            txtBox_Title.Text = recruiterInstance.Title;
            txtBox_FirstName.Text = recruiterInstance.FirstName;
            txtBox_MiddleName.Text = recruiterInstance.MiddleName;
            txtBox_LastName.Text = recruiterInstance.LastName;
            txtBox_Age.Text = recruiterInstance.Age.ToString();
            txtBox_MobileNumber.Text = recruiterInstance.MobileNumber;
            txtBox_EmailID.Text = recruiterInstance.EmailID;
            txtBox_Nationality.Text = recruiterInstance.Nationality;
            txtBox_Address.Text = recruiterInstance.Address;
            datePicker_Birthdate.SelectedDate = recruiterInstance.BirthDate;
            cbBox_Gender.SelectedItem = cbBox_Gender.FindName(recruiterInstance.Gender);
            cbBox_MaritalStatus.SelectedItem = cbBox_MaritalStatus.FindName(recruiterInstance.MaritalStatus);
            datePicker_HireDate.SelectedDate = recruiterInstance.HireDate;
            txtBox_SupervisorName.Text = recruiterInstance.SupervisorName;
            cbBox_Department.SelectedItem = cbBox_Department.FindName(recruiterInstance.Department);
            txtBox_Salary.Text = recruiterInstance.Salary.ToString();
            txtBox_MedLeaves.Text = recruiterInstance.Medical_Leaves.ToString();
            txtBox_NonMedLeaves.Text = recruiterInstance.Non_Medical_Leaves.ToString();
            txtBox_Notes.Text = recruiterInstance.Notes;
        }

        private void btn_ModifyRecruiter_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem gender = (ComboBoxItem)cbBox_Gender.SelectedItem;
            ComboBoxItem marital_status = (ComboBoxItem)cbBox_MaritalStatus.SelectedItem;
            ComboBoxItem department = (ComboBoxItem)cbBox_Department.SelectedItem;

            int returnCode = recruiterController.ModifyRecruiter(txtBox_EmployeeID.Text, txtBox_Title.Text, txtBox_FirstName.Text, txtBox_MiddleName.Text, txtBox_LastName.Text, Convert.ToInt32(txtBox_Age.Text),
                    txtBox_MobileNumber.Text, txtBox_EmailID.Text, txtBox_Nationality.Text, txtBox_Address.Text, (DateTime)datePicker_Birthdate.SelectedDate, gender.Content.ToString(), marital_status.Content.ToString(), (DateTime)datePicker_HireDate.SelectedDate,
                    txtBox_SupervisorName.Text, department.Content.ToString(), Convert.ToInt32(txtBox_Salary.Text), Convert.ToInt32(txtBox_MedLeaves.Text), Convert.ToInt32(txtBox_NonMedLeaves.Text), txtBox_Notes.Text,
                    recruiterInstance.user_password, recruiterInstance.user_level);

            if (returnCode == 1)
            {
                MessageBox.Show($"Recruiter: {txtBox_FirstName.Text + " " + txtBox_LastName.Text} has successfully been modified.");
                this.Close();
            }
            else if (returnCode == -1)
            {
                MessageBox.Show("Please rescheck numeric values!");
            }
            else
            {
                MessageBox.Show("Please recheck your form entries!");
            }

        }
    }
}
