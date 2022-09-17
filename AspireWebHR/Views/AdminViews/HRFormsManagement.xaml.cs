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
using System.Drawing.Printing;
using AspireWebHR.Models;
using AspireWebHR.Models.FormModels;

namespace AspireWebHR.Views.AdminViews
{
    /// <summary>
    /// Interaction logic for HRFormsManagement.xaml
    /// </summary>
    public partial class HRFormsManagement : Window
    {
        private HRFileController fileController = new HRFileController();
        private RuntimeController runtimeController = new RuntimeController();


        public HRFormsManagement()
        {
            InitializeComponent();
            BindDataToGrid();
        }

        private void BindDataToGrid()
        {
            this.listView_Main.ItemsSource = runtimeController.GetAllForms();
        }

        private void BindDataToGrid(string Key)
        {
            this.listView_Main.ItemsSource = runtimeController.GetAllForms(Key);
        }

        private void Btn_AddForm_Click(object sender, RoutedEventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.ShowDialog();

            BindDataToGrid();
        }

        private void listView_Main_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int selectedIndex = listView_Main.SelectedIndex;
            if (selectedIndex >= 0)
            {
                FormModel form = fileController.GetForms()[selectedIndex];

                MessageBoxResult result = MessageBox.Show($"Would you like to download this file named: {FTP.FileParser.GetFileFromFTPString(form.FileName)}", "Download File", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    if (FTP.FTPConnector.DownloadFile(form.FilePath, $"D:\\HRForms\\{FTP.FileParser.GetFileFromFTPString(form.FilePath)}") == 1)
                    {
                        MessageBox.Show("File downloaded in D:\\HRForms!");
                    }
                }
                
            }
        }

        private void txtBox_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            BindDataToGrid(txtBox_Search.Text);
        }
    }
}
