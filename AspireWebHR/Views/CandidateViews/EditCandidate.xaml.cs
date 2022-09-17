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
using Microsoft.Win32;
using AspireWebHR.Views.AdminViews.FormManagement;

namespace AspireWebHR.Views.CandidateViews
{
    /// <summary>
    /// Interaction logic for EditCandidate.xaml
    /// </summary>
    public partial class EditCandidate : Window
    {

        private string pathToFTPfile = "";
        private string pathToAttachment = "";

        private CandidateModel candidateInstance = new CandidateModel();
        private CandidateController candidateController = new CandidateController();

        public EditCandidate()
        {
            InitializeComponent();
        }

        public EditCandidate(CandidateModel candidateInstance)
        {
            InitializeComponent();
            InitializeValues(candidateInstance);
        }

        private void UploadFile()
        {
            if (pathToAttachment.Length > 0 && pathToFTPfile.Length > 0)
            {
                int resultCode = FTP.FTPConnector.UploadFile(pathToAttachment, pathToFTPfile);

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



        public void InitializeValues(CandidateModel candidateInstance)
        {

            this.candidateInstance = candidateInstance;

            datePicker_EntryDate.SelectedDate = candidateInstance.EntryDate;
            txtBox_FirstName.Text = candidateInstance.FirstName;
            txtBox_MiddleName.Text = candidateInstance.MiddleName;
            txtBox_LastName.Text = candidateInstance.LastName;
            txtBox_Age.Text = candidateInstance.Age.ToString();
            txtBox_MobileNumber.Text = candidateInstance.MobileNumber;
            txtBox_EmailID.Text = candidateInstance.EmailID;
            cbBox_MaritalStatus.SelectedItem = cbBox_MaritalStatus.FindName(candidateInstance.MaritalStatus);
            txtBox_Nationality.Text = candidateInstance.Nationality;
            txtBox_Address.Text = candidateInstance.Address;
            datePicker_BirthDate.SelectedDate = candidateInstance.Birthdate;
            cbBox_Gender.SelectedItem = cbBox_Gender.FindName(candidateInstance.Gender);
            txtBox_ReferenceName.Text = candidateInstance.ReferenceName;
            txtBox_ReferenceNumber.Text = candidateInstance.ReferenceNumber;
            txtBox_JobTitle.Text = candidateInstance.JobTitle;
            txtBox_Skills.Text = candidateInstance.Skills;
            txtBox_Notes.Text = candidateInstance.Notes;
            txtBox_ExpectedSalary.Text = candidateInstance.ExpectedSalary.ToString();
            txtBox_VisaStatus.Text = candidateInstance.VisaStatus;
            txtBox_JobApplied.Text = candidateInstance.JobApplied;

            //if (candidateInstance.Attachments.Length > 0)
            //{
            //    pathToFTPfile = candidateInstance.Attachments;
            //    Btn_Attachment.Content = pathToFTPfile;
            //}


            int expLength = candidateInstance.GetExperienceLength();
            int localCount = 0;

            if (expLength > 0)
            {
                if (localCount < expLength)
                {
                    txtBox_C0.Text = candidateInstance.CandidateExperience[0].CompanyName;
                    txtBox_J0.Text = candidateInstance.CandidateExperience[0].JobTitle;
                    txtBox_S0.Text = candidateInstance.CandidateExperience[0].Salary.ToString();
                    txtBox_D0.Text = candidateInstance.CandidateExperience[0].Duration.ToString();
                    txtBox_R0.Text = candidateInstance.CandidateExperience[0].LeavingReason;
                    localCount++;
                }

                if (localCount < expLength)
                {
                    txtBox_C1.Text = candidateInstance.CandidateExperience[1].CompanyName;
                    txtBox_J1.Text = candidateInstance.CandidateExperience[1].JobTitle;
                    txtBox_S1.Text = candidateInstance.CandidateExperience[1].Salary.ToString();
                    txtBox_D1.Text = candidateInstance.CandidateExperience[1].Duration.ToString();
                    txtBox_R1.Text = candidateInstance.CandidateExperience[1].LeavingReason;
                    localCount++;
                }

                if (localCount < expLength)
                {
                    txtBox_C2.Text = candidateInstance.CandidateExperience[2].CompanyName;
                    txtBox_J2.Text = candidateInstance.CandidateExperience[2].JobTitle;
                    txtBox_S2.Text = candidateInstance.CandidateExperience[2].Salary.ToString();
                    txtBox_D2.Text = candidateInstance.CandidateExperience[2].Duration.ToString();
                    txtBox_R2.Text = candidateInstance.CandidateExperience[2].LeavingReason;
                    localCount++;
                }

                if (localCount < expLength)
                {
                    txtBox_C3.Text = candidateInstance.CandidateExperience[3].CompanyName;
                    txtBox_J3.Text = candidateInstance.CandidateExperience[3].JobTitle;
                    txtBox_S3.Text = candidateInstance.CandidateExperience[3].Salary.ToString();
                    txtBox_D3.Text = candidateInstance.CandidateExperience[3].Duration.ToString();
                    txtBox_R3.Text = candidateInstance.CandidateExperience[3].LeavingReason;
                    localCount++;
                }
            }
        }

        private void Btn_Attachment_Click(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.ShowDialog();

            //if (!openFileDialog.FileName.Equals(""))
            //{
            //    this.pathToAttachment = openFileDialog.FileName;
            //    string targetFileName = FTP.FileParser.RenameFile(pathToAttachment, $"{txtBox_FirstName.Text}_{txtBox_LastName.Text}");
            //    MessageBox.Show($"File with (target) path: {targetFileName} selected. Original path: {pathToAttachment}");

            //    this.pathToFTPfile = $"/CandidateAttachments/{targetFileName}";
            //    Btn_Attachment.Content = FTP.FileParser.GetFile(this.pathToAttachment);
            //}

            ManageForms manageForms = new ManageForms(candidateInstance);
            manageForms.ShowDialog();
        }

        private void Btn_ModifyCandidate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ComboBoxItem gender = (ComboBoxItem)cbBox_Gender.SelectedItem;
                ComboBoxItem marital_status = (ComboBoxItem)cbBox_MaritalStatus.SelectedItem;

                string tempAttachment = candidateInstance.Attachments;
                candidateInstance.Attachments = pathToFTPfile;

                if (txtBox_C0.Text.Length < 1)
                {
                    txtBox_D0.Text = "0";
                    txtBox_S0.Text = "0";
                }

                if (txtBox_C1.Text.Length < 1)
                {
                    txtBox_D1.Text = "0";
                    txtBox_S1.Text = "0";
                }

                if (txtBox_C2.Text.Length < 1)
                {
                    txtBox_D2.Text = "0";
                    txtBox_S2.Text = "0";
                }

                if (txtBox_C3.Text.Length < 1)
                {
                    txtBox_D3.Text = "0";
                    txtBox_S3.Text = "0";
                }

                try
                {
                    if (candidateController.ModifyCandidate(candidateInstance.CandidateID, (DateTime)datePicker_EntryDate.SelectedDate, txtBox_FirstName.Text, txtBox_MiddleName.Text, txtBox_LastName.Text, Convert.ToInt32(txtBox_Age.Text), txtBox_MobileNumber.Text, txtBox_EmailID.Text,
                            marital_status.Content.ToString(), txtBox_Nationality.Text, txtBox_Address.Text, (DateTime)datePicker_BirthDate.SelectedDate, gender.Content.ToString(), txtBox_ReferenceName.Text, txtBox_JobTitle.Text, txtBox_Skills.Text, txtBox_ReferenceNumber.Text, txtBox_Notes.Text, pathToFTPfile,
                            txtBox_C0.Text, txtBox_J0.Text, Convert.ToInt32(txtBox_S0.Text), Convert.ToInt32(txtBox_D0.Text), txtBox_R0.Text,
                            txtBox_C1.Text, txtBox_J1.Text, Convert.ToInt32(txtBox_S1.Text), Convert.ToInt32(txtBox_D1.Text), txtBox_R1.Text, txtBox_C2.Text, txtBox_J2.Text, Convert.ToInt32(txtBox_S2.Text), Convert.ToInt32(txtBox_D2.Text), txtBox_R2.Text,
                            txtBox_C3.Text, txtBox_J3.Text, Convert.ToInt32(txtBox_S3.Text), Convert.ToInt32(txtBox_D3.Text), txtBox_R3.Text, Convert.ToInt32(txtBox_ExpectedSalary.Text), txtBox_VisaStatus.Text, txtBox_JobApplied.Text))
                    {
                        if (pathToFTPfile.Length > 0 && !tempAttachment.Equals(pathToFTPfile))
                        {
                            UploadFile();
                        }
                        MessageBox.Show("Candidate has been successfully modified!");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Some field is missing! Exception reached.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Some field is missing! Exception reached.");
            }

        }

        private void Btn_GetFile_Click(object sender, RoutedEventArgs e)
        {
            if (candidateInstance.Attachments.Length > 0)
            {
                if (FTP.FTPConnector.DownloadFile(candidateInstance.Attachments, FTP.FileParser.GetFileFromFTPString($"D:\\CandidateAttachments\\{candidateInstance.Attachments}")) == 1) 
                {
                    MessageBox.Show("File Downloaded");
                }
                else
                {
                    MessageBox.Show("Trouble downloading the file. Please reupload!");
                    candidateInstance.Attachments = "";
                }

            }
        }
    }
}
