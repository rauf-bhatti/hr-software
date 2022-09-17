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
using Microsoft.Win32;
using AspireWebHR.Models.FormModels;
using AspireWebHR.Models;

namespace AspireWebHR.Views.AdminViews
{
    /// <summary>
    /// Interaction logic for AddForm.xaml
    /// </summary>
    public partial class AddForm : Window
    {
        private Controllers.HRFileController fileController = new Controllers.HRFileController();
        private string pathToAttachment = "";
        private string pathToFTPattachment = "";
        private FormModel formType;

        private string employeeID;
        private string folderName;


        private ClientModel clientInstance;
        private RecruiterModel recruiterInstance;
        private CandidateModel candidateInstance;


        private bool clientMode = false;
        private bool recruiterMode = false;
        private bool formsMode = false;
        private bool candidateMode = false;


        public AddForm()
        {
            InitializeComponent();
        }


        public AddForm(RecruiterModel recruiterInstance)
        {
            InitializeComponent();
            this.recruiterMode = true;
            this.recruiterInstance = recruiterInstance;

            this.folderName = $"EmployeeFiles/{recruiterInstance.EmployeeID}_{recruiterInstance.FirstName}_{recruiterInstance.LastName}";

        }

        public AddForm(CandidateModel candidateInstance)
        {
            InitializeComponent();
            this.candidateMode  = true;
            this.candidateInstance = candidateInstance;

            this.folderName = $"CandidateFiles/{candidateInstance.CandidateID}_{candidateInstance.FirstName}_{candidateInstance.LastName}";
        }

        public AddForm(FormModel formType)
        {
            InitializeComponent();
            this.formType = formType;
            this.formsMode = true;
        }

        public AddForm(FormModel formType, ClientModel clientInstance)
        {
            InitializeComponent();
            this.clientInstance = clientInstance;
            this.folderName = $"ClientFiles/{clientInstance.ClientName}";
            this.formType = formType;
            this.clientMode = true;
        }

        private void Btn_AddForm_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();

            if (txtBox_FileName.Text.Length > 0)
            {
                if (!openFileDialog.FileName.Equals(""))
                {
                    if (formsMode)
                    {
                        if (formType is OtherForms)
                        {
                            folderName = "OtherForms";
                        }
                        else if (formType is GovernmentForms)
                        {
                            folderName = "GovernmentForms";
                        }

                        else if (formType is EmployeeForms)
                        {
                            //MessageBox.Show("Employee Form being added!");
                            folderName = "EmployeeForms";
                        }
                    }
                    else if (clientMode)
                    {

                    }
                    else if (recruiterMode) { }


                    this.pathToAttachment = openFileDialog.FileName;
                    string targetFileName = FTP.FileParser.RenameFile(pathToAttachment, $"{txtBox_FileName.Text}");
                    this.pathToFTPattachment = $"/{folderName}/{targetFileName}";
                    MessageBox.Show($"File with (target) path: {targetFileName} selected. Original path: {pathToAttachment}. Computed path: {this.pathToFTPattachment}");

                    Btn_AddForm.Content = FTP.FileParser.GetFile(this.pathToAttachment);
                }
            }
            
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
        }

        private void Btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            if (txtBox_FileName.Text.Length > 0)
            {
                if (pathToAttachment != "")
                {
                    if (formsMode)
                    {
                        if (formType is OtherForms)
                        {
                            if (this.fileController.InsertOtherFiles(pathToFTPattachment, FTP.FileParser.GetFileFromFTPString(this.pathToFTPattachment)) != 1)
                            {
                                _ = MessageBox.Show("Error adding file!");
                                return;
                            }
                        }

                        else if (formType is GovernmentForms)
                        {
                            if (this.fileController.InsertGovernmentFile(pathToFTPattachment, FTP.FileParser.GetFileFromFTPString(this.pathToFTPattachment)) != 1)
                            {
                                _ = MessageBox.Show("Error adding file!");
                                return;
                            }
                        }
                    }
                    else if (clientMode)
                    {
                        if (this.fileController.InsertClientFiles(clientInstance.ClientID, pathToFTPattachment, FTP.FileParser.GetFileFromFTPString(this.pathToFTPattachment)) != 1)
                        {
                            _ = MessageBox.Show("Error adding file!");
                            return;
                        }
                    }
                    else if (recruiterMode)
                    {
                        if (this.fileController.InsertEmployeeFile(recruiterInstance.EmployeeID, pathToFTPattachment, FTP.FileParser.GetFileFromFTPString(this.pathToFTPattachment)) != 1)
                        {
                            _ = MessageBox.Show("Error adding file!");
                            return;
                        }
                    }
                    else if (candidateMode)
                    {
                        if (this.fileController.InsertCandidateFile(candidateInstance.CandidateID, pathToFTPattachment, FTP.FileParser.GetFileFromFTPString(this.pathToFTPattachment)) != 1)
                        {
                            _ = MessageBox.Show("Error adding file!");
                            return;
                        }
                    }

                    UploadFile();
                    this.Close();
                }
            }
        }
    }
}
