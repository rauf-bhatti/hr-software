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
using AspireWebHR.Models.FormModels;

namespace AspireWebHR.Views.AdminViews.FormManagement
{
    /// <summary>
    /// Interaction logic for ManageClientForms.xaml
    /// </summary>
    public partial class ManageClientForms : Window
    {
        RuntimeController runtimeController = new RuntimeController();
        public ManageClientForms()
        {
            InitializeComponent();
            BindDataToGrid();
        }

        private void BindDataToGrid()
        {
            this.listView_Main.ItemsSource = runtimeController.GetClients();
        }

        private void Btn_AddClient_Click(object sender, RoutedEventArgs e)
        {
            AddClient addClient = new AddClient();
            addClient.ShowDialog();

            BindDataToGrid();
        }

        private void listView_Main_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int selectedItem = listView_Main.SelectedIndex;

            ClientModel clientInstance = runtimeController.GetClientFromIndex(selectedItem);

            ManageForms manageForms = new ManageForms(clientInstance);
            manageForms.ShowDialog();
        }

        private void txtBox_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.listView_Main.ItemsSource = runtimeController.GetClients(txtBox_Search.Text);
        }

        private void Btn_Refresh_Click(object sender, RoutedEventArgs e)
        {
            this.txtBox_Search.Text = "";
            BindDataToGrid();
        }
    }
}
