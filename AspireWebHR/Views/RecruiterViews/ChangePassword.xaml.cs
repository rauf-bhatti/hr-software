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

namespace AspireWebHR.Views.RecruiterViews
{
    /// <summary>
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        RecruiterController recruiterController = new RecruiterController();

        public ChangePassword()
        {
            InitializeComponent();
        }

        public ChangePassword(bool flag)
        {

            InitializeComponent();


            this.Label1.Visibility = Visibility.Hidden;
            this.Label2.Visibility = Visibility.Hidden;
        }

        private void Btn_SavePassword_Click(object sender, RoutedEventArgs e)
        {
            if (recruiterController.UpdateUserPassword(txtBox_Password.Password) == 1)
            {
                MessageBox.Show("Password updated!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Password could not be updated!");
                this.Close();
            }
        }
    }
}
