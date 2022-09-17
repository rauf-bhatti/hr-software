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
using Microsoft.Win32;
using AspireWebHR.Views.AdminViews.FormManagement;

namespace AspireWebHR.Views.RecruiterViews
{
    /// <summary>
    /// Interaction logic for EditRecruiter.xaml
    /// </summary>
    public partial class EditRecruiter : Window
    {
        private RecruiterController recruiterController = new RecruiterController();
        private RuntimeController runtimeController = new RuntimeController();
        private RecruiterModel recruiterInstance = new RecruiterModel();

        private string pathToAttachment = "";
        private string pathToFTPattachment = "";


        public EditRecruiter()
        {
            InitializeComponent();
        }

        public EditRecruiter(RecruiterModel recruiterInstance)
        {
            InitializeComponent();
            InitializeValues(recruiterInstance);
        }

        public void InitializeDropdown()
        {
            List<DepartmentModel> deptModel = this.runtimeController.GetDepartments();
            int savedDeptIndex = -1;

            for (int i = 0; i < deptModel.Count; i++)
            {
                if (deptModel[i].DepartmentName.Equals(recruiterInstance.Department))
                {
                    savedDeptIndex = i;
                }
                this.cbBox_Department.Items.Add(deptModel[i].DepartmentName);
            }

            if (savedDeptIndex != -1)
            {
                this.cbBox_Department.SelectedItem = this.cbBox_Department.Items[savedDeptIndex];
            }
        }


        private void InitializeValues(RecruiterModel recruiterInstance)
        {
            this.recruiterInstance = recruiterInstance;

            this.pathToFTPattachment = recruiterInstance.attachment;

            if (!recruiterInstance.attachment.Equals(""))
            {
            }



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
            InitializeDropdown();
            txtBox_Salary.Text = recruiterInstance.Salary.ToString();
            txtBox_MedLeaves.Text = recruiterInstance.Medical_Leaves.ToString();
            txtBox_NonMedLeaves.Text = recruiterInstance.Non_Medical_Leaves.ToString();
            txtBox_Notes.Text = recruiterInstance.Notes;
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


        private void btn_ModifyRecruiter_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem gender = (ComboBoxItem)cbBox_Gender.SelectedItem;
            ComboBoxItem marital_status = (ComboBoxItem)cbBox_MaritalStatus.SelectedItem;
            string department = (string)cbBox_Department.SelectedItem;

            string tempAttachment = recruiterInstance.attachment;
            recruiterInstance.attachment = pathToFTPattachment;

            int returnCode = recruiterController.ModifyRecruiter(txtBox_EmployeeID.Text, txtBox_Title.Text, txtBox_FirstName.Text, txtBox_MiddleName.Text, txtBox_LastName.Text, Convert.ToInt32(txtBox_Age.Text),
                    txtBox_MobileNumber.Text, txtBox_EmailID.Text, txtBox_Nationality.Text, txtBox_Address.Text, (DateTime)datePicker_Birthdate.SelectedDate, gender.Content.ToString(), marital_status.Content.ToString(), (DateTime)datePicker_HireDate.SelectedDate,
                    txtBox_SupervisorName.Text, department, Convert.ToInt32(txtBox_Salary.Text), Convert.ToInt32(txtBox_MedLeaves.Text), Convert.ToInt32(txtBox_NonMedLeaves.Text), txtBox_Notes.Text,
                    recruiterInstance.user_password, recruiterInstance.user_level, recruiterInstance.attachment);

            if (returnCode == 1)
            {
                if (!tempAttachment.Equals(pathToFTPattachment))
                {
                    UploadFile();
                }

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

        private void Btn_GeneratePayslip_Click(object sender, RoutedEventArgs e)
        {
            PayrollViews.AddPayslip addPayslip = new PayrollViews.AddPayslip();
            addPayslip.ShowDialog();
        }

        private void Btn_PromoteRecruiter_Click(object sender, RoutedEventArgs e)
        {
            if (this.recruiterController.PromoteRecruiter(recruiterInstance.QueryizePromotion()) == 1)
            {
                MessageBox.Show("Recruiter level updated!");
                this.Close();
            }
            else
            {
                MessageBox.Show("There was an issue. Please try again later!");
                this.Close();
            }
        }

        private void Btn_DeleteRecruiter_Click(object sender, RoutedEventArgs e)
        {
            if (this.recruiterController.DeleteRecruiter(recruiterInstance.QueryizeDeletion()) == 1)
            {
                MessageBox.Show("Recruiter deleted!");
                this.Close();
            }
            else
            {
                MessageBox.Show("There was an issue. Please try again later!");
                this.Close();
            }
        }

        private void Btn_ManageIncentives_Click(object sender, RoutedEventArgs e)
        {
            PayrollViews.IncentiveView.ManageIncentives manageIncentives = new PayrollViews.IncentiveView.ManageIncentives(recruiterInstance);
            manageIncentives.ShowDialog();
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
            }
        }

        private void Btn_GetFile_Click(object sender, RoutedEventArgs e)
        {
            if (recruiterInstance.attachment.Length > 0)
            {
                if (FTP.FTPConnector.DownloadFile(recruiterInstance.attachment, FTP.FileParser.GetFileFromFTPString($"D:\\RecruiterAttachments\\{recruiterInstance.attachment}")) == 1)
                {
                    MessageBox.Show("File Downloaded");
                }
                else
                {
                    MessageBox.Show("Trouble downloading the file. Please reupload!");
                    recruiterInstance.attachment = "";
                }

            }

        }

        private void Btn_ManageAttachments_Click(object sender, RoutedEventArgs e)
        {
            ManageForms manageForms = new ManageForms(recruiterInstance);
            manageForms.ShowDialog();
        }

        private void Btn_ResetPassword_Click(object sender, RoutedEventArgs e)
        {
            if (recruiterController.ResetPassword(this.recruiterInstance) == 1)
            {
                MessageBox.Show($"Password for user: {recruiterInstance.FirstName} {recruiterInstance.LastName} has been changed!");
            }
            else
            {
                MessageBox.Show($"Error resetting password for user: {recruiterInstance.FirstName} {recruiterInstance.LastName}");
            }
        }
    }
}
