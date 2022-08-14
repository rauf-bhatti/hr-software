using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AspireWebHR.Views;
using AspireWebHR.Controllers;

namespace AspireWebHR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LoginController loginController = new LoginController();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int returnCode = loginController.CheckLogin(txtBox_Username.Text, txtBox_Password.Password);

            if (returnCode == -1)
            {
                MessageBox.Show("[Technical Error] Technical Error is in place.");
                return;
            }
            else if (returnCode == 0)
            {
                MessageBox.Show("[Error] Wrong username or password entered!");
                return;
            }

            Dashboard viewDashboard = new Dashboard();
            this.Hide();
            viewDashboard.ShowDialog();
            this.Close();
        }
    }
}
