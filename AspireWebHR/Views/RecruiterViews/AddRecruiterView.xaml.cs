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
using AspireWebHR.Models;
using Microsoft.Win32;
namespace AspireWebHR.Views.RecruiterViews
{
    /// <summary>
    /// Interaction logic for AddRecruiterView.xaml
    /// </summary>
    /// 
    public partial class AddRecruiterView : Window
    {
        private RecruiterController recruiterController = new RecruiterController();
        private RuntimeController runtimeController = new RuntimeController();
        private string pathToAttachment = "";
        private string pathToFTPattachment = "";

        public AddRecruiterView()
        {
            InitializeComponent();
            InitializeDropdown();
        }

        public void InitializeDropdown()
        {
            List<DepartmentModel> deptModel = this.runtimeController.GetDepartments();

            for (int i = 0; i < deptModel.Count; i++)
            {
                this.cbBox_Department.Items.Add(deptModel[i].DepartmentName);
            }

            this.cbBox_Department.SelectedItem = this.cbBox_Department.Items[2];
        }

        private void UploadFile()
        {
            if (pathToAttachment.Length > 0 && pathToFTPattachment.Length > 0)
            {
                int resultCode = FTP.FTPConnector.UploadFile(pathToAttachment, pathToFTPattachment);

                if (resultCode == -2)
                {
                    MessageBox.Show("Connection unsuccessful!");
                }
                else if (resultCode == -1)
                {
                    MessageBox.Show("Could not upload!");
                }
                else if (resultCode == 0)
                {
                    MessageBox.Show("File already exists!");
                }
                else
                {
                    MessageBox.Show("Upload successful!");
                }

                return;
            }

            return;
        }


        private void btn_SubmitRecruiter_Click(object sender, RoutedEventArgs e)
        {
            try //Handle Exception incase someone enters alphabetical values in a numerical field and the conversion generates an exception.
            {
                ComboBoxItem gender = (ComboBoxItem)cbBox_Gender.SelectedItem;
                ComboBoxItem marital_status = (ComboBoxItem)cbBox_MaritalStatus.SelectedItem;
                string department = (string)cbBox_Department.SelectedItem;



                int returnCode = recruiterController.AddRecruiter(txtBox_EmployeeID.Text, txtBox_Title.Text, txtBox_FirstName.Text, txtBox_MiddleName.Text, txtBox_LastName.Text, Convert.ToInt32(txtBox_Age.Text),
                    txtBox_MobileNumber.Text, txtBox_EmailID.Text, txtBox_Nationality.Text, txtBox_Address.Text, (DateTime)datePicker_Birthdate.SelectedDate, gender.Content.ToString(), marital_status.Content.ToString(), (DateTime)datePicker_HireDate.SelectedDate,
                    txtBox_SupervisorName.Text, department, Convert.ToInt32(txtBox_Salary.Text), Convert.ToInt32(txtBox_MedLeaves.Text), Convert.ToInt32(txtBox_NonMedLeaves.Text), txtBox_Notes.Text, pathToFTPattachment);
                
                //if (pathToAttachment.Length > 1 && pathToFTPattachment.Length > 1)
                //{
                //    this.Btn_RecruiterAttachment.Content = "Uploading...";
                //}

                if (returnCode == 1)
                {
                    UploadFile();
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

        private void Btn_RecruiterAttachment_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();

            if (!openFileDialog.FileName.Equals(""))
            {
                this.pathToAttachment = openFileDialog.FileName;
                string targetFileName = FTP.FileParser.RenameFile(pathToAttachment, $"{txtBox_EmployeeID.Text}_{txtBox_FirstName.Text}");
                MessageBox.Show($"File with (target) path: {targetFileName} selected. Original path: {pathToAttachment}");

                this.pathToFTPattachment = $"/EmployeeAttachments/{targetFileName}";
                Btn_RecruiterAttachment.Content = FTP.FileParser.GetFile(this.pathToAttachment);
            }
        }
    }
}
