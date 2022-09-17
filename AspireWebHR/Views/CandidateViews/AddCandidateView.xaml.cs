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
using Microsoft.Win32;

namespace AspireWebHR.Views.CandidateViews
{
    /// <summary>
    /// Interaction logic for AddCandidateView.xaml
    /// </summary>
    public partial class AddCandidateView : Window
    {
        private CandidateController candidateController = new CandidateController();

        private string pathToFTPfile = "";
        private string pathToAttachment = "";

        public AddCandidateView()
        {
            InitializeComponent();
        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                ComboBoxItem gender = (ComboBoxItem)cbBox_Gender.SelectedItem;
                ComboBoxItem marital_status = (ComboBoxItem)cbBox_MaritalStatus.SelectedItem;

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



                if (candidateController.AddCandidate((DateTime)datePicker_EntryDate.SelectedDate, txtBox_FirstName.Text, txtBox_MiddleName.Text, txtBox_LastName.Text, Convert.ToInt32(txtBox_Age.Text), txtBox_MobileNumber.Text, txtBox_EmailID.Text,
                    marital_status.Content.ToString(), txtBox_Nationality.Text, txtBox_Address.Text, (DateTime)datePicker_BirthDate.SelectedDate, gender.Content.ToString(), txtBox_ReferenceName.Text, txtBox_JobTitle.Text, txtBox_Skills.Text, txtBox_ReferenceNumber.Text, txtBox_Notes.Text, pathToFTPfile,
                    txtBox_C0.Text, txtBox_J0.Text, Convert.ToInt32(txtBox_S0.Text), Convert.ToInt32(txtBox_D0.Text), txtBox_R0.Text,
                    txtBox_C1.Text, txtBox_J1.Text, Convert.ToInt32(txtBox_S1.Text), Convert.ToInt32(txtBox_D1.Text), txtBox_R1.Text, txtBox_C2.Text, txtBox_J2.Text, Convert.ToInt32(txtBox_S2.Text), Convert.ToInt32(txtBox_D2.Text), txtBox_R2.Text,
                    txtBox_C3.Text, txtBox_J3.Text, Convert.ToInt32(txtBox_S3.Text), Convert.ToInt32(txtBox_D3.Text), txtBox_R3.Text, Convert.ToInt32(txtBox_ExpectedSalary.Text), txtBox_VisaStatus.Text, txtBox_JobApplied.Text))
                {
                    MessageBox.Show("Candidate has been inserted!");
                    if (pathToFTPfile.Length > 0)
                    {
                        UploadFile();
                    }

                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
            }

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

        private void Btn_AttachFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();

            if (!openFileDialog.FileName.Equals(""))
            {
                this.pathToAttachment = openFileDialog.FileName;
                string targetFileName = FTP.FileParser.RenameFile(pathToAttachment, $"{txtBox_FirstName.Text}_{txtBox_LastName.Text}");
                MessageBox.Show($"File with (target) path: {targetFileName} selected. Original path: {pathToAttachment}");

                this.pathToFTPfile = $"/CandidateAttachments/{targetFileName}";
                Btn_AttachFile.Content = FTP.FileParser.GetFile(this.pathToAttachment);
            }
        }
    }
}
