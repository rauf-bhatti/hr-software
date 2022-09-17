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
using AspireWebHR.Models.FormModels;

namespace AspireWebHR.Views.AdminViews.FormManagement
{
    /// <summary>
    /// Interaction logic for FormDashboard.xaml
    /// </summary>
    public partial class FormDashboard : Window
    {
        public FormDashboard()
        {
            InitializeComponent();
        }

        private void Btn_HRForms_Click(object sender, RoutedEventArgs e)
        {
            ManageForms manageForm = new ManageForms(1);
            manageForm.ShowDialog();
        }

        private void Btn_Other_Forms_Click(object sender, RoutedEventArgs e)
        {
            ManageForms manageForm = new ManageForms(3);
            manageForm.ShowDialog();
        }

        private void Btn_Government_Forms_Click(object sender, RoutedEventArgs e)
        {
            ManageForms manageForm = new ManageForms(2);
            manageForm.ShowDialog();
        }

        private void Btn_Clients_Forms_Click(object sender, RoutedEventArgs e)
        {
            ManageClientForms manageForm = new ManageClientForms();
            manageForm.ShowDialog();
        }
    }
}
