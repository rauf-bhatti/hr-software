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

namespace AspireWebHR.Views.AdminViews.FormManagement
{
    /// <summary>
    /// Interaction logic for AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        private ClientController clientController = new ClientController();
        public AddClient()
        {
            InitializeComponent();
        }

        private void Btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            if (txtBox_ClientName.Text.Length > 0)
            {
                if (clientController.InsertClient(txtBox_ClientName.Text) == 1)
                {
                    MessageBox.Show("Client added!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error adding client!");
                }
            }
        }
    }
}
