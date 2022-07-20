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
    /// Interaction logic for LeaveApplication.xaml
    /// </summary>
    public partial class LeaveApplication : Window
    {
        private LeaveController leaveController = new LeaveController();
        public LeaveApplication()
        {
            InitializeComponent();
        }

        private void btn_SubmitLeave_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem reason = (ComboBoxItem)cbBox_Reason.SelectedItem;

            if (leaveController.AddLeave((DateTime)datePicker_FromLeaveDate.SelectedDate, (DateTime)datePicker_ToLeaveDate.SelectedDate, txtBox_Reason.Text, reason.Content.ToString()) == 1)
            {
                MessageBox.Show($"You have successfully applied for leave from: {(DateTime)datePicker_FromLeaveDate.SelectedDate} to: {(DateTime)datePicker_ToLeaveDate.SelectedDate}");
            }
            else
            {
                MessageBox.Show($"Error applying for leave!");
            }
        }
    }
}