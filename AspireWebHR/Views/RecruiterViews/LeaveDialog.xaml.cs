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
namespace AspireWebHR.Views.RecruiterViews
{
    /// <summary>
    /// Interaction logic for LeaveDialog.xaml
    /// </summary>
    public partial class LeaveDialog : Window
    {
        private LeaveModel leaveInstance;
        private LeaveController leaveController = new LeaveController();
        public LeaveDialog()
        {
            InitializeComponent();
        }

        public LeaveDialog(LeaveModel leaveInstance)
        {
            this.leaveInstance = leaveInstance;
            InitializeComponent();
        }

        private void Btn_Approve_Click(object sender, RoutedEventArgs e)
        {
            if (leaveController.ModifyLeaveStatus(leaveInstance.QueryizeApprove()) == 1)
            {
                MessageBox.Show("Status updated!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error updating status!");
                this.Close();
            }
        }

        private void Btn_Decline_Click(object sender, RoutedEventArgs e)
        {
            if (leaveController.ModifyLeaveStatus(leaveInstance.QueryizeDecline()) == 1)
            {
                MessageBox.Show("Leave cancelled!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error deleting leave!");
                this.Close();
            }
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
