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
using AspireWebHR.FTP;
using AspireWebHR.Models.FormModels;
using AspireWebHR.Controllers;

namespace AspireWebHR.Views.AdminViews.FormManagement
{
    /// <summary>
    /// Interaction logic for ActionPrompt.xaml
    /// </summary>
    public partial class ActionPrompt : Window
    {
        private string filePath;
        private dynamic form;
        private HRFileController fileController = new HRFileController();

        public ActionPrompt()
        {
            InitializeComponent();
        }

        public ActionPrompt(string filePath)
        {
            InitializeComponent();
            this.filePath = filePath;
        }

        public ActionPrompt(dynamic form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void Btn_DownloadFile_Click(object sender, RoutedEventArgs e)
        {
            filePath = (string)form.FilePath;

            if (FTP.FTPConnector.DownloadFile(filePath, $"D:\\AspireWebDownloads\\{FTP.FileParser.GetFileFromFTPString(filePath)}") == 1)
            {
                MessageBox.Show("File downloaded in D:\\AspireWebDownloads!");
            }
            this.Close();
        }

        private void btn_DeleteFile_Click(object sender, RoutedEventArgs e)
        {
            if (FTPConnector.DeleteFile((string)form.FilePath) > 0)
            {
                if (fileController.DeleteForm(form.QueryizeDelete()) == 1)
                {
                    MessageBox.Show("File deleted!");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("File could not be deleted! Please contact support!");
            }
        }
    }
}
