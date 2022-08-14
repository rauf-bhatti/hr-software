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
using AspireWebHR.Controllers;

namespace AspireWebHR.Views.RecruiterViews
{
    /// <summary>
    /// Interaction logic for AddRecruiterView.xaml
    /// </summary>
    /// 
    public partial class AddRecruiterView : Window
    {
        private RecruiterController recruiterController = new RecruiterController();


        public AddRecruiterView()
        {
            InitializeComponent();
        }

        private void btn_SubmitRecruiter_Click(object sender, RoutedEventArgs e)
        {
            try //Handle Exception incase someone enters alphabetical values in a numerical field and the conversion generates an exception.
            {
                ComboBoxItem gender = (ComboBoxItem)cbBox_Gender.SelectedItem;
                ComboBoxItem marital_status = (ComboBoxItem)cbBox_MaritalStatus.SelectedItem;
                ComboBoxItem department = (ComboBoxItem)cbBox_Department.SelectedItem;

                int returnCode = recruiterController.AddRecruiter(txtBox_EmployeeID.Text, txtBox_Title.Text, txtBox_FirstName.Text, txtBox_MiddleName.Text, txtBox_LastName.Text, Convert.ToInt32(txtBox_Age.Text),
                    txtBox_MobileNumber.Text, txtBox_EmailID.Text, txtBox_Nationality.Text, txtBox_Address.Text, (DateTime)datePicker_Birthdate.SelectedDate, gender.Content.ToString(), marital_status.Content.ToString(), (DateTime)datePicker_HireDate.SelectedDate,
                    txtBox_SupervisorName.Text, department.Content.ToString(), Convert.ToInt32(txtBox_Salary.Text), Convert.ToInt32(txtBox_MedLeaves.Text), Convert.ToInt32(txtBox_NonMedLeaves.Text), txtBox_Notes.Text);

                if (returnCode == 1)
                {
                    MessageBox.Show($"Recruiter: {txtBox_FirstName.Text + " " + txtBox_LastName.Text} has successfully been inserted.");
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
            catch (Exception exception)
            {
                Console.WriteLine($"Exception: {exception.StackTrace}");
            }
        }
    }
}
